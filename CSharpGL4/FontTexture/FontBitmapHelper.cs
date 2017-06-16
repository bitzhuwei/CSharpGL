using System;
using System.Drawing;

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
        private const int glyphInterval = 1;

        /// <summary>
        /// bigger maring means less mix. But 1 is enough.
        /// </summary>
        private const int leftMargin = 1;

        /// <summary>
        /// Gets a <see cref="FontBitmap"/>'s intance.
        /// </summary>
        /// <param name="font">建议最大字体不超过32像素高度，否则可能无法承载所有Unicode字符。</param>
        /// <param name="charSet"></param>
        /// <param name="drawBoundary"></param>
        /// <returns></returns>
        public static FontBitmap GetFontBitmap(this Font font, string charSet, bool drawBoundary = false)
        {
            var fontBitmap = new FontBitmap();
            fontBitmap.GlyphFont = font; //fontBitmap.GlyphInfoDictionary //fontBitmap.GlyphHeight //fontBitmap.GlyphBitmap
            // 先获取各个glyph的width和height
            fontBitmap.GlyphInfoDictionary = GetGlyphDict(font, charSet);
            // 获取所有glyph的面积之和，开方得到最终贴图的宽度textureWidth
            int textureWidth = GetTextureWidth(fontBitmap.GlyphInfoDictionary);
            // 以所有glyph中height最大的为标准高度
            fontBitmap.GlyphHeight = GetGlyphHeight(fontBitmap.GlyphInfoDictionary, textureWidth);
            // 摆放glyph，得到x偏移和y偏移量，同时顺便得到最终贴图的高度textureHeight
            int textureHeight = LayoutGlyphs(fontBitmap.GlyphInfoDictionary, textureWidth, fontBitmap.GlyphHeight);
            // 根据glyph的摆放位置，生成最终的贴图
            fontBitmap.GlyphBitmap = PaintTexture(textureWidth, textureHeight, fontBitmap.GlyphInfoDictionary, font);

            if (drawBoundary)
            {
                using (var graphics = Graphics.FromImage(fontBitmap.GlyphBitmap))
                {
                    bool odd = false;
                    foreach (GlyphInfo item in fontBitmap.GlyphInfoDictionary.Values)
                    {
                        graphics.DrawRectangle(
                            odd ? Pens.Green : Pens.Blue,
                            item.ToRectangle(1, 1, -2, -1));
                        odd = !odd;
                    }
                    graphics.DrawRectangle(Pens.Red, 0, 0, fontBitmap.GlyphBitmap.Width - 1, fontBitmap.GlyphBitmap.Height - 1);
                }
            }
            //fontBitmap.GlyphBitmap.Save("aaaaaaaaaaaaa.png");
            return fontBitmap;
        }


        private static Bitmap PaintTexture(int textureWidth, int textureHeight, FullDictionary<char, GlyphInfo> fullDictionary, Font font)
        {
            var bitmap = new Bitmap(textureWidth, textureHeight);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                foreach (var item in fullDictionary)
                {
                    Size oneSize = graphics.MeasureString(string.Format("{0}", item.Key), font).ToSize();

                    using (var oneBitmap = new Bitmap(oneSize.Width, oneSize.Height))
                    {
                        using (var oneGrphics = Graphics.FromImage(oneBitmap))
                        { oneGrphics.DrawString(string.Format("{0}", item.Key), font, Brushes.Red, 0, 0); }

                        graphics.DrawImage(oneBitmap,
                            item.Value.ToRectangle(),
                            new Rectangle((oneSize.Width - item.Value.width) / 2, 0, item.Value.width, item.Value.height),
                            GraphicsUnit.Pixel);
                    }
                }
            }

            return bitmap;
        }

        private static int LayoutGlyphs(FullDictionary<char, GlyphInfo> fullDictionary, int textureWidth, int glyphHeight)
        {
            int cursorX = 0, cursorY = 0;
            foreach (var item in fullDictionary)
            {
                int width = item.Value.width;
                int height = item.Value.height;
                if (cursorX + width > textureWidth)
                {
                    cursorX = 0;
                    cursorY += glyphHeight;
                }

                item.Value.xoffset = cursorX;
                item.Value.yoffset = cursorY;

                cursorX += width;
            }

            return cursorY + glyphHeight;
        }

        private static int GetGlyphHeight(FullDictionary<char, GlyphInfo> fullDictionary, int textureWidth)
        {
            int glyphHeight = 0;
            foreach (var item in fullDictionary)
            {
                int height = item.Value.height;
                if (glyphHeight < height) { glyphHeight = height; }
            }

            return glyphHeight;
        }

        private static int GetTextureWidth(FullDictionary<char, GlyphInfo> fullDictionary)
        {
            int totalAera = 0;
            foreach (var item in fullDictionary)
            {
                int area = item.Value.width * item.Value.height;
                totalAera += area;
            }

            return (int)Math.Sqrt(totalAera);
        }

        private static FullDictionary<char, GlyphInfo> GetGlyphDict(Font font, string charSet)
        {
            var dict = new FullDictionary<char, GlyphInfo>(GlyphInfo.Default);
            using (var bmp = new Bitmap(1, 1))
            {
                using (var graphics = Graphics.FromImage(bmp))
                {
                    foreach (var c in charSet)
                    {
                        Size oneSize = graphics.MeasureString(string.Format("{0}", c), font).ToSize();
                        Size doubleSize = graphics.MeasureString(string.Format("{0}{0}", c), font).ToSize();

                        // TODO: Log this.
                        if (oneSize.Height != doubleSize.Height) { continue; }
                        if (oneSize.Width >= doubleSize.Width) { continue; }

                        Size charSize = new Size(doubleSize.Width - oneSize.Width, oneSize.Height);
                        var info = new GlyphInfo(0, 0, charSize.Width, charSize.Height);
                        dict.Add(c, info);
                    }
                }
            }

            return dict;
        }

    }
}