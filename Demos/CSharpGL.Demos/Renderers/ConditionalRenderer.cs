namespace CSharpGL.Demos
{
    /// <summary>
    /// demostrates how to perform conditional rendering.
    /// </summary>
    internal class ConditionalRenderer : RendererBase
    {
        private BoundingBoxRenderer boxRenderer;
        private RendererBase concreteRenderer;

        public static ConditionalRenderer Create()
        {
            const int xside = 5, yside = 5, zside = 5;

            throw new System.NotFiniteNumberException();
        }

        private ConditionalRenderer()
        { }

        protected override void DoInitialize()
        {
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
        }
    }
}