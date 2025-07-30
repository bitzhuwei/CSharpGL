using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// Provides glyph information according to specified character(s).
    /// </summary>
    public partial class GlyphServer {
        private readonly Dictionary<string, GlyphInfo> dictionary;
        /// <summary>
        /// A GL_TEXTURE_2D_ARRAY texture that stores all glyphs in one or multiple layers.
        /// </summary>
        public readonly Texture glyphTexture;
        /// <summary>
        /// <see cref="glyphTexture"/>'s width.
        /// </summary>
        public readonly int textureWidth;
        /// <summary>
        /// <see cref="glyphTexture"/>'s height.
        /// </summary>
        public readonly int textureHeight;

        private GlyphServer() {
            this.dictionary = new Dictionary<string, GlyphInfo>();
            this.glyphTexture = default1x1;
            this.textureWidth = 0;
            this.textureHeight = 0;
        }
        private GlyphServer(Dictionary<string, GlyphInfo> dictionary, Texture glyphTexture, int textureWidth, int textureHeight) {
            this.dictionary = dictionary;
            this.glyphTexture = glyphTexture;
            this.textureWidth = textureWidth;
            this.textureHeight = textureHeight;
        }

        /// <summary>
        /// for each render context, there's a default glyph server.
        /// </summary>
        private static readonly Dictionary<GL, GlyphServer> defaultServerDict = new();
        private static readonly object synObj = new object();
        /// <summary>
        /// default server only provides visible ASCII code.
        /// </summary>
        public unsafe static GlyphServer DefaultServer {
            get {
                var gl = GL.current; if (gl == null) { throw new Exception("Render context not exists!"); }
                //IntPtr context = GLRenderContext. gl.glGetCurrentContext();
                //if (context == null) { throw new Exception("Render context not exists!"); }

                var dict = GlyphServer.defaultServerDict;
                if (!dict.TryGetValue(gl, out var server)) {
                    lock (synObj) // the process of creating a glyph serve may take a long time(several seconds), so we need a lock.
                    {
                        if (!dict.TryGetValue(gl, out server)) {
                            var builder = new StringBuilder();
                            // ascii
                            for (char c = ' '; c <= '~'; c++) {
                                builder.Append(c);
                            }
                            //// Chinese characters
                            //for (char c = (char)0x4E00; c <= 0x9FA5; c++)
                            //{
                            //    builder.Append(c);
                            //}
                            //for (char c = (char)0; c < char.MaxValue; c++)
                            //{
                            //    builder.Append(c);
                            //}
                            string charSet = builder.ToString();
                            var font = new System.Drawing.Font("Arial", 64, GraphicsUnit.Pixel);
                            server = GlyphServer.Create(font, charSet, 1024, 1024, 1000);
                            font.Dispose();
                            dict.Add(gl, server);
                        }
                    }
                }

                return server;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="font"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static GlyphServer Create(Font font, IEnumerable<char> charset) {
            int maxTextureSize = GetMaxTextureSize();
            return Create(font, charset, maxTextureSize, maxTextureSize, 100);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="font"></param>
        /// <param name="charset"></param>
        /// <param name="maxTextureWidth"></param>
        /// <param name="maxTextureHeight"></param>
        /// <param name="maxTextureCount"></param>
        /// <returns></returns>
        public static GlyphServer Create(Font font, IEnumerable<char> charset, int maxTextureWidth, int maxTextureHeight, int maxTextureCount) {
            if (charset == null || charset.Count() == 0) { return new GlyphServer(); }

            List<ChunkBase> chunkList = GetChunkList(font, charset);
            return Create(chunkList, maxTextureWidth, maxTextureHeight, maxTextureCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="font"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static GlyphServer Create(Font font, IEnumerable<string> charset) {
            int maxTextureSize = GetMaxTextureSize();
            return Create(font, charset, maxTextureSize, maxTextureSize, 100);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="font"></param>
        /// <param name="charset"></param>
        /// <param name="maxTextureWidth"></param>
        /// <param name="maxTextureHeight"></param>
        /// <param name="maxTextureCount"></param>
        /// <returns></returns>
        public static GlyphServer Create(Font font, IEnumerable<string> charset, int maxTextureWidth, int maxTextureHeight, int maxTextureCount) {
            if (charset == null || charset.Count() == 0) { return new GlyphServer(); }

            List<ChunkBase> chunkList = GetChunkList(font, charset);
            return Create(chunkList, maxTextureWidth, maxTextureHeight, maxTextureCount);
        }

        private static GlyphServer Create(List<ChunkBase> chunkList, int maxTextureWidth, int maxTextureHeight, int maxTextureCount) {
            var context = new PagesContext(maxTextureWidth, maxTextureHeight, maxTextureCount);
            foreach (var item in chunkList) {
                item.Put(context);
            }

            GLBitmap[] bitmaps = GenerateBitmaps(chunkList, context.PageList.Count);
            PrintChunks(chunkList, context, bitmaps);

            Dictionary<string, GlyphInfo> dictionary = GetDictionary(chunkList, bitmaps[0].width, bitmaps[0].height);

            Texture texture = GenerateTexture(bitmaps);

            var server = new GlyphServer(dictionary, texture, bitmaps[0].width, bitmaps[0].height);

            //// test: save bitmaps to disk.
            //Test(server.dictionary, bitmaps);

            foreach (var item in bitmaps) {
                if (item is IDisposable disp) { disp.Dispose(); }
            }

            return server;
        }

        /// <summary>
        /// save bitmaps to disk.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="bitmaps"></param>
        private static void Test(Dictionary<string, GlyphInfo> dictionary, Bitmap[] bitmaps) {
            //var graphicses = new Graphics[bitmaps.Length];
            foreach (var item in dictionary) {
                GlyphInfo info = item.Value;
                QuadSTRStruct quad = info.quad;
                int index = (int)Math.Floor(quad.leftTop.z);

                float x0 = quad.leftTop.x * bitmaps[index].Width;
                float x1 = quad.rightTop.x * bitmaps[index].Width;
                float y0 = quad.leftTop.y * bitmaps[index].Height;
                float y1 = quad.leftBottom.y * bitmaps[index].Height;
                using (var graphics = Graphics.FromImage(bitmaps[index])) {
                    graphics.DrawRectangle(index == 0 ? Pens.Red : Pens.Green, x0, y0, x1 - x0, y1 - y0);
                }
            }

            for (int i = 0; i < bitmaps.Length; i++) {
                bitmaps[i].Save(string.Format("{0}.png", i));
            }

            //using (var sw = new System.IO.StreamWriter("defaultGlyphServer.txt"))
            //{
            //    foreach (var item in dictionary)
            //    {
            //        string line = string.Empty;
            //        try
            //        {
            //            line = item.Value.ToString();
            //            sw.WriteLine(line);
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex);
            //            //line = string.Format("glyph:[??], quad:[{0}]", item.Value.quad);
            //        }
            //    }
            //}
        }

        private static Dictionary<string, GlyphInfo> GetDictionary(List<ChunkBase> chunkList, int pageWidth, int pageHeight) {
            var dictionary = new Dictionary<string, GlyphInfo>();
            foreach (var chunk in chunkList) {
                string characters = chunk.text;
                float x0 = chunk.leftTop.X; float x1 = x0 + chunk.size.Width;
                float y0 = chunk.leftTop.Y;
                float y1 = y0 + chunk.size.Height;
                int textureIndex = chunk.PageIndex;
                var glyphInfo = new GlyphInfo(characters,
                    new vec2(x0 / pageWidth, y0 / pageHeight), new vec2(x1 / pageWidth, y1 / pageHeight), textureIndex);
                dictionary.Add(characters, glyphInfo);
            }

            return dictionary;
        }

        private static Texture GenerateTexture(GLBitmap[] bitmaps) {
            var storage = new TexImageBitmaps(bitmaps);
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                //new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();

            return texture;
        }

        private static void PrintChunks(List<ChunkBase> chunkList, PagesContext context, GLBitmap[] bitmaps) {
            if (chunkList.Count == 0) { return; }

            //var graphicses = new Graphics[bitmaps.Length];
            var bmpOne = new Bitmap(1, 1);
            var g = Graphics.FromImage(bmpOne);

            foreach (var chunk in chunkList) {
                int index = chunk.PageIndex;
                if (index >= bitmaps.Length) { continue; }

                string bigStr = "丨" + chunk.text + "丨";
                SizeF bigSize = g.MeasureString(bigStr, chunk.theFont);
                var bigBmp = new Bitmap((int)Math.Ceiling(bigSize.Width), (int)Math.Ceiling(bigSize.Height));
                using (var bigGraphics = Graphics.FromImage(bigBmp)) { bigGraphics.DrawString(bigStr, chunk.theFont, Brushes.Black, 0, 0); }

                //if (graphicses[index] == null) { graphicses[index] = Graphics.FromImage(bitmaps[index]); }
                var source = bitmaps[index];
                var tmp = new Bitmap(source.width, source.height, source.width * source.pixelBytes, System.Drawing.Imaging.PixelFormat.Format32bppArgb, source.scan0);
                using (var graphics = Graphics.FromImage(tmp)) {
                    graphics.DrawImage(bigBmp,
                        new RectangleF(chunk.leftTop, chunk.size),
                        new RectangleF(
                            (bigSize.Width - chunk.size.Width) / 2, 0,
                            chunk.size.Width, chunk.size.Height),
                        GraphicsUnit.Pixel);
                    //graphics.DrawRectangle(Pens.Red, chunk.LeftTop.X, chunk.LeftTop.Y, chunk.Size.Width - 1, chunk.Size.Height - 1);
                    //graphics.DrawRectangle(Pens.Red, 0, 0, bitmaps[index].Width - 1, bitmaps[index].Height - 1);
                }
            }

            g.Dispose();
            bmpOne.Dispose();
        }

        private static GLBitmap[] GenerateBitmaps(List<ChunkBase> chunkList, int pageCount) {
            var bitmaps = new GLBitmap[pageCount];
            if (chunkList.Count == 0) { return bitmaps; }

            //var sizes = new SizeF[bitmaps.Length];
            var widths = new float[bitmaps.Length];
            var heights = new float[bitmaps.Length];
            for (int i = 0; i < chunkList.Count; i++) {
                ChunkBase chunk = chunkList[i];
                int index = chunk.PageIndex;
                if (index >= bitmaps.Length) // this happens when chunks overflows of max pages.
                {
                    continue;
                }

                float newWidth = chunk.leftTop.X + chunk.size.Width;
                float newHeight = chunk.leftTop.Y + chunk.size.Height;
                if (widths[index] < newWidth) { widths[index] = newWidth; }
                if (heights[index] < newHeight) { heights[index] = newHeight; }
            }

            float maxWidth = 0.0f, maxHeight = 0.0f;
            for (int i = 0; i < bitmaps.Length; i++) {
                if (maxWidth < widths[i]) { maxWidth = widths[i]; }
                if (maxHeight < heights[i]) { maxHeight = heights[i]; }
            }

            int w = (int)Math.Ceiling(maxWidth);
            int h = (int)Math.Ceiling(maxHeight);
            for (int i = 0; i < bitmaps.Length; i++) {
                bitmaps[i] = new GLBitmap(w, h, 4);
            }

            return bitmaps;
        }

        private unsafe static int GetMaxTextureSize() {
            var maxTextureSize = stackalloc int[1];
            var gl = GL.current; if (gl != null) {
                gl.glGetIntegerv((GLenum)GetTarget.MaxTextureSize, maxTextureSize);
            }
            int result = maxTextureSize[0] > 1024 ? 1024 : maxTextureSize[0];
            return result;
        }

        private static List<ChunkBase> GetChunkList(Font font, IEnumerable<char> charset) {
            var result = new List<ChunkBase>();
            foreach (var item in charset) {
                var chunk = new StringChunk(item.ToString(), font);
                result.Add(chunk);
            }

            return result;
        }

        private static List<ChunkBase> GetChunkList(Font font, IEnumerable<string> charset) {
            var result = new List<ChunkBase>();
            foreach (var item in charset) {
                var chunk = new StringChunk(item, font);
                result.Add(chunk);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool GetGlyphInfo(char character, [MaybeNullWhen(false)] out GlyphInfo result) {
            return this.dictionary.TryGetValue(character.ToString(), out result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="characters"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool GetGlyphInfo(string characters, [MaybeNullWhen(false)] out GlyphInfo result) {
            return this.dictionary.TryGetValue(characters, out result);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class _GlyphServerHelper {
        /// <summary>
        /// Create a <see cref="GlyphServer"/> instance that provides glyph information according to specified character.
        /// 
        /// </summary>
        /// <param name="font"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static GlyphServer CreateGlyphServer(this Font font, IEnumerable<char> charset) {
            return GlyphServer.Create(font, charset);
        }

        /// <summary>
        /// Create a <see cref="GlyphServer"/> instance that provides glyph information according to specified characters.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static GlyphServer CreateGlyphServer(this Font font, IEnumerable<string> charset) {
            return GlyphServer.Create(font, charset);
        }
    }
}
