using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 将VBO上传到GPU后，就得到VBO的指针。CPU内存中的VBO数据就可以释放掉了。
    /// VBO's pointer got from Buffer's Upload2GPU() method.
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
        protected static OpenGL.glBindBuffer glBindBuffer;
        /// <summary>
        /// 
        /// </summary>
        protected static OpenGL.glDeleteBuffers glDeleteBuffers;

        /// <summary>
        /// 将VBO上传到GPU后，就得到VBO的指针。CPU内存中的VBO数据就可以释放掉了。
        /// VBO's pointer got from Buffer's Upload2GPU() method. It's totally OK to free memory of unmanaged array stored in this buffer object now.
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
            }

            this.BufferId = bufferId;
            this.Length = length;
            this.ByteLength = byteLength;
        }

        /// <summary>
        /// 执行此VBO的渲染操作。
        /// <para>Render using this VBO.</para>
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="shaderProgram">binding shader program for this VBO.</param>
        public abstract void Render(RenderEventArg arg, ShaderProgram shaderProgram);

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
