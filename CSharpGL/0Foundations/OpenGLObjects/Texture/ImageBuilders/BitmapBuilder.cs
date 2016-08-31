using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// build texture's content with Bitmap.
    /// </summary>
    public class BitmapBuilder : ImageBuilder
    {
        private System.Drawing.Bitmap bitmap;
        private int level;
        private uint internalformat;
        private int border;
        private uint format;
        private uint type;

        /// <summary>
        /// build texture's content with Bitmap.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="level">0</param>
        /// <param name="internalformat">OpenGL.GL_RGBA etc.</param>
        /// <param name="border">0</param>
        /// <param name="format">OpenGL.GL_BGRA etc.</param>
        /// <param name="type">OpenGL.GL_UNSIGNED_BYTE etc.</param>
        public BitmapBuilder(System.Drawing.Bitmap bitmap,
            int level, uint internalformat, int border, uint format, uint type)
        {
            this.bitmap = bitmap;
            this.level = level;
            this.internalformat = internalformat;
            this.border = border;
            this.format = format;
            this.type = type;
        }

        /// <summary>
        /// build texture's content with Bitmap.
        /// </summary>
        /// <param name="target"></param>
        public override void Build(BindTextureTarget target)
        {
            // generate texture.
            //  Lock the image bits (so that we can pass them to OGL).
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            if (target == BindTextureTarget.Texture1D)
            {
                OpenGL.TexImage1D((uint)target, 0, this.internalformat, bitmap.Width, 0, this.format, this.type, bitmapData.Scan0);
            }
            else if (target == BindTextureTarget.Texture2D)
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
