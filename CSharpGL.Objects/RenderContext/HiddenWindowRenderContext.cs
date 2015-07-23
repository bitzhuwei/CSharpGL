using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Objects
{
    public class HiddenWindowRenderContext : RenderContext
    {

        /// <summary>
        /// Creates the render context provider. Must also create the OpenGL extensions.
        /// </summary>
        /// <param name="openGLVersion">The desired OpenGL version.</param>
        /// <param name="gl">The OpenGL context.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="bitDepth">The bit depth.</param>
        /// <param name="parameter">The parameter</param>
        /// <returns></returns>
        public override bool Create(GLVersion openGLVersion, int width, int height, int bitDepth, object parameter)
        {
            //  Call the base.
            base.Create(openGLVersion, width, height, bitDepth, parameter);

            //	Create a new window class, as basic as possible.                
            WNDCLASSEX wndClass = new WNDCLASSEX();
            wndClass.Init();
            wndClass.style = ClassStyles.HorizontalRedraw | ClassStyles.VerticalRedraw | ClassStyles.OwnDC;
            wndClass.lpfnWndProc = wndProcDelegate;
            wndClass.cbClsExtra = 0;
            wndClass.cbWndExtra = 0;
            wndClass.hInstance = IntPtr.Zero;
            wndClass.hIcon = IntPtr.Zero;
            wndClass.hCursor = IntPtr.Zero;
            wndClass.hbrBackground = IntPtr.Zero;
            wndClass.lpszMenuName = null;
            wndClass.lpszClassName = "SharpGLRenderWindow";
            wndClass.hIconSm = IntPtr.Zero;
            Win32.RegisterClassEx(ref wndClass);

            //	Create the window. Position and size it.
            windowHandle = Win32.CreateWindowEx(0,
                          "SharpGLRenderWindow",
                          "",
                          WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_POPUP,
                          0, 0, width, height,
                          IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

            //	Get the window device context.
            DeviceContextHandle = Win32.GetDC(windowHandle);

            //	Setup a pixel format.
            PIXELFORMATDESCRIPTOR pfd = new PIXELFORMATDESCRIPTOR();
            pfd.Init();
            pfd.nVersion = 1;
            pfd.dwFlags = Win32.PFD_DRAW_TO_WINDOW | Win32.PFD_SUPPORT_OPENGL | Win32.PFD_DOUBLEBUFFER;
            pfd.iPixelType = Win32.PFD_TYPE_RGBA;
            pfd.cColorBits = (byte)bitDepth;
            pfd.cDepthBits = 16;
            pfd.cStencilBits = 8;
            pfd.iLayerType = Win32.PFD_MAIN_PLANE;

            //	Match an appropriate pixel format 
            int iPixelformat;
            if ((iPixelformat = Win32.ChoosePixelFormat(DeviceContextHandle, pfd)) == 0)
                return false;

            //	Sets the pixel format
            if (Win32.SetPixelFormat(DeviceContextHandle, iPixelformat, pfd) == 0)
            {
                return false;
            }

            //	Create the render context.
            RenderContextHandle = Win32.wglCreateContext(DeviceContextHandle);

            //  Make the context current.
            MakeCurrent();

            //  Update the context if required.
            UpdateContextVersion();

            //  Return success.
            return true;
        }

        private static WndProc wndProcDelegate = new WndProc(WndProc);

        static private IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            return Win32.DefWindowProc(hWnd, msg, wParam, lParam);
        }

        /// <summary>
        /// Destroys the render context provider instance.
        /// </summary>
        public override void Destroy()
        {
            //	Release the device context.
            Win32.ReleaseDC(windowHandle, DeviceContextHandle);

            //	Destroy the window.
            Win32.DestroyWindow(windowHandle);

            //	Call the base, which will delete the render context handle.
            base.Destroy();
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

            //	Set the window size.
            Win32.SetWindowPos(windowHandle, IntPtr.Zero, 0, 0, Width, Height,
                SetWindowPosFlags.SWP_NOACTIVATE |
                SetWindowPosFlags.SWP_NOCOPYBITS |
                SetWindowPosFlags.SWP_NOMOVE |
                SetWindowPosFlags.SWP_NOOWNERZORDER);
        }

        /// <summary>
        /// Blit the rendered data to the supplied device context.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        public override void Blit(IntPtr hdc)
        {
            if (DeviceContextHandle != IntPtr.Zero || windowHandle != IntPtr.Zero)
            {
                //	Swap the buffers.
                Win32.SwapBuffers(DeviceContextHandle);

                //  Get the HDC for the graphics object.
                Win32.BitBlt(hdc, 0, 0, Width, Height, DeviceContextHandle, 0, 0, Win32.SRCCOPY);
            }
        }

        /// <summary>
        /// Makes the render context current.
        /// </summary>
        public override void MakeCurrent()
        {
            if (RenderContextHandle != IntPtr.Zero)
                Win32.wglMakeCurrent(DeviceContextHandle, RenderContextHandle);
        }

        /// <summary>
        /// The window handle.
        /// </summary>
        protected IntPtr windowHandle = IntPtr.Zero;
    }
}
