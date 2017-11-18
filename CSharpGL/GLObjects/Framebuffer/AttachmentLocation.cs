using System;
using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public enum AttachmentLocation : uint
    {
        /// <summary>
        /// 
        /// </summary>
        Color = GL.GL_COLOR_ATTACHMENT0,

        /// <summary>
        ///
        /// </summary>
        Depth = GL.GL_DEPTH_ATTACHMENT,

        /// <summary>
        ///
        /// </summary>
        Stencil = GL.GL_STENCIL_ATTACHMENT,

        /// <summary>
        ///
        /// </summary>
        DepthStencil = GL.GL_DEPTH_STENCIL_ATTACHMENT,
    }
}
