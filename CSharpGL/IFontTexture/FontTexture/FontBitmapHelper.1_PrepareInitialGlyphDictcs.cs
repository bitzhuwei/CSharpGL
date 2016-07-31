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
