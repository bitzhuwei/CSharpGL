using System.ComponentModel;
namespace CSharpGL
{
    public abstract partial class RendererBase
    {
        /// <summary>
        /// records whether modelMatrix is updated.
        /// </summary>
        protected UpdatingRecord modelMatrixRecord = new UpdatingRecord(true);

        private vec3 worldPosition;

        /// <summary>
        /// Position in world space.
        /// </summary>
        [Category(strRenderer)]
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
        ///
        /// </summary>
        [Category(strRenderer)]
        public virtual float RotationAngle
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
        ///
        /// </summary>
        [Category(strRenderer)]
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
        ///
        /// </summary>
        [Category(strRenderer)]
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
        ///
        /// </summary>
        [Category(strRenderer)]
        public virtual vec3 Lengths { get; set; }
    }
}