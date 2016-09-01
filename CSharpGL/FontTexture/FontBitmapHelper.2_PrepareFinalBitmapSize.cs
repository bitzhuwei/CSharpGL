using System;

namespace CSharpGL
{
    /// <summary>
    /// helper class.
    /// </summary>
    public static partial class FontBitmapHelper
    {
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
                int totalWidth = 0;
                foreach (GlyphInfo item in fontBitmap.GlyphInfoDictionary.Values)
                {
                    totalWidth += item.width + glyphInterval;
                    if (maxGlyphHeight < item.height) { maxGlyphHeight = item.height; }
                }
                int area = totalWidth * maxGlyphHeight;
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
                    else// new row will start.
                    {
                        if (maxWidth < currentX) { maxWidth = currentX; }
                        currentX = leftMargin;
                        currentY += maxGlyphHeight;
                        currentX += item.Value.width + glyphInterval;
                    }
                }

                // if there is no glyph
                // or if there is only 1 line of glyph.
                if (maxWidth < currentX) { maxWidth = currentX; }

                if (currentX > leftMargin)// last line is not finished.
                {
                    maxHeight = currentY + maxGlyphHeight;
                }
                else// last line is finished and new line is started and new line has no glyph.
                {
                    maxHeight = currentY;
                }

                width = maxWidth;
                height = maxHeight;
            }
        }
    }
}