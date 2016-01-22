using CSharpGL.Enumerations;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.VertexBuffers;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.VolumeRendering
{
    /// <summary>
    /// 用多个Quad进行VR渲染。
    /// </summary>
    public class DemoVolumeRendering01 : RendererBase
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
        const string strMVP = "MVP";
        public mat4 mvp;

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"DemoVolumeRendering01.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"DemoVolumeRendering01.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

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
                var indexBuffer = new ZeroIndexBuffer(DrawMode.Quads, 0, zFrameCount * 4);
                indexBuffer.Alloc(zFrameCount);// this actually does nothing.
                this.indexBufferRenderer = indexBuffer.GetRenderer();
                indexBuffer.Dispose();
            }
            this.vao = new VertexArrayObject(this.positionBufferRenderer, this.uvBufferRenderer, this.indexBufferRenderer);
        }

        private void InitTexture()
        {
            this.textureProcessor.ReadFile("head256x256x109", 256, 256, 109);
        }

        protected override void DoRender(RenderEventArgs e)
        {
            
            GL.CullFace(GL.GL_FRONT_AND_BACK);
            GL.PolygonMode(PolygonModeFaces.FrontAndBack, PolygonModes.Filled);

            GL.Enable(GL.GL_ALPHA_TEST);
            GL.AlphaFunc(GL.GL_GREATER, alphaThreshold);

            bool blend = this.blend;
            if (blend)
            {
                GL.Enable(GL.GL_BLEND);
                GL.BlendFunc(sFactor, dFactor);
            }

            uint textureID = this.textureProcessor.GetTexture3D();
            GL.BindTexture(GL.GL_TEXTURE_3D, textureID);

            this.shaderProgram.Bind();
            this.shaderProgram.SetUniform("tex", textureID);
            this.shaderProgram.SetUniformMatrix4(strMVP, mvp.to_array());
            if (this.vao.ID == 0)
            {
                this.vao.Create(e, this.shaderProgram);
            }
            else
            {
                this.vao.Render(e, this.shaderProgram);
            }

            this.shaderProgram.Unbind();
            GL.BindTexture(GL.GL_TEXTURE_3D, 0);

            if (blend)
            {
                GL.Disable(GL.GL_BLEND);
                GL.Disable(GL.GL_ALPHA_TEST);
            }
        }

        public BlendingSourceFactor sFactor = BlendingSourceFactor.SourceAlpha;
        public BlendingDestinationFactor dFactor = BlendingDestinationFactor.OneMinusSourceAlpha;
        public bool blend = true;

        protected override void CleanUnmanagedRes()
        {
            this.vao.Dispose();

            base.CleanUnmanagedRes();
        }
    }
}
