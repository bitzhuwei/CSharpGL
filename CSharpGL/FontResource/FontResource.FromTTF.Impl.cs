using SharpFont;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Linq;

namespace CSharpGL
{
    /// <summary>
    /// 字形贴图及其UV。
    /// </summary>
    public sealed partial class FontResource
    {

        public static FontResource Load(Stream stream, IEnumerable<char> targets, int pixelSize)
        {
            InitStandardWidths();

            int count = targets.Count();
            int maxWidth = GetMaxWidth(pixelSize, count);

            var dict = new FullDictionary<char, CharacterInfo>(CharacterInfo.Default);
            Bitmap finalBitmap;
            using (var bitmap = new Bitmap(maxWidth, maxWidth, PixelFormat.Format24bppRgb))
            {
                int currentX = 0, currentY = 0;
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    var typeface = new FontFace(stream);

                    foreach (char c in targets)
                    {
                        BlitCharacter(pixelSize, maxWidth, dict, ref currentX, ref currentY, graphics, typeface, c);
                    }
                }

                finalBitmap = ShortenBitmap(bitmap, maxWidth, currentY + yInterval + pixelSize + (pixelSize / 10 > 1 ? pixelSize / 10 : 1));
            }

            var fontResource = new FontResource();
            fontResource.FontHeight = pixelSize + yInterval;
            fontResource.CharInfoDict = dict;
            fontResource.InitTexture(finalBitmap);
            finalBitmap.Dispose();
            return fontResource;
        }

        const int xInterval = 1;
        const int yInterval = 10;

        private static void BlitCharacter(int pixelSize, int maxWidth, FullDictionary<char, CharacterInfo> dict, ref int currentX, ref int currentY, Graphics g, FontFace typeface, char c)
        {
            if (c == ' ' || c == '\t')
            {
                int width = (c == ' ') ? pixelSize / 2 : pixelSize * 4;
                if (currentX + xInterval + width >= maxWidth)
                {
                    currentX = 0;
                    currentY += yInterval + pixelSize;
                    if (currentY + yInterval + pixelSize >= maxWidth)
                    { throw new Exception("Texture Size not big enough for required characters."); }
                }
                Bitmap glyphBitmap = new Bitmap(width + xInterval, pixelSize + yInterval);
                //float yoffset = pixelSize * 3 / 4 - glyph.HorizontalMetrics.Bearing.Y;
                g.DrawImage(glyphBitmap, currentX + xInterval, currentY + yInterval);
                CharacterInfo info = new CharacterInfo(currentX, currentY, width + xInterval, pixelSize + yInterval);
                dict.Add(c, info);
                glyphBitmap.Dispose();
                currentX += width;
            }
            else
            {
                Surface surface; Glyph glyph;
                if (RenderGlyph(typeface, c, pixelSize, out surface, out glyph))
                {
                    if (currentX + xInterval + surface.Width >= maxWidth)
                    {
                        currentX = 0;
                        currentY += yInterval + pixelSize;
                        if (currentY + yInterval + pixelSize >= maxWidth)
                        { throw new Exception("Texture Size not big enough for reuqired characters."); }
                    }
                    Bitmap glyphBitmap = GetGlyphBitmap(surface);
                    const int a = 5;
                    const int b = 8;
                    //float yoffset = pixelSize * a / b - glyph.HorizontalMetrics.Bearing.Y;
                    float skyHeight = yInterval + pixelSize * a / b - glyph.HorizontalMetrics.Bearing.Y;
                    if (skyHeight < 0) { skyHeight = 0; }
                    if (skyHeight < 0)
                    { skyHeight = 0; }
                    else if (skyHeight + glyphBitmap.Height > yInterval + pixelSize)
                    { skyHeight -= glyphBitmap.Height - (yInterval + pixelSize); }
#if DEBUG
                    g.DrawRectangle(redPen, currentX + xInterval, currentY + skyHeight, glyphBitmap.Width, glyphBitmap.Height);
                    g.DrawRectangle(greenPen, currentX, currentY, glyphBitmap.Width + xInterval, yInterval + pixelSize - 1);
#endif
                    g.DrawImage(glyphBitmap, currentX + xInterval, currentY + skyHeight, glyphBitmap.Width, glyphBitmap.Height);
                    CharacterInfo info = new CharacterInfo(currentX, currentY, glyphBitmap.Width + xInterval, yInterval + pixelSize - 1);
                    dict.Add(c, info);
                    glyphBitmap.Dispose();
                    currentX += xInterval + surface.Width;
                }

                surface.Dispose();
            }
        }

#if DEBUG
        static Pen redPen = new Pen(Color.Red);
        static Pen greenPen = new Pen(Color.Green);
#endif

        private static unsafe Bitmap GetGlyphBitmap(Surface surface)
        {
            if (surface.Width > 0 && surface.Height > 0)
            {
                var bitmap = new Bitmap(surface.Width, surface.Height, PixelFormat.Format24bppRgb);
                var bitmapData = bitmap.LockBits(new Rectangle(0, 0, surface.Width, surface.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                for (int y = 0; y < surface.Height; y++)
                {
                    var dest = (byte*)bitmapData.Scan0 + y * bitmapData.Stride;
                    var src = (byte*)surface.Bits + y * surface.Pitch;

                    for (int x = 0; x < surface.Width; x++)
                    {
                        var b = *src++;
                        *dest++ = b;
                        *dest++ = b;
                        *dest++ = b;
                    }
                }

                bitmap.UnlockBits(bitmapData);
                return bitmap;
            }
            else
            {
                return null;
            }
        }

        private static unsafe bool RenderGlyph(FontFace typeface, char c, int pixelSize, out Surface surface, out Glyph glyph)
        {
            bool result = false;

            glyph = typeface.GetGlyph(c, pixelSize);
            if (glyph != null)
            {
                surface = new Surface
                {
                    Bits = Marshal.AllocHGlobal(glyph.RenderWidth * glyph.RenderHeight),
                    Width = glyph.RenderWidth,
                    Height = glyph.RenderHeight,
                    Pitch = glyph.RenderWidth
                };

                var stuff = (byte*)surface.Bits;
                // todo: this is not needed?
                for (int i = 0; i < surface.Width * surface.Height; i++)
                    *stuff++ = 0;

                glyph.RenderTo(surface);

                result = true;
            }
            else
            {
                surface = new Surface();
            }

            return result;
        }

    }
}
