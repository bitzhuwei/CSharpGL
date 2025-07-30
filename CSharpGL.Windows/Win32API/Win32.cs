using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace CSharpGL.Windows {
    /// <summary>
    /// Useful functions imported from the Win32 SDK.
    /// </summary>
    internal static partial class Win32 {

        private static readonly OpenGL32Library openGL32lib = OpenGL32Library.Instance;

        internal static IntPtr GetProcAddress(string procName) {
            var addr = Win32.GetProcAddress(openGL32lib.module, procName);
            return addr;
        }

        //  The names of the libraries we're importing.
        /// <summary>
        /// private const string kernel32 = "kernel32.dll";
        /// </summary>
        private const string kernel32 = "kernel32.dll";

        /// <summary>
        /// private const string gdi32 = "gdi32.dll"
        /// </summary>
        private const string gdi32 = "gdi32.dll";

        /// <summary>
        /// private const string user32 = "user32.dll"
        /// </summary>
        private const string user32 = "user32.dll";

        /// <summary>
        /// internal const string OpenGL32 = "opengl32.dll"
        /// </summary>
        internal const string opengl32 = "opengl32.dll";
        //Linux => new[] { "libGL.so.1" };
        //MacOS => new[] { "/System/Library/Frameworks/OpenGL.framework/OpenGL" };
        //Android => new[] { "libGL.so.1" };
        //IOS => new[] { "/System/Library/Frameworks/OpenGL.framework/OpenGL" };
        //Windows64 => new[] { "opengl32.dll" };
        //Windows86 => new[] { "opengl32.dll" };
        #region Kernel32 Functions

        [LibraryImport(kernel32, SetLastError = true, EntryPoint = "LoadLibraryW", StringMarshalling = StringMarshalling.Utf16)]
        internal static partial IntPtr LoadLibrary(string fileName);

        class MyStringMarshal {

        }

        [LibraryImport(kernel32, SetLastError = true, StringMarshalling = StringMarshalling.Utf8)]
        internal static partial IntPtr GetProcAddress(IntPtr module, String procName);

        [LibraryImport(kernel32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static partial bool FreeLibrary(IntPtr module);

        #endregion Kernel32 Functions

        #region WGL Functions

        /// <summary>
        /// Gets the current render context.
        /// </summary>
        /// <returns>The current render context.</returns>
        [LibraryImport(opengl32, SetLastError = true)]
        internal static partial IntPtr wglGetCurrentContext();

        /// <summary>
        /// The wglGetCurrentDC function obtains a handle to the device context that is associated with the current OpenGL rendering context of the calling thread.
        /// </summary>
        /// <returns></returns>
        [LibraryImport(opengl32, SetLastError = true)]
        internal static partial IntPtr wglGetCurrentDC();

        /// <summary>
        /// Make the specified render context current.
        /// </summary>
        /// <param name="hdc">The handle to the device context.</param>
        /// <param name="hrc">The handle to the render context.</param>
        /// <returns></returns>
        [LibraryImport(opengl32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static partial bool wglMakeCurrent(IntPtr hdc, IntPtr hrc);

        /// <summary>
        /// Creates a render context from the device context.
        /// </summary>
        /// <param name="hdc">The handle to the device context.</param>
        /// <returns>The handle to the render context.</returns>
        [LibraryImport(opengl32, SetLastError = true)]
        internal static partial IntPtr wglCreateContext(IntPtr hdc);

        /// <summary>
        /// Deletes the render context.
        /// </summary>
        /// <param name="hrc">The handle to the render context.</param>
        /// <returns></returns>
        [LibraryImport(opengl32, SetLastError = true)]
        internal static partial int wglDeleteContext(IntPtr hrc);

        /// <summary>
        /// Gets a proc address.
        /// </summary>
        /// <param name="name">The name of the function.</param>
        /// <returns>The address of the function.</returns>
        [LibraryImport(opengl32, SetLastError = true, StringMarshalling = StringMarshalling.Utf8)]
        internal static partial IntPtr wglGetProcAddress(string name);

        ///// <summary>
        ///// The wglUseFontBitmaps function creates a set of bitmap display lists for use in the current OpenGL rendering context. The set of bitmap display lists is based on the glyphs in the currently selected font in the device context. You can then use bitmaps to draw characters in an OpenGL image.
        ///// </summary>
        ///// <param name="hDC">Specifies the device context whose currently selected font will be used to form the glyph bitmap display lists in the current OpenGL rendering context..</param>
        ///// <param name="first">Specifies the first glyph in the run of glyphs that will be used to form glyph bitmap display lists.</param>
        ///// <param name="count">Specifies the number of glyphs in the run of glyphs that will be used to form glyph bitmap display lists. The function creates count display lists, one for each glyph in the run.</param>
        ///// <param name="listBase">Specifies a starting display list.</param>
        ///// <returns>If the function succeeds, the return value is TRUE. If the function fails, the return value is FALSE. To get extended error information, call GetLastError.</returns>
        //[LibraryImport(opengl32, SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //internal static partial bool wglUseFontBitmaps(IntPtr hDC, uint first, uint count, uint listBase);
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

        /// <summary>
        /// Link two render contexts so they share lists (buffer IDs, etc.)
        /// </summary>
        /// <param name="hrc1">The first context.</param>
        /// <param name="hrc2">The second context.</param>
        /// <returns>If the function succeeds, the return value is TRUE. If the function fails, the return value is FALSE.
        /// To get extended error information, call GetLastError.</returns>
        [LibraryImport(opengl32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static partial bool wglShareLists(IntPtr hrc1, IntPtr hrc2);

        #endregion WGL Functions

        #region PixelFormatDescriptor structure and flags.

        [LibraryImport(user32, SetLastError = true)]
        internal static partial IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        //[DllImport(user32, SetLastError = true)]
        //internal static extern IntPtr CreateWindowEx(
        //   WindowStylesEx dwExStyle,
        //   string lpClassName,
        //   string lpWindowName,
        //   WindowStyles dwStyle,
        //   int x,
        //   int y,
        //   int nWidth,
        //   int nHeight,
        //   IntPtr hWndParent,
        //   IntPtr hMenu,
        //   IntPtr hInstance,
        //   IntPtr lpParam);

        #endregion PixelFormatDescriptor structure and flags.

        #region Win32 Function Definitions.

        //	Unmanaged functions from the Win32 graphics library.
        [DllImport(gdi32, SetLastError = true)]
        internal unsafe static extern int ChoosePixelFormat(IntPtr hDC,
            [In, MarshalAs(UnmanagedType.LPStruct)] PixelFormatDescriptor ppfd);

        [DllImport(gdi32, SetLastError = true)]
        internal unsafe static extern bool SetPixelFormat(IntPtr hDC, int iPixelFormat,
            [In, MarshalAs(UnmanagedType.LPStruct)] PixelFormatDescriptor ppfd);

        //[DllImport(gdi32, SetLastError = true)]
        //internal static extern IntPtr GetStockObject(uint fnObject);

        [LibraryImport(gdi32, SetLastError = true)]
        internal static partial int SwapBuffers(IntPtr hDC);

        [LibraryImport(gdi32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static partial bool BitBlt(IntPtr hDC, int x, int y, int width,
            int height, IntPtr hDCSource, int sourceX, int sourceY, uint type);

        [LibraryImport(gdi32, SetLastError = true)]
        internal static partial IntPtr CreateDIBSection(IntPtr hdc, ref BitmapInfo pbmi,
           uint pila, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);

        [LibraryImport(gdi32, SetLastError = true)]
        internal static partial IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [LibraryImport(gdi32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static partial bool DeleteObject(IntPtr hObject);

        /// <summary>
        /// This function creates a memory device context (DC) compatible with the specified device.
        /// </summary>
        /// <param name="hDC">Handle to an existing device context.If this handle is NULL, the function creates a memory device context compatible with the application's current screen.</param>
        /// <returns>The handle to a memory device context indicates success. NULL indicates failure.</returns>
        [LibraryImport(gdi32, SetLastError = true)]
        internal static partial IntPtr CreateCompatibleDC(IntPtr hDC);

        [LibraryImport(gdi32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static partial bool DeleteDC(IntPtr hDC);

        //[LibraryImport(gdi32, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
        //internal static partial IntPtr CreateFont(int nHeight, int nWidth, int nEscapement,
        //   int nOrientation, uint fnWeight, uint fdwItalic, uint fdwUnderline, uint
        //   fdwStrikeOut, uint fdwCharSet, uint fdwOutputPrecision, uint
        //   fdwClipPrecision, uint fdwQuality, uint fdwPitchAndFamily, string lpszFace);
        [DllImport(gdi32, SetLastError = true)]
        internal static extern IntPtr CreateFont(int nHeight, int nWidth, int nEscapement,
          int nOrientation, uint fnWeight, uint fdwItalic, uint fdwUnderline, uint
          fdwStrikeOut, uint fdwCharSet, uint fdwOutputPrecision, uint
          fdwClipPrecision, uint fdwQuality, uint fdwPitchAndFamily, string lpszFace);


        #endregion Win32 Function Definitions.

        #region User32 Functions

        [LibraryImport(user32, SetLastError = true)]
        internal static partial IntPtr GetDC(IntPtr hWnd);

        [LibraryImport(user32, SetLastError = true)]
        internal static partial int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        //[LibraryImport(user32, SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //internal static partial bool DestroyWindow(IntPtr hWnd);

        //[DllImport(user32, SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        //[DllImport(user32, SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.U2)]
        //internal static extern short RegisterClassEx([In] ref WNDCLASSEX lpwcx);

        #endregion User32 Functions
    }
}