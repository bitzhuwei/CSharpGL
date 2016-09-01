namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public enum GetTexImageTargets : uint
    {
        /// <summary>
        ///
        /// </summary>
        Texture1D = OpenGL.GL_TEXTURE_1D,

        /// <summary>
        ///
        /// </summary>
        Texture2D = OpenGL.GL_TEXTURE_2D,

        /// <summary>
        ///
        /// </summary>
        Texture3D = OpenGL.GL_TEXTURE_3D,

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
    public enum GetTexImageFormats : uint
    {
        /// <summary>
        ///
        /// </summary>
        Red = OpenGL.GL_RED,

        /// <summary>
        ///
        /// </summary>
        Green = OpenGL.GL_GREEN,

        /// <summary>
        ///
        /// </summary>
        Blue = OpenGL.GL_BLUE,

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
        BGR = OpenGL.GL_BGR,

        /// <summary>
        ///
        /// </summary>
        RGBA = OpenGL.GL_RGBA,

        /// <summary>
        ///
        /// </summary>
        BGRA = OpenGL.GL_BGRA,

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
    /// 在你需要使用加入这些选项：
    /// GL_UNSIGNED_BYTE, GL_BYTE, GL_UNSIGNED_SHORT, GL_SHORT, GL_UNSIGNED_INT, GL_INT, GL_FLOAT, GL_UNSIGNED_BYTE_3_3_2, GL_UNSIGNED_BYTE_2_3_3_REV, GL_UNSIGNED_SHORT_5_6_5, GL_UNSIGNED_SHORT_5_6_5_REV, GL_UNSIGNED_SHORT_4_4_4_4, GL_UNSIGNED_SHORT_4_4_4_4_REV, GL_UNSIGNED_SHORT_5_5_5_1, GL_UNSIGNED_SHORT_1_5_5_5_REV, GL_UNSIGNED_INT_8_8_8_8, GL_UNSIGNED_INT_8_8_8_8_REV, GL_UNSIGNED_INT_10_10_10_2, and GL_UNSIGNED_INT_2_10_10_10_REV
    /// check: https://www.opengl.org/sdk/docs/man2/xhtml/glGetTexImage.xml
    /// </summary>
    public enum GetTexImageTypes : uint
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