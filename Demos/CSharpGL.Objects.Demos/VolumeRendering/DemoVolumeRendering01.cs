using CSharpGL.Enumerations;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.VertexBuffers;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Demos.VolumeRendering
{
    public class DemoVolumeRendering01 : SceneElementBase, IMVP
    {
        VertexArrayObject vao;

        BufferRenderer positionBufferRenderer;
        BufferRenderer uvBufferRenderer;
        BufferRenderer indexBufferRenderer;

        CRawDataProcessor textureProcessor = new CRawDataProcessor();

        /// <summary>
        /// shader program
        /// </summary>
        public ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_uv = "in_uv";
        public const string strMVP = "MVP";

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"VolumeRendering.DemoVolumeRendering01.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"VolumeRendering.DemoVolumeRendering01.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            shaderProgram.AssertValid();
        }

        protected override void DoInitialize()
        {
            InitializeShader(out shaderProgram);

            InitTexture();

            InitVertexBuffers();

            //base.BeforeRendering += IMVPHelper.Getelement_BeforeRendering();
            //base.AfterRendering += IMVPHelper.Getelement_AfterRendering();
        }

        const int zFrameCount = 109;
        const float xLength = 1;
        const float yLength = 1;
        public float alphaThreshold = 0.05f;

        private unsafe void InitVertexBuffers()
        {
            {
                VR01PositionBuffer positionBuffer = new VR01PositionBuffer(strin_Position);
                positionBuffer.Alloc(zFrameCount);
                QuadPosition* array = (QuadPosition*)positionBuffer.FirstElement();
                for (int i = 0; i < zFrameCount; i++)
                {
                    array[i] = new QuadPosition(
                        new vec3(-xLength, -yLength, (float)i / (float)zFrameCount - 0.5f),
                        new vec3(xLength, -yLength, (float)i / (float)zFrameCount - 0.5f),
                        new vec3(xLength, yLength, (float)i / (float)zFrameCount - 0.5f),
                        new vec3(-xLength, yLength, (float)i / (float)zFrameCount - 0.5f)
                        );
                }
                this.positionBufferRenderer = positionBuffer.GetRenderer();
                positionBuffer.Dispose();
            }

            {
                VR01UVBuffer uvBuffer = new VR01UVBuffer(strin_uv);
                uvBuffer.Alloc(zFrameCount);
                QuadUV* array = (QuadUV*)uvBuffer.FirstElement();
                for (int i = 0; i < zFrameCount; i++)
                {
                    array[i] = new QuadUV(
                        new vec3(0, 0, (float)i / (float)zFrameCount),
                        new vec3(1, 0, (float)i / (float)zFrameCount),
                        new vec3(1, 1, (float)i / (float)zFrameCount),
                        new vec3(0, 1, (float)i / (float)zFrameCount)
                        );
                }
                this.uvBufferRenderer = uvBuffer.GetRenderer();
                uvBuffer.Dispose();
            }
            {
                var indexBuffer = new ZeroIndexBuffer(DrawMode.Quads, zFrameCount * 4);
                indexBuffer.Alloc(zFrameCount);// this actually does nothing.
                this.indexBufferRenderer = indexBuffer.GetRenderer();
                indexBuffer.Dispose();
            }
        }

        private void InitTexture()
        {
            this.textureProcessor.ReadFile("head256x256x109", 256, 256, 109);
        }

        protected override void DoRender(RenderEventArgs e)
        {
            if (this.vao == null)
            {
                this.vao = new VertexArrayObject(this.positionBufferRenderer, this.uvBufferRenderer, this.indexBufferRenderer);
                this.vao.Create(e, this.shaderProgram);
            }
            
            this.vao.Render(e, this.shaderProgram);
          
        }

        public BlendingSourceFactor sFactor = BlendingSourceFactor.SourceAlpha;
        public BlendingDestinationFactor dFactor = BlendingDestinationFactor.OneMinusSourceAlpha;

        void IMVP.SetShaderProgram(mat4 mvp)
        {
            //this.tex.Bind();
            GL.CullFace(GL.GL_FRONT_AND_BACK);

            GL.Enable(GL.GL_ALPHA_TEST);
            GL.AlphaFunc(GL.GL_GREATER, alphaThreshold);

            GL.Enable(GL.GL_BLEND);
            GL.BlendFunc(sFactor, dFactor);

            uint textureID = this.textureProcessor.GetTexture3D();
            GL.BindTexture(GL.GL_TEXTURE_3D, textureID);

            this.shaderProgram.Bind();
            this.shaderProgram.SetUniform("tex", textureID);

            IMVPHelper.SetMVP(this, mvp);
        }


        void IMVP.ResetShaderProgram()
        {
            IMVPHelper.ResetMVP(this);

            //this.tex.Unbind();
            this.shaderProgram.Unbind();
            GL.BindTexture(GL.GL_TEXTURE_3D, 0);

            GL.Disable(GL.GL_BLEND);
            GL.Disable(GL.GL_ALPHA_TEST);
        }


        ShaderProgram IMVP.GetShaderProgram()
        {
            return this.shaderProgram;
        }

    }
}
