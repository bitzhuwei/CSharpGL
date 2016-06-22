using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace SimLab.Geometry
{

    /// <summary>
    /// 四边形描述信息,p1,p2，p3,p4; p1,p2,p3,p4 按照顺序连接就是一个四边形
    /// p1-----p2
    /// |       |
    /// |       |
    /// |       |
    /// p4-----p3
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct QuadPosition
    {
        public vec3 P1;
        public vec3 P2;
        public vec3 P3;
        public vec3 P4;
    }
}
