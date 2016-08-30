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

        /// <summary>
        /// build texture's content with Bitmap.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="target"></param>
        public BitmapBuilder(System.Drawing.Bitmap bitmap, BindTextureTarget target)
        {
            // TODO: Complete member initialization
            this.bitmap = bitmap;
            this.Target = target;
        }

        /// <summary>
        /// build texture's content with Bitmap.
        /// </summary>
        public override void Build()
        {
            // generate texture.
            //  Lock the image bits (so that we can pass them to OGL).
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            if (Target == BindTextureTarget.Texture1D)
            {
                OpenGL.TexImage1D((uint)Target, 0, (int)OpenGL.GL_RGBA, bitmap.Width, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE, bitmapData.Scan0);
            }
            else if (Target == BindTextureTarget.Texture2D)
            {
                OpenGL.TexImage2D((uint)Target, 0, (int)OpenGL.GL_RGBA, bitmap.Width, bitmap.Height, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE, bitmapData.Scan0);
            }
            else
            { throw new NotImplementedException(); }

            //  Unlock the image.
            bitmap.UnlockBits(bitmapData);
        }
    }
}
