namespace CSharpGL
{
    internal class ClockRenderer : RendererBase, IModelSpace
    {
        private readonly ClockCircleRenderer circleRenderer = new ClockCircleRenderer();
        private readonly ClockMarkRenderer markRenderer = new ClockMarkRenderer();
        private readonly ClockPinRenderer pinRenderer = new ClockPinRenderer();

        public ClockRenderer(vec3 worldPosition)
        {
            this.WorldPosition = worldPosition;
            const float factor = 0.5f;
            this.Scale = new vec3(factor, factor, factor);
            this.ModelSize = new vec3(2, 2, 2);
        }

        protected override void DoInitialize()
        {
            circleRenderer.Initialize();
            markRenderer.Initialize();
            pinRenderer.Initialize();
        }

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        public void Render(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { Initialize(); }

            DoRender(arg);
        }

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        protected void DoRender(RenderEventArgs arg)
        {
            circleRenderer.Render(arg);
            markRenderer.Render(arg);
            pinRenderer.Render(arg);
        }

        #region IModelSpace 成员

        public vec3 WorldPosition
        {
            get { return this.circleRenderer.WorldPosition; }
            set
            {
                this.circleRenderer.WorldPosition = value;
                this.markRenderer.WorldPosition = value;
                this.pinRenderer.WorldPosition = value;
            }
        }

        public float RotationAngle
        {
            get { return this.circleRenderer.RotationAngle; }
            set
            {
                this.circleRenderer.RotationAngle = value;
                this.markRenderer.RotationAngle = value;
                this.pinRenderer.RotationAngle = value;
            }
        }

        public vec3 RotationAxis
        {
            get { return this.circleRenderer.RotationAxis; }
            set
            {
                this.circleRenderer.RotationAxis = value;
                this.markRenderer.RotationAxis = value;
                this.pinRenderer.RotationAxis = value;
            }
        }

        public vec3 Scale
        {
            get { return this.circleRenderer.Scale; }
            set
            {
                this.circleRenderer.Scale = value;
                this.markRenderer.Scale = value;
                this.pinRenderer.Scale = value;
            }
        }

        public vec3 ModelSize
        {
            get { return this.circleRenderer.ModelSize; }
            set
            {
                this.circleRenderer.ModelSize = value;
                this.markRenderer.ModelSize = value;
                this.pinRenderer.ModelSize = value;
            }
        }

        #endregion

    }
}