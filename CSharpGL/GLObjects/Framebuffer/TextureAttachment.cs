using System;
using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public enum TextureAttachment : uint
    {
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment = GL.GL_COLOR_ATTACHMENT0,

        /// <summary>
        ///
        /// </summary>
        DepthAttachment = GL.GL_DEPTH_ATTACHMENT,

        /// <summary>
        ///
        /// </summary>
        StencilAttachment = GL.GL_STENCIL_ATTACHMENT,

        /// <summary>
        ///
        /// </summary>
        DepthStencilAttachment = GL.GL_DEPTH_STENCIL_ATTACHMENT,
    }
}
