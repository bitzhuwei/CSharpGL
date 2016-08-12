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
        /// <param name="wrapping"></param>
        /// <param name="textureFiltering"></param>
        /// <param name="mipmapFiltering"></param>
        /// <returns></returns>
        public static FontTexture GetFontTexture(this FontBitmap fontBitmap,
            TextureWrapping wrapping = TextureWrapping.ClampToEdge,
            TextureFilter textureFiltering = TextureFilter.Linear,
            MipmapFilter mipmapFiltering = MipmapFilter.LinearMipmapLinear)
        {
            var texture = new NewTexture(fontBitmap.GlyphBitmap,
                wrapping, textureFiltering, mipmapFiltering);
            texture.Initialize();
            var result = new FontTexture();
            result.GlyphFont = fontBitmap.GlyphFont;
            result.GlyphHeight = fontBitmap.GlyphHeight;
            result.TextureSize = fontBitmap.GlyphBitmap.Size;
            result.GlyphInfoDictionary = fontBitmap.GlyphInfoDictionary;
            result.FontTextureId = texture.Id;
            return result;
        }
    }
}
