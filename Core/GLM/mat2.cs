using System;
using System.Linq;

namespace GLM
{
    /// <summary>
    /// Represents a 2x2 matrix.
    /// </summary>
    public struct mat2
    {
        public override string ToString()
        {
            var builder = new System.Text.StringBuilder();
            var cols = new vec2[] { col0, col1};
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
        /// Initializes a new instance of the <see cref="mat2"/> struct.
        /// This matrix is the identity matrix scaled by <paramref name="scale"/>.
        /// </summary>
        /// <param name="scale">The scale.</param>
        public mat2(float scale)
        {
            this.col0 = new vec2(scale, 0);
            this.col1 = new vec2(0, scale);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="mat2"/> struct.
        /// The matrix is initialised with the <paramref name="cols"/>.
        /// </summary>
        /// <param name="cols">The colums of the matrix.</param>
        public mat2(vec2[] cols)
        {
            this.col0 = cols[0];
            this.col1 = cols[1];
        }

        public mat2(vec2 a, vec2 b)
        {
            this.col0 = a;
            this.col1 = b;
        }

        public mat2(float a, float b, float c, float d)
        {
            this.col0 = new vec2(a, b);
            this.col1 = new vec2(c, d);
        }

        /// <summary>
        /// Creates an identity matrix.
        /// </summary>
        /// <returns>A new identity matrix.</returns>
        public static mat2 identity()
        {
            return new mat2
            {
                col0 = new vec2(1, 0),
                col1 = new vec2(0, 1),
            };
        }

        #endregion

        #region Index Access

        /// <summary>
        /// Gets or sets the <see cref="vec2"/> column at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="vec2"/> column.
        /// </value>
        /// <param name="column">The column index.</param>
        /// <returns>The column at index <paramref name="column"/>.</returns>
        public vec2 this[int column]
        {
            get
            {
                if (column == 0) { return this.col0; }
                if (column == 1) { return this.col1; }

                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (column == 0) { this.col0 = value; }
                else if (column == 1) { this.col1 = value; }
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

                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (column == 0) { this.col0[row] = value; }
                else if (column == 1) { this.col1[row] = value; }
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
            float[] result = new float[4];
            result[0 + 0] = col0.x; result[0 + 1] = col0.y;
            result[2 + 0] = col1.x; result[2 + 1] = col1.y;

            return result;
        }

        #endregion

        #region Multiplication

        /// <summary>
        /// Multiplies the <paramref name="lhs"/> matrix by the <paramref name="rhs"/> vector.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS vector.</param>
        /// <returns>The product of <paramref name="lhs"/> and <paramref name="rhs"/>.</returns>
        public static vec2 operator *(mat2 lhs, vec2 rhs)
        {
            return new vec2(
                lhs[0, 0] * rhs[0] + lhs[1, 0] * rhs[1],
                lhs[0, 1] * rhs[0] + lhs[1, 1] * rhs[1]
            );
        }

        /// <summary>
        /// Multiplies the <paramref name="lhs"/> matrix by the <paramref name="rhs"/> matrix.
        /// </summary>
        /// <param name="lhs">The LHS matrix.</param>
        /// <param name="rhs">The RHS matrix.</param>
        /// <returns>The product of <paramref name="lhs"/> and <paramref name="rhs"/>.</returns>
        public static mat2 operator *(mat2 lhs, mat2 rhs)
        {
            mat2 result = new mat2(
                new vec2(
                    lhs[0][0] * rhs[0][0] + lhs[1][0] * rhs[0][1],
                    lhs[0][1] * rhs[0][0] + lhs[1][1] * rhs[0][1]
                    ),
                new vec2(
                    lhs[0][0] * rhs[1][0] + lhs[1][0] * rhs[1][1],
                    lhs[0][1] * rhs[1][0] + lhs[1][1] * rhs[1][1]
                    )
                    );

            return result;
        }

        public static mat2 operator *(mat2 lhs, float s)
        {
            return new mat2(new[]
            {
                lhs[0]*s,
                lhs[1]*s
            });
        }

        #endregion

        private vec2 col0;
        private vec2 col1;
    }
}