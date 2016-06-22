using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace SimLab.SimGrid
{
    /// <summary>
    /// 描述三角形索引。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TriangleIndex
    {
        /// <summary>
        /// 第0个顶点的索引值
        /// </summary>
        public uint dot0;
        /// <summary>
        /// 第1个顶点的索引值
        /// </summary>
        public uint dot1;
        /// <summary>
        /// 第2个顶点的索引值
        /// </summary>
        public uint dot2;
    }
}
