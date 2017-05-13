namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public enum PolygonOffset : uint
    {
        /// <summary>
        ///
        /// </summary>
        Factor = OpenGL.GL_POLYGON_OFFSET_FACTOR,// = 0x8038;

        /// <summary>
        ///
        /// </summary>
        Units = OpenGL.GL_POLYGON_OFFSET_UNITS,// = 0x2A00;

        /// <summary>
        ///
        /// </summary>
        Point = OpenGL.GL_POLYGON_OFFSET_POINT,// = 0x2A01;

        /// <summary>
        ///
        /// </summary>
        Line = OpenGL.GL_POLYGON_OFFSET_LINE,// = 0x2A02;

        /// <summary>
        ///
        /// </summary>
        Fill = OpenGL.GL_POLYGON_OFFSET_FILL,// = 0x8037;
    }
}