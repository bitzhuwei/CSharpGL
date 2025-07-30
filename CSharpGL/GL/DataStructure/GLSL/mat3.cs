using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CSharpGL {
    /// <summary>
    /// Represents a 3x3 matrix.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct mat3 : IEquatable<mat3>/*, ILoadFromString*/
    {
        //internal static mat3 Parse(string value)
        //{
        //    string[] parts = value.Split(MatrixHelper.separator, StringSplitOptions.RemoveEmptyEntries);
        //    vec3 col0 = vec3.Parse(parts[1]);
        //    vec3 col1 = vec3.Parse(parts[3]);
        //    vec3 col2 = vec3.Parse(parts[5]);

        //    return new mat3(col0, col1, col2);
        //}

        /// <summary>
        /// Don't change the order of col0, col1, col2 appears!
        /// </summary>
        [FieldOffset(sizeof(float) * 3 * 0)]
        internal vec3 col0;

        /// <summary>
        /// Don't change the order of col0, col1, col2 appears!
        /// </summary>
        [FieldOffset(sizeof(float) * 3 * 1)]
        internal vec3 col1;

        /// <summary>
        /// Don't change the order of col0, col1, col2 appears!
        /// </summary>
        [FieldOffset(sizeof(float) * 3 * 2)]
        internal vec3 col2;

        /// <summary>
        /// Initializes a new instance of the <see cref="mat3"/> struct.
        /// This matrix is the identity matrix scaled by <paramref name="scale"/>.
        /// </summary>
        /// <param name="scale">The scale.</param>
        public mat3(float scale) {
            this.col0 = new vec3(scale, 0, 0);
            this.col1 = new vec3(0, scale, 0);
            this.col2 = new vec3(0, 0, scale);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mat3"/> struct.
        /// The matrix is initialised with the <paramref name="cols"/>.
        /// </summary>
        /// <param name="cols">The colums of the matrix.</param>
        public mat3(vec3[] cols) {
            this.col0 = cols[0];
            this.col1 = cols[1];
            this.col2 = cols[2];
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="col0"></param>
        /// <param name="col1"></param>
        /// <param name="col2"></param>
        public mat3(vec3 col0, vec3 col1, vec3 col2) {
            this.col0 = col0;
            this.col1 = col1;
            this.col2 = col2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        public mat3(mat4 matrix) {
            this.col0 = new vec3(matrix.col0);
            this.col1 = new vec3(matrix.col1);
            this.col2 = new vec3(matrix.col2);
        }

        /// <summary>
        /// Gets or sets the <see cref="vec3"/> column at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="vec3"/> column.
        /// </value>
        /// <param name="column">The column index.</param>
        /// <returns>The column at index <paramref name="column"/>.</returns>
        public vec3 this[int column] {
            get {
                if (column == 0) { return this.col0; }
                if (column == 1) { return this.col1; }
                if (column == 2) { return this.col2; }

                throw new ArgumentOutOfRangeException();
            }
            set {
                if (column == 0) { this.col0 = value; }
                else if (column == 1) { this.col1 = value; }
                else if (column == 2) { this.col2 = value; }
                else {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Gets or sets the element at <paramref name="column"/> and <paramref name="row"/>.
        /// </summary>
        /// <value>
        /// The element at <paramref name="column"/> and <paramref name="row"/>.
        /// </value>
        /// <param name="column">The column index.</param>
        /// <param name="row">The row index.</param>
        /// <returns>
        /// The element at <paramref name="column"/> and <paramref name="row"/>.
        /// </returns>
        public float this[int column, int row] {
            get {
                if (column == 0) { return this.col0[row]; }
                if (column == 1) { return this.col1[row]; }
                if (column == 2) { return this.col2[row]; }

                throw new ArgumentOutOfRangeException();
            }
            set {
                if (column == 0) { this.col0[row] = value; }
                else if (column == 1) { this.col1[row] = value; }
                else if (column == 2) { this.col2[row] = value; }
                else {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Creates an identity matrix.
        /// </summary>
        /// <returns>A new identity matrix.</returns>
        public static mat3 identity() {
            return new mat3 {
                col0 = new vec3(1, 0, 0),
                col1 = new vec3(0, 1, 0),
                col2 = new vec3(0, 0, 1),
            };
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(mat3 left, mat3 right) {
            return !(left == right);
        }

        /// <summary>
        /// Multiplies the <paramref name="lhs"/> matrix by the <paramref name="rhs"/> vector.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS vector.</param>
        /// <returns>The product of <paramref name="lhs"/> and <paramref name="rhs"/>.</returns>
        public static vec3 operator *(mat3 lhs, vec3 rhs) {
            return new vec3(
                //lhs[0, 0] * rhs[0] + lhs[1, 0] * rhs[1] + lhs[2, 0] * rhs[2],
                //lhs[0, 1] * rhs[0] + lhs[1, 1] * rhs[1] + lhs[2, 1] * rhs[2],
                //lhs[0, 2] * rhs[0] + lhs[1, 2] * rhs[1] + lhs[2, 2] * rhs[2]);
                lhs.col0.x * rhs.x + lhs.col1.x * rhs.y + lhs.col2.x * rhs.z,
                lhs.col0.y * rhs.x + lhs.col1.y * rhs.y + lhs.col2.y * rhs.z,
                lhs.col0.z * rhs.x + lhs.col1.z * rhs.y + lhs.col2.z * rhs.z);
        }

        /// <summary>
        /// Multiplies the <paramref name="lhs"/> matrix by the <paramref name="rhs"/> matrix.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS matrix.</param>
        /// <returns>The product of <paramref name="lhs"/> and <paramref name="rhs"/>.</returns>
        public static mat3 operator *(mat3 lhs, mat3 rhs) {
            mat3 result = new mat3(
                new vec3(
                    lhs[0][0] * rhs[0][0] + lhs[1][0] * rhs[0][1] + lhs[2][0] * rhs[0][2],
                    lhs[0][1] * rhs[0][0] + lhs[1][1] * rhs[0][1] + lhs[2][1] * rhs[0][2],
                    lhs[0][2] * rhs[0][0] + lhs[1][2] * rhs[0][1] + lhs[2][2] * rhs[0][2]
                    ),
                new vec3(
                    lhs[0][0] * rhs[1][0] + lhs[1][0] * rhs[1][1] + lhs[2][0] * rhs[1][2],
                    lhs[0][1] * rhs[1][0] + lhs[1][1] * rhs[1][1] + lhs[2][1] * rhs[1][2],
                    lhs[0][2] * rhs[1][0] + lhs[1][2] * rhs[1][1] + lhs[2][2] * rhs[1][2]
                    ),
                new vec3(
                    lhs[0][0] * rhs[2][0] + lhs[1][0] * rhs[2][1] + lhs[2][0] * rhs[2][2],
                    lhs[0][1] * rhs[2][0] + lhs[1][1] * rhs[2][1] + lhs[2][1] * rhs[2][2],
                    lhs[0][2] * rhs[2][0] + lhs[1][2] * rhs[2][1] + lhs[2][2] * rhs[2][2]
                    )
                    );

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static mat3 operator *(mat3 lhs, float s) {
            return new mat3(new[]
            {
                lhs[0]*s,
                lhs[1]*s,
                lhs[2]*s
            });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(mat3 left, mat3 right) {
            //object leftObj = left, rightObj = right;
            //if (leftObj == null)
            //{
            //    if (rightObj == null) { return true; }
            //    else { return false; }
            //}
            //else
            //{
            //    if (rightObj == null) { return false; }
            //}

            return left.Equals(right);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj) {
            return (obj is mat3 right && this.Equals(right));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(mat3 other) {
            return (this.col0 == other.col0 && this.col1 == other.col1 && this.col2 == other.col2);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Returns the <see cref="mat3"/> portion of this matrix.
        /// </summary>
        /// <returns>The <see cref="mat3"/> portion of this matrix.</returns>
        public mat2 to_mat2() {
            return new mat2(new vec2[]
                {
                    new vec2(col0.x,col0.y),
                    new vec2(col1.x,col1.y),
                });
        }

        /// <summary>
        /// Returns the matrix as a flat array of elements, column major.
        /// </summary>
        /// <returns></returns>
        public float[] ToArray() {
            float[] result = new float[9];
            result[0 + 0] = col0.x; result[0 + 1] = col0.y; result[0 + 2] = col0.z;
            result[3 + 0] = col1.x; result[3 + 1] = col1.y; result[3 + 2] = col1.z;
            result[6 + 0] = col2.x; result[6 + 1] = col2.y; result[6 + 2] = col2.z;
            return result;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString() {
            var builder = new System.Text.StringBuilder();
            var cols = new vec3[] { col0, col1, col2 };
            for (int i = 0; i < cols.Length; i++) {
                builder.Append("col ");
                builder.Append(i);
                builder.Append(": [");
                builder.Append(cols[i]);
                builder.Append("] ");
                builder.AppendLine();
            }
            return builder.ToString();
        }

        /// <summary>
        /// Transform this matrix to a <see cref="Quaternion"/>.
        /// </summary>
        /// <returns></returns>
        public Quaternion ToQuaternion() {
            // input matrix.
            float m11 = this.col0.x, m12 = this.col1.x, m13 = this.col2.x;
            float m21 = this.col0.y, m22 = this.col1.y, m23 = this.col2.y;
            float m31 = this.col0.z, m32 = this.col1.z, m33 = this.col2.z;
            // output quaternion
            float x = 0, y = 0, z = 0, w = 0;
            // detect biggest in w, x, y, z.
            float fourWSquaredMinus1 = +m11 + m22 + m33;
            float fourXSquaredMinus1 = +m11 - m22 - m33;
            float fourYSquaredMinus1 = -m11 + m22 - m33;
            float fourZSquaredMinus1 = -m11 - m22 + m33;
            int biggestIndex = 0;
            float biggest = fourWSquaredMinus1;
            if (fourXSquaredMinus1 > biggest) {
                biggest = fourXSquaredMinus1;
                biggestIndex = 1;
            }
            if (fourYSquaredMinus1 > biggest) {
                biggest = fourYSquaredMinus1;
                biggestIndex = 2;
            }
            if (fourZSquaredMinus1 > biggest) {
                biggest = fourZSquaredMinus1;
                biggestIndex = 3;
            }
            // sqrt and division
            float biggestVal = (float)(Math.Sqrt(biggest + 1) * 0.5);
            float mult = 0.25f / biggestVal;
            // get output
            switch (biggestIndex) {
            case 0:
            w = biggestVal;
            x = (m23 - m32) * mult;
            y = (m31 - m13) * mult;
            z = (m12 - m21) * mult;
            break;

            case 1:
            x = biggestVal;
            w = (m23 - m32) * mult;
            y = (m12 + m21) * mult;
            z = (m31 + m13) * mult;
            break;

            case 2:
            y = biggestVal;
            w = (m31 - m13) * mult;
            x = (m12 + m21) * mult;
            z = (m23 + m32) * mult;
            break;

            case 3:
            z = biggestVal;
            w = (m12 - m21) * mult;
            x = (m31 + m13) * mult;
            y = (m23 + m32) * mult;
            break;

            default:
            break;
            }

            if (x == 0.0f && y == 0.0f && z == 0.0f) {
                return new Quaternion(1, 1, 1, 1);
            }
            else {
                return new Quaternion(w, -x, -y, -z);
            }
        }
    }
}