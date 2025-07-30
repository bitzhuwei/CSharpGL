using System;

namespace CSharpGL {
    unsafe partial class GLBuffer {
        private bool disposedValue = false;

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
        ~GLBuffer() {
            this.Dispose(false);
        }

        private void Dispose(bool disposing) {
            if (this.disposedValue == false) {
                if (disposing) {
                    // Dispose managed resources.
                    DisposeManagedResources();
                }

                // Dispose unmanaged resources.
                DisposeUnmanagedResources();
            }

            this.disposedValue = true;
        }

        //private static GLDelegates.void_int_uintN glDeleteBuffers;
        /// <summary>
        ///
        /// </summary>
        protected virtual void DisposeUnmanagedResources() {
            //IntPtr context = gl.glGetCurrentContext();
            var gl = GL.current;
            if (gl != null) {
                //if (glDeleteBuffers == null) { glDeleteBuffers = gl.glGetDelegateFor("glDeleteBuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN; }
                var name = this.bufferId;
                gl.glDeleteBuffers(1, &name);
            }

            //this.bufferId = 0;
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void DisposeManagedResources() {
        }
    }
}