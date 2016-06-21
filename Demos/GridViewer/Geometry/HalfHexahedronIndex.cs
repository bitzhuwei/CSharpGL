using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimLab.SimGrid
{
    /// <summary>
    /// 描述用OpenGL.GL_QUAD_STRIP渲染六面体时的三个面+一个PrimitiveRestart索引。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HalfHexahedronIndex
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
        public uint dot3;
        public uint dot4;
        public uint dot5;
        public uint dot6;
        public uint dot7;

        /// <summary>
        /// 请始终给此变量赋值uint.MaxValue
        /// </summary>
        public uint restartIndex;
    }
}
