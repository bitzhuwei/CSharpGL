using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    [StructLayout(LayoutKind.Explicit)]
    internal class PixelFormatDescriptor
    {
        [FieldOffset(0)]
        public UInt16 nSize;

        [FieldOffset(2)]
        public UInt16 nVersion;

        [FieldOffset(4)]
        public UInt32 dwFlags;

        [FieldOffset(8)]
        public Byte iPixelType;

        [FieldOffset(9)]
        public Byte cColorBits;

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
        public Byte cAccumBits;

        [FieldOffset(19)]
        public Byte cAccumRedBits;

        [FieldOffset(20)]
        public Byte cAccumGreenBits;

        [FieldOffset(21)]
        public Byte cAccumBlueBits;

        [FieldOffset(22)]
        public Byte cAccumAlphaBits;

        [FieldOffset(23)]
        public Byte cDepthBits;

        [FieldOffset(24)]
        public Byte cStencilBits;

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

        public void Init()
        {
            nSize = (ushort)Marshal.SizeOf(this);
        }
    }

    //struct PixelFormatDescriptor
    //{
    //    public ushort nSize;
    //    public ushort nVersion;
    //    public uint dwFlags;
    //    public byte iPixelType;
    //    public byte cColorBits;
    //    public byte cRedBits;
    //    public byte cRedShift;
    //    public byte cGreenBits;
    //    public byte cGreenShift;
    //    public byte cBlueBits;
    //    public byte cBlueShift;
    //    public byte cAlphaBits;
    //    public byte cAlphaShift;
    //    public byte cAccumBits;
    //    public byte cAccumRedBits;
    //    public byte cAccumGreenBits;
    //    public byte cAccumBlueBits;
    //    public byte cAccumAlphaBits;
    //    public byte cDepthBits;
    //    public byte cStencilBits;
    //    public byte cAuxBuffers;
    //    public sbyte iLayerType;
    //    public byte bReserved;
    //    public uint dwLayerMask;
    //    public uint dwVisibleMask;
    //    public uint dwDamageMask;
    //}
}