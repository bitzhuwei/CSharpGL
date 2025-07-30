﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL {
    /// <summary>
    /// gets model's original size.
    /// transform a model from model's sapce to world's space.
    /// </summary>

    public interface IWorldSpace {
        /// <summary>
        /// Position in world space.
        /// </summary>
        vec3 WorldPosition { get; set; }

        /// <summary>
        /// Rotation occurs based on which position?
        /// </summary>
        vec3 RotationCenter { get; set; }

        /// <summary>
        /// Rotation angle in degree.
        /// </summary>
        float RotationAngle { get; set; }

        /// <summary>
        /// Rotation axis.
        /// </summary>
        vec3 RotationAxis { get; set; }

        /// <summary>
        /// Scale occurs based on which position?
        /// </summary>
        vec3 ScaleCenter { get; set; }

        /// <summary>
        /// Scale factor.
        /// </summary>
        vec3 Scale { get; set; }

        /// <summary>
        /// Size in X/Y/Z axis.
        /// </summary>
        vec3 ModelSize { get; set; }
    }

    /// <summary>
    /// transform event argument.
    /// </summary>
    public class TransformEventArgs {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransformEventArgs"/> class.
        /// </summary>
        public TransformEventArgs() {
            this.ModelMatrixStack = new Stack<mat4>();
            this.ModelMatrixStack.Push(mat4.identity());
        }
        /// <summary>
        /// 
        /// </summary>
        internal Stack<mat4> ModelMatrixStack { get; private set; }
    }

    /// <summary>
    ///
    /// </summary>
    public static class IWorldSpaceHelper {
        /// <summary>
        /// Gets max and min position of the AABB box that wraps specified <paramref name="model"/>.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="maxPosition"></param>
        /// <param name="minPosition"></param>
        public static void GetMaxMinPosition(this IWorldSpace model, out vec3 maxPosition, out vec3 minPosition) {
            if (model == null) { throw new System.ArgumentNullException(); }

            vec3 lengths = model.ModelSize * model.Scale;
            maxPosition = model.WorldPosition + lengths / 2.0f;
            minPosition = model.WorldPosition - lengths / 2.0f;
        }

        /// <summary>
        /// Copy <see cref="IWorldSpace"/> state from specified <paramref name="source"/>.
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="source"></param>
        public static void CopyModelSpaceStateFrom(this IWorldSpace dest, IWorldSpace source) {
            if (dest == null || source == null) { throw new System.ArgumentNullException(); }

            dest.ModelSize = source.ModelSize;
            dest.RotationAngle = source.RotationAngle;
            dest.RotationAxis = source.RotationAxis;
            dest.Scale = source.Scale;
            dest.WorldPosition = source.WorldPosition;
        }

        ///// <summary>
        ///// Get model matrix.
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public static mat4 GetModelMatrix(this IWorldSpace model)
        //{
        //    mat4 matrix = glm.translate(mat4.identity(), model.WorldPosition);
        //    matrix = glm.scale(matrix, model.Scale);
        //    matrix = glm.rotate(matrix, model.RotationAngle, model.RotationAxis);

        //    var node = model as RendererBase;
        //    if (node != null)
        //    {
        //        var parent = node.Parent as RendererBase;
        //        if (parent != null)
        //        {
        //            matrix = parent.modelMat * matrix;
        //        }

        //        node.modelMat = matrix;
        //    }

        //    return matrix;
        //}

        /// <summary>
        /// Rotate this model based on all previous rotation actions.
        /// Thus all rotations will take part in model's rotation result.
        /// <para>在目前的旋转状态下继续旋转一次，即所有的旋转操作都会（按照发生顺序）生效。</para>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="angleDegree">Angle in Degree.</param>
        /// <param name="axis"></param>
        public static void Rotate(this IWorldSpace model, float angleDegree, vec3 axis) {
            mat4 currentRotationMatrix = glm.rotate(model.RotationAngle, model.RotationAxis);
            mat4 newRotationMatrix = glm.rotate(angleDegree, axis);
            mat4 latestRotationMatrix = newRotationMatrix * currentRotationMatrix;
            Quaternion quaternion = latestRotationMatrix.ToQuaternion();
            float latestAngle;
            vec3 latestAxis;
            quaternion.Parse(out latestAngle, out latestAxis);
            model.RotationAngle = latestAngle;
            model.RotationAxis = latestAxis;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static BoundingBox GetBoundingBox(this IWorldSpace model) {
            vec3 max, min;
            {
                vec3 position = model.WorldPosition + model.ModelSize * model.Scale / 2;
                max = position;
            }
            {
                vec3 position = model.WorldPosition - model.ModelSize * model.Scale / 2;
                min = position;
            }

            return new BoundingBox(min, max);
        }

        /// <summary>
        /// Run legacy model transform.(from model space to world space)
        /// </summary>
        /// <param name="model"></param>
        public unsafe static void LegacyTransform(this IWorldSpace model) {
            var gl = GL.current; if (gl != null) {
                gl.glTranslatef(model.WorldPosition.x, model.WorldPosition.y, model.WorldPosition.z);
                gl.glScalef(model.Scale.x, model.Scale.y, model.Scale.z);
                gl.glRotatef(model.RotationAngle, model.RotationAxis.x, model.RotationAxis.y, model.RotationAxis.z);
            }
        }
    }
}