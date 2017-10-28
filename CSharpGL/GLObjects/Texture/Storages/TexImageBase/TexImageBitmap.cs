using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Set up texture's content with 'glTexImage2D()'.
    /// </summary>
    public class TexImageBitmap : TexImageBase
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
        /// 
        /// </summary>
        public readonly int levelCount;

        /// <summary>
        /// Set up texture's content with 'glTexImage2D()'.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="internalFormat"></param>
        /// <param name="levelCount"></param>
        /// <param name="border"></param>
        public TexImageBitmap(Bitmap bitmap, uint internalFormat = GL.GL_RGBA, int levelCount = 1, int border = 0)
            : base(TextureTarget.Texture2D, internalFormat, border)
        {
            if (bitmap == null) { throw new ArgumentNullException("bitmap"); }

            this.levelCount = levelCount;
            this.bitmap = bitmap;
            this.width = bitmap.Width;
            this.height = bitmap.Height;
        }

        /// <summary>
        /// Set up texture's content with 'glTexImage2D()'.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="border"></param>
        public TexImageBitmap(int width, int height, int border = 0)
            : base(TextureTarget.Texture2D, GL.GL_RGBA, border)
        {
            this.width = width;
            this.height = height;
            this.levelCount = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply()
        {
            var bitmap = this.bitmap;
            if (bitmap == null)
            {
                // TODO: add mipmap parameter.
                GL.Instance.TexImage2D((uint)this.target, 0, this.internalFormat, this.width, this.height, this.border, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, IntPtr.Zero);
            }
            else
            {
                {
                    BitmapData data = bitmap.LockBits(new Rectangle(0, 0, this.width, this.height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    IntPtr pixels = data.Scan0;
                    GL.Instance.TexImage2D((uint)this.target, 0, this.internalFormat, this.width, this.height, this.border, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, pixels);
                    bitmap.UnlockBits(data);
                }
                Bitmap bmp = bitmap;
                for (int level = 1; level < levelCount; level++)
                {
                    bmp = (Bitmap)bmp.GetThumbnailImage(bmp.Width / 2, bmp.Height / 2, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
                    BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    IntPtr pixels = data.Scan0;
                    GL.Instance.TexImage2D((uint)this.target, level, this.internalFormat, bmp.Width, bmp.Height, this.border, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, pixels);
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
