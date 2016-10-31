using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// 将VBO上传到GPU后，就得到VBO的指针。CPU内存中的VBO数据就可以释放掉了。
    /// VBO's pointer got from Buffer's GetBufferPtr() method.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public abstract partial class BufferPtr : IDisposable
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
        internal static OpenGL.glBindBuffer glBindBuffer;

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

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glCopyBufferSubData glCopyBufferSubData;

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glGetBufferSubData glGetBufferSubData;

        /// <summary>
        /// 将VBO上传到GPU后，就得到VBO的指针。CPU内存中的VBO数据就可以释放掉了。
        /// VBO's pointer got from Buffer's GetBufferPtr() method. It's totally OK to free memory of unmanaged array stored in this buffer object now.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal BufferPtr(uint bufferId, int length, int byteLength)
        {
            Debug.Assert(bufferId >= 0);
            Debug.Assert(length >= 0);
            Debug.Assert(byteLength >= 0);

            if (glBindBuffer == null)
            {
                glBindBuffer = OpenGL.GetDelegateFor<OpenGL.glBindBuffer>();
                glDeleteBuffers = OpenGL.GetDelegateFor<OpenGL.glDeleteBuffers>();
                glMapBuffer = OpenGL.GetDelegateFor<OpenGL.glMapBuffer>();
                glMapBufferRange = OpenGL.GetDelegateFor<OpenGL.glMapBufferRange>();
                glUnmapBuffer = OpenGL.GetDelegateFor<OpenGL.glUnmapBuffer>();
                glClearBufferData = OpenGL.GetDelegateFor<OpenGL.glClearBufferData>();
                glClearBufferSubData = OpenGL.GetDelegateFor<OpenGL.glClearBufferSubData>();
                glCopyBufferSubData = OpenGL.GetDelegateFor<OpenGL.glCopyBufferSubData>();
                glGetBufferSubData = OpenGL.GetDelegateFor<OpenGL.glGetBufferSubData>();
            }

            this.BufferId = bufferId;
            this.Length = length;
            this.ByteLength = byteLength;
        }

        /// <summary>
        ///Bind this buffer.
        /// </summary>
        public virtual void Bind()
        {
            glBindBuffer((uint)this.Target, this.BufferId);
        }

        /// <summary>
        /// Unind this buffer.
        /// </summary>
        public virtual void Unbind()
        {
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
        public virtual IntPtr MapBuffer(MapBufferAccess access, bool bind = true)
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
        public virtual bool UnmapBuffer(bool unbind = true)
        {
            bool result = glUnmapBuffer((uint)this.Target);
            if (unbind)
            {
                glBindBuffer((uint)this.Target, 0);
            }

            return result;
        }
    }
}