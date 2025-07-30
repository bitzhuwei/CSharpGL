using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {

    enum BindFramebufferTarget : uint {
        /// <summary>
        /// 0x8CA9
        /// </summary>
        DrawFramebuffer = GL.GL_DRAW_FRAMEBUFFER,
        /// <summary>
        /// 0x8CA8
        /// </summary>
        ReadFramebuffer = GL.GL_READ_FRAMEBUFFER,
        /// <summary>
        /// 0x8D40
        /// </summary>
        Framebuffer = GL.GL_FRAMEBUFFER
    }
}
