using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// 
    /// </summary>
    public static unsafe partial class TextureHelper {
        /// <summary>
        /// Get image from texture.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public static unsafe IGLBitmap GetImage(this Texture texture, int width, int height, int level = 0) {
            var bmp = new GLBitmap(width, height, 4);
            var gl = GL.current; if (gl == null) { return bmp; }
            texture.Bind();

            //var data = bmp.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //var data = bmp.Lock();
            gl.glGetTexImage((GLenum)texture.Target, level, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, bmp.scan0);
            //bmp.Unlock();
            //bmp.RotateFlip(RotateFlipType.Rotate180FlipX);

            texture.Unbind();

            return bmp;
        }

        /// <summary>
        /// Get image from a cubemap texture.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="face"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public static unsafe IGLBitmap GetImage(this Texture texture, CubemapFace face, int width, int height, int level = 0) {
            var bmp = new GLBitmap(width, height, 4);
            var gl = GL.current; if (gl == null) { return bmp; }
            texture.Bind();

            //var data = bmp.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //var data = bmp.Lock();
            gl.glGetTexImage((uint)face, level, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, bmp.Scan0);
            //bmp.Unlock();
            //bmp.RotateFlip(RotateFlipType.Rotate180FlipX);

            texture.Unbind();

            return bmp;
        }
    }

}
