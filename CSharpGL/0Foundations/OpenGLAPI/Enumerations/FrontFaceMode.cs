namespace CSharpGL
{
    /// <summary>
    /// 控制多边形的正面是如何决定的。在默认情况下是GL_CCW。
    /// </summary>
    public enum FrontFaceMode : uint
    {
        /// <summary>
        /// GL_CCW 表示窗口坐标上投影多边形的顶点顺序为逆时针方向的表面为正面。
        /// </summary>
        CCW = OpenGL.GL_CCW,

        /// <summary>
        /// GL_CW 表示顶点顺序为顺时针方向的表面为正面。
        /// </summary>
        CW = OpenGL.GL_CW,
    }
}