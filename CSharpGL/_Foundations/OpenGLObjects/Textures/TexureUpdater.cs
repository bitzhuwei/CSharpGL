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
    public class TexureUpdater
    {
        /// <summary>
        /// OpenGL.GL_TEXTURE0 etc.
        /// </summary>
        public uint ActiveTexture { get; set; }

        /// <summary>
        /// OpenGL.GL_TEXTURE_2D etc.
        /// </summary>
        public uint Target { get; set; }

        /// <summary>
        /// build texture.
        /// </summary>
        public TexureUpdater()
        {
            this.ActiveTexture = OpenGL.GL_TEXTURE0;
            this.Target = OpenGL.GL_TEXTURE_2D;
        }

        /// <summary>
        /// Build texture.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public bool UpdateTexture(Bitmap bitmap)
        {
            throw new NotImplementedException();
            //var ids = new uint[1];
            //// generate texture.
            ////  Lock the image bits (so that we can pass them to OGL).
            //BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            //    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            ////GL.ActiveTexture(GL.GL_TEXTURE0);
            //OpenGL.GetDelegateFor<OpenGL.glActiveTexture>()(this.ActiveTexture);
            //OpenGL.GenTextures(1, ids);
            //OpenGL.BindTexture(this.Target, ids[0]);
            ///* We require 1 byte alignment when uploading texture data */
            ////GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);
            ///* Clamping to edges is important to prevent artifacts when scaling */
            //OpenGL.TexParameteri(this.Target, OpenGL.GL_TEXTURE_WRAP_S, (int)OpenGL.GL_CLAMP_TO_EDGE);
            //OpenGL.TexParameteri(this.Target, OpenGL.GL_TEXTURE_WRAP_T, (int)OpenGL.GL_CLAMP_TO_EDGE);
            ///* Linear filtering usually looks best for text */
            //OpenGL.TexParameteri(this.Target, OpenGL.GL_TEXTURE_MIN_FILTER, (int)OpenGL.GL_LINEAR);
            //OpenGL.TexParameteri(this.Target, OpenGL.GL_TEXTURE_MAG_FILTER, (int)OpenGL.GL_LINEAR);
            //OpenGL.TexImage2D(this.Target, 0, (int)OpenGL.GL_RGBA,
            //    bitmap.Width, bitmap.Height, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE,
            //    bitmapData.Scan0);
            ////  Unlock the image.
            //bitmap.UnlockBits(bitmapData);
            //OpenGL.BindTexture(this.Target, 0);

            //var result = new TextureInfo();
            //result.Id = ids[0];
            //return result;
        }
    }
}
