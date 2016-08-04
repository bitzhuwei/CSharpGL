using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public struct Pixel
    {
        /// <summary>
        /// 
        /// </summary>
        public byte r;
        /// <summary>
        /// 
        /// </summary>
        public byte g;
        /// <summary>
        /// 
        /// </summary>
        public byte b;
        /// <summary>
        /// 
        /// </summary>
        public byte a;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public Pixel(byte r, byte g, byte b, byte a)
        {
            this.r = r; this.g = g; this.b = b; this.a = a;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Color ToColor()
        {
            return Color.FromArgb(a, r, g, b);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("R:{0}, G:{1}, B:{2}, A:{3}", r, g, b, a);
        }
    }
}
