using System;
using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// Represents a two dimensional vector.
    /// </summary>
    [TypeConverter(typeof(StructTypeConverter<uvec2>))]
    public struct uvec2 : IEquatable<uvec2>, ILoadFromString
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
        /// <param name="index"></param>
        /// <returns></returns>
        public uint this[int index]
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        public uvec2(uint s)
        {
            x = y = s;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public uvec2(uint x, uint y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public uvec2(uvec2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public uvec2(uvec3 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public uvec2(uvec4 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="lhs"></param>
        ///// <returns></returns>
        //public static uvec2 operator -(uvec2 lhs)
        //{
        //    return new uvec2(-lhs.x, -lhs.y);
        //}
        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static uvec2 operator +(uvec2 lhs, uvec2 rhs)
        {
            return new uvec2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static uvec2 operator +(uvec2 lhs, uint rhs)
        {
            return new uvec2(lhs.x + rhs, lhs.y + rhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static uvec2 operator -(uvec2 lhs, uvec2 rhs)
        {
            return new uvec2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static uvec2 operator -(uvec2 lhs, uint rhs)
        {
            return new uvec2(lhs.x - rhs, lhs.y - rhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="self"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static uvec2 operator *(uvec2 self, uint s)
        {
            return new uvec2(self.x * s, self.y * s);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static uvec2 operator *(uint lhs, uvec2 rhs)
        {
            return new uvec2(rhs.x * lhs, rhs.y * lhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static uvec2 operator *(uvec2 lhs, uvec2 rhs)
        {
            return new uvec2(rhs.x * lhs.x, rhs.y * lhs.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static uvec2 operator /(uvec2 lhs, uint rhs)
        {
            return new uvec2(lhs.x / rhs, lhs.y / rhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public uint dot(uvec2 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y;
            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public float length()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y);

            return (float)result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(uvec2 lhs, uvec2 rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(uvec2 lhs, uvec2 rhs)
        {
            return (lhs.x != rhs.x || lhs.y != rhs.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is uvec2) && (this.Equals((uvec2)obj));
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return string.Format("{0}#{1}", x, y).GetHashCode();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public uint[] ToArray()
        {
            return new[] { x, y };
        }

        ///// <summary>
        ///// 归一化向量
        ///// </summary>
        ///// <returns></returns>
        //public uvec2 normalize()
        //{
        //    var frt = (uint)Math.Sqrt(this.x * this.x + this.y * this.y);

        //    return new uvec2(x / frt, y / frt);
        //}
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}", x, y);
        }

        internal static uvec2 Parse(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            uint x = uint.Parse(parts[0]);
            uint y = uint.Parse(parts[1]);
            return new uvec2(x, y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(uvec2 other)
        {
            return (this.x == other.x && this.y == other.y);
        }

        void ILoadFromString.Load(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            this.x = uint.Parse(parts[0]);
            this.y = uint.Parse(parts[1]);
        }
    }
}