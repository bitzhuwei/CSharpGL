using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Demos
{
    /// <summary>
    /// 演示Texture3D的用法和效果。
    /// </summary>
    public class DemoLegacyTexture3DCubeElement : SceneElementBase
    {
        private uint[] textureName = new uint[1];
        public float positiveX, negativeX;
        public float positiveY, negativeY;
        public float positiveZ, negativeZ;
        public float positiveTexX, negativeTexX;
        public float positiveTexY, negativeTexY;
        public float positiveTexZ, negativeTexZ;

        protected override void DoInitialize()
        {
            InitTexture3D();

            InitModel();
        }

        private void InitModel()
        {
            this.positiveX = 1; this.negativeX = -1;
            this.positiveY = 1; this.negativeY = -1;
            this.positiveZ = 1; this.negativeZ = -1;
            this.positiveTexX = 1; this.negativeTexX = 0;
            this.positiveTexY = 1; this.negativeTexY = 0;
            this.positiveTexZ = 1; this.negativeTexZ = 0;
        }

        Random random = new Random();

        private void InitTexture3D()
        {
            int xSize = 16;
            int ySize = 16;
            int zSize = 16;

            int minSize = Math.Min(xSize, Math.Min(ySize, zSize));

            using (var data = new UnmanagedArray<float>(xSize * ySize * zSize))
            {
                int index=0;
                for (int i = 0; i < xSize; i++)
                {
                    for (int j = 0; j < ySize; j++)
                    {
                        for (int k = 0; k < zSize; k++)
                        {
                            //data[index++] = new vec3((float)i / xSize, (float)j / ySize, (float)k / zSize);
                            //data[index++] = new vec3((float)i / xSize, (float)j / ySize, (float)k / zSize);
                            data[index++] = (float)random.NextDouble();
                        }
                    }
                }

                GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);

                GL.GenTextures(1, this.textureName);

                GL.ActiveTexture(GL.GL_TEXTURE0);

                GL.BindTexture(GL.GL_TEXTURE_3D, this.textureName[0]);

                GL.TexParameteri(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_BASE_LEVEL, 0);
                GL.TexParameterf(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_MAX_LEVEL, (float)Math.Log(minSize, 2));
                GL.TexParameterf(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_MIN_FILTER, GL.GL_LINEAR_MIPMAP_LINEAR);
                GL.TexParameterf(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_MAG_FILTER, GL.GL_LINEAR);
                GL.TexParameterf(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_WRAP_S, GL.GL_CLAMP_TO_EDGE);
                GL.TexParameterf(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_WRAP_T, GL.GL_CLAMP_TO_EDGE);
                GL.TexParameterf(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_WRAP_R, GL.GL_CLAMP_TO_EDGE);

                GL.TexImage3D(GL.GL_TEXTURE_3D,
                    0,
                    //(int)GL.GL_R32F,
                    (int)GL.GL_RGB,
                    xSize, ySize, zSize,
                    0,
                   GL.GL_RGB, GL.GL_FLOAT,
                    data.Header);

                GL.GenerateMipmapEXT(GL.GL_TEXTURE_3D);

                GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 4);
            }
        }

        protected override void DoRender(RenderEventArgs e)
        {
            GL.BindTexture(GL.GL_TEXTURE_3D, this.textureName[0]);
            GL.ActiveTexture(GL.GL_TEXTURE0);

            //GL.Color(1f, 1f, 1f, 1f);

            GL.Begin(PrimitiveModes.QuadStrip);
            {
                GL.Vertex(this.positiveX, this.positiveY, this.positiveZ);
                GL.TexCoord3f(this.positiveTexX, this.positiveTexY, this.positiveTexZ);
                GL.Vertex(this.positiveX, this.positiveY, this.negativeZ);
                GL.TexCoord3f(this.positiveTexX, this.positiveTexY, this.negativeTexZ);
                GL.Vertex(this.negativeX, this.positiveY, this.positiveZ);
                GL.TexCoord3f(this.negativeTexX, this.positiveTexY, this.positiveTexZ);
                GL.Vertex(this.negativeX, this.positiveY, this.negativeZ);
                GL.TexCoord3f(this.negativeTexX, this.positiveTexY, this.negativeTexZ);
                GL.Vertex(this.negativeX, this.negativeY, this.positiveZ);
                GL.TexCoord3f(this.negativeTexX, this.negativeTexY, this.positiveTexZ);
                GL.Vertex(this.negativeX, this.negativeY, this.negativeZ);
                GL.TexCoord3f(this.negativeTexX, this.negativeTexY, this.negativeTexZ);
                GL.Vertex(this.positiveX, this.negativeY, this.positiveZ);
                GL.TexCoord3f(this.positiveTexX, this.negativeTexY, this.positiveTexZ);
                GL.Vertex(this.positiveX, this.negativeY, this.negativeZ);
                GL.TexCoord3f(this.positiveTexX, this.negativeTexY, this.negativeTexZ);
            }
            GL.End();

            GL.BindTexture(GL.GL_TEXTURE_3D, 0);
        }
    }
}
