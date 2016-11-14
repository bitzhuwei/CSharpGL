using System;

namespace CSharpGL
{
    public abstract partial class Buffer
    {
        private bool disposedValue = false;

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
        ~Buffer()
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
                if (glDeleteBuffers == null) { glDeleteBuffers = OpenGL.GetDelegateFor<OpenGL.glDeleteBuffers>(); }
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