namespace CSharpGL
{
    public class ClockNode : SceneNodeBase
    {
        public ClockNode()
        {
            this.Children.Add(new ClockCircleNode());
            this.Children.Add(new ClockMarkNode());
            this.Children.Add(new ClockPinNode());
        }
    }
}