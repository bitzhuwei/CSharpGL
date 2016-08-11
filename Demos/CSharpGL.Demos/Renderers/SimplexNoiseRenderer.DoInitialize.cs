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

            var texture = new Texture1D();
            var bitmap = new Bitmap(@"Textures\sunColor.png");
            texture.Initialize(bitmap);
            bitmap.Dispose();
            this.SetUniform("sunColor", new samplerValue(BindTextureTarget.Texture1D,
                texture.Id, OpenGL.GL_TEXTURE0));
        }

    }
}
