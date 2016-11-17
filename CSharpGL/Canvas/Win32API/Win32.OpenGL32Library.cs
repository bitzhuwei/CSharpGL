using System;

namespace CSharpGL
{
    internal class OpenGL32Library : IDisposable
    {
        public static readonly OpenGL32Library Instance = new OpenGL32Library();

        private OpenGL32Library()
        {
            libPtr = Win32.LoadLibrary(Win32.opengl32);
        }

        /// <summary>
        /// glLibrary = Win32.LoadLibrary(OpenGL32);
        /// </summary>
        internal readonly IntPtr libPtr;

        public override string ToString()
        {
            return string.Format("OpenGL32 Library Address: {0}", libPtr);
        }

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
        ~OpenGL32Library()
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
                Win32.FreeLibrary(libPtr);
            }

            this.disposedValue = true;
        }

        #endregion IDisposable
    }
}