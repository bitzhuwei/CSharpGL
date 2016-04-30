
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    // check http://www.cnblogs.com/bitzhuwei/p/CSharpGL-18-Picking-of-OneIndexBuffer.html
    public partial class OneIndexModernRenderer
    {

        public override PickedGeometry Pick(RenderEventArgs e, uint stageVertexId,
            int x, int y, int canvasWidth, int canvasHeight)
        {
            uint lastVertexId;
            PickedGeometry pickedGeometry = null;
            if (this.GetLastVertexIdOfPickedGeometry(stageVertexId, out lastVertexId))
            {
                // 找到 lastIndexId
                RecognizedPrimitiveIndex lastIndexId =
                    this.GetLastIndexIdOfPickedGeometry(
                        e, lastVertexId, x, y, canvasWidth, canvasHeight);
                Debug.WriteLineIf(lastIndexId == null, string.Format(
                    "Got lastVertexId[{0}] but no lastIndexId! Params are [{1}] [{2}] [{3}] [{4}] [{5}] [{6}]",
                    lastVertexId, e, stageVertexId, x, y, canvasWidth, canvasHeight));
                if (lastIndexId != null)
                {
                    // 获取pickedGeometry
                    pickedGeometry = this.GetGeometry(e, lastIndexId, stageVertexId);
                }
            }

            return pickedGeometry;
        }

        private PickedGeometry GetGeometry(RenderEventArgs e,
            RecognizedPrimitiveIndex lastIndexId, uint stageVertexId)
        {
            var pickedGeometry = new PickedGeometry();
            pickedGeometry.GeometryType = this.GetIndexBufferPtr().Mode.ToPrimitiveMode().ToGeometryType();
            pickedGeometry.StageVertexId = stageVertexId;
            pickedGeometry.From = this;
            pickedGeometry.Indexes = lastIndexId.IndexIdList.ToArray();
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
            IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (vec3*)pointer.ToPointer();
                List<vec3> list = new List<vec3>();
                for (int i = 0; i < lastIndexId.IndexIdList.Count; i++)
                {
                    list.Add(array[lastIndexId.IndexIdList[i]]);
                }
                pickedGeometry.Positions = list.ToArray();
            }
            GL.UnmapBuffer(BufferTarget.ArrayBuffer);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            return pickedGeometry;
        }

        private RecognizedPrimitiveIndex GetLastIndexIdOfPickedGeometry(
            RenderEventArgs e,
            uint lastVertexId, int x, int y, int canvasWidth, int canvasHeight)
        {
            List<RecognizedPrimitiveIndex> lastIndexIdList = GetLastIndexIdList(e, lastVertexId);

            if (lastIndexIdList.Count == 0) { return null; }

            RecognizedPrimitiveIndex lastIndexId = GetLastIndexId(
                e, lastIndexIdList, x, y, canvasWidth, canvasHeight);

            return lastIndexId;
        }

        private uint Pick(RenderEventArgs e, OneIndexBufferPtr twoPrimitivesIndexBufferPtr,
            int x, int y, int canvasWidth, int canvasHeight)
        {
            Render4Picking(e, twoPrimitivesIndexBufferPtr);

            uint pickedIndex = ReadPixel(x, y, canvasHeight);

            return pickedIndex;
        }

        private static uint ReadPixel(int x, int y, int canvasHeight)
        {
            // get coded color.
            //byte[] codedColor = new byte[4];
            UnmanagedArray<byte> codedColor = new UnmanagedArray<byte>(4);
            GL.ReadPixels(x, canvasHeight - y - 1, 1, 1, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, codedColor.Header);
            if (!
                // This is when (x, y) is on background and no primitive is picked.
                (codedColor[0] == byte.MaxValue && codedColor[1] == byte.MaxValue
                && codedColor[2] == byte.MaxValue && codedColor[3] == byte.MaxValue))
            {
                // see http://www.cnblogs.com/bitzhuwei/p/modern-opengl-picking-primitive-in-VBO-2.html
                uint shiftedR = (uint)codedColor[0];
                uint shiftedG = (uint)codedColor[1] << 8;
                uint shiftedB = (uint)codedColor[2] << 16;
                uint shiftedA = (uint)codedColor[3] << 24;
                uint stageVertexId = shiftedR + shiftedG + shiftedB + shiftedA;

                return stageVertexId;
            }
            else
            { return uint.MaxValue; }
        }

        private void Render4Picking(RenderEventArgs e, OneIndexBufferPtr twoPrimitivesIndexBufferPtr)
        {
            // 暂存clear color
            var originalClearColor = new float[4];
            GL.GetFloat(GetTarget.ColorClearValue, originalClearColor);

            GL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);// 白色意味着没有拾取到任何对象
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            // 恢复clear color
            GL.ClearColor(originalClearColor[0], originalClearColor[1], originalClearColor[2], originalClearColor[3]);

            ShaderProgram program = this.PickingShaderProgram;
            // 绑定shader
            program.Bind();
            program.SetUniform("pickingBaseID", 0u);
            pickingMVP.SetUniform(program);
            GL.GetDelegateFor<GL.glPrimitiveRestartIndex>()(uint.MaxValue);
            GL.Enable(GL.GL_PRIMITIVE_RESTART);
            foreach (var item in switchList) { item.On(); }
            {
                //var arg = new RenderEventArgs(RenderModes.ColorCodedPicking, camera);
                this.positionBufferPtr.Render(e, program);
                twoPrimitivesIndexBufferPtr.Render(e, program);
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            }
            GL.Disable(GL.GL_PRIMITIVE_RESTART);
            foreach (var item in switchList) { item.Off(); }

            pickingMVP.ResetUniform(program);

            // 解绑shader
            program.Unbind();

            GL.Flush();
        }

        /// <summary>
        /// 遍历以<see cref="lastVerteID"/>为最后一个顶点的图元，
        /// 瞄准每个图元的索引（例如1个三角形有3个索引）中的最后一个索引，
        /// 将此索引在<see cref="indexBufferPtr"/>中的索引（位置）收集起来。
        /// </summary>
        /// <param name="lastVertexId"></param>
        /// <returns></returns>
        private List<RecognizedPrimitiveIndex> GetLastIndexIdList(RenderEventArgs e, uint lastVertexId)
        {
            PrimitiveRecognizer recognizer = PrimitiveRecognizerFactory.Create(
                this.GetIndexBufferPtr().Mode);

            PrimitiveRestartSwitch glSwitch = GetPrimitiveRestartSwitch();

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, this.oneIndexBufferPtr.BufferId);
            IntPtr pointer = GL.MapBuffer(BufferTarget.ElementArrayBuffer, MapBufferAccess.ReadOnly);
            List<RecognizedPrimitiveIndex> lastIndexIdList = null;
            if (glSwitch == null)
            { lastIndexIdList = recognizer.Recognize(lastVertexId, pointer, this.oneIndexBufferPtr); }
            else
            { lastIndexIdList = recognizer.Recognize(lastVertexId, pointer, this.oneIndexBufferPtr, glSwitch.RestartIndex); }
            GL.UnmapBuffer(BufferTarget.ElementArrayBuffer);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

            return lastIndexIdList;
        }

        private PrimitiveRestartSwitch GetPrimitiveRestartSwitch()
        {
            foreach (var item in this.switchList)
            {
                if (item is PrimitiveRestartSwitch)
                {
                    return item as PrimitiveRestartSwitch;
                }
            }

            return null;
        }
    }
}
