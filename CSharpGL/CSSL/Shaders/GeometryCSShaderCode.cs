using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.CSSL
{
    /// <summary>
    /// Geometry shader invocations take a single Primitive as input and may output zero or more primitives.
    /// Geometry shader输入：一个primitive，输出：0或多个primitive。
    /// </summary>
    public abstract class GeometryCSShaderCode : CSShaderCode
    {

        protected class gl_inElement
        {
            public vec4 gl_Position;
            public float gl_PointSize;
            public float[] gl_ClipDistance;
        }

        protected class gl_inArray
        {
            public gl_inElement this[int index] { get { return null; } }

            public int length() { return 0; }
        }

        protected gl_inArray gl_in;

        public enum InType
        {
            points,
            lines,
            lines_adjacency,
            triangles,
            triangle_adjacency,
        }

        /// <summary>
        /// 输入类型。
        /// </summary>
        public abstract InType LayoutIn { get; }

        public enum OutType
        {
            points,
            line_strip,
            triangle_strip,
        }

        /// <summary>
        /// 输出类型。
        /// </summary>
        public abstract OutType LayoutOut { get; }

        /// <summary>
        /// 最多多少个顶点。
        /// </summary>
        public abstract int max_vertices { get; }

        protected vec4 gl_Position;

        protected void EmitVertex() { }
        protected void EndPrimitive() { }
    }

}
