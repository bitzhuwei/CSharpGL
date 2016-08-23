using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// transform a model from model's sapce to world's space.
    /// </summary>
    public interface IModelTransform
    {
        /// <summary>
        /// world position before model is scaled or rotated.
        /// </summary>
        vec3 OriginalWorldPosition { get; }

        /// <summary>
        /// matrix that transforms a model from model's sapce to world's space.
        /// </summary>
        mat4 ModelMatrix { get; set; }
    }
}
