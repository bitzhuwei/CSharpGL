using System;
using System.ComponentModel;
using System.Linq;

namespace CSharpGL
{
    /// <summary>
    /// Represents a 3x3 matrix.
    /// </summary>
    [TypeConverter(typeof(Mat3TypeConverter))]
    public struct mat3
    {
        static readonly char[] separator = new char[] { '[', ']' };

        internal static mat3 Parse(string value)
        {
            string[] parts = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            vec3 col0 = vec3.Parse(parts[1]);
            vec3 col1 = vec3.Parse(parts[3]);
            vec3 col2 = vec3.Parse(parts[5]);

            return new mat3(col0, col1, col2);
        }

        public override string ToString()
        {
            var builder = new System.Text.StringBuilder();
            var cols = new vec3[] { col0, col1, col2 };
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
        /// Initializes a new instance of the <see cref="mat3"/> struct.
        /// This matrix is the identity matrix scaled by <paramref name="scale"/>.
        /// </summary>
        /// <param name="scale">The scale.</param>
        public mat3(float scale)
        {
            this.col0 = new vec3(scale, 0, 0);
            this.col1 = new vec3(0, scale, 0);
            this.col2 = new vec3(0, 0, scale);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mat3"/> struct.
        /// The matrix is initialised with the <paramref name="cols"/>.
        /// </summary>
        /// <param name="cols">The colums of the matrix.</param>
        public mat3(vec3[] cols)
        {
            this.col0 = cols[0];
            this.col1 = cols[1];
            this.col2 = cols[2];
        }

        public mat3(vec3 col0, vec3 col1, vec3 col2)
        {
            this.col0 = col0;
            this.col1 = col1;
            this.col2 = col2;
        }

        /// <summary>
        /// Creates an identity matrix.
        /// </summary>
        /// <returns>A new identity matrix.</returns>
        public static mat3 identity()
        {
            return new mat3
            {
                col0 = new vec3(1, 0, 0),
                col1 = new vec3(0, 1, 0),
                col2 = new vec3(0, 0, 1),
            };
        }

        #endregion

        #region Index Access

        /// <summary>
        /// Gets or sets the <see cref="vec3"/> column at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="vec3"/> column.
        /// </value>
        /// <param name="column">The column index.</param>
        /// <returns>The column at index <paramref name="column"/>.</returns>
        public vec3 this[int column]
        {
            get
            {
                if (column == 0) { return this.col0; }
                if (column == 1) { return this.col1; }
                if (column == 2) { return this.col2; }

                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (column == 0) { this.col0 = value; }
                else if (column == 1) { this.col1 = value; }
                else if (column == 2) { this.col2 = value; }
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

                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (column == 0) { this.col0[row] = value; }
                else if (column == 1) { this.col1[row] = value; }
                else if (column == 2) { this.col2[row] = value; }
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
        public float[] to_array()
        {
            float[] result = new float[9];
            result[0 + 0] = col0.x; result[0 + 1] = col0.y; result[0 + 2] = col0.z;
            result[3 + 0] = col1.x; result[3 + 1] = col1.y; result[3 + 2] = col1.z;
            result[6 + 0] = col2.x; result[6 + 1] = col2.y; result[6 + 2] = col2.z;
            return result;
        }

        /// <summary>
        /// Returns the <see cref="mat3"/> portion of this matrix.
        /// </summary>
        /// <returns>The <see cref="mat3"/> portion of this matrix.</returns>
        public mat2 to_mat2()
        {
            return new mat2(new vec2[]
                {
                    new vec2(col0.x,col0.y),
                    new vec2(col1.x,col1.y),
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
        public static vec3 operator *(mat3 lhs, vec3 rhs)
        {
            return new vec3(
                lhs[0, 0] * rhs[0] + lhs[1, 0] * rhs[1] + lhs[2, 0] * rhs[2],
                lhs[0, 1] * rhs[0] + lhs[1, 1] * rhs[1] + lhs[2, 1] * rhs[2],
                lhs[0, 2] * rhs[0] + lhs[1, 2] * rhs[1] + lhs[2, 2] * rhs[2]
            );
        }

        /// <summary>
        /// Multiplies the <paramref name="lhs"/> matrix by the <paramref name="rhs"/> matrix.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS matrix.</param>
        /// <returns>The product of <paramref name="lhs"/> and <paramref name="rhs"/>.</returns>
        public static mat3 operator *(mat3 lhs, mat3 rhs)
        {
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

        public static mat3 operator *(mat3 lhs, float s)
        {
            return new mat3(new[]
            {
                lhs[0]*s,
                lhs[1]*s,
                lhs[2]*s
            });
        }

        #endregion

        private vec3 col0;
        private vec3 col1;
        private vec3 col2;

        public static bool operator ==(mat3 left, mat3 right)
        {
            object leftObj = left, rightObj = right;
            if (leftObj == null)
            {
                if (rightObj == null) { return true; }
                else { return false; }
            }
            else
            {
                if (rightObj == null) { return false; }
            }

            return left.Equals(right);
        }

        public static bool operator !=(mat3 left, mat3 right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            var p = (mat3)obj;

            //return this.HashCode == p.HashCode;
            return (this.col0 == p.col0 && this.col1 == p.col1
                && this.col2 == p.col2);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

    }
}