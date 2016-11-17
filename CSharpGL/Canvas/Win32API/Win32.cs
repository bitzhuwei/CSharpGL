using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Useful functions imported from the Win32 SDK.
    /// </summary>
    internal static partial class Win32
    {
        private static OpenGL32Library lib;

        static Win32()
        {
            lib = OpenGL32Library.Instance;
        }

        internal static IntPtr GetProcAddress(string name)
        {
            return Win32.GetProcAddress(OpenGL32Library.Instance.libPtr, name);
        }

        #region Kernel32 Functions

        [DllImport(kernel32, SetLastError = true)]
        internal static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport(kernel32, SetLastError = true)]
        internal extern static IntPtr GetProcAddress(IntPtr lib, String funcName);

        [DllImport(kernel32, SetLastError = true)]
        internal extern static bool FreeLibrary(IntPtr lib);

        #endregion Kernel32 Functions

        #region WGL Functions

        /// <summary>
        /// Gets the current render context.
        /// </summary>
        /// <returns>The current render context.</returns>
        [DllImport(opengl32, SetLastError = true)]
        internal static extern IntPtr wglGetCurrentContext();

        /// <summary>
        /// The wglGetCurrentDC function obtains a handle to the device context that is associated with the current OpenGL rendering context of the calling thread.
        /// </summary>
        /// <returns></returns>
        [DllImport(opengl32, SetLastError = true)]
        internal static extern IntPtr wglGetCurrentDC();

        /// <summary>
        /// Make the specified render context current.
        /// </summary>
        /// <param name="hdc">The handle to the device context.</param>
        /// <param name="hrc">The handle to the render context.</param>
        /// <returns></returns>
        [DllImport(opengl32, SetLastError = true)]
        internal static extern bool wglMakeCurrent(IntPtr hdc, IntPtr hrc);

        /// <summary>
        /// Creates a render context from the device context.
        /// </summary>
        /// <param name="hdc">The handle to the device context.</param>
        /// <returns>The handle to the render context.</returns>
        [DllImport(opengl32, SetLastError = true)]
        internal static extern IntPtr wglCreateContext(IntPtr hdc);

        /// <summary>
        /// Deletes the render context.
        /// </summary>
        /// <param name="hrc">The handle to the render context.</param>
        /// <returns></returns>
        [DllImport(opengl32, SetLastError = true)]
        internal static extern int wglDeleteContext(IntPtr hrc);

        /// <summary>
        /// Gets a proc address.
        /// </summary>
        /// <param name="name">The name of the function.</param>
        /// <returns>The address of the function.</returns>
        [DllImport(opengl32, SetLastError = true)]
        internal static extern IntPtr wglGetProcAddress(string name);

        /// <summary>
        /// The wglUseFontBitmaps function creates a set of bitmap display lists for use in the current OpenGL rendering context. The set of bitmap display lists is based on the glyphs in the currently selected font in the device context. You can then use bitmaps to draw characters in an OpenGL image.
        /// </summary>
        /// <param name="hDC">Specifies the device context whose currently selected font will be used to form the glyph bitmap display lists in the current OpenGL rendering context..</param>
        /// <param name="first">Specifies the first glyph in the run of glyphs that will be used to form glyph bitmap display lists.</param>
        /// <param name="count">Specifies the number of glyphs in the run of glyphs that will be used to form glyph bitmap display lists. The function creates count display lists, one for each glyph in the run.</param>
        /// <param name="listBase">Specifies a starting display list.</param>
        /// <returns>If the function succeeds, the return value is TRUE. If the function fails, the return value is FALSE. To get extended error information, call GetLastError.</returns>
        [DllImport(opengl32, SetLastError = true)]
        internal static extern bool wglUseFontBitmaps(IntPtr hDC, uint first, uint count, uint listBase);

        ///// <summary>
        ///// The wglUseFontOutlines function creates a set of display lists, one for each glyph of the currently selected outline font of a device context, for use with the current rendering context.
        ///// </summary>
        ///// <param name="hDC">The h DC.</param>
        ///// <param name="first">The first.</param>
        ///// <param name="count">The count.</param>
        ///// <param name="listBase">The list base.</param>
        ///// <param name="deviation">The deviation.</param>
        ///// <param name="extrusion">The extrusion.</param>
        ///// <param name="format">The format.</param>
        ///// <param name="lpgmf">The LPGMF.</param>
        ///// <returns></returns>
        //[DllImport(OpenGL32, SetLastError = true)]
        //internal static extern bool wglUseFontOutlines(IntPtr hDC, uint first, uint count, uint listBase,
        //    float deviation, float extrusion, int format, [Out, MarshalAs(UnmanagedType.LPArray)] GLYPHMETRICSFLOAT[] lpgmf);

        ///// <summary>
        ///// Link two render contexts so they share lists (buffer IDs, etc.)
        ///// </summary>
        ///// <param name="hrc1">The first context.</param>
        ///// <param name="hrc2">The second context.</param>
        ///// <returns>If the function succeeds, the return value is TRUE. If the function fails, the return value is FALSE.
        ///// To get extended error information, call GetLastError.</returns>
        //[DllImport(opengl32, SetLastError = true)]
        //internal static extern bool wglShareLists(IntPtr hrc1, IntPtr hrc2);

        #endregion WGL Functions

        #region PixelFormatDescriptor structure and flags.

        [DllImport(user32, SetLastError = true)]
        internal static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        [DllImport(user32, SetLastError = true)]
        internal static extern IntPtr CreateWindowEx(
           WindowStylesEx dwExStyle,
           string lpClassName,
           string lpWindowName,
           WindowStyles dwStyle,
           int x,
           int y,
           int nWidth,
           int nHeight,
           IntPtr hWndParent,
           IntPtr hMenu,
           IntPtr hInstance,
           IntPtr lpParam);

        #endregion PixelFormatDescriptor structure and flags.

        #region Win32 Function Definitions.

        //	Unmanaged functions from the Win32 graphics library.
        [DllImport(gdi32, SetLastError = true)]
        internal unsafe static extern int ChoosePixelFormat(IntPtr hDC,
            [In, MarshalAs(UnmanagedType.LPStruct)] PixelFormatDescriptor ppfd);

        [DllImport(gdi32, SetLastError = true)]
        internal unsafe static extern int SetPixelFormat(IntPtr hDC, int iPixelFormat,
            [In, MarshalAs(UnmanagedType.LPStruct)] PixelFormatDescriptor ppfd);

        //[DllImport(gdi32, SetLastError = true)]
        //internal static extern IntPtr GetStockObject(uint fnObject);

        [DllImport(gdi32, SetLastError = true)]
        internal static extern int SwapBuffers(IntPtr hDC);

        [DllImport(gdi32, SetLastError = true)]
        internal static extern bool BitBlt(IntPtr hDC, int x, int y, int width,
            int height, IntPtr hDCSource, int sourceX, int sourceY, uint type);

        [DllImport(gdi32, SetLastError = true)]
        internal static extern IntPtr CreateDIBSection(IntPtr hdc, [In] ref BitmapInfo pbmi,
           uint pila, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);

        [DllImport(gdi32, SetLastError = true)]
        internal static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport(gdi32, SetLastError = true)]
        internal static extern bool DeleteObject(IntPtr hObject);

        /// <summary>
        /// This function creates a memory device context (DC) compatible with the specified device.
        /// </summary>
        /// <param name="hDC">Handle to an existing device context.If this handle is NULL, the function creates a memory device context compatible with the application's current screen.</param>
        /// <returns>The handle to a memory device context indicates success. NULL indicates failure.</returns>
        [DllImport(gdi32, SetLastError = true)]
        internal static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport(gdi32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteDC(IntPtr hDC);

        [DllImport(gdi32, SetLastError = true)]
        internal static extern IntPtr CreateFont(int nHeight, int nWidth, int nEscapement,
           int nOrientation, uint fnWeight, uint fdwItalic, uint fdwUnderline, uint
           fdwStrikeOut, uint fdwCharSet, uint fdwOutputPrecision, uint
           fdwClipPrecision, uint fdwQuality, uint fdwPitchAndFamily, string lpszFace);

        #endregion Win32 Function Definitions.

        #region User32 Functions

        [DllImport(user32, SetLastError = true)]
        internal static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport(user32, SetLastError = true)]
        internal static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport(user32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DestroyWindow(IntPtr hWnd);

        [DllImport(user32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        [DllImport(user32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.U2)]
        internal static extern short RegisterClassEx([In] ref WNDCLASSEX lpwcx);

        #endregion User32 Functions
    }
}