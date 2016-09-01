namespace CSharpGL
{
    /// <summary>
    /// The hint mode.
    /// </summary>
    public enum HintMode : uint
    {
        /// <summary>
        ///
        /// </summary>
        DontCare = OpenGL.GL_DONT_CARE,

        /// <summary>
        ///
        /// </summary>
        Fastest = OpenGL.GL_FASTEST,

        /// <summary>
        /// The
        /// </summary>
        Nicest = OpenGL.GL_NICEST
    }

    /// <summary>
    /// The hint target.
    /// </summary>
    public enum HintTarget : uint
    {
        /// <summary>
        ///
        /// </summary>
        PerspectiveCorrection = OpenGL.GL_PERSPECTIVE_CORRECTION_HINT,

        /// <summary>
        ///
        /// </summary>
        PointSmooth = OpenGL.GL_POINT_SMOOTH_HINT,

        /// <summary>
        ///
        /// </summary>
        LineSmooth = OpenGL.GL_LINE_SMOOTH_HINT,

        /// <summary>
        ///
        /// </summary>
        PolygonSmooth = OpenGL.GL_POLYGON_SMOOTH_HINT,

        /// <summary>
        ///
        /// </summary>
        Fog = OpenGL.GL_FOG_HINT
    }
}