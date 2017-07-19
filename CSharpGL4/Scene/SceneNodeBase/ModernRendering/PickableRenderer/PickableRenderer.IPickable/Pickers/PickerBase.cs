using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Get picked geometry.
    /// </summary>
    abstract class PickerBase
    {
        /// <summary>
        /// Get picked geometry.
        /// </summary>
        /// <param name="renderer"></param>
        public PickerBase(PickableRenderer renderer)
        {
            this.Renderer = renderer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public abstract PickedGeometry GetPickedGeometry(PickingEventArgs arg, uint stageVertexId);

        /// <summary>
        /// 
        /// </summary>
        public PickableRenderer Renderer { get; set; }


        protected vec3[] FillPickedGeometrysPosition(uint firstIndex, int indexCount)
        {
            VertexBuffer buffer = this.Renderer.PickingRenderUnit.PositionBuffer;
            int offset = (int)(firstIndex * buffer.Config.GetDataSize() * buffer.Config.GetDataTypeByteLength());
            //IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadOnly);
            IntPtr pointer = buffer.MapBufferRange(
                offset,
                indexCount * buffer.Config.GetDataSize() * buffer.Config.GetDataTypeByteLength(),
                MapBufferRangeAccess.MapReadBit);
            var positions = new vec3[indexCount];
            if (pointer.ToInt64() != 0)
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
                ErrorCode error = (ErrorCode)GL.Instance.GetError();
                if (error != ErrorCode.NoError)
                {
                    throw new Exception(string.Format(
                        "Error:[{0}] glMapBufferRange failed: buffer ID: [{1}]", error, buffer.BufferId.ToString()));
                }
            }
            buffer.UnmapBuffer();

            return positions;
        }

        protected vec3[] FillPickedGeometrysPosition(uint[] indexes)
        {
            var positions = new vec3[indexes.Length];

            VertexBuffer buffer = this.Renderer.PickingRenderUnit.PositionBuffer;
            buffer.Bind();
            for (int i = 0; i < indexes.Length; i++)
            {
                int offset = (int)(indexes[i] * buffer.Config.GetDataSize() * buffer.Config.GetDataTypeByteLength());
                //IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadOnly);
                IntPtr pointer = buffer.MapBufferRange(
                    offset,
                    1 * buffer.Config.GetDataSize() * buffer.Config.GetDataTypeByteLength(),
                    MapBufferRangeAccess.MapReadBit, false);
                if (pointer.ToInt64() != 0)
                {
                    unsafe
                    {
                        var array = (vec3*)pointer.ToPointer();
                        positions[i] = array[0];
                    }
                }
                else
                {
                    ErrorCode error = (ErrorCode)GL.Instance.GetError();
                    if (error != ErrorCode.NoError)
                    {
                        Debug.WriteLine(string.Format(
                            "Error:[{0}] glMapBufferRange failed: buffer ID: [{1}]", error, buffer.BufferId.ToString()));
                    }
                }
                buffer.UnmapBuffer(false);
            }
            buffer.Unbind();

            return positions;
        }

    }
}
