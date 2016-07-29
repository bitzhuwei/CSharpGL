using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class FontResourceBuilder
    {
        private System.Drawing.Font font;
        private char[] content;
        private static int[] standardWidths;
        private const float yInterval = 2;

        public FontResourceBuilder(System.Drawing.Font font, char[] content)
        {
            // TODO: Complete member initialization
            this.font = font;
            this.content = content;
        }


        public FontResource BuildFontData()
        {
            InitStandardWidths();

            int count = this.content.Length;
            float maxWidth = GetMaxWidth(this.font.Size, count);

            Bitmap finalBitmap;
            FullDictionary<char, GlyphInfo> dict;
            GetGlyphInfo(out finalBitmap, out dict, this.font.Size, this.content);

            var fontResource = new FontResource();
            fontResource.FontHeight = this.font.Size + yInterval;
            fontResource.CharInfoDict = dict;
            fontResource.InitTexture(finalBitmap);
            finalBitmap.Dispose();
            return fontResource;
        }

        private static void GetGlyphInfo(out Bitmap glyphBitmap, out FullDictionary<char, GlyphInfo> glyphDict, float pixelSize, IEnumerable<char> targets)
        {
            glyphDict = new FullDictionary<char, GlyphInfo>(GlyphInfo.Default);

            using (Stream stream = ManifestResourceLoader.GetStream(@"Resources\ANTQUAI.TTF"))
            {
                InitStandardWidths();
                int maxWidth = GetMaxWidth(pixelSize, targets.Count());

                using (var bitmap = new Bitmap(maxWidth, maxWidth, PixelFormat.Format24bppRgb))
                {
                    int currentX = 0, currentY = 0;
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        var typeface = new FontFace(stream);

                        foreach (char c in targets)
                        {
                            BlitCharacter(pixelSize, maxWidth, glyphDict, ref currentX, ref currentY, graphics, typeface, c);
                        }
                    }

                    glyphBitmap = ShortenBitmap(bitmap, maxWidth, currentY + yInterval + pixelSize + (pixelSize / 10 > 1 ? pixelSize / 10 : 1));
                }
            }

        }
        private static float GetMaxWidth(float pixelSize, int count)
        {
            if (count < 1) { throw new ArgumentException(); }
            int maxWidth = (int)(Math.Sqrt(count) * pixelSize);
            if (maxWidth < pixelSize)
            {
                maxWidth = pixelSize;
            }
            for (int i = 0; i < standardWidths.Length; i++)
            {
                if (maxWidth <= standardWidths[i])
                {
                    maxWidth = standardWidths[i];
                    break;
                }
            }
            return maxWidth;
        }
        private static void InitStandardWidths()
        {
            if (standardWidths == null)
            {
                var maxTextureSize = new int[1];
                OpenGL.GetInteger(GetTarget.MaxTextureSize, maxTextureSize);
                if (maxTextureSize[0] == 0) { maxTextureSize[0] = (int)Math.Pow(2, 14); }
                int i = 2;
                var widths = new List<int>();
                while (Math.Pow(2, i) <= maxTextureSize[0])
                {
                    widths.Add((int)Math.Pow(2, i));
                    i++;
                }
                standardWidths = widths.ToArray();
            }
        }

    }
}
