using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Represents a two dimensional vector.
    /// </summary>
    [TypeConverter(typeof(bvec2TypeConverter))]
    public struct bvec2 : IEquatable<bvec2>
    {
        /// <summary>
        /// 
        /// </summary>
        public bool x;
        /// <summary>
        /// 
        /// </summary>
        public bool y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool this[int index]
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
        public bvec2(bool s)
        {
            x = y = s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public bvec2(bool x, bool y)
        {
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public bvec2(bvec2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public bvec2(bvec3 v)
        {
            this.x = v.x;
            this.y = v.y;
        }
           /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public bvec2(bvec4 v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(bvec2 lhs, bvec2 rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(bvec2 lhs, bvec2 rhs)
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
            return (obj is bvec2) && (this.Equals((bvec2)obj));
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
        public bool[] ToArray()
        {
            return new[] { x, y };
        }

        ///// <summary>
        ///// 归一化向量
        ///// </summary>
        ///// <returns></returns>
        //public bvec2 normalize()
        //{
        //    var frt = (bool)Math.Sqrt(this.x * this.x + this.y * this.y);

        //    return new bvec2(x / frt, y / frt);
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}", x, y);
        }

        internal static bvec2 Parse(string value)
        {
            string[] parts = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            bool x = bool.Parse(parts[0]);
            bool y = bool.Parse(parts[1]);
            return new bvec2(x, y);
        }

        static readonly char[] separator = new char[] { ' ', ',' };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(bvec2 other)
        {
            return (this.x == other.x && this.y == other.y);
        }
    }
}