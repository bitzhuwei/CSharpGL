using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;

namespace CSharpGL.NewFontResource
{
    class FontBitmapBuilder
    {
        private System.Drawing.Font font;
        private FontBitmapConfiguration config;

        public FontBitmapBuilder(System.Drawing.Font font, FontBitmapConfiguration config)
        {
            // TODO: Complete member initialization
            this.font = font;
            this.config = config;
        }

        public FontBitmap Build(System.Drawing.Font font, FontBitmapConfiguration config)
        {
            if (config.ForcePowerOfTwo && config.SuperSampleLevels != PowerOfTwo(config.SuperSampleLevels))
                throw new ArgumentOutOfRangeException("SuperSampleLevels must be a power of two when using ForcePowerOfTwo.");
            if (config.SuperSampleLevels <= 0 || config.SuperSampleLevels > 8)
                throw new ArgumentOutOfRangeException("SuperSampleLevels = [" + config.SuperSampleLevels + "] is an unsupported value. Please use values in the range [1,8]");

            int margin = 2; // margin in initial bitmap (don't bother to make configurable - likely to cause confusion
            int pageWidth = config.PageWidth * config.SuperSampleLevels;
            int pageHeight = config.PageHeight * config.SuperSampleLevels;
            bool usePowerOfTwo = config.ForcePowerOfTwo;
            int glyphMargin = config.GlyphMargin * config.SuperSampleLevels;

            List<SizeF> sizes = GetGlyphSizes(font);
            SizeF maxSize = GetMaxGlyphSize(sizes);
            GlyphInfo[] initialGlyphs;
            Bitmap initialBmp = CreateInitialBitmap(font, maxSize, margin, out initialGlyphs);
            initialBmp.Save("initialBmp0.bmp");
            BitmapData initialBitmapData = initialBmp.LockBits(new Rectangle(0, 0, initialBmp.Width, initialBmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            var minYOffset = int.MaxValue;
            foreach (GLFontGlyph glyph in initialGlyphs)
            {
                RetargetGlyphRectangleInwards(initialBitmapData, glyph, true, config.KerningConfig.AlphaEmptyPixelTolerance);
                minYOffset = Math.Min(minYOffset, glyph.YOffset);
            }
            minYOffset--; // give one pixel of breathing room?
            initialBmp.Save("initialBmp1.bmp");

            foreach (var glyph in initialGlyphs)
                glyph.YOffset -= minYOffset;

            GLFontGlyph[] glyphs;
            List<GLFontBitmap> bitmapPages = GenerateBitmapSheetsAndRepack(initialGlyphs, new BitmapData[1] { initialBitmapData }, pageWidth, pageHeight, out glyphs, glyphMargin, usePowerOfTwo);
            int index = 0;
            foreach (GLFontBitmap item in bitmapPages)
            {
                item.bitmap.Save(string.Format("bitmapPages{0}.bmp", index++));
            }
            initialBmp.UnlockBits(initialBitmapData);
            initialBmp.Save("initialBmp2.bmp");
            initialBmp.Dispose();

            if (config.SuperSampleLevels != 1)
            {
                ScaleSheetsAndGlyphs(bitmapPages, glyphs, 1.0f / config.SuperSampleLevels);
                RetargetAllGlyphs(bitmapPages, glyphs, config.KerningConfig.AlphaEmptyPixelTolerance);
                index = 0;
                foreach (GLFontBitmap item in bitmapPages)
                {
                    item.bitmap.Save(string.Format("bitmapPages.2.{0}.bmp", index++));
                }
            }

            //create list of texture pages
            var texturePages = new List<GLFontTexture>();
            foreach (var page in bitmapPages)
                texturePages.Add(new GLFontTexture(page.bitmapData));

            var fontData = new GLFontData();
            fontData.CharSetMapping = glyphs.ToDictionary(g => g.Character);
            fontData.TexturePages = texturePages.ToArray();
            fontData.CalculateMeanWidth();
            fontData.CalculateMaxHeight();
            fontData.KerningPairs = GLFontKerningCalculator.CalculateKerning(charSet.ToCharArray(), glyphs, bitmapPages, config.KerningConfig);
            fontData.naturallyMonospaced = IsMonospaced(sizes);

            foreach (var glyph in glyphs)
            {
                var page = texturePages[glyph.Page];
                glyph.TextureMin = new PointF((float)glyph.Rect.X / page.Width, (float)glyph.Rect.Y / page.Height);
                glyph.TextureMax = new PointF((float)glyph.Rect.Right / page.Width, (float)glyph.Rect.Bottom / page.Height);
            }

            foreach (var page in bitmapPages)
                page.Free();

            //validate glyphs
            var intercept = FirstIntercept(fontData.CharSetMapping);
            if (intercept != null)
                throw new Exception("Failed to create glyph set. Glyphs '" + intercept[0] + "' and '" + intercept[1] + "' were overlapping. This is could be due to an error in the font, or a bug in Graphics.MeasureString().");

            return fontData;
        }
        private delegate bool EmptyDel(BitmapData data, int x, int y);

        /// <summary>
        /// The initial bitmap is simply a long thin strip of all glyphs in a row
        /// </summary>
        /// <param name="font"></param>
        /// <param name="maxSize"></param>
        /// <param name="initialMargin"></param>
        /// <param name="glyphs"></param>
        /// <param name="renderHint"></param>
        /// <returns></returns>
        private Bitmap CreateInitialBitmap(Font font, SizeF maxSize, int initialMargin, out GlyphInfo[] glyphs)
        {
            glyphs = new GlyphInfo[config.CharSet.Length];

            int spacing = (int)Math.Ceiling(maxSize.Width) + 2 * initialMargin;
            Bitmap bmp = new Bitmap(spacing * config.CharSet.Length, (int)Math.Ceiling(maxSize.Height) + 2 * initialMargin + 1, PixelFormat.Format24bppRgb);
            Graphics graph = Graphics.FromImage(bmp);

            graph.TextRenderingHint = font.Size <= 12.0f ? TextRenderingHint.ClearTypeGridFit : TextRenderingHint.AntiAlias;

            int xOffset = initialMargin;
            for (int i = 0; i < config.CharSet.Length; i++)
            {
                graph.DrawString("" + config.CharSet[i], font, Brushes.White, xOffset, initialMargin);
                var charSize = graph.MeasureString("" + config.CharSet[i], font);
                glyphs[i] = new GlyphInfo(0, new Rectangle(xOffset - initialMargin, 0, (int)charSize.Width + initialMargin * 2, (int)charSize.Height + initialMargin * 2), 0, config.CharSet[i]);
                xOffset += (int)charSize.Width + initialMargin * 2;
            }

            graph.Flush();
            graph.Dispose();

            return bmp;
        }
        private List<SizeF> GetGlyphSizes(Font font)
        {
            Bitmap bmp = new Bitmap(512, 512, PixelFormat.Format24bppRgb);
            Graphics graph = Graphics.FromImage(bmp);
            List<SizeF> sizes = new List<SizeF>();

            for (int i = 0; i < charSet.Length; i++)
            {
                var charSize = graph.MeasureString("" + charSet[i], font);
                sizes.Add(new SizeF(charSize.Width, charSize.Height));
            }

            graph.Dispose();
            bmp.Dispose();

            return sizes;
        }

        private SizeF GetMaxGlyphSize(List<SizeF> sizes)
        {
            SizeF maxSize = new SizeF(0f, 0f);
            for (int i = 0; i < charSet.Length; i++)
            {
                if (sizes[i].Width > maxSize.Width)
                    maxSize.Width = sizes[i].Width;

                if (sizes[i].Height > maxSize.Height)
                    maxSize.Height = sizes[i].Height;
            }

            return maxSize;
        }

        private SizeF GetMinGlyphSize(List<SizeF> sizes)
        {
            SizeF minSize = new SizeF(float.MaxValue, float.MaxValue);
            for (int i = 0; i < charSet.Length; i++)
            {
                if (sizes[i].Width < minSize.Width)
                    minSize.Width = sizes[i].Width;

                if (sizes[i].Height < minSize.Height)
                    minSize.Height = sizes[i].Height;
            }

            return minSize;
        }

        private bool IsMonospaced(List<SizeF> sizes)
        {
            var min = GetMinGlyphSize(sizes);
            var max = GetMaxGlyphSize(sizes);
            if (max.Width - min.Width < max.Width * 0.05f)
                return true;
            return false;
        }

        private static void ScaleSheetsAndGlyphs(List<GLFontBitmap> pages, GLFontGlyph[] glyphs, float scale)
        {
            foreach (var page in pages)
                page.DownScale32((int)(page.bitmap.Width * scale), (int)(page.bitmap.Height * scale));

            foreach (var glyph in glyphs)
            {
                glyph.Rect = new Rectangle((int)(glyph.Rect.X * scale), (int)(glyph.Rect.Y * scale), (int)(glyph.Rect.Width * scale), (int)(glyph.Rect.Height * scale));
                glyph.YOffset = (int)(glyph.YOffset * scale);
            }
        }

        private static void RetargetAllGlyphs(List<GLFontBitmap> pages, GLFontGlyph[] glyphs, byte alphaTolerance)
        {
            foreach (var glyph in glyphs)
                RetargetGlyphRectangleOutwards(pages[glyph.Page].bitmapData, glyph, false, alphaTolerance);
        }

        public static void CreateBitmapPerGlyph(GLFontGlyph[] sourceGlyphs, GLFontBitmap[] sourceBitmaps, out GLFontGlyph[] destGlyphs, out GLFontBitmap[] destBitmaps)
        {
            destBitmaps = new GLFontBitmap[sourceGlyphs.Length];
            destGlyphs = new GLFontGlyph[sourceGlyphs.Length];
            for (int i = 0; i < sourceGlyphs.Length; i++)
            {
                var sg = sourceGlyphs[i];
                destGlyphs[i] = new GLFontGlyph(i, new Rectangle(0, 0, sg.Rect.Width, sg.Rect.Height), sg.YOffset, sg.Character);
                destBitmaps[i] = new GLFontBitmap(new Bitmap(sg.Rect.Width, sg.Rect.Height, PixelFormat.Format32bppArgb));
                GLFontBitmap.Blit(sourceBitmaps[sg.Page].bitmapData, destBitmaps[i].bitmapData, sg.Rect, 0, 0);
            }
        }

        private static char[] FirstIntercept(Dictionary<char, GLFontGlyph> charSet)
        {
            char[] keys = charSet.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
                for (int j = i + 1; j < keys.Length; j++)
                    if (charSet[keys[i]].Page == charSet[keys[j]].Page && charSet[keys[i]].Rect.IntersectsWith(charSet[keys[j]].Rect))
                        return new char[2] { keys[i], keys[j] };
            return null;
        }

        /// <summary>
        /// Returns the power of 2 that is closest to x, but not smaller than x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static int PowerOfTwo(int x)
        {
            if (x < 0) { return 0; }

            int shifts = 0;
            uint val = (uint)x;

            while (val > 0)
            {
                val = val >> 1;
                shifts++;
            }

            val = (uint)1 << (shifts - 1);
            if (val < x)
            {
                val = val << 1;
            }

            return (int)val;
        }
    }
}
