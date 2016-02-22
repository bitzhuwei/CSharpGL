using System;
using System.Runtime.InteropServices;

namespace CSharpShadingLanguage
{
    /// <summary>
    /// Represents a three dimensional vector.
    /// </summary>
    public class vec3
    {
        internal float a0;
        internal float a1;
        internal float a2;

        #region compositions

        public float x { get { return a0; } set { a0 = x; } }
        public float y { get { return a1; } set { a1 = y; } }
        public float z { get { return a2; } set { a2 = z; } }

        public vec2 xx { get { return new vec2(x, x); } set { this.x = value.a0; this.x = value.a1; } }
        public vec2 xy { get { return new vec2(x, y); } set { this.x = value.a0; this.y = value.a1; } }
        public vec2 xz { get { return new vec2(x, z); } set { this.x = value.a0; this.z = value.a1; } }
        public vec2 yx { get { return new vec2(y, x); } set { this.y = value.a0; this.x = value.a1; } }
        public vec2 yy { get { return new vec2(y, y); } set { this.y = value.a0; this.y = value.a1; } }
        public vec2 yz { get { return new vec2(y, z); } set { this.y = value.a0; this.z = value.a1; } }
        public vec2 zx { get { return new vec2(z, x); } set { this.z = value.a0; this.x = value.a1; } }
        public vec2 zy { get { return new vec2(z, y); } set { this.z = value.a0; this.y = value.a1; } }
        public vec2 zz { get { return new vec2(z, z); } set { this.z = value.a0; this.z = value.a1; } }

        public vec3 xxx { get { return new vec3(x, x, x); } set { this.x = value.a0; this.x = value.a1; this.x = value.a2; } }
        public vec3 xxy { get { return new vec3(x, x, y); } set { this.x = value.a0; this.x = value.a1; this.y = value.a2; } }
        public vec3 xxz { get { return new vec3(x, x, z); } set { this.x = value.a0; this.x = value.a1; this.z = value.a2; } }
        public vec3 xyx { get { return new vec3(x, y, x); } set { this.x = value.a0; this.y = value.a1; this.x = value.a2; } }
        public vec3 xyy { get { return new vec3(x, y, y); } set { this.x = value.a0; this.y = value.a1; this.y = value.a2; } }
        public vec3 xyz { get { return new vec3(x, y, z); } set { this.x = value.a0; this.y = value.a1; this.z = value.a2; } }
        public vec3 xzx { get { return new vec3(x, z, x); } set { this.x = value.a0; this.z = value.a1; this.x = value.a2; } }
        public vec3 xzy { get { return new vec3(x, z, y); } set { this.x = value.a0; this.z = value.a1; this.y = value.a2; } }
        public vec3 xzz { get { return new vec3(x, z, z); } set { this.x = value.a0; this.z = value.a1; this.z = value.a2; } }
        public vec3 yxx { get { return new vec3(y, x, x); } set { this.y = value.a0; this.x = value.a1; this.x = value.a2; } }
        public vec3 yxy { get { return new vec3(y, x, y); } set { this.y = value.a0; this.x = value.a1; this.y = value.a2; } }
        public vec3 yxz { get { return new vec3(y, x, z); } set { this.y = value.a0; this.x = value.a1; this.z = value.a2; } }
        public vec3 yyx { get { return new vec3(y, y, x); } set { this.y = value.a0; this.y = value.a1; this.x = value.a2; } }
        public vec3 yyy { get { return new vec3(y, y, y); } set { this.y = value.a0; this.y = value.a1; this.y = value.a2; } }
        public vec3 yyz { get { return new vec3(y, y, z); } set { this.y = value.a0; this.y = value.a1; this.z = value.a2; } }
        public vec3 yzx { get { return new vec3(y, z, x); } set { this.y = value.a0; this.z = value.a1; this.x = value.a2; } }
        public vec3 yzy { get { return new vec3(y, z, y); } set { this.y = value.a0; this.z = value.a1; this.y = value.a2; } }
        public vec3 yzz { get { return new vec3(y, z, z); } set { this.y = value.a0; this.z = value.a1; this.z = value.a2; } }
        public vec3 zxx { get { return new vec3(z, x, x); } set { this.z = value.a0; this.x = value.a1; this.x = value.a2; } }
        public vec3 zxy { get { return new vec3(z, x, y); } set { this.z = value.a0; this.x = value.a1; this.y = value.a2; } }
        public vec3 zxz { get { return new vec3(z, x, z); } set { this.z = value.a0; this.x = value.a1; this.z = value.a2; } }
        public vec3 zyx { get { return new vec3(z, y, x); } set { this.z = value.a0; this.y = value.a1; this.x = value.a2; } }
        public vec3 zyy { get { return new vec3(z, y, y); } set { this.z = value.a0; this.y = value.a1; this.y = value.a2; } }
        public vec3 zyz { get { return new vec3(z, y, z); } set { this.z = value.a0; this.y = value.a1; this.z = value.a2; } }
        public vec3 zzx { get { return new vec3(z, z, x); } set { this.z = value.a0; this.z = value.a1; this.x = value.a2; } }
        public vec3 zzy { get { return new vec3(z, z, y); } set { this.z = value.a0; this.z = value.a1; this.y = value.a2; } }
        public vec3 zzz { get { return new vec3(z, z, z); } set { this.z = value.a0; this.z = value.a1; this.z = value.a2; } }

