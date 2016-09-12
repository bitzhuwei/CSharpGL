using System;
using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// Represents a four dimensional vector.
    /// </summary>
    //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 4 * 4)]
    [TypeConverter(typeof(StructTypeConverter<dvec4>))]
    public struct dvec4 : IEquatable<dvec4>, ILoadFromString
    {
        /// <summary>
        ///
        /// </summary>
        public double w;

        /// <summary>
        ///
        /// </summary>
        public double x;

        /// <summary>
        ///
        /// </summary>
        public double y;

        /// <summary>
        ///
        /// </summary>
        public double z;

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        public dvec4(double s)
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
        public dvec4(double x, double y, double z, double w)
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
        public dvec4(dvec4 v)
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
        public dvec4(dvec3 xyz, double w)
        {
            this.x = xyz.x;
            this.y = xyz.y;
            this.z = xyz.z;
            this.w = w;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public double this[int index]
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
        /// <param name="lhs"></param>
        /// <returns></returns>
        public static dvec4 operator -(dvec4 lhs)
        {
            return new dvec4(-lhs.x, -lhs.y, -lhs.z, -lhs.w);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static dvec4 operator -(dvec4 lhs, dvec4 rhs)
        {
            return new dvec4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(dvec4 lhs, dvec4 rhs)
        {
            return (lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z || lhs.w != rhs.w);
        }

        //public static dvec4 operator -(dvec4 lhs, double rhs)
        //{
        //    return new dvec4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);
        //}
        /// <summary>
        ///
        /// </summary>
        /// <param name="self"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static dvec4 operator *(dvec4 self, double s)
        {
            return new dvec4(self.x * s, self.y * s, self.z * s, self.w * s);
        }

        //public static dvec4 operator +(dvec4 lhs, double rhs)
        //{
        //    return new dvec4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);
        //}
        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static dvec4 operator *(double lhs, dvec4 rhs)
        {
            return new dvec4(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs, rhs.w * lhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static dvec4 operator *(dvec4 lhs, dvec4 rhs)
        {
            return new dvec4(rhs.x * lhs.x, rhs.y * lhs.y, rhs.z * lhs.z, rhs.w * lhs.w);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static dvec4 operator /(dvec4 lhs, double rhs)
        {
            return new dvec4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static dvec4 operator +(dvec4 lhs, dvec4 rhs)
        {
            return new dvec4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(dvec4 lhs, dvec4 rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z && lhs.w == rhs.w);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public double dot(dvec4 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y + this.z * rhs.z + this.w * rhs.w;
            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is dvec4) && (this.Equals((dvec4)obj));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(dvec4 other)
        {
            return (this.x == other.x && this.y == other.y && this.z == other.z && this.w == other.w);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return string.Format("{0}#{1}#{2}#{3}", x, y, z, w).GetHashCode();
        }

        void ILoadFromString.Load(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            this.x = double.Parse(parts[0]);
            this.y = double.Parse(parts[1]);
            this.z = double.Parse(parts[2]);
            this.w = double.Parse(parts[3]);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public double length()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);

            return (double)result;
        }

        /// <summary>
        /// 归一化向量
        /// </summary>
        /// <returns></returns>
        public dvec4 normalize()
        {
            var frt = (double)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);

            return new dvec4(x / frt, y / frt, z / frt, w / frt);
            ;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public double[] ToArray()
        {
            return new[] { x, y, z, w };
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //return string.Format("{0:0.00},{1:0.00},{2:0.00},{3:0.00}", x, y, z, w);
            return string.Format("{0}, {1}, {2}, {3}", x.ToShortString(), y.ToShortString(), z.ToShortString(), w.ToShortString());
            //return base.ToString();
        }

        internal static dvec4 Parse(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            double x = double.Parse(parts[0]);
            double y = double.Parse(parts[1]);
            double z = double.Parse(parts[2]);
            double w = double.Parse(parts[3]);
            return new dvec4(x, y, z, w);
        }
    }
}