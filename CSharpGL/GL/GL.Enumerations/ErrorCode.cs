﻿namespace CSharpGL {
    /// <summary>
    /// Error Code
    /// </summary>
    public enum ErrorCode : uint {
        /// <summary>
        /// 自上次调用glGetError以来没有错误。
        /// </summary>
        NoError = GL.GL_NO_ERROR,

        /// <summary>
        /// 枚举参数不合法。
        /// </summary>
        InvalidEnum = GL.GL_INVALID_ENUM,

        /// <summary>
        /// 值参数不合法。
        /// </summary>
        InvalidValue = GL.GL_INVALID_VALUE,

        /// <summary>
        /// 一个指令的状态对指令的参数不合法。
        /// </summary>
        InvalidOperation = GL.GL_INVALID_OPERATION,

        /// <summary>
        /// 压栈操作造成栈上溢(Overflow)。
        /// </summary>
        StackOverflow = GL.GL_STACK_OVERFLOW,

        /// <summary>
        /// 弹栈操作时栈在最低点（译注：即栈下溢(Underflow)）。
        /// </summary>
        StackUnderflow = GL.GL_STACK_UNDERFLOW,

        /// <summary>
        /// 内存调用操作无法调用（足够的）内存。
        /// </summary>
        OutOfMemory = GL.GL_OUT_OF_MEMORY,

        /// <summary>
        /// 读取或写入一个不完整的帧缓冲。
        /// </summary>
        InvalidFramebufferOperation = GL.GL_INVALID_FRAMEBUFFER_OPERATION,
    }
}