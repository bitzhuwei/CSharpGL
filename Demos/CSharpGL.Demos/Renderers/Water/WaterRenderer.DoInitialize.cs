using System;
using System.Drawing;
using System.IO;

namespace CSharpGL.Demos
{
    internal partial class WaterRenderer
    {

        protected override void DoInitialize()
        {
            this.waterInnerRenderer.Initialize();
            this.backgroundRenderer.Initialize();
            this.textureRenderer.Initialize();
        }

    }
}