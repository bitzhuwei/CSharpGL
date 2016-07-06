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

        private static void GetGlyphInfo(out Bitmap glyphBitmap, out FullDictionary<char, GlyphInfo> glyphDict, int pixelSize, string targets)
        {
            defaultGlyphDict = new FullDictionary<char, GlyphInfo>(GlyphInfo.Default);

            using (Stream stream = ManifestResourceLoader.GetStream(@"Resources\ANTQUAI.TTF"))
            {
                InitStandardWidths();
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

            glyphBitmap = defaultGlyphBitmap;
            glyphDict = defaultGlyphDict;
        }
    }
}
