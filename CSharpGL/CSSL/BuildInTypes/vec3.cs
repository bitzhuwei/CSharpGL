using System;
using System.Runtime.InteropServices;

namespace CSharpGL.CSSL
{
    /// <summary>
    /// 专用于CSSL。不可用于数学计算。
    /// <para>Specially designed for CSSL. Not for glm.</para>
    /// </summary>
    public class vec3
    {
        internal double a0;
        internal double a1;
        internal double a2;

        #region compositions

        public float x { get { return 0.0f; } set { } }
        public float y { get { return 0.0f; } set { } }
        public float z { get { return 0.0f; } set { } }

        public vec2 xx { get { return null; } set { } }
        public vec2 xy { get { return null; } set { } }
        public vec2 xz { get { return null; } set { } }
        public vec2 yx { get { return null; } set { } }
        public vec2 yy { get { return null; } set { } }
        public vec2 yz { get { return null; } set { } }
        public vec2 zx { get { return null; } set { } }
        public vec2 zy { get { return null; } set { } }
        public vec2 zz { get { return null; } set { } }

        public vec3 xxx { get { return null; } set { } }
        public vec3 xxy { get { return null; } set { } }
        public vec3 xxz { get { return null; } set { } }
        public vec3 xyx { get { return null; } set { } }
        public vec3 xyy { get { return null; } set { } }
        public vec3 xyz { get { return null; } set { } }
        public vec3 xzx { get { return null; } set { } }
        public vec3 xzy { get { return null; } set { } }
        public vec3 xzz { get { return null; } set { } }
        public vec3 yxx { get { return null; } set { } }
        public vec3 yxy { get { return null; } set { } }
        public vec3 yxz { get { return null; } set { } }
        public vec3 yyx { get { return null; } set { } }
        public vec3 yyy { get { return null; } set { } }
        public vec3 yyz { get { return null; } set { } }
        public vec3 yzx { get { return null; } set { } }
        public vec3 yzy { get { return null; } set { } }
        public vec3 yzz { get { return null; } set { } }
        public vec3 zxx { get { return null; } set { } }
        public vec3 zxy { get { return null; } set { } }
        public vec3 zxz { get { return null; } set { } }
        public vec3 zyx { get { return null; } set { } }
        public vec3 zyy { get { return null; } set { } }
        public vec3 zyz { get { return null; } set { } }
        public vec3 zzx { get { return null; } set { } }
        public vec3 zzy { get { return null; } set { } }
        public vec3 zzz { get { return null; } set { } }

        public float r { get { return 0.0f; } set { } }
        public float g { get { return 0.0f; } set { } }
        public float b { get { return 0.0f; } set { } }

        public vec2 rr { get { return null; } set { } }
        public vec2 rg { get { return null; } set { } }
        public vec2 rb { get { return null; } set { } }
        public vec2 gr { get { return null; } set { } }
        public vec2 gg { get { return null; } set { } }
        public vec2 gb { get { return null; } set { } }
        public vec2 br { get { return null; } set { } }
        public vec2 bg { get { return null; } set { } }
        public vec2 bb { get { return null; } set { } }

        public vec3 rrr { get { return null; } set { } }
        public vec3 rrg { get { return null; } set { } }
        public vec3 rrb { get { return null; } set { } }
        public vec3 rgr { get { return null; } set { } }
        public vec3 rgg { get { return null; } set { } }
        public vec3 rgb { get { return null; } set { } }
        public vec3 rbr { get { return null; } set { } }
        public vec3 rbg { get { return null; } set { } }
        public vec3 rbb { get { return null; } set { } }
        public vec3 grr { get { return null; } set { } }
        public vec3 grg { get { return null; } set { } }
        public vec3 grb { get { return null; } set { } }
        public vec3 ggr { get { return null; } set { } }
        public vec3 ggg { get { return null; } set { } }
        public vec3 ggb { get { return null; } set { } }
        public vec3 gbr { get { return null; } set { } }
        public vec3 gbg { get { return null; } set { } }
        public vec3 gbb { get { return null; } set { } }
        public vec3 brr { get { return null; } set { } }
        public vec3 brg { get { return null; } set { } }
        public vec3 brb { get { return null; } set { } }
        public vec3 bgr { get { return null; } set { } }
        public vec3 bgg { get { return null; } set { } }
        public vec3 bgb { get { return null; } set { } }
        public vec3 bbr { get { return null; } set { } }
        public vec3 bbg { get { return null; } set { } }
        public vec3 bbb { get { return null; } set { } }

        public float s { get { return 0.0f; } set { } }
        public float t { get { return 0.0f; } set { } }
        public float p { get { return 0.0f; } set { } }

        public vec2 ss { get { return null; } set { } }
        public vec2 st { get { return null; } set { } }
        public vec2 sp { get { return null; } set { } }
        public vec2 ts { get { return null; } set { } }
        public vec2 tt { get { return null; } set { } }
        public vec2 tp { get { return null; } set { } }
        public vec2 ps { get { return null; } set { } }
        public vec2 pt { get { return null; } set { } }
        public vec2 pp { get { return null; } set { } }

        public vec3 sss { get { return null; } set { } }
        public vec3 sst { get { return null; } set { } }
        public vec3 ssp { get { return null; } set { } }
        public vec3 sts { get { return null; } set { } }
        public vec3 stt { get { return null; } set { } }
        public vec3 stp { get { return null; } set { } }
        public vec3 sps { get { return null; } set { } }
        public vec3 spt { get { return null; } set { } }
        public vec3 spp { get { return null; } set { } }
        public vec3 tss { get { return null; } set { } }
        public vec3 tst { get { return null; } set { } }
        public vec3 tsp { get { return null; } set { } }
        public vec3 tts { get { return null; } set { } }
        public vec3 ttt { get { return null; } set { } }
        public vec3 ttp { get { return null; } set { } }
        public vec3 tps { get { return null; } set { } }
        public vec3 tpt { get { return null; } set { } }
        public vec3 tpp { get { return null; } set { } }
        public vec3 pss { get { return null; } set { } }
        public vec3 pst { get { return null; } set { } }
        public vec3 psp { get { return null; } set { } }
        public vec3 pts { get { return null; } set { } }
        public vec3 ptt { get { return null; } set { } }
        public vec3 ptp { get { return null; } set { } }
        public vec3 pps { get { return null; } set { } }
        public vec3 ppt { get { return null; } set { } }
        public vec3 ppp { get { return null; } set { } }

        #endregion compositions

        public float this[int index]
        {
            get
            {
                return 0.0f;
            }
            set
            {
            }
        }

        private vec3() { }

        public static vec3 operator -(vec3 lhs)
        {
            return null;
        }

        public static vec3 operator +(vec3 lhs, vec3 rhs)
        {
            return null;
        }

        public static vec3 operator +(vec3 lhs, double rhs)
        {
            return null;
        }

        public static vec3 operator -(vec3 lhs, vec3 rhs)
        {
            return null;
        }

        public static vec3 operator -(vec3 lhs, double rhs)
        {
            return null;
        }

        public static vec3 operator *(vec3 self, double s)
        {
            return null;
        }
        public static vec3 operator *(double lhs, vec3 rhs)
        {
            return null;
        }

        public static vec3 operator /(vec3 lhs, double rhs)
        {
            return null;
        }

        public static vec3 operator *(vec3 lhs, vec3 rhs)
        {
            return null;
        }

        public override string ToString()
        {
            return string.Format("CSSL's vec3 type.");
        }
    }
}