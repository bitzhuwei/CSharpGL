using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL.CSSL
{
    /// <summary>
    /// 所有CSSL都共有的内容。
    /// </summary>
    public abstract partial class CSShaderCode
    {

        /// <summary>
        /// Multiply matrix x by matrix y
        /// component-wise, i.e., result[i][j] is the
        /// scalar product of x[i][j] and y[i][j].
        /// Note: To get linear-algebraic matrix
        /// multiplication, use the multiply
        /// operator (*).
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static mat2 matrixCompMult(mat2 x, mat2 y) { return null; }
        /// <summary>
        /// Multiply matrix x by matrix y
        /// component-wise, i.e., result[i][j] is the
        /// scalar product of x[i][j] and y[i][j].
        /// Note: To get linear-algebraic matrix
        /// multiplication, use the multiply
        /// operator (*).
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static mat3 matrixCompMult(mat3 x, mat3 y) { return null; }
        /// <summary>
        /// Multiply matrix x by matrix y
        /// component-wise, i.e., result[i][j] is the
        /// scalar product of x[i][j] and y[i][j].
        /// Note: To get linear-algebraic matrix
        /// multiplication, use the multiply
        /// operator (*).
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static mat4 matrixCompMult(mat4 x, mat4 y) { return null; }

        /// <summary>
        /// Returns a matrix that is the transpose
        /// of m. The input matrix is not
        /// modified.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat2 transpose(mat2 m) { return null; }
        /// <summary>
        /// Returns a matrix that is the transpose
        /// of m. The input matrix is not
        /// modified.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat3 transpose(mat3 m) { return null; }
        /// <summary>
        /// Returns a matrix that is the transpose
        /// of m. The input matrix is not
        /// modified.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat4 transpose(mat4 m) { return null; }
        /// <summary>
        /// Returns a matrix that is the transpose
        /// of m. The input matrix is not
        /// modified.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat2x3 transpose(mat3x2 m) { return null; }
        /// <summary>
        /// Returns a matrix that is the transpose
        /// of m. The input matrix is not
        /// modified.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat3x2 transpose(mat2x3 m) { return null; }
        /// <summary>
        /// Returns a matrix that is the transpose
        /// of m. The input matrix is not
        /// modified.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat2x4 transpose(mat4x2 m) { return null; }
        /// <summary>
        /// Returns a matrix that is the transpose
        /// of m. The input matrix is not
        /// modified.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat4x2 transpose(mat2x4 m) { return null; }
        /// <summary>
        /// Returns a matrix that is the transpose
        /// of m. The input matrix is not
        /// modified.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat3x4 transpose(mat4x3 m) { return null; }
        /// <summary>
        /// Returns a matrix that is the transpose
        /// of m. The input matrix is not
        /// modified.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat4x3 transpose(mat3x4 m) { return null; }

        /// <summary>
        /// Returns a matrix that is the inverse of
        /// m. The input matrix is not modified.
        /// The values in the returned matrix are
        /// undefined if the input matrix is
        /// singular or poorly conditioned (nearly
        /// singular).
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat2 inverse(mat2 m) { return null; }
        /// <summary>
        /// Returns a matrix that is the inverse of
        /// m. The input matrix is not modified.
        /// The values in the returned matrix are
        /// undefined if the input matrix is
        /// singular or poorly conditioned (nearly
        /// singular).
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat3 inverse(mat3 m) { return null; }
        /// <summary>
        /// Returns a matrix that is the inverse of
        /// m. The input matrix is not modified.
        /// The values in the returned matrix are
        /// undefined if the input matrix is
        /// singular or poorly conditioned (nearly
        /// singular).
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static mat4 inverse(mat4 m) { return null; }

        /// <summary>
        /// Returns the outer product. Treats the
        /// first parameter as a column vector and
        /// the second parameter as a row vector
        /// and performs a linear algebra matrix
        /// multipy c*r yielding a matrix.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static mat2 outerProduct(vec2 c, vec2 r) { return null; }
        /// <summary>
        /// Returns the outer product. Treats the
        /// first parameter as a column vector and
        /// the second parameter as a row vector
        /// and performs a linear algebra matrix
        /// multipy c*r yielding a matrix.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static mat3 outerProduct(vec3 c, vec3 r) { return null; }
        /// <summary>
        /// Returns the outer product. Treats the
        /// first parameter as a column vector and
        /// the second parameter as a row vector
        /// and performs a linear algebra matrix
        /// multipy c*r yielding a matrix.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static mat4 outerProduct(vec4 c, vec4 r) { return null; }
        /// <summary>
        /// Returns the outer product. Treats the
        /// first parameter as a column vector and
        /// the second parameter as a row vector
        /// and performs a linear algebra matrix
        /// multipy c*r yielding a matrix.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static mat2x3 outerProduct(vec2 c, vec3 r) { return null; }
        /// <summary>
        /// Returns the outer product. Treats the
        /// first parameter as a column vector and
        /// the second parameter as a row vector
        /// and performs a linear algebra matrix
        /// multipy c*r yielding a matrix.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static mat3x2 outerProduct(vec3 c, vec2 r) { return null; }
        /// <summary>
        /// Returns the outer product. Treats the
        /// first parameter as a column vector and
        /// the second parameter as a row vector
        /// and performs a linear algebra matrix
        /// multipy c*r yielding a matrix.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static mat2x4 outerProduct(vec2 c, vec4 r) { return null; }
        /// <summary>
        /// Returns the outer product. Treats the
        /// first parameter as a column vector and
        /// the second parameter as a row vector
        /// and performs a linear algebra matrix
        /// multipy c*r yielding a matrix.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static mat4x2 outerProduct(vec4 c, vec2 r) { return null; }
        /// <summary>
        /// Returns the outer product. Treats the
        /// first parameter as a column vector and
        /// the second parameter as a row vector
        /// and performs a linear algebra matrix
        /// multipy c*r yielding a matrix.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static mat3x4 outerProduct(vec3 c, vec4 r) { return null; }
        /// <summary>
        /// Returns the outer product. Treats the
        /// first parameter as a column vector and
        /// the second parameter as a row vector
        /// and performs a linear algebra matrix
        /// multipy c*r yielding a matrix.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static mat4x3 outerProduct(vec4 c, vec3 r) { return null; }

    }
}