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
    public class CubemapDataProvider : TexImageDataProvider<CubemapData>, IDisposable
    {
        private readonly Bitmap positiveX;
        private readonly Bitmap negtiveX;
        private readonly Bitmap positiveY;
        private readonly Bitmap negtiveY;
        private readonly Bitmap positiveZ;
        private readonly Bitmap negtiveZ;

        private readonly bool autoDispose;
        private readonly int levelCount;

        /// <summary>
        /// Provides specified bitmaps' data as <see cref="Texture"/>'s image content.
        /// </summary>
        /// <param name="positiveX"></param>
        /// <param name="negtiveX"></param>
        /// <param name="positiveY"></param>
        /// <param name="negtiveY"></param>
        /// <param name="positiveZ"></param>
        /// <param name="negtiveZ"></param>
        /// <param name="autoDisose">dispose bitmaps when disposing this <see cref="ImageDataProvider"/> object.</param>
        /// <param name="levelCount">[1, 2, 3, 4, 5, 6, 7, 8]</param>
        public CubemapDataProvider(
            Bitmap positiveX, Bitmap negtiveX,
            Bitmap positiveY, Bitmap negtiveY,
            Bitmap positiveZ, Bitmap negtiveZ,
            bool autoDisose = false, int levelCount = 1)
        {
            this.positiveX = positiveX;
            this.positiveY = positiveY;
            this.positiveZ = positiveZ;
            this.negtiveX = negtiveX;
            this.negtiveY = negtiveY;
            this.negtiveZ = negtiveZ;

            this.autoDispose = autoDisose;
            this.levelCount = levelCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerator<CubemapData> GetEnumerator()
        {
            yield return new CubemapData(this.positiveX, CubemapFace.PositiveX, false);
            yield return new CubemapData(this.negtiveX, CubemapFace.NegtiveX, false);
            yield return new CubemapData(this.positiveY, CubemapFace.PositiveY, false);
            yield return new CubemapData(this.negtiveY, CubemapFace.NegtiveY, false);
            yield return new CubemapData(this.positiveZ, CubemapFace.PositiveZ, false);
            yield return new CubemapData(this.negtiveZ, CubemapFace.NegtiveZ, false);
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
        ~CubemapDataProvider()
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
                    var array = new Bitmap[] { this.positiveX, this.negtiveX, this.positiveY, this.negtiveY, this.positiveZ, this.negtiveZ, };
                    foreach (var item in array)
                    {
                        if (item != null)
                        {
                            item.Dispose();
                        }
                    }
                }
            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion
    }
}
