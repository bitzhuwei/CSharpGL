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
            int width = GetAllWidth(sizes);
            int height = (int)sizes[0].Height;
            var bitmap = new Bitmap(width, height);
            Draw(charset, sizes, bitmap);
            FillDictionary(sizes, server.dictionary);

            return server;
        }

        private static void FillDictionary(SizeF[] sizes, Dictionary<char, GlyphInfo> dictionary)
        {
            throw new NotImplementedException();
        }

        private static void Draw(IEnumerable<char> charset, SizeF[] sizes, Bitmap bitmap)
        {
            throw new NotImplementedException();
        }

        private static int GetAllWidth(SizeF[] sizes)
        {
            throw new NotImplementedException();
        }

        private static SizeF[] GetAllCharSizes(Font font, IEnumerable<char> charset)
        {
            throw new NotImplementedException();
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
