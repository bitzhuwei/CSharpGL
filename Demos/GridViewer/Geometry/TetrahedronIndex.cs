using System.Runtime.InteropServices;

namespace SimLab.SimGrid.Geometry
{
    /// <summary>
    /// 用OpenGL.GL_TRIANGLE_STRIP来渲染四面体。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TetrahedronIndex
    {
        public uint dot0;
        public uint dot1;
        public uint dot2;
        public uint dot3;
        public uint dot4;
        public uint dot5;

        /// <summary>
        /// 请给此变量赋值'uint.MaxValue'
        /// </summary>
        public uint restartIndex;
    }

    /// <summary>
    /// 用OpenGL.GL_QUAD_STRIP来渲染三棱柱。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TetrahedronTriangularPrismIndex
    {
        public uint dot0;
        public uint dot1;
        public uint dot2;
        public uint dot3;
        public uint dot4;
        public uint dot5;
        public uint dot6;
        public uint dot7;

        /// <summary>
        /// 请给此变量赋值'uint.MaxValue'
        /// </summary>
        public uint restartIndex;
    }
}