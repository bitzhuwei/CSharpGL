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
        /// Position in world space.
        /// </summary>
        vec3 WorldPosition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        float RotationAngle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        vec3 RotationAxis { get; set; }

        /// <summary>
        /// 
        /// </summary>
        vec3 Scale { get; set; }

        /// <summary>
        /// Length in X/Y/Z axis.
        /// </summary>
        vec3 Lengths { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class IModelSpaceHelper
    {
        /// <summary>
        /// Get model matrix that transform model from model space to world space.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static mat4 GetMatrix(this IModelSpace model)
        {
            mat4 matrix = glm.translate(mat4.identity(), model.WorldPosition);
            matrix = glm.scale(matrix, model.Scale);
            matrix = glm.rotate(matrix, model.RotationAngle, model.RotationAxis);
            return matrix;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static BoundingBox GetBoundingBox(this IModelSpace model)
        {
            vec3 max, min;
            {
                vec3 position = model.WorldPosition + model.Lengths / 2;
                max = position;
            }
            {
                vec3 position = model.WorldPosition - model.Lengths / 2;
                min = position;
            }

            return new BoundingBox(min, max);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        internal static void LegacyTransform(this IModelSpace model)
        {
            OpenGL.Translate(model.WorldPosition.x, model.WorldPosition.y, model.WorldPosition.z);
            OpenGL.Scale(model.Scale.x, model.Scale.y, model.Scale.z);
            OpenGL.Rotate(model.RotationAngle, model.RotationAxis.x, model.RotationAxis.y, model.RotationAxis.z);
        }
    }
}
