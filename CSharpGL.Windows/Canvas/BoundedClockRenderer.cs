namespace CSharpGL
{
    /// <summary>
    /// </summary>
    internal class BoundedClockRenderer : RendererBase
    {
        public BoundedClockRenderer()
        {
            const float factor = 1.4f;
            var boxRenderer = new LegacyBoundingBoxRenderer();
            boxRenderer.Scale = new vec3(factor, factor, factor);
            this.Children.Add(boxRenderer);
            this.Children.Add(new ClockRenderer(new vec3(1, 0.8f, 0)));
        }
    }
}