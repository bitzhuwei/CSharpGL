namespace CSharpGL
{
    public partial class PickableRenderer
    {
        /// <summary>
        ///
        /// </summary>
        public override vec3 WorldPosition
        {
            get
            {
                return base.WorldPosition;
            }
            set
            {
                InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
                if (innerPickableRenderer != null)
                {
                    innerPickableRenderer.WorldPosition = value;
                }

                base.WorldPosition = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override vec3 Lengths
        {
            get
            {
                return base.Lengths;
            }
            set
            {
                InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
                if (innerPickableRenderer != null)
                {
                    innerPickableRenderer.Lengths = value;
                }

                base.Lengths = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override float RotationAngle
        {
            get
            {
                return base.RotationAngle;
            }
            set
            {
                InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
                if (innerPickableRenderer != null)
                {
                    innerPickableRenderer.RotationAngle = value;
                }

                base.RotationAngle = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override vec3 RotationAxis
        {
            get
            {
                return base.RotationAxis;
            }
            set
            {
                InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
                if (innerPickableRenderer != null)
                {
                    innerPickableRenderer.RotationAxis = value;
                }

                base.RotationAxis = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override vec3 Scale
        {
            get
            {
                return base.Scale;
            }
            set
            {
                InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
                if (innerPickableRenderer != null)
                {
                    innerPickableRenderer.Scale = value;
                }

                base.Scale = value;
            }
        }
    }
}