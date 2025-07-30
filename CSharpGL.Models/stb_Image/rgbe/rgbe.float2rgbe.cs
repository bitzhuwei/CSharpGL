using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL {
    public static partial class rgbe {
        /* standard conversion from float pixels to rgbe pixels */
        /* note: you can remove the "inline"s if your compiler complains about it */
        public static void float2rgbe(char[] rgbe, float red, float green, float blue) {
            float v;
            int e;

            v = red;
            if (green > v) v = green;
            if (blue > v) v = blue;
            if (v < 1e-32) {
                rgbe[0] = rgbe[1] = rgbe[2] = rgbe[3] = '\0';
            }
            else {
                v = (float)(frexp(v, out e) * 256.0 / v);
                rgbe[0] = (char)(red * v);
                rgbe[1] = (char)(green * v);
                rgbe[2] = (char)(blue * v);
                rgbe[3] = (char)(e + 128);
            }
        }

        [StructLayout(LayoutKind.Explicit, Size = sizeof(double))]
        unsafe struct U2 {
            [FieldOffset(0)]
            public double d;
            [FieldOffset(0)]
            public fixed byte c[8];
        }

        public static unsafe double frexp(double x, out int exp) {
            U2 u = new U2(); u.d = x;
            //得到移码，并减去1022得到指数值。
            exp = (int)(((u.c[7] & 0x7f) << 4) | (u.c[6] >> 4)) - 1022;
            //把指数部分置为0x03FE
            u.c[7] &= 0x80;
            u.c[7] |= 0x3f;
            u.c[6] &= 0x0f;
            u.c[6] |= 0xe0;

            return u.d;
        }

        // this works too.
        //[StructLayout(LayoutKind.Explicit, Size = sizeof(double))]
        //struct U {
        //    [FieldOffset(0)]
        //    public double d;
        //    [FieldOffset(0)]
        //    public byte c0;
        //    [FieldOffset(1)]
        //    public byte c1;
        //    [FieldOffset(2)]
        //    public byte c2;
        //    [FieldOffset(3)]
        //    public byte c3;
        //    [FieldOffset(4)]
        //    public byte c4;
        //    [FieldOffset(5)]
        //    public byte c5;
        //    [FieldOffset(6)]
        //    public byte c6;
        //    [FieldOffset(7)]
        //    public byte c7;
        //}

        //public static double frexp(double x, out int exp) {
        //    U u = new U(); u.d = x;
        //    //得到移码，并减去1022得到指数值。
        //    exp = (int)(((u.c7 & 0x7f) << 4) | (u.c6 >> 4)) - 1022;
        //    //把指数部分置为0x03FE
        //    u.c7 &= 0x80;
        //    u.c7 |= 0x3f;
        //    u.c6 &= 0x0f;
        //    u.c6 |= 0xe0;

        //    return u.d;
        //}

        // this failed.
        //public static double frexp(double x, out int exp) {
        //    //得到移码，并减去1022得到指数值。
        //    long l = BitConverter.DoubleToInt64Bits(x);
        //    {
        //        long c7 = l & 0x7f;
        //        long c6 = l & 0xff00;
        //        exp = (int)(((c7) << 4) | (c6 >> 4)) - 1022;
        //    }
        //    //把指数部分置为0x03FE
        //    {
        //        long c7 = (l & 0xff) & 0x80;
        //        c7 = c7 | 0x3f;

        //        long c6 = (l & 0xff00) & 0x0f00;
        //        c6 = c6 | 0xe000;

        //        long lResult = (l & 0x7fFFffFFffFF0000) | c6 | c7;
        //        double result = BitConverter.Int64BitsToDouble(lResult);
        //        return result;
        //    }
        //}

    }
}
