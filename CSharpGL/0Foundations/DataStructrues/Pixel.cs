using System.Drawing;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct Pixel
    {
        /// <summary>
        ///
        /// </summary>
        [FieldOffset(sizeof(byte) * 0)]
        public byte r;

        /// <summary>
        ///
        /// </summary>
        [FieldOffset(sizeof(byte) * 1)]
        public byte g;

        /// <summary>
        ///
        /// </summary>
        [FieldOffset(sizeof(byte) * 2)]
        public byte b;

        /// <summary>
        ///
        /// </summary>
        [FieldOffset(sizeof(byte) * 3)]
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