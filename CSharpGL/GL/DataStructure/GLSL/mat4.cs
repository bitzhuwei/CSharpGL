using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CSharpGL {
    /// <summary>
    /// Represents a 4x4 matrix.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct mat4 : IEquatable<mat4>/*, ILoadFromString*/
    {
        //internal static mat4 Parse(string value)
        //{
        //    string[] parts = value.Split(MatrixHelper.separator, StringSplitOptions.RemoveEmptyEntries);
        //    vec4 col0 = vec4.Parse(parts[1]);
        //    vec4 col1 = vec4.Parse(parts[3]);
        //    vec4 col2 = vec4.Parse(parts[5]);
        //    vec4 col3 = vec4.Parse(parts[7]);

        //    return new mat4(col0, col1, col2, col3);
        //}

        /// <summary>
        /// Don't change the order of col0, col1, col2, col3 appears!
        /// </summary>
        [FieldOffset(sizeof(float) * 4 * 0)]
        internal vec4 col0;

        /// <summary>
        /// Don't change the order of col0, col1, col2, col3 appears!
        /// </summary>
        [FieldOffset(sizeof(float) * 4 * 1)]
        internal vec4 col1;

        /// <summary>
        /// Don't change the order of col0, col1, col2, col3 appears!
        /// </summary>
        [FieldOffset(sizeof(float) * 4 * 2)]
        internal vec4 col2;

        /// <summary>
        /// Don't change the order of col0, col1, col2, col3 appears!
        /// </summary>
        [FieldOffset(sizeof(float) * 4 * 3)]
        internal vec4 col3;

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(mat4 left, mat4 right) {
            return !(left == right);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(mat4 left, mat4 right) {
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
            return (obj is mat4 right && this.Equals(right));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(mat4 other) {
            return (this.col0 == other.col0 && this.col1 == other.col1 && this.col2 == other.col2 && this.col3 == other.col3);
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
        public mat3 to_mat3() {
            return new mat3(new vec3[]
            {
                new vec3(col0),
                new vec3(col1),
                new vec3(col2),
            });
        }

        /// <summary>
        /// Returns the matrix as a flat array of elements, column major.
        /// </summary>
        /// <returns></returns>
        public float[] ToArray() {
            float[] result = new float[16];
            result[00 + 0] = col0.x; result[00 + 1] = col0.y; result[00 + 2] = col0.z; result[00 + 3] = col0.w;
            result[04 + 0] = col1.x; result[04 + 1] = col1.y; result[04 + 2] = col1.z; result[04 + 3] = col1.w;
            result[08 + 0] = col2.x; result[08 + 1] = col2.y; result[08 + 2] = col2.z; result[08 + 3] = col2.w;
            result[12 + 0] = col3.x; result[12 + 1] = col3.y; result[12 + 2] = col3.z; result[12 + 3] = col3.w;

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString() {
            var builder = new System.Text.StringBuilder();
            var cols = new vec4[] { col0, col1, col2, col3 };
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

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="mat4"/> struct.
        /// This matrix is the identity matrix scaled by <paramref name="scale"/>.
        /// </summary>
        /// <param name="scale">The scale.</param>
        public mat4(float scale) {
            this.col0 = new vec4(scale, 0, 0, 0);
            this.col1 = new vec4(0, scale, 0, 0);
            this.col2 = new vec4(0, 0, scale, 0);
            this.col3 = new vec4(0, 0, 0, scale);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mat4"/> struct.
        /// The matrix is initialised with the <paramref name="cols"/>.
        /// </summary>
        /// <param name="cols">The colums of the matrix.</param>
        public mat4(vec4[] cols) {
            this.col0 = cols[0];
            this.col1 = cols[1];
            this.col2 = cols[2];
            this.col3 = cols[3];
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="col0"></param>
        /// <param name="col1"></param>
        /// <param name="col2"></param>
        /// <param name="col3"></param>
        public mat4(vec4 col0, vec4 col1, vec4 col2, vec4 col3) {
            this.col0 = col0;
            this.col1 = col1;
            this.col2 = col2;
            this.col3 = col3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="colomnMajor">16 elements in column-major order</param>
        public mat4(float[] colomnMajor) {
            this.col0 = new vec4(colomnMajor[0], colomnMajor[1], colomnMajor[2], colomnMajor[3]);
            this.col1 = new vec4(colomnMajor[4], colomnMajor[5], colomnMajor[6], colomnMajor[7]);
            this.col2 = new vec4(colomnMajor[8], colomnMajor[9], colomnMajor[10], colomnMajor[11]);
            this.col3 = new vec4(colomnMajor[12], colomnMajor[13], colomnMajor[14], colomnMajor[15]);
        }

        public mat4() {
            this.col0 = new vec4(1, 0, 0, 0);
            this.col1 = new vec4(0, 1, 0, 0);
            this.col2 = new vec4(0, 0, 1, 0);
            this.col3 = new vec4(0, 0, 0, 1);
        }

        /// <summary>
        /// Creates an identity matrix.
        /// </summary>
        /// <returns>A new identity matrix.</returns>
        public static mat4 identity() {
            return new mat4 {
                col0 = new vec4(1, 0, 0, 0),
                col1 = new vec4(0, 1, 0, 0),
                col2 = new vec4(0, 0, 1, 0),
                col3 = new vec4(0, 0, 0, 1),
            };
        }

        #endregion Construction

        #region Index Access

        /// <summary>
        /// Gets or sets the <see cref="vec4"/> column at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="vec4"/> column.
        /// </value>
        /// <param name="column">The column index.</param>
        /// <returns>The column at index <paramref name="column"/>.</returns>
        public vec4 this[int column] {
            get {
                if (column == 0) { return this.col0; }
                if (column == 1) { return this.col1; }
                if (column == 2) { return this.col2; }
                if (column == 3) { return this.col3; }

                throw new ArgumentOutOfRangeException();
            }
            set {
                if (column == 0) { this.col0 = value; }
                else if (column == 1) { this.col1 = value; }
                else if (column == 2) { this.col2 = value; }
                else if (column == 3) { this.col3 = value; }
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
                if (column == 3) { return this.col3[row]; }

                throw new ArgumentOutOfRangeException();
            }
            set {
                if (column == 0) { this.col0[row] = value; }
                else if (column == 1) { this.col1[row] = value; }
                else if (column == 2) { this.col2[row] = value; }
                else if (column == 3) { this.col3[row] = value; }
                else {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        #endregion Index Access

        #region Multiplication

        /// <summary>
        /// Multiplies the <paramref name="lhs"/> matrix by the <paramref name="rhs"/> vector.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS vector.</param>
        /// <returns>The product of <paramref name="lhs"/> and <paramref name="rhs"/>.</returns>
        public static vec4 operator *(mat4 lhs, vec4 rhs) {
            return new vec4(
                lhs[0, 0] * rhs[0] + lhs[1, 0] * rhs[1] + lhs[2, 0] * rhs[2] + lhs[3, 0] * rhs[3],
                lhs[0, 1] * rhs[0] + lhs[1, 1] * rhs[1] + lhs[2, 1] * rhs[2] + lhs[3, 1] * rhs[3],
                lhs[0, 2] * rhs[0] + lhs[1, 2] * rhs[1] + lhs[2, 2] * rhs[2] + lhs[3, 2] * rhs[3],
                lhs[0, 3] * rhs[0] + lhs[1, 3] * rhs[1] + lhs[2, 3] * rhs[2] + lhs[3, 3] * rhs[3]
            );
        }

        /// <summary>
        /// Multiplies the <paramref name="lhs"/> matrix by the <paramref name="rhs"/> matrix.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS matrix.</param>
        /// <returns>The product of <paramref name="lhs"/> and <paramref name="rhs"/>.</returns>
        public static mat4 operator *(mat4 lhs, mat4 rhs) {
            mat4 result = new mat4(
                new vec4(
                    lhs[0][0] * rhs[0][0] + lhs[1][0] * rhs[0][1] + lhs[2][0] * rhs[0][2] + lhs[3][0] * rhs[0][3],
                    lhs[0][1] * rhs[0][0] + lhs[1][1] * rhs[0][1] + lhs[2][1] * rhs[0][2] + lhs[3][1] * rhs[0][3],
                    lhs[0][2] * rhs[0][0] + lhs[1][2] * rhs[0][1] + lhs[2][2] * rhs[0][2] + lhs[3][2] * rhs[0][3],
                    lhs[0][3] * rhs[0][0] + lhs[1][3] * rhs[0][1] + lhs[2][3] * rhs[0][2] + lhs[3][3] * rhs[0][3]
                    ),
                new vec4(
                    lhs[0][0] * rhs[1][0] + lhs[1][0] * rhs[1][1] + lhs[2][0] * rhs[1][2] + lhs[3][0] * rhs[1][3],
                    lhs[0][1] * rhs[1][0] + lhs[1][1] * rhs[1][1] + lhs[2][1] * rhs[1][2] + lhs[3][1] * rhs[1][3],
                    lhs[0][2] * rhs[1][0] + lhs[1][2] * rhs[1][1] + lhs[2][2] * rhs[1][2] + lhs[3][2] * rhs[1][3],
                    lhs[0][3] * rhs[1][0] + lhs[1][3] * rhs[1][1] + lhs[2][3] * rhs[1][2] + lhs[3][3] * rhs[1][3]
                    ),
                new vec4(
                    lhs[0][0] * rhs[2][0] + lhs[1][0] * rhs[2][1] + lhs[2][0] * rhs[2][2] + lhs[3][0] * rhs[2][3],
                    lhs[0][1] * rhs[2][0] + lhs[1][1] * rhs[2][1] + lhs[2][1] * rhs[2][2] + lhs[3][1] * rhs[2][3],
                    lhs[0][2] * rhs[2][0] + lhs[1][2] * rhs[2][1] + lhs[2][2] * rhs[2][2] + lhs[3][2] * rhs[2][3],
                    lhs[0][3] * rhs[2][0] + lhs[1][3] * rhs[2][1] + lhs[2][3] * rhs[2][2] + lhs[3][3] * rhs[2][3]
                    ),
                new vec4(
                    lhs[0][0] * rhs[3][0] + lhs[1][0] * rhs[3][1] + lhs[2][0] * rhs[3][2] + lhs[3][0] * rhs[3][3],
                    lhs[0][1] * rhs[3][0] + lhs[1][1] * rhs[3][1] + lhs[2][1] * rhs[3][2] + lhs[3][1] * rhs[3][3],
                    lhs[0][2] * rhs[3][0] + lhs[1][2] * rhs[3][1] + lhs[2][2] * rhs[3][2] + lhs[3][2] * rhs[3][3],
                    lhs[0][3] * rhs[3][0] + lhs[1][3] * rhs[3][1] + lhs[2][3] * rhs[3][2] + lhs[3][3] * rhs[3][3]
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
        public static mat4 operator *(mat4 lhs, float s) {
            return new mat4(new[]
            {
                lhs[0]*s,
                lhs[1]*s,
                lhs[2]*s,
                lhs[3]*s
            });
        }

        #endregion Multiplication

        // https://blog.csdn.net/hunter_wwq/article/details/21473519
        // https://blog.csdn.net/lql0716/article/details/72597719
        /// <summary>
        /// Parse <paramref name="rotation"/>, <paramref name="scale"/> and <paramref name="worldPosition"/>(Translation) inside this matrix.
        /// <paramref name="rotation"/>.xyz is axis, <paramref name="rotation"/>.w is rotation angle in degrees.
        /// </summary>
        /// <param name="worldPosition"></param>
        /// <param name="scale"></param>
        /// <param name="rotation"></param>
        public void ParseRST(out vec3 worldPosition, out vec3 scale, out vec4 rotation) {
            worldPosition = new vec3(this.col3.x, this.col3.y, this.col3.z);

            float l0 = this.col0.length();
            float l1 = this.col1.length();
            float l2 = this.col2.length();
            scale = new vec3(l0, l1, l2);

            vec3 col0 = new vec3(this.col0.x / l0, this.col0.y / l0, this.col0.z / l0);
            vec3 col1 = new vec3(this.col1.x / l1, this.col1.y / l1, this.col1.z / l1);
            vec3 col2 = new vec3(this.col2.x / l2, this.col2.y / l2, this.col2.z / l2);
            /*
            col0 is vec3(1 - 2 * (yy + zz), 2 * (xy - zw), 2 * (xz + yw));
            col1 is vec3(2 * (xy + zw), 1 - 2 * (xx + zz), 2 * (yz - xw));
            col2 is vec3(2 * (xz - yw), 2 * (yz + xw), 1 - 2 * (xx + yy));
             */
            float w, x, y, z;
            //+col0.x + col1.y + col2.z = 4ww - 1
            w = (float)(Math.Sqrt(+col0.x + col1.y + col2.z + 1) / 2.0);
            //+col0.x - col1.y - col2.z = 4xx - 1
            x = (float)(Math.Sqrt(+col0.x - col1.y - col2.z + 1) / 2.0);
            //-col0.x + col1.y - col2.z = 4yy - 1
            y = (float)(Math.Sqrt(-col0.x + col1.y - col2.z + 1) / 2.0);
            //-col0.x - col1.y + col2.z = 4zz - 1
            z = (float)(Math.Sqrt(-col0.x - col1.y + col2.z + 1) / 2.0);
            int maxIndex = GetMaxIndex(w, x, y, z);
            switch (maxIndex) {
            case 0: // based on w
            x = (col1.z - col2.y) * 0.25f / w;
            y = (col2.x - col0.z) * 0.25f / w;
            z = (col0.y - col1.x) * 0.25f / w;
            break;
            case 1: // based on x
            w = (col1.z - col2.y) * 0.25f / x;
            y = (col0.y + col1.x) * 0.25f / x;
            z = (col2.x + col0.z) * 0.25f / x;
            break;
            case 2: // based on y
            w = (col2.x - col0.z) * 0.25f / y;
            x = (col0.y + col1.x) * 0.25f / y;
            z = (col1.z + col2.y) * 0.25f / y;
            break;
            case 3: // based on z
            w = (col0.y - col1.x) * 0.25f / z;
            x = (col2.x + col0.z) * 0.25f / z;
            y = (col1.z + col2.y) * 0.25f / z;
            break;
            }
            // from quaternion to axis+angle.
            vec3 axis; float angle;
            var quaternion = new Quaternion(w, x, y, z);
            quaternion.Parse(out angle, out axis);
            rotation = new vec4(axis, angle);
        }

        private int GetMaxIndex(float w, float x, float y, float z) {
            float max = w; int maxIndex = 0;
            if (max < x) { max = x; maxIndex = 1; }
            if (max < y) { max = y; maxIndex = 2; }
            if (max < z) { max = z; maxIndex = 3; }

            return maxIndex;
        }
    }
}