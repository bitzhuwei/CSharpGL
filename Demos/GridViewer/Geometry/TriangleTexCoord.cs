using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace SimLab.SimGrid.Geometry
{

    /// <summary>
    /// 三角形的3个顶点的颜色信息的纹理坐标。（只有U，没有V，因为不需要V）
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TriangleTexCoord
    {
        public float P1;
        public float P2;
        public float P3;

        public void SetTextureCoord(float value)
        {
            this.P1 = value;
            this.P2 = value;
            this.P3 = value;
        }
    }
}
