namespace CSharpGL
{
    /// <summary>
    /// </summary>
    internal class BoundedClockRenderer : RendererBase, IRenderable, IWorldSpace
    {
        public LegacyBoundingBoxRenderer BoxRenderer { get; set; }
        public ClockRenderer ClockRenderer { get; set; }

        public BoundedClockRenderer()
        {
            this.BoxRenderer = new LegacyBoundingBoxRenderer();
            const float factor = 1.4f;
            this.BoxRenderer.Scale = new vec3(factor, factor, factor);
            this.ClockRenderer = new ClockRenderer(new vec3(1, 0.8f, 0));
        }

        protected override void DoInitialize()
        {
            this.BoxRenderer.Initialize();
            this.ClockRenderer.Initialize();
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
            this.BoxRenderer.Render(arg);
            this.ClockRenderer.Render(arg);
        }

        #region IWorldSpace 成员

        public vec3 WorldPosition
        {
            get { return this.BoxRenderer.WorldPosition; }
            set
            {
                this.BoxRenderer.WorldPosition = value;
                this.ClockRenderer.WorldPosition = value;
            }
        }

        public float RotationAngle
        {
            get { return this.BoxRenderer.RotationAngle; }
            set
            {
                this.BoxRenderer.RotationAngle = value;
                this.ClockRenderer.RotationAngle = value;
            }
        }

        public vec3 RotationAxis
        {
            get { return this.BoxRenderer.RotationAxis; }
            set
            {
                this.BoxRenderer.RotationAxis = value;
                this.ClockRenderer.RotationAxis = value;
            }
        }

        public vec3 Scale
        {
            get { return this.BoxRenderer.Scale; }
            set
            {
                this.BoxRenderer.Scale = value;
                this.ClockRenderer.Scale = value;
            }
        }

        public vec3 ModelSize
        {
            get { return this.BoxRenderer.ModelSize; }
            set
            {
                this.BoxRenderer.ModelSize = value;
                this.ClockRenderer.ModelSize = value;
            }
        }

        #endregion
    }
}