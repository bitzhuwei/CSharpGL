using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T">此buffer存储的是哪种struct的数据？<para>type of index value.</para></typeparam>
    public class PixelUnpackBuffer<T> : Buffer where T : struct
    {

        /// <summary>
        /// </summary>
        /// <param name="dataSize">second parameter in glVertexAttribPointer(attributeLocation, size, type, false, 0, IntPtr.Zero);
        /// </param>
        /// <param name="dataType">third parameter in glVertexAttribPointer(attributeLocation, size, type, false, 0, IntPtr.Zero);
        /// </param>
        /// <param name="usage"></param>
        public PixelUnpackBuffer(int dataSize, uint dataType, BufferUsage usage)
            : base(usage)
        {
            this.DataSize = dataSize;
            this.DataType = dataType;
        }

        /// <summary>
        /// second parameter in glVertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);
        /// </summary>
        public int DataSize { get; private set; }

        /// <summary>
        /// GL_FLOAT etc
        /// <para>third parameter in glVertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);</para>
        /// </summary>
        public uint DataType { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override BufferPtr Upload2GPU()
        {
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            glBindBuffer(OpenGL.GL_PIXEL_UNPACK_BUFFER, buffers[0]);
            glBufferData(OpenGL.GL_PIXEL_UNPACK_BUFFER, this.ByteLength, this.Header, (uint)this.Usage);
            glBindBuffer(OpenGL.GL_PIXEL_UNPACK_BUFFER, 0);

            var bufferPtr = new PixelUnpackBufferPtr(
                buffers[0], this.DataSize, this.DataType, this.Length, this.ByteLength);

            return bufferPtr;
        }

        /// <summary>
        /// 申请指定长度的非托管数组。
        /// <para>create an unmanaged array to store data for this buffer.</para>
        /// </summary>
        /// <param name="elementCount">数组元素的数目。<para>How many elements?</para></param>
        public override void Create(int elementCount)
        {
            this.array = new UnmanagedArray<T>(elementCount);
        }
    }
}
