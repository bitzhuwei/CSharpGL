using GLM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    //TODO:  copyed from ModernRenderer, need to update(This is complex)
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
                // 获取pickedGeometry
                pickedGeometry = this.GetGeometry(lastIndexId, stageVertexId);
            }

            return pickedGeometry;
        }

        private PickedGeometry GetGeometry(RecognizedPrimitiveIndex lastIndexId, uint stageVertexId)
        {
            var pickedGeometry = new PickedGeometry();
            pickedGeometry.GeometryType = this.indexBufferPtr.Mode.ToPrimitiveMode().ToGeometryType();
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
            List<RecognizedPrimitiveIndex> lastIndexIdList = GetLastIndexIdList(lastVertexId);

            RecognizedPrimitiveIndex lastIndexId = GetLastIndexId(
                e, lastIndexIdList, x, y, canvasWidth, canvasHeight);

            return lastIndexId;
        }

        /// <summary>
        /// 在所有可能的图元（<see cref="lastVertexId"/>匹配）中，
        /// 逐个测试，找到最接近摄像机的那个图元，
        /// 返回此图元的最后一个索引在<see cref="indexBufferPtr"/>中的索引（位置）。
        /// </summary>
        /// <param name="lastIndexIdList"></param>
        /// <returns></returns>
        private RecognizedPrimitiveIndex GetLastIndexId(
            RenderEventArgs e,
            List<RecognizedPrimitiveIndex> lastIndexIdList,
            int x, int y, int canvasWidth, int canvasHeight)
        {
            if (lastIndexIdList == null || lastIndexIdList.Count == 0) { throw new ArgumentException(); }

            int current = 0;
#if DEBUG
            NoPrimitiveRestartIndex(lastIndexIdList);
#endif
            for (int i = 1; i < lastIndexIdList.Count; i++)
            {
                OneIndexBufferPtr twoPrimitivesIndexBufferPtr;
                uint lastIndex0, lastIndex1;
                AssembleIndexBuffer(
                    lastIndexIdList[current], lastIndexIdList[i], this.indexBufferPtr.Mode,
                    out twoPrimitivesIndexBufferPtr, out lastIndex0, out lastIndex1);
                uint pickedIndex = Pick(e, twoPrimitivesIndexBufferPtr,
                    x, y, canvasWidth, canvasHeight);
                if (pickedIndex == lastIndex1)
                { current = i; }
                else if (pickedIndex == lastIndex0)
                { /* nothing to do */}
                else if (pickedIndex == uint.MaxValue)// 两个候选图元都没有被拾取到
                { /* nothing to do */}
                else
                { throw new Exception("This should not happen!"); }
            }

            return lastIndexIdList[current];
        }

        private void NoPrimitiveRestartIndex(List<RecognizedPrimitiveIndex> lastIndexIdList)
        {
            PrimitiveRestartSwitch glSwitch = GetPrimitiveRestartSwitch();
            if (glSwitch != null)
            {
                foreach (var lastIndexId in lastIndexIdList)
                {
                    foreach (var indexId in lastIndexId.IndexIdList)
                    {
                        if (indexId == glSwitch.RestartIndex) { throw new Exception(); }
                    }
                }
            }
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

        private void AssembleIndexBuffer(
            RecognizedPrimitiveIndex recognizedPrimitiveIndex0,
            RecognizedPrimitiveIndex recognizedPrimitiveIndex1,
            DrawMode drawMode,
            out OneIndexBufferPtr oneIndexBufferPtr,
            out uint lastIndex0, out uint lastIndex1)
        {
            List<uint> indexArray = ArrangeIndexes(
                recognizedPrimitiveIndex0, recognizedPrimitiveIndex1,
                out lastIndex0, out lastIndex1);
            if (indexArray.Count !=
                recognizedPrimitiveIndex0.IndexIdList.Count
                + 1
                + recognizedPrimitiveIndex1.IndexIdList.Count)
            { throw new Exception(); }

            using (var indexBuffer = new OneIndexBuffer<uint>(drawMode, BufferUsage.StaticDraw))
            {
                indexBuffer.Alloc(
                    recognizedPrimitiveIndex0.IndexIdList.Count
                    + 1
                    + recognizedPrimitiveIndex1.IndexIdList.Count);
                unsafe
                {
                    var array = (uint*)indexBuffer.FirstElement();
                    for (int i = 0; i < indexArray.Count; i++)
                    {
                        array[i] = indexArray[i];
                    }
                }

                oneIndexBufferPtr = indexBuffer.GetBufferPtr() as OneIndexBufferPtr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recognizedPrimitiveIndex0"></param>
        /// <param name="recognizedPrimitiveIndex1"></param>
        /// <returns></returns>
        private List<uint> ArrangeIndexes(
            RecognizedPrimitiveIndex recognizedPrimitiveIndex0,
            RecognizedPrimitiveIndex recognizedPrimitiveIndex1,
            out uint lastIndex0, out uint lastIndex1)
        {
            List<uint> sameIndexList = new List<uint>();
            List<uint> array0 = new List<uint>(recognizedPrimitiveIndex0.IndexIdList);
            List<uint> array1 = new List<uint>(recognizedPrimitiveIndex1.IndexIdList);
            array0.Sort(); array1.Sort();
            int p0 = 0, p1 = 0;
            while (p0 < array0.Count && p1 < array1.Count)
            {
                if (array0[p0] < array1[p1])
                { p0++; }
                else if (array0[p0] > array1[p1])
                { p1++; }
                else
                {
                    sameIndexList.Add(array0[p0]);
                    array0.RemoveAt(p0);
                    array1.RemoveAt(p1);
                }
            }

            if (array0.Count == 0 && array1.Count == 0)
            { throw new Exception("Two primitives are totally the same!"); }

            if (array0.Count > 0)
            { lastIndex0 = array0.Last(); }
            else
            {
                if (sameIndexList.Count == 0)
                { throw new Exception("array0 is totally empty!"); }

                lastIndex0 = sameIndexList.Last();
            }

            if (array1.Count > 0)
            { lastIndex1 = array1.Last(); }
            else
            {
                if (sameIndexList.Count == 0)
                { throw new Exception("array1 is totally empty!"); }

                lastIndex1 = sameIndexList.Last();
            }

            if (lastIndex0 == lastIndex1) { throw new Exception(); }

            List<uint> result = new List<uint>();
            result.AddRange(sameIndexList);
            result.AddRange(array0);
            result.Add(uint.MaxValue);// primitive restart index
            result.AddRange(sameIndexList);
            result.AddRange(array1);

            return result;
        }

        /// <summary>
        /// 遍历以<see cref="lastVerteID"/>为最后一个顶点的图元，
        /// 瞄准每个图元的索引（例如1个三角形有3个索引）中的最后一个索引，
        /// 将此索引在<see cref="indexBufferPtr"/>中的索引（位置）收集起来。
        /// </summary>
        /// <param name="lastVertexId"></param>
        /// <returns></returns>
        private List<RecognizedPrimitiveIndex> GetLastIndexIdList(uint lastVertexId)
        {
            PrimitiveRecognizer recognizer = PrimitiveRecognizerFactory.Create(this.indexBufferPtr.Mode);
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
