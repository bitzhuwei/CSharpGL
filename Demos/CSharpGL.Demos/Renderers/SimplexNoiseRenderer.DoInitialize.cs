using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;


namespace CSharpGL.Demos
{
    partial class SimplexNoiseRenderer
    {


        protected override void DoInitialize()
        {
            base.DoInitialize();

            lastTime = DateTime.Now;

            var bitmap = new Bitmap(@"Textures\sunColor.png");
            var texture = new Texture(BindTextureTarget.Texture1D, bitmap, new SamplerParameters());
            texture.Initialize();
            bitmap.Dispose();
            this.SetUniform("sunColor", texture.ToSamplerValue());
        }

    }
}
