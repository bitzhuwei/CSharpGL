using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Represents a two dimensional vector.
    /// </summary>
    [TypeConverter(typeof(Vec2TypeConverter))]
    public struct vec2
    {
        public float x;
        public float y;

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

        public vec2(float s)
        {
            x = y = s;
        }

        public vec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public vec2(vec2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        public vec2(vec3 v)
        {
            this.x = v.x;
            this.y = v.y;
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

        public float dot(vec2 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y;
            return result;
        }

        public float Magnitude()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y);

            return (float)result;

        }
        public static bool operator ==(vec2 lhs, vec2 rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y);
        }

        public static bool operator !=(vec2 lhs, vec2 rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            vec2 p = (vec2)obj;
            return (this == p);
        }

        public override int GetHashCode()
        {
            return string.Format("{0},{1}", x, y).GetHashCode();
        }

        public float[] to_array()
        {
            return new[] { x, y };
        }

        /// <summary>
        /// 归一化向量
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public vec2 normalize()
        {
            var frt = (float)Math.Sqrt(this.x * this.x + this.y * this.y);

            return new vec2(x / frt, y / frt);
        }

        public override string ToString()
        {
            //return string.Format("{0:0.00},{1:0.00}", x, y);
            return string.Format("{0}, {1}", x.ToShortString(), y.ToShortString());
        }

        internal static vec2 Parse(string value)
        {
            string[] parts = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            float x = float.Parse(parts[0]);
            float y = float.Parse(parts[1]);
            return new vec2(x, y);
        }

        static readonly char[] separator = new char[] { ' ', ',' };
    }
}