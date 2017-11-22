using System;

namespace CSharpGL
{
    public partial class Framebuffer
    {
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
        ~Framebuffer()
        {
            this.Dispose(false);
        }

        private bool disposedValue = false;

        private void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                }

                // Dispose unmanaged resources.
                {
                    Renderbuffer depthBuffer = this.depthBuffer;
                    if (depthBuffer != null)
                    {
                        depthBuffer.Dispose();
                    }
                }
                {
                    Renderbuffer[] array = this.colorBuffers;
                    foreach (var item in array)
                    {
                        if (item != null)
                        {
                            item.Dispose();
                        }
                    }
                }
                {
                    IntPtr context = GL.Instance.GetCurrentContext();
                    if (context != IntPtr.Zero)
                    {
                        glDeleteFramebuffers(this.frameBufferId.Length, this.frameBufferId);
                    }
                }
            }

            this.disposedValue = true;
        }
    }
}