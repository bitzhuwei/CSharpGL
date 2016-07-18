using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// device-independent bitmap
    /// </summary>
    class DIBSection : IDisposable
    {
        /// <summary>
        /// Creates the specified width.
        /// </summary>
        /// <param name="deviceContext"></param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="bitCount">The bit count.</param>
        /// <returns></returns>
        public virtual bool Create(IntPtr deviceContext, int width, int height, int bitCount)
        {
            this.Width = width;
            this.Height = height;
            this.DibSectionDeviceContext = Win32.CreateCompatibleDC(deviceContext);

            //	Destroy existing objects.
            this.Destroy();

            //	Create a bitmap info structure.
            var info = new BitmapInfo();
            info.Init();

            //	Set the data.
            info.biBitCount = (short)bitCount;
            info.biPlanes = 1;
            info.biWidth = width;
            info.biHeight = height;

            //	Create the bitmap.
            this.HBitmap = Win32.CreateDIBSection(deviceContext, ref info, Win32.DIB_RGB_COLORS,
                out this.bits, IntPtr.Zero, 0);

            Win32.SelectObject(deviceContext, this.HBitmap);

            //	Set the OpenGL pixel format.
            SetPixelFormat(deviceContext, bitCount);

            return true;
        }

        /// <summary>
        /// Resizes the section.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="bitCount">The bit count.</param>
        public void Resize(int width, int height, int bitCount)
        {
            //	Destroy existing objects.
            this.Destroy();

            //  Set parameters.
            this.Width = width;
            this.Height = height;

            //	Create a bitmap info structure.
            var info = new BitmapInfo();
            info.Init();

            //	Set the data.
            info.biBitCount = (short)bitCount;
            info.biPlanes = 1;
            info.biWidth = width;
            info.biHeight = height;

            //	Create the bitmap.
            this.HBitmap = Win32.CreateDIBSection(this.DibSectionDeviceContext, ref info, Win32.DIB_RGB_COLORS,
                out this.bits, IntPtr.Zero, 0);

            Win32.SelectObject(this.DibSectionDeviceContext, this.HBitmap);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Destroy();
        }

        /// <summary>
        /// This function sets the pixel format of the underlying bitmap.
        /// </summary>
        /// <param name="hDC"></param>
        /// <param name="bitCount">The bitcount.</param>
        protected virtual bool SetPixelFormat(IntPtr hDC, int bitCount)
        {
            //	Create the big lame pixel format majoo.
            var pixelFormat = new PixelFormatDescriptor();
            pixelFormat.Init();

            //	Set the values for the pixel format.
            pixelFormat.nVersion = 1;
            pixelFormat.dwFlags = (Win32.PFD_DRAW_TO_BITMAP | Win32.PFD_SUPPORT_OPENGL | Win32.PFD_SUPPORT_GDI);
            pixelFormat.iPixelType = Win32.PFD_TYPE_RGBA;
            pixelFormat.cColorBits = (byte)bitCount;
            pixelFormat.cDepthBits = 32;
            pixelFormat.iLayerType = Win32.PFD_MAIN_PLANE;

            //	Match an appropriate pixel format 
            int iPixelformat = Win32.ChoosePixelFormat(hDC, pixelFormat);
            if (iPixelformat == 0) { return false; }

            //	Sets the pixel format
            if (Win32.SetPixelFormat(hDC, iPixelformat, pixelFormat) == 0)
            {
                int lastError = Marshal.GetLastWin32Error();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Destroys this instance.
        /// </summary>
        public virtual void Destroy()
        {
            //	Destroy the bitmap.
            if (this.HBitmap != IntPtr.Zero)
            {
                Win32.DeleteObject(this.HBitmap);
                this.HBitmap = IntPtr.Zero;
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
        public IntPtr DibSectionDeviceContext { get; private set; }

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