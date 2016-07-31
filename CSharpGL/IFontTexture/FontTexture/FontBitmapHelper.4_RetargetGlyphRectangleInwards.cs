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
        /// Returns true if the given pixel is empty (i.e. black)
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

    }
}
