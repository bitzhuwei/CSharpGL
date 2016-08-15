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
    }
}
