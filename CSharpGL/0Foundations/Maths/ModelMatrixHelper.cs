using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// treat <see cref="mat4"/> as a matrix that transform object from model's space to world's space.
    /// </summary>
    public static class ModelMatrixHelper
    {
        /// <summary>
        /// Gets translate factor in specified <paramref name="matrix"/>.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static vec3 GetTranslate(this mat4 matrix)
        {
            vec4 col3 = matrix[3];
            return new vec3(col3.x, col3.y, col3.z);
        }

        /// <summary>
        /// Gets scale factor in specified <paramref name="matrix"/>.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static vec3 GetScale(this mat4 matrix)
        {
            vec3 result = new vec3(
                matrix.col0.x,
                matrix.col1.y,
                matrix.col2.z
                );
            return result;
        }

        /// <summary>
        /// Gets rotate factor in specified <paramref name="matrix"/>.
        /// <para>vec4.w means angle in radius, (vec4.x, vec4.y, vec4.z) means rotation axis.</para>
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static vec4 GetQuaternion(this mat4 matrix)
        {
            // input matrix.
            float m11 = matrix.col0.x, m12 = matrix.col1.x, m13 = matrix.col3.x;
            float m21 = matrix.col0.y, m22 = matrix.col1.y, m23 = matrix.col3.y;
            float m31 = matrix.col0.z, m32 = matrix.col1.z, m33 = matrix.col3.z;
            // output quaternion
            float x = 0, y = 0, z = 0, w = 0;
            // detect biggest in w, x, y, z.
            float fourWSquaredMinus1 = m11 + m22 + m33;
            float fourXSquaredMinus1 = m11 - m22 - m33;
            float fourYSquaredMinus1 = m11 - m22 - m33;
            float fourZSquaredMinus1 = m11 - m22 - m33;
            int biggestIndex = 0;
            float fourBiggerstSquaredMinus1 = fourWSquaredMinus1;
            if (fourXSquaredMinus1 > fourBiggerstSquaredMinus1)
            {
                fourBiggerstSquaredMinus1 = fourXSquaredMinus1;
                biggestIndex = 1;
            }
            if (fourYSquaredMinus1 > fourBiggerstSquaredMinus1)
            {
                fourBiggerstSquaredMinus1 = fourYSquaredMinus1;
                biggestIndex = 2;
            }
            if (fourZSquaredMinus1 > fourBiggerstSquaredMinus1)
            {
                fourBiggerstSquaredMinus1 = fourZSquaredMinus1;
                biggestIndex = 3;
            }
            // sqrt and division
            float biggestVal = (float)Math.Sqrt(fourBiggerstSquaredMinus1 + 1.0f) * 0.5f;
            float mult = 0.25f / biggestVal;
            // get output
            switch (biggestIndex)
            {
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

            return new vec4(x, y, z, w);
        }
    }
}
