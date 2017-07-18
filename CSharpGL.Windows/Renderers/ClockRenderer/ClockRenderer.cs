namespace CSharpGL
{
    public class ClockRenderer : SceneNodeBase
    {
        private readonly ClockCircleRenderer circleRenderer = new ClockCircleRenderer();
        private readonly ClockMarkRenderer markRenderer = new ClockMarkRenderer();
        private readonly ClockPinRenderer pinRenderer = new ClockPinRenderer();

        public ClockRenderer()
        {
            this.Children.Add(new ClockCircleRenderer());
            this.Children.Add(new ClockMarkRenderer());
            this.Children.Add(new ClockPinRenderer());
        }
    }
}