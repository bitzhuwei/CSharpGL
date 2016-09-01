namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public enum TexStorage2DTarget : uint
    {
        /// <summary>
        ///
        /// </summary>
        Texture2D = OpenGL.GL_TEXTURE_2D,

        /// <summary>
        ///
        /// </summary>
        ProxyTexture2D = OpenGL.GL_PROXY_TEXTURE_2D,

        /// <summary>
        ///
        /// </summary>
        Texture1DArray = OpenGL.GL_TEXTURE_1D_ARRAY,

        /// <summary>
        ///
        /// </summary>
        ProxyTexture1DArray = OpenGL.GL_PROXY_TEXTURE_1D_ARRAY,

        /// <summary>
        ///
        /// </summary>
        TextureRectangle = OpenGL.GL_TEXTURE_RECTANGLE,

        /// <summary>
        ///
        /// </summary>
        ProxyTextureRectangle = OpenGL.GL_PROXY_TEXTURE_RECTANGLE,

        /// <summary>
        ///
        /// </summary>
        TextureCubeMap = OpenGL.GL_TEXTURE_CUBE_MAP,

        /// <summary>
        ///
        /// </summary>
        ProxyTextureCubeMap = OpenGL.GL_PROXY_TEXTURE_CUBE_MAP,
    }
}