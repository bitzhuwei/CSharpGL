using SharpFont;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace CSharpGL
{
    public sealed partial class FontResource
    {

        private static Bitmap defaultGlyphBitmap;
        private static FullDictionary<char, GlyphInfo> defaultGlyphDict;

        private static void GetDefaultGlyphBitmap(out Bitmap glyphBitmap, out FullDictionary<char, GlyphInfo> glyphDict, out int pixelSize)
        {
            pixelSize = 64;
            if (defaultGlyphBitmap == null)
            {
                defaultGlyphDict = new FullDictionary<char, GlyphInfo>(GlyphInfo.Default);
               
                var builder = new StringBuilder();
                for (int i = 32; i < 127; i++)
                {
                    builder.Append((char)i);
                }
                using (Stream stream = ManifestResourceLoader.GetStream(@"Resources\ANTQUAI.TTF"))
                {
                    InitStandardWidths();
                    string targets = builder.ToString();
                    int maxWidth = GetMaxWidth(pixelSize, targets.Length);

                    using (var bitmap = new Bitmap(maxWidth, maxWidth, PixelFormat.Format24bppRgb))
                    {
                        int currentX = 0, currentY = 0;
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            var typeface = new FontFace(stream);

                            foreach (char c in targets)
                            {
                                BlitCharacter(pixelSize, maxWidth, defaultGlyphDict, ref currentX, ref currentY, graphics, typeface, c);
                            }
                        }

                        defaultGlyphBitmap = ShortenBitmap(bitmap, maxWidth, currentY + yInterval + pixelSize + (pixelSize / 10 > 1 ? pixelSize / 10 : 1));
                    }
                }
            }

            glyphBitmap = defaultGlyphBitmap;
            glyphDict = defaultGlyphDict;
        }
    }
}
