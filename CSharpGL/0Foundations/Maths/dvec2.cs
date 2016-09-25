using System;
using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// Represents a two dimensional vector.
    /// </summary>
    [TypeConverter(typeof(StructTypeConverter<dvec2>))]
    public struct dvec2 : IEquatable<dvec2>, ILoadFromString
    {
        /// <summary>
        /// Don't change the order of x, y appears!
        /// </summary>
        public double x;

        /// <summary>
        /// Don't change the order of x, y appears!
        /// </summary>
        public double y;

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        public dvec2(double s)
        {
            x = y = s;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public dvec2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public dvec2(dvec2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public dvec2(dvec3 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public dvec2(dvec4 v)
        {
            this.x = v.x;
            this.y = v.y;
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
        /// <param name="lhs"></param>
        /// <returns></returns>
        public static dvec2 operator -(dvec2 lhs)
        {
            return new dvec2(-lhs.x, -lhs.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static dvec2 operator -(dvec2 lhs, dvec2 rhs)
        {
            return new dvec2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static dvec2 operator -(dvec2 lhs, double rhs)
        {
            return new dvec2(lhs.x - rhs, lhs.y - rhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(dvec2 lhs, dvec2 rhs)
        {
            return (lhs.x != rhs.x || lhs.y != rhs.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="self"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static dvec2 operator *(dvec2 self, double s)
        {
            return new dvec2(self.x * s, self.y * s);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static dvec2 operator *(double lhs, dvec2 rhs)
        {
            return new dvec2(rhs.x * lhs, rhs.y * lhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static dvec2 operator *(dvec2 lhs, dvec2 rhs)
        {
            return new dvec2(rhs.x * lhs.x, rhs.y * lhs.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static dvec2 operator /(dvec2 lhs, double rhs)
        {
            return new dvec2(lhs.x / rhs, lhs.y / rhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static dvec2 operator +(dvec2 lhs, dvec2 rhs)
        {
            return new dvec2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static dvec2 operator +(dvec2 lhs, double rhs)
        {
            return new dvec2(lhs.x + rhs, lhs.y + rhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(dvec2 lhs, dvec2 rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public double dot(dvec2 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y;
            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is dvec2) && (this.Equals((dvec2)obj));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(dvec2 other)
        {
            return (this.x == other.x && this.y == other.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return string.Format("{0}#{1}", x, y).GetHashCode();
        }

        void ILoadFromString.Load(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            this.x = double.Parse(parts[0]);
            this.y = double.Parse(parts[1]);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public double length()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y);

            return (double)result;
        }

        /// <summary>
        /// 归一化向量
        /// </summary>
        /// <returns></returns>
        public dvec2 normalize()
        {
            double frt = Math.Sqrt(this.x * this.x + this.y * this.y);

            return new dvec2(x / frt, y / frt);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public double[] ToArray()
        {
            return new[] { x, y };
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

        internal static dvec2 Parse(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            double x = double.Parse(parts[0]);
            double y = double.Parse(parts[1]);
            return new dvec2(x, y);
        }
    }
}