using System;

namespace CSharpGL {
    public unsafe partial class Framebuffer {
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
        ~Framebuffer() {
            this.Dispose(false);
        }

        private bool disposedValue = false;

        private void Dispose(bool disposing) {
            if (this.disposedValue == false) {
                if (disposing) {
                    // Dispose managed resources.
                }

                // Dispose unmanaged resources.
                {
                    var depthBuffer = this.depthBuffer;
                    if (depthBuffer != null) {
                        depthBuffer.Dispose();
                    }
                }
                {
                    foreach (var item in this.renderBuffers) {
                        if (item != null) {
                            item.Dispose();
                        }
                    }
                }
                {
                    var gl = GL.current;
                    if (gl != null) {
                        //IntPtr context = gl.glGetCurrentContext();
                        //if (context != IntPtr.Zero) {
                        var framebuffers = stackalloc GLuint[1];
                        framebuffers[0] = this.id;
                        gl.glDeleteFramebuffers(1, framebuffers);
                        //}
                    }
                }
            }

            this.disposedValue = true;
        }
    }
}