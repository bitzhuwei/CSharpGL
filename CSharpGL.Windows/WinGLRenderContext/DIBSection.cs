using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace CSharpGL.Windows {
    /// <summary>
    /// device-independent bitmap
    /// </summary>
    partial class DIBSection : IDisposable {

        ///// <summary>
        ///// The parent dc.
        ///// </summary>
        //protected IntPtr parentDC = IntPtr.Zero;


        /// <summary>
        /// parent DC
        /// </summary>
        public readonly IntPtr memoryDeviceContext;
        public readonly ContextGenerationParams genParams;

        /// <summary>
        /// Gets the handle to the bitmap.
        /// </summary>
        public IntPtr HBitmap { get; private set; }

        protected IntPtr bits = IntPtr.Zero;
        /// <summary>
        /// address of the bits.
        /// </summary>
        public IntPtr Bits { get { return bits; } }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; private set; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; private set; }

        /// <summary>
        /// Creates device-independent bitmap.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="hDC"></param>
        /// <param name="genParams">parameters.</param>
        public DIBSection(int width, int height, IntPtr hDC, ContextGenerationParams genParams) {
            IntPtr mDC = Win32.CreateCompatibleDC(hDC);

            ////	Destroy existing objects.
            //this.DestroyBitmap();

            //	Create the bitmap.
            var info = new BitmapInfo() {
                biWidth = width,
                biHeight = height,
                biPlanes = 1,
                biBitCount = genParams.colorBits,
            };
            IntPtr hBitmap = Win32.CreateDIBSection(mDC, ref info, 0/*DIB_RGB_COLORS*/, out this.bits, IntPtr.Zero, 0);
            Win32.SelectObject(mDC, hBitmap);

            // sets the OpenGL pixel format of the underlying bitmap.
            var pfd = new PixelFormatDescriptor() {
                nVersion = 1,
                dwFlags = (8/*PFD_DRAW_TO_BITMAP*/ | 32/*PFD_SUPPORT_OPENGL*/ | 16/*PFD_SUPPORT_GDI*/),
                iPixelType = 0/*PFD_TYPE_RGBA*/,
                colorBits = genParams.colorBits,
                depthBits = genParams.depthBits,
                stencilBits = genParams.stencilBits,
                iLayerType = 0/*PFD_MAIN_PLANE*/,
            };
            // Match an appropriate pixel format
            int iPixelformat = Win32.ChoosePixelFormat(mDC, pfd);
            if (iPixelformat == 0) { throw new Exception($"ChoosePixelFormat({mDC}, {pfd}) failed!"); }
            // Set the values for the pixel format.
            if (false == Win32.SetPixelFormat(mDC, iPixelformat, pfd)) {
                int lastError = Marshal.GetLastWin32Error();
                throw new Exception($"SetPixelFormat({mDC}, {iPixelformat}, {pfd}) failed! Win32Error:{lastError}.");
            }

            this.Width = width;
            this.Height = height;
            this.HBitmap = hBitmap;
            this.memoryDeviceContext = mDC;
            this.genParams = genParams;
        }

        /// <summary>
        /// Resizes the section.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void Resize(int width, int height) {
            //	Destroy existing objects.
            this.DestroyBitmap();

            //	Create the bitmap.
            var info = new BitmapInfo() {
                biWidth = width,
                biHeight = height,
                biPlanes = 1,
                biBitCount = this.genParams.colorBits,
            };
            IntPtr mDC = this.memoryDeviceContext;
            IntPtr hBitmap = Win32.CreateDIBSection(mDC, ref info, 0/*DIB_RGB_COLORS*/, out this.bits, IntPtr.Zero, 0);

            Win32.SelectObject(mDC, hBitmap);

            //  Set parameters.
            this.Width = width;
            this.Height = height;
            this.HBitmap = hBitmap;
        }

        /// <summary>
        /// Destroys this instance.
        /// </summary>
        public virtual void DestroyBitmap() {
            //	Destroy the bitmap.
            IntPtr hBitmap = this.HBitmap;
            if (hBitmap != IntPtr.Zero) {
                this.HBitmap = IntPtr.Zero;
                Win32.DeleteObject(hBitmap);
            }
        }

    }
}