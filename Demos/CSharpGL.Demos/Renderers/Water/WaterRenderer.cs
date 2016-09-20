using System;
using System.IO;

namespace CSharpGL.Demos
{
    internal partial class WaterRenderer : RendererBase
    {
        WaterInnerRenderer waterInnerRenderer;
        WaterBackgroundRenderer backgroundRenderer;
        WaterTextureRenderer textureRenderer;

        private WaterRenderer(int sideLength)
        {
            this.waterInnerRenderer = WaterInnerRenderer.Create(sideLength);
            this.backgroundRenderer = WaterBackgroundRenderer.Create(sideLength);
            this.textureRenderer = WaterTextureRenderer.Create(sideLength);
        }

    }
}