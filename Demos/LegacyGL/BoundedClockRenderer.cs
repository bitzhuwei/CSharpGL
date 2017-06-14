namespace CSharpGL
{
    /// <summary>
    /// </summary>
    internal class BoundedClockRenderer : RendererBase
    {
        public BoundedClockRenderer()
        {
            this.Children.Add(new LegacyBoundingBoxRenderer());
            this.Children.Add(new ClockRenderer(new vec3(1, 0.8f, 0)));
        }


        protected override void DoInitialize()
        {

        }
    }
}