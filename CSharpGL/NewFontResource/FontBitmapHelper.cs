using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace CSharpGL.NewFontResource
{
    /// <summary>
    /// helper class.
    /// </summary>
    public static class FontBitmapHelper
    {
        /// <summary>
        /// Gets a <see cref="FontBitmap"/>'s intance.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static FontBitmap GetFontBitmap(this Font font, string charSet)
        {
            var result = new FontBitmap();
            result.font = font;
            InitStandardWidths();

            int count = charSet.Length;
            int maxWidth = GetMaxWidth(font.Size, count);

            GetGlyphInfo(result, font.Size, charSet);

            //var fontResource = new FontResource();
            //fontResource.FontHeight = pixelSize + yInterval;
            //fontResource.CharInfoDict = dict;
            //fontResource.InitTexture(finalBitmap);
            //finalBitmap.Dispose();
            //return fontResource;
            return result;
        }

        private static void GetGlyphInfo(FontBitmap fontBitmap, float pixelSize, string charSet)
        {
            InitStandardWidths();
            int maxWidth = GetMaxWidth(pixelSize, charSet.Length);

            using (var bitmap = new Bitmap(maxWidth, maxWidth, PixelFormat.Format24bppRgb))
            {
                float currentX = 0, currentY = 0;
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    foreach (char c in charSet)
                    {
                        BlitCharacter(pixelSize, maxWidth, fontBitmap.glyphInfoDictionary, ref currentX, ref currentY, graphics, c, fontBitmap.font);
                    }
                }

                fontBitmap.glyphBitmap = ShortenBitmap(bitmap, maxWidth, (int)Math.Ceiling(currentY + yInterval + pixelSize + (pixelSize / 10 > 1 ? pixelSize / 10 : 1)));
            }
        }
        static int[] standardWidths;

        private static Bitmap ShortenBitmap(Bitmap bitmap, int width, int height)
        {
            var finalBitmap = new Bitmap(width, height);
            var g = Graphics.FromImage(finalBitmap);
            g.DrawImage(bitmap, 0, 0);
            g.Dispose();
            //finalBitmap.Save("Test.bmp");
            return finalBitmap;
        }

        private static int GetMaxWidth(float pixelSize, int count)
        {
            if (count < 1) { throw new ArgumentException(); }
            float maxWidth = (float)(Math.Sqrt(count) * pixelSize);
            if (maxWidth < pixelSize)
            {
                maxWidth = pixelSize;
            }
            for (int i = 0; i < standardWidths.Length; i++)
            {
                if (maxWidth <= standardWidths[i])
                {
                    maxWidth = standardWidths[i];
                    break;
                }
            }
            return (int)Math.Ceiling(maxWidth);
        }

        private static void InitStandardWidths()
        {
            if (standardWidths == null)
            {
                var maxTextureSize = new int[1];
                OpenGL.GetInteger(GetTarget.MaxTextureSize, maxTextureSize);
                if (maxTextureSize[0] == 0) { maxTextureSize[0] = (int)Math.Pow(2, 14); }
                int i = 2;
                var widths = new List<int>();
                while (Math.Pow(2, i) <= maxTextureSize[0])
                {
                    widths.Add((int)Math.Pow(2, i));
                    i++;
                }
                standardWidths = widths.ToArray();
            }
        }
        private static void BlitCharacter(float pixelSize, int maxWidth, FullDictionary<char, GlyphInfo> dict, ref float currentX, ref float currentY, Graphics graphics, char c, Font font)
        {
            SizeF size = graphics.MeasureString(c.ToString(), font);
            if (currentX + xInterval + size.Width >= maxWidth)
            {
                currentX = 0;
                currentY += yInterval + pixelSize;
                if (currentY + yInterval + pixelSize >= maxWidth)
                { throw new Exception("Texture Size not big enough for required characters."); }
            }
            const int a = 5;
            const int b = 8;
            var info = new GlyphInfo(currentX, currentY, size.Width + xInterval, yInterval + pixelSize - 1);
            dict.Add(c, info);
            currentX += xInterval + size.Width;
        }

        const int xInterval = 1;
        const int yInterval = 10;
    }
}
