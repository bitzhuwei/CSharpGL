namespace CSharpGL.Demos
{
    /// <summary>
    /// 高亮显示拾取的图元。
    /// </summary>
    public class HighlightedPickableRenderer : RendererBase
    {
        /// <summary>
        /// 高亮显示拾取的图元。
        /// </summary>
        /// <param name="highlighter"></param>
        /// <param name="pickableRenderer"></param>
        public HighlightedPickableRenderer(HighlightRenderer highlighter,
            PickableRenderer pickableRenderer)
        {
            this.Highlighter = highlighter;
            this.PickableRenderer = pickableRenderer;
        }

        protected override void DoInitialize()
        {
            this.Highlighter.Initialize();
            this.PickableRenderer.Initialize();
            this.Highlighter.WorldPosition = this.PickableRenderer.WorldPosition;
            this.Highlighter.Lengths = this.PickableRenderer.Lengths;
            this.PickableRenderer.RotationAxis = this.PickableRenderer.RotationAxis;
            this.PickableRenderer.RotationAngle = this.PickableRenderer.RotationAngle;
            this.PickableRenderer.Scale = this.PickableRenderer.Scale;
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.Highlighter.Render(arg);
            this.PickableRenderer.Render(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
            this.Highlighter.Dispose();
            this.PickableRenderer.Dispose();
        }

        /// <summary>
        /// 高亮。
        /// </summary>
        public HighlightRenderer Highlighter { get; private set; }

        /// <summary>
        /// 拾取。
        /// </summary>
        public PickableRenderer PickableRenderer { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public override vec3 WorldPosition
        {
            get
            {
                return PickableRenderer.WorldPosition;
            }
            set
            {
                Highlighter.WorldPosition = value;
                PickableRenderer.WorldPosition = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override vec3 Lengths
        {
            get
            {
                return PickableRenderer.Lengths;
            }
            set
            {
                Highlighter.Lengths = value;
                PickableRenderer.Lengths = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override float RotationAngle
        {
            get
            {
                return PickableRenderer.RotationAngle;
            }
            set
            {
                Highlighter.RotationAngle = value;
                PickableRenderer.RotationAngle = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override vec3 RotationAxis
        {
            get
            {
                return PickableRenderer.RotationAxis;
            }
            set
            {
                Highlighter.RotationAxis = value;
                PickableRenderer.RotationAxis = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override vec3 Scale
        {
            get
            {
                return PickableRenderer.Scale;
            }
            set
            {
                Highlighter.Scale = value;
                PickableRenderer.Scale = value;
            }
        }
    }
}