using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace CSharpGL
{
    /// <summary>
    /// build texture's content with Bitmap.
    /// </summary>
    public class BitmapFiller : ImageFiller
    {
        private System.Drawing.Bitmap bitmap;
        private int level;
        private uint internalformat;
        private int border;
        private uint format;
        private uint type;
        private TextureTarget target;

        /// <summary>
        /// build texture's content with Bitmap.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="level">0</param>
        /// <param name="internalformat">OpenGL.GL_RGBA etc.</param>
        /// <param name="border">0</param>
        /// <param name="format">OpenGL.GL_BGRA etc.</param>
        /// <param name="type">OpenGL.GL_UNSIGNED_BYTE etc.</param>
        /// <param name="target2d">true for 2D; false for 1D.</param>
        public BitmapFiller(System.Drawing.Bitmap bitmap,
            int level, uint internalformat, int border, uint format, uint type, bool target2d = true)
        {
            this.bitmap = bitmap;
            this.level = level;
            this.internalformat = internalformat;
            this.border = border;
            this.format = format;
            this.type = type;
            this.target = target2d ? TextureTarget.Texture2D : TextureTarget.Texture1D;
        }

        /// <summary>
        /// build texture's content with Bitmap.
        /// </summary>
        public override void Fill()
        {
            // generate texture.
            //  Lock the image bits (so that we can pass them to OGL).
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            if (target == TextureTarget.Texture1D)
            {
                OpenGL.TexImage1D((uint)target, 0, this.internalformat, bitmap.Width, 0, this.format, this.type, bitmapData.Scan0);
            }
            else if (target == TextureTarget.Texture2D)
            {
                OpenGL.TexImage2D((uint)target, 0, this.internalformat, bitmap.Width, bitmap.Height, 0, this.format, this.type, bitmapData.Scan0);
            }
            else
            { throw new NotImplementedException(); }

            //  Unlock the image.
            bitmap.UnlockBits(bitmapData);
        }
    }
}