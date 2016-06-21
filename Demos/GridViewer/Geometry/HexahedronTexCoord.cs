using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimLab.SimGrid.Geometry
{

    /// <summary>
    /// 描述六面体顶点颜色的U坐标（由于使用色标，色标在纵向的颜色相同，所以不需要V坐标）
    /// <para>U坐标在0.0~1.0之间为正常值，否则为透明色。</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HexahedronTexCoord
    {
        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        public float FLT;
        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        public float FRT;
        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        public float BRT;
        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        public float BLT;

        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        public float FLB;

        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        public float FRB;
        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        public float BRB;
        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        public float BLB;

        /// <summary>
        /// U坐标在0.0~1.0之间为正常值，否则为透明色。
        /// </summary>
        /// <param name="value"></param>
        public void SetCoord(float value)
        {
            FLT = value;
            FRT = value;
            BRT = value;
            BLT = value;
            FLB = value;
            FRB = value;
            BRB = value;
            BLB = value;
        }
    }
}
