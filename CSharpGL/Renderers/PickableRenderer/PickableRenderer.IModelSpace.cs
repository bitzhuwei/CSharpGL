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
                InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
                if (innerPickableRenderer != null)
                {
                    return innerPickableRenderer.WorldPosition;
                }
                else
                {
                    return new vec3(0, 0, 0);
                }
            }
            set
            {
                InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
                if (innerPickableRenderer != null)
                {
                    innerPickableRenderer.WorldPosition = value;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override vec3 Lengths
        {
            get
            {
                InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
                if (innerPickableRenderer != null)
                {
                    return innerPickableRenderer.Lengths;
                }
                else
                {
                    return new vec3(0, 0, 0);
                }
            }
            set
            {
                InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
                if (innerPickableRenderer != null)
                {
                    innerPickableRenderer.Lengths = value;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override float RotationAngle
        {
            get
            {
                InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
                if (innerPickableRenderer != null)
                {
                    return innerPickableRenderer.RotationAngle;
                }
                else
                {
                    return 0.0f;
                }
            }
            set
            {
                InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
                if (innerPickableRenderer != null)
                {
                    innerPickableRenderer.RotationAngle = value;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override vec3 RotationAxis
        {
            get
            {
                InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
                if (innerPickableRenderer != null)
                {
                    return innerPickableRenderer.RotationAxis;
                }
                else
                {
                    return new vec3(0, 0, 0);
                }
            }
            set
            {
                InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
                if (innerPickableRenderer != null)
                {
                    innerPickableRenderer.RotationAxis = value;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override vec3 Scale
        {
            get
            {
                InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
                if (innerPickableRenderer != null)
                {
                    return innerPickableRenderer.Scale;
                }
                else
                {
                    return new vec3(0, 0, 0);
                }
            }
            set
            {
                InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
                if (innerPickableRenderer != null)
                {
                    innerPickableRenderer.Scale = value;
                }
            }
        }
    }
}