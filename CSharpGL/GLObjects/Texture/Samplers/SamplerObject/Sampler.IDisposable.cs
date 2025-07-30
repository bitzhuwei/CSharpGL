using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public unsafe partial class Sampler {
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        } // end sub

        /// <summary>
        /// Destruct instance of the unsafe class.
        /// </summary>
        ~Sampler() {
            this.Dispose(false);
        }

        /// <summary>
        /// Backing field to track whether Dispose has been called.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Dispose managed and unmanaged resources of this instance.
        /// </summary>
        /// <param name="disposing">If disposing equals true, managed and unmanaged resources can be disposed. If disposing equals false, only unmanaged resources can be disposed. </param>
        private void Dispose(bool disposing) {
            if (this.disposedValue == false) {
                if (disposing) {
                    // Dispose managed resources.
                } // end if

                // Dispose unmanaged resources.
                {
                    //IntPtr context = gl.glGetCurrentContext();
                    //if (context != IntPtr.Zero) {
                    var gl = GL.current; if (gl != null) {
                        var ids = stackalloc GLuint[1]; ids[0] = this.id;
                        gl.glDeleteSamplers(1, ids);
                    }
                    //}
                }
            } // end if

            this.disposedValue = true;
        } // end sub
    }
}
