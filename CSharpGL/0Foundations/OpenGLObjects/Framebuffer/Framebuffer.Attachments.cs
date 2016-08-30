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
        private Renderbuffer depthBuffer;
        private List<Renderbuffer> colorBufferList = new List<Renderbuffer>();

        /// <summary>
        /// Attach a texture.
        /// <para>Bind() this framebuffer before invoking this method.</para>
        /// </summary>
        /// <param name="texture"></param>
        /// <returns></returns>
        public void Attach(Texture texture)
        {
            if (nextColorAttachmentIndex >= attachment_id.Length)
            { throw new IndexOutOfRangeException("Not enough color attach points!"); }

            glFramebufferTexture2D(
    OpenGL.GL_FRAMEBUFFER, attachment_id[nextColorAttachmentIndex++], OpenGL.GL_TEXTURE_2D, texture.Id, 0);
        }

        /// <summary>
        /// Attach a render buffer.
        /// <para>Bind() this framebuffer before invoking this method.</para>
        /// </summary>
        /// <param name="renderbuffer"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public void Attach(Renderbuffer renderbuffer, FramebufferTarget target = FramebufferTarget.Framebuffer)
        {
            switch (renderbuffer.BufferType)
            {
                case RenderbufferType.DepthBuffer:
                    if (this.depthBuffer != null)
                    { throw new Exception("Depth buffer already exists!"); }
                    glFramebufferRenderbuffer((uint)target, (uint)RenderbufferAttachment.DepthAttachment, OpenGL.GL_RENDERBUFFER, renderbuffer.Id);
                    this.depthBuffer = renderbuffer;
                    break;
                case RenderbufferType.ColorBuffer:
                    if (nextColorAttachmentIndex >= attachment_id.Length)
                    { throw new IndexOutOfRangeException("Not enough attach points!"); }

                    glFramebufferRenderbuffer((uint)target, attachment_id[nextColorAttachmentIndex++], OpenGL.GL_RENDERBUFFER, renderbuffer.Id);
                    this.colorBufferList.Add(renderbuffer);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion attach Texture images
    }

    /// <summary>
    /// 
    /// </summary>
    public enum RenderbufferAttachment : uint
    {
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment0 = OpenGL.GL_COLOR_ATTACHMENT0,
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment1 = OpenGL.GL_COLOR_ATTACHMENT1,
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment2 = OpenGL.GL_COLOR_ATTACHMENT2,
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment3 = OpenGL.GL_COLOR_ATTACHMENT3,
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment4 = OpenGL.GL_COLOR_ATTACHMENT4,
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment5 = OpenGL.GL_COLOR_ATTACHMENT5,
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment6 = OpenGL.GL_COLOR_ATTACHMENT6,
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment7 = OpenGL.GL_COLOR_ATTACHMENT7,
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment8 = OpenGL.GL_COLOR_ATTACHMENT8,
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment9 = OpenGL.GL_COLOR_ATTACHMENT9,
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment10 = OpenGL.GL_COLOR_ATTACHMENT10,
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment11 = OpenGL.GL_COLOR_ATTACHMENT11,
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment12 = OpenGL.GL_COLOR_ATTACHMENT12,
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment13 = OpenGL.GL_COLOR_ATTACHMENT13,
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment14 = OpenGL.GL_COLOR_ATTACHMENT14,
        /// <summary>
        /// 
        /// </summary>
        ColorAttachment15 = OpenGL.GL_COLOR_ATTACHMENT15,
        /// <summary>
        /// 
        /// </summary>
        DepthAttachment = OpenGL.GL_DEPTH_ATTACHMENT,
        /// <summary>
        /// 
        /// </summary>
        StencilAttachment = OpenGL.GL_STENCIL_ATTACHMENT,
        /// <summary>
        /// 
        /// </summary>
        DepthStencilAttachment = OpenGL.GL_DEPTH_STENCIL_ATTACHMENT,
    }
}
