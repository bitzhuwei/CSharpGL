using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Demos
{
    public class DemoLegacyGLTexture3D : RendererBase
    {
        struct Texture3DElement
        {
            public byte s;
            public byte t;
            public byte r;
        }

        const int iWidth = 16;
        const int iHeight = 16;
        const int iDepth = 16;
        //static byte[, , ,] image = new byte[iDepth, iHeight, iWidth, 3];
        static UnmanagedArray<Texture3DElement> image;
        uint[] texName;
        private double angle;

        static DemoLegacyGLTexture3D()
        {
            image = new UnmanagedArray<Texture3DElement>(iDepth * iHeight * iWidth);
            int s, t, r;

            for (s = 0; s < 16; s++)
                for (t = 0; t < 16; t++)
                    for (r = 0; r < 16; r++)
                    {
                        image[r * 16 * 16 + t * 16 + s] =
                            new Texture3DElement() { s = (byte)(s * 17), t = (byte)(t * 17), r = (byte)(r * 17), };
                    }
        }

        public void Reshape(int width, int height)
        {
            GL.Viewport(0, 0, width, height);
            GL.MatrixMode(GL.GL_PROJECTION);
            GL.LoadIdentity();
            GL.gluPerspective(60.0, (float)width / (float)height, 1.0, 30.0);
            GL.MatrixMode(GL.GL_MODELVIEW);
            GL.LoadIdentity();
            GL.Translate(0.0, 0.0, -4.0);
        }

        protected override void DoInitialize()
        {
            GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);

            texName = new uint[1];
            GL.GenTextures(1, texName);
            GL.BindTexture(GL.GL_TEXTURE_3D, texName[0]);
            GL.TexParameteri(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP);
            GL.TexParameteri(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP);
            GL.TexParameteri(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_WRAP_R, (int)GL.GL_CLAMP);
            GL.TexParameteri(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_MAG_FILTER,
                            (int)GL.GL_NEAREST);
            GL.TexParameteri(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_MIN_FILTER,
                            (int)GL.GL_NEAREST);
            GL.TexImage3D(GL.GL_TEXTURE_3D, 0, (int)GL.GL_RGB, iWidth, iHeight,
                         iDepth, 0, GL.GL_RGB, GL.GL_UNSIGNED_BYTE, image.Header);
            GL.Enable(GL.GL_TEXTURE_3D);
        }

        protected override void DoRender(RenderEventArgs e)
        {
            int[] vieport = new int[4];
            GL.GetInteger(GetTarget.Viewport, vieport);
            Reshape(vieport[2], vieport[3]);

            GL.Rotate(angle, 0.0, 1.0, 0.0);
            angle += 1;
            GL.Begin(GL.GL_QUADS);
            GL.TexCoord(0.0, 0.0, 0.0); GL.Vertex(-2.25, -1.0, 0.0);
            GL.TexCoord(0.0, 1.0, 0.0); GL.Vertex(-2.25, 1.0, 0.0);
            GL.TexCoord(1.0, 1.0, 1.0); GL.Vertex(-0.25, 1.0, 0.0);
            GL.TexCoord(1.0, 0.0, 1.0); GL.Vertex(-0.25, -1.0, 0.0);

            GL.TexCoord(0.0, 0.0, 1.0); GL.Vertex(0.25, -1.0, 0.0);
            GL.TexCoord(0.0, 1.0, 1.0); GL.Vertex(0.25, 1.0, 0.0);
            GL.TexCoord(1.0, 1.0, 0.0); GL.Vertex(2.25, 1.0, 0.0);
            GL.TexCoord(1.0, 0.0, 0.0); GL.Vertex(2.25, -1.0, 0.0);
            GL.End();
        }
    }
}
