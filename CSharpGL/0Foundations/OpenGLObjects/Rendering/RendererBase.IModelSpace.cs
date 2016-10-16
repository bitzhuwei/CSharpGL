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

        private mat4 modelMatrix = mat4.identity();
        private mat4 cascadeModelMatrix = mat4.identity();

        /// <summary>
        /// Should this model matrix be updated?
        /// </summary>
        /// <returns></returns>
        public bool IsModelMatrixMarked()
        {
            return this.modelMatrixRecord.IsMarked();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelMatrix"></param>
        /// <returns></returns>
        public bool GetCascadeModelMatrix(out mat4 modelMatrix)
        {
            mat4 thisModel;
            bool result = GetUpdatedModelMatrix(out thisModel);
            SceneObject obj = this.BindingSceneObject;
            if (obj != null)
            {
                RendererBase renderer = obj.Renderer;
                if (renderer != null)
                {
                    // this requires scene objects to be rendered from parent to children.
                    this.cascadeModelMatrix = renderer.cascadeModelMatrix * thisModel;
                }
            }

            modelMatrix = this.cascadeModelMatrix;

            return result;
        }
        /// <summary>
        /// Get model matrix that transform model from model space to world space.
        /// <para>This method will also cancel updated recording mark.</para>
        /// <para>Returns true if model matrix is updated; otherwise return false.</para>
        /// </summary>
        /// <param name="modelMatrix">updated model matrix.</param>
        /// <returns></returns>
        public bool GetUpdatedModelMatrix(out mat4 modelMatrix)
        {
            bool result = false;
            if (this.modelMatrixRecord.IsMarked())
            {
                this.modelMatrix = IModelSpaceHelper.GetModelMatrix(this);
                this.modelMatrixRecord.CancelMark();
                result = true;
            }

            modelMatrix = this.modelMatrix;

            return result;
        }

        /// <summary>
        /// Get model matrix that transform model from model space to world space.
        /// <para>This method will also cancel updated recording mark.</para>
        /// </summary>
        /// <returns></returns>
        public mat4 GetUpdatedModelMatrix()
        {
            if (this.modelMatrixRecord.IsMarked())
            {
                this.modelMatrix = IModelSpaceHelper.GetModelMatrix(this);
                this.modelMatrixRecord.CancelMark();
            }

            return this.modelMatrix;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum ModelSpaceFactor
    {
        /// <summary>
        /// 
        /// </summary>
        WorldPosition,
        /// <summary>
        /// 
        /// </summary>
        Scale,
        /// <summary>
        /// 
        /// </summary>
        RotationAngle,
        /// <summary>
        /// 
        /// </summary>
        RotationAxis,
    }
}