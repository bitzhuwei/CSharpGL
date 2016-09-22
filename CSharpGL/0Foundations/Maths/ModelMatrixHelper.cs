using System;

namespace CSharpGL
{
    /// <summary>
    /// treat <see cref="mat4"/> as a matrix that transform object from model's space to world's space.
    /// </summary>
    public static class ModelMatrixHelper
    {
        /// <summary>
        /// Gets rotate factor in specified <paramref name="matrix"/>.
        /// <para>vec4.w means angle in radius, (vec4.x, vec4.y, vec4.z) means rotation axis.</para>
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Quaternion ToQuaternion(this mat4 matrix)
        {
            return (matrix.to_mat3().ToQuaternion());
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
        /// Gets translate factor in specified <paramref name="matrix"/>.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static vec3 GetTranslate(this mat4 matrix)
        {
            vec4 col3 = matrix[3];
            return new vec3(col3.x, col3.y, col3.z);
        }
    }
}