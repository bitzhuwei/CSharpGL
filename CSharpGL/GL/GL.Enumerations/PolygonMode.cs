﻿namespace CSharpGL {
    /// <summary>
    ///
    /// </summary>
    public enum PolygonModeFaces : uint {
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
    public enum PolygonMode : uint {
        /// <summary>
        /// Render as points.
        /// </summary>
        Point = GL.GL_POINT,

        /// <summary>
        /// Render as lines.
        /// </summary>
        Line = GL.GL_LINE,

        /// <summary>
        /// Render as filled(surface).
        /// </summary>
        Fill = GL.GL_FILL
    }
}