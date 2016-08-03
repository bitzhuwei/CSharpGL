using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// update texture's content.
    /// </summary>
    public class TextureUpdater
    {
        /// <summary>
        /// texture's id.
        /// </summary>
        public uint Id { get; private set; }

        ///// <summary>
        ///// OpenGL.GL_TEXTURE0 etc.
        ///// </summary>
        //public uint ActiveTexture { get; set; }

        /// <summary>
        /// OpenGL.GL_TEXTURE_2D etc.
        /// </summary>
        public uint Target { get; set; }

        /// <summary>
        /// build texture.
        /// </summary>
        public TextureUpdater(uint id)
        {
            this.Id = id;
            //this.ActiveTexture = OpenGL.GL_TEXTURE0;
            this.Target = OpenGL.GL_TEXTURE_2D;
        }

        /// <summary>
        /// Build texture.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public bool UpdateTexture(Bitmap bitmap)
        {
            //  Lock the image bits (so that we can pass them to OGL).
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            OpenGL.BindTexture(this.Target, this.Id);
            OpenGL.TexImage2D(this.Target, 0, (int)OpenGL.GL_RGBA,
                bitmapData.Width, bitmapData.Height, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE,
                bitmapData.Scan0);
            //  Unlock the image.
            bitmap.UnlockBits(bitmapData);
            OpenGL.BindTexture(this.Target, 0);

            //// TODO: TexSubImage2D() do not work. why?
            //BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            //    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            //OpenGL.BindTexture(this.Target, this.Id);
            //OpenGL.TexSubImage2D(this.Target, 0, 0, 0, bitmap.Width, bitmap.Height, OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE, bitmapData.Scan0);
            //OpenGL.TexSubImage2D(TexSubImage2DTarget.Texture2D, 0, 0, 0, bitmap.Width, bitmap.Height, TexSubImage2DFormats.RGBA, TexSubImage2DType.UnsignedByte, bitmapData.Scan0);
            //OpenGL.BindTexture(this.Target, 0);
            //bitmap.UnlockBits(bitmapData);

            return true;
        }

    }
}
