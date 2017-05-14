namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public enum DrawMode : uint
    {
        /// <summary>
        /// GL_POINTS = 0x0000;
        /// </summary>
        Points = GL.GL_POINTS,

        /// <summary>
        /// GL_LINES = 0x0001;
        /// </summary>
        Lines = GL.GL_LINES,

        /// <summary>
        /// GL_LINE_LOOP = 0x0002;
        /// </summary>
        LineLoop = GL.GL_LINE_LOOP,

        /// <summary>
        /// GL_LINE_STRIP = 0x0003;
        /// </summary>
        LineStrip = GL.GL_LINE_STRIP,

        /// <summary>
        /// GL_TRIANGLES = 0x0004;
        /// </summary>
        Triangles = GL.GL_TRIANGLES,

        /// <summary>
        /// GL_TRIANGLE_STRIP = 0x0005;
        /// </summary>
        TriangleStrip = GL.GL_TRIANGLE_STRIP,

        /// <summary>
        /// GL_TRIANGLE_FAN = 0x0006;
        /// </summary>
        TriangleFan = GL.GL_TRIANGLE_FAN,

        /// <summary>
        /// GL_QUADS = 0x0007;
        /// </summary>
        Quads = GL.GL_QUADS,

        /// <summary>
        /// GL_QUAD_STRIP = 0x0008;
        /// </summary>
        QuadStrip = GL.GL_QUAD_STRIP,

        /// <summary>
        /// GL_POLYGON = 0x0009;
        /// </summary>
        Polygon = GL.GL_POLYGON,

        /// <summary>
        /// GL_LINES_ADJACENCY = 0x000A;
        /// </summary>
        LinesAdjacency = GL.GL_LINES_ADJACENCY,

        /// <summary>
        /// GL_LINE_STRIP_ADJACENCY = 0x000B;
        /// </summary>
        LineStripAdjacency = GL.GL_LINE_STRIP_ADJACENCY,

        /// <summary>
        /// GL_TRIANGLES_ADJACENCY = 0x000C;
        /// </summary>
        TrianglesAdjacency = GL.GL_TRIANGLES_ADJACENCY,

        /// <summary>
        /// GL_TRIANGLE_STRIP_ADJACENCY = 0x000D;
        /// </summary>
        TriangleStripAdjacency = GL.GL_TRIANGLE_STRIP_ADJACENCY,

        /// <summary>
        /// GL_PATCHES = 0xE;
        /// </summary>
        Patches = GL.GL_PATCHES,
    }
}