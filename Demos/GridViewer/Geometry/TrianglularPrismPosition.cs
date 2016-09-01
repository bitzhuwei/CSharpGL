using CSharpGL;
using System.Runtime.InteropServices;

namespace SimLab.Geometry
{
    /// <summary>
    /// 三棱行的描述
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TriangularPrismPosition
    {
        /**
         * 顶三角形的坐标按顺序组成一个三角形,(p1,p2),(p4,p5)构成一个四边形，（
         * */
        public vec3 P1;
        public vec3 P2;
        public vec3 P3;

        /**
         * 底三角形的坐标按顺序组成一个三角形，
         * */
        public vec3 P4;
        public vec3 P5;
        public vec3 P6;
    }
}