using System.Drawing;

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
        private const int glyphInterval = 1;

        /// <summary>
        /// bigger maring means less mix. But 1 is enough.
        /// </summary>
        private const int leftMargin = 1;

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
    }
}