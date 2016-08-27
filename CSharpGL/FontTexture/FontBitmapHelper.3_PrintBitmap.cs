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

    }
}
