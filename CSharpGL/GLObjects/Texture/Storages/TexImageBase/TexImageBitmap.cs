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
        public readonly int levelCount;

        /// <summary>
        /// Set up texture's content with 'glTexImage2D()'.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="border"></param>
        /// <param name="levelCount"></param>
        public TexImageBitmap(Bitmap bitmap, int border, int levelCount = 1)
            : base(TextureTarget.Texture2D, GL.GL_RGBA, border)
        {
            this.levelCount = levelCount;
            this.bitmap = bitmap;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply()
        {
            var bitmap = this.bitmap;
            {
                BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                IntPtr pixels = data.Scan0;
                GL.Instance.TexImage2D((uint)this.target, 0, this.internalFormat, bitmap.Width, bitmap.Height, this.border, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, pixels);
                bitmap.UnlockBits(data);
            }
            Bitmap bmp = bitmap;
            for (int level = 1; level < levelCount; level++)
            {
                bmp = (Bitmap)bitmap.GetThumbnailImage(bmp.Width / 2, bmp.Height / 2, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
                BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                IntPtr pixels = data.Scan0;
                GL.Instance.TexImage2D((uint)this.target, level, this.internalFormat, bmp.Width, bmp.Height, this.border, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, pixels);
                bmp.UnlockBits(data);
            }
        }

        private bool ThumbnailCallback()
        {
            return false;
        }
    }
}
