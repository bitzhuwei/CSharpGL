using System;
using System.Runtime.InteropServices;

namespace CSharpShadingLanguage
{
    /// <summary>
    /// Represents a two dimensional vector.
    /// </summary>
    public class vec2
    {
        internal float a0;
        internal float a1;

        #region compositions

        public float x { get { return a0; } set { a0 = x; } }
        public float y { get { return a1; } set { a1 = y; } }

        public vec2 xx { get { return new vec2(x, x); } set { this.x = value.a0; this.x = value.a1; } }
        public vec2 xy { get { return new vec2(x, y); } set { this.x = value.a0; this.y = value.a1; } }
        public vec2 yx { get { return new vec2(y, x); } set { this.y = value.a0; this.x = value.a1; } }
        public vec2 yy { get { return new vec2(y, y); } set { this.y = value.a0; this.y = value.a1; } }

        public float r { get { return a0; } set { a0 = r; } }
        public float g { get { return a1; } set { a1 = g; } }

        public vec2 rr { get { return new vec2(r, r); } set { this.r = value.a0; this.r = value.a1; } }
        public vec2 rg { get { return new vec2(r, g); } set { this.r = value.a0; this.g = value.a1; } }
        public vec2 gr { get { return new vec2(g, r); } set { this.g = value.a0; this.r = value.a1; } }
        public vec2 gg { get { return new vec2(g, g); } set { this.g = value.a0; this.g = value.a1; } }

        public float s { get { return a0; } set { a0 = s; } }
        public float t { get { return a1; } set { a1 = t; } }

        public vec2 ss { get { return new vec2(s, s); } set { this.s = value.a0; this.s = value.a1; } }
        public vec2 st { get { return new vec2(s, t); } set { this.s = value.a0; this.t = value.a1; } }
        public vec2 ts { get { return new vec2(t, s); } set { this.t = value.a0; this.s = value.a1; } }
        public vec2 tt { get { return new vec2(t, t); } set { this.t = value.a0; this.t = value.a1; } }

        #endregion compositions


        public float this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return y;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0) x = value;
                else if (index == 1) y = value;
                else throw new Exception("Out of range.");
            }
        }

        internal vec2() { }

        internal vec2(float s)
        {
            a0 = a1 = s;
        }

        internal vec2(float x, float y)
        {
            this.a0 = x;
            this.a1 = y;
        }

        internal vec2(vec2 v)
        {
            this.a0 = v.x;
            this.a1 = v.y;
        }

        internal vec2(vec3 v)
        {
            this.a0 = v.x;
            this.a1 = v.y;
        }

        public static vec2 operator -(vec2 lhs)
        {
            return new vec2(-lhs.x, -lhs.y);
        }

        public static vec2 operator +(vec2 lhs, vec2 rhs)
        {
            return new vec2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static vec2 operator +(vec2 lhs, float rhs)
        {
            return new vec2(lhs.x + rhs, lhs.y + rhs);
        }

        public static vec2 operator -(vec2 lhs, vec2 rhs)
        {
            return new vec2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static vec2 operator -(vec2 lhs, float rhs)
        {
            return new vec2(lhs.x - rhs, lhs.y - rhs);
        }

        public static vec2 operator *(vec2 self, float s)
        {
            return new vec2(self.x * s, self.y * s);
        }

        public static vec2 operator *(float lhs, vec2 rhs)
        {
            return new vec2(rhs.x * lhs, rhs.y * lhs);
        }

        public static vec2 operator *(vec2 lhs, vec2 rhs)
        {
            return new vec2(rhs.x * lhs.x, rhs.y * lhs.y);
        }

        public static vec2 operator /(vec2 lhs, float rhs)
        {
            return new vec2(lhs.x / rhs, lhs.y / rhs);
        }

        internal float dot(vec2 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y;
            return result;
        }

        internal float Magnitude()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y);

            return (float)result;

        }
        internal float[] to_array()
        {
            return new[] { x, y };
        }

        /// <summary>
        /// 归一化向量
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        internal vec2 normalize()
        {
            var frt = (float)Math.Sqrt(this.x * this.x + this.y * this.y);

            return new vec2(x / frt, y / frt);
        }

        public override string ToString()
        {
            return string.Format("vec2({0}, {1})", x, y);
            //return string.Format("{0:0.00},{1:0.00}", x, y);
            //return string.Format("{0}, {1}", x.ToShortString(), y.ToShortString());
        }
    }
}