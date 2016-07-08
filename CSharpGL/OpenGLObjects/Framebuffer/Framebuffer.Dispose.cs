using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    //TODO: IDisposable
    public partial class Framebuffer : IDisposable
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
                glDeleteFramebuffers(1, this.framebufferId);
            }

            this.disposedValue = true;
        }
    }
}
