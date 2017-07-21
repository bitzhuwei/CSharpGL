using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace CSharpGL
{
    /// <summary>
    /// update texture's content.
    /// </summary>
    public static class TextureHelper
    {
        /// <summary>
        /// upadte texture's content.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="bitmap"></param>
        public static void UpdateContent(this Texture texture, Bitmap bitmap)
        {
            //  Lock the image bits (so that we can pass them to OGL).
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            GL.Instance.BindTexture((uint)texture.Target, texture.Id);
            if (texture.Target == TextureTarget.Texture1D)
            {
                GL.Instance.TexImage1D((uint)texture.Target, 0, (int)GL.GL_RGBA, bitmapData.Width, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, bitmapData.Scan0);
            }
            else if (texture.Target == TextureTarget.Texture2D)
            {
                GL.Instance.TexImage2D((uint)texture.Target, 0, (int)GL.GL_RGBA, bitmapData.Width, bitmapData.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, bitmapData.Scan0);
            }
            else
            {
                throw new Exception("Unexpected TextureTarget!");
            }
            GL.Instance.BindTexture((uint)texture.Target, 0);

            //  Unlock the image.
            bitmap.UnlockBits(bitmapData);

            //// TODO: TexSubImage2D() do not work. why?
            //BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            //    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            //OpenGL.BindTexture(this.Target, this.Id);
            //OpenGL.TexSubImage2D(this.Target, 0, 0, 0, bitmap.Width, bitmap.Height, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, bitmapData.Scan0);
            //OpenGL.TexSubImage2D(TexSubImage2DTarget.Texture2D, 0, 0, 0, bitmap.Width, bitmap.Height, TexSubImage2DFormats.RGBA, TexSubImage2DType.UnsignedByte, bitmapData.Scan0);
            //OpenGL.BindTexture(this.Target, 0);
            //bitmap.UnlockBits(bitmapData);
        }

        /// <summary>
        /// get <see cref="samplerValue"/> from this texture.
        /// </summary>
        /// <param name="texture"></param>
        /// <returns></returns>
        public static samplerValue ToSamplerValue(this Texture texture)
        {
            return new samplerValue(
                texture.Target,
                texture.Id,
                texture.TextureUnitIndex);
        }
    }
}