using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// The primitive mode.
    /// </summary>
    public enum PrimitiveMode : uint
    {
        /// <summary>
        /// Treats each vertex as a single point. Vertex n defines point n. N points are drawn.0x0000
        /// </summary>
        Points = GL.GL_POINTS,

        /// <summary>
        /// Treats each pair of vertices as an independent line segment. Vertices 2n - 1 and 2n define line n. N/2 lines are drawn.0x0001
        /// </summary>
        Lines = GL.GL_LINES,

        /// <summary>
        /// Draws a connected group of line segments from the first vertex to the last, then back to the first. Vertices n and n + 1 define line n. The last line, however, is defined by vertices N and 1. N lines are drawn.0x0002
        /// </summary>
        LineLoop = GL.GL_LINE_LOOP,

        /// <summary>
        /// Draws a connected group of line segments from the first vertex to the last. Vertices n and n+1 define line n. N - 1 lines are drawn.0x0003
        /// </summary>
        LineStrip = GL.GL_LINE_STRIP,

        /// <summary>
        /// Treats each triplet of vertices as an independent triangle. Vertices 3n - 2, 3n - 1, and 3n define triangle n. N/3 triangles are drawn.0x0004
        /// </summary>
        Triangles = GL.GL_TRIANGLES,

        /// <summary>
        /// Draws a connected group of triangles. One triangle is defined for each vertex presented after the first two vertices. For odd n, vertices n, n + 1, and n + 2 define triangle n. For even n, vertices n + 1, n, and n + 2 define triangle n. N - 2 triangles are drawn.0x0005
        /// </summary>
        TriangleString = GL.GL_TRIANGLE_STRIP,

        /// <summary>
        /// Draws a connected group of triangles. one triangle is defined for each vertex presented after the first two vertices. Vertices 1, n + 1, n + 2 define triangle n. N - 2 triangles are drawn.0x0006
        /// </summary>
        TriangleFan = GL.GL_TRIANGLE_FAN,

        /// <summary>
        /// Treats each group of four vertices as an independent quadrilateral. Vertices 4n - 3, 4n - 2, 4n - 1, and 4n define quadrilateral n. N/4 quadrilaterals are drawn.0x0007
        /// </summary>
        Quads = GL.GL_QUADS,

        /// <summary>
        /// Draws a connected group of quadrilaterals. One quadrilateral is defined for each pair of vertices presented after the first pair. Vertices 2n - 1, 2n, 2n + 2, and 2n + 1 define quadrilateral n. N/2 - 1 quadrilaterals are drawn. Note that the order in which vertices are used to construct a quadrilateral from strip data is different from that used with independent data.0x0008
        /// </summary>
        QuadStrip = GL.GL_QUAD_STRIP,

        /// <summary>
        /// Draws a single, convex polygon. Vertices 1 through N define this polygon.0x0009
        /// </summary>
        Polygon = GL.GL_POLYGON
    }

}
