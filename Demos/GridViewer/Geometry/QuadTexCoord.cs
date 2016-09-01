using System.Runtime.InteropServices;

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