using CSharpGL;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Represents a 4x4 matrix.
    /// </summary>
    [TypeConverter(typeof(StructTypeConverter<mat4>))]
    public struct mat4 : IEquatable<mat4>, ILoadFromString
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
        /// 
        /// </summary>
        public override string ToString()
        {
            var builder = new System.Text.StringBuilder();
            var cols = new vec4[] { col0, col1, col2, col3 };
            for (int i = 0; i < cols.Length; i++)
            {
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
        public mat4(float scale)
        {
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
        public mat4(vec4[] cols)
        {
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
        public mat4(vec4 col0, vec4 col1, vec4 col2, vec4 col3)
        {
            this.col0 = col0;
            this.col1 = col1;
            this.col2 = col2;
            this.col3 = col3;
        }

        /// <summary>
        /// Creates an identity matrix.
        /// </summary>
        /// <returns>A new identity matrix.</returns>
        public static mat4 identity()
        {
            return new mat4
            {
                col0 = new vec4(1, 0, 0, 0),
                col1 = new vec4(0, 1, 0, 0),
                col2 = new vec4(0, 0, 1, 0),
                col3 = new vec4(0, 0, 0, 1),
            };
        }

        #endregion

        #region Index Access

        /// <summary>
        /// Gets or sets the <see cref="vec4"/> column at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="vec4"/> column.
        /// </value>
        /// <param name="column">The column index.</param>
        /// <returns>The column at index <paramref name="column"/>.</returns>
        public vec4 this[int column]
        {
            get
            {
                if (column == 0) { return this.col0; }
                if (column == 1) { return this.col1; }
                if (column == 2) { return this.col2; }
                if (column == 3) { return this.col3; }

                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (column == 0) { this.col0 = value; }
                else if (column == 1) { this.col1 = value; }
                else if (column == 2) { this.col2 = value; }
                else if (column == 3) { this.col3 = value; }
                else
                {
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
        public float this[int column, int row]
        {
            get
            {
                if (column == 0) { return this.col0[row]; }
                if (column == 1) { return this.col1[row]; }
                if (column == 2) { return this.col2[row]; }
                if (column == 3) { return this.col3[row]; }

                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (column == 0) { this.col0[row] = value; }
                else if (column == 1) { this.col1[row] = value; }
                else if (column == 2) { this.col2[row] = value; }
                else if (column == 3) { this.col3[row] = value; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        #endregion

        #region Conversion

        /// <summary>
        /// Returns the matrix as a flat array of elements, column major.
        /// </summary>
        /// <returns></returns>
        public float[] ToArray()
        {
            float[] result = new float[16];
            result[0 + 0] = col0.x; result[0 + 1] = col0.y; result[0 + 2] = col0.z; result[0 + 3] = col0.w;
            result[4 + 0] = col1.x; result[4 + 1] = col1.y; result[4 + 2] = col1.z; result[4 + 3] = col1.w;
            result[8 + 0] = col2.x; result[8 + 1] = col2.y; result[8 + 2] = col2.z; result[8 + 3] = col2.w;
            result[12 + 0] = col3.x; result[12 + 1] = col3.y; result[12 + 2] = col3.z; result[12 + 3] = col3.w;

            return result;
        }

        /// <summary>
        /// Returns the <see cref="mat3"/> portion of this matrix.
        /// </summary>
        /// <returns>The <see cref="mat3"/> portion of this matrix.</returns>
        public mat3 to_mat3()
        {
            return new mat3(new vec3[]
            {
                new vec3(col0),
                new vec3(col1),
                new vec3(col2),
            });
        }

        #endregion

        #region Multiplication

        /// <summary>
        /// Multiplies the <paramref name="lhs"/> matrix by the <paramref name="rhs"/> vector.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS vector.</param>
        /// <returns>The product of <paramref name="lhs"/> and <paramref name="rhs"/>.</returns>
        public static vec4 operator *(mat4 lhs, vec4 rhs)
        {
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
        public static mat4 operator *(mat4 lhs, mat4 rhs)
        {
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
        public static mat4 operator *(mat4 lhs, float s)
        {
            return new mat4(new[]
            {
                lhs[0]*s,
                lhs[1]*s,
                lhs[2]*s,
                lhs[3]*s
            });
        }

        #endregion

        internal vec4 col0;
        internal vec4 col1;
        internal vec4 col2;
        internal vec4 col3;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(mat4 left, mat4 right)
        {
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
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(mat4 left, mat4 right)
        {
            return !(left == right);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is mat4) && (this.Equals((mat4)obj));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(mat4 other)
        {
            return (this.col0 == other.col0 && this.col1 == other.col1 && this.col2 == other.col2 && this.col3 == other.col3);
        }

        void ILoadFromString.Load(string value)
        {
            string[] parts = value.Split(MatrixHelper.separator, StringSplitOptions.RemoveEmptyEntries);
            this.col0 = vec4.Parse(parts[1]);
            this.col1 = vec4.Parse(parts[3]);
            this.col2 = vec4.Parse(parts[5]);
            this.col3 = vec4.Parse(parts[7]); 
        }
    }
}