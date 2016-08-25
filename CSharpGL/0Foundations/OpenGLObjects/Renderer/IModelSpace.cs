using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// gets model's original size.
    /// transform a model from model's sapce to world's space.
    /// </summary>
    public interface IModelSpace
    {
        /// <summary>
        /// world position before model is scaled or rotated.
        /// </summary>
        vec3 OriginalWorldPosition { get; }

        /// <summary>
        /// matrix that transforms a model from model's sapce to world's space.
        /// </summary>
        mat4 ModelMatrix { get; set; }

        /// <summary>
        /// Length in X/Y/Z axis.
        /// </summary>
        vec3 Lengths { get; }
    }
}
