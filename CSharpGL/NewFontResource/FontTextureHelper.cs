using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.NewFontResource
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
            result.GlyphFont = fontBitmap.font;
            result.GlyphHeight = fontBitmap.glyphHeight;
            result.glyphInfoDictionary = fontBitmap.glyphInfoDictionary;
            result.Initialize(textureBuilder, fontBitmap.glyphBitmap);
            return result;
        }
    }
}
