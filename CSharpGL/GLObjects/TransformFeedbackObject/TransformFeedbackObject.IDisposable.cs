using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace CSharpGL {
    public unsafe partial class TransformFeedbackObject {
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
        ~TransformFeedbackObject() {
            this.Dispose(false);
        }

        private void Dispose(bool disposing) {
            if (this.disposedValue == false) {
                if (disposing) {
                    // Dispose managed resources.
                }

                // Dispose unmanaged resources.
                //IntPtr context = gl.glGetCurrentContext();
                //if (context != IntPtr.Zero) {
                var gl = GL.current; if (gl != null) {
                    var ids = stackalloc GLuint[1]; ids[0] = this.id;
                    gl.glDeleteTransformFeedbacks(1, ids);
                }
                //}

                //this.ids[0] = 0;
            }

            this.disposedValue = true;
        }
    }
}
