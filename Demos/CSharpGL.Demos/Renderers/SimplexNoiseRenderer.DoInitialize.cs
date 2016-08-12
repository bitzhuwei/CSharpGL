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

            var sampler = new Sampler();
            var bitmap = new Bitmap(@"Textures\sunColor.png");
            var texture = new Texture(bitmap, sampler) { Target = BindTextureTarget.Texture1D, };
            texture.Initialize();
            bitmap.Dispose();
            this.SetUniform("sunColor", new samplerValue(BindTextureTarget.Texture1D,
                texture.Id, OpenGL.GL_TEXTURE0));
        }

    }
}
