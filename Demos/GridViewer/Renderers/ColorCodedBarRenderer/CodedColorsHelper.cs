using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;


namespace GridViewer
{
    public static class CodedColorsHelper
    {
        /// <summary>
        /// Get bitmap of 1 height for coded color bar.
        /// </summary>
        /// <param name="codedColors"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static Bitmap GetBitmap(this CodedColor[] codedColors, int width)
        {
            var format = System.Drawing.Imaging.PixelFormat.Format32bppRgb;
            var lockMode = System.Drawing.Imaging.ImageLockMode.WriteOnly;
            var bitmap = new Bitmap(width, 1, format);
            var bitmapRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpData = bitmap.LockBits(bitmapRect, lockMode, format);

            int length = Math.Abs(bmpData.Stride) * bitmap.Height;
            byte[] bitmapBytes = new byte[length];

            for (int i = 0; i < codedColors.Length - 1; i++)
            {
                int left = (int)(width * codedColors[i].Coord);
                int right = (int)(width * codedColors[i + 1].Coord);
                vec3 leftColor = codedColors[i].DisplayColor;
                vec3 rightColor = codedColors[i + 1].DisplayColor;
                for (int col = left; col < right; col++)
                {
                    vec3 color = (leftColor * ((right - col) * 1.0f / (right - left)) + rightColor * ((col - left) * 1.0f / (right - left)));
                    for (int row = 0; row < 1; row++)
                    {
                        bitmapBytes[row * bmpData.Stride + col * 4 + 0] = (byte)(color.z * 255.0f);
                        bitmapBytes[row * bmpData.Stride + col * 4 + 1] = (byte)(color.y * 255.0f);
                        bitmapBytes[row * bmpData.Stride + col * 4 + 2] = (byte)(color.x * 255.0f);
                    }
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(bitmapBytes, 0, bmpData.Scan0, length);

            bitmap.UnlockBits(bmpData);

            return bitmap;
        }
    }
}
