using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// helper class.
    /// </summary>
    public static class FontTextureHelper
    {
        /// <summary>
        /// Gets an instance of <see cref="FontTexture"/>.
        /// </summary>
        /// <param name="fontBitmap"></param>
        /// <param name="textureBuilder"></param>
        /// <returns></returns>
        public static FontTexture GetFontTexture(this FontBitmap fontBitmap, TextureBuilder textureBuilder = null)
        {
            if (textureBuilder == null) { textureBuilder = new TextureBuilder(); }

            var result = new FontTexture();
            result.GlyphFont = fontBitmap.GlyphFont;
            result.GlyphHeight = fontBitmap.GlyphHeight;
            result.TextureSize = fontBitmap.GlyphBitmap.Size;
            result.GlyphInfoDictionary = fontBitmap.GlyphInfoDictionary;
            result.Initialize(textureBuilder, fontBitmap.GlyphBitmap);
            return result;
        }
    }
}
