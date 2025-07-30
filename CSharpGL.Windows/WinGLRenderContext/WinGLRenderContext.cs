using CSharpGL.Windows;
using System;
using System.Diagnostics;
using System.Drawing;

namespace CSharpGL.Windows {
    /// <summary>
    /// openGL implementation on Windows Operation System.
    /// </summary>
    public unsafe partial class WinGLRenderContext : GLRenderContext, IDisposable {

        /// <summary>
        ///
        /// </summary>
        private DIBSection dibSection;

        /// <summary>
        /// creates render device and render context.
        /// </summary>
        /// <param name="handle">Control.Handle</param>
        /// <param name="width">Control.Width</param>
        /// <param name="height">Control.Height</param>
        /// <param name="hDC"></param>
        /// <param name="hRC"></param>
        /// <param name="glFunctions"></param>
        /// <param name="dibSection"></param>
        /// <returns></returns>
        private WinGLRenderContext(IntPtr handle, int width, int height, IntPtr hDC, IntPtr hRC, GL glFunctions, DIBSection dibSection)
            : base(handle, width, height, hDC, hRC, glFunctions) {
            this.dibSection = dibSection;
        }

        /// <summary>
        /// Sets the dimensions of the render context provider.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        public override void SetDimensions(int width, int height) {
            //  Call the base.
            base.SetDimensions(width, height);

            ////	Set the window size.
            //Win32.SetWindowPos(windowHandle, IntPtr.Zero, 0, 0, Width, Height,
            //    SetWindowPosFlags.SWP_NOACTIVATE |
            //    SetWindowPosFlags.SWP_NOCOPYBITS |
            //    SetWindowPosFlags.SWP_NOMOVE |
            //    SetWindowPosFlags.SWP_NOOWNERZORDER);

            //	Resize dib section.
            this.dibSection.Resize(width, height);
        }


        /// <summary>
        /// Blit the rendered data to the supplied device context.
        /// </summary>
        /// <param name="hDC">Graphics.GetHdc()</param>
        public override bool Blit(IntPtr hDC) {
            //IntPtr dc = this.DeviceContextHandle;
            //if (dc != IntPtr.Zero || windowHandle != IntPtr.Zero) {
            //    //	Swap the buffers.
            //    Win32.SwapBuffers(dc);
            //    //	Blit the DC (containing the DIB section) to the target DC.
            //    Win32.BitBlt(hDC, 0, 0, this.Width, this.Height, dc, 0, 0, Win32.SRCCOPY);
            //}

            ////  Set the read buffer.
            //GL.glReadBuffer(GL.GL_COLOR_ATTACHMENT0);
            //	Read the pixels into the DIB section.
            this.glFunctions.glReadPixels(0, 0, this.width, this.height, 0x80E1/*GL_BGRA*/, 0x1401/*GL_UNSIGNED_BYTE*/, this.dibSection.Bits);
            //	Blit the DC (containing the DIB section) to the target DC.
            return Win32.BitBlt(hDC, 0, 0, this.width, this.height, this.dibSection.memoryDeviceContext, 0, 0, 0x00CC0020/*SRCCOPY*/);
        }

        /// <summary>
        /// Makes the render context current.
        /// </summary>
        public override void MakeCurrent() {
            base.MakeCurrent();
            if (this.hRC != IntPtr.Zero) {
                Win32.wglMakeCurrent(this.hDC, this.hRC);
            }
        }

        public override void CancelCurrent() {
            base.CancelCurrent();
            Win32.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
        }
    }
}