using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class GLRenderContext
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
        ~GLRenderContext()
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

        /// <summary>
        ///
        /// </summary>
        protected abstract void DisposeUnmanagedResources();

        /// <summary>
        ///
        /// </summary>
        protected abstract void DisposeManagedResources();

    }
}
