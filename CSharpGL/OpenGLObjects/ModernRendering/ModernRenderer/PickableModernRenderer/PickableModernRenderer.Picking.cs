
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
            int x, int y, int canvasWidth, int canvasHeight);


        internal uint ReadPixel(int x, int y, int canvasHeight)
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

        internal void Render4Picking(RenderEventArgs e, IndexBufferPtr indexBufferPtr)
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

            foreach (var item in switchList) { item.On(); }
            this.primitiveRestartSwitch4Picking.On();
            this.polygonModeSwitch4Picking.On();
            {
                //var arg = new RenderEventArgs(RenderModes.ColorCodedPicking, camera);
                this.positionBufferPtr.Render(e, program);
                indexBufferPtr.Render(e, program);
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            }
            this.polygonModeSwitch4Picking.Off();
            this.primitiveRestartSwitch4Picking.Off();
            foreach (var item in switchList) { item.Off(); }

            // 解绑shader
            pickingMVP.ResetUniform(program);
            program.Unbind();

            GL.Flush();
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

        PrimitiveRestartSwitch primitiveRestartSwitch4Picking = new PrimitiveRestartSwitch(uint.MaxValue);

    }
}
