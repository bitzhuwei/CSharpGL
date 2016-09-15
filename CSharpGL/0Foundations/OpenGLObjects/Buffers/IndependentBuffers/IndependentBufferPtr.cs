using System;

namespace CSharpGL
{
    /// <summary>
    /// Buffer object that not work as input variable in shader.
    /// </summary>
    public abstract class IndependentBufferPtr : BufferPtr
    {
        /// <summary>
        /// pixel unpack buffer's pointer.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal IndependentBufferPtr(BufferTarget target,
            uint bufferId, int length, int byteLength)
            : base(target, bufferId, length, byteLength)
        {
        }

        /// <summary>
        /// Start to read/write buffer.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="access"></param>
        /// <param name="bind"></param>
        /// <returns></returns>
        public IntPtr MapBufferRange(int offset, int length, MapBufferRangeAccess access, bool bind = true)
        {
            if (bind)
            {
                glBindBuffer((uint)this.Target, this.BufferId);
            }
            return glMapBufferRange((uint)this.Target, offset, length, (uint)access);
        }

        /// <summary>
        /// Start to read/write buffer.
        /// </summary>
        /// <param name="access"></param>
        /// <param name="bind"></param>
        /// <returns></returns>
        public IntPtr MapBuffer(MapBufferAccess access, bool bind = true)
        {
            if (bind)
            {
                glBindBuffer((uint)this.Target, this.BufferId);
            }
            IntPtr pointer = glMapBuffer((uint)this.Target, (uint)access);
            return pointer;
        }

        /// <summary>
        /// Stop reading/writing buffer.
        /// </summary>
        /// <param name="unbind"></param>
        public void UnmapBuffer(bool unbind = true)
        {
            glUnmapBuffer((uint)this.Target);
            if (unbind)
            {
                glBindBuffer((uint)this.Target, 0);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Id: {0}, {1}, ByteLength: {2}", this.BufferId, this.Target, this.ByteLength);
        }
    }
}