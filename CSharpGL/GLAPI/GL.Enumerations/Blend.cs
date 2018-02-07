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
        Zero = GL.GL_ZERO,

        /// <summary>
        ///
        /// </summary>
        One = GL.GL_ONE,

        /// <summary>
        ///
        /// </summary>
        SourceColor = GL.GL_SRC_COLOR,

        /// <summary>
        ///
        /// </summary>
        OneMinusSourceColor = GL.GL_ONE_MINUS_SRC_COLOR,

        /// <summary>
        ///
        /// </summary>
        DestinationColor = GL.GL_DST_COLOR,

        /// <summary>
        ///
        /// </summary>
        OneMinusDestinationColor = GL.GL_ONE_MINUS_DST_COLOR,

        /// <summary>
        ///
        /// </summary>
        SourceAlpha = GL.GL_SRC_ALPHA,

        /// <summary>
        ///
        /// </summary>
        OneMinusSourceAlpha = GL.GL_ONE_MINUS_SRC_ALPHA,

        /// <summary>
        ///
        /// </summary>
        DestinationAlpha = GL.GL_DST_ALPHA,

        /// <summary>
        ///
        /// </summary>
        OneMinusDestinationAlpha = GL.GL_ONE_MINUS_DST_ALPHA,

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
    public enum BlendingSourceFactor : uint
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
        SourceColor = GL.GL_SRC_COLOR,

        /// <summary>
        ///
        /// </summary>
        OneMinusSourceColor = GL.GL_ONE_MINUS_SRC_COLOR,

        /// <summary>
        ///
        /// </summary>
        DestinationColor = GL.GL_DST_COLOR,

        /// <summary>
        ///
        /// </summary>
        OneMinusDestinationColor = GL.GL_ONE_MINUS_DST_COLOR,

        /// <summary>
        ///
        /// </summary>
        SourceAlpha = GL.GL_SRC_ALPHA,

        /// <summary>
        ///
        /// </summary>
        OneMinusSourceAlpha = GL.GL_ONE_MINUS_SRC_ALPHA,

        /// <summary>
        ///
        /// </summary>
        DestinationAlpha = GL.GL_DST_ALPHA,

        /// <summary>
        ///
        /// </summary>
        OneMinusDestinationAlpha = GL.GL_ONE_MINUS_DST_ALPHA,

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
        SourceAlphaSaturate = GL.GL_SRC_ALPHA_SATURATE,
    }
	
	public enum BlendEquationMode : uint
	{
		Add = GL.GL_FUNC_ADD,
		Subtract = GL.GL_FUNC_SUBTRACT, 
		ReverseSubtract = GL.GL_FUNC_REVERSE_SUBTRACT, 
		Min = GL.GL_MIN, 
		Max = GL.GL_MAX,
	}
	
}