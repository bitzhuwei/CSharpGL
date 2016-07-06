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

            Bitmap finalBitmap;
            FullDictionary<char, GlyphInfo> dict;
            GetGlyphInfo(out finalBitmap, out dict, pixelSize, targets);

            var fontResource = new FontResource();
            fontResource.FontHeight = pixelSize + yInterval;
            fontResource.CharInfoDict = dict;
            fontResource.InitTexture(finalBitmap);
            finalBitmap.Dispose();
            return fontResource;
        }


        private static void BlitCharacter(int pixelSize, int maxWidth, FullDictionary<char, GlyphInfo> dict, ref int currentX, ref int currentY, Graphics graphics, FontFace typeface, char c)
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
                graphics.DrawImage(glyphBitmap, currentX + xInterval, currentY + yInterval);
                var info = new GlyphInfo(currentX, currentY, width + xInterval, pixelSize + yInterval);
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
                        { throw new Exception("Texture Size not big enough for required characters."); }
                    }
                    Bitmap glyphBitmap = GetGlyphBitmap(surface);
                    const int a = 5;
                    const int b = 8;
                    //float yoffset = pixelSize * a / b - glyph.HorizontalMetrics.Bearing.Y;
                    float skyHeight = yInterval + pixelSize * a / b - glyph.HorizontalMetrics.Bearing.y;
                    if (skyHeight < 0) { skyHeight = 0; }
                    else if (skyHeight + glyphBitmap.Height > yInterval + pixelSize)
                    { skyHeight -= glyphBitmap.Height - (yInterval + pixelSize); }
                    graphics.DrawImage(glyphBitmap, currentX + xInterval, currentY + skyHeight, glyphBitmap.Width, glyphBitmap.Height);
//#if DEBUG
//                    graphics.DrawRectangle(greenPen, currentX, currentY, glyphBitmap.Width + xInterval, yInterval + pixelSize - 1);
//                    graphics.DrawRectangle(redPen, currentX + xInterval, currentY + skyHeight, glyphBitmap.Width, glyphBitmap.Height);
//                    graphics.DrawLine(bluePen, currentX, currentY + yInterval + pixelSize * a / b,
//                        currentX + glyphBitmap.Width, currentY + yInterval + pixelSize * a / b);
//#endif
                    var info = new GlyphInfo(currentX, currentY, glyphBitmap.Width + xInterval, yInterval + pixelSize - 1);
                    dict.Add(c, info);
                    glyphBitmap.Dispose();
                    currentX += xInterval + surface.Width;
                }

                surface.Dispose();
            }
        }

        const int xInterval = 1;
        const int yInterval = 10;

//#if DEBUG
//        static Pen redPen = new Pen(Color.Red);
//        static Pen greenPen = new Pen(Color.Green);
//        static Pen bluePen = new Pen(Color.Blue);
//#endif
    }
}
