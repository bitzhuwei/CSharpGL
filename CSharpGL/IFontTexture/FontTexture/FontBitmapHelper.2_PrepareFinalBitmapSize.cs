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
    }
}
