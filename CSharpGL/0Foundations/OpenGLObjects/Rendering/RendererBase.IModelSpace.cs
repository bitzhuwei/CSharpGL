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
        protected UpdatingRecord modelMatrixRecord = new UpdatingRecord(true);

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
        public virtual vec3 Lengths { get; set; }

        #endregion IModelSpace
    }
}