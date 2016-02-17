using System;
using System.Runtime.InteropServices;

namespace CSharpShadingLanguage
{
    /// <summary>
    /// Represents a three dimensional vector.
    /// </summary>
    public class vec3
    {
        public float x { get { return 0.0f; } set { } }
        public float y { get { return 0.0f; } set { } }
        public float z { get { return 0.0f; } set { } }

        public vec2 xx { get { return default(vec2); } set { } }
        public vec2 xy { get { return default(vec2); } set { } }
        public vec2 xz { get { return default(vec2); } set { } }
        public vec2 yx { get { return default(vec2); } set { } }
        public vec2 yy { get { return default(vec2); } set { } }
        public vec2 yz { get { return default(vec2); } set { } }
        public vec2 zx { get { return default(vec2); } set { } }
        public vec2 zy { get { return default(vec2); } set { } }
        public vec2 zz { get { return default(vec2); } set { } }

        public vec3 xxx { get { return default(vec3); } set { } }
        public vec3 xxy { get { return default(vec3); } set { } }
        public vec3 xxz { get { return default(vec3); } set { } }
        public vec3 xyx { get { return default(vec3); } set { } }
        public vec3 xyy { get { return default(vec3); } set { } }
        public vec3 xyz { get { return default(vec3); } set { } }
        public vec3 xzx { get { return default(vec3); } set { } }
        public vec3 xzy { get { return default(vec3); } set { } }
        public vec3 xzz { get { return default(vec3); } set { } }
        public vec3 yxx { get { return default(vec3); } set { } }
        public vec3 yxy { get { return default(vec3); } set { } }
        public vec3 yxz { get { return default(vec3); } set { } }
        public vec3 yyx { get { return default(vec3); } set { } }
        public vec3 yyy { get { return default(vec3); } set { } }
        public vec3 yyz { get { return default(vec3); } set { } }
        public vec3 yzx { get { return default(vec3); } set { } }
        public vec3 yzy { get { return default(vec3); } set { } }
        public vec3 yzz { get { return default(vec3); } set { } }
        public vec3 zxx { get { return default(vec3); } set { } }
        public vec3 zxy { get { return default(vec3); } set { } }
        public vec3 zxz { get { return default(vec3); } set { } }
        public vec3 zyx { get { return default(vec3); } set { } }
        public vec3 zyy { get { return default(vec3); } set { } }
        public vec3 zyz { get { return default(vec3); } set { } }
        public vec3 zzx { get { return default(vec3); } set { } }
        public vec3 zzy { get { return default(vec3); } set { } }
        public vec3 zzz { get { return default(vec3); } set { } }

        public float r { get { return 0.0f; } set { } }
        public float g { get { return 0.0f; } set { } }
        public float b { get { return 0.0f; } set { } }

        public vec2 rr { get { return default(vec2); } set { } }
        public vec2 rg { get { return default(vec2); } set { } }
        public vec2 rb { get { return default(vec2); } set { } }
        public vec2 gr { get { return default(vec2); } set { } }
        public vec2 gg { get { return default(vec2); } set { } }
        public vec2 gb { get { return default(vec2); } set { } }
        public vec2 br { get { return default(vec2); } set { } }
        public vec2 bg { get { return default(vec2); } set { } }
        public vec2 bb { get { return default(vec2); } set { } }

