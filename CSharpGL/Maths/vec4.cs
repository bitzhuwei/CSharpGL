using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Represents a four dimensional vector.
    /// </summary>
    //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 4 * 4)]   
    [TypeConverter(typeof(Vec4TypeConverter))]
    public struct vec4 : IEquatable<vec4>
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public float this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return y;
                else if (index == 2) return z;
                else if (index == 3) return w;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0) x = value;
                else if (index == 1) y = value;
                else if (index == 2) z = value;
                else if (index == 3) w = value;
                else throw new Exception("Out of range.");
            }
        }

        public vec4(float s)
        {
            x = y = z = w = s;
        }

        public vec4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public vec4(vec4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }

        public vec4(vec3 xyz, float w)
        {
            this.x = xyz.x;
            this.y = xyz.y;
            this.z = xyz.z;
            this.w = w;
        }

        public static vec4 operator -(vec4 lhs)
        {
            return new vec4(-lhs.x, -lhs.y, -lhs.z, -lhs.w);
        }

        public static vec4 operator +(vec4 lhs, vec4 rhs)
        {
            return new vec4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        }

        //public static vec4 operator +(vec4 lhs, float rhs)
        //{
        //    return new vec4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);
        //}

        //public static vec4 operator -(vec4 lhs, float rhs)
        //{
        //    return new vec4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);
        //}

        public static vec4 operator -(vec4 lhs, vec4 rhs)
        {
            return new vec4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        }

        public static vec4 operator *(vec4 self, float s)
        {
            return new vec4(self.x * s, self.y * s, self.z * s, self.w * s);
        }

        public static vec4 operator *(float lhs, vec4 rhs)
        {
            return new vec4(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs, rhs.w * lhs);
        }

        public static vec4 operator *(vec4 lhs, vec4 rhs)
        {
            return new vec4(rhs.x * lhs.x, rhs.y * lhs.y, rhs.z * lhs.z, rhs.w * lhs.w);
        }

        public static vec4 operator /(vec4 lhs, float rhs)
        {
            return new vec4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        }

        public float dot(vec4 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y + this.z * rhs.z + this.w * rhs.w;
            return result;
        }

        public float length()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);

            return (float)result;
        }

        public static bool operator ==(vec4 lhs, vec4 rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z && lhs.w == rhs.w);
        }

        public static bool operator !=(vec4 lhs, vec4 rhs)
        {
            return (lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z || lhs.w != rhs.w);
        }

        public override bool Equals(object obj)
        {
            return (obj is vec4) && (this.Equals((vec4)obj));
        }

        public override int GetHashCode()
        {
            return string.Format("{0}#{1}#{2}#{3}", x, y, z, w).GetHashCode();
        }

        public float[] to_array()
        {
            return new[] { x, y, z, w };
        }

        /// <summary>
        /// 归一化向量
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public vec4 normalize()
        {
            var frt = (float)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);

            return new vec4(x / frt, y / frt, z / frt, w / frt);
            ;
        }

        public override string ToString()
        {
            //return string.Format("{0:0.00},{1:0.00},{2:0.00},{3:0.00}", x, y, z, w);
            return string.Format("{0}, {1}, {2}, {3}", x.ToShortString(), y.ToShortString(), z.ToShortString(), w.ToShortString());
            //return base.ToString();
        }


        internal static vec4 Parse(string value)
        {
            string[] parts = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            float x = float.Parse(parts[0]);
            float y = float.Parse(parts[1]);
            float z = float.Parse(parts[2]);
            float w = float.Parse(parts[3]);
            return new vec4(x, y, z, w);
        }

        static readonly char[] separator = new char[] { ' ', ',' };

        public bool Equals(vec4 other)
        {
            return (this.x == other.x && this.y == other.y && this.z == other.z && this.w == other.w);
        }
    }
}