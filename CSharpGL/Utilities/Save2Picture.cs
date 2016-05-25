using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    struct Pixel
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;

        public Pixel(byte r, byte g, byte b, byte a)
        {
            this.r = r; this.g = g; this.b = b; this.a = a;
        }

        public Color ToColor()
        {
            return Color.FromArgb(a, r, g, b);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", r, g, b, a);
        }
    }
    /// <summary>
    /// Helper class for array.
    /// </summary>
    public static class Save2PictureHelper
    {
        /// <summary>
        /// 把OpenGL渲染的内容保存到图片文件。
        /// </summary>
        /// <param name="x">左下角坐标为(0, 0)</param>
        /// <param name="y">左下角坐标为(0, 0)</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="filename"></param>
        public static void Save2Picture(int x, int y, int width, int height, string filename)
        {
            var format = System.Drawing.Imaging.PixelFormat.Format32bppArgb;
            using (var bitmap = new Bitmap(width, height, format))
            {
                var bitmapRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                var lockMode = System.Drawing.Imaging.ImageLockMode.WriteOnly;
                System.Drawing.Imaging.BitmapData bmpData = bitmap.LockBits(bitmapRect, lockMode, format);
                OpenGL.ReadPixels(x, y, width, height, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE, bmpData.Scan0);
                bitmap.UnlockBits(bmpData);
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);

                bitmap.Save(filename);
            }
        }
    }
}
