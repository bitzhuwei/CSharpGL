using System;
using System.Runtime.InteropServices;

namespace CSharpGL.Windows {
    /// <summary>
    /// pfd: pixel format descriptor
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    internal class PixelFormatDescriptor {
        [FieldOffset(0)]
        public readonly UInt16 nSize;

        [FieldOffset(2)]
        public UInt16 nVersion;

        [FieldOffset(4)]
        public UInt32 dwFlags;

        [FieldOffset(8)]
        public Byte iPixelType;

        [FieldOffset(9)]
        public Byte colorBits;

        [FieldOffset(10)]
        public Byte cRedBits;

        [FieldOffset(11)]
        public Byte cRedShift;

        [FieldOffset(12)]
        public Byte cGreenBits;

        [FieldOffset(13)]
        public Byte cGreenShift;

        [FieldOffset(14)]
        public Byte cBlueBits;

        [FieldOffset(15)]
        public Byte cBlueShift;

        [FieldOffset(16)]
        public Byte cAlphaBits;

        [FieldOffset(17)]
        public Byte cAlphaShift;

        [FieldOffset(18)]
        public Byte accumBits;

        [FieldOffset(19)]
        public Byte accumRedBits;

        [FieldOffset(20)]
        public Byte accumGreenBits;

        [FieldOffset(21)]
        public Byte accumBlueBits;

        [FieldOffset(22)]
        public Byte accumAlphaBits;

        [FieldOffset(23)]
        public Byte depthBits;

        [FieldOffset(24)]
        public Byte stencilBits;

        [FieldOffset(25)]
        public Byte cAuxBuffers;

        [FieldOffset(26)]
        public SByte iLayerType;

        [FieldOffset(27)]
        public Byte bReserved;

        [FieldOffset(28)]
        public UInt32 dwLayerMask;

        [FieldOffset(32)]
        public UInt32 dwVisibleMask;

        [FieldOffset(36)]
        public UInt32 dwDamageMask;

        public PixelFormatDescriptor() { nSize = (ushort)Marshal.SizeOf(this); }

        public override string ToString() {
            return string.Concat(nSize, " ", nVersion, " ", dwFlags, " ", iPixelType, " ", colorBits, " ", cRedBits, " ", cGreenBits, " ", cGreenShift, " ", cBlueBits, " ", cBlueShift, " ", cAlphaBits, " ", cAlphaShift, " ", accumBits, " ", accumRedBits, " ", accumGreenBits, " ", accumBlueBits, " ", accumAlphaBits, " ", depthBits, " ", stencilBits, " ", cAuxBuffers, " ", iLayerType, " ", bReserved, " ", dwLayerMask, " ", dwVisibleMask, " ", dwDamageMask);
        }
    }
}
