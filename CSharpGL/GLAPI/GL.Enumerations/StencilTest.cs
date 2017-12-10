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
        /// Always passes.
        /// </summary>
        Always = GL.GL_ALWAYS,
        /// <summary>
        /// Always fails
        /// </summary>
        Never = GL.GL_NEVER,
        /// <summary>
        /// Passes if ( ref &amp; mask) &lt; ( stencil &amp; mask)
        /// </summary>
        Less = GL.GL_LESS,
        /// <summary>
        /// Passes if ( ref &amp; mask) &lt;= ( stencil &amp; mask)
        /// </summary>
        LEqual = GL.GL_LEQUAL,
        /// <summary>
        /// Passes if ( ref &amp; mask) &gt; ( stencil &amp; mask)
        /// </summary>
        Greater = GL.GL_GREATER,
        /// <summary>
        /// Passes if ( ref &amp; mask) &gt;= ( stencil &amp; mask).
        /// </summary>
        GEqual = GL.GL_GEQUAL,
        /// <summary>
        /// Passes if ( ref &amp; mask) = ( stencil &amp; mask)
        /// </summary>
        Equal = GL.GL_EQUAL,
        /// <summary>
        /// Passes if ( ref &amp; mask) != ( stencil &amp; mask)
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
