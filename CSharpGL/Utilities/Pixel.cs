using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public struct Pixel
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;

        public Pixel(byte r, byte g, byte b, byte a)
        {
            this.r = r; this.g = g; this.b = b; this.a = a;
        }

        public Color ToColor()
        {
            return Color.FromArgb(a, r, g, b);
        }

        public override string ToString()
        {
            return string.Format("R:{0}, G:{1}, B:{2}, A:{3}", r, g, b, a);
        }
    }
}
