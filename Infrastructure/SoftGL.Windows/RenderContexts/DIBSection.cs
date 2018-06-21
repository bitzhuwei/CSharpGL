using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// device-independent bitmap
    /// </summary>
    partial class DIBSection : IDisposable
    {
        /// <summary>
        /// Creates the specified width.
        /// </summary>
        /// <param name="deviceContext"></param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="parameters">parameters.</param>
        public DIBSection(IntPtr deviceContext, int width, int height, ContextGenerationParams parameters)
        {
            this.Width = width;
            this.Height = height;
            //this.MemoryDeviceContext = Win32.CreateCompatibleDC(deviceContext);

            //	Destroy existing objects.
            this.DestroyBitmap();

            ////	Create a bitmap info structure.
            //var info = new BitmapInfo();
            //info.Init();

            ////	Set the data.
            //info.biBitCount = parameters.ColorBits;
            //info.biPlanes = 1;
            //info.biWidth = width;
            //info.biHeight = height;

            ////	Create the bitmap.
            //IntPtr mdc = this.MemoryDeviceContext;
            //this.HBitmap = Win32.CreateDIBSection(mdc, ref info, Win32.DIB_RGB_COLORS, out this.bits, IntPtr.Zero, 0);

            //Win32.SelectObject(mdc, this.HBitmap);

            ////	Set the OpenGL pixel format.
            //this.SetPixelFormat(mdc, parameters);
        }

        /// <summary>
        /// Resizes the section.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="parameters">parameters.</param>
        public void Resize(int width, int height, ContextGenerationParams parameters)
        {
            //	Destroy existing objects.
            this.DestroyBitmap();

            //  Set parameters.
            this.Width = width;
            this.Height = height;

            ////	Create a bitmap info structure.
            //var info = new BitmapInfo();
            //info.Init();

            ////	Set the data.
            //info.biBitCount = parameters.ColorBits;
            //info.biPlanes = 1;
            //info.biWidth = width;
            //info.biHeight = height;

            ////	Create the bitmap.
            //IntPtr mdc = this.MemoryDeviceContext;
            //this.HBitmap = Win32.CreateDIBSection(mdc, ref info, Win32.DIB_RGB_COLORS, out this.bits, IntPtr.Zero, 0);

            //Win32.SelectObject(mdc, this.HBitmap);
        }

        /// <summary>
        /// This function sets the pixel format of the underlying bitmap.
        /// </summary>
        /// <param name="hDC"></param>
        /// <param name="parameters">parameters.</param>
        protected void SetPixelFormat(IntPtr hDC, ContextGenerationParams parameters)
        {
            //	Create the big lame pixel format majoo.
            //var pdf = new PixelFormatDescriptor();
            //pdf.Init();

            ////	Set the values for the pixel format.
            //pdf.nVersion = 1;
            //pdf.dwFlags = (Win32.PFD_DRAW_TO_BITMAP | Win32.PFD_SUPPORT_OPENGL | Win32.PFD_SUPPORT_GDI);
            //pdf.iPixelType = Win32.PFD_TYPE_RGBA;
            //pdf.cColorBits = parameters.ColorBits;
            //pdf.cDepthBits = parameters.DepthBits;
            //pdf.cStencilBits = parameters.StencilBits;
            //pdf.iLayerType = Win32.PFD_MAIN_PLANE;

            ////	Match an appropriate pixel format
            //int iPixelformat = Win32.ChoosePixelFormat(hDC, pdf);
            //if (iPixelformat == 0) { throw new Exception(string.Format("ChoosePixelFormat([{0}], [{1}]) failed!", hDC, pdf)); }

            ////	Sets the pixel format
            //if (false == Win32.SetPixelFormat(hDC, iPixelformat, pdf))
            //{
            //    int lastError = Marshal.GetLastWin32Error();
            //    throw new Exception(string.Format("SetPixelFormat([{0}], [{1}], [{2}]) failed! Win32Error:[{3}].", hDC, iPixelformat, pdf, lastError));
            //}
        }

        /// <summary>
        /// Destroys this instance.
        /// </summary>
        public virtual void DestroyBitmap()
        {
            //	Destroy the bitmap.
            IntPtr hBitmap = this.HBitmap;
            if (hBitmap != IntPtr.Zero)
            {
                this.HBitmap = IntPtr.Zero;
                //Win32.DeleteObject(hBitmap);
            }
        }

        ///// <summary>
        ///// The parent dc.
        ///// </summary>
        //protected IntPtr parentDC = IntPtr.Zero;

        /// <summary>
        /// The bits.
        /// </summary>
        protected IntPtr bits = IntPtr.Zero;

        /// <summary>
        /// parentDC
        /// </summary>
        public IntPtr MemoryDeviceContext { get; private set; }

        /// <summary>
        /// Gets the handle to the bitmap.
        /// </summary>
        /// <value>The handle to the bitmap.</value>
        public IntPtr HBitmap { get; protected set; }

        /// <summary>
        /// Gets the bits.
        /// </summary>
        public IntPtr Bits
        {
            get { return bits; }
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; protected set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; protected set; }
    }
}