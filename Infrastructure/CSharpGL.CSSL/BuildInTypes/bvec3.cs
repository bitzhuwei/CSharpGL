namespace CSharpGL.CSSL
{
    /// <summary>
    /// 专用于CSSL。不可用于数学计算。
    /// <para>Specially designed for CSSL. Not for glm.</para>
    /// </summary>
    public class bvec3
    {
        //internal double a0;
        //internal double a1;
        //internal double a2;

        #region compositions

        public bool x { get { return false; } set { } }
        public bool y { get { return false; } set { } }
        public bool z { get { return false; } set { } }

        public vec2 xx { get { return null; } set { } }
        public vec2 xy { get { return null; } set { } }
        public vec2 xz { get { return null; } set { } }
        public vec2 yx { get { return null; } set { } }
        public vec2 yy { get { return null; } set { } }
        public vec2 yz { get { return null; } set { } }
        public vec2 zx { get { return null; } set { } }
        public vec2 zy { get { return null; } set { } }
        public vec2 zz { get { return null; } set { } }

        public bvec3 xxx { get { return null; } set { } }
        public bvec3 xxy { get { return null; } set { } }
        public bvec3 xxz { get { return null; } set { } }
        public bvec3 xyx { get { return null; } set { } }
        public bvec3 xyy { get { return null; } set { } }
        public bvec3 xyz { get { return null; } set { } }
        public bvec3 xzx { get { return null; } set { } }
        public bvec3 xzy { get { return null; } set { } }
        public bvec3 xzz { get { return null; } set { } }
        public bvec3 yxx { get { return null; } set { } }
        public bvec3 yxy { get { return null; } set { } }
        public bvec3 yxz { get { return null; } set { } }
        public bvec3 yyx { get { return null; } set { } }
        public bvec3 yyy { get { return null; } set { } }
        public bvec3 yyz { get { return null; } set { } }
        public bvec3 yzx { get { return null; } set { } }
        public bvec3 yzy { get { return null; } set { } }
        public bvec3 yzz { get { return null; } set { } }
        public bvec3 zxx { get { return null; } set { } }
        public bvec3 zxy { get { return null; } set { } }
        public bvec3 zxz { get { return null; } set { } }
        public bvec3 zyx { get { return null; } set { } }
        public bvec3 zyy { get { return null; } set { } }
        public bvec3 zyz { get { return null; } set { } }
        public bvec3 zzx { get { return null; } set { } }
        public bvec3 zzy { get { return null; } set { } }
        public bvec3 zzz { get { return null; } set { } }

        public bool r { get { return false; } set { } }
        public bool g { get { return false; } set { } }
        public bool b { get { return false; } set { } }

        public vec2 rr { get { return null; } set { } }
        public vec2 rg { get { return null; } set { } }
        public vec2 rb { get { return null; } set { } }
        public vec2 gr { get { return null; } set { } }
        public vec2 gg { get { return null; } set { } }
        public vec2 gb { get { return null; } set { } }
        public vec2 br { get { return null; } set { } }
        public vec2 bg { get { return null; } set { } }
        public vec2 bb { get { return null; } set { } }

        public bvec3 rrr { get { return null; } set { } }
        public bvec3 rrg { get { return null; } set { } }
        public bvec3 rrb { get { return null; } set { } }
        public bvec3 rgr { get { return null; } set { } }
        public bvec3 rgg { get { return null; } set { } }
        public bvec3 rgb { get { return null; } set { } }
        public bvec3 rbr { get { return null; } set { } }
        public bvec3 rbg { get { return null; } set { } }
        public bvec3 rbb { get { return null; } set { } }
        public bvec3 grr { get { return null; } set { } }
        public bvec3 grg { get { return null; } set { } }
        public bvec3 grb { get { return null; } set { } }
        public bvec3 ggr { get { return null; } set { } }
        public bvec3 ggg { get { return null; } set { } }
        public bvec3 ggb { get { return null; } set { } }
        public bvec3 gbr { get { return null; } set { } }
        public bvec3 gbg { get { return null; } set { } }
        public bvec3 gbb { get { return null; } set { } }
        public bvec3 brr { get { return null; } set { } }
        public bvec3 brg { get { return null; } set { } }
        public bvec3 brb { get { return null; } set { } }
        public bvec3 bgr { get { return null; } set { } }
        public bvec3 bgg { get { return null; } set { } }
        public bvec3 bgb { get { return null; } set { } }
        public bvec3 bbr { get { return null; } set { } }
        public bvec3 bbg { get { return null; } set { } }
        public bvec3 bbb { get { return null; } set { } }

        public bool s { get { return false; } set { } }
        public bool t { get { return false; } set { } }
        public bool p { get { return false; } set { } }

        public vec2 ss { get { return null; } set { } }
        public vec2 st { get { return null; } set { } }
        public vec2 sp { get { return null; } set { } }
        public vec2 ts { get { return null; } set { } }
        public vec2 tt { get { return null; } set { } }
        public vec2 tp { get { return null; } set { } }
        public vec2 ps { get { return null; } set { } }
        public vec2 pt { get { return null; } set { } }
        public vec2 pp { get { return null; } set { } }

        public bvec3 sss { get { return null; } set { } }
        public bvec3 sst { get { return null; } set { } }
        public bvec3 ssp { get { return null; } set { } }
        public bvec3 sts { get { return null; } set { } }
        public bvec3 stt { get { return null; } set { } }
        public bvec3 stp { get { return null; } set { } }
        public bvec3 sps { get { return null; } set { } }
        public bvec3 spt { get { return null; } set { } }
        public bvec3 spp { get { return null; } set { } }
        public bvec3 tss { get { return null; } set { } }
        public bvec3 tst { get { return null; } set { } }
        public bvec3 tsp { get { return null; } set { } }
        public bvec3 tts { get { return null; } set { } }
        public bvec3 ttt { get { return null; } set { } }
        public bvec3 ttp { get { return null; } set { } }
        public bvec3 tps { get { return null; } set { } }
        public bvec3 tpt { get { return null; } set { } }
        public bvec3 tpp { get { return null; } set { } }
        public bvec3 pss { get { return null; } set { } }
        public bvec3 pst { get { return null; } set { } }
        public bvec3 psp { get { return null; } set { } }
        public bvec3 pts { get { return null; } set { } }
        public bvec3 ptt { get { return null; } set { } }
        public bvec3 ptp { get { return null; } set { } }
        public bvec3 pps { get { return null; } set { } }
        public bvec3 ppt { get { return null; } set { } }
        public bvec3 ppp { get { return null; } set { } }

        #endregion compositions

        public bool this[int index]
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        private bvec3()
        {
        }

        public static bvec3 operator -(bvec3 lhs)
        {
            return null;
        }

        public static bvec3 operator +(bvec3 lhs, bvec3 rhs)
        {
            return null;
        }

        public static bvec3 operator +(bvec3 lhs, double rhs)
        {
            return null;
        }

        public static bvec3 operator -(bvec3 lhs, bvec3 rhs)
        {
            return null;
        }

        public static bvec3 operator -(bvec3 lhs, double rhs)
        {
            return null;
        }

        public static bvec3 operator *(bvec3 self, double s)
        {
            return null;
        }

        public static bvec3 operator *(double lhs, bvec3 rhs)
        {
            return null;
        }

        public static bvec3 operator /(bvec3 lhs, double rhs)
        {
            return null;
        }

        public static bvec3 operator *(bvec3 lhs, bvec3 rhs)
        {
            return null;
        }

        public override string ToString()
        {
            return string.Format("CSSL's bvec3 type.");
        }
    }
}