using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimLab.GridSource
{

    /// <summary>
    /// map to opengl buffer
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HexahedronPosition
    {
        /// <summary>
        ///  front left top p0
        /// </summary>
        public vec3 FLT;

        /// <summary>
        /// front right top p1
        /// </summary>
        public vec3 FRT;

        /// <summary>
        /// back right top p2
        /// </summary>
        public vec3 BRT;

        /// <summary>
        /// back left top p4
        /// </summary>
        public vec3 BLT;

        /// <summary>
        /// 
        /// </summary>
        public vec3 FLB;
        public vec3 FRB;
        public vec3 BRB;
        public vec3 BLB;

    }
}
