using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Represents a two dimensional vector.
    /// </summary>
    [TypeConverter(typeof(StructTypeConverter<ivec2>))]
    public struct ivec2 : IEquatable<ivec2>, ILoadFromString
    {
        /// <summary>
        /// 
        /// </summary>
        public int x;
        /// <summary>
        /// 
        /// </summary>
        public int y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int this[int index]
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
        public ivec2(int s)
        {
            x = y = s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public ivec2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public ivec2(ivec2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public ivec2(ivec3 v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public ivec2(ivec4 v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <returns></returns>
        public static ivec2 operator -(ivec2 lhs)
        {
            return new ivec2(-lhs.x, -lhs.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static ivec2 operator +(ivec2 lhs, ivec2 rhs)
        {
            return new ivec2(lhs.x + rhs.x, lhs.y + rhs.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static ivec2 operator +(ivec2 lhs, int rhs)
        {
            return new ivec2(lhs.x + rhs, lhs.y + rhs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static ivec2 operator -(ivec2 lhs, ivec2 rhs)
        {
            return new ivec2(lhs.x - rhs.x, lhs.y - rhs.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static ivec2 operator -(ivec2 lhs, int rhs)
        {
            return new ivec2(lhs.x - rhs, lhs.y - rhs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static ivec2 operator *(ivec2 self, int s)
        {
            return new ivec2(self.x * s, self.y * s);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static ivec2 operator *(int lhs, ivec2 rhs)
        {
            return new ivec2(rhs.x * lhs, rhs.y * lhs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static ivec2 operator *(ivec2 lhs, ivec2 rhs)
        {
            return new ivec2(rhs.x * lhs.x, rhs.y * lhs.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static ivec2 operator /(ivec2 lhs, int rhs)
        {
            return new ivec2(lhs.x / rhs, lhs.y / rhs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public int dot(ivec2 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y;
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int length()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y);

            return (int)result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(ivec2 lhs, ivec2 rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(ivec2 lhs, ivec2 rhs)
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
            return (obj is ivec2) && (this.Equals((ivec2)obj));
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
        public int[] ToArray()
        {
            return new[] { x, y };
        }

        /// <summary>
        /// 归一化向量
        /// </summary>
        /// <returns></returns>
        public ivec2 normalize()
        {
            var frt = (int)Math.Sqrt(this.x * this.x + this.y * this.y);

            return new ivec2(x / frt, y / frt);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}", x, y);
        }

        internal static ivec2 Parse(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            return new ivec2(x, y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ivec2 other)
        {
            return (this.x == other.x && this.y == other.y);
        }

        void ILoadFromString.Load(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            this.x = int.Parse(parts[0]);
            this.y = int.Parse(parts[1]);
        }
    }
}