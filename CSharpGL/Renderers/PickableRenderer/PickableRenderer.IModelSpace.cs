namespace CSharpGL
{
    public partial class PickableRenderer
    {
        // 教训：必须永远对this.Property进行读写，否则会引起奇怪的bug。
        // 这是因为this.Property可能被其他地方引用，若this.Property不变，那么其他地方就不会收到通知。
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
        public override float RotationAngleDegree
        {
            get
            {
                return base.RotationAngleDegree;
            }
            set
            {
                InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
                if (innerPickableRenderer != null)
                {
                    innerPickableRenderer.RotationAngleDegree = value;
                }

                base.RotationAngleDegree = value;
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