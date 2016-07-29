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
        /// <param name="charSet"></param>
        /// <returns></returns>
        public static FontBitmap GetFontBitmap(this Font font, string charSet)
        {
            InitStandardWidths();

            var fontBitmap = new FontBitmap();
            fontBitmap.font = font;

            // 以下三步，不能调换先后顺序。
            // Don't change the order in which these 3 functions invoked.
            GetGlyphSizes(fontBitmap, charSet);
            GetGlyphPositions(fontBitmap, charSet);
            PrintBitmap(fontBitmap, charSet);

            fontBitmap.glyphBitmap.Save("TestFontBitmap.bmp");
            //var fontResource = new FontResource();
            //fontResource.FontHeight = pixelSize + yInterval;
            //fontResource.CharInfoDict = dict;
            //fontResource.InitTexture(finalBitmap);
            //finalBitmap.Dispose();
            //return fontResource;
            return fontBitmap;
        }

        private static void PrintBitmap(FontBitmap fontBitmap, string charSet)
        {
            throw new NotImplementedException();
        }

        private static void GetGlyphPositions(FontBitmap fontBitmap, string charSet)
        {
            throw new NotImplementedException();
        }

        private static void GetGlyphSizes(FontBitmap fontBitmap, string charSet)
        {
            float fontSize = fontBitmap.font.Size;
            int maxWidth = GetMaxWidth(fontSize, charSet.Length);

            using (var bitmap = new Bitmap(maxWidth, maxWidth, PixelFormat.Format24bppRgb))
            {
                float currentX = 0, currentY = 0;
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    foreach (char c in charSet)
                    {
                        SizeF size = graphics.MeasureString(c.ToString(), fontBitmap.font);
                        if (currentX + xInterval + size.Width >= maxWidth)
                        {
                            currentX = 0;
                            currentY += yInterval + fontSize;
                            if (currentY + yInterval + fontSize >= maxWidth)
                            { throw new Exception("Texture Size not big enough for required characters."); }
                        }
                        const int a = 5;
                        const int b = 8;
                        var info = new GlyphInfo(currentX, currentY, size.Width + xInterval, yInterval + fontSize - 1);
                        fontBitmap.glyphInfoDictionary.Add(c, info);
                        currentX += xInterval + size.Width;
                    }
                }
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

        const int xInterval = 1;
        const int yInterval = 10;
    }
}
