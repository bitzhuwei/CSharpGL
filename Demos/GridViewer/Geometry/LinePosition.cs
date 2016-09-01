using CSharpGL;
using System.Runtime.InteropServices;

namespace SimLab.SimGrid.Geometry
{
    /// <summary>
    /// 描述一条线段
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LinePosition
    {
        /// <summary>
        /// 起始点
        /// </summary>
        public vec3 P1;

        /// <summary>
        /// 终点
        /// </summary>
        public vec3 P2;
    }
}