namespace CSharpGL.CSSL
{
    /// <summary>
    /// 专用于CSSL。不可用于数学计算。
    /// <para>Specially designed for CSSL. Not for glm.</para>
    /// </summary>
    public class uvec3
    {
        //internal double a0;
        //internal double a1;
        //internal double a2;

        #region compositions

        public uint x { get { return 0; } set { } }
        public uint y { get { return 0; } set { } }
        public uint z { get { return 0; } set { } }

        public vec2 xx { get { return null; } set { } }
        public vec2 xy { get { return null; } set { } }
        public vec2 xz { get { return null; } set { } }
        public vec2 yx { get { return null; } set { } }
        public vec2 yy { get { return null; } set { } }
        public vec2 yz { get { return null; } set { } }
        public vec2 zx { get { return null; } set { } }
        public vec2 zy { get { return null; } set { } }
        public vec2 zz { get { return null; } set { } }

        public uvec3 xxx { get { return null; } set { } }
        public uvec3 xxy { get { return null; } set { } }
        public uvec3 xxz { get { return null; } set { } }
        public uvec3 xyx { get { return null; } set { } }
        public uvec3 xyy { get { return null; } set { } }
        public uvec3 xyz { get { return null; } set { } }
        public uvec3 xzx { get { return null; } set { } }
        public uvec3 xzy { get { return null; } set { } }
        public uvec3 xzz { get { return null; } set { } }
        public uvec3 yxx { get { return null; } set { } }
        public uvec3 yxy { get { return null; } set { } }
        public uvec3 yxz { get { return null; } set { } }
        public uvec3 yyx { get { return null; } set { } }
        public uvec3 yyy { get { return null; } set { } }
        public uvec3 yyz { get { return null; } set { } }
        public uvec3 yzx { get { return null; } set { } }
        public uvec3 yzy { get { return null; } set { } }
        public uvec3 yzz { get { return null; } set { } }
        public uvec3 zxx { get { return null; } set { } }
        public uvec3 zxy { get { return null; } set { } }
        public uvec3 zxz { get { return null; } set { } }
        public uvec3 zyx { get { return null; } set { } }
        public uvec3 zyy { get { return null; } set { } }
        public uvec3 zyz { get { return null; } set { } }
        public uvec3 zzx { get { return null; } set { } }
        public uvec3 zzy { get { return null; } set { } }
        public uvec3 zzz { get { return null; } set { } }

        public uint r { get { return 0; } set { } }
        public uint g { get { return 0; } set { } }
        public uint b { get { return 0; } set { } }

        public vec2 rr { get { return null; } set { } }
        public vec2 rg { get { return null; } set { } }
        public vec2 rb { get { return null; } set { } }
        public vec2 gr { get { return null; } set { } }
        public vec2 gg { get { return null; } set { } }
        public vec2 gb { get { return null; } set { } }
        public vec2 br { get { return null; } set { } }
        public vec2 bg { get { return null; } set { } }
        public vec2 bb { get { return null; } set { } }

        public uvec3 rrr { get { return null; } set { } }
        public uvec3 rrg { get { return null; } set { } }
        public uvec3 rrb { get { return null; } set { } }
        public uvec3 rgr { get { return null; } set { } }
        public uvec3 rgg { get { return null; } set { } }
        public uvec3 rgb { get { return null; } set { } }
        public uvec3 rbr { get { return null; } set { } }
        public uvec3 rbg { get { return null; } set { } }
        public uvec3 rbb { get { return null; } set { } }
        public uvec3 grr { get { return null; } set { } }
        public uvec3 grg { get { return null; } set { } }
        public uvec3 grb { get { return null; } set { } }
        public uvec3 ggr { get { return null; } set { } }
        public uvec3 ggg { get { return null; } set { } }
        public uvec3 ggb { get { return null; } set { } }
        public uvec3 gbr { get { return null; } set { } }
        public uvec3 gbg { get { return null; } set { } }
        public uvec3 gbb { get { return null; } set { } }
        public uvec3 brr { get { return null; } set { } }
        public uvec3 brg { get { return null; } set { } }
        public uvec3 brb { get { return null; } set { } }
        public uvec3 bgr { get { return null; } set { } }
        public uvec3 bgg { get { return null; } set { } }
        public uvec3 bgb { get { return null; } set { } }
        public uvec3 bbr { get { return null; } set { } }
        public uvec3 bbg { get { return null; } set { } }
        public uvec3 bbb { get { return null; } set { } }

        public uint s { get { return 0; } set { } }
        public uint t { get { return 0; } set { } }
        public uint p { get { return 0; } set { } }

        public vec2 ss { get { return null; } set { } }
        public vec2 st { get { return null; } set { } }
        public vec2 sp { get { return null; } set { } }
        public vec2 ts { get { return null; } set { } }
        public vec2 tt { get { return null; } set { } }
        public vec2 tp { get { return null; } set { } }
        public vec2 ps { get { return null; } set { } }
        public vec2 pt { get { return null; } set { } }
        public vec2 pp { get { return null; } set { } }

        public uvec3 sss { get { return null; } set { } }
        public uvec3 sst { get { return null; } set { } }
        public uvec3 ssp { get { return null; } set { } }
        public uvec3 sts { get { return null; } set { } }
        public uvec3 stt { get { return null; } set { } }
        public uvec3 stp { get { return null; } set { } }
        public uvec3 sps { get { return null; } set { } }
        public uvec3 spt { get { return null; } set { } }
        public uvec3 spp { get { return null; } set { } }
        public uvec3 tss { get { return null; } set { } }
        public uvec3 tst { get { return null; } set { } }
        public uvec3 tsp { get { return null; } set { } }
        public uvec3 tts { get { return null; } set { } }
        public uvec3 ttt { get { return null; } set { } }
        public uvec3 ttp { get { return null; } set { } }
        public uvec3 tps { get { return null; } set { } }
        public uvec3 tpt { get { return null; } set { } }
        public uvec3 tpp { get { return null; } set { } }
        public uvec3 pss { get { return null; } set { } }
        public uvec3 pst { get { return null; } set { } }
        public uvec3 psp { get { return null; } set { } }
        public uvec3 pts { get { return null; } set { } }
        public uvec3 ptt { get { return null; } set { } }
        public uvec3 ptp { get { return null; } set { } }
        public uvec3 pps { get { return null; } set { } }
        public uvec3 ppt { get { return null; } set { } }
        public uvec3 ppp { get { return null; } set { } }

        #endregion compositions

        public uint this[int index]
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        private uvec3()
        {
        }

        public static uvec3 operator -(uvec3 lhs)
        {
            return null;
        }

        public static uvec3 operator +(uvec3 lhs, uvec3 rhs)
        {
            return null;
        }

        public static uvec3 operator +(uvec3 lhs, double rhs)
        {
            return null;
        }

        public static uvec3 operator -(uvec3 lhs, uvec3 rhs)
        {
            return null;
        }

        public static uvec3 operator -(uvec3 lhs, double rhs)
        {
            return null;
        }

        public static uvec3 operator *(uvec3 self, double s)
        {
            return null;
        }

        public static uvec3 operator *(double lhs, uvec3 rhs)
        {
            return null;
        }

        public static uvec3 operator /(uvec3 lhs, double rhs)
        {
            return null;
        }

        public static uvec3 operator *(uvec3 lhs, uvec3 rhs)
        {
            return null;
        }

        public override string ToString()
        {
            return string.Format("CSSL's uvec3 type.");
        }
    }
}