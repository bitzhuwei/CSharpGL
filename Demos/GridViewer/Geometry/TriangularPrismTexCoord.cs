using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace SimLab.Geometry
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TriangularPrismTexCoord
    {
        public float P1;
        public float P2;
        public float P3;
        public float P4;
        public float P5;
        public float P6;

        /// <summary>
        /// 设置纹理映射坐标
        /// </summary>
        /// <param name="value"></param>
        public void SetTextureCoord(float value)
        {
            this.P1 = value;
            this.P2 = value;
            this.P3 = value;
            this.P4 = value;
            this.P5 = value;
            this.P6 = value;
        }
    }
}
