using System;
using System.ComponentModel;
using System.Diagnostics;

namespace CSharpGL
{
    partial class InnerPickableRenderer : IColorCodedPicking
    {
        /// <summary>
        /// uniform mat4 VMP; (in shader)
        /// </summary>
        protected UniformMat4 uniformmMVP4Picking = new UniformMat4("MVP");

        /// <summary>
        ///
        /// </summary>
        [Browsable(false)]
        public uint PickingBaseId { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public uint GetVertexCount()
        {
            VertexAttributeBufferPtr positionBufferPtr = this.PositionBufferPtr;
            if (positionBufferPtr == null) { return 0; }
            int byteLength = positionBufferPtr.ByteLength;
            int vertexLength = positionBufferPtr.DataSize * positionBufferPtr.DataTypeByteLength;
            uint vertexCount = (uint)(byteLength / vertexLength);
            return vertexCount;
        }

        public abstract PickedGeometry GetPickedGeometry(
            RenderEventArgs arg,
            uint stageVertexId,
            int x, int y);

        /// <summary>
        /// 在此Buffer中的图元进行N选1
        /// select a line from triangle/quad/polygon in this renderer.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="indexBufferPtr">indicates the primitive to pick a line from.</param>
        internal void Render4InnerPicking(RenderEventArgs arg, IndexBufferPtr indexBufferPtr)
        {
            // record clear color
            var originalClearColor = new float[4];
            OpenGL.GetFloat(GetTarget.ColorClearValue, originalClearColor);

            // 白色意味着没有拾取到任何对象
            // white color: nothing picked.
            OpenGL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            // restore clear color
            OpenGL.ClearColor(originalClearColor[0], originalClearColor[1], originalClearColor[2], originalClearColor[3]);

            this.ColorCodedRender(arg, indexBufferPtr);

            OpenGL.Flush();

            //var filename = string.Format("Render4InnerPicking{0:yyyy-MM-dd_HH-mm-ss.ff}.png", DateTime.Now);
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
            int offset = (int)(firstIndex * this.PositionBufferPtr.DataSize * this.PositionBufferPtr.DataTypeByteLength);
            //IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadOnly);
            IntPtr pointer = this.PositionBufferPtr.MapBufferRange(
                offset,
                indexCount * this.PositionBufferPtr.DataSize * this.PositionBufferPtr.DataTypeByteLength,
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
                ErrorCode error = (ErrorCode)OpenGL.GetError();
                if (error != ErrorCode.NoError)
                {
                    throw new Exception(string.Format(
                        "Error:[{0}] glMapBufferRange failed: buffer ID: [{1}]", error, this.PositionBufferPtr.BufferId));
                }
            }
            this.PositionBufferPtr.UnmapBuffer();

            return positions;
        }

        protected vec3[] FillPickedGeometrysPosition(uint[] indexes)
        {
            var positions = new vec3[indexes.Length];

            this.PositionBufferPtr.Bind();
            for (int i = 0; i < indexes.Length; i++)
            {
                int offset = (int)(indexes[i] * this.PositionBufferPtr.DataSize * this.PositionBufferPtr.DataTypeByteLength);
                //IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadOnly);
                IntPtr pointer = this.PositionBufferPtr.MapBufferRange(
                    offset,
                    1 * this.PositionBufferPtr.DataSize * this.PositionBufferPtr.DataTypeByteLength,
                    MapBufferRangeAccess.MapReadBit, false);
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
                    ErrorCode error = (ErrorCode)OpenGL.GetError();
                    if (error != ErrorCode.NoError)
                    {
                        Debug.WriteLine(string.Format(
                            "Error:[{0}] glMapBufferRange failed: buffer ID: [{1}]", error, this.PositionBufferPtr.BufferId));
                    }
                }
                this.PositionBufferPtr.UnmapBuffer(false);
            }
            this.PositionBufferPtr.Unbind();

            return positions;
        }
    }
}