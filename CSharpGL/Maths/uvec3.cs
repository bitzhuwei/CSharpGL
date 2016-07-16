using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Represents a three dimensional vector.
    /// </summary>
    [TypeConverter(typeof(uvec3TypeConverter))]
    public struct uvec3 : IEquatable<uvec3>
    {

        /// <summary>
        /// 
        /// </summary>
        public uint x;

        /// <summary>
        /// 
        /// </summary>
        public uint y;

        /// <summary>
        /// 
        /// </summary>
        public uint z;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public uint this[int index]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public uvec3(uint s)
        {
            x = y = z = s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public uvec3(uint x, uint y, uint z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public uvec3(uvec3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public uvec3(uvec4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xy"></param>
        /// <param name="z"></param>
        public uvec3(uvec2 xy, uint z)
        {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="lhs"></param>
        ///// <returns></returns>
        //public static uvec3 operator -(uvec3 lhs)
        //{
        //    return new uvec3(-lhs.x, -lhs.y, -lhs.z);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static uvec3 operator +(uvec3 lhs, uvec3 rhs)
        {
            return new uvec3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        //public static uvec3 operator +(uvec3 lhs, uint rhs)
        //{
        //    return new uvec3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static uvec3 operator -(uvec3 lhs, uvec3 rhs)
        {
            return new uvec3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        //public static uvec3 operator -(uvec3 lhs, uint rhs)
        //{
        //    return new uvec3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static uvec3 operator *(uvec3 self, uint s)
        {
            return new uvec3(self.x * s, self.y * s, self.z * s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static uvec3 operator *(uint lhs, uvec3 rhs)
        {
            return new uvec3(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static uvec3 operator /(uvec3 lhs, uint rhs)
        {
            return new uvec3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static uvec3 operator *(uvec3 lhs, uvec3 rhs)
        {
            return new uvec3(rhs.x * lhs.x, rhs.y * lhs.y, rhs.z * lhs.z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public uint dot(uvec3 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y + this.z * rhs.z;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float length()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);

            return (float)result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public uvec3 cross(uvec3 rhs)
        {
            return new uvec3(
                this.y * rhs.z - rhs.y * this.z,
                this.z * rhs.x - rhs.z * this.x,
                this.x * rhs.y - rhs.x * this.y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(uvec3 lhs, uvec3 rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(uvec3 lhs, uvec3 rhs)
        {
            return (lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is uvec3) && (this.Equals((uvec3)obj));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return string.Format("{0}#{1}#{2}", x, y, z).GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint[] ToArray()
        {
            return new[] { x, y, z };
        }

        ///// <summary>
        ///// 归一化向量
        ///// </summary>
        ///// <returns></returns>
        //public uvec3 normalize()
        //{
        //    var frt = (uint)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);

        //    return new uvec3(x / frt, y / frt, z / frt);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", x, y, z);
        }

        internal static uvec3 Parse(string value)
        {
            string[] parts = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            uint x = uint.Parse(parts[0]);
            uint y = uint.Parse(parts[1]);
            uint z = uint.Parse(parts[2]);
            return new uvec3(x, y, z);
        }

        static readonly char[] separator = new char[] { ' ', ',' };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(uvec3 other)
        {
            return (this.x == other.x && this.y == other.y && this.z == other.z);
        }
    }
}