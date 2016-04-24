using GLM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public struct Pixel
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;

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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="filename"></param>
        public static void Save2Picture(int x, int y, int width, int height, string filename)
        {
            //int nAlignWidth = (width * 24 + 31) / 32;
            //glReadPixels(0, 0, width, height, GL_RGB, GL_UNSIGNED_BYTE, pdata);

            var pdata = new UnmanagedArray<Pixel>(width * height);
            GL.ReadPixels(x, height - y - 1, width, height, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, pdata.Header);
            //GL.ReadPixels(x, y, width, height, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, pdata.Header);
            {
                var bitmap = new Bitmap(width, height);
                int index = 0;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        Pixel v = pdata[index++];
                        //Color c = Color.FromArgb(v.a, (byte)(v.r + v.g + v.b + v.a), (byte)(v.r + v.g + v.b + v.a), (byte)(v.r + v.g + v.b + v.a));
                        Color c = Color.FromArgb(v.a, v.r, v.g, v.b);
                        //Color c = Color.FromArgb((int)(v.x * 255), (int)(v.y * 255), (int)(v.z * 255), (int)(v.w * 255));
                        bitmap.SetPixel(i, j, c);
                    }
                }
                if (index != width * height)
                {
                    Console.WriteLine("asf");
                }

                bitmap.Save(filename);
            }
            //{
            //    System.Drawing.Imaging.PixelFormat format = System.Drawing.Imaging.PixelFormat.Format32bppArgb;
            //    System.Drawing.Imaging.ImageLockMode lockMode = System.Drawing.Imaging.ImageLockMode.WriteOnly;
            //    var bitmap = new Bitmap(width, height, format);
            //    Rectangle bitmapRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            //    System.Drawing.Imaging.BitmapData bmpData = bitmap.LockBits(bitmapRect, lockMode, format);
            //    int length = Math.Abs(bmpData.Stride) * bitmap.Height;
            //    byte[] bitmapBytes = new byte[length];
            //    for (int row = 0; row < height; row++)
            //    {
            //        for (int col = 0; col < width; col += 4)
            //        {
            //            bitmapBytes[row * bmpData.Stride + col * 4 + 0] = pdata[row * width + col + 0];
            //            bitmapBytes[row * bmpData.Stride + col * 4 + 1] = pdata[row * width + col + 1];
            //            bitmapBytes[row * bmpData.Stride + col * 4 + 2] = pdata[row * width + col + 2];
            //            bitmapBytes[row * bmpData.Stride + col * 4 + 3] = pdata[row * width + col + 3];
            //        }
            //    }

            //    System.Runtime.InteropServices.Marshal.Copy(bitmapBytes, 0, bmpData.Scan0, length);

            //    bitmap.UnlockBits(bmpData);

            //    bitmap.Save(filename);
            //}
        }
    }
}
