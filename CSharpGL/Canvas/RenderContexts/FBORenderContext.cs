using System;

namespace CSharpGL
{
    /// <summary>
    /// A render context.
    /// </summary>
    public class FBORenderContext : HiddenWindowRenderContext
    {
        //static List<WeakReference<FBORenderContext>> renderContextList = new List<WeakReference<FBORenderContext>>();
        //public FBORenderContext()
        //{
        //    renderContextList.Add(new WeakReference<FBORenderContext>(this));
        //}

        //public override void Destroy()
        //{
        //    bool found = false;
        //    WeakReference<FBORenderContext> target = null;
        //    for (int index = 0; index < renderContextList.Count; index++)
        //    {
        //        target = renderContextList[index];
        //        FBORenderContext context;
        //        if (target.TryGetTarget(out context))
        //        {
        //            if (context == this)
        //            { break; }
        //        }
        //    }
        //    if (found)
        //    {
        //        renderContextList.Remove(target);
        //    }

        //    base.Destroy();
        //}
        //public static FBORenderContext GetCurrentRenderContext()
        //{
        //    IntPtr renderContext = Win32.wglGetCurrentContext();

        //}

        /// <summary>
        /// Creates the render context provider. Must also create the OpenGL extensions.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="bitDepth"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool Create(int width, int height, int bitDepth, object parameter)
        {
            //  Call the base class.
            base.Create(width, height, bitDepth, parameter);

            // Create frame buffer object.
            Framebuffer framebuffer = CreateFramebuffer(width, height);
            this.framebuffer = framebuffer;

            //  Create the DIB section.
            var dibSection = new DIBSection();
            dibSection.Create(this.DeviceContextHandle, width, height, bitDepth);
            this.dibSection = dibSection;

            return true;
        }

        private static Framebuffer CreateFramebuffer(int width, int height)
        {
            Renderbuffer colorBuffer = Renderbuffer.CreateColorbuffer(width, height, OpenGL.GL_RGBA);
            Renderbuffer depthBuffer = Renderbuffer.CreateDepthbuffer(width, height, DepthComponentType.DepthComponent24);
            var framebuffer = new Framebuffer();
            framebuffer.Bind();
            framebuffer.Attach(colorBuffer);
            framebuffer.Attach(depthBuffer);

            framebuffer.CheckCompleteness();

            return framebuffer;
        }

        /// <summary>
        ///
        /// </summary>
        protected override void DisposeUnmanagedResources()
        {
            //  Delete the render buffers.
            this.framebuffer.Dispose();

            //  Destroy the internal dc.
            //Win32.DeleteDC(this.dibSection.MemoryDeviceContext);
            this.dibSection.Dispose();

            //this.dibSection.Dispose();

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

            this.framebuffer.Dispose();
            Framebuffer framebuffer = CreateFramebuffer(width, height);
            this.framebuffer = framebuffer;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="hdc"></param>
        public override void Blit(IntPtr hdc)
        {
            if (this.DeviceContextHandle != IntPtr.Zero)
            {
                //  Set the read buffer.
                OpenGL.ReadBuffer(OpenGL.GL_COLOR_ATTACHMENT0);

                //	Read the pixels into the DIB section.
                OpenGL.ReadPixels(0, 0, this.Width, this.Height, OpenGL.GL_BGRA,
                    OpenGL.GL_UNSIGNED_BYTE, this.dibSection.Bits);

                //	Blit the DC (containing the DIB section) to the target DC.
                Win32.BitBlt(hdc, 0, 0, this.Width, this.Height,
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

        ///// <summary>
        ///// Gets the internal DIB section.
        ///// </summary>
        ///// <value>The internal DIB section.</value>
        //public DIBSection InternalDIBSection
        //{
        //    get { return dibSection; }
        //}
    }
}