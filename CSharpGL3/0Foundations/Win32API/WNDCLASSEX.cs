using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct WNDCLASSEX
    {
        /// <summary>
        ///
        /// </summary>
        public uint cbSize;

        /// <summary>
        ///
        /// </summary>
        public ClassStyles style;

        /// <summary>
        ///
        /// </summary>
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public WndProc lpfnWndProc;

        /// <summary>
        ///
        /// </summary>
        public int cbClsExtra;

        /// <summary>
        ///
        /// </summary>
        public int cbWndExtra;

        /// <summary>
        ///
        /// </summary>
        public IntPtr hInstance;

        /// <summary>
        ///
        /// </summary>
        public IntPtr hIcon;

        /// <summary>
        ///
        /// </summary>
        public IntPtr hCursor;

        /// <summary>
        ///
        /// </summary>
        public IntPtr hbrBackground;

        /// <summary>
        ///
        /// </summary>
        public string lpszMenuName;

        /// <summary>
        ///
        /// </summary>
        public string lpszClassName;

        /// <summary>
        ///
        /// </summary>
        public IntPtr hIconSm;

        /// <summary>
        ///
        /// </summary>
        public void Init()
        {
            cbSize = (uint)Marshal.SizeOf(this);
        }
    }
}