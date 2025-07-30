using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CSharpGL {
    /// <summary>
    /// Represents a three dimensional vector.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct bvec3 : IEquatable<bvec3>/*, ILoadFromString*/
    {
        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(int) * 0)]
        public int x;

        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(int) * 1)]
        public int y;

        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(int) * 2)]
        public int z;

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        public bvec3(int s) {
            x = y = z = s;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public bvec3(int x, int y, int z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public bvec3(bvec3 v) {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="v"></param>
        public bvec3(bvec4 v) {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="xy"></param>
        /// <param name="z"></param>
        public bvec3(bvec2 xy, int z) {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int this[int index] {
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
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(bvec3 lhs, bvec3 rhs) {
            return (lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(bvec3 lhs, bvec3 rhs) {
            return (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj) {
            return (obj is bvec3 right && this.Equals(right));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(bvec3 other) {
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
        public int[] ToArray() {
            return new[] { x, y, z };
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("{0}, {1}, {2}", x, y, z);
        }
    }
}