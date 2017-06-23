using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public abstract partial class RendererBase
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

        private vec3 worldPosition;
        /// <summary>
        /// 
        /// </summary>
        public vec3 WorldPosition
        {
            get { return worldPosition; }
            set { worldPosition = value; worldSpacePropertyUpdated = true; }
        }

        private float rotationAngle;
        /// <summary>
        /// 
        /// </summary>
        public float RotationAngle
        {
            get { return rotationAngle; }
            set { rotationAngle = value; worldSpacePropertyUpdated = true; }
        }

        private vec3 _rotationAxis = new vec3(0, 1, 0);
        /// <summary>
        /// 
        /// </summary>
        public vec3 RotationAxis
        {
            get { return this._rotationAxis; }
            set { this._rotationAxis = value; worldSpacePropertyUpdated = true; }
        }

        private vec3 _scale = new vec3(1, 1, 1);
        /// <summary>
        /// 
        /// </summary>
        public vec3 Scale
        {
            get { return this._scale; }
            set { this._scale = value; worldSpacePropertyUpdated = true; }
        }

        private vec3 _modelSize = new vec3(1, 1, 1);
        /// <summary>
        /// 
        /// </summary>
        public vec3 ModelSize
        {
            get { return this._modelSize; }
            set { this._modelSize = value; worldSpacePropertyUpdated = true; }
        }

        #endregion


        /// <summary>
        /// Get cascade model matrix.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public mat4 GetModelMatrix()
        {
            if (this.worldSpacePropertyUpdated)
            {
                mat4 matrix = glm.translate(mat4.identity(), this.WorldPosition);
                matrix = glm.scale(matrix, this.Scale);
                matrix = glm.rotate(matrix, this.RotationAngle, this.RotationAxis);
                this.thisModelMatrix = matrix;
                this.worldSpacePropertyUpdated = false;

                var parent = this.Parent as RendererBase;
                if (parent != null)
                {
                    matrix = parent.cascadeModelMatrix * matrix;
                }

                this.cascadeModelMatrix = matrix;

            }
            else
            {
                var parent = this.Parent as RendererBase;
                if (parent != null)
                {
                    this.cascadeModelMatrix = parent.cascadeModelMatrix * this.thisModelMatrix;
                }
            }

            return this.cascadeModelMatrix;
        }
    }
}