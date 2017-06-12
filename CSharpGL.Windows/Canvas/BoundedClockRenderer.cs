namespace CSharpGL
{
    /// <summary>
    /// </summary>
    internal class BoundedClockRenderer : SceneElementBase
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

        protected override void DoRender(RenderEventArgs arg)
        {
            this.BoxRenderer.Render(arg);
            this.ClockRenderer.Render(arg);
        }

        public override uint PickingBaseId { get; set; }

        public override void RenderForPicking(PickEventArgs arg)
        {
        }

        public override uint GetVertexCount()
        {
            return 0;
        }

        public override PickedGeometry GetPickedGeometry(PickEventArgs arg, uint stageVertexId, int x, int y)
        {
            return null;
        }
    }
}