using System;

namespace CSharpGL
{
    //TODO: IDisposable
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
                OpenGL.DeleteRenderbuffers(1, this.renderbuffer);
            }

            this.disposedValue = true;
        }
    }
}