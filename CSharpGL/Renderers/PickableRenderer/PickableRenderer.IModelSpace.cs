namespace CSharpGL
{
    public partial class PickableRenderer
    {
        // 教训：必须永远对this.Property进行读写，否则会引起奇怪的bug。
        // 这是因为this.Property可能被其他地方引用，若this.Property不变，那么其他地方就不会收到通知。
        /// <summary>
        ///
        /// </summary>
        public override MarkableStruct<vec3> WorldPosition
        {
            get
            {
                return base.WorldPosition;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public override void SetWorldPosition(vec3 value)
        {
            InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
            if (innerPickableRenderer != null)
            {
                innerPickableRenderer.SetWorldPosition(value);
            }

            base.SetWorldPosition(value);
        }

        /// <summary>
        ///
        /// </summary>
        public override vec3 ModelSize
        {
            get
            {
                return base.ModelSize;
            }
            set
            {
                InnerPickableRenderer innerPickableRenderer = this.innerPickableRenderer;
                if (innerPickableRenderer != null)
                {
                    innerPickableRenderer.ModelSize = value;
                }

                base.ModelSize = value;
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