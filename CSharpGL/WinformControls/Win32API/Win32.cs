using System;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// Useful functions imported from the Win32 SDK.
    /// </summary>
    public sealed class Win32
    {

        private Win32() { }

        /// <summary>
        /// glLibrary = Win32.LoadLibrary(OpenGL32);
        /// </summary>
        public static readonly IntPtr opengl32Library;
        /// <summary>
        /// Initializes the <see cref="Win32"/> class.
        /// </summary>
        static Win32()
        {
            //  Load the openGL library - without this wgl calls will fail.
            opengl32Library = Win32.LoadLibrary(OpenGL32);
        }
        ~Win32()
        {
            FreeLibrary(opengl32Library);
        }

        //  The names of the libraries we're importing.
        /// <summary>
        /// public const string Kernel32 = "kernel32.dll";
        /// </summary>
        public const string Kernel32 = "kernel32.dll";
        /// <summary>
        /// public const string Kernel32 = "opengl32.dll"
        /// </summary>
        public const string OpenGL32 = "opengl32.dll";
        /// <summary>
        /// public const string Kernel32 = "Glu32.dll"
        /// </summary>
        public const string Glu32 = "Glu32.dll";
        /// <summary>
        /// public const string Kernel32 = "gdi32.dll"
        /// </summary>
        public const string Gdi32 = "gdi32.dll";
        /// <summary>
        /// public const string Kernel32 = "user32.dll"
        /// </summary>
        public const string User32 = "user32.dll";

        #region Kernel32 Functions

        [DllImport(Kernel32, SetLastError = true)]
        public static extern IntPtr LoadLibrary(string lpFileName);

        internal static IntPtr GetProcAddress(string funcName)
        {
            IntPtr result = GetProcAddress(Win32.opengl32Library, funcName);

            return result;
        }

        [DllImport(Kernel32, SetLastError = true)]
        public extern static IntPtr GetProcAddress(IntPtr lib, String funcName);

        [DllImport(Kernel32, SetLastError = true)]
        public extern static bool FreeLibrary(IntPtr lib);

        #endregion

        #region WGL Functions

        /// <summary>
        /// Gets the current render context.
        /// </summary>
        /// <returns>The current render context.</returns>
        [DllImport(OpenGL32, SetLastError = true)]
        public static extern IntPtr wglGetCurrentContext();

        /// <summary>
        /// The wglGetCurrentDC function obtains a handle to the device context that is associated with the current OpenGL rendering context of the calling thread.
        /// </summary>
        /// <returns></returns>
        [DllImport(OpenGL32, SetLastError = true)]
        public static extern IntPtr wglGetCurrentDC();
        /// <summary>
        /// Make the specified render context current.
        /// </summary>
        /// <param name="hdc">The handle to the device context.</param>
        /// <param name="hrc">The handle to the render context.</param>
        /// <returns></returns>
        [DllImport(OpenGL32, SetLastError = true)]
        public static extern bool wglMakeCurrent(IntPtr hdc, IntPtr hrc);

        /// <summary>
        /// Creates a render context from the device context.
        /// </summary>
        /// <param name="hdc">The handle to the device context.</param>
        /// <returns>The handle to the render context.</returns>
        [DllImport(OpenGL32, SetLastError = true)]
        public static extern IntPtr wglCreateContext(IntPtr hdc);

        /// <summary>
        /// Deletes the render context.
        /// </summary>
        /// <param name="hrc">The handle to the render context.</param>
        /// <returns></returns>
        [DllImport(OpenGL32, SetLastError = true)]
        public static extern int wglDeleteContext(IntPtr hrc);

        /// <summary>
        /// Gets a proc address.
        /// </summary>
        /// <param name="name">The name of the function.</param>
        /// <returns>The address of the function.</returns>
        [DllImport(OpenGL32, SetLastError = true)]
        public static extern IntPtr wglGetProcAddress(string name);

        /// <summary>
        /// The wglUseFontBitmaps function creates a set of bitmap display lists for use in the current OpenGL rendering context. The set of bitmap display lists is based on the glyphs in the currently selected font in the device context. You can then use bitmaps to draw characters in an OpenGL image.
        /// </summary>
        /// <param name="hDC">Specifies the device context whose currently selected font will be used to form the glyph bitmap display lists in the current OpenGL rendering context..</param>
        /// <param name="first">Specifies the first glyph in the run of glyphs that will be used to form glyph bitmap display lists.</param>
        /// <param name="count">Specifies the number of glyphs in the run of glyphs that will be used to form glyph bitmap display lists. The function creates count display lists, one for each glyph in the run.</param>
        /// <param name="listBase">Specifies a starting display list.</param>
        /// <returns>If the function succeeds, the return value is TRUE. If the function fails, the return value is FALSE. To get extended error information, call GetLastError.</returns>
        [DllImport(OpenGL32, SetLastError = true)]
        public static extern bool wglUseFontBitmaps(IntPtr hDC, uint first, uint count, uint listBase);

        /// <summary>
        /// The wglUseFontOutlines function creates a set of display lists, one for each glyph of the currently selected outline font of a device context, for use with the current rendering context.
        /// </summary>
        /// <param name="hDC">The h DC.</param>
        /// <param name="first">The first.</param>
        /// <param name="count">The count.</param>
        /// <param name="listBase">The list base.</param>
        /// <param name="deviation">The deviation.</param>
        /// <param name="extrusion">The extrusion.</param>
        /// <param name="format">The format.</param>
        /// <param name="lpgmf">The LPGMF.</param>
        /// <returns></returns>
        [DllImport(OpenGL32, SetLastError = true)]
        public static extern bool wglUseFontOutlines(IntPtr hDC, uint first, uint count, uint listBase,
            float deviation, float extrusion, int format, [Out, MarshalAs(UnmanagedType.LPArray)] GLYPHMETRICSFLOAT[] lpgmf);

        /// <summary>
        /// Link two render contexts so they share lists (buffer IDs, etc.)
        /// </summary>
        /// <param name="hrc1">The first context.</param>
        /// <param name="hrc2">The second context.</param>
        /// <returns>If the function succeeds, the return value is TRUE. If the function fails, the return value is FALSE. 
        /// To get extended error information, call GetLastError.</returns>
        [DllImport(OpenGL32, SetLastError = true)]
        public static extern bool wglShareLists(IntPtr hrc1, IntPtr hrc2);

        #endregion

        #region PixelFormatDescriptor structure and flags.

        public const byte PFD_TYPE_RGBA = 0;
        public const byte PFD_TYPE_COLORINDEX = 1;

        public const uint PFD_DOUBLEBUFFER = 1;
        public const uint PFD_STEREO = 2;
        public const uint PFD_DRAW_TO_WINDOW = 4;
        public const uint PFD_DRAW_TO_BITMAP = 8;
        public const uint PFD_SUPPORT_GDI = 16;
        public const uint PFD_SUPPORT_OPENGL = 32;
        public const uint PFD_GENERIC_FORMAT = 64;
        public const uint PFD_NEED_PALETTE = 128;
        public const uint PFD_NEED_SYSTEM_PALETTE = 256;
        public const uint PFD_SWAP_EXCHANGE = 512;
        public const uint PFD_SWAP_COPY = 1024;
        public const uint PFD_SWAP_LAYER_BUFFERS = 2048;
        public const uint PFD_GENERIC_ACCELERATED = 4096;
        public const uint PFD_SUPPORT_DIRECTDRAW = 8192;

        public const sbyte PFD_MAIN_PLANE = 0;
        public const sbyte PFD_OVERLAY_PLANE = 1;
        public const sbyte PFD_UNDERLAY_PLANE = -1;


        [DllImport(User32, SetLastError = true)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        [DllImport(User32, SetLastError = true)]
        public static extern IntPtr CreateWindowEx(
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

        #endregion

        #region Win32 Function Definitions.

        //	Unmanaged functions from the Win32 graphics library.
        [DllImport(Gdi32, SetLastError = true)]
        public unsafe static extern int ChoosePixelFormat(IntPtr hDC,
            [In, MarshalAs(UnmanagedType.LPStruct)] PIXELFORMATDESCRIPTOR ppfd);

        [DllImport(Gdi32, SetLastError = true)]
        public unsafe static extern int SetPixelFormat(IntPtr hDC, int iPixelFormat,
            [In, MarshalAs(UnmanagedType.LPStruct)] PIXELFORMATDESCRIPTOR ppfd);

        [DllImport(Gdi32, SetLastError = true)]
        public static extern IntPtr GetStockObject(uint fnObject);

        [DllImport(Gdi32, SetLastError = true)]
        public static extern int SwapBuffers(IntPtr hDC);

        [DllImport(Gdi32, SetLastError = true)]
        public static extern bool BitBlt(IntPtr hDC, int x, int y, int width,
            int height, IntPtr hDCSource, int sourceX, int sourceY, uint type);

        [DllImport(Gdi32, SetLastError = true)]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, [In] ref BITMAPINFO pbmi,
           uint pila, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);

        [DllImport(Gdi32, SetLastError = true)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport(Gdi32, SetLastError = true)]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport(Gdi32, SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport(Gdi32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteDC(IntPtr hDC);

        [DllImport(Gdi32, SetLastError = true)]
        public static extern IntPtr CreateFont(int nHeight, int nWidth, int nEscapement,
           int nOrientation, uint fnWeight, uint fdwItalic, uint fdwUnderline, uint
           fdwStrikeOut, uint fdwCharSet, uint fdwOutputPrecision, uint
           fdwClipPrecision, uint fdwQuality, uint fdwPitchAndFamily, string lpszFace);

        #endregion

        #region User32 Functions

        [DllImport(User32, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport(User32, SetLastError = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport(User32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DestroyWindow(IntPtr hWnd);

        [DllImport(User32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        [DllImport(User32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.U2)]
        public static extern short RegisterClassEx([In] ref WNDCLASSEX lpwcx);

        #endregion



        #region Windows Messages

        public const int WM_ACTIVATE = 0x0006;
        public const int WM_ACTIVATEAPP = 0x001C;
        public const int WM_AFXFIRST = 0x0360;
        public const int WM_AFXLAST = 0x037F;
        public const int WM_APP = 0x8000;
        public const int WM_ASKCBFORMATNAME = 0x030C;
        public const int WM_CANCELJOURNAL = 0x004B;
        public const int WM_CANCELMODE = 0x001F;
        public const int WM_CAPTURECHANGED = 0x0215;
        public const int WM_CHANGECBCHAIN = 0x030D;
        public const int WM_CHANGEUISTATE = 0x0127;
        public const int WM_CHAR = 0x0102;
        public const int WM_CHARTOITEM = 0x002F;
        public const int WM_CHILDACTIVATE = 0x0022;
        public const int WM_CLEAR = 0x0303;
        public const int WM_CLOSE = 0x0010;
        public const int WM_COMMAND = 0x0111;
        public const int WM_COMPACTING = 0x0041;
        public const int WM_COMPAREITEM = 0x0039;
        public const int WM_CONTEXTMENU = 0x007B;
        public const int WM_COPY = 0x0301;
        public const int WM_COPYDATA = 0x004A;
        public const int WM_CREATE = 0x0001;
        public const int WM_CTLCOLORBTN = 0x0135;
        public const int WM_CTLCOLORDLG = 0x0136;
        public const int WM_CTLCOLOREDIT = 0x0133;
        public const int WM_CTLCOLORLISTBOX = 0x0134;
        public const int WM_CTLCOLORMSGBOX = 0x0132;
        public const int WM_CTLCOLORSCROLLBAR = 0x0137;
        public const int WM_CTLCOLORSTATIC = 0x0138;
        public const int WM_CUT = 0x0300;
        public const int WM_DEADCHAR = 0x0103;
        public const int WM_DELETEITEM = 0x002D;
        public const int WM_DESTROY = 0x0002;
        public const int WM_DESTROYCLIPBOARD = 0x0307;
        public const int WM_DEVICECHANGE = 0x0219;
        public const int WM_DEVMODECHANGE = 0x001B;
        public const int WM_DISPLAYCHANGE = 0x007E;
        public const int WM_DRAWCLIPBOARD = 0x0308;
        public const int WM_DRAWITEM = 0x002B;
        public const int WM_DROPFILES = 0x0233;
        public const int WM_ENABLE = 0x000A;
        public const int WM_ENDSESSION = 0x0016;
        public const int WM_ENTERIDLE = 0x0121;
        public const int WM_ENTERMENULOOP = 0x0211;
        public const int WM_ENTERSIZEMOVE = 0x0231;
        public const int WM_ERASEBKGND = 0x0014;
        public const int WM_EXITMENULOOP = 0x0212;
        public const int WM_EXITSIZEMOVE = 0x0232;
        public const int WM_FONTCHANGE = 0x001D;
        public const int WM_GETDLGCODE = 0x0087;
        public const int WM_GETFONT = 0x0031;
        public const int WM_GETHOTKEY = 0x0033;
        public const int WM_GETICON = 0x007F;
        public const int WM_GETMINMAXINFO = 0x0024;
        public const int WM_GETOBJECT = 0x003D;
        public const int WM_GETTEXT = 0x000D;
        public const int WM_GETTEXTLENGTH = 0x000E;
        public const int WM_HANDHELDFIRST = 0x0358;
        public const int WM_HANDHELDLAST = 0x035F;
        public const int WM_HELP = 0x0053;
        public const int WM_HOTKEY = 0x0312;
        public const int WM_HSCROLL = 0x0114;
        public const int WM_HSCROLLCLIPBOARD = 0x030E;
        public const int WM_ICONERASEBKGND = 0x0027;
        public const int WM_IME_CHAR = 0x0286;
        public const int WM_IME_COMPOSITION = 0x010F;
        public const int WM_IME_COMPOSITIONFULL = 0x0284;
        public const int WM_IME_CONTROL = 0x0283;
        public const int WM_IME_ENDCOMPOSITION = 0x010E;
        public const int WM_IME_KEYDOWN = 0x0290;
        public const int WM_IME_KEYLAST = 0x010F;
        public const int WM_IME_KEYUP = 0x0291;
        public const int WM_IME_NOTIFY = 0x0282;
        public const int WM_IME_REQUEST = 0x0288;
        public const int WM_IME_SELECT = 0x0285;
        public const int WM_IME_SETCONTEXT = 0x0281;
        public const int WM_IME_STARTCOMPOSITION = 0x010D;
        public const int WM_INITDIALOG = 0x0110;
        public const int WM_INITMENU = 0x0116;
        public const int WM_INITMENUPOPUP = 0x0117;
        public const int WM_INPUTLANGCHANGE = 0x0051;
        public const int WM_INPUTLANGCHANGEREQUEST = 0x0050;
        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYFIRST = 0x0100;
        public const int WM_KEYLAST = 0x0108;
        public const int WM_KEYUP = 0x0101;
        public const int WM_KILLFOCUS = 0x0008;
        public const int WM_LBUTTONDBLCLK = 0x0203;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_MBUTTONDBLCLK = 0x0209;
        public const int WM_MBUTTONDOWN = 0x0207;
        public const int WM_MBUTTONUP = 0x0208;
        public const int WM_MDIACTIVATE = 0x0222;
        public const int WM_MDICASCADE = 0x0227;
        public const int WM_MDICREATE = 0x0220;
        public const int WM_MDIDESTROY = 0x0221;
        public const int WM_MDIGETACTIVE = 0x0229;
        public const int WM_MDIICONARRANGE = 0x0228;
        public const int WM_MDIMAXIMIZE = 0x0225;
        public const int WM_MDINEXT = 0x0224;
        public const int WM_MDIREFRESHMENU = 0x0234;
        public const int WM_MDIRESTORE = 0x0223;
        public const int WM_MDISETMENU = 0x0230;
        public const int WM_MDITILE = 0x0226;
        public const int WM_MEASUREITEM = 0x002C;
        public const int WM_MENUCHAR = 0x0120;
        public const int WM_MENUCOMMAND = 0x0126;
        public const int WM_MENUDRAG = 0x0123;
        public const int WM_MENUGETOBJECT = 0x0124;
        public const int WM_MENURBUTTONUP = 0x0122;
        public const int WM_MENUSELECT = 0x011F;
        public const int WM_MOUSEACTIVATE = 0x0021;
        public const int WM_MOUSEFIRST = 0x0200;
        public const int WM_MOUSEHOVER = 0x02A1;
        public const int WM_MOUSELAST = 0x020D;
        public const int WM_MOUSELEAVE = 0x02A3;
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_MOUSEWHEEL = 0x020A;
        public const int WM_MOUSEHWHEEL = 0x020E;
        public const int WM_MOVE = 0x0003;
        public const int WM_MOVING = 0x0216;
        public const int WM_NCACTIVATE = 0x0086;
        public const int WM_NCCALCSIZE = 0x0083;
        public const int WM_NCCREATE = 0x0081;
        public const int WM_NCDESTROY = 0x0082;
        public const int WM_NCHITTEST = 0x0084;
        public const int WM_NCLBUTTONDBLCLK = 0x00A3;
        public const int WM_NCLBUTTONDOWN = 0x00A1;
        public const int WM_NCLBUTTONUP = 0x00A2;
        public const int WM_NCMBUTTONDBLCLK = 0x00A9;
        public const int WM_NCMBUTTONDOWN = 0x00A7;
        public const int WM_NCMBUTTONUP = 0x00A8;
        public const int WM_NCMOUSEMOVE = 0x00A0;
        public const int WM_NCPAINT = 0x0085;
        public const int WM_NCRBUTTONDBLCLK = 0x00A6;
        public const int WM_NCRBUTTONDOWN = 0x00A4;
        public const int WM_NCRBUTTONUP = 0x00A5;
        public const int WM_NEXTDLGCTL = 0x0028;
        public const int WM_NEXTMENU = 0x0213;
        public const int WM_NOTIFY = 0x004E;
        public const int WM_NOTIFYFORMAT = 0x0055;
        public const int WM_NULL = 0x0000;
        public const int WM_PAINT = 0x000F;
        public const int WM_PAINTCLIPBOARD = 0x0309;
        public const int WM_PAINTICON = 0x0026;
        public const int WM_PALETTECHANGED = 0x0311;
        public const int WM_PALETTEISCHANGING = 0x0310;
        public const int WM_PARENTNOTIFY = 0x0210;
        public const int WM_PASTE = 0x0302;
        public const int WM_PENWINFIRST = 0x0380;
        public const int WM_PENWINLAST = 0x038F;
        public const int WM_POWER = 0x0048;
        public const int WM_POWERBROADCAST = 0x0218;
        public const int WM_PRINT = 0x0317;
        public const int WM_PRINTCLIENT = 0x0318;
        public const int WM_QUERYDRAGICON = 0x0037;
        public const int WM_QUERYENDSESSION = 0x0011;
        public const int WM_QUERYNEWPALETTE = 0x030F;
        public const int WM_QUERYOPEN = 0x0013;
        public const int WM_QUEUESYNC = 0x0023;
        public const int WM_QUIT = 0x0012;
        public const int WM_RBUTTONDBLCLK = 0x0206;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_RBUTTONUP = 0x0205;
        public const int WM_RENDERALLFORMATS = 0x0306;
        public const int WM_RENDERFORMAT = 0x0305;
        public const int WM_SETCURSOR = 0x0020;
        public const int WM_SETFOCUS = 0x0007;
        public const int WM_SETFONT = 0x0030;
        public const int WM_SETHOTKEY = 0x0032;
        public const int WM_SETICON = 0x0080;
        public const int WM_SETREDRAW = 0x000B;
        public const int WM_SETTEXT = 0x000C;
        public const int WM_SETTINGCHANGE = 0x001A;
        public const int WM_SHOWWINDOW = 0x0018;
        public const int WM_SIZE = 0x0005;
        public const int WM_SIZECLIPBOARD = 0x030B;
        public const int WM_SIZING = 0x0214;
        public const int WM_SPOOLERSTATUS = 0x002A;
        public const int WM_STYLECHANGED = 0x007D;
        public const int WM_STYLECHANGING = 0x007C;
        public const int WM_SYNCPAINT = 0x0088;
        public const int WM_SYSCHAR = 0x0106;
        public const int WM_SYSCOLORCHANGE = 0x0015;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int WM_SYSDEADCHAR = 0x0107;
        public const int WM_SYSKEYDOWN = 0x0104;
        public const int WM_SYSKEYUP = 0x0105;
        public const int WM_TCARD = 0x0052;
        public const int WM_TIMECHANGE = 0x001E;
        public const int WM_TIMER = 0x0113;
        public const int WM_UNDO = 0x0304;
        public const int WM_UNINITMENUPOPUP = 0x0125;
        public const int WM_USER = 0x0400;
        public const int WM_USERCHANGED = 0x0054;
        public const int WM_VKEYTOITEM = 0x002E;
        public const int WM_VSCROLL = 0x0115;
        public const int WM_VSCROLLCLIPBOARD = 0x030A;
        public const int WM_WINDOWPOSCHANGED = 0x0047;
        public const int WM_WINDOWPOSCHANGING = 0x0046;
        public const int WM_WININICHANGE = 0x001A;
        public const int WM_XBUTTONDBLCLK = 0x020D;
        public const int WM_XBUTTONDOWN = 0x020B;
        public const int WM_XBUTTONUP = 0x020C;

        #endregion

        public const uint WHITE_BRUSH = 0;
        public const uint LTGRAY_BRUSH = 1;
        public const uint GRAY_BRUSH = 2;
        public const uint DKGRAY_BRUSH = 3;
        public const uint BLACK_BRUSH = 4;
        public const uint NULL_BRUSH = 5;
        public const uint HOLLOW_BRUSH = NULL_BRUSH;
        public const uint WHITE_PEN = 6;
        public const uint BLACK_PEN = 7;
        public const uint NULL_PEN = 8;
        public const uint OEM_FIXED_FONT = 10;
        public const uint ANSI_FIXED_FONT = 11;
        public const uint ANSI_VAR_FONT = 12;
        public const uint SYSTEM_FONT = 13;
        public const uint DEVICE_DEFAULT_FONT = 14;
        public const uint DEFAULT_PALETTE = 15;
        public const uint SYSTEM_FIXED_FONT = 16;
        public const uint DEFAULT_GUI_FONT = 17;
        public const uint DC_BRUSH = 18;
        public const uint DC_PEN = 19;

        public const uint DEFAULT_PITCH = 0;
        public const uint FIXED_PITCH = 1;
        public const uint VARIABLE_PITCH = 2;

        public const uint DEFAULT_QUALITY = 0;
        public const uint DRAFT_QUALITY = 1;
        public const uint PROOF_QUALITY = 2;
        public const uint NONANTIALIASED_QUALITY = 3;
        public const uint ANTIALIASED_QUALITY = 4;
        public const uint CLEARTYPE_QUALITY = 5;
        public const uint CLEARTYPE_NATURAL_QUALITY = 6;

        public const uint CLIP_DEFAULT_PRECIS = 0;
        public const uint CLIP_CHARACTER_PRECIS = 1;
        public const uint CLIP_STROKE_PRECIS = 2;
        public const uint CLIP_MASK = 0xf;

        public const uint OUT_DEFAULT_PRECIS = 0;
        public const uint OUT_STRING_PRECIS = 1;
        public const uint OUT_CHARACTER_PRECIS = 2;
        public const uint OUT_STROKE_PRECIS = 3;
        public const uint OUT_TT_PRECIS = 4;
        public const uint OUT_DEVICE_PRECIS = 5;
        public const uint OUT_RASTER_PRECIS = 6;
        public const uint OUT_TT_ONLY_PRECIS = 7;
        public const uint OUT_OUTLINE_PRECIS = 8;
        public const uint OUT_SCREEN_OUTLINE_PRECIS = 9;
        public const uint OUT_PS_ONLY_PRECIS = 10;

        public const uint ANSI_CHARSET = 0;
        public const uint DEFAULT_CHARSET = 1;
        public const uint SYMBOL_CHARSET = 2;

        public const uint FW_DONTCARE = 0;
        public const uint FW_THIN = 100;
        public const uint FW_EXTRALIGHT = 200;
        public const uint FW_LIGHT = 300;
        public const uint FW_NORMAL = 400;
        public const uint FW_MEDIUM = 500;
        public const uint FW_SEMIBOLD = 600;
        public const uint FW_BOLD = 700;
        public const uint FW_EXTRABOLD = 800;
        public const uint FW_HEAVY = 900;

        public const uint SRCCOPY = 0x00CC0020;	// dest = source                   
        public const uint SRCPAINT = 0x00EE0086;	// dest = source OR dest           
        public const uint SRCAND = 0x008800C6;	// dest = source AND dest          
        public const uint SRCINVERT = 0x00660046;	// dest = source XOR dest          
        public const uint SRCERASE = 0x00440328;	// dest = source AND (NOT dest )   
        public const uint NOTSRCCOPY = 0x00330008;	// dest = (NOT source)             
        public const uint NOTSRCERASE = 0x001100A6;	// dest = (NOT src) AND (NOT dest) 
        public const uint MERGECOPY = 0x00C000CA;	// dest = (source AND pattern)     
        public const uint MERGEPAINT = 0x00BB0226;	// dest = (NOT source) OR dest     
        public const uint PATCOPY = 0x00F00021;	// dest = pattern                  
        public const uint PATPAINT = 0x00FB0A09;	// dest = DPSnoo                   
        public const uint PATINVERT = 0x005A0049;	// dest = pattern XOR dest         
        public const uint DSTINVERT = 0x00550009;	// dest = (NOT dest)               
        public const uint BLACKNESS = 0x00000042;	// dest = BLACK                    
        public const uint WHITENESS = 0x00FF0062;	// dest = WHITE     

        public const uint DIB_RGB_COLORS = 0;
        public const uint DIB_PAL_COLORS = 1;

        public const uint CS_VREDRAW = 0x0001;
        public const uint CS_HREDRAW = 0x0002;
        public const uint CS_DBLCLKS = 0x0008;
        public const uint CS_OWNDC = 0x0020;
        public const uint CS_CLASSDC = 0x0040;
        public const uint CS_PARENTDC = 0x0080;
        public const uint CS_NOCLOSE = 0x0200;
        public const uint CS_SAVEBITS = 0x0800;
        public const uint CS_BYTEALIGNCLIENT = 0x1000;
        public const uint CS_BYTEALIGNWINDOW = 0x2000;
        public const uint CS_GLOBALCLASS = 0x4000;
    }
}
