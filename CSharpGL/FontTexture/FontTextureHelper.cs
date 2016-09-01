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
        /// <param name="parameters"></param>
        /// <param name="mipmapFiltering"></param>
        /// <returns></returns>
        public static FontTexture GetFontTexture(this FontBitmap fontBitmap,
            SamplerParameters parameters = null,
            MipmapFilter mipmapFiltering = MipmapFilter.LinearMipmapLinear)
        {
            var texture = new Texture(
                BindTextureTarget.Texture2D,
                fontBitmap.GlyphBitmap,
                parameters, mipmapFiltering);
            texture.Initialize();
            var result = new FontTexture();
            result.GlyphFont = fontBitmap.GlyphFont;
            result.GlyphHeight = fontBitmap.GlyphHeight;
            result.TextureSize = fontBitmap.GlyphBitmap.Size;
            result.GlyphInfoDictionary = fontBitmap.GlyphInfoDictionary;
            result.TextureObj = texture;
            return result;
        }
    }
}