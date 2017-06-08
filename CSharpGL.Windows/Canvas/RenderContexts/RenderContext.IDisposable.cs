using System;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public abstract partial class RenderContext
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
        ~RenderContext()
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
                DisposeUnmanagedResources();
            }

            this.disposedValue = true;
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void DisposeUnmanagedResources()
        {
            // If we have a render context, destroy it.
            if (this.RenderContextHandle != IntPtr.Zero)
            {
                Win32.wglDeleteContext(this.RenderContextHandle);
                this.RenderContextHandle = IntPtr.Zero;
            }
        }
    }
}