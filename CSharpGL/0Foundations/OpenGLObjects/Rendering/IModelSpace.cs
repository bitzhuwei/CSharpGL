using System;

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
        /// Rotation angle in radian.
        /// </summary>
        float RotationRadianAngle { get; set; }

        /// <summary>
        /// Rotation axis.
        /// </summary>
        vec3 RotationAxis { get; set; }

        /// <summary>
        /// Scale factor.
        /// </summary>
        vec3 Scale { get; set; }

        /// <summary>
        /// Length in X/Y/Z axis.
        /// </summary>
        vec3 Lengths { get; set; }
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
        public static mat4 GetModelMatrix(this IModelSpace model)
        {
            mat4 matrix = glm.translate(mat4.identity(), model.WorldPosition);
            matrix = glm.scale(matrix, model.Scale);
            matrix = glm.rotate(matrix, model.RotationRadianAngle, model.RotationAxis);
            return matrix;
        }

        /// <summary>
        /// Rotate this model based on all previous rotation actions.
        /// Thus all rotations will take part in model's rotation result.
        /// <para>在目前的旋转状态下继续旋转一次，即所有的旋转操作都会（按照发生顺序）生效。</para>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="angle"></param>
        /// <param name="axis"></param>
        public static void Rotate(this IModelSpace model, float angle, vec3 axis)
        {
            mat4 currentRotationMatrix = glm.rotate(model.RotationRadianAngle, model.RotationAxis);
            mat4 newRotationMatrix = glm.rotate(angle, axis);
            mat4 latestRotationMatrix = newRotationMatrix * currentRotationMatrix;
            Quaternion quaternion = latestRotationMatrix.ToQuaternion();
            float latestAngle;
            vec3 latestAxis;
            quaternion.Parse(out latestAngle, out latestAxis);
            model.RotationRadianAngle = latestAngle;
            model.RotationAxis = latestAxis;
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
        /// Run legacy model transform.(from model space to world space)
        /// </summary>
        /// <param name="model"></param>
        public static void LegacyTransform(this IModelSpace model)
        {
            OpenGL.Translate(model.WorldPosition.x, model.WorldPosition.y, model.WorldPosition.z);
            OpenGL.Scale(model.Scale.x, model.Scale.y, model.Scale.z);
            OpenGL.Rotate(model.RotationRadianAngle, model.RotationAxis.x, model.RotationAxis.y, model.RotationAxis.z);
        }
    }
}