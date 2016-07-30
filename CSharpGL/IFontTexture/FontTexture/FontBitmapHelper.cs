using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// helper class.
    /// </summary>
    public static class FontBitmapHelper
    {
        /// <summary>
        /// bigger interval means less mix. Maybe 1 is enough for font with size of 64.
        /// </summary>
        const int glyphInterval = 1;
        /// <summary>
        /// bigger maring means less mix. But 1 is enough.
        /// </summary>
        const int leftMargin = 1;
        /// <summary>
        /// Gets a <see cref="FontBitmap"/>'s intance.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="charSet"></param>
        /// <param name="drawBoundary"></param>
        /// <returns></returns>
        public static FontBitmap GetFontBitmap(this Font font, string charSet, bool drawBoundary = false)
        {
            var fontBitmap = new FontBitmap();
            fontBitmap.GlyphFont = font;

            // 以下几步，不能调换先后顺序。
            // Don't change the order in which these functions invoked.
            // TODO: 下述方式尚有可优化的余地：应避免创建中间过程产生的大型Bitmap。
            // TODO: avoid creating big bitmap during the whole process except the last one.
            GetGlyphSizes(fontBitmap, charSet);
            int width, height;
            GetGlyphPositions(fontBitmap, charSet, out width, out height);
            PrintBitmap(fontBitmap, charSet, width, height);
            RetargetGlyphRectangleInwards(fontBitmap);
            ReprintBitmap(fontBitmap);
            if (drawBoundary)
            {
                using (var graphics = Graphics.FromImage(fontBitmap.GlyphBitmap))
                {
                    foreach (var item in fontBitmap.GlyphInfoDictionary.Values)
                    {
                        graphics.DrawRectangle(Pens.Green, item.ToRectangle());
                    }
                    graphics.DrawRectangle(Pens.Red, 0, 0, fontBitmap.GlyphBitmap.Width - 1, fontBitmap.GlyphBitmap.Height - 1);
                }
            }
            return fontBitmap;
        }

        /// <summary>
        /// reprint(shrink) glyph's bitmap.
        /// </summary>
        /// <param name="fontBitmap"></param>
        private static void ReprintBitmap(FontBitmap fontBitmap)
        {
            int totalWidth = 0;
            int maxGlyphHeight = 0;
            var dict = new FullDictionary<char, GlyphInfo>(GlyphInfo.Default);
            foreach (var item in fontBitmap.GlyphInfoDictionary)
            {
                var glyphInfo = item.Value.Clone() as GlyphInfo;
                dict.Add(item.Key, glyphInfo);
                totalWidth += glyphInfo.width + glyphInterval;
                if (maxGlyphHeight < glyphInfo.height) { maxGlyphHeight = glyphInfo.height; }
            }
            int area = totalWidth * maxGlyphHeight;
            int sideLength = (int)Math.Ceiling(Math.Sqrt(area));
            var bitmap = new Bitmap(sideLength, sideLength + maxGlyphHeight);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                int currentX = leftMargin, currentY = 0;
                foreach (var item in dict)
                {
                    if (currentX + item.Value.width >= bitmap.Width)
                    {
                        currentX = leftMargin;
                        currentY += maxGlyphHeight;
                    }
                    GlyphInfo originalGlyphInfo = fontBitmap.GlyphInfoDictionary[item.Key];
                    graphics.DrawImage(fontBitmap.GlyphBitmap,
                        new Rectangle(currentX, currentY, item.Value.width, item.Value.height),
                        originalGlyphInfo.ToRectangle(), GraphicsUnit.Pixel);
                    item.Value.xoffset = currentX;
                    item.Value.yoffset = currentY;
                    currentX += item.Value.width + glyphInterval;
                }
            }
            fontBitmap.GlyphInfoDictionary.Clear();
            fontBitmap.GlyphBitmap.Dispose();
            fontBitmap.GlyphInfoDictionary = dict;
            fontBitmap.GlyphBitmap = bitmap;
        }

        /// <summary>
        /// print all glyphs to <paramref name="fontBitmap"/>'s bitmap field.
        /// </summary>
        /// <param name="fontBitmap"></param>
        /// <param name="charSet"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private static void PrintBitmap(FontBitmap fontBitmap, string charSet, int width, int height)
        {
            var bitmap = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                foreach (KeyValuePair<char, GlyphInfo> item in fontBitmap.GlyphInfoDictionary)
                {
                    graphics.DrawString(item.Key.ToString(), fontBitmap.GlyphFont, Brushes.White, item.Value.xoffset, item.Value.yoffset);
                }
            }

            fontBitmap.GlyphBitmap = bitmap;
        }

        /// <summary>
        /// shrink glyph's width.
        /// </summary>
        /// <param name="fontBitmap"></param>
        private static void RetargetGlyphRectangleInwards(FontBitmap fontBitmap)
        {
            Bitmap bitmap = fontBitmap.GlyphBitmap;
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            foreach (var glyphInfo in fontBitmap.GlyphInfoDictionary)
            {
                if (glyphInfo.Key == ' ' || glyphInfo.Key == '\t' || glyphInfo.Key == '\r' || glyphInfo.Key == '\n') { continue; }

                RetargetGlyphRectangleInwards(bitmapData, glyphInfo.Value);
            }

            bitmap.UnlockBits(bitmapData);
        }

        /// <summary>
        /// Returns try if the given pixel is empty (i.e. black)
        /// </summary>
        /// <param name="bitmapData"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private static unsafe bool IsEmptyPixel(BitmapData bitmapData, int x, int y)
        {
            var addr = (byte*)(bitmapData.Scan0) + bitmapData.Stride * y + x * 3;
            return (*addr == 0 && *(addr + 1) == 0 && *(addr + 2) == 0);
        }

        /// <summary>
        /// shrink glyph's width to fit in exactly.
        /// </summary>
        /// <param name="bitmapData"></param>
        /// <param name="glyph"></param>
        private static void RetargetGlyphRectangleInwards(BitmapData bitmapData, GlyphInfo glyph)
        {
            int startX, endX;

            {
                bool done = false;
                for (startX = glyph.xoffset; startX < bitmapData.Width; startX++)
                {
                    for (int j = glyph.yoffset; j < glyph.yoffset + glyph.height; j++)
                    {
                        if (!IsEmptyPixel(bitmapData, startX, j))
                        {
                            done = true;
                            break;
                        }
                    }
                    if (done) { break; }
                }
            }
            {
                bool done = false;
                for (endX = glyph.xoffset + glyph.width - 1; endX >= 0; endX--)
                {
                    for (int j = glyph.yoffset; j < glyph.yoffset + glyph.height; j++)
                    {
                        if (!IsEmptyPixel(bitmapData, endX, j))
                        {
                            done = true;
                            break;
                        }
                    }
                    if (done) { break; }
                }
            }

            if (endX < startX)
            {
                //startX = endX = glyph.xoffset;
                glyph.width = 0;
            }
            else
            {
                glyph.xoffset = startX;
                glyph.width = endX - startX + 1;
            }
        }

        /// <summary>
        /// Gets glyph's position(xoffset, yoffset) and bitmap's size(width, size)
        /// </summary>
        /// <param name="fontBitmap"></param>
        /// <param name="charSet"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private static void GetGlyphPositions(FontBitmap fontBitmap, string charSet, out int width, out int height)
        {
            int sideLength;
            int maxGlyphHeight = 0;
            {
                float totalWidth = 0.0f;
                foreach (GlyphInfo item in fontBitmap.GlyphInfoDictionary.Values)
                {
                    totalWidth += item.width + glyphInterval;
                    if (maxGlyphHeight < item.height) { maxGlyphHeight = item.height; }
                }
                float area = totalWidth * maxGlyphHeight;
                sideLength = (int)Math.Ceiling(Math.Sqrt(area));
                fontBitmap.GlyphHeight = maxGlyphHeight;
            }
            {
                int maxWidth = 0, maxHeight = 0;
                int currentX = 0, currentY = 0;
                foreach (var item in fontBitmap.GlyphInfoDictionary)
                {
                    if (currentX + item.Value.width < sideLength)
                    {
                        item.Value.xoffset = currentX;
                        item.Value.yoffset = currentY;
                        currentX += item.Value.width + glyphInterval;
                    }
                    else
                    {
                        if (maxWidth < currentX) { maxWidth = currentX; }
                        currentX = 0;
                        currentY += maxGlyphHeight;
                        item.Value.xoffset = currentX;
                        item.Value.yoffset = currentY;
                        currentX += item.Value.width + glyphInterval;
                    }
                }
                maxHeight = currentY + maxGlyphHeight;
                width = maxWidth;
                height = maxHeight;
            }
        }

        /// <summary>
        /// get glyph's size(width, height) by Graphics.DrawString().
        /// </summary>
        /// <param name="fontBitmap"></param>
        /// <param name="charSet"></param>
        private static void GetGlyphSizes(FontBitmap fontBitmap, string charSet)
        {
            float fontSize = fontBitmap.GlyphFont.Size;

            using (var bitmap = new Bitmap(1, 1, PixelFormat.Format24bppRgb))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    foreach (char c in charSet)
                    {
                        SizeF size = graphics.MeasureString(c.ToString(), fontBitmap.GlyphFont);
                        // glyph's position is not settled yet.
                        var info = new GlyphInfo(0, 0, (int)size.Width, (int)size.Height);
                        fontBitmap.GlyphInfoDictionary.Add(c, info);
                    }
                }
            }
        }

    }
}
