using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CSharpGL {
    /// <summary>
    /// Represents a three dimensional vector.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct vec3 : IEquatable<vec3>/*, ILoadFromString*/
    {
        /// <summary>
        /// x = r = s
        /// </summary>
        [FieldOffset(sizeof(float) * 0)]
        public float x;

        /// <summary>
        /// y = g = t
        /// </summary>
        [FieldOffset(sizeof(float) * 1)]
        public float y;

        /// <summary>
        /// z = b = p
        /// </summary>
        [FieldOffset(sizeof(float) * 2)]
        public float z;

        private static readonly char[] separator = new char[] { ' ', ',' };

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        public vec3(float s) {
            x = y = z = s;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public vec3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="xyz"></param>
        public vec3(float[] xyz) {
            this.x = xyz[0];
            this.y = xyz[1];
            this.z = xyz[2];
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public vec3(vec3 v) {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public vec3(vec4 v) {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="xy"></param>
        /// <param name="z"></param>
        public vec3(vec2 xy, float z) {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public float this[int index] {
            get {
                if (index == 0) return x;
                else if (index == 1) return y;
                else if (index == 2) return z;
                else throw new Exception("Out of range.");
            }
            set {
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
        public static vec3 operator -(vec3 lhs) {
            return new vec3(-lhs.x, -lhs.y, -lhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec3 operator -(vec3 lhs, vec3 rhs) {
            return new vec3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(vec3 lhs, vec3 rhs) {
            return (lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="self"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static vec3 operator *(vec3 self, float s) {
            return new vec3(self.x * s, self.y * s, self.z * s);
        }

        //public static vec3 operator +(vec3 lhs, float rhs)
        //{
        //    return new vec3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);
        //}
        //public static vec3 operator -(vec3 lhs, float rhs)
        //{
        //    return new vec3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
        //}
        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec3 operator *(float lhs, vec3 rhs) {
            return new vec3(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec3 operator *(vec3 lhs, vec3 rhs) {
            return new vec3(rhs.x * lhs.x, rhs.y * lhs.y, rhs.z * lhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec3 operator /(vec3 lhs, float rhs) {
            return new vec3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static vec3 operator +(vec3 lhs, vec3 rhs) {
            return new vec3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(vec3 lhs, vec3 rhs) {
            return (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public vec3 cross(vec3 rhs) {
            return new vec3(
                this.y * rhs.z - rhs.y * this.z,
                this.z * rhs.x - rhs.z * this.x,
                this.x * rhs.y - rhs.x * this.y);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public float dot(vec3 rhs) {
            var result = this.x * rhs.x + this.y * rhs.y + this.z * rhs.z;
            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj) {
            return (obj is vec3 right && this.Equals(right));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(vec3 other) {
            return (this.x == other.x && this.y == other.y && this.z == other.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() {
            return string.Format("{0}#{1}#{2}", x, y, z).GetHashCode();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public float length() {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);

            return (float)result;
        }

        /// <summary>
        /// 归一化向量
        /// </summary>
        /// <returns></returns>
        public vec3 normalize() {
            float frt = (float)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
            if (frt == 0.0f) {
                //Debug.WriteLine("Zero vec3 being normalized!");

                return new vec3(0, 0, 0);
            }
            else {
                return new vec3(x / frt, y / frt, z / frt);
            }
        }

        /// <summary>
        /// max value of x, y, z.
        /// </summary>
        /// <returns></returns>
        public float max() {
            float value = x < y ? y : x;
            if (value < z) { value = z; }

            return value;
        }

        /// <summary>
        /// min value of x, y, z.
        /// </summary>
        /// <returns></returns>
        public float min() {
            float value = x < y ? x : y;
            if (z < value) { value = z; }

            return value;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public float[] ToArray() {
            return new[] { x, y, z };
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            //return string.Format("{0:0.00},{1:0.00},{2:0.00}", x, y, z);
            return string.Format("{0}, {1}, {2}", x.ToShortString(), y.ToShortString(), z.ToShortString());
        }

        internal static vec3 Parse(string value) {
            string[] parts = value.Split(VectorHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            float x = float.Parse(parts[0]);
            float y = float.Parse(parts[1]);
            float z = float.Parse(parts[2]);
            return new vec3(x, y, z);
        }
    }
}