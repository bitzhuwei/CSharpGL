using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Error Code
    /// </summary>
    public enum ErrorCode : uint
    {
        NoError = OpenGL.GL_NO_ERROR,
        InvalidEnum = OpenGL.GL_INVALID_ENUM,
        InvalidValue = OpenGL.GL_INVALID_VALUE,
        InvalidOperation = OpenGL.GL_INVALID_OPERATION,
        StackOverflow = OpenGL.GL_STACK_OVERFLOW,
        StackUnderflow = OpenGL.GL_STACK_UNDERFLOW,
        OutOfMemory = OpenGL.GL_OUT_OF_MEMORY
    }
}
