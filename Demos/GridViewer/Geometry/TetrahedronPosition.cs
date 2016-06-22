using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


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
