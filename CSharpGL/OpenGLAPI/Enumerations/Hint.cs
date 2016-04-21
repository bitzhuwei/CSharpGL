using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// The hint mode.
    /// </summary>
    public enum HintMode : uint
    {
        DontCare = GL.GL_DONT_CARE,
        Fastest = GL.GL_FASTEST,
        /// <summary>
        /// The 
        /// </summary>
        Nicest = GL.GL_NICEST
    }

    /// <summary>
    /// The hint target.
    /// </summary>
    public enum HintTarget : uint
    {
        PerspectiveCorrection = GL.GL_PERSPECTIVE_CORRECTION_HINT,
        PointSmooth = GL.GL_POINT_SMOOTH_HINT,
        LineSmooth = GL.GL_LINE_SMOOTH_HINT,
        PolygonSmooth = GL.GL_POLYGON_SMOOTH_HINT,
        Fog = GL.GL_FOG_HINT
    }
}
