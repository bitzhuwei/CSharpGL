using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// Error Code
    /// </summary>
    public enum ErrorCode : uint
    {
        NoError = GL.GL_NO_ERROR,
        InvalidEnum = GL.GL_INVALID_ENUM,
        InvalidValue = GL.GL_INVALID_VALUE,
        InvalidOperation = GL.GL_INVALID_OPERATION,
        StackOverflow = GL.GL_STACK_OVERFLOW,
        StackUnderflow = GL.GL_STACK_UNDERFLOW,
        OutOfMemory = GL.GL_OUT_OF_MEMORY
    }
}
