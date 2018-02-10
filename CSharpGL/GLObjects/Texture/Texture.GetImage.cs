using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class TextureHelper
    {
        /// <summary>
        /// Get image from texture.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static unsafe Bitmap GetImage(this Texture texture, int width, int height)
        {
            texture.Bind();

            var bmp = new Bitmap(width, height);
            var data = bmp.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.Instance.GetTexImage((uint)texture.Target, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, data.Scan0);
            bmp.UnlockBits(data);
            bmp.RotateFlip(RotateFlipType.Rotate180FlipX);

            texture.Unbind();

            return bmp;
        }
    }

}
