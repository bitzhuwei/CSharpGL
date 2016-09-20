using System;
using System.IO;

namespace CSharpGL.Demos
{
    internal partial class WaterRenderer : RendererBase
    {
        WaterInnerRenderer waterInnerRenderer;
        WaterBackgroundRenderer backgroundRenderer;
        WaterTextureRenderer textureRenderer;

        private WaterRenderer()
        {

        }

    }
}