using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class NewBitmapBuilder : NewImageBuilder
    {
        private System.Drawing.Bitmap bitmap;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        public NewBitmapBuilder(System.Drawing.Bitmap bitmap)
        {
            // TODO: Complete member initialization
            this.bitmap = bitmap;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Build()
        {
            // generate texture.
            //  Lock the image bits (so that we can pass them to OGL).
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            OpenGL.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, (int)OpenGL.GL_RGBA,
                bitmap.Width, bitmap.Height, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE,
                bitmapData.Scan0);
            //  Unlock the image.
            bitmap.UnlockBits(bitmapData);
        }
    }
}
