using System;
using System.IO;

namespace CSharpGL.Demos
{
    internal partial class WaterRenderer : RendererBase
    {
        WaterPlaneRenderer waterPlaneRenderer;
        WaterBackgroundRenderer backgroundRenderer;
        WaterTextureRenderer textureRenderer;

        private WaterRenderer(int sideLength)
        {
            this.waterPlaneRenderer = WaterPlaneRenderer.Create(sideLength);
            this.backgroundRenderer = WaterBackgroundRenderer.Create(sideLength);
            this.textureRenderer = WaterTextureRenderer.Create(sideLength);
        }

    }
}