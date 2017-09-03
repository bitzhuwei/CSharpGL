using System;

namespace CSharpGL
{
    public abstract partial class GLBuffer
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
        ~GLBuffer()
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

        private static GLDelegates.void_int_uintN glDeleteBuffers;
        /// <summary>
        ///
        /// </summary>
        protected virtual void DisposeUnmanagedResources()
        {
            IntPtr context = GL.Instance.GetCurrentContext();
            if (context != IntPtr.Zero)
            {
                if (glDeleteBuffers == null) { glDeleteBuffers = GL.Instance.GetDelegateFor("glDeleteBuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN; }
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