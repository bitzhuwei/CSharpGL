namespace CSharpGL
{
    internal class ClockRenderer : RendererBase
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

            this.Children.Add(new ClockCircleRenderer());
            this.Children.Add(new ClockMarkRenderer());
            this.Children.Add(new ClockPinRenderer());
        }
    }
}