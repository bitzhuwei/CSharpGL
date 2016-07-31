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
    public static partial class FontBitmapHelper
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
            int singleCharWidth, singleCharHeight;
            PrepareInitialGlyphDict(fontBitmap, charSet, out singleCharWidth, out singleCharHeight);
            int width, height;
            PrepareFinalBitmapSize(fontBitmap, out width, out height);
            PrintBitmap(fontBitmap, singleCharWidth, singleCharHeight, width, height);
            if (drawBoundary)
            {
                using (var graphics = Graphics.FromImage(fontBitmap.GlyphBitmap))
                {
                    bool odd = false;
                    foreach (var item in fontBitmap.GlyphInfoDictionary.Values)
                    {
                        graphics.DrawRectangle(
                            odd ? Pens.Green : Pens.Blue,
                            item.ToRectangle(1, 1, -2, -1));
                        odd = !odd;
                    }
                    graphics.DrawRectangle(Pens.Red, 0, 0, fontBitmap.GlyphBitmap.Width - 1, fontBitmap.GlyphBitmap.Height - 1);
                }
            }
            return fontBitmap;
        }

        /// <summary>
        /// Print the final bitmap that contains all glyphs.
        /// And also setup glyph's xoffset, yoffset.
        /// </summary>
        /// <param name="fontBitmap"></param>
        /// <param name="singleCharWidth"></param>
        /// <param name="singleCharHeight"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private static void PrintBitmap(FontBitmap fontBitmap, int singleCharWidth, int singleCharHeight, int width, int height)
        {
            var bitmap = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                using (var glyphBitmap = new Bitmap(singleCharWidth, singleCharHeight))
                {
                    using (var glyphGraphics = Graphics.FromImage(glyphBitmap))
                    {
                        int currentX = leftMargin, currentY = 0;
                        Color clearColor = Color.FromArgb(0, 0, 0, 0);
                        foreach (KeyValuePair<char, GlyphInfo> item in fontBitmap.GlyphInfoDictionary)
                        {
                            glyphGraphics.Clear(clearColor);
                            glyphGraphics.DrawString(item.Key.ToString(), fontBitmap.GlyphFont,
                                Brushes.White, 0, 0);
                            glyphBitmap.Save(string.Format("TestTest{0}.bmp", (int)item.Key));
                            // move to new line if this line is full.
                            if (currentX + item.Value.width > width)
                            {
                                currentX = leftMargin;
                                currentY += singleCharHeight;
                            }
                            // draw the current glyph.
                            graphics.DrawImage(glyphBitmap,
                                new Rectangle(currentX, currentY, item.Value.width, item.Value.height),
                                item.Value.ToRectangle(),
                                GraphicsUnit.Pixel);
                            // move line cursor to next(right) position.
                            item.Value.xoffset = currentX;
                            item.Value.yoffset = currentY;
                            // prepare for next glyph's position.
                            currentX += item.Value.width + glyphInterval;
                        }
                    }
                }
            }

            fontBitmap.GlyphBitmap = bitmap;
        }

        /// <summary>
        /// prepare final bitmap's size.
        /// </summary>
        /// <param name="fontBitmap"></param>
        /// <param name="width">final bitmap's width.</param>
        /// <param name="height">final bitmap's height.</param>
        private static void PrepareFinalBitmapSize(FontBitmap fontBitmap, out int width, out int height)
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
                int currentX = leftMargin, currentY = 0;
                foreach (var item in fontBitmap.GlyphInfoDictionary)
                {
                    if (currentX + item.Value.width < sideLength)
                    {
                        currentX += item.Value.width + glyphInterval;
                    }
                    else
                    {
                        if (maxWidth < currentX) { maxWidth = currentX; }
                        currentX = leftMargin;
                        currentY += maxGlyphHeight;
                        currentX += item.Value.width + glyphInterval;
                    }
                }
                if (currentX > leftMargin)
                {
                    maxHeight = currentY + maxGlyphHeight;
                }
                else
                {
                    maxHeight = currentY;
                }
                width = maxWidth;
                height = maxHeight;
            }
        }

        /// <summary>
        /// Get glyph's size by graphics.MeasureString().
        /// Then shrink glyph's size.
        /// xoffset now means offset in a single glyph's bitmap.
        /// </summary>
        /// <param name="fontBitmap"></param>
        /// <param name="charSet"></param>
        /// <param name="singleCharWidth"></param>
        /// <param name="singleCharHeight"></param>
        private static void PrepareInitialGlyphDict(FontBitmap fontBitmap, string charSet, out int singleCharWidth, out int singleCharHeight)
        {
            // Get glyph's size by graphics.MeasureString().
            {
                int maxWidth = 0, maxHeight = 0;

                float fontSize = fontBitmap.GlyphFont.Size;

                using (var bitmap = new Bitmap(1, 1, PixelFormat.Format24bppRgb))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        foreach (char c in charSet)
                        {
                            SizeF size = graphics.MeasureString(c.ToString(), fontBitmap.GlyphFont);
                            var info = new GlyphInfo(0, 0, (int)size.Width, (int)size.Height);
                            fontBitmap.GlyphInfoDictionary.Add(c, info);
                            if (maxWidth < (int)size.Width) { maxWidth = (int)size.Width; }
                            if (maxHeight < (int)size.Height) { maxHeight = (int)size.Height; }
                        }
                    }
                }
                singleCharWidth = maxWidth;
                singleCharHeight = maxHeight;
            }
            // shrink glyph's size.
            // xoffset now means offset in a single glyph's bitmap.
            {
                using (var bitmap = new Bitmap(singleCharWidth, singleCharHeight))
                {
                    using (var graphics = Graphics.FromImage(bitmap))
                    {
                        Color clearColor = Color.FromArgb(0, 0, 0, 0);
                        foreach (var item in fontBitmap.GlyphInfoDictionary)
                        {
                            if (item.Key == ' ' || item.Key == '\t' || item.Key == '\r' || item.Key == '\n') { continue; }

                            graphics.Clear(clearColor);
                            graphics.DrawString(item.Key.ToString(), fontBitmap.GlyphFont, Brushes.White, 0, 0);
                            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                            RetargetGlyphRectangleInwards(data, item.Value);
                            bitmap.UnlockBits(data);
                        }
                    }
                }
            }
        }
    }
}
