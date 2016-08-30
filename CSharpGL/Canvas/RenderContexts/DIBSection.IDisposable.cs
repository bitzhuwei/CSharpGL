using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    partial class DIBSection
    {

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
        ~DIBSection()
        {
            this.Dispose(false);
        }

        private bool disposedValue = false;

        private void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                }

                // Dispose unmanaged resources.
                this.DestroyBitmap();

                if (this.MemoryDeviceContext != IntPtr.Zero)
                {
                    Win32.DeleteDC(this.MemoryDeviceContext);
                    this.MemoryDeviceContext = IntPtr.Zero;
                }
            }

            this.disposedValue = true;
        }
    }
}