namespace CSharpGL.Demos
{
    internal class ImageProcessingRenderer : RendererBase
    {
        private InnerImageProcessingRenderer innerRenderer;
        private ImageProcessingComputeRenderer computeRenderer;

        public ImageProcessingRenderer(string textureFilename = @"Textures\edgeDetection.bmp")
        {
            this.innerRenderer = InnerImageProcessingRenderer.Create(textureFilename);
            this.computeRenderer = ImageProcessingComputeRenderer.Create(this.innerRenderer);
        }

        protected override void DoInitialize()
        {
            this.innerRenderer.Initialize();
            this.computeRenderer.Initialize();
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.computeRenderer.Render(arg);
            this.innerRenderer.Render(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
            this.computeRenderer.Dispose();
            this.innerRenderer.Dispose();
        }

        public void SwitchDisplayImage(bool forward)
        {
            this.innerRenderer.SwitchDisplayImage(forward);
        }
    }
}