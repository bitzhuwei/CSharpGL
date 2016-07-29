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
            float totalWidth = 0.0f;
            float maxHeight = 0.0f;
            foreach (GlyphInfo item in fontBitmap.glyphInfoDictionary.Values)
            {
                totalWidth += item.width;
                if (maxHeight < item.height) { maxHeight = item.height; }
            }
            //int maxHeight = (int)Math.Ceiling(maxHeightf);
            float area = totalWidth * maxHeight;
            int sideLength = (int)Math.Ceiling(Math.Sqrt(area));
            float currentX = 0, currentY = 0;
            foreach (GlyphInfo item in fontBitmap.glyphInfoDictionary.Values)
            {
                item.xoffset = currentX;
                item.yoffset = currentY;
                currentX += item.width;
                if (currentX >= sideLength)
                {
                    currentY += maxHeight;
                    currentX = 0;
                }
            }
        }

        private static void GetGlyphSizes(FontBitmap fontBitmap, string charSet)
        {
            float fontSize = fontBitmap.font.Size;

            using (var bitmap = new Bitmap(1, 1, PixelFormat.Format24bppRgb))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    foreach (char c in charSet)
                    {
                        SizeF size = graphics.MeasureString(c.ToString(), fontBitmap.font);
                        // glyph's position is not settled yet.
                        var info = new GlyphInfo(0, 0, size.Width, size.Height);
                        fontBitmap.glyphInfoDictionary.Add(c, info);
                    }
                }
            }
        }

        private static Bitmap ShortenBitmap(Bitmap bitmap, int width, int height)
        {
            var finalBitmap = new Bitmap(width, height);
            var g = Graphics.FromImage(finalBitmap);
            g.DrawImage(bitmap, 0, 0);
            g.Dispose();
            //finalBitmap.Save("Test.bmp");
            return finalBitmap;
        }

        const int xInterval = 1;
        const int yInterval = 10;
    }
}
