using System;

namespace CSharpGL
{
    /// <summary>
    /// A render context.
    /// </summary>
    public class FBORenderContext : HiddenWindowRenderContext
    {
        /// <summary>
        /// Creates the render context provider. Must also create the OpenGL extensions.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="colorBitDepth"></param>
        /// <returns></returns>
        public FBORenderContext(int width, int height, byte colorBitDepth)
            : base(width, height, colorBitDepth)
        {
            Framebuffer framebuffer = CreateFramebuffer(width, height);
            framebuffer.Bind();
            this.framebuffer = framebuffer;

            this.dibSection = new DIBSection(this.DeviceContextHandle, width, height, colorBitDepth);
        }

        private static Framebuffer CreateFramebuffer(int width, int height)
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
            //{
            //    var renderbuffer = new Renderbuffer(width, height, GL.GL_STENCIL_INDEX8);
            //    framebuffer.Attach(FramebufferTarget.Framebuffer, renderbuffer, AttachmentLocation.Stencil);
            //}
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

            //  Destroy the internal dc.
            this.dibSection.Dispose();

            //	Call the base, which will delete the render context handle and window.
            base.DisposeUnmanagedResources();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public override void SetDimensions(int width, int height)
        {
            //  Call the base.
            base.SetDimensions(width, height);

            //	Resize dib section.
            this.dibSection.Resize(width, height, this.BitDepth);

            //  TODO: We should be able to just use the code below - however we
            //  get invalid dimension issues at the moment, so recreate for now.
            ////  Resize the render buffer storage.
            //this.framebuffer.Resize(width, height);

            this.framebuffer.Unbind();
            this.framebuffer.Dispose();
            Framebuffer framebuffer = CreateFramebuffer(width, height);
            framebuffer.Bind();
            this.framebuffer = framebuffer;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="deviceContext"></param>
        public override void Blit(IntPtr deviceContext)
        {
            if (this.DeviceContextHandle != IntPtr.Zero)
            {
                //  Set the read buffer.
                GL.Instance.ReadBuffer(GL.GL_COLOR_ATTACHMENT0);

                //	Read the pixels into the DIB section.
                GL.Instance.ReadPixels(0, 0, this.Width, this.Height, GL.GL_BGRA,
                    GL.GL_UNSIGNED_BYTE, this.dibSection.Bits);

                //	Blit the DC (containing the DIB section) to the target DC.
                Win32.BitBlt(deviceContext, 0, 0, this.Width, this.Height,
                    this.dibSection.MemoryDeviceContext, 0, 0, Win32.SRCCOPY);
            }
        }

        /// <summary>
        /// somehing wrong if this field is removed. I don't know why.
        /// </summary>
        private Framebuffer framebuffer;

        ///// <summary>
        /////
        ///// </summary>
        //private IntPtr dibSectionDeviceContext = IntPtr.Zero;
        /// <summary>
        ///
        /// </summary>
        private DIBSection dibSection;

    }
}