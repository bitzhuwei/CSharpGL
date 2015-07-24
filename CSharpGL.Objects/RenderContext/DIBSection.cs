using System;
using System.Runtime.InteropServices;

namespace CSharpGL.Objects.RenderContext
{
    /// <summary>
    /// device-independent bitmap
    /// </summary>
    public class DIBSection : IDisposable
    {
        /// <summary>
        /// Creates the specified width.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="bitCount">The bit count.</param>
        /// <returns></returns>
        public virtual bool Create(IntPtr hDC, int width, int height, int bitCount)
        {
            this.Width = width;
            this.Height = height;
            parentDC = hDC;

            //	Destroy existing objects.
            Destroy();

            //	Create a bitmap info structure.
            BITMAPINFO info = new BITMAPINFO();
            info.Init();

            //	Set the data.
            info.biBitCount = (short)bitCount;
            info.biPlanes = 1;
            info.biWidth = width;
            info.biHeight = height;

            //	Create the bitmap.
            HBitmap = Win32.CreateDIBSection(hDC, ref info, Win32.DIB_RGB_COLORS,
                out bits, IntPtr.Zero, 0);

            Win32.SelectObject(hDC, HBitmap);

            //	Set the OpenGL pixel format.
            SetPixelFormat(hDC, bitCount);

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
            Destroy();

            //  Set parameters.
            Width = width;
            Height = height;

            //	Create a bitmap info structure.
            BITMAPINFO info = new BITMAPINFO();
            info.Init();

            //	Set the data.
            info.biBitCount = (short)bitCount;
            info.biPlanes = 1;
            info.biWidth = width;
            info.biHeight = height;

            //	Create the bitmap.
            HBitmap = Win32.CreateDIBSection(parentDC, ref info, Win32.DIB_RGB_COLORS,
                out bits, IntPtr.Zero, 0);

            Win32.SelectObject(parentDC, HBitmap);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Destroy();
        }

        /// <summary>
        /// This function sets the pixel format of the underlying bitmap.
        /// </summary>
        /// <param name="bitCount">The bitcount.</param>
        protected virtual bool SetPixelFormat(IntPtr hDC, int bitCount)
        {
            //	Create the big lame pixel format majoo.
            PIXELFORMATDESCRIPTOR pixelFormat = new PIXELFORMATDESCRIPTOR();
            pixelFormat.Init();

            //	Set the values for the pixel format.
            pixelFormat.nVersion = 1;
            pixelFormat.dwFlags = (Win32.PFD_DRAW_TO_BITMAP | Win32.PFD_SUPPORT_OPENGL | Win32.PFD_SUPPORT_GDI);
            pixelFormat.iPixelType = Win32.PFD_TYPE_RGBA;
            pixelFormat.cColorBits = (byte)bitCount;
            pixelFormat.cDepthBits = 32;
            pixelFormat.iLayerType = Win32.PFD_MAIN_PLANE;

            //	Match an appropriate pixel format 
            int iPixelformat;
            if ((iPixelformat = Win32.ChoosePixelFormat(hDC, pixelFormat)) == 0)
                return false;

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
            if (HBitmap != IntPtr.Zero)
            {
                Win32.DeleteObject(HBitmap);
                HBitmap = IntPtr.Zero;
            }
        }

        /// <summary>
        /// The parent dc.
        /// </summary>
        protected IntPtr parentDC = IntPtr.Zero;

        /// <summary>
        /// The bits.
        /// </summary>
        protected IntPtr bits = IntPtr.Zero;

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