using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Provides glyph information according to specified character(s).
    /// </summary>
    public class GlyphServer
    {
        private Dictionary<string, GlyphInfo> dictionary = new Dictionary<string, GlyphInfo>();

        /// <summary>
        /// A GL_TEXTURE_2D_ARRAY texture that stores all glyphs in one or multiple layers.
        /// </summary>
        public Texture GlyphTexture { get; private set; }
        /// <summary>
        /// <see cref="GlyphTexture"/>'s width.
        /// </summary>
        public int TextureWidth { get; private set; }
        /// <summary>
        /// <see cref="GlyphTexture"/>'s height.
        /// </summary>
        public int TextureHeight { get; private set; }

        private GlyphServer() { }

        /// <summary>
        /// for each render context, there's a default glyph server.
        /// </summary>
        private static readonly Dictionary<IntPtr, GlyphServer> defaultServerDict = new Dictionary<IntPtr, GlyphServer>();
        private static readonly object synObj = new object();
        /// <summary>
        /// default server only provides visible ASCII code.
        /// </summary>
        public static GlyphServer DefaultServer
        {
            get
            {
                IntPtr context = GL.Instance.GetCurrentContext();
                if (context == null) { throw new Exception("Render context not exists!"); }

                GlyphServer server;
                var dict = GlyphServer.defaultServerDict;
                if (!dict.TryGetValue(context, out server))
                {
                    lock (synObj) // the process of creating a glyph serve may take a long time(several seconds), so we need a lock.
                    {
                        if (!dict.TryGetValue(context, out server))
                        {
                            var builder = new StringBuilder();
                            // ascii
                            for (char c = ' '; c <= '~'; c++)
                            {
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
                            var font = new Font("Arial", 64, GraphicsUnit.Pixel);
                            string charSet = builder.ToString();
                            server = GlyphServer.Create(font, charSet, 1024, 1024, 1000);
                            font.Dispose();
                            dict.Add(context, server);
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
        public static GlyphServer Create(Font font, IEnumerable<char> charset)
        {
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
        public static GlyphServer Create(Font font, IEnumerable<char> charset, int maxTextureWidth, int maxTextureHeight, int maxTextureCount)
        {
            if (charset == null || charset.Count() == 0) { return new GlyphServer(); ; }

            List<ChunkBase> chunkList = GetChunkList(font, charset);
            return Create(chunkList, maxTextureWidth, maxTextureHeight, maxTextureCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="font"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static GlyphServer Create(Font font, IEnumerable<string> charset)
        {
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
        public static GlyphServer Create(Font font, IEnumerable<string> charset, int maxTextureWidth, int maxTextureHeight, int maxTextureCount)
        {
            if (charset == null || charset.Count() == 0) { return new GlyphServer(); }

            List<ChunkBase> chunkList = GetChunkList(font, charset);
            return Create(chunkList, maxTextureWidth, maxTextureHeight, maxTextureCount);
        }

        private static GlyphServer Create(List<ChunkBase> chunkList, int maxTextureWidth, int maxTextureHeight, int maxTextureCount)
        {
            var context = new PagesContext(maxTextureWidth, maxTextureHeight, maxTextureCount);
            foreach (var item in chunkList)
            {
                item.Put(context);
            }

            Bitmap[] bitmaps = GenerateBitmaps(chunkList, context.PageList.Count);
            PrintChunks(chunkList, context, bitmaps);

            Dictionary<string, GlyphInfo> dictionary = GetDictionary(chunkList, bitmaps[0].Width, bitmaps[0].Height);

            Texture texture = GenerateTexture(bitmaps);

            var server = new GlyphServer();
            server.dictionary = dictionary;
            server.GlyphTexture = texture;
            server.TextureWidth = bitmaps[0].Width;
            server.TextureHeight = bitmaps[0].Height;

            //// test: save bitmaps to disk.
            //Test(server.dictionary, bitmaps);

            foreach (var item in bitmaps)
            {
                item.Dispose();
            }

            return server;
        }

        /// <summary>
        /// save bitmaps to disk.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="bitmaps"></param>
        private static void Test(Dictionary<string, GlyphInfo> dictionary, Bitmap[] bitmaps)
        {
            //var graphicses = new Graphics[bitmaps.Length];
            foreach (var item in dictionary)
            {
                GlyphInfo info = item.Value;
                QuadSTRStruct quad = info.quad;
                int index = (int)Math.Floor(quad.leftTop.z);

                float x0 = quad.leftTop.x * bitmaps[index].Width;
                float x1 = quad.rightTop.x * bitmaps[index].Width;
                float y0 = quad.leftTop.y * bitmaps[index].Height;
                float y1 = quad.leftBottom.y * bitmaps[index].Height;
                using (var graphics = Graphics.FromImage(bitmaps[index]))
                {
                    graphics.DrawRectangle(index == 0 ? Pens.Red : Pens.Green, x0, y0, x1 - x0, y1 - y0);
                }
            }

            for (int i = 0; i < bitmaps.Length; i++)
            {
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

        private static Dictionary<string, GlyphInfo> GetDictionary(List<ChunkBase> chunkList, int pageWidth, int pageHeight)
        {
            var dictionary = new Dictionary<string, GlyphInfo>();
            foreach (var chunk in chunkList)
            {
                string characters = chunk.Text;
                float x0 = chunk.LeftTop.X; float x1 = x0 + chunk.Size.Width;
                float y0 = chunk.LeftTop.Y;
                float y1 = y0 + chunk.Size.Height;
                int textureIndex = chunk.PageIndex;
                var glyphInfo = new GlyphInfo(characters,
                    new vec2(x0 / pageWidth, y0 / pageHeight), new vec2(x1 / pageWidth, y1 / pageHeight), textureIndex);
                dictionary.Add(characters, glyphInfo);
            }

            return dictionary;
        }

        private static Texture GenerateTexture(Bitmap[] bitmaps)
        {
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

        private static void PrintChunks(List<ChunkBase> chunkList, PagesContext context, Bitmap[] bitmaps)
        {
            if (chunkList.Count == 0) { return; }

            //var graphicses = new Graphics[bitmaps.Length];
            var bmp = new Bitmap(1, 1);
            var g = Graphics.FromImage(bmp);

            foreach (var chunk in chunkList)
            {
                int index = chunk.PageIndex;
                if (index >= bitmaps.Length) { continue; }

                string bigStr = "丨" + chunk.Text + "丨";
                SizeF bigSize = g.MeasureString(bigStr, chunk.TheFont);
                var bigBmp = new Bitmap((int)Math.Ceiling(bigSize.Width), (int)Math.Ceiling(bigSize.Height));
                using (var bigGraphics = Graphics.FromImage(bigBmp))
                { bigGraphics.DrawString(bigStr, chunk.TheFont, Brushes.Black, 0, 0); }

                //if (graphicses[index] == null) { graphicses[index] = Graphics.FromImage(bitmaps[index]); }
                using (var graphics = Graphics.FromImage(bitmaps[index]))
                {
                    graphics.DrawImage(bigBmp,
                        new RectangleF(chunk.LeftTop, chunk.Size),
                        new RectangleF(
                            (bigSize.Width - chunk.Size.Width) / 2, 0,
                            chunk.Size.Width, chunk.Size.Height),
                        GraphicsUnit.Pixel);
                    //graphics.DrawRectangle(Pens.Red, chunk.LeftTop.X, chunk.LeftTop.Y, chunk.Size.Width - 1, chunk.Size.Height - 1);
                    //graphics.DrawRectangle(Pens.Red, 0, 0, bitmaps[index].Width - 1, bitmaps[index].Height - 1);
                }
            }

            g.Dispose();
            bmp.Dispose();
        }

        private static Bitmap[] GenerateBitmaps(List<ChunkBase> chunkList, int pageCount)
        {
            var bitmaps = new Bitmap[pageCount];
            if (chunkList.Count == 0) { return bitmaps; }

            //var sizes = new SizeF[bitmaps.Length];
            var widths = new float[bitmaps.Length];
            var heights = new float[bitmaps.Length];
            for (int i = 0; i < chunkList.Count; i++)
            {
                ChunkBase chunk = chunkList[i];
                int index = chunk.PageIndex;
                if (index >= bitmaps.Length) // this happens when chunks overflows of max pages.
                {
                    continue;
                }

                float newWidth = chunk.LeftTop.X + chunk.Size.Width;
                float newHeight = chunk.LeftTop.Y + chunk.Size.Height;
                if (widths[index] < newWidth) { widths[index] = newWidth; }
                if (heights[index] < newHeight) { heights[index] = newHeight; }
            }

            float maxWidth = 0.0f, maxHeight = 0.0f;
            for (int i = 0; i < bitmaps.Length; i++)
            {
                if (maxWidth < widths[i]) { maxWidth = widths[i]; }
                if (maxHeight < heights[i]) { maxHeight = heights[i]; }
            }

            int w = (int)Math.Ceiling(maxWidth);
            int h = (int)Math.Ceiling(maxHeight);
            for (int i = 0; i < bitmaps.Length; i++)
            {
                bitmaps[i] = new Bitmap(w, h);
            }

            return bitmaps;
        }

        private static int GetMaxTextureSize()
        {
            int[] maxTextureSize = new int[1];
            GL.Instance.GetIntegerv((uint)GetTarget.MaxTextureSize, maxTextureSize);
            int result = maxTextureSize[0] > 1024 ? 1024 : maxTextureSize[0];
            return result;
        }

        private static List<ChunkBase> GetChunkList(Font font, IEnumerable<char> charset)
        {
            var result = new List<ChunkBase>();
            foreach (var item in charset)
            {
                var chunk = new StringChunk(item.ToString(), font);
                result.Add(chunk);
            }

            return result;
        }

        private static List<ChunkBase> GetChunkList(Font font, IEnumerable<string> charset)
        {
            var result = new List<ChunkBase>();
            foreach (var item in charset)
            {
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
        public bool GetGlyphInfo(char character, out GlyphInfo result)
        {
            return this.dictionary.TryGetValue(character.ToString(), out result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="characters"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool GetGlyphInfo(string characters, out GlyphInfo result)
        {
            return this.dictionary.TryGetValue(characters, out result);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class _GlyphServerHelper
    {
        /// <summary>
        /// Create a <see cref="GlyphServer"/> instance that provides glyph information according to specified character.
        /// 
        /// </summary>
        /// <param name="font"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static GlyphServer CreateGlyphServer(this Font font, IEnumerable<char> charset)
        {
            return GlyphServer.Create(font, charset);
        }

        /// <summary>
        /// Create a <see cref="GlyphServer"/> instance that provides glyph information according to specified characters.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static GlyphServer CreateGlyphServer(this Font font, IEnumerable<string> charset)
        {
            return GlyphServer.Create(font, charset);
        }
    }
}
