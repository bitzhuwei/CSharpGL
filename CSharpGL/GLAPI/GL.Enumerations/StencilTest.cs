using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public enum EStencilFunc : uint
    {
        /// <summary>
        /// 
        /// </summary>
        Always = GL.GL_ALWAYS,
        /// <summary>
        /// 
        /// </summary>
        Never = GL.GL_NEVER,
        /// <summary>
        /// 
        /// </summary>
        Less = GL.GL_LESS,
        /// <summary>
        /// 
        /// </summary>
        LEqual = GL.GL_LEQUAL,
        /// <summary>
        /// 
        /// </summary>
        Greater = GL.GL_GREATER,
        /// <summary>
        /// 
        /// </summary>
        GEqual = GL.GL_GEQUAL,
        /// <summary>
        /// 
        /// </summary>
        Equal = GL.GL_EQUAL,
        /// <summary>
        /// 
        /// </summary>
        NotEqual = GL.GL_NOTEQUAL,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum EStencilOp : uint
    {
        /// <summary>
        /// 
        /// </summary>
        Keep = GL.GL_KEEP,
        /// <summary>
        /// 
        /// </summary>
        Zero = GL.GL_ZERO,
        /// <summary>
        /// 
        /// </summary>
        Replace = GL.GL_REPLACE,
        /// <summary>
        /// 
        /// </summary>
        Incr = GL.GL_INCR,
        /// <summary>
        /// 
        /// </summary>
        IncrWrap = GL.GL_INCR_WRAP,
        /// <summary>
        /// 
        /// </summary>
        Decr = GL.GL_DECR,
        /// <summary>
        /// 
        /// </summary>
        DecrWrap = GL.GL_DECR_WRAP,
        /// <summary>
        /// 
        /// </summary>
        Invert = GL.GL_INVERT
    }
}
