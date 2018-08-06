using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// creates render device and render context.
    /// </summary>
    public partial class SoftGLRenderContext : GLRenderContext
    {
        /// <summary>
        /// 
        /// </summary>
        internal IntPtr Pointer { get; private set; }

        /// <summary>
        /// creates render device and render context.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="parameters">parameters.</param>
        /// <returns></returns>
        public SoftGLRenderContext(int width, int height, ContextGenerationParams parameters)
            : base(width, height, parameters)
        {
            GCHandle handle = GCHandle.Alloc(this, GCHandleType.WeakTrackResurrection);
            this.Pointer = GCHandle.ToIntPtr(handle);
            handle.Free();
            // Create a new window class, as basic as possible.
            if (!this.CreateBasicRenderContext(width, height, parameters))
            {
                throw new Exception(string.Format("Create basic render context failed!"));
            }

            //  Make the context current.
            this.MakeCurrent();

            if (parameters.UpdateContextVersion)
            {
                //  Update the context if required.
                // if I update context, something in legacy opengl will not work...
                this.UpdateContextVersion(parameters);
            }

            this.dibSection = new DIBSection(this.DeviceContextHandle, width, height, parameters);
        }

        /// <summary>
        /// Create a new window class, as basic as possible.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private bool CreateBasicRenderContext(int width, int height, ContextGenerationParams parameters)
        {
            //var wndClass = new WNDCLASSEX();
            //wndClass.Init();
            //wndClass.style = ClassStyles.HorizontalRedraw | ClassStyles.VerticalRedraw | ClassStyles.OwnDC;
            //wndClass.lpfnWndProc = wndProcDelegate;
            //wndClass.lpszClassName = "CSharpGLRenderWindow";
            //Win32.RegisterClassEx(ref wndClass);

            ////	Create the window. Position and size it.
            //windowHandle = Win32.CreateWindowEx(0,
            //              "CSharpGLRenderWindow",
            //              "",
            //              WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_POPUP,
            //              0, 0, width, height,
            //              IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

            ////	Get the window device context.
            //this.DeviceContextHandle = Win32.GetDC(windowHandle);

            ////	Setup a pixel format.
            //var pfd = new PixelFormatDescriptor();
            //pfd.Init();
            //pfd.nVersion = 1;
            //pfd.dwFlags = Win32.PFD_DRAW_TO_WINDOW | Win32.PFD_SUPPORT_OPENGL | Win32.PFD_DOUBLEBUFFER;
            //pfd.iPixelType = Win32.PFD_TYPE_RGBA;
            //pfd.cColorBits = parameters.ColorBits;
            //pfd.cAccumBits = parameters.AccumBits;
            //pfd.cAccumRedBits = parameters.AccumRedBits;
            //pfd.cAccumGreenBits = parameters.AccumGreenBits;
            //pfd.cAccumBlueBits = parameters.AccumBlueBits;
            //pfd.cAccumAlphaBits = parameters.AccumAlphaBits;
            //pfd.cDepthBits = parameters.DepthBits;
            //pfd.cStencilBits = parameters.StencilBits;
            //pfd.iLayerType = Win32.PFD_MAIN_PLANE;

            ////	Match an appropriate pixel format
            //int iPixelformat = Win32.ChoosePixelFormat(this.DeviceContextHandle, pfd);
            //if (iPixelformat == 0)
            //{
            //    return false;
            //}

            ////	Sets the pixel format
            //if (false == Win32.SetPixelFormat(this.DeviceContextHandle, iPixelformat, pfd))
            //{
            //    return false;
            //}

            ////	Create the render context.
            //this.RenderContextHandle = Win32.wglCreateContext(this.DeviceContextHandle);

            return true;
        }

        /// <summary>
        /// Only valid to be called after the render context is created, this function attempts to
        /// move the render context to the OpenGL version originally requested. If this is &gt; 2.1, this
        /// means building a new context. If this fails, we'll have to make do with 2.1.
        /// </summary>
        /// <param name="parameters"></param>
        protected bool UpdateContextVersion(ContextGenerationParams parameters)
        {
            //  If the request version number is anything up to and including 2.1, standard render contexts
            //  will provide what we need (as long as the graphics card drivers are up to date).

            //  Now the none-trivial case. We must use the WGL_create_context extension to
            //  attempt to create a 3.0+ context.
            try
            {
                var wglChoosePixelFormatARB = GL.Instance.GetDelegateFor("wglChoosePixelFormatARB", GLDelegates.typeof_bool_IntPtr_intN_floatN_uint_intN_uintN) as GLDelegates.bool_IntPtr_intN_floatN_uint_intN_uintN;
                if (wglChoosePixelFormatARB == null) { return false; }
                var wglCreateContextAttribs = GL.Instance.GetDelegateFor("wglCreateContextAttribsARB", GLDelegates.typeof_IntPtr_IntPtr_IntPtr_intN) as GLDelegates.IntPtr_IntPtr_IntPtr_intN;
                if (wglCreateContextAttribs == null) { return false; }

                int major, minor;
                GetHighestVersion(out major, out minor);
                if ((major > 2) || (major == 2 && minor > 1))
                {

                    int[] attribList = new int[]
                    {
                        SoftGL.WGL_SUPPORT_OPENGL_ARB,   (int)GL.GL_TRUE,
                        SoftGL.WGL_DRAW_TO_WINDOW_ARB,   (int)GL.GL_TRUE,
                        SoftGL.WGL_DOUBLE_BUFFER_ARB,    (int)GL.GL_TRUE,
                        SoftGL.WGL_ACCELERATION_ARB,     SoftGL.WGL_FULL_ACCELERATION_ARB,
                        SoftGL.WGL_PIXEL_TYPE_ARB,       SoftGL.WGL_TYPE_RGBA_ARB,
                        SoftGL.WGL_COLOR_BITS_ARB,       parameters.ColorBits,
                        SoftGL.WGL_ACCUM_BITS_ARB,       parameters.AccumBits,
                        SoftGL.WGL_ACCUM_RED_BITS_ARB,   parameters.AccumRedBits,
                        SoftGL.WGL_ACCUM_GREEN_BITS_ARB, parameters.AccumGreenBits,
                        SoftGL.WGL_ACCUM_BLUE_BITS_ARB,  parameters.AccumBlueBits,
                        SoftGL.WGL_ACCUM_ALPHA_BITS_ARB, parameters.AccumAlphaBits,
                        SoftGL.WGL_DEPTH_BITS_ARB,       parameters.DepthBits,
                        SoftGL.WGL_STENCIL_BITS_ARB,     parameters.StencilBits,
                        0,        //End
                    };

                    IntPtr dc = this.DeviceContextHandle;
                    //	Match an appropriate pixel format
                    int[] pixelFormat = new int[1];
                    uint[] numFormats = new uint[1];
                    if (false == wglChoosePixelFormatARB(dc, attribList, null, 1, pixelFormat, numFormats))
                    { return false; }
                    //	Sets the pixel format
                    //if (false == Win32.SetPixelFormat(dc, pixelFormat[0], new PixelFormatDescriptor()))
                    //{
                    //    return false;
                    //}

                    int[] attributes =
                    {
                        SoftGL.WGL_CONTEXT_MAJOR_VERSION_ARB, 
                        major,
                        SoftGL.WGL_CONTEXT_MINOR_VERSION_ARB, 
                        minor,
                        SoftGL.WGL_CONTEXT_PROFILE_MASK_ARB,  
                        SoftGL.WGL_CONTEXT_COMPATIBILITY_PROFILE_BIT_ARB,
//#if DEBUG
//                        GL.WGL_CONTEXT_FLAGS, GL.WGL_CONTEXT_DEBUG_BIT,// this is a debug context
//#endif
                        0
                    };
                    IntPtr hrc = wglCreateContextAttribs(dc, IntPtr.Zero, attributes);
                    //Win32.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
                    //Win32.wglDeleteContext(this.RenderContextHandle);
                    //Win32.wglMakeCurrent(dc, hrc);
                    this.RenderContextHandle = hrc;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Log.Write(ex);
            }

            return true;
        }

        private void GetHighestVersion(out int major, out int minor)
        {
            major = 2; minor = 1;
            try
            {
                string version = GL.Instance.GetString(GL.GL_VERSION);
                string[] parts = version.Split('.');
                major = int.Parse(parts[0]);
                minor = int.Parse(parts[1]);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        //private static WndProc wndProcDelegate = new WndProc(WndProc);

        //static private IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        //{
        //    return Win32.DefWindowProc(hWnd, msg, wParam, lParam);
        //}

        /// <summary>
        /// Destroys the render context provider instance.
        /// </summary>
        protected override void DisposeUnmanagedResources()
        {
            //  Destroy the internal dc.
            this.dibSection.Dispose();

            ////	Release the device context.
            //Win32.ReleaseDC(windowHandle, this.DeviceContextHandle);

            ////	Destroy the window.
            //Win32.DestroyWindow(windowHandle);

            // If we have a render context, destroy it.
            if (this.RenderContextHandle != IntPtr.Zero)
            {
                //Win32.wglDeleteContext(this.RenderContextHandle);
                this.RenderContextHandle = IntPtr.Zero;
            }

        }

        /// <summary>
        /// Sets the dimensions of the render context provider.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        public override void SetDimensions(int width, int height)
        {
            //  Call the base.
            base.SetDimensions(width, height);

            ////	Set the window size.
            //Win32.SetWindowPos(windowHandle, IntPtr.Zero, 0, 0, Width, Height,
            //    SetWindowPosFlags.SWP_NOACTIVATE |
            //    SetWindowPosFlags.SWP_NOCOPYBITS |
            //    SetWindowPosFlags.SWP_NOMOVE |
            //    SetWindowPosFlags.SWP_NOOWNERZORDER);

            //	Resize dib section.
            this.dibSection.Resize(width, height, this.Parameters);
        }

        /// <summary>
        /// Blit the rendered data to the supplied device context.
        /// </summary>
        /// <param name="deviceContext">The HDC.</param>
        public override void Blit(IntPtr deviceContext)
        {
            //IntPtr dc = this.DeviceContextHandle;
            //if (dc != IntPtr.Zero || windowHandle != IntPtr.Zero)
            //{
            //    //	Swap the buffers.
            //    Win32.SwapBuffers(dc);

            //    //	Blit the DC (containing the DIB section) to the target DC.
            //    Win32.BitBlt(deviceContext, 0, 0, this.Width, this.Height, dc, 0, 0, Win32.SRCCOPY);
            //}

            if (this.DeviceContextHandle != IntPtr.Zero)
            {
                ////  Set the read buffer.
                //GL.Instance.ReadBuffer(GL.GL_COLOR_ATTACHMENT0);

                //	Read the pixels into the DIB section.
                GL.Instance.ReadPixels(0, 0, this.Width, this.Height, GL.GL_BGRA,
                    GL.GL_UNSIGNED_BYTE, this.dibSection.Bits);

                //	Blit the DC (containing the DIB section) to the target DC.
                //Win32.BitBlt(deviceContext, 0, 0, this.Width, this.Height,
                //this.dibSection.MemoryDeviceContext, 0, 0, Win32.SRCCOPY);
            }
        }

        /// <summary>
        /// Makes the render context current.
        /// </summary>
        public override void MakeCurrent()
        {
            //if (this.RenderContextHandle != IntPtr.Zero)
            //Win32.wglMakeCurrent(this.DeviceContextHandle, this.RenderContextHandle);
        }

        /// <summary>
        /// The window handle.
        /// </summary>
        protected IntPtr windowHandle = IntPtr.Zero;


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