using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Represents a three dimensional vector.
    /// </summary>
    [TypeConverter(typeof(VectorTypeConverter<ivec3>))]
    public struct ivec3 : IEquatable<ivec3>, ILoadFromString
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
        public int z;

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
        public ivec3(int s)
        {
            x = y = z = s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public ivec3(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public ivec3(ivec3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public ivec3(ivec4 v)
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
        public ivec3(ivec2 xy, int z)
        {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <returns></returns>
        public static ivec3 operator -(ivec3 lhs)
        {
            return new ivec3(-lhs.x, -lhs.y, -lhs.z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static ivec3 operator +(ivec3 lhs, ivec3 rhs)
        {
            return new ivec3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        //public static ivec3 operator +(ivec3 lhs, int rhs)
        //{
        //    return new ivec3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static ivec3 operator -(ivec3 lhs, ivec3 rhs)
        {
            return new ivec3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        //public static ivec3 operator -(ivec3 lhs, int rhs)
        //{
        //    return new ivec3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static ivec3 operator *(ivec3 self, int s)
        {
            return new ivec3(self.x * s, self.y * s, self.z * s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static ivec3 operator *(int lhs, ivec3 rhs)
        {
            return new ivec3(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static ivec3 operator /(ivec3 lhs, int rhs)
        {
            return new ivec3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static ivec3 operator *(ivec3 lhs, ivec3 rhs)
        {
            return new ivec3(rhs.x * lhs.x, rhs.y * lhs.y, rhs.z * lhs.z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public int dot(ivec3 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y + this.z * rhs.z;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int length()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);

            return (int)result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public ivec3 cross(ivec3 rhs)
        {
            return new ivec3(
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
        public static bool operator ==(ivec3 lhs, ivec3 rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(ivec3 lhs, ivec3 rhs)
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
            return (obj is ivec3) && (this.Equals((ivec3)obj));
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
        public int[] ToArray()
        {
            return new[] { x, y, z };
        }

        /// <summary>
        /// 归一化向量
        /// </summary>
        /// <returns></returns>
        public ivec3 normalize()
        {
            var frt = (int)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);

            return new ivec3(x / frt, y / frt, z / frt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", x, y, z);
        }

        internal static ivec3 Parse(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            int z = int.Parse(parts[2]);
            return new ivec3(x, y, z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ivec3 other)
        {
            return (this.x == other.x && this.y == other.y && this.z == other.z);
        }

        void ILoadFromString.Load(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            this.x = int.Parse(parts[0]);
            this.y = int.Parse(parts[1]);
            this.z = int.Parse(parts[2]);
        }
    }
}