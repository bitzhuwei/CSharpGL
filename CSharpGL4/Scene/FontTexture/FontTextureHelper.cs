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
            MipmapFilter mipmapFiltering = MipmapFilter.LinearMipmapLinear)
        {
            var bmp = fontBitmap.GlyphBitmap;
            var texture = new Texture(
                TextureTarget.Texture2D,
                    new TexImage2D(TexImage2D.Target.Texture2D, 0, (int)GL.GL_RGBA, bmp.Width, bmp.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, new ImageDataProvider(bmp)));
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