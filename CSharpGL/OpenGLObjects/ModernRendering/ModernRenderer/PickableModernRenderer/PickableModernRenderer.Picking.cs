
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class PickableModernRenderer : IColorCodedPicking
    {
        // Color Coded Picking
        protected VertexArrayObject vertexArrayObject4Picking;

        protected UniformMat4 pickingMVP = new UniformMat4("MVP");

        protected ShaderProgram pickingShaderProgram;
        protected ShaderProgram PickingShaderProgram
        {
            get
            {
                if (pickingShaderProgram == null)
                { pickingShaderProgram = PickingShaderHelper.GetPickingShaderProgram(); }

                return pickingShaderProgram;
            }
        }

        public mat4 MVP
        {
            get { return pickingMVP.Value; }
            set { pickingMVP.Value = value; }
        }

        public uint PickingBaseID { get; private set; }

        public void SetPickingBaseID(uint value)
        {
            this.PickingBaseID = value;
        }

        public uint GetVertexCount()
        {
            PropertyBufferPtr positionBufferPtr = this.positionBufferPtr;
            if (positionBufferPtr == null) { return 0; }
            int byteLength = positionBufferPtr.ByteLength;
            int vertexLength = positionBufferPtr.DataSize * positionBufferPtr.DataTypeByteLength;
            uint vertexCount = (uint)(byteLength / vertexLength);
            return vertexCount;
        }

        public abstract PickedGeometry Pick(
            RenderEventArgs e,
            uint stageVertexId,
            int x, int y);


        //internal uint ReadPixel(int x, int y, int canvasHeight)
        //{
        //    // get coded color.
        //    //byte[] codedColor = new byte[4];
        //    UnmanagedArray<byte> codedColor = new UnmanagedArray<byte>(4);
        //    GL.ReadPixels(x, canvasHeight - y - 1, 1, 1, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, codedColor.Header);
        //    if (!
        //        // This is when (x, y) is on background and no primitive is picked.
        //        (codedColor[0] == byte.MaxValue && codedColor[1] == byte.MaxValue
        //        && codedColor[2] == byte.MaxValue && codedColor[3] == byte.MaxValue))
        //    {
        //        // see http://www.cnblogs.com/bitzhuwei/p/modern-opengl-picking-primitive-in-VBO-2.html
        //        uint shiftedR = (uint)codedColor[0];
        //        uint shiftedG = (uint)codedColor[1] << 8;
        //        uint shiftedB = (uint)codedColor[2] << 16;
        //        uint shiftedA = (uint)codedColor[3] << 24;
        //        uint stageVertexId = shiftedR + shiftedG + shiftedB + shiftedA;

        //        return stageVertexId;
        //    }
        //    else
        //    { return uint.MaxValue; }
        //}

        /// <summary>
        /// 在此Buffer中的图元进行N选1
        /// </summary>
        /// <param name="e"></param>
        /// <param name="indexBufferPtr"></param>
        internal void Render4SelfPicking(RenderEventArgs e, IndexBufferPtr indexBufferPtr)
        {
            // 暂存clear color
            var originalClearColor = new float[4];
            GL.GetFloat(GetTarget.ColorClearValue, originalClearColor);

            GL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);// 白色意味着没有拾取到任何对象
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            // 恢复clear color
            GL.ClearColor(originalClearColor[0], originalClearColor[1], originalClearColor[2], originalClearColor[3]);

            UpdatePolygonMode(e.PickingGeometryType);
            ShaderProgram program = this.PickingShaderProgram;
            // 绑定shader
            program.Bind();
            pickingMVP.SetUniform(program);
            program.SetUniform("pickingBaseID", 0u);// special uniform in Picking shader.

            PickingSwitchesOn();
            {
                //var arg = new RenderEventArgs(RenderModes.ColorCodedPicking, camera);
                this.positionBufferPtr.Render(e, program);
                indexBufferPtr.Render(e, program);
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            }
            PickingSwitchesOff();

            // 解绑shader
            pickingMVP.ResetUniform(program);
            program.Unbind();

            GL.Flush();

            //var filename = string.Format("Render4SelfPicking{0:yyyy-MM-dd_HH-mm-ss.ff}.png", DateTime.Now);
            //Save2PictureHelper.Save2Picture(0, 0,
            //    e.CanvasRect.Width, e.CanvasRect.Height, filename);
        }

        internal PrimitiveRestartSwitch GetPrimitiveRestartSwitch()
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

        protected vec3[] FillPickedGeometrysPosition(uint firstIndex, int indexCount)
        {
            int offset = (int)(firstIndex * this.positionBufferPtr.DataSize * this.positionBufferPtr.DataTypeByteLength);
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
            //IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadOnly);
            IntPtr pointer = GL.MapBufferRange(BufferTarget.ArrayBuffer,
                offset,
                indexCount * this.positionBufferPtr.DataSize * this.positionBufferPtr.DataTypeByteLength,
                MapBufferRangeAccess.MapReadBit);
            var positions = new vec3[indexCount];
            if (pointer.ToInt32() != 0)
            {
                unsafe
                {
                    var array = (vec3*)pointer.ToPointer();
                    for (uint i = 0; i < indexCount; i++)
                    {
                        positions[i] = array[i];
                    }
                }
            }
            else
            {
                ErrorCode error = (ErrorCode)GL.GetError();
                throw new Exception(string.Format(
                    "Error:[{0}] MapBufferRange failed: buffer ID: [{1}]", error, this.positionBufferPtr.BufferId));
            }
            GL.UnmapBuffer(BufferTarget.ArrayBuffer);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            return positions;
        }

        protected vec3[] FillPickedGeometrysPosition(uint[] indexes)
        {
            var positions = new vec3[indexes.Length];

            GL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferPtr.BufferId);
            for (int i = 0; i < indexes.Length; i++)
            {
                int offset = (int)(indexes[i] * this.positionBufferPtr.DataSize * this.positionBufferPtr.DataTypeByteLength);
                //IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadOnly);
                IntPtr pointer = GL.MapBufferRange(BufferTarget.ArrayBuffer,
                    offset,
                    1 * this.positionBufferPtr.DataSize * this.positionBufferPtr.DataTypeByteLength,
                    MapBufferRangeAccess.MapReadBit);
                if (pointer.ToInt32() != 0)
                {
                    unsafe
                    {
                        var array = (vec3*)pointer.ToPointer();
                        positions[i] = array[0];
                    }
                }
                else
                {
                    ErrorCode error = (ErrorCode)GL.GetError();
                    throw new Exception(string.Format(
                        "Error:[{0}] MapBufferRange failed: buffer ID: [{1}]", error, this.positionBufferPtr.BufferId));
                }
                GL.UnmapBuffer(BufferTarget.ArrayBuffer);
            }

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            return positions;
        }

    }
}
