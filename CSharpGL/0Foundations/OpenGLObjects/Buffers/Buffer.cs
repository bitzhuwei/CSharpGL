using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// 位于服务器端（GPU内存）中的定长数组。
    /// <para>An array at server side (GPU memory) with fixed length.</para>
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public abstract partial class Buffer : IDisposable
    {
        /// <summary>
        /// 用glGenBuffers()得到的VBO的Id。
        /// <para>Id got from glGenBuffers();</para>
        /// </summary>
        public uint BufferId { get; private set; }

        /// <summary>
        /// 此VBO含有多个个元素？
        /// <para>How many elements?</para>
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// 此VBO中的数据在内存中占用多少个字节？
        /// <para>How many bytes in this buffer?</para>
        /// </summary>
        public int ByteLength { get; private set; }

        /// <summary>
        /// Target that this buffer should bind to.
        /// </summary>
        public abstract BufferTarget Target { get; }

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glGenBuffers glGenBuffers;

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glBindBuffer glBindBuffer;

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glBufferData glBufferData;

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glDeleteBuffers glDeleteBuffers;

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glMapBuffer glMapBuffer;

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glUnmapBuffer glUnmapBuffer;

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glMapBufferRange glMapBufferRange;

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glClearBufferData glClearBufferData;

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glClearBufferSubData glClearBufferSubData;

        ///// <summary>
        /////
        ///// </summary>
        //internal static OpenGL.glCopyBufferSubData glCopyBufferSubData;

        ///// <summary>
        /////
        ///// </summary>
        //internal static OpenGL.glGetBufferSubData glGetBufferSubData;

        /// <summary>
        /// 将VBO上传到GPU后，就得到VBO的指针。CPU内存中的VBO数据就可以释放掉了。
        /// VBO's pointer got from Buffer's GetBuffer() method. It's totally OK to free memory of unmanaged array stored in this buffer object now.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        protected Buffer(uint bufferId, int length, int byteLength)
        {
            Debug.Assert(bufferId >= 0);
            Debug.Assert(length >= 0);
            Debug.Assert(byteLength >= 0);

            this.BufferId = bufferId;
            this.Length = length;
            this.ByteLength = byteLength;
        }

        /// <summary>
        ///Bind this buffer.
        /// </summary>
        public virtual void Bind()
        {
            if (glBindBuffer == null) { glBindBuffer = OpenGL.GetDelegateFor<OpenGL.glBindBuffer>(); }
            glBindBuffer((uint)this.Target, this.BufferId);
        }

        /// <summary>
        /// Unind this buffer.
        /// </summary>
        public virtual void Unbind()
        {
            if (glBindBuffer == null) { glBindBuffer = OpenGL.GetDelegateFor<OpenGL.glBindBuffer>(); }
            glBindBuffer((uint)this.Target, 0);
        }

        /// <summary>
        /// Start to read/write buffer.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="access"></param>
        /// <param name="bind"></param>
        /// <returns></returns>
        public virtual IntPtr MapBufferRange(int offset, int length, MapBufferRangeAccess access, bool bind = true)
        {
            if (bind)
            {
                if (glBindBuffer == null) { glBindBuffer = OpenGL.GetDelegateFor<OpenGL.glBindBuffer>(); }
                glBindBuffer((uint)this.Target, this.BufferId);
            }

            if (glMapBufferRange == null) { glMapBufferRange = OpenGL.GetDelegateFor<OpenGL.glMapBufferRange>(); }
            IntPtr pointer = glMapBufferRange((uint)this.Target, offset, length, (uint)access);
            return pointer;
        }

        /// <summary>
        /// Start to read/write buffer.
        /// </summary>
        /// <param name="access"></param>
        /// <param name="bind"></param>
        /// <returns></returns>
        public virtual IntPtr MapBuffer(MapBufferAccess access, bool bind = true)
        {
            if (bind)
            {
                if (glBindBuffer == null) { glBindBuffer = OpenGL.GetDelegateFor<OpenGL.glBindBuffer>(); }
                glBindBuffer((uint)this.Target, this.BufferId);
            }

            if (glMapBuffer == null) { glMapBuffer = OpenGL.GetDelegateFor<OpenGL.glMapBuffer>(); }
            IntPtr pointer = glMapBuffer((uint)this.Target, (uint)access);
            return pointer;
        }

        /// <summary>
        /// Stop reading/writing buffer.
        /// </summary>
        /// <param name="unbind"></param>
        public virtual bool UnmapBuffer(bool unbind = true)
        {
            if (glUnmapBuffer == null) { glUnmapBuffer = OpenGL.GetDelegateFor<OpenGL.glUnmapBuffer>(); }
            bool result = glUnmapBuffer((uint)this.Target);
            if (unbind)
            {
                if (glBindBuffer == null) { glBindBuffer = OpenGL.GetDelegateFor<OpenGL.glBindBuffer>(); }
                glBindBuffer((uint)this.Target, 0);
            }

            return result;
        }
    }
}