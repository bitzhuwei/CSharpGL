using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// The hint mode.
    /// </summary>
    public enum HintMode : uint
    {
        DontCare = OpenGL.GL_DONT_CARE,
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
        PerspectiveCorrection = OpenGL.GL_PERSPECTIVE_CORRECTION_HINT,
        PointSmooth = OpenGL.GL_POINT_SMOOTH_HINT,
        LineSmooth = OpenGL.GL_LINE_SMOOTH_HINT,
        PolygonSmooth = OpenGL.GL_POLYGON_SMOOTH_HINT,
        Fog = OpenGL.GL_FOG_HINT
    }
}
