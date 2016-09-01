namespace CSharpGL
{
    /// <summary>
    /// Error Code
    /// </summary>
    public enum ErrorCode : uint
    {
        /// <summary>
        ///
        /// </summary>
        NoError = OpenGL.GL_NO_ERROR,

        /// <summary>
        ///
        /// </summary>
        InvalidEnum = OpenGL.GL_INVALID_ENUM,

        /// <summary>
        ///
        /// </summary>
        InvalidValue = OpenGL.GL_INVALID_VALUE,

        /// <summary>
        ///
        /// </summary>
        InvalidOperation = OpenGL.GL_INVALID_OPERATION,

        /// <summary>
        ///
        /// </summary>
        StackOverflow = OpenGL.GL_STACK_OVERFLOW,

        /// <summary>
        ///
        /// </summary>
        StackUnderflow = OpenGL.GL_STACK_UNDERFLOW,

        /// <summary>
        ///
        /// </summary>
        OutOfMemory = OpenGL.GL_OUT_OF_MEMORY,
    }
}