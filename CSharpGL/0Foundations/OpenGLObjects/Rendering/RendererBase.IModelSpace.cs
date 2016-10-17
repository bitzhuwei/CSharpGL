using System;
using System.ComponentModel;

namespace CSharpGL
{
    public abstract partial class RendererBase
    {
        #region IModelSpace

        /// <summary>
        ///
        /// </summary>
        protected const string strModelSpace = "Model Space";

        /// <summary>
        /// records whether modelMatrix is updated.
        /// </summary>
        private UpdatingRecord modelMatrixRecord = new UpdatingRecord(true);

        private vec3 worldPosition;

        /// <summary>
        /// Position in world space.
        /// </summary>
        [Category(strModelSpace)]
        [Description("Position in world space.")]
        public virtual vec3 WorldPosition
        {
            get { return worldPosition; }
            set
            {
                if (worldPosition != value)
                {
                    worldPosition = value;
                    modelMatrixRecord.Mark();
                }
            }
        }

        private float rotationAngle;

        /// <summary>
        /// Rotation angle in degree.
        /// </summary>
        [Category(strModelSpace)]
        [Description("Rotation angle in degree.")]
        public virtual float RotationAngleDegree
        {
            get { return rotationAngle; }
            set
            {
                if (rotationAngle != value)
                {
                    rotationAngle = value;
                    modelMatrixRecord.Mark();
                }
            }
        }

        private vec3 rotationAxis = new vec3(0, 1, 0);

        /// <summary>
        /// Rotation axis.
        /// </summary>
        [Category(strModelSpace)]
        [Description("Rotation axis.")]
        public virtual vec3 RotationAxis
        {
            get { return rotationAxis; }
            set
            {
                if (rotationAxis != value)
                {
                    rotationAxis = value;
                    modelMatrixRecord.Mark();
                }
            }
        }

        private vec3 scale = new vec3(1, 1, 1);

        /// <summary>
        /// Scale factor.
        /// </summary>
        [Category(strModelSpace)]
        [Description("Scale factor.")]
        public virtual vec3 Scale
        {
            get { return scale; }
            set
            {
                if (scale != value)
                {
                    scale = value;
                    modelMatrixRecord.Mark();
                }
            }
        }

        /// <summary>
        /// Length in X/Y/Z axis.
        /// </summary>
        [Category(strModelSpace)]
        [Description("Length in X/Y/Z axis.")]
        public virtual vec3 ModelSize { get; set; }

        #endregion IModelSpace

        private MarkableStruct<mat4> modelMatrix = new MarkableStruct<mat4>(mat4.identity());
        //private mat4 cascadeModelMatrix = mat4.identity();

        /// <summary>
        /// Should this model matrix be updated?
        /// </summary>
        /// <returns></returns>
        public bool IsModelMatrixMarked()
        {
            return this.modelMatrixRecord.IsMarked();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="modelMatrix"></param>
        ///// <returns></returns>
        //public bool GetCascadeModelMatrix(out mat4 modelMatrix)
        //{
        //    mat4 thisModel;
        //    bool result = GetModelMatrix();
        //    SceneObject obj = this.BindingSceneObject;
        //    if (obj != null)
        //    {
        //        RendererBase renderer = obj.Renderer;
        //        if (renderer != null)
        //        {
        //            // this requires scene objects to be rendered from parent to children.
        //            this.cascadeModelMatrix = renderer.cascadeModelMatrix * thisModel;
        //        }
        //    }

        //    modelMatrix = this.cascadeModelMatrix;

        //    return result;
        //}

        private long parentModelMatrixTicks;

        // TODO: cascade model matrix not tested yet!
        /// <summary>
        /// Get model matrix that transform model from model space to world space.
        /// Note: this method requires that parent scene object be rendered first, then chidren.
        /// </summary>
        /// <returns></returns>
        public MarkableStruct<mat4> GetModelMatrix()
        {
            if (this.modelMatrixRecord.IsMarked())// this model matrix is updated.
            {
                mat4 thisModel = IModelSpaceHelper.GetModelMatrix(this);
                this.modelMatrixRecord.CancelMark();
                // cascade parent's model matrix.
                SceneObject obj = this.BindingSceneObject;
                if (obj != null)
                {
                    RendererBase renderer = obj.Renderer;
                    if (renderer != null)
                    {
                        // this requires that parent scene object be rendered first, then chidren.
                        thisModel = renderer.modelMatrix.Value * thisModel;
                    }
                }
                // total model matrix.
                this.modelMatrix.Value = thisModel;
            }
            else // this model matrix is not updated.
            {
                SceneObject obj = this.BindingSceneObject;
                if (obj != null)
                {
                    SceneObject parent = obj.Parent;
                    if (parent != null)
                    {
                        RendererBase parentRenderer = parent.Renderer;
                        if (parentRenderer != null)
                        {
                            long ticks = parentRenderer.modelMatrix.UpdateTicks;
                            if (this.parentModelMatrixTicks != ticks) // parent's model matrix is updated.
                            {
                                this.modelMatrix.Value = parentRenderer.modelMatrix.Value * this.modelMatrix.Value;
                                this.parentModelMatrixTicks = ticks;
                            }
                        }
                    }
                }
            }

            return this.modelMatrix;
        }
    }

    ///// <summary>
    ///// 
    ///// </summary>
    //[Flags]
    //public enum ModelSpaceFactor
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    WorldPosition,
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    Scale,
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    RotationAngle,
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    RotationAxis,
    //}
}