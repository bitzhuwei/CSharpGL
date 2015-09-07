using System;
using System.Runtime.InteropServices;

namespace CSharpGL.Maths
{
    /// <summary>
    /// Represents a three dimensional vector.
    /// </summary>
    public struct vec3
    {
        public float x;
        public float y;
        public float z;

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

        public vec3(float s)
        {
            x = y = z = s;
        }

        public vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public vec3(vec3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        public vec3(vec4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        public vec3(vec2 xy, float z)
        {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
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

        public float dot(vec3 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y + this.z * rhs.z;
            return result;
        }

        public float Magnitude()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);

            return (float)result;
        }

        public vec3 cross(vec3 rhs)
        {
            return new vec3(
                this.y * rhs.z - rhs.y * this.z,
                this.z * rhs.x - rhs.z * this.x,
                this.x * rhs.y - rhs.x * this.y);
        }

        public float[] to_array()
        {
            return new[] { x, y, z };
        }

        /// <summary>
        /// 归一化向量
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public void Normalize()
        {
            var frt = (float)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);

            this.x = x / frt;
            this.y = y / frt;
            this.z = z / frt;
        }

        public override string ToString()
        {
            return string.Format("{0:0.00},{1:0.00},{2:0.00}", x, y, z);
        }
    }
}