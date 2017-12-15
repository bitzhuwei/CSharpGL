using System;

namespace CSharpGL
{
    /// <summary>
    /// A render context.
    /// </summary>
    public class FBORenderContext : WinGLRenderContext
    {
        /// <summary>
        /// A render context.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public FBORenderContext(int width, int height, ContextGenerationParams parameters)
            : base(width, height, parameters)
        {
            Framebuffer framebuffer = CreateFramebuffer(width, height, parameters);
            framebuffer.Bind();
            this.framebuffer = framebuffer;
        }

        private static Framebuffer CreateFramebuffer(int width, int height, ContextGenerationParams parameters)
        {
            var framebuffer = new Framebuffer(width, height);
            framebuffer.Bind();
            {
                var renderbuffer = new Renderbuffer(width, height, GL.GL_RGBA);
                uint colorAttachmentLocation = 0;
                framebuffer.Attach(FramebufferTarget.Framebuffer, renderbuffer, colorAttachmentLocation);// 0
            }
            {
                var renderbuffer = new Renderbuffer(width, height, GL.GL_DEPTH_COMPONENT24);
                framebuffer.Attach(FramebufferTarget.Framebuffer, renderbuffer, AttachmentLocation.Depth);// special
            }
            if (parameters.StencilBits > 0)
            {
                var renderbuffer = new Renderbuffer(width, height, GL.GL_STENCIL_INDEX8);
                framebuffer.Attach(FramebufferTarget.Framebuffer, renderbuffer, AttachmentLocation.Stencil);
            }
            framebuffer.CheckCompleteness();
            framebuffer.Unbind();

            return framebuffer;
        }

        /// <summary>
        ///
        /// </summary>
        protected override void DisposeUnmanagedResources()
        {
            //  Delete the framebuffer.
            this.framebuffer.Unbind();
            this.framebuffer.Dispose();

            //	Call the base, which will delete the render context handle and window.
            base.DisposeUnmanagedResources();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="parameters"></param>
        public override void SetDimensions(int width, int height)
        {
            //  Call the base.
            base.SetDimensions(width, height);

            //  TODO: We should be able to just use the code below - however we
            //  get invalid dimension issues at the moment, so recreate for now.
            ////  Resize the render buffer storage.
            //this.framebuffer.Resize(width, height);

            this.framebuffer.Unbind();
            this.framebuffer.Dispose();
            Framebuffer framebuffer = CreateFramebuffer(width, height, this.Parameters);
            framebuffer.Bind();
            this.framebuffer = framebuffer;
        }

        /// <summary>
        /// somehing wrong if this field is removed. I don't know why.
        /// </summary>
        private Framebuffer framebuffer;

    }
}