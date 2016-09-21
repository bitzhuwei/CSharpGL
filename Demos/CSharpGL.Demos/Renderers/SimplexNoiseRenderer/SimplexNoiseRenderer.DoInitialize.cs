using System;
using System.Drawing;

namespace CSharpGL.Demos
{
    partial class SimplexNoiseRenderer
    {
        protected override void DoInitialize()
        {
            base.DoInitialize();

            lastTime = DateTime.Now;

            var bitmap = new Bitmap(@"Textures\sunColor.png");
            var texture = new Texture(TextureTarget.Texture1D, bitmap, new SamplerParameters());
            texture.Initialize();
            bitmap.Dispose();
            this.SetUniform("sunColor", texture.ToSamplerValue());
        }
    }
}