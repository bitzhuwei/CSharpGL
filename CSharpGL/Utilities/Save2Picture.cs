using GLM;
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
        static Random random = new Random();
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
            var pdata = new UnmanagedArray<Pixel>(width * height);
            GL.ReadPixels(x, y, width, height, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, pdata.Header);
            //{
            //    var bitmap = new Bitmap(width, height);
            //    int index = 0;
            //    for (int j = height - 1; j >= 0; j--)
            //    {
            //        for (int i = 0; i < width; i++)
            //        {
            //            Pixel v = pdata[index++];
            //            Color c = v.ToColor();
            //            bitmap.SetPixel(i, j, c);
            //        }
            //    }

            //    bitmap.Save(filename);
            //}
            {
                System.Drawing.Imaging.PixelFormat format = System.Drawing.Imaging.PixelFormat.Format32bppArgb;
                System.Drawing.Imaging.ImageLockMode lockMode = System.Drawing.Imaging.ImageLockMode.WriteOnly;
                var bitmap = new Bitmap(width, height, format);
                Rectangle bitmapRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                System.Drawing.Imaging.BitmapData bmpData = bitmap.LockBits(bitmapRect, lockMode, format);
                int length = Math.Abs(bmpData.Stride) * bitmap.Height;
                byte[] bitmapBytes = new byte[length];
                int index = 0;
                for (int j = height - 1; j >= 0; j--)
                {
                    for (int i = 0; i < width; i++)
                    {
                        Pixel v = pdata[index++];
                        bitmapBytes[j * bmpData.Stride + i * 4 + 0] = v.b;
                        bitmapBytes[j * bmpData.Stride + i * 4 + 1] = v.g;
                        bitmapBytes[j * bmpData.Stride + i * 4 + 2] = v.r;
                        bitmapBytes[j * bmpData.Stride + i * 4 + 3] = v.a;
                    }
                }

                System.Runtime.InteropServices.Marshal.Copy(bitmapBytes, 0, bmpData.Scan0, length);

                bitmap.UnlockBits(bmpData);

                bitmap.Save(filename);
            }
        }
    }
}
