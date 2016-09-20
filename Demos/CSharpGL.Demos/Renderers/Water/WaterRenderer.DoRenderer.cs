namespace CSharpGL.Demos
{
    internal partial class WaterRenderer
    {
        protected override void DoRender(RenderEventArgs arg)
        {
            this.waterPlaneRenderer.Render(arg);
            this.backgroundRenderer.Render(arg);
            this.textureRenderer.Render(arg);
        }
    }
}