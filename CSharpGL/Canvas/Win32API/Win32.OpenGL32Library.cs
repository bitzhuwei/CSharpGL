using System;

namespace CSharpGL
{
    internal static partial class Win32
    {
        private class OpenGL32Library : IDisposable
        {
            public static readonly OpenGL32Library Instance = new OpenGL32Library();

            private OpenGL32Library()
            {
                libPtr = Win32.LoadLibrary(opengl32);
            }

            /// <summary>
            /// glLibrary = Win32.LoadLibrary(OpenGL32);
            /// </summary>
            internal readonly IntPtr libPtr;

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
                    FreeLibrary(libPtr);
                }

                this.disposedValue = true;
            }

            #endregion IDisposable
        }
    }
}