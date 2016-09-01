namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public enum TexSubImage2DTarget : uint
    {
        /// <summary>
        ///
        /// </summary>
        Texture2D = OpenGL.GL_TEXTURE_2D,

        /// <summary>
        ///
        /// </summary>
        TextureCubeMapPositiveX = OpenGL.GL_TEXTURE_CUBE_MAP_POSITIVE_X,

        /// <summary>
        ///
        /// </summary>
        TextureCubeMapNegativeX = OpenGL.GL_TEXTURE_CUBE_MAP_NEGATIVE_X,

        /// <summary>
        ///
        /// </summary>
        TextureCubeMapPositiveY = OpenGL.GL_TEXTURE_CUBE_MAP_POSITIVE_Y,

        /// <summary>
        ///
        /// </summary>
        TextureCubeMapNegativeY = OpenGL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Y,

        /// <summary>
        ///
        /// </summary>
        TextureCubeMapPositiveZ = OpenGL.GL_TEXTURE_CUBE_MAP_POSITIVE_Z,

        /// <summary>
        ///
        /// </summary>
        TextureCubeMapNegativeZ = OpenGL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Z,
    }

    /// <summary>
    ///
    /// </summary>
    public enum TexSubImage2DFormats : uint
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

        /// <summary>
        ///
        /// </summary>
        RedInteger = OpenGL.GL_RED_INTEGER,
    }

    /// <summary>
    ///
    /// </summary>
    public enum TexSubImage2DType : uint
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

        /// <summary>
        ///
        /// </summary>
        UnsignedInt = OpenGL.GL_UNSIGNED_INT,
    }
}