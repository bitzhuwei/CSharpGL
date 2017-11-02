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
        private Dictionary<string, GlyphInfo> dictionary = new Dictionary<string, GlyphInfo>();

        /// <summary>
        /// 
        /// </summary>
        public Texture GlyphTexture { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public int TextureWidth { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public int TextureHeight { get; private set; }

        private GlyphServer() { }

        /// <summary>
        /// default server only accepts visible ASCII code.
        /// </summary>
        public static readonly GlyphServer defaultServer;

        static GlyphServer()
        {
            var builder = new StringBuilder();
            for (char c = ' '; c < (char)127; c++)
            {
                builder.Append(c);
            }
            string charSet = builder.ToString();
            var font = new Font("Arial", 32, GraphicsUnit.Pixel);
            defaultServer = GlyphServer.Create(font, charSet, 265, 265, 100);
            font.Dispose();
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
            var server = new GlyphServer();
            if (charset == null || charset.Count() == 0) { return server; }

            List<ChunkBase> chunkList = GetChunkList(font, charset);
            Create(maxTextureWidth, maxTextureHeight, maxTextureCount, server, chunkList);

            return server;
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
            var server = new GlyphServer();
            if (charset == null || charset.Count() == 0) { return server; }

            List<ChunkBase> chunkList = GetChunkList(font, charset);
            Create(maxTextureWidth, maxTextureHeight, maxTextureCount, server, chunkList);

            return server;
        }

        private static void Create(int maxTextureWidth, int maxTextureHeight, int maxTextureCount, GlyphServer server, List<ChunkBase> chunkList)
        {
            var context = new PagesContext(maxTextureWidth, maxTextureHeight, maxTextureCount);
            foreach (var item in chunkList)
            {
                item.Put(context);
            }

            Bitmap[] bitmaps = GenerateBitmaps(chunkList, context);
            PrintChunks(chunkList, context, bitmaps);

            FillDictionary(chunkList, context, server.dictionary, bitmaps[0].Width, bitmaps[0].Height);

            Texture texture = GenerateTexture(bitmaps);
            server.GlyphTexture = texture;
            server.TextureWidth = bitmaps[0].Width;
            server.TextureHeight = bitmaps[0].Height;

            // test
            Test(server.dictionary, bitmaps);

            foreach (var item in bitmaps)
            {
                item.Dispose();
            }
        }

        private static void Test(Dictionary<string, GlyphInfo> dictionary, Bitmap[] bitmaps)
        {
            var graphicses = new Graphics[bitmaps.Length];
            foreach (var item in dictionary)
            {
                GlyphInfo info = item.Value;
                int index = info.textureIndex;

                if (graphicses[index] == null) { graphicses[index] = Graphics.FromImage(bitmaps[index]); }

                QuadStruct quad = info.quad;
                float x0 = quad.leftTop.x * bitmaps[index].Width;
                float x1 = quad.rightTop.x * bitmaps[index].Width;
                float y0 = quad.leftTop.y * bitmaps[index].Height;
                float y1 = quad.leftBottom.y * bitmaps[index].Height;
                graphicses[index].DrawRectangle(info.textureIndex == 0 ? Pens.Red : Pens.Green, x0, y0, x1 - x0, y1 - y0);
            }
            foreach (var item in graphicses)
            {
                item.Dispose();
            }

            for (int i = 0; i < bitmaps.Length; i++)
            {
                bitmaps[i].Save(string.Format("{0}.png", i));
            }
        }

        private static void FillDictionary(List<ChunkBase> chunkList, PagesContext context, Dictionary<string, GlyphInfo> dictionary, int pageWidth, int pageHeight)
        {
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
        }

        private static Texture GenerateTexture(Bitmap[] bitmaps)
        {
            var storage = new TexImageBitmaps(bitmaps);
            var texture = new Texture(TextureTarget.Texture2DArray, storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();

            return texture;
        }

        private static void PrintChunks(List<ChunkBase> chunkList, PagesContext context, Bitmap[] bitmaps)
        {
            if (chunkList.Count == 0) { return; }

            var graphicses = new Graphics[bitmaps.Length];
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

                if (graphicses[index] == null) { graphicses[index] = Graphics.FromImage(bitmaps[index]); }
                graphicses[index].DrawImage(bigBmp,
                    new RectangleF(chunk.LeftTop, chunk.Size),
                    new RectangleF(
                        (bigSize.Width - chunk.Size.Width) / 2, 0,
                        chunk.Size.Width, chunk.Size.Height),
                    GraphicsUnit.Pixel);
            }

            foreach (var grahpics in graphicses)
            {
                grahpics.Dispose();
            }
            g.Dispose();
            bmp.Dispose();
        }

        private static Bitmap[] GenerateBitmaps(List<ChunkBase> chunkList, PagesContext context)
        {
            List<Page> list = context.PageList;
            var bitmaps = new Bitmap[list.Count];
            if (chunkList.Count == 0) { return bitmaps; }

            //var sizes = new SizeF[bitmaps.Length];
            var widths = new float[bitmaps.Length];
            var heights = new float[bitmaps.Length];
            for (int i = 0; i < chunkList.Count; i++)
            {
                ChunkBase chunk = chunkList[i];
                int index = chunk.PageIndex;
                if (index >= list.Count) // this happens when chunks overflows of max pages.
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

            for (int i = 0; i < bitmaps.Length; i++)
            {
                var bmp = new Bitmap((int)Math.Ceiling(maxWidth), (int)Math.Ceiling(maxHeight));
                bitmaps[i] = bmp;
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
        /// 
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
