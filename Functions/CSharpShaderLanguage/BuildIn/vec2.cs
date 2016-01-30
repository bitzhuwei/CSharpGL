using System;
using System.Runtime.InteropServices;

namespace CSharpShaderLanguage
{
    /// <summary>
    /// Represents a two dimensional vector.
    /// </summary>
    public struct vec2
    {
        public double x;
        public double y;

        public double this[int index]
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

        public vec2(double s)
        {
            x = y = s;
        }

        public vec2(double x, double y)
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

        public static vec2 operator +(vec2 lhs, vec2 rhs)
        {
            return new vec2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static vec2 operator +(vec2 lhs, double rhs)
        {
            return new vec2(lhs.x + rhs, lhs.y + rhs);
        }

        public static vec2 operator -(vec2 lhs, vec2 rhs)
        {
            return new vec2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static vec2 operator -(vec2 lhs, double rhs)
        {
            return new vec2(lhs.x - rhs, lhs.y - rhs);
        }

        public static vec2 operator *(vec2 self, double s)
        {
            return new vec2(self.x * s, self.y * s);
        }

        public static vec2 operator *(double lhs, vec2 rhs)
        {
            return new vec2(rhs.x * lhs, rhs.y * lhs);
        }

        public static vec2 operator *(vec2 lhs, vec2 rhs)
        {
            return new vec2(rhs.x * lhs.x, rhs.y * lhs.y);
        }

        public static vec2 operator /(vec2 lhs, double rhs)
        {
            return new vec2(lhs.x / rhs, lhs.y / rhs);
        }

        public double dot(vec2 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y;
            return result;
        }

        public double Magnitude()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y);

            return (double)result;

        }
        public double[] to_array()
        {
            return new[] { x, y };
        }

        /// <summary>
        /// 归一化向量
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public void Normalize()
        {
            var frt = (double)Math.Sqrt(this.x * this.x + this.y * this.y);

            this.x = x / frt;
            this.y = y / frt;
        }

        public override string ToString()
        {
            return string.Format("{0:0.00},{1:0.00}", x, y);
        }
    }
}