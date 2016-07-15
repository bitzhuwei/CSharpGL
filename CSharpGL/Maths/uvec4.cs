using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Represents a four dimensional vector.
    /// </summary>
    //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 4 * 4)]   
    [TypeConverter(typeof(uvec4TypeConverter))]
    public struct uvec4 : IEquatable<uvec4>
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
        public uint w;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public uint this[uint index]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public uvec4(uint s)
        {
            x = y = z = w = s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public uvec4(uint x, uint y, uint z, uint w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public uvec4(uvec4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xyz"></param>
        /// <param name="w"></param>
        public uvec4(uvec3 xyz, uint w)
        {
            this.x = xyz.x;
            this.y = xyz.y;
            this.z = xyz.z;
            this.w = w;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="lhs"></param>
        ///// <returns></returns>
        //public static uvec4 operator -(uvec4 lhs)
        //{
        //    return new uvec4(-lhs.x, -lhs.y, -lhs.z, -lhs.w);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static uvec4 operator +(uvec4 lhs, uvec4 rhs)
        {
            return new uvec4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        }

        //public static uvec4 operator +(uvec4 lhs, uint rhs)
        //{
        //    return new uvec4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);
        //}

        //public static uvec4 operator -(uvec4 lhs, uint rhs)
        //{
        //    return new uvec4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static uvec4 operator -(uvec4 lhs, uvec4 rhs)
        {
            return new uvec4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static uvec4 operator *(uvec4 self, uint s)
        {
            return new uvec4(self.x * s, self.y * s, self.z * s, self.w * s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static uvec4 operator *(uint lhs, uvec4 rhs)
        {
            return new uvec4(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs, rhs.w * lhs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static uvec4 operator *(uvec4 lhs, uvec4 rhs)
        {
            return new uvec4(rhs.x * lhs.x, rhs.y * lhs.y, rhs.z * lhs.z, rhs.w * lhs.w);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static uvec4 operator /(uvec4 lhs, uint rhs)
        {
            return new uvec4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public uint dot(uvec4 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y + this.z * rhs.z + this.w * rhs.w;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint length()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);

            return (uint)result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(uvec4 lhs, uvec4 rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z && lhs.w == rhs.w);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(uvec4 lhs, uvec4 rhs)
        {
            return (lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z || lhs.w != rhs.w);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is uvec4) && (this.Equals((uvec4)obj));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return string.Format("{0}#{1}#{2}#{3}", x, y, z, w).GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint[] to_array()
        {
            return new[] { x, y, z, w };
        }

        /// <summary>
        /// 归一化向量
        /// </summary>
        /// <returns></returns>
        public uvec4 normalize()
        {
            var frt = (uint)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);

            return new uvec4(x / frt, y / frt, z / frt, w / frt);
            ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", x, y, z, w);
        }

        internal static uvec4 Parse(string value)
        {
            string[] parts = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            uint x = uint.Parse(parts[0]);
            uint y = uint.Parse(parts[1]);
            uint z = uint.Parse(parts[2]);
            uint w = uint.Parse(parts[3]);
            return new uvec4(x, y, z, w);
        }

        static readonly char[] separator = new char[] { ' ', ',' };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(uvec4 other)
        {
            return (this.x == other.x && this.y == other.y && this.z == other.z && this.w == other.w);
        }
    }
}