        public float r { get { return a0; } set { a0 = r; } }
        public float g { get { return a1; } set { a1 = g; } }
        public float b { get { return a2; } set { a2 = b; } }

        public vec2 rr { get { return new vec2(r, r); } set { this.r = value.a0; this.r = value.a1; } }
        public vec2 rg { get { return new vec2(r, g); } set { this.r = value.a0; this.g = value.a1; } }
        public vec2 rb { get { return new vec2(r, b); } set { this.r = value.a0; this.b = value.a1; } }
        public vec2 gr { get { return new vec2(g, r); } set { this.g = value.a0; this.r = value.a1; } }
        public vec2 gg { get { return new vec2(g, g); } set { this.g = value.a0; this.g = value.a1; } }
        public vec2 gb { get { return new vec2(g, b); } set { this.g = value.a0; this.b = value.a1; } }
        public vec2 br { get { return new vec2(b, r); } set { this.b = value.a0; this.r = value.a1; } }
        public vec2 bg { get { return new vec2(b, g); } set { this.b = value.a0; this.g = value.a1; } }
        public vec2 bb { get { return new vec2(b, b); } set { this.b = value.a0; this.b = value.a1; } }

        public vec3 rrr { get { return new vec3(r, r, r); } set { this.r = value.a0; this.r = value.a1; this.r = value.a2; } }
        public vec3 rrg { get { return new vec3(r, r, g); } set { this.r = value.a0; this.r = value.a1; this.g = value.a2; } }
        public vec3 rrb { get { return new vec3(r, r, b); } set { this.r = value.a0; this.r = value.a1; this.b = value.a2; } }
        public vec3 rgr { get { return new vec3(r, g, r); } set { this.r = value.a0; this.g = value.a1; this.r = value.a2; } }
        public vec3 rgg { get { return new vec3(r, g, g); } set { this.r = value.a0; this.g = value.a1; this.g = value.a2; } }
        public vec3 rgb { get { return new vec3(r, g, b); } set { this.r = value.a0; this.g = value.a1; this.b = value.a2; } }
        public vec3 rbr { get { return new vec3(r, b, r); } set { this.r = value.a0; this.b = value.a1; this.r = value.a2; } }
        public vec3 rbg { get { return new vec3(r, b, g); } set { this.r = value.a0; this.b = value.a1; this.g = value.a2; } }
        public vec3 rbb { get { return new vec3(r, b, b); } set { this.r = value.a0; this.b = value.a1; this.b = value.a2; } }
        public vec3 grr { get { return new vec3(g, r, r); } set { this.g = value.a0; this.r = value.a1; this.r = value.a2; } }
        public vec3 grg { get { return new vec3(g, r, g); } set { this.g = value.a0; this.r = value.a1; this.g = value.a2; } }
        public vec3 grb { get { return new vec3(g, r, b); } set { this.g = value.a0; this.r = value.a1; this.b = value.a2; } }
        public vec3 ggr { get { return new vec3(g, g, r); } set { this.g = value.a0; this.g = value.a1; this.r = value.a2; } }
        public vec3 ggg { get { return new vec3(g, g, g); } set { this.g = value.a0; this.g = value.a1; this.g = value.a2; } }
        public vec3 ggb { get { return new vec3(g, g, b); } set { this.g = value.a0; this.g = value.a1; this.b = value.a2; } }
        public vec3 gbr { get { return new vec3(g, b, r); } set { this.g = value.a0; this.b = value.a1; this.r = value.a2; } }
        public vec3 gbg { get { return new vec3(g, b, g); } set { this.g = value.a0; this.b = value.a1; this.g = value.a2; } }
        public vec3 gbb { get { return new vec3(g, b, b); } set { this.g = value.a0; this.b = value.a1; this.b = value.a2; } }
        public vec3 brr { get { return new vec3(b, r, r); } set { this.b = value.a0; this.r = value.a1; this.r = value.a2; } }
        public vec3 brg { get { return new vec3(b, r, g); } set { this.b = value.a0; this.r = value.a1; this.g = value.a2; } }
        public vec3 brb { get { return new vec3(b, r, b); } set { this.b = value.a0; this.r = value.a1; this.b = value.a2; } }
        public vec3 bgr { get { return new vec3(b, g, r); } set { this.b = value.a0; this.g = value.a1; this.r = value.a2; } }
        public vec3 bgg { get { return new vec3(b, g, g); } set { this.b = value.a0; this.g = value.a1; this.g = value.a2; } }
        public vec3 bgb { get { return new vec3(b, g, b); } set { this.b = value.a0; this.g = value.a1; this.b = value.a2; } }
        public vec3 bbr { get { return new vec3(b, b, r); } set { this.b = value.a0; this.b = value.a1; this.r = value.a2; } }
        public vec3 bbg { get { return new vec3(b, b, g); } set { this.b = value.a0; this.b = value.a1; this.g = value.a2; } }
        public vec3 bbb { get { return new vec3(b, b, b); } set { this.b = value.a0; this.b = value.a1; this.b = value.a2; } }

