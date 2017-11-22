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
        Depth = GL.GL_DEPTH_ATTACHMENT,

        /// <summary>
        ///
        /// </summary>
        Stencil = GL.GL_STENCIL_ATTACHMENT,

        /// <summary>
        /// Attaching a level of a texture to GL_DEPTH_STENCIL_ATTACHMENT is equivalent to attaching that level to both the GL_DEPTH_ATTACHMENTand the GL_STENCIL_ATTACHMENT attachment points simultaneously.
        /// </summary>
        DepthStencil = GL.GL_DEPTH_STENCIL_ATTACHMENT,
    }
}
