namespace CSharpGL
{
    internal class ClockRenderer : RendererBase, IModelSpace
    {
        private readonly ClockCircleRenderer circleRenderer = new ClockCircleRenderer();
        private readonly ClockMarkRenderer markRenderer = new ClockMarkRenderer();
        private readonly ClockPinRenderer pinRenderer = new ClockPinRenderer();

        public ClockRenderer(vec3 worldPosition)
        {
            this.SetWorldPosition(worldPosition);
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

        protected override void DoRender(RenderEventArgs arg)
        {
            circleRenderer.Render(arg);
            markRenderer.Render(arg);
            pinRenderer.Render(arg);
        }

        public override MarkableStruct<vec3> WorldPosition
        {
            get
            {
                return base.WorldPosition;
            }
        }

        public override void SetWorldPosition(vec3 value)
        {
            this.circleRenderer.SetWorldPosition(value);
            this.markRenderer.SetWorldPosition(value);
            this.pinRenderer.SetWorldPosition(value);
            base.SetWorldPosition(value);
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

        public override vec3 ModelSize
        {
            //get { return this.circleRenderer.Lengths; }
            set
            {
                this.circleRenderer.ModelSize = value;
                this.markRenderer.ModelSize = value;
                this.pinRenderer.ModelSize = value;
                base.ModelSize = value;
            }
        }
    }
}