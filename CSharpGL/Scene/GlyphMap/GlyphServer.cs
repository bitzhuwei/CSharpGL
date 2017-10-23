using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Provides glyph information according to specified char.
    /// </summary>
    public class GlyphServer
    {
        private Dictionary<char, GlyphInfo> dictionary = new Dictionary<char, GlyphInfo>();

        private GlyphServer() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="font"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static GlyphServer Create(Font font, IEnumerable<char> charset)
        {
            var server = new GlyphServer();
            if (charset == null || charset.Count() == 0) { return server; }

            SizeF[] sizes = GetAllCharSizes(font, charset);
            float width = GetWidthSum(sizes);
            float height = sizes[0].Height;
            var bitmap = new Bitmap((int)width, (int)height);
            Draw(charset, sizes, bitmap, font);
            Texture texture = GenetateTexture(bitmap);
            FillDictionary(charset, sizes, server.dictionary, texture);

            return server;
        }


        private static void FillDictionary(IEnumerable<char> charset, SizeF[] sizes, Dictionary<char, GlyphInfo> dictionary, Texture texture)
        {
            int index = 0;
            float currentWidth = 0;
            foreach (var item in charset)
            {
                SizeF size = sizes[index++];
                float x0 = currentWidth, x1 = currentWidth + size.Width;
                float y0 = 0;
                float y1 = size.Height;
                var glyphInfo = new GlyphInfo(item, new vec2(x0, y0), new vec2(x0, y1), new vec2(x1, y1), new vec2(x1, y0), texture);
                dictionary.Add(item, glyphInfo);
                currentWidth += size.Width;
            }
        }

        private static Texture GenetateTexture(Bitmap bitmap)
        {
            var texture = new Texture(TextureTarget.Texture2D,
                new TexImage2D(TexImage2D.Target.Texture2D, 0, GL.GL_RGBA, bitmap.Width, bitmap.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, new ImageDataProvider(bitmap)));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

            texture.Initialize();

            return texture;
        }

        private static void Draw(IEnumerable<char> charset, SizeF[] sizes, Bitmap bitmap, Font font)
        {
            using (var graphics = Graphics.FromImage(bitmap))
            {
                int index = 0;
                float currentWidth = 0;
                foreach (var item in charset)
                {
                    string str = string.Format("|{0}|", item);
                    SizeF bigSize = graphics.MeasureString(str, font);
                    var singleCharBitmap = new Bitmap((int)bigSize.Width, (int)bigSize.Height);
                    using (var g = Graphics.FromImage(singleCharBitmap))
                    { g.DrawString(str, font, Brushes.Black, 0, 0); }
                    SizeF size = sizes[index++];
                    graphics.DrawImage(singleCharBitmap,
                        new RectangleF(
                            currentWidth,
                            0,
                            size.Width,
                            size.Height),
                        new RectangleF(
                            (bigSize.Width - size.Width) / 2,
                            0,
                            size.Width,
                            size.Height
                            ),
                        GraphicsUnit.Pixel);
                    // for debug purpose only
                    graphics.DrawRectangle(Pens.Red,
                        currentWidth, 0, size.Width, size.Height);

                    currentWidth += size.Width;
                }
            }
            // for debug purpose only
            bitmap.Save("GlyphServer.png");
        }

        private static float GetWidthSum(SizeF[] sizes)
        {
            float result = 0;
            foreach (var item in sizes)
            {
                result += item.Width;
            }

            return result;
        }

        private static SizeF[] GetAllCharSizes(Font font, IEnumerable<char> charset)
        {
            int count = charset.Count();
            var result = new SizeF[count];
            int index = 0;
            var bmp = new Bitmap(1, 1);
            var graphics = Graphics.FromImage(bmp);
            graphics.PageUnit = font.Unit;
            var boundSize = graphics.MeasureString("||", font);
            foreach (var item in charset)
            {
                SizeF bigSize = graphics.MeasureString(string.Format("|{0}|", item), font);
                float width = bigSize.Width - boundSize.Width;
                float height = bigSize.Height;
                result[index++] = new SizeF(width, height);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public bool GetGlyphInfo(char character, out GlyphInfo result)
        {
            return this.dictionary.TryGetValue(character, out result);
        }
    }

    public static class _GlyphServerHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="font"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static GlyphServer CreateGlyphServer(this Font font, IEnumerable<char> charset)
        {
            return GlyphServer.Create(font, charset);
        }
    }
}
