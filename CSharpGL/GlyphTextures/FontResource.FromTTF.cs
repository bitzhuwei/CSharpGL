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
    /// 含有字形贴图及其配置信息的单例类型。
    /// </summary>
    public sealed partial class FontResource
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ttfFilename"></param>
        /// <param name="pixelSize">The desired size of the font, in pixels.</param>
        /// <returns></returns>
        public static FontResource Load(string ttfFilename,
            char firstChar, char lastChar, int pixelSize = 32)
        {
            FontResource result;
            Load(ttfFilename, firstChar, lastChar, pixelSize, out result);
            return result;
        }

        static int[] standardWidths;
        private static void Load(string ttfFilename, char firstChar, char lastChar, int pixelSize, out FontResource fontResource)
        {
            if (standardWidths == null)
            {
                int[] maxTextureSize = new int[1];
                OpenGL.GetInteger(GetTarget.MaxTextureSize, maxTextureSize);
                int i = 2;
                List<int> widths = new List<int>();
                while (Math.Pow(2, i) <= maxTextureSize[0])
                {
                    widths.Add((int)Math.Pow(2, i));
                    i++;
                }
                standardWidths = widths.ToArray();
            }

            int count = lastChar - firstChar + 1;
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

            fontResource = new FontResource();
            fontResource.FontHeight = pixelSize;
            var dict = new FullDictionary<char, CharacterInfo>(CharacterInfo.Default);
            fontResource.CharInfoDict = dict;
            var bitmap = new Bitmap(maxWidth, maxWidth, PixelFormat.Format24bppRgb);
            int currentX = 0, currentY = 0;
            Graphics g = Graphics.FromImage(bitmap);
            /*
            this.FontHeight = int.Parse(config.Attribute(strFontHeight).Value);
            this.CharInfoDict = CharacterInfoDictHelper.Parse(
                config.Element(CharacterInfoDictHelper.strCharacterInfoDict));
             */
            using (var file = File.OpenRead(ttfFilename))
            {
                var typeface = new FontFace(file);

                for (char c = firstChar; c <= lastChar; c++)
                {
                    //Console.WriteLine("Dump {0}: {1}", (int)c, c);
                    //var comparisonFile = Path.Combine(ComparisonPath, (int)c + ".png");
                    Surface surface; Glyph glyph;
                    if (RenderGlyph(typeface, c, pixelSize, out surface, out glyph))
                    {
                        if (currentX + surface.Width > maxWidth)
                        {
                            currentX = 0;
                            currentY += pixelSize;
                            if (currentY + pixelSize >= maxWidth)
                            { throw new Exception("Texture Size not big enough for reuqired characters."); }
                        }
                        Bitmap glyphBitmap = GetGlyphBitmap(surface);
                        g.DrawImage(glyphBitmap, currentX, currentY);
                        CharacterInfo info = new CharacterInfo(currentX, currentY, surface.Width, surface.Height);
                        dict.Add(c, info);
                        glyphBitmap.Dispose();
                        currentX += surface.Width;
                        //SaveSurface(surface, comparisonFile);
                        surface.Dispose();
                    }
                }
            }
            g.Dispose();
            fontResource.InitTexture(bitmap);
            bitmap.Dispose();


            throw new NotImplementedException();
        }


        static unsafe Bitmap GetGlyphBitmap(Surface surface)
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
