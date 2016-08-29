using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public partial class Framebuffer
    {
        #region attach Texture images

        private static readonly uint[] attachment_id =
        {
			OpenGL.GL_COLOR_ATTACHMENT0,
			OpenGL.GL_COLOR_ATTACHMENT1,
			OpenGL.GL_COLOR_ATTACHMENT2,
			OpenGL.GL_COLOR_ATTACHMENT3,
			OpenGL.GL_COLOR_ATTACHMENT4,
			OpenGL.GL_COLOR_ATTACHMENT5,
			OpenGL.GL_COLOR_ATTACHMENT6,
			OpenGL.GL_COLOR_ATTACHMENT7,
			OpenGL.GL_COLOR_ATTACHMENT8,
			OpenGL.GL_COLOR_ATTACHMENT9,
			OpenGL.GL_COLOR_ATTACHMENT10,
			OpenGL.GL_COLOR_ATTACHMENT11,
			OpenGL.GL_COLOR_ATTACHMENT12,
			OpenGL.GL_COLOR_ATTACHMENT13,
			OpenGL.GL_COLOR_ATTACHMENT14,
			OpenGL.GL_COLOR_ATTACHMENT15,
        };
        private int nextColorAttachmentIndex = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texture"></param>
        /// <returns></returns>
        public bool Attach(Texture texture)
        {
            if (nextColorAttachmentIndex >= attachment_id.Length)
            { throw new IndexOutOfRangeException("Not enough color attach points!"); }

            glFramebufferTexture2D(
    OpenGL.GL_FRAMEBUFFER, attachment_id[nextColorAttachmentIndex++], OpenGL.GL_TEXTURE_2D, texture.Id, 0);

            return CheckCompleteness();
        }

        /// <summary>
        /// Attach a render buffer.
        /// </summary>
        /// <param name="renderbuffer"></param>
        /// <returns></returns>
        public bool Attach(Renderbuffer renderbuffer)
        {
            if (nextColorAttachmentIndex >= attachment_id.Length)
            { throw new IndexOutOfRangeException("Not enough attach points!"); }

            glFramebufferRenderbuffer(OpenGL.GL_FRAMEBUFFER, OpenGL.GL_DEPTH_STENCIL_ATTACHMENT, OpenGL.GL_RENDERBUFFER, renderbuffer.Id);

            return CheckCompleteness();
        }

        #endregion attach Texture images
    }
}
