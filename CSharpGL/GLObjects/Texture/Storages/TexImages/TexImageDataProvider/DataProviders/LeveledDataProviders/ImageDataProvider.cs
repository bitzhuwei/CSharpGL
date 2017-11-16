using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Provides specified bitmap's data as <see cref="Texture"/>'s image content.
    /// </summary>
    public class ImageDataProvider : LeveledDataProvider
    {
        private readonly Bitmap bitmap;
        private readonly bool autoDispose;
        private readonly int levelCount;

        /// <summary>
        /// Provides specified <paramref name="bitmap"/>'s data as <see cref="Texture"/>'s image content.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="autoDisose">dispose <paramref name="bitmap"/> when disposing this <see cref="ImageDataProvider"/> object.</param>
        /// <param name="levelCount">[1, 2, 3, 4, 5, 6, 7, 8]</param>
        public ImageDataProvider(Bitmap bitmap, bool autoDisose = false, int levelCount = 1)
        {
            if (bitmap == null) { throw new ArgumentNullException("bitmap"); }

            this.bitmap = bitmap;
            this.autoDispose = autoDisose;
            this.levelCount = levelCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerator<LeveledData> GetEnumerator()
        {
            yield return new ImageData(this.bitmap, 0, false);

            Bitmap bmp = this.bitmap;
            for (int level = 1; level < levelCount; level++)
            {
                bmp = new Bitmap(bmp, bmp.Size);
                yield return new ImageData(bmp, level, true);
            }
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
        ~ImageDataProvider()
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
                if (this.autoDispose)
                {
                    var bitmap = this.bitmap;
                    if (bitmap != null)
                    {
                        bitmap.Dispose();
                    }
                }
            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion
    }
}
