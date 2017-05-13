namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public enum TexImage2DTargets : uint
    {
        /// <summary>
        ///
        /// </summary>
        Texture2D = OpenGL.GL_TEXTURE_2D,

        /// <summary>
        ///
        /// </summary>
        ProxyTexture2D = OpenGL.GL_PROXY_TEXTURE_2D,
    }

    /// <summary>
    ///
    /// </summary>
    public enum TexImage2DFormats : uint
    {
        /// <summary>
        ///
        /// </summary>
        Alpha = OpenGL.GL_ALPHA,

        /// <summary>
        ///
        /// </summary>
        RGB = OpenGL.GL_RGB,

        /// <summary>
        ///
        /// </summary>
        RGBA = OpenGL.GL_RGBA,

        /// <summary>
        ///
        /// </summary>
        Luminance = OpenGL.GL_LUMINANCE,

        /// <summary>
        ///
        /// </summary>
        LuminanceAlpha = OpenGL.GL_LUMINANCE_ALPHA,
    }

    /// <summary>
    ///
    /// </summary>
    public enum TexImage2DTypes : uint
    {
        /// <summary>
        ///
        /// </summary>
        UnsignedByte = OpenGL.GL_UNSIGNED_BYTE,

        /// <summary>
        ///
        /// </summary>
        UnsignedShort565 = OpenGL.GL_UNSIGNED_SHORT_5_6_5,

        /// <summary>
        ///
        /// </summary>
        UnsignedShort4444 = OpenGL.GL_UNSIGNED_SHORT_4_4_4_4,

        /// <summary>
        ///
        /// </summary>
        UnsignedShort5551 = OpenGL.GL_UNSIGNED_SHORT_5_5_5_1,
    }
}