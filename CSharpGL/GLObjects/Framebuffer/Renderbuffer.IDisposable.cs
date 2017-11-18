using System;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public partial class Renderbuffer : IDisposable
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
        ~Renderbuffer()
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
                IntPtr context = GL.Instance.GetCurrentContext();
                if (context != IntPtr.Zero)
                {
                    glDeleteRenderbuffers(this.renderbuffer.Length, this.renderbuffer);
                    this.renderbuffer[0] = 0;
                }
            }

            this.disposedValue = true;
        }
    }
}