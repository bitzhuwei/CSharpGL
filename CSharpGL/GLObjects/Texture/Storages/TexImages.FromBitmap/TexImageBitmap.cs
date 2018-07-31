using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Set up 2D texture's content with a <see cref="Bitmap"/> object.
    /// </summary>
    public class TexImageBitmap : TexStorageBase
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly Bitmap bitmap;
        /// <summary>
        /// 
        /// </summary>
        public readonly int width;
        /// <summary>
        /// 
        /// </summary>
        public readonly int height;

        /// <summary>
        /// Set up 2D texture's content with a <see cref="Bitmap"/> object.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="internalFormat"></param>
        /// <param name="mipmapLevelCount"></param>
        /// <param name="border"></param>
        public TexImageBitmap(Bitmap bitmap, uint internalFormat = GL.GL_RGBA, int mipmapLevelCount = 1, bool border = false)
            : base(TextureTarget.Texture2D, internalFormat, mipmapLevelCount, border)
        {
            if (bitmap == null) { throw new ArgumentNullException("bitmap"); }

            this.bitmap = bitmap;
            this.width = bitmap.Width;
            this.height = bitmap.Height;
        }

        /// <summary>
        /// Set up 2D texture's content with a <see cref="Bitmap"/> object.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="internalFormat"></param>
        /// <param name="mipmapLevelCount"></param>
        /// <param name="border"></param>
        public TexImageBitmap(int width, int height, uint internalFormat = GL.GL_RGBA, int mipmapLevelCount = 1, bool border = false)
            : base(TextureTarget.Texture2D, internalFormat, mipmapLevelCount, border)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply()
        {
            var bitmap = this.bitmap;
            if (bitmap == null)
            {
                for (int level = 0; level < mipmapLevelCount; level++)
                {
                    GL.Instance.TexImage2D((uint)this.target, level, this.internalFormat, this.width, this.height, this.border ? 1 : 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, IntPtr.Zero);
                }
            }
            else
            {
                {
                    const int level = 0;
                    BitmapData data = bitmap.LockBits(new Rectangle(0, 0, this.width, this.height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    IntPtr pixels = data.Scan0;
                    GL.Instance.TexImage2D((uint)this.target, level, this.internalFormat, this.width, this.height, this.border ? 1 : 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, pixels);
                    bitmap.UnlockBits(data);
                }
                Bitmap bmp = bitmap;
                for (int level = 1; level < mipmapLevelCount; level++)
                {
                    bmp = (Bitmap)bmp.GetThumbnailImage(bmp.Width / 2, bmp.Height / 2, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
                    BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    IntPtr pixels = data.Scan0;
                    GL.Instance.TexImage2D((uint)this.target, level, this.internalFormat, bmp.Width, bmp.Height, this.border ? 1 : 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, pixels);
                    bmp.UnlockBits(data);
                    bmp.Dispose();
                }
            }
        }

        private bool ThumbnailCallback()
        {
            return false;
        }
    }
}
