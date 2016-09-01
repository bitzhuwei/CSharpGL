namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public enum TexStorage3DTarget : uint
    {
        /// <summary>
        ///
        /// </summary>
        Texture3D = OpenGL.GL_TEXTURE_3D,

        /// <summary>
        ///
        /// </summary>
        ProxyTexture3D = OpenGL.GL_PROXY_TEXTURE_3D,

        /// <summary>
        ///
        /// </summary>
        Texture2DArray = OpenGL.GL_TEXTURE_2D_ARRAY,

        /// <summary>
        ///
        /// </summary>
        ProxyTexture2DArray = OpenGL.GL_PROXY_TEXTURE_2D_ARRAY,

        /// <summary>
        ///
        /// </summary>
        TextureCubeMapArray = OpenGL.GL_TEXTURE_CUBE_MAP_ARRAY,

        /// <summary>
        ///
        /// </summary>
        ProxyTextureCubeMapArray = OpenGL.GL_PROXY_TEXTURE_CUBE_MAP_ARRAY,
    }
}