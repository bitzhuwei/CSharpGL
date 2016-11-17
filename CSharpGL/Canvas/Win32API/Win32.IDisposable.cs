using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    internal sealed partial class Win32
    {
        #region IDisposable

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
        ~Win32()
        {
            this.Dispose(false);
        }

        private bool disposedValue;

        private void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                }

                // Dispose unmanaged resources.
                FreeLibrary(opengl32Library);
            }

            this.disposedValue = true;
        }

        #endregion IDisposable

    }
}