using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{
    partial class SimplexNoiseRenderer
    {


        protected override void DoInitialize()
        {
            base.DoInitialize();

            lastTime = DateTime.Now;

            var texture = new sampler2D();
            var bitmap = new Bitmap(@"13SimplexNoise\sunColor.jpg");
            texture.Initialize(bitmap);
            bitmap.Dispose();
            this.SetUniform("sunColor", new samplerValue(BindTextureTarget.Texture2D,
                texture.Id, OpenGL.GL_TEXTURE0));
        }

    }
}