        public float s { get { return a0; } set { a0 = s; } }
        public float t { get { return a1; } set { a1 = t; } }
        public float p { get { return a2; } set { a2 = p; } }

        public vec2 ss { get { return new vec2(s, s); } set { this.s = value.a0; this.s = value.a1; } }
        public vec2 st { get { return new vec2(s, t); } set { this.s = value.a0; this.t = value.a1; } }
        public vec2 sp { get { return new vec2(s, p); } set { this.s = value.a0; this.p = value.a1; } }
        public vec2 ts { get { return new vec2(t, s); } set { this.t = value.a0; this.s = value.a1; } }
        public vec2 tt { get { return new vec2(t, t); } set { this.t = value.a0; this.t = value.a1; } }
        public vec2 tp { get { return new vec2(t, p); } set { this.t = value.a0; this.p = value.a1; } }
        public vec2 ps { get { return new vec2(p, s); } set { this.p = value.a0; this.s = value.a1; } }
        public vec2 pt { get { return new vec2(p, t); } set { this.p = value.a0; this.t = value.a1; } }
        public vec2 pp { get { return new vec2(p, p); } set { this.p = value.a0; this.p = value.a1; } }

        public vec3 sss { get { return new vec3(s, s, s); } set { this.s = value.a0; this.s = value.a1; this.s = value.a2; } }
        public vec3 sst { get { return new vec3(s, s, t); } set { this.s = value.a0; this.s = value.a1; this.t = value.a2; } }
        public vec3 ssp { get { return new vec3(s, s, p); } set { this.s = value.a0; this.s = value.a1; this.p = value.a2; } }
        public vec3 sts { get { return new vec3(s, t, s); } set { this.s = value.a0; this.t = value.a1; this.s = value.a2; } }
        public vec3 stt { get { return new vec3(s, t, t); } set { this.s = value.a0; this.t = value.a1; this.t = value.a2; } }
        public vec3 stp { get { return new vec3(s, t, p); } set { this.s = value.a0; this.t = value.a1; this.p = value.a2; } }
        public vec3 sps { get { return new vec3(s, p, s); } set { this.s = value.a0; this.p = value.a1; this.s = value.a2; } }
        public vec3 spt { get { return new vec3(s, p, t); } set { this.s = value.a0; this.p = value.a1; this.t = value.a2; } }
        public vec3 spp { get { return new vec3(s, p, p); } set { this.s = value.a0; this.p = value.a1; this.p = value.a2; } }
        public vec3 tss { get { return new vec3(t, s, s); } set { this.t = value.a0; this.s = value.a1; this.s = value.a2; } }
        public vec3 tst { get { return new vec3(t, s, t); } set { this.t = value.a0; this.s = value.a1; this.t = value.a2; } }
        public vec3 tsp { get { return new vec3(t, s, p); } set { this.t = value.a0; this.s = value.a1; this.p = value.a2; } }
        public vec3 tts { get { return new vec3(t, t, s); } set { this.t = value.a0; this.t = value.a1; this.s = value.a2; } }
        public vec3 ttt { get { return new vec3(t, t, t); } set { this.t = value.a0; this.t = value.a1; this.t = value.a2; } }
        public vec3 ttp { get { return new vec3(t, t, p); } set { this.t = value.a0; this.t = value.a1; this.p = value.a2; } }
        public vec3 tps { get { return new vec3(t, p, s); } set { this.t = value.a0; this.p = value.a1; this.s = value.a2; } }
        public vec3 tpt { get { return new vec3(t, p, t); } set { this.t = value.a0; this.p = value.a1; this.t = value.a2; } }
        public vec3 tpp { get { return new vec3(t, p, p); } set { this.t = value.a0; this.p = value.a1; this.p = value.a2; } }
        public vec3 pss { get { return new vec3(p, s, s); } set { this.p = value.a0; this.s = value.a1; this.s = value.a2; } }
        public vec3 pst { get { return new vec3(p, s, t); } set { this.p = value.a0; this.s = value.a1; this.t = value.a2; } }
        public vec3 psp { get { return new vec3(p, s, p); } set { this.p = value.a0; this.s = value.a1; this.p = value.a2; } }
        public vec3 pts { get { return new vec3(p, t, s); } set { this.p = value.a0; this.t = value.a1; this.s = value.a2; } }
        public vec3 ptt { get { return new vec3(p, t, t); } set { this.p = value.a0; this.t = value.a1; this.t = value.a2; } }
        public vec3 ptp { get { return new vec3(p, t, p); } set { this.p = value.a0; this.t = value.a1; this.p = value.a2; } }
        public vec3 pps { get { return new vec3(p, p, s); } set { this.p = value.a0; this.p = value.a1; this.s = value.a2; } }
        public vec3 ppt { get { return new vec3(p, p, t); } set { this.p = value.a0; this.p = value.a1; this.t = value.a2; } }
        public vec3 ppp { get { return new vec3(p, p, p); } set { this.p = value.a0; this.p = value.a1; this.p = value.a2; } }

