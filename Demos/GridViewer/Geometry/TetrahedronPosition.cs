using CSharpGL;
using System.Runtime.InteropServices;

namespace SimLab.SimGrid.Geometry
{
    /// <summary>
    ///  描述一个四面体的位置信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TetrahedronPosition
    {
        public vec3 p1;
        public vec3 p2;
        public vec3 p3;
        public vec3 p4;
    }
}