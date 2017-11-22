using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class Framebuffer
    {
        /// <summary>
        /// Attach a <see cref="Renderbuffer"/> object as a color attachment to the currently bound framebuffer object.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="renderbuffer"></param>
        /// <param name="colorAttachmentLocation">ranges from 0 to <see cref="Framebuffer.maxColorAttachmentCount"/> - 1.</param>
        public void Attach(FramebufferTarget target, Renderbuffer renderbuffer, uint colorAttachmentLocation)
        {
            if (colorAttachmentLocation >= Framebuffer.maxColorAttachmentCount)
            { throw new IndexOutOfRangeException("Not enough attach points!"); }

            glFramebufferRenderbuffer((uint)target, GL.GL_COLOR_ATTACHMENT0 + colorAttachmentLocation, GL.GL_RENDERBUFFER, renderbuffer.Id);

            this.colorBuffers[colorAttachmentLocation] = renderbuffer;
        }

        /// <summary>
        /// Attach a <see cref="Renderbuffer"/> object to the currently bound framebuffer object.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="renderbuffer"></param>
        /// <param name="location"></param>
        public void Attach(FramebufferTarget target, Renderbuffer renderbuffer, AttachmentLocation location)
        {
            switch (location)
            {
                case AttachmentLocation.Depth:
                    {
                        if (this.depthBuffer != null)
                        { throw new Exception("Depth buffer already exists!"); }

                        glFramebufferRenderbuffer((uint)target, GL.GL_DEPTH_ATTACHMENT, GL.GL_RENDERBUFFER, renderbuffer.Id);

                        this.depthBuffer = renderbuffer;
                    }
                    break;
                case AttachmentLocation.Stencil:
                    {
                        if (this.stencilBuffer != null)
                        { throw new Exception("Stencil buffer already exists!"); }

                        glFramebufferRenderbuffer((uint)target, GL.GL_STENCIL_ATTACHMENT, GL.GL_RENDERBUFFER, renderbuffer.Id);

                        this.stencilBuffer = renderbuffer;
                    }
                    break;
                case AttachmentLocation.DepthStencil:
                    {
                        if (this.depthBuffer != null)
                        { throw new Exception("Depth buffer already exists!"); }
                        if (this.stencilBuffer != null)
                        { throw new Exception("Stencil buffer already exists!"); }

                        glFramebufferRenderbuffer((uint)target, GL.GL_DEPTH_STENCIL_ATTACHMENT, GL.GL_RENDERBUFFER, renderbuffer.Id);

                        this.depthBuffer = renderbuffer;
                        this.stencilBuffer = renderbuffer;
                    }
                    break;
                default:
                    throw new NotDealWithNewEnumItemException(typeof(AttachmentLocation));
            }
        }
    }
}
