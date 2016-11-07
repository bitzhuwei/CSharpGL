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
        private int maxLevel;
        private uint internalformat;
        private int border;
        private uint format;
        private uint type;
        private TextureTarget target;

        /// <summary>
        /// build texture's content with Bitmap.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="maxLevel">0 as default.</param>
        /// <param name="internalformat">OpenGL.GL_RGBA etc.</param>
        /// <param name="border">max level.</param>
        /// <param name="format">OpenGL.GL_BGRA etc.</param>
        /// <param name="type">OpenGL.GL_UNSIGNED_BYTE etc.</param>
        /// <param name="target2d">true for 2D; false for 1D.</param>
        public BitmapFiller(System.Drawing.Bitmap bitmap,
            int maxLevel, uint internalformat, int border, uint format, uint type, bool target2d = true)
        {
            if (maxLevel < 0) { throw new ArgumentException("texture level must be no less than 0!"); }

            this.bitmap = bitmap;
            this.maxLevel = maxLevel;
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
            if (target == TextureTarget.Texture1D)
            {
                Bitmap bmp = null;
                for (int level = 0; level <= this.maxLevel; level++)
                {
                    if (level == 0) { bmp = this.bitmap; }
                    else
                    {
                        bmp.Dispose();
                        int width = bmp.Width / 2;
                        if (width < 1) { width = 1; }
                        bmp = new Bitmap(bmp, width, 1);
                    }
                    //  Lock the image bits (so that we can pass them to OGL).
                    BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                    OpenGL.TexImage1D((uint)target, level, this.internalformat, bitmap.Width, 0, this.format, this.type, bitmapData.Scan0);
                    //  Unlock the image.
                    bmp.UnlockBits(bitmapData);
                }

                if (bmp != this.bitmap) { bmp.Dispose(); }
            }
            else if (target == TextureTarget.Texture2D)
            {
                Bitmap bmp = null;
                for (int level = 0; level <= this.maxLevel; level++)
                {
                    if (level == 0) { bmp = this.bitmap; }
                    else
                    {
                        bmp.Dispose();
                        int width = bmp.Width / 2, height = bmp.Height / 2;
                        if (width < 1) { width = 1; }
                        if (height < 1) { height = 1; }
                        bmp = new Bitmap(bmp, width, height);
                    }
                    //  Lock the image bits (so that we can pass them to OGL).
                    BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                    OpenGL.TexImage2D((uint)target, level, this.internalformat, bmp.Width, bmp.Height, 0, this.format, this.type, bitmapData.Scan0);
                    //  Unlock the image.
                    bmp.UnlockBits(bitmapData);
                }

                if (bmp != this.bitmap) { bmp.Dispose(); }
            }
            else
            { throw new NotImplementedException(); }

        }
    }
}