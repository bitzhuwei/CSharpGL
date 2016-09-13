using System;

namespace CSharpGL
{
    /// <summary>
    /// 将VBO上传到GPU后，就得到VBO的指针。CPU内存中的VBO数据就可以释放掉了。
    /// VBO's pointer got from Buffer's GetBufferPtr() method.
    /// </summary>
    public abstract class BufferPtr : IDisposable
    {
        private bool disposedValue = false;

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
        /// 将VBO上传到GPU后，就得到VBO的指针。CPU内存中的VBO数据就可以释放掉了。
        /// VBO's pointer got from Buffer's GetBufferPtr() method. It's totally OK to free memory of unmanaged array stored in this buffer object now.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal BufferPtr(uint bufferId, int length, int byteLength)
        {
            if (glBindBuffer == null)
            {
                glBindBuffer = OpenGL.GetDelegateFor<OpenGL.glBindBuffer>();
                glDeleteBuffers = OpenGL.GetDelegateFor<OpenGL.glDeleteBuffers>();
                glMapBuffer = OpenGL.GetDelegateFor<OpenGL.glMapBuffer>();
                glMapBufferRange = OpenGL.GetDelegateFor<OpenGL.glMapBufferRange>();
                glUnmapBuffer = OpenGL.GetDelegateFor<OpenGL.glUnmapBuffer>();
            }

            this.BufferId = bufferId;
            this.Length = length;
            this.ByteLength = byteLength;
        }

        /// <summary>
        ///Bind this buffer.
        /// </summary>
        public abstract void Bind();

        /// <summary>
        /// Unind this buffer.
        /// </summary>
        public abstract void Unbind();

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///
        /// </summary>
        ~BufferPtr()
        {
            this.Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    DisposeManagedResources();
                }

                // Dispose unmanaged resources.
                DisposeUnmanagedResources();
            }

            this.disposedValue = true;
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void DisposeUnmanagedResources()
        {
            IntPtr context = Win32.wglGetCurrentContext();
            if (context != IntPtr.Zero)
            {
                glDeleteBuffers(1, new uint[] { this.BufferId });
            }

            this.BufferId = 0;
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void DisposeManagedResources()
        {
        }
    }
}