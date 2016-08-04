using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{

    /// <summary>
    /// 
    /// </summary>
    public enum PolygonModeFaces : uint
    {
        /// <summary>
        /// 表示显示模式将适用于物体的前向面（也就是物体能看到的面）
        /// </summary>
        Front = OpenGL.GL_FRONT,

        /// <summary>
        /// 表示显示模式将适用于物体的后向面（也就是物体上不能看到的面）
        /// </summary>
        Back = OpenGL.GL_BACK,

        /// <summary>
        /// 表示显示模式将适用于物体的所有面
        /// </summary>
        FrontAndBack = OpenGL.GL_FRONT_AND_BACK,
    }

    /// <summary>
    /// The Polygon mode.
    /// </summary>
    public enum PolygonModes : uint
    {
        /// <summary>
        /// Render as points.
        /// </summary>
        Points = OpenGL.GL_POINT,

        /// <summary>
        /// Render as lines.
        /// </summary>
        Lines = OpenGL.GL_LINE,

        /// <summary>
        /// Render as filled.
        /// </summary>
        Filled = OpenGL.GL_FILL
    }
}
