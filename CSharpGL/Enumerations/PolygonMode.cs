using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{

    public enum PolygonModeFaces : uint
    {
        /// <summary>
        /// 表示显示模式将适用于物体的前向面（也就是物体能看到的面）
        /// </summary>
        Front = GL.GL_FRONT,

        /// <summary>
        /// 表示显示模式将适用于物体的后向面（也就是物体上不能看到的面）
        /// </summary>
        Back = GL.GL_BACK,

        /// <summary>
        /// 表示显示模式将适用于物体的所有面
        /// </summary>
        FrontAndBack = GL.GL_FRONT_AND_BACK,
    }

    /// <summary>
    /// The Polygon mode.
    /// </summary>
    public enum PolygonModes : uint
    {
        /// <summary>
        /// Render as points.
        /// </summary>
        Points = GL.GL_POINT,

        /// <summary>
        /// Render as lines.
        /// </summary>
        Lines = GL.GL_LINE,

        /// <summary>
        /// Render as filled.
        /// </summary>
        Filled = GL.GL_FILL
    }
}
