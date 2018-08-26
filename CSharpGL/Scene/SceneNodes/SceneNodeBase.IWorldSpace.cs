using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public abstract partial class SceneNodeBase
    {

        /// <summary>
        /// indicates whether <see cref="IWorldSpace"/>'s property value has changed.
        /// </summary>
        internal bool worldSpacePropertyUpdated = true;
        /// <summary>
        /// cascade model matrix.
        /// </summary>
        internal mat4 cascadeModelMatrix = mat4.identity();
        /// <summary>
        /// this model's matrix from <see cref="IWorldSpace"/>.
        /// </summary>
        internal mat4 thisModelMatrix = mat4.identity();

        #region IWorldSpace 成员

        private vec3 worldSpacePosition;
        /// <summary>
        /// Position in world space relative to parent node.
        /// </summary>
        [Category(strSceneNodeBase)]
        [Description("Position in world space relative to parent node.")]
        public vec3 WorldPosition
        {
            get { return worldSpacePosition; }
            set
            {
                if (worldSpacePosition != value)
                {
                    worldSpacePosition = value;
                    worldSpacePropertyUpdated = true;
                }
            }
        }

        private vec3 rotationCenter;
        /// <summary>
        /// Rotation occurs based on which position?
        /// </summary>
        [Category(strSceneNodeBase)]
        [Description("Rotation occurs based on which position?")]
        public vec3 RotationCenter
        {
            get { return this.rotationCenter; }
            set
            {
                if (this.rotationCenter != value)
                {
                    this.rotationCenter = value;
                    this.worldSpacePropertyUpdated = true;
                }
            }
        }

        private float rotationAngle;
        /// <summary>
        /// Rotation angle in degrees in world space relative to parent node.
        /// </summary>
        [Category(strSceneNodeBase)]
        [Description("Rotation angle in degrees in world space relative to parent node.")]
        public float RotationAngle
        {
            get { return this.rotationAngle; }
            set
            {
                if (this.rotationAngle != value)
                {
                    this.rotationAngle = value;
                    this.worldSpacePropertyUpdated = true;
                }
            }
        }

        private vec3 rotationAxis = new vec3(0, 1, 0);
        /// <summary>
        /// Rotation axis in world space relative to parent node.
        /// </summary>
        [Category(strSceneNodeBase)]
        [Description("Rotation axis in world space relative to parent node.")]
        public vec3 RotationAxis
        {
            get { return this.rotationAxis; }
            set
            {
                if (this.rotationAxis != value)
                {
                    this.rotationAxis = value;
                    this.worldSpacePropertyUpdated = true;
                }
            }
        }

        private vec3 scaleCenter;
        /// <summary>
        /// Scale occurs based on which position?
        /// </summary>
        [Category(strSceneNodeBase)]
        [Description("Scale occurs based on which position?")]
        public vec3 ScaleCenter
        {
            get { return this.scaleCenter; }
            set
            {
                if (this.scaleCenter != value)
                {
                    this.scaleCenter = value;
                    this.worldSpacePropertyUpdated = true;
                }
            }
        }

        private vec3 scale = new vec3(1, 1, 1);
        /// <summary>
        /// Scale in world space relative to parent node.
        /// </summary>
        [Category(strSceneNodeBase)]
        [Description("Scale in world space relative to parent node.")]
        public vec3 Scale
        {
            get { return this.scale; }
            set
            {
                if (this.scale != value)
                {
                    this.scale = value;
                    this.worldSpacePropertyUpdated = true;
                }
            }
        }

        private vec3 _modelSize = new vec3(1, 1, 1);
        /// <summary>
        /// This model's size.
        /// </summary>
        [Category(strSceneNodeBase)]
        [Description("This model's size.")]
        public vec3 ModelSize
        {
            get { return this._modelSize; }
            set
            {
                if (_modelSize != value)
                {
                    _modelSize = value;
                    worldSpacePropertyUpdated = true;
                }
            }
        }

        #endregion

        /// <summary>
        /// Gets the cascade model matrix.
        /// </summary>
        /// <returns></returns>
        public mat4 GetModelMatrix()
        {
            return this.cascadeModelMatrix;
        }

        /// <summary>
        /// Update and Get cascade model matrix.
        /// </summary>
        /// <param name="parentCascadeModelMatrix"></param>
        /// <returns></returns>
        public mat4 GetModelMatrix(mat4 parentCascadeModelMatrix)
        {
            if (this.worldSpacePropertyUpdated)
            {
                mat4 matrix = glm.translate(mat4.identity(), this.WorldPosition);
                matrix = glm.translate(matrix, this.ScaleCenter);
                matrix = glm.scale(matrix, this.Scale);
                matrix = glm.translate(matrix, -this.ScaleCenter);
                matrix = glm.translate(matrix, this.RotationCenter);
                matrix = glm.rotate(matrix, this.RotationAngle, this.RotationAxis);
                matrix = glm.translate(matrix, -this.RotationCenter);
                this.thisModelMatrix = matrix;
                this.worldSpacePropertyUpdated = false;

                matrix = parentCascadeModelMatrix * matrix;

                this.cascadeModelMatrix = matrix;
            }
            else
            {
                this.cascadeModelMatrix = parentCascadeModelMatrix * this.thisModelMatrix;
            }

            return this.cascadeModelMatrix;
        }
    }
}