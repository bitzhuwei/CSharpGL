using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class Framebuffer
    {
        /// <summary>
        /// Attach a renderbuffer.
        /// </summary>
        /// <param name="renderbufferType"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public Renderbuffer Attach(RenderbufferType renderbufferType, FramebufferTarget target = FramebufferTarget.Framebuffer)
        {
            Renderbuffer result = null;
            switch (renderbufferType)
            {
                case RenderbufferType.DepthBuffer:
                    result = AttachDepthbuffer(target);
                    break;

                case RenderbufferType.ColorBuffer:
                    result = AttachColorbuffer(target);
                    break;

                default:
                    throw new NotDealWithNewEnumItemException(typeof(RenderbufferType));
            }

            return result;
        }

        private Renderbuffer AttachColorbuffer(FramebufferTarget target)
        {
            if (this.nextColorAttachmentIndex >= Framebuffer.maxColorAttachmentCount)
            { throw new IndexOutOfRangeException("Not enough attach points!"); }

            Renderbuffer colorBuffer = Renderbuffer.CreateColorbuffer(this.Width, this.Height, GL.GL_RGBA);
            glFramebufferRenderbuffer((uint)target, GL.GL_COLOR_ATTACHMENT0 + this.nextColorAttachmentIndex, GL.GL_RENDERBUFFER, colorBuffer.Id);
            this.nextColorAttachmentIndex++;

            this.colorBufferList.Add(colorBuffer);

            return colorBuffer;
        }

        private Renderbuffer AttachDepthbuffer(FramebufferTarget target)
        {
            if (this.depthBuffer != null)
            { throw new Exception("Depth buffer already exists!"); }

            Renderbuffer depthBuffer = Renderbuffer.CreateDepthbuffer(this.Width, this.Height, DepthComponentType.DepthComponent24);
            glFramebufferRenderbuffer((uint)target, GL.GL_DEPTH_ATTACHMENT, GL.GL_RENDERBUFFER, depthBuffer.Id);

            this.depthBuffer = depthBuffer;

            return depthBuffer;
        }
    }
}
