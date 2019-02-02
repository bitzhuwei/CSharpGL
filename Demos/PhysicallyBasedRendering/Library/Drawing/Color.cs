using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeImageAPI
{
    public struct Color
    {
        public byte A { get; set; }

        public byte R { get; set; }

        public byte G { get; set; }

        public byte B { get; set; }

        public String Name
        {
            get
            {
                return String.Format("#{0:X2}{1:X2}{2:X2}", (int)(R * 0xff), (int)(G * 0xff), (int)(B * 0xff));
            }
        }

        public override bool Equals(object obj)
        {
            if(obj is Color)
            {
                Color other = (Color)obj;
                return this == other;
            }
            return false;
        }

        public int ToArgb()
        {
            return (A << 24) + (R << 16) + (G << 8) + B;
        }

        public static Color White
        {
            get
            {
                return new Color()
                {
                    A = 255,
                    R = 255,
                    G = 255,
                    B = 255
                };
            }
        }

        public static bool operator ==(Color c1, Color c2)
        {
            return c1.A == c2.A &&
                   c1.R == c2.R &&
                   c1.G == c2.G &&
                   c1.B == c2.B;
        }

        public static bool operator !=(Color c1, Color c2)
        {
            return c1.A != c2.A ||
                   c1.R != c2.R ||
                   c1.G != c2.G ||
                   c1.B != c2.B;
        }

        public static Color FromArgb(uint color)
        {
            return new Color()
                {
                    A = (byte)((color >> 24) & 0xFF),
                    R = (byte)((color >> 16) & 0xFF),
                    G = (byte)((color >> 8) & 0xFF),
                    B = (byte)(color & 0xFF)
                };
        }

        public static Color FromArgb(int color)
        {
            return new Color()
            {
                A = (byte)((color >> 24) & 0xFF),
                R = (byte)((color >> 16) & 0xFF),
                G = (byte)((color >> 8) & 0xFF),
                B = (byte)(color & 0xFF)
            };
        }

        public static Color FromArgb(int a, int r, int g, int b)
        {
            return new Color()
            {
                A = (byte)a,
                R = (byte)r,
                G = (byte)g,
                B = (byte)b
            };
        }

        public static Color FromArgb(int r, int g, int b)
        {
            return new Color()
            {
                A = byte.MaxValue,
                R = (byte)r,
                G = (byte)g,
                B = (byte)b
            };
        }
    }
}
