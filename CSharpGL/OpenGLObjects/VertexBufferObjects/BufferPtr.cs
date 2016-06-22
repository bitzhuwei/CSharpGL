using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 将VBO上传到GPU后，就得到VBO的指针。CPU内存中的VBO数据就可以释放掉了。
    /// </summary>
    public abstract class BufferPtr : IDisposable
    {
        private bool disposedValue = false;

        /// <summary>
        /// 用GL.GenBuffers()得到的VBO的ID。
        /// </summary>
        public uint BufferId { get; private set; }

        /// <summary>
        /// 此VBO含有多个个元素？
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// 此VBO含有多个个字节？
        /// </summary>
        public int ByteLength { get; private set; }

        protected static OpenGL.glBindBuffer glBindBuffer;
        protected static OpenGL.glDeleteBuffers glDeleteBuffers;

        /// <summary>
        /// 为给定VBO执行渲染时所需的操作。
        /// </summary>
        /// <param name="bufferID">用GL.GenBuffers()得到的VBO的ID。</param>
        /// <param name="length">此VBO含有多个个元素？</param>
        internal BufferPtr(uint bufferID, int length, int byteLength)
        {
            if (glBindBuffer == null)
            {
                glBindBuffer = OpenGL.GetDelegateFor<OpenGL.glBindBuffer>();
                glDeleteBuffers = OpenGL.GetDelegateFor<OpenGL.glDeleteBuffers>();
            }

            this.BufferId = bufferID;
            this.Length = length;
            this.ByteLength = byteLength;
        }

        /// <summary>
        /// 执行此VBO的渲染操作。
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="shaderProgram">此VBO使用的shader program。</param>
        public abstract void Render(RenderEventArgs arg, ShaderProgram shaderProgram);

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

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

        protected virtual void DisposeUnmanagedResources()
        {
            IntPtr context = Win32.wglGetCurrentContext();
            if (context != IntPtr.Zero)
            {
                glDeleteBuffers(1, new uint[] { this.BufferId });
            }

            this.BufferId = 0;
        }

        protected virtual void DisposeManagedResources()
        {
        }


    }
}
