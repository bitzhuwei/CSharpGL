using CSharpGL;
using System.Runtime.InteropServices;

namespace SimLab.SimGrid.Geometry
{
    /// <summary>
    /// 描述一个三角形的位置信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TrianglePosition
    {
        public vec3 P1;
        public vec3 P2;
        public vec3 P3;
    }
}