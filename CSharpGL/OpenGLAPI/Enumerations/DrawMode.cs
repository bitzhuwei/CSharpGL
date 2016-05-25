using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public enum DrawMode : uint
    {
        Points = OpenGL.GL_POINTS,
        LineStrip = OpenGL.GL_LINE_STRIP,
        LineLoop = OpenGL.GL_LINE_LOOP,
        Lines = OpenGL.GL_LINES,
        LineStripAdjacency = OpenGL.GL_LINE_STRIP_ADJACENCY,
        LinesAdjacency = OpenGL.GL_LINES_ADJACENCY,
        TriangleStrip = OpenGL.GL_TRIANGLE_STRIP,
        TriangleFan = OpenGL.GL_TRIANGLE_FAN,
        Triangles = OpenGL.GL_TRIANGLES,
        TriangleStripAdjacency = OpenGL.GL_TRIANGLE_STRIP_ADJACENCY,
        TrianglesAdjacency = OpenGL.GL_TRIANGLES_ADJACENCY,
        Patches = OpenGL.GL_PATCHES,
        QuadStrip = OpenGL.GL_QUAD_STRIP,
        Quads = OpenGL.GL_QUADS,
        Polygon = OpenGL.GL_POLYGON,
    }
}
