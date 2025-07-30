using System;
using System.Runtime.InteropServices;

namespace CSharpGL.Windows {
    [StructLayout(LayoutKind.Sequential)]
    internal struct BitmapInfo {
        public readonly Int32 biSize;
        public Int32 biWidth;
        public Int32 biHeight;
        public Int16 biPlanes;
        public Int16 biBitCount;
        public Int32 biCompression;
        public Int32 biSizeImage;
        public Int32 biXPelsPerMeter;
        public Int32 biYPelsPerMeter;
        public Int32 biClrUsed;
        public Int32 biClrImportant;

        public BitmapInfo() {
            biSize = Marshal.SizeOf(this);
        }
    }
}