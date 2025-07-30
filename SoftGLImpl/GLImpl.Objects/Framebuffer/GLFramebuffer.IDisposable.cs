using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    partial class GLFramebuffer {
        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~GLFramebuffer() {
            this.Dispose(false);
        }

        private bool disposedValue = false;

        private void Dispose(bool disposing) // TODO: dispose attachments?
        {
            if (this.disposedValue == false) {
                if (disposing) {
                    // Dispose managed resources.
                }

                // Dispose unmanaged resources.

            }

            this.disposedValue = true;
        }
    }
}
