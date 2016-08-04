using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Represents a two dimensional vector.
    /// </summary>
    [TypeConverter(typeof(StructTypeConverter<vec2>))]
    public struct vec2 : IEquatable<vec2>, ILoadFromString
    {
        /// <summary>
        /// 
        /// </summary>
        public float x;
        /// <summary>
        /// 
        /// </summary>
        public float y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public vec2(float s)
        {
            x = y = s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public vec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public vec2(vec2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public vec2(vec3 v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public vec2(vec4 v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <returns></returns>
        public static vec2 operator -(vec2 lhs)
        {
            return new vec2(-lhs.x, -lhs.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec2 operator +(vec2 lhs, vec2 rhs)
        {
            return new vec2(lhs.x + rhs.x, lhs.y + rhs.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec2 operator +(vec2 lhs, float rhs)
        {
            return new vec2(lhs.x + rhs, lhs.y + rhs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec2 operator -(vec2 lhs, vec2 rhs)
        {
            return new vec2(lhs.x - rhs.x, lhs.y - rhs.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec2 operator -(vec2 lhs, float rhs)
        {
            return new vec2(lhs.x - rhs, lhs.y - rhs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static vec2 operator *(vec2 self, float s)
        {
            return new vec2(self.x * s, self.y * s);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec2 operator *(float lhs, vec2 rhs)
        {
            return new vec2(rhs.x * lhs, rhs.y * lhs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec2 operator *(vec2 lhs, vec2 rhs)
        {
            return new vec2(rhs.x * lhs.x, rhs.y * lhs.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec2 operator /(vec2 lhs, float rhs)
        {
            return new vec2(lhs.x / rhs, lhs.y / rhs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public float dot(vec2 rhs)
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
        public static bool operator ==(vec2 lhs, vec2 rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(vec2 lhs, vec2 rhs)
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
            return (obj is vec2) && (this.Equals((vec2)obj));
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
        public float[] ToArray()
        {
            return new[] { x, y };
        }

        /// <summary>
        /// 归一化向量
        /// </summary>
        /// <returns></returns>
        public vec2 normalize()
        {
            var frt = (float)Math.Sqrt(this.x * this.x + this.y * this.y);

            return new vec2(x / frt, y / frt);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //return string.Format("{0:0.00},{1:0.00}", x, y);
            return string.Format("{0}, {1}", x.ToShortString(), y.ToShortString());
        }

        internal static vec2 Parse(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            float x = float.Parse(parts[0]);
            float y = float.Parse(parts[1]);
            return new vec2(x, y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(vec2 other)
        {
            return (this.x == other.x && this.y == other.y);
        }

        void ILoadFromString.Load(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            this.x = float.Parse(parts[0]);
            this.y = float.Parse(parts[1]);
        }
    }
}