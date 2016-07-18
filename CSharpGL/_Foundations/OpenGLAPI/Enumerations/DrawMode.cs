using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public enum DrawMode : uint
    {
        /// <summary>
        /// 
        /// </summary>
        Points = OpenGL.GL_POINTS,
        /// <summary>
        /// 
        /// </summary>
        LineStrip = OpenGL.GL_LINE_STRIP,
        /// <summary>
        /// 
        /// </summary>
        LineLoop = OpenGL.GL_LINE_LOOP,
        /// <summary>
        /// 
        /// </summary>
        Lines = OpenGL.GL_LINES,
        /// <summary>
        /// 
        /// </summary>
        LineStripAdjacency = OpenGL.GL_LINE_STRIP_ADJACENCY,
        /// <summary>
        /// 
        /// </summary>
        LinesAdjacency = OpenGL.GL_LINES_ADJACENCY,
        /// <summary>
        /// 
        /// </summary>
        TriangleStrip = OpenGL.GL_TRIANGLE_STRIP,
        /// <summary>
        /// 
        /// </summary>
        TriangleFan = OpenGL.GL_TRIANGLE_FAN,
        /// <summary>
        /// 
        /// </summary>
        Triangles = OpenGL.GL_TRIANGLES,
        /// <summary>
        /// 
        /// </summary>
        TriangleStripAdjacency = OpenGL.GL_TRIANGLE_STRIP_ADJACENCY,
        /// <summary>
        /// 
        /// </summary>
        TrianglesAdjacency = OpenGL.GL_TRIANGLES_ADJACENCY,
        /// <summary>
        /// 
        /// </summary>
        Patches = OpenGL.GL_PATCHES,
        /// <summary>
        /// 
        /// </summary>
        QuadStrip = OpenGL.GL_QUAD_STRIP,
        /// <summary>
        /// 
        /// </summary>
        Quads = OpenGL.GL_QUADS,
        /// <summary>
        /// 
        /// </summary>
        Polygon = OpenGL.GL_POLYGON,
    }
}