        #endregion compositions


        public float this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return y;
                else if (index == 2) return z;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0) x = value;
                else if (index == 1) y = value;
                else if (index == 2) z = value;
                else throw new Exception("Out of range.");
            }
        }

        internal vec3() { }

        internal vec3(float s)
        {
            a0 = a1 = a2 = s;
        }

        internal vec3(float x, float y, float z)
        {
            this.a0 = x;
            this.a1 = y;
            this.a2 = z;
        }

        internal vec3(vec3 v)
        {
            this.a0 = v.x;
            this.a1 = v.y;
            this.a2 = v.z;
        }

        internal vec3(vec4 v)
        {
            this.a0 = v.x;
            this.a1 = v.y;
            this.a2 = v.z;
        }

        internal vec3(vec2 xy, float z)
        {
            this.a0 = xy.x;
            this.a1 = xy.y;
            this.a2 = z;
        }

        public static vec3 operator -(vec3 lhs)
        {
            return new vec3(-lhs.x, -lhs.y, -lhs.z);
        }

        public static vec3 operator +(vec3 lhs, vec3 rhs)
        {
            return new vec3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        //public static vec3 operator +(vec3 lhs, float rhs)
        //{
        //    return new vec3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);
        //}

        public static vec3 operator -(vec3 lhs, vec3 rhs)
        {
            return new vec3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        //public static vec3 operator -(vec3 lhs, float rhs)
        //{
        //    return new vec3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
        //}

        public static vec3 operator *(vec3 self, float s)
        {
            return new vec3(self.x * s, self.y * s, self.z * s);
        }
        public static vec3 operator *(float lhs, vec3 rhs)
        {
            return new vec3(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs);
        }

        public static vec3 operator /(vec3 lhs, float rhs)
        {
            return new vec3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }

        public static vec3 operator *(vec3 lhs, vec3 rhs)
        {
            return new vec3(rhs.x * lhs.x, rhs.y * lhs.y, rhs.z * lhs.z);
        }

        internal float dot(vec3 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y + this.z * rhs.z;
            return result;
        }

        internal float Magnitude()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);

            return (float)result;
        }

        internal vec3 cross(vec3 rhs)
        {
            return new vec3(
                this.y * rhs.z - rhs.y * this.z,
                this.z * rhs.x - rhs.z * this.x,
                this.x * rhs.y - rhs.x * this.y);
        }

        public static bool operator ==(vec3 lhs, vec3 rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z);
        }

        public static bool operator !=(vec3 lhs, vec3 rhs)
        {
            return !(lhs == rhs);
        }

        internal float[] to_array()
        {
            return new[] { x, y, z };
        }

        /// <summary>
        /// 归一化向量
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        internal vec3 normalize()
        {
            var frt = (float)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);

            return new vec3(x / frt, y / frt, z / frt);
        }

        public override string ToString()
        {
            return string.Format("vec3({0}, {1}, {2})", x, y, z);
            //return string.Format("{0:0.00},{1:0.00},{2:0.00}", x, y, z);
        }
    }
}