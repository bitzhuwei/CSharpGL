namespace CSharpGL.Demos
{
    /// <summary>
    /// Raycast Volume Rendering Demo.
    /// </summary>
    [DemoRenderer]
    partial class RaycastVolumeRenderer : RendererBase
    {
        private Renderer backfaceRenderer;
        private Renderer raycastRenderer;
        private Texture transferFunc1DTexture;
        private Texture backface2DTexture;
        private Texture volume3DTexture;
        private Framebuffer framebuffer;

        private static readonly IBufferable model = new RaycastModel();
        private float g_stepSize = 0.001f;

        public void SetMVP(mat4 mvp)
        {
            this.backfaceRenderer.SetUniform("MVP", mvp);
            this.raycastRenderer.SetUniform("MVP", mvp);
        }

        protected override void DisposeUnmanagedResources()
        {
            this.backfaceRenderer.Dispose();
            this.raycastRenderer.Dispose();
            this.transferFunc1DTexture.Dispose();
            this.backface2DTexture.Dispose();
            this.volume3DTexture.Dispose();
            this.framebuffer.Dispose();
        }
    }
}