namespace CSharpGL
{
    /// <summary>
    /// BlendingDestinationFactor
    /// </summary>
    public enum BlendDestFactor : uint
    {
        /// <summary>
        /// The initial value is GL_ZERO
        /// </summary>
        Zero = GL.GL_ZERO,

        /// <summary>
        ///
        /// </summary>
        One = GL.GL_ONE,

        /// <summary>
        ///
        /// </summary>
        SrcColor = GL.GL_SRC_COLOR,

        /// <summary>
        ///
        /// </summary>
        OneMinusSrcColor = GL.GL_ONE_MINUS_SRC_COLOR,

        /// <summary>
        ///
        /// </summary>
        DstColor = GL.GL_DST_COLOR,

        /// <summary>
        ///
        /// </summary>
        OneMinusDstColor = GL.GL_ONE_MINUS_DST_COLOR,

        /// <summary>
        ///
        /// </summary>
        SrcAlpha = GL.GL_SRC_ALPHA,

        /// <summary>
        ///
        /// </summary>
        OneMinusSrcAlpha = GL.GL_ONE_MINUS_SRC_ALPHA,

        /// <summary>
        ///
        /// </summary>
        DstAlpha = GL.GL_DST_ALPHA,

        /// <summary>
        ///
        /// </summary>
        OneMinusDstAlpha = GL.GL_ONE_MINUS_DST_ALPHA,

        /// <summary>
        ///
        /// </summary>
        ConstantColor = GL.GL_CONSTANT_COLOR,

        /// <summary>
        ///
        /// </summary>
        OneMinusConstantColor = GL.GL_ONE_MINUS_CONSTANT_COLOR,

        /// <summary>
        ///
        /// </summary>
        ConstantAlpha = GL.GL_CONSTANT_ALPHA,

        /// <summary>
        ///
        /// </summary>
        OneMinusConstantAlpha = GL.GL_ONE_MINUS_CONSTANT_ALPHA,
    }

    /// <summary>
    /// The blending source factor.
    /// </summary>
    public enum BlendSrcFactor : uint
    {
        /// <summary>
        /// The initial value is GL_ONE
        /// </summary>
        One = GL.GL_ONE,

        /// <summary>
        ///
        /// </summary>
        Zero = GL.GL_ZERO,

        /// <summary>
        ///
        /// </summary>
        SrcColor = GL.GL_SRC_COLOR,

        /// <summary>
        ///
        /// </summary>
        OneMinusSrcColor = GL.GL_ONE_MINUS_SRC_COLOR,

        /// <summary>
        ///
        /// </summary>
        DstColor = GL.GL_DST_COLOR,

        /// <summary>
        ///
        /// </summary>
        OneMinusDstColor = GL.GL_ONE_MINUS_DST_COLOR,

        /// <summary>
        ///
        /// </summary>
        SrcAlpha = GL.GL_SRC_ALPHA,

        /// <summary>
        ///
        /// </summary>
        OneMinusSrcAlpha = GL.GL_ONE_MINUS_SRC_ALPHA,

        /// <summary>
        ///
        /// </summary>
        DstAlpha = GL.GL_DST_ALPHA,

        /// <summary>
        ///
        /// </summary>
        OneMinusDstAlpha = GL.GL_ONE_MINUS_DST_ALPHA,

        /// <summary>
        ///
        /// </summary>
        ConstantColor = GL.GL_CONSTANT_COLOR,

        /// <summary>
        ///
        /// </summary>
        OneMinusConstantColor = GL.GL_ONE_MINUS_CONSTANT_COLOR,

        /// <summary>
        ///
        /// </summary>
        ConstantAlpha = GL.GL_CONSTANT_ALPHA,

        /// <summary>
        ///
        /// </summary>
        OneMinusConstantAlpha = GL.GL_ONE_MINUS_CONSTANT_ALPHA,

        /// <summary>
        ///
        /// </summary>
        SrcAlphaSaturate = GL.GL_SRC_ALPHA_SATURATE,
    }

    /// <summary>
    /// Blending equation mode.
    /// </summary>
    public enum BlendEquationMode : uint
    {
        /// <summary>
        /// </summary>
        Add = GL.GL_FUNC_ADD,
        /// <summary>
        /// </summary>
        Subtract = GL.GL_FUNC_SUBTRACT,
        /// <summary>
        /// </summary>
        ReverseSubtract = GL.GL_FUNC_REVERSE_SUBTRACT,
        /// <summary>
        /// </summary>
        Min = GL.GL_MIN,
        /// <summary>
        /// </summary>
        Max = GL.GL_MAX,
    }

}