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
        private Texture[] textures;

        private GlyphServer() { }

        public static readonly GlyphServer defaultServer;

        static GlyphServer()
        {
            var builder = new StringBuilder();
            for (char c = (char)20; c < (char)127; c++)
            {
                builder.Append(c);
            }
            string charSet = builder.ToString();
            var font = new Font("Arial", 32, GraphicsUnit.Pixel);
            defaultServer = GlyphServer.Create(font, charSet);
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
        /// <param name="textureWidth"></param>
        /// <param name="textureHeight"></param>
        /// <param name="maxTextureCount"></param>
        /// <returns></returns>
        public static GlyphServer Create(Font font, IEnumerable<char> charset, int textureWidth, int textureHeight, int maxTextureCount)
        {
            var server = new GlyphServer();
            if (charset == null || charset.Count() == 0) { return server; }

            List<ChunkBase> chunkList = GetChunkList(font, charset);
            Create(textureWidth, textureHeight, maxTextureCount, server, chunkList);

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
        /// <param name="textureWidth"></param>
        /// <param name="textureHeight"></param>
        /// <param name="maxTextureCount"></param>
        /// <returns></returns>
        public static GlyphServer Create(Font font, IEnumerable<string> charset, int textureWidth, int textureHeight, int maxTextureCount)
        {
            var server = new GlyphServer();
            if (charset == null || charset.Count() == 0) { return server; }

            List<ChunkBase> chunkList = GetChunkList(font, charset);
            Create(textureWidth, textureHeight, maxTextureCount, server, chunkList);

            return server;
        }

        private static void Create(int textureWidth, int textureHeight, int maxTextureCount, GlyphServer server, List<ChunkBase> chunkList)
        {
            var context = new PagesContext(textureWidth, textureHeight, maxTextureCount);
            foreach (var item in chunkList)
            {
                item.Put(context);
            }

            Bitmap[] bitmaps = GenerateBitmaps(chunkList, context);
            PrintChunks(chunkList, context, bitmaps);
            //for (int i = 0; i < bitmaps.Length; i++)
            //{
            //    bitmaps[i].Save(string.Format("{0}.png", i));
            //}
            Texture[] textures = GenerateTextures(bitmaps);
            server.textures = textures;
            FillDictionary(chunkList, context, textures, server.dictionary);
        }

        private static void FillDictionary(List<ChunkBase> chunkList, PagesContext context, Texture[] textures, Dictionary<string, GlyphInfo> dictionary)
        {
            int currentIndex = 0;
            float currentWidth = 0;
            foreach (var chunk in chunkList)
            {
                if (currentIndex != chunk.PageIndex) // new page starts.
                {
                    currentIndex = chunk.PageIndex;
                    currentWidth = 0;
                }

                if (currentIndex >= context.PageList.Count) { continue; } // not enough pages for speicifed chearacters.

                string characters = chunk.Text;
                float x0 = currentWidth, x1 = currentWidth + chunk.Size.Width;
                float y0 = 0;
                float y1 = chunk.Size.Height;
                var glyphInfo = new GlyphInfo(characters,
                    new vec2(x0, y0), new vec2(x1, y1), textures[currentIndex]);
                dictionary.Add(characters, glyphInfo);
                currentWidth += chunk.Size.Width;
            }
        }

        private static Texture[] GenerateTextures(Bitmap[] bitmaps)
        {
            var result = new Texture[bitmaps.Length];

            for (int i = 0; i < bitmaps.Length; i++)
            {
                var bmp = bitmaps[i];
                var storage = new TexImage2D(TexImage2D.Target.Texture2D, 0,
                    GL.GL_RGBA, bmp.Width, bmp.Height, 0,
                    GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, new ImageDataProvider(bmp));
                var texture = new Texture(TextureTarget.Texture2D, storage,
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

                texture.Initialize();

                result[i] = texture;
            }

            return result;
        }

        private static void PrintChunks(List<ChunkBase> chunkList, PagesContext context, Bitmap[] bitmaps)
        {
            if (chunkList.Count == 0) { return; }

            var graphicses = new Graphics[bitmaps.Length];
            var bmp = new Bitmap(1, 1);
            var g = Graphics.FromImage(bmp);

            int currentIndex = 0;
            float currentWidth = 0;
            foreach (var chunk in chunkList)
            {
                int index = chunk.PageIndex;
                if (index >= bitmaps.Length) { continue; }

                if (currentIndex != index)
                {
                    currentIndex = index;
                    currentWidth = 0;
                }

                string bigStr = "丨" + chunk.Text + "丨";
                SizeF bigSize = g.MeasureString(bigStr, chunk.TheFont);
                var bigChunk = new Bitmap((int)bigSize.Width, (int)bigSize.Height);
                var bigGraphics = Graphics.FromImage(bigChunk);
                bigGraphics.DrawString(bigStr, chunk.TheFont, Brushes.Black, 0, 0);

                if (graphicses[index] == null) { graphicses[index] = Graphics.FromImage(bitmaps[index]); }
                graphicses[index].DrawImage(bigChunk,
                    new RectangleF(currentWidth, 0, chunk.Size.Width, chunk.Size.Height),
                    new RectangleF(
                        (bigSize.Width - chunk.Size.Width) / 2, 0,
                        chunk.Size.Width, chunk.Size.Height),
                    GraphicsUnit.Pixel);
                currentWidth += chunk.Size.Width;
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

            var sizes = new SizeF[list.Count];
            for (int i = 0; i < chunkList.Count; i++)
            {
                ChunkBase chunk = chunkList[i];
                if (chunk.PageIndex >= list.Count) // this happens when chunks overflows of max pages.
                {
                    break;
                }

                int index = chunk.PageIndex;
                sizes[index].Width += chunk.Size.Width;
                sizes[index].Height = Math.Max(sizes[index].Height, chunk.Size.Height);
            }

            float maxWidth = 0.0f, maxHeight = 0.0f;
            foreach (var size in sizes)
            {
                if (maxWidth < size.Width) { maxWidth = size.Width; }
                if (maxHeight < size.Height) { maxHeight = size.Height; }
            }

            for (int i = 0; i < bitmaps.Length; i++)
            {
                var bmp = new Bitmap((int)maxWidth, (int)maxHeight);
                bitmaps[i] = bmp;
            }

            return bitmaps;
        }

        private static int GetMaxTextureSize()
        {
            int[] maxTextureSize = new int[1];
            GL.Instance.GetIntegerv((uint)GetTarget.MaxTextureSize, maxTextureSize);
            return maxTextureSize[0];
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
