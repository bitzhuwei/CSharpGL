using System;
using System.Runtime.InteropServices;

namespace CSharpGL.CSSL
{
    /// <summary>
    /// 专用于CSSL。不可用于数学计算。
    /// <para>Specially designed for CSSL. Not for glm.</para>
    /// </summary>
    public class ivec3
    {
        //internal double a0;
        //internal double a1;
        //internal double a2;

        #region compositions

        public int x { get { return 0; } set { } }
        public int y { get { return 0; } set { } }
        public int z { get { return 0; } set { } }

        public vec2 xx { get { return null; } set { } }
        public vec2 xy { get { return null; } set { } }
        public vec2 xz { get { return null; } set { } }
        public vec2 yx { get { return null; } set { } }
        public vec2 yy { get { return null; } set { } }
        public vec2 yz { get { return null; } set { } }
        public vec2 zx { get { return null; } set { } }
        public vec2 zy { get { return null; } set { } }
        public vec2 zz { get { return null; } set { } }

        public ivec3 xxx { get { return null; } set { } }
        public ivec3 xxy { get { return null; } set { } }
        public ivec3 xxz { get { return null; } set { } }
        public ivec3 xyx { get { return null; } set { } }
        public ivec3 xyy { get { return null; } set { } }
        public ivec3 xyz { get { return null; } set { } }
        public ivec3 xzx { get { return null; } set { } }
        public ivec3 xzy { get { return null; } set { } }
        public ivec3 xzz { get { return null; } set { } }
        public ivec3 yxx { get { return null; } set { } }
        public ivec3 yxy { get { return null; } set { } }
        public ivec3 yxz { get { return null; } set { } }
        public ivec3 yyx { get { return null; } set { } }
        public ivec3 yyy { get { return null; } set { } }
        public ivec3 yyz { get { return null; } set { } }
        public ivec3 yzx { get { return null; } set { } }
        public ivec3 yzy { get { return null; } set { } }
        public ivec3 yzz { get { return null; } set { } }
        public ivec3 zxx { get { return null; } set { } }
        public ivec3 zxy { get { return null; } set { } }
        public ivec3 zxz { get { return null; } set { } }
        public ivec3 zyx { get { return null; } set { } }
        public ivec3 zyy { get { return null; } set { } }
        public ivec3 zyz { get { return null; } set { } }
        public ivec3 zzx { get { return null; } set { } }
        public ivec3 zzy { get { return null; } set { } }
        public ivec3 zzz { get { return null; } set { } }

        public int r { get { return 0; } set { } }
        public int g { get { return 0; } set { } }
        public int b { get { return 0; } set { } }

        public vec2 rr { get { return null; } set { } }
        public vec2 rg { get { return null; } set { } }
        public vec2 rb { get { return null; } set { } }
        public vec2 gr { get { return null; } set { } }
        public vec2 gg { get { return null; } set { } }
        public vec2 gb { get { return null; } set { } }
        public vec2 br { get { return null; } set { } }
        public vec2 bg { get { return null; } set { } }
        public vec2 bb { get { return null; } set { } }

        public ivec3 rrr { get { return null; } set { } }
        public ivec3 rrg { get { return null; } set { } }
        public ivec3 rrb { get { return null; } set { } }
        public ivec3 rgr { get { return null; } set { } }
        public ivec3 rgg { get { return null; } set { } }
        public ivec3 rgb { get { return null; } set { } }
        public ivec3 rbr { get { return null; } set { } }
        public ivec3 rbg { get { return null; } set { } }
        public ivec3 rbb { get { return null; } set { } }
        public ivec3 grr { get { return null; } set { } }
        public ivec3 grg { get { return null; } set { } }
        public ivec3 grb { get { return null; } set { } }
        public ivec3 ggr { get { return null; } set { } }
        public ivec3 ggg { get { return null; } set { } }
        public ivec3 ggb { get { return null; } set { } }
        public ivec3 gbr { get { return null; } set { } }
        public ivec3 gbg { get { return null; } set { } }
        public ivec3 gbb { get { return null; } set { } }
        public ivec3 brr { get { return null; } set { } }
        public ivec3 brg { get { return null; } set { } }
        public ivec3 brb { get { return null; } set { } }
        public ivec3 bgr { get { return null; } set { } }
        public ivec3 bgg { get { return null; } set { } }
        public ivec3 bgb { get { return null; } set { } }
        public ivec3 bbr { get { return null; } set { } }
        public ivec3 bbg { get { return null; } set { } }
        public ivec3 bbb { get { return null; } set { } }

        public int s { get { return 0; } set { } }
        public int t { get { return 0; } set { } }
        public int p { get { return 0; } set { } }

        public vec2 ss { get { return null; } set { } }
        public vec2 st { get { return null; } set { } }
        public vec2 sp { get { return null; } set { } }
        public vec2 ts { get { return null; } set { } }
        public vec2 tt { get { return null; } set { } }
        public vec2 tp { get { return null; } set { } }
        public vec2 ps { get { return null; } set { } }
        public vec2 pt { get { return null; } set { } }
        public vec2 pp { get { return null; } set { } }

        public ivec3 sss { get { return null; } set { } }
        public ivec3 sst { get { return null; } set { } }
        public ivec3 ssp { get { return null; } set { } }
        public ivec3 sts { get { return null; } set { } }
        public ivec3 stt { get { return null; } set { } }
        public ivec3 stp { get { return null; } set { } }
        public ivec3 sps { get { return null; } set { } }
        public ivec3 spt { get { return null; } set { } }
        public ivec3 spp { get { return null; } set { } }
        public ivec3 tss { get { return null; } set { } }
        public ivec3 tst { get { return null; } set { } }
        public ivec3 tsp { get { return null; } set { } }
        public ivec3 tts { get { return null; } set { } }
        public ivec3 ttt { get { return null; } set { } }
        public ivec3 ttp { get { return null; } set { } }
        public ivec3 tps { get { return null; } set { } }
        public ivec3 tpt { get { return null; } set { } }
        public ivec3 tpp { get { return null; } set { } }
        public ivec3 pss { get { return null; } set { } }
        public ivec3 pst { get { return null; } set { } }
        public ivec3 psp { get { return null; } set { } }
        public ivec3 pts { get { return null; } set { } }
        public ivec3 ptt { get { return null; } set { } }
        public ivec3 ptp { get { return null; } set { } }
        public ivec3 pps { get { return null; } set { } }
        public ivec3 ppt { get { return null; } set { } }
        public ivec3 ppp { get { return null; } set { } }

        #endregion compositions

        public int this[int index]
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        private ivec3() { }

        public static ivec3 operator -(ivec3 lhs)
        {
            return null;
        }

        public static ivec3 operator +(ivec3 lhs, ivec3 rhs)
        {
            return null;
        }

        public static ivec3 operator +(ivec3 lhs, double rhs)
        {
            return null;
        }

        public static ivec3 operator -(ivec3 lhs, ivec3 rhs)
        {
            return null;
        }

        public static ivec3 operator -(ivec3 lhs, double rhs)
        {
            return null;
        }

        public static ivec3 operator *(ivec3 self, double s)
        {
            return null;
        }
        public static ivec3 operator *(double lhs, ivec3 rhs)
        {
            return null;
        }

        public static ivec3 operator /(ivec3 lhs, double rhs)
        {
            return null;
        }

        public static ivec3 operator *(ivec3 lhs, ivec3 rhs)
        {
            return null;
        }

        public override string ToString()
        {
            return string.Format("CSSL's ivec3 type.");
        }
    }
}