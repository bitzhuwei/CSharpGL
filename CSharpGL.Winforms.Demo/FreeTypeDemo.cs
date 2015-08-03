using CSharpGL.Objects.Texts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Winforms.Demo
{
    class FreeTypeDemo
    {
        float cnt1;
        private LegacyMultiTextureFont largeFont;
        public FreeTypeDemo()
        {
            //largeFont = new Font3D("LuckiestGuy.ttf", 48);
            largeFont = new LegacyMultiTextureFont("ebrima.ttf", 48);

        }

        public void render()
        {

            //Clear display
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            //Rotate something about
            GL.Color3ub(0xff, 0, 0);
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.Rotatef(cnt1, 0, 0, 1);
            GL.Scalef(1f, (float).8f + .3f * (float)Math.Cos((double)cnt1 / 5), 1);
            GL.Translatef(-180, 0, 0);
            largeFont.print(320, 240, "hello FREE-TYPE / 2");
            GL.PopMatrix();
            cnt1 += 0.051f;
        }
    }
}
