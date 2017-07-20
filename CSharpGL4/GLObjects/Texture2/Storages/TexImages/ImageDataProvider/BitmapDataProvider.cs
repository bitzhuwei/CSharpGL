using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL.Texture2
{
    /// <summary>
    /// Provides specified bitmap's data as <see cref="Texture"/>'s image content.
    /// </summary>
    public class BitmapDataProvider : TexImageDataProvider, IDisposable
    {
        private Bitmap bitmap;
        private System.Drawing.Imaging.BitmapData data;

        /// <summary>
        /// Provides specified <paramref name="bitmap"/>'s data as <see cref="Texture"/>'s image content.
        /// </summary>
        /// <param name="bitmap"></param>
        public BitmapDataProvider(Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }

        public override IntPtr LockData()
        {
            this.data = this.bitmap.LockBits(new Rectangle(0, 0, this.bitmap.Width, this.bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, this.bitmap.PixelFormat);
            return data.Scan0;
        }

        public override void FreeData()
        {
            this.bitmap.UnlockBits(this.data);
        }

        #region IDisposable 成员

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        } // end sub

        /// <summary>
        /// Destruct instance of the class.
        /// </summary>
        ~BitmapDataProvider()
        {
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
        private void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.

                } // end if

                // Dispose unmanaged resources.
                var bitmap = this.bitmap;
                if (bitmap != null)
                {
                    this.bitmap = null;
                    bitmap.Dispose();
                }

            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion
    }
}
