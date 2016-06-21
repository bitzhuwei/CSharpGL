using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimLab.Geometry
{
    /// <summary>
    /// 四边形的纹理映射坐标
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct QuadTexCoord
    {
        public float P1;
        public float P2;
        public float P3;
        public float P4;

        public void SetTextureCoord(float value)
        {
            this.P1 = value;
            this.P2 = value;
            this.P3 = value;
            this.P4 = value;
        }
       
    }
}