        public vec3 rrr { get { return default(vec3); } set { } }
        public vec3 rrg { get { return default(vec3); } set { } }
        public vec3 rrb { get { return default(vec3); } set { } }
        public vec3 rgr { get { return default(vec3); } set { } }
        public vec3 rgg { get { return default(vec3); } set { } }
        public vec3 rgb { get { return default(vec3); } set { } }
        public vec3 rbr { get { return default(vec3); } set { } }
        public vec3 rbg { get { return default(vec3); } set { } }
        public vec3 rbb { get { return default(vec3); } set { } }
        public vec3 grr { get { return default(vec3); } set { } }
        public vec3 grg { get { return default(vec3); } set { } }
        public vec3 grb { get { return default(vec3); } set { } }
        public vec3 ggr { get { return default(vec3); } set { } }
        public vec3 ggg { get { return default(vec3); } set { } }
        public vec3 ggb { get { return default(vec3); } set { } }
        public vec3 gbr { get { return default(vec3); } set { } }
        public vec3 gbg { get { return default(vec3); } set { } }
        public vec3 gbb { get { return default(vec3); } set { } }
        public vec3 brr { get { return default(vec3); } set { } }
        public vec3 brg { get { return default(vec3); } set { } }
        public vec3 brb { get { return default(vec3); } set { } }
        public vec3 bgr { get { return default(vec3); } set { } }
        public vec3 bgg { get { return default(vec3); } set { } }
        public vec3 bgb { get { return default(vec3); } set { } }
        public vec3 bbr { get { return default(vec3); } set { } }
        public vec3 bbg { get { return default(vec3); } set { } }
        public vec3 bbb { get { return default(vec3); } set { } }

        public float s { get { return 0.0f; } set { } }
        public float t { get { return 0.0f; } set { } }
        public float p { get { return 0.0f; } set { } }

        public vec2 ss { get { return default(vec2); } set { } }
        public vec2 st { get { return default(vec2); } set { } }
        public vec2 sp { get { return default(vec2); } set { } }
        public vec2 ts { get { return default(vec2); } set { } }
        public vec2 tt { get { return default(vec2); } set { } }
        public vec2 tp { get { return default(vec2); } set { } }
        public vec2 ps { get { return default(vec2); } set { } }
        public vec2 pt { get { return default(vec2); } set { } }
        public vec2 pp { get { return default(vec2); } set { } }

        public vec3 sss { get { return default(vec3); } set { } }
        public vec3 sst { get { return default(vec3); } set { } }
        public vec3 ssp { get { return default(vec3); } set { } }
        public vec3 sts { get { return default(vec3); } set { } }
        public vec3 stt { get { return default(vec3); } set { } }
        public vec3 stp { get { return default(vec3); } set { } }
        public vec3 sps { get { return default(vec3); } set { } }
        public vec3 spt { get { return default(vec3); } set { } }
        public vec3 spp { get { return default(vec3); } set { } }
        public vec3 tss { get { return default(vec3); } set { } }
        public vec3 tst { get { return default(vec3); } set { } }
        public vec3 tsp { get { return default(vec3); } set { } }
        public vec3 tts { get { return default(vec3); } set { } }
        public vec3 ttt { get { return default(vec3); } set { } }
        public vec3 ttp { get { return default(vec3); } set { } }
        public vec3 tps { get { return default(vec3); } set { } }
        public vec3 tpt { get { return default(vec3); } set { } }
        public vec3 tpp { get { return default(vec3); } set { } }
        public vec3 pss { get { return default(vec3); } set { } }
        public vec3 pst { get { return default(vec3); } set { } }
        public vec3 psp { get { return default(vec3); } set { } }
        public vec3 pts { get { return default(vec3); } set { } }
        public vec3 ptt { get { return default(vec3); } set { } }
        public vec3 ptp { get { return default(vec3); } set { } }
        public vec3 pps { get { return default(vec3); } set { } }
        public vec3 ppt { get { return default(vec3); } set { } }
        public vec3 ppp { get { return default(vec3); } set { } }


        public float this[int index] { get { throw new NotNeedToImplementException(); } set { } }

        public static vec3 operator +(vec3 lhs, vec3 rhs) { throw new NotNeedToImplementException(); }
        public static vec3 operator -(vec3 lhs, vec3 rhs) { throw new NotNeedToImplementException(); }
        public static vec3 operator *(vec3 self, float s) { throw new NotNeedToImplementException(); }
        public static vec3 operator *(float lhs, vec3 rhs) { throw new NotNeedToImplementException(); }
        public static vec3 operator /(vec3 lhs, float rhs) { throw new NotNeedToImplementException(); }
        public static vec3 operator *(vec3 lhs, vec3 rhs) { throw new NotNeedToImplementException(); }

    }
}