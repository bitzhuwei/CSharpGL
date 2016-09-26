using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace CSharpGL
{
    /// <summary>
    /// build texture's content with Bitmap.
    /// </summary>
    public class CubemapImageFiller : ImageFiller
    {
        private CubemapImages images;
        private int level;
        private uint internalformat;
        private int border;
        private uint format;
        private uint type;

        /// <summary>
        /// build texture's content with Bitmap.
        /// </summary>
        /// <param name="images"></param>
        /// <param name="level">0</param>
        /// <param name="internalformat">OpenGL.GL_RGBA etc.</param>
        /// <param name="border">0</param>
        /// <param name="format">OpenGL.GL_BGRA etc.</param>
        /// <param name="type">OpenGL.GL_UNSIGNED_BYTE etc.</param>
        public CubemapImageFiller(CubemapImages images,
            int level, uint internalformat, int border, uint format, uint type)
        {
            this.images = images;
            this.level = level;
            this.internalformat = internalformat;
            this.border = border;
            this.format = format;
            this.type = type;
        }

        /// <summary>
        /// build texture's content with Bitmap.
        /// </summary>
        public override void Fill()
        {
            foreach (var item in this.images)
            {
                uint target = item.Item1;
                Bitmap image = item.Item2;
                // generate texture.
                //  Lock the image bits (so that we can pass them to OGL).
                BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                OpenGL.TexImage2D(target, 0, this.internalformat, image.Width, image.Height, 0, this.format, this.type, bitmapData.Scan0);

                //  Unlock the image.
                image.UnlockBits(bitmapData);
            }
        }
    }

    /// <summary>
    /// maintains 6 images for cube map.
    /// </summary>
    public class CubemapImages : IEnumerable<Tuple<uint, Bitmap>>, IDisposable
    {
        private Bitmap PositiveX;
        private Bitmap NegativeX;
        private Bitmap PositiveY;
        private Bitmap NegativeY;
        private Bitmap PositiveZ;
        private Bitmap NegativeZ;

        /// <summary>
        /// maintains 6 images for cube map.
        /// </summary>
        /// <param name="positiveX"></param>
        /// <param name="negativeX"></param>
        /// <param name="positiveY"></param>
        /// <param name="negativeY"></param>
        /// <param name="positiveZ"></param>
        /// <param name="negativeZ"></param>
        public CubemapImages(Bitmap positiveX, Bitmap negativeX, Bitmap positiveY, Bitmap negativeY, Bitmap positiveZ, Bitmap negativeZ)
        {
            // TODO: Complete member initialization
            this.PositiveX = positiveX;
            this.NegativeX = negativeX;
            this.PositiveY = positiveY;
            this.NegativeY = negativeY;
            this.PositiveZ = positiveZ;
            this.NegativeZ = negativeZ;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Tuple<uint, Bitmap>> GetEnumerator()
        {
            yield return new Tuple<uint, Bitmap>(OpenGL.GL_TEXTURE_CUBE_MAP_POSITIVE_X, this.PositiveX);
            yield return new Tuple<uint, Bitmap>(OpenGL.GL_TEXTURE_CUBE_MAP_NEGATIVE_X, this.NegativeX);
            yield return new Tuple<uint, Bitmap>(OpenGL.GL_TEXTURE_CUBE_MAP_POSITIVE_Y, this.PositiveY);
            yield return new Tuple<uint, Bitmap>(OpenGL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Y, this.NegativeY);
            yield return new Tuple<uint, Bitmap>(OpenGL.GL_TEXTURE_CUBE_MAP_POSITIVE_Z, this.PositiveZ);
            yield return new Tuple<uint, Bitmap>(OpenGL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Z, this.NegativeZ);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #region IDisposable

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
        ~CubemapImages()
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
                foreach (var item in this)
                {
                    item.Item2.Dispose();
                }
            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion IDisposable
    }
}