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
            this.Size = new vec3(2, 2, 2);
        }

        protected override void DoInitialize()
        {
            circleRenderer.Initialize();
            markRenderer.Initialize();
            pinRenderer.Initialize();
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            circleRenderer.Render(arg);
            markRenderer.Render(arg);
            pinRenderer.Render(arg);
        }

        public override vec3 WorldPosition
        {
            //get { return this.circleRenderer.WorldPosition; }
            set
            {
                this.circleRenderer.WorldPosition = value;
                this.markRenderer.WorldPosition = value;
                this.pinRenderer.WorldPosition = value;
                base.WorldPosition = value;
            }
        }

        public override float RotationAngleDegree
        {
            //get { return this.circleRenderer.RotationAngle; }
            set
            {
                this.circleRenderer.RotationAngleDegree = value;
                this.markRenderer.RotationAngleDegree = value;
                this.pinRenderer.RotationAngleDegree = value;
                base.RotationAngleDegree = value;
            }
        }

        public override vec3 RotationAxis
        {
            //get { return this.circleRenderer.RotationAxis; }
            set
            {
                this.circleRenderer.RotationAxis = value;
                this.markRenderer.RotationAxis = value;
                this.pinRenderer.RotationAxis = value;
                base.RotationAxis = value;
            }
        }

        public override vec3 Scale
        {
            //get { return this.circleRenderer.Scale; }
            set
            {
                this.circleRenderer.Scale = value;
                this.markRenderer.Scale = value;
                this.pinRenderer.Scale = value;
                base.Scale = value;
            }
        }

        public override vec3 Size
        {
            //get { return this.circleRenderer.Lengths; }
            set
            {
                this.circleRenderer.Size = value;
                this.markRenderer.Size = value;
                this.pinRenderer.Size = value;
                base.Size = value;
            }
        }
    }
}