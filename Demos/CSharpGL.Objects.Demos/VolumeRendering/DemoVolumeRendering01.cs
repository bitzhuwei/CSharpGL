using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Demos.VolumeRendering
{
    public class DemoVolumeRendering01 : SceneElementBase
    {
        Shaders.ShaderProgram shaderProgram;
        private string textureFilename;
        uint textureID;

        public DemoVolumeRendering01(string textureFilename)
        {
            this.textureFilename = textureFilename;
        }

        protected override void DoInitialize()
        {
            InitShaderProgram();

            CRawDataProcessor processor = new CRawDataProcessor();
            processor.ReadFile(textureFilename, 256, 256, 109);
            this.textureID = processor.GetTexture3D();


        }

        private void InitShaderProgram()
        {
            throw new NotImplementedException();
        }

        float dOrthoSize = 1.0f;

        protected override void DoRender(RenderEventArgs e)
        {
            for (float fIndx = -1.0f; fIndx <= 1.0f; fIndx += 0.01f)
            {
                GL.Begin(GL.GL_QUADS);
                GL.TexCoord3f(0.0f, 0.0f, ((float)fIndx + 1.0f) / 2.0f);
                GL.Vertex3f(-dOrthoSize, -dOrthoSize, fIndx);
                GL.TexCoord3f(1.0f, 0.0f, ((float)fIndx + 1.0f) / 2.0f);
                GL.Vertex3f(dOrthoSize, -dOrthoSize, fIndx);
                GL.TexCoord3f(1.0f, 1.0f, ((float)fIndx + 1.0f) / 2.0f);
                GL.Vertex3f(dOrthoSize, dOrthoSize, fIndx);
                GL.TexCoord3f(0.0f, 1.0f, ((float)fIndx + 1.0f) / 2.0f);
                GL.Vertex3f(-dOrthoSize, dOrthoSize, fIndx);
                GL.End();
            }
         
        }

    }
}
