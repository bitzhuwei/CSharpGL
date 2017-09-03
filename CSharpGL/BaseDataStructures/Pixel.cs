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

        // This is how is vertexID coded into color in vertex shader.
        // int objectID = gl_VertexID;
        // codedColor = vec4(
        //     float(objectID & 0xFF),
        //     float((objectID >> 8) & 0xFF),
        //     float((objectID >> 16) & 0xFF),
        //     float((objectID >> 24) & 0xFF));
        /// <summary>
        /// Gets stageVertexID from coded color.
        /// The stageVertexID is the last vertex that constructs the primitive.
        /// see http://www.cnblogs.com/bitzhuwei/p/modern-opengl-picking-primitive-in-VBO-2.html
        /// </summary>
        /// <returns></returns>
        public uint ToStageVertexId()
        {
            uint shiftedR = (uint)this.r;
            uint shiftedG = ((uint)this.g) << 8;
            uint shiftedB = ((uint)this.b) << 16;
            uint shiftedA = ((uint)this.a) << 24;
            uint stageVertexId = shiftedR + shiftedG + shiftedB + shiftedA;

            return stageVertexId;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public bool IsWhite()
        {
            return this.r == byte.MaxValue && this.g == byte.MaxValue && this.b == byte.MaxValue && this.a == byte.MaxValue;
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