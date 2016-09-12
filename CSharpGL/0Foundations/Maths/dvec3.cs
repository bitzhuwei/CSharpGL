using System;
using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// Represents a three dimensional vector.
    /// </summary>
    [TypeConverter(typeof(StructTypeConverter<dvec3>))]
    public struct dvec3 : IEquatable<dvec3>, ILoadFromString
    {
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

        private static readonly char[] separator = new char[] { ' ', ',' };

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        public dvec3(double s)
        {
            x = y = z = s;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public dvec3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public dvec3(dvec3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public dvec3(dvec4 v)
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
        public dvec3(dvec2 xy, double z)
        {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
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
        /// <param name="lhs"></param>
        /// <returns></returns>
        public static dvec3 operator -(dvec3 lhs)
        {
            return new dvec3(-lhs.x, -lhs.y, -lhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static dvec3 operator -(dvec3 lhs, dvec3 rhs)
        {
            return new dvec3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(dvec3 lhs, dvec3 rhs)
        {
            return (lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="self"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static dvec3 operator *(dvec3 self, double s)
        {
            return new dvec3(self.x * s, self.y * s, self.z * s);
        }

        //public static dvec3 operator +(dvec3 lhs, double rhs)
        //{
        //    return new dvec3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);
        //}
        //public static dvec3 operator -(dvec3 lhs, double rhs)
        //{
        //    return new dvec3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
        //}
        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static dvec3 operator *(double lhs, dvec3 rhs)
        {
            return new dvec3(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static dvec3 operator *(dvec3 lhs, dvec3 rhs)
        {
            return new dvec3(rhs.x * lhs.x, rhs.y * lhs.y, rhs.z * lhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static dvec3 operator /(dvec3 lhs, double rhs)
        {
            return new dvec3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static dvec3 operator +(dvec3 lhs, dvec3 rhs)
        {
            return new dvec3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(dvec3 lhs, dvec3 rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public dvec3 cross(dvec3 rhs)
        {
            return new dvec3(
                this.y * rhs.z - rhs.y * this.z,
                this.z * rhs.x - rhs.z * this.x,
                this.x * rhs.y - rhs.x * this.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public double dot(dvec3 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y + this.z * rhs.z;
            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is dvec3) && (this.Equals((dvec3)obj));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(dvec3 other)
        {
            return (this.x == other.x && this.y == other.y && this.z == other.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return string.Format("{0}#{1}#{2}", x, y, z).GetHashCode();
        }

        void ILoadFromString.Load(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            this.x = double.Parse(parts[0]);
            this.y = double.Parse(parts[1]);
            this.z = double.Parse(parts[2]);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public double length()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);

            return (double)result;
        }
        /// <summary>
        /// 归一化向量
        /// </summary>
        /// <returns></returns>
        public dvec3 normalize()
        {
            var frt = (double)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);

            return new dvec3(x / frt, y / frt, z / frt);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public double[] ToArray()
        {
            return new[] { x, y, z };
        }
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //return string.Format("{0:0.00},{1:0.00},{2:0.00}", x, y, z);
            return string.Format("{0}, {1}, {2}", x.ToShortString(), y.ToShortString(), z.ToShortString());
        }

        internal static dvec3 Parse(string value)
        {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            double x = double.Parse(parts[0]);
            double y = double.Parse(parts[1]);
            double z = double.Parse(parts[2]);
            return new dvec3(x, y, z);
        }
    }
}