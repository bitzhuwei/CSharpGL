namespace CSharpGL
{
    /// <summary>
    /// BlendingDestinationFactor
    /// </summary>
    public enum BlendingDestinationFactor : uint
    {
        /// <summary>
        /// The initial value is GL_ZERO
        /// </summary>
        Zero = OpenGL.GL_ZERO,

        /// <summary>
        ///
        /// </summary>
        One = OpenGL.GL_ONE,

        /// <summary>
        ///
        /// </summary>
        SourceColor = OpenGL.GL_SRC_COLOR,

        /// <summary>
        ///
        /// </summary>
        OneMinusSourceColor = OpenGL.GL_ONE_MINUS_SRC_COLOR,

        /// <summary>
        ///
        /// </summary>
        DestinationColor = OpenGL.GL_DST_COLOR,

        /// <summary>
        ///
        /// </summary>
        OneMinusDestinationColor = OpenGL.GL_ONE_MINUS_DST_COLOR,

        /// <summary>
        ///
        /// </summary>
        SourceAlpha = OpenGL.GL_SRC_ALPHA,

        /// <summary>
        ///
        /// </summary>
        OneMinusSourceAlpha = OpenGL.GL_ONE_MINUS_SRC_ALPHA,

        /// <summary>
        ///
        /// </summary>
        DestinationAlpha = OpenGL.GL_DST_ALPHA,

        /// <summary>
        ///
        /// </summary>
        OneMinusDestinationAlpha = OpenGL.GL_ONE_MINUS_DST_ALPHA,

        /// <summary>
        ///
        /// </summary>
        ConstantColor = OpenGL.GL_CONSTANT_COLOR,

        /// <summary>
        ///
        /// </summary>
        OneMinusConstantColor = OpenGL.GL_ONE_MINUS_CONSTANT_COLOR,

        /// <summary>
        ///
        /// </summary>
        ConstantAlpha = OpenGL.GL_CONSTANT_ALPHA,

        /// <summary>
        ///
        /// </summary>
        OneMinusConstantAlpha = OpenGL.GL_ONE_MINUS_CONSTANT_ALPHA,
    }

    /// <summary>
    /// The blending source factor.
    /// </summary>
    public enum BlendingSourceFactor : uint
    {
        /// <summary>
        /// The initial value is GL_ONE
        /// </summary>
        One = OpenGL.GL_ONE,

        /// <summary>
        ///
        /// </summary>
        Zero = OpenGL.GL_ZERO,

        /// <summary>
        ///
        /// </summary>
        SourceColor = OpenGL.GL_SRC_COLOR,

        /// <summary>
        ///
        /// </summary>
        OneMinusSourceColor = OpenGL.GL_ONE_MINUS_SRC_COLOR,

        /// <summary>
        ///
        /// </summary>
        DestinationColor = OpenGL.GL_DST_COLOR,

        /// <summary>
        ///
        /// </summary>
        OneMinusDestinationColor = OpenGL.GL_ONE_MINUS_DST_COLOR,

        /// <summary>
        ///
        /// </summary>
        SourceAlpha = OpenGL.GL_SRC_ALPHA,

        /// <summary>
        ///
        /// </summary>
        OneMinusSourceAlpha = OpenGL.GL_ONE_MINUS_SRC_ALPHA,

        /// <summary>
        ///
        /// </summary>
        DestinationAlpha = OpenGL.GL_DST_ALPHA,

        /// <summary>
        ///
        /// </summary>
        OneMinusDestinationAlpha = OpenGL.GL_ONE_MINUS_DST_ALPHA,

        /// <summary>
        ///
        /// </summary>
        ConstantColor = OpenGL.GL_CONSTANT_COLOR,

        /// <summary>
        ///
        /// </summary>
        OneMinusConstantColor = OpenGL.GL_ONE_MINUS_CONSTANT_COLOR,

        /// <summary>
        ///
        /// </summary>
        ConstantAlpha = OpenGL.GL_CONSTANT_ALPHA,

        /// <summary>
        ///
        /// </summary>
        OneMinusConstantAlpha = OpenGL.GL_ONE_MINUS_CONSTANT_ALPHA,

        /// <summary>
        ///
        /// </summary>
        SourceAlphaSaturate = OpenGL.GL_SRC_ALPHA_SATURATE,
    }
}