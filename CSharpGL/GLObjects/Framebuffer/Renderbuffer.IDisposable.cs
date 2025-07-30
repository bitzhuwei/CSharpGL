using System;

namespace CSharpGL {
    /// <summary>
    ///
    /// </summary>
    public unsafe partial class Renderbuffer : IDisposable {
        /// <summary>
        ///
        /// </summary>
        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///
        /// </summary>
        ~Renderbuffer() {
            this.Dispose(false);
        }

        private bool disposedValue = false;

        private void Dispose(bool disposing) {
            if (this.disposedValue == false) {
                if (disposing) {
                    // Dispose managed resources.
                }

                // Dispose unmanaged resources.
                var gl = GL.current;
                if (gl != null) {
                    //IntPtr context = gl.glGetCurrentContext();
                    //if (context != IntPtr.Zero) {
                    var ids = stackalloc GLuint[1]; ids[0] = this.id;
                    gl.glDeleteRenderbuffers(1, ids);
                    //}
                }
            }

            this.disposedValue = true;
        }
    }
}