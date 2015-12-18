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
    /// <summary>
    /// 用多个Points进行VR渲染。
    /// </summary>
    public class DemoVolumeRendering05 : SceneElementBase, IMVP
    {
        VertexArrayObject vao;

        BufferRenderer positionBufferRenderer;
        BufferRenderer uvBufferRenderer;
        ZeroIndexBufferRenderer indexBufferRenderer;

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
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"VolumeRendering.DemoVolumeRendering05.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"VolumeRendering.DemoVolumeRendering05.frag");

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
        const int xFrameCount = 256;
        const int yFrameCount = 256;

        const float xLength = 1;
        const float yLength = 1;
        public float alphaThreshold = 0.05f;
        public void SetStartIndex(int value)
        {
            if (this.indexBufferRenderer == null) { return; }

            this.indexBufferRenderer.FirstVertex = value;           
        }

        public void SetVertexCount(int value)
        {
            if (this.indexBufferRenderer == null) { return; }

            this.indexBufferRenderer.VertexCount = value;
        }


        private unsafe void InitVertexBuffers()
        {
            {
                VR02PositionBuffer positionBuffer = new VR02PositionBuffer(strin_Position);
                positionBuffer.Alloc(xFrameCount * yFrameCount * zFrameCount);
                vec3* array = (vec3*)positionBuffer.FirstElement();
                int index = 0;
                for (int i = 0; i < xFrameCount; i++)
                {
                    for (int j = 0; j < yFrameCount; j++)
                    {
                        for (int k = 0; k < zFrameCount; k++)
                        {
                            array[index++] = new vec3(
                                (float)i / (float)xFrameCount - 0.5f,
                                (float)j / (float)yFrameCount - 0.5f,
                                ((float)k / (float)zFrameCount - 0.5f) * 109.0f / 256.0f
                                );
                        }
                    }
                }
                this.positionBufferRenderer = positionBuffer.GetRenderer();
                positionBuffer.Dispose();
            }

            {
                VR02UVBuffer uvBuffer = new VR02UVBuffer(strin_uv);
                uvBuffer.Alloc(xFrameCount * yFrameCount * zFrameCount);
                vec3* array = (vec3*)uvBuffer.FirstElement();
                int index = 0;
                for (int i = 0; i < xFrameCount; i++)
                {
                    for (int j = 0; j < yFrameCount; j++)
                    {
                        for (int k = 0; k < zFrameCount; k++)
                        {
                            array[index++] = new vec3(
                                (float)i / (float)xFrameCount,
                                (float)j / (float)yFrameCount,
                                (float)k / (float)zFrameCount
                                );
                        }
                    }
                }
                this.uvBufferRenderer = uvBuffer.GetRenderer();
                uvBuffer.Dispose();
            }
            {
                var indexBuffer = new ZeroIndexBuffer(DrawMode.Points, 0, xFrameCount * yFrameCount * zFrameCount);
                indexBuffer.Alloc(xFrameCount * yFrameCount * zFrameCount);// this actually does nothing.
                this.indexBufferRenderer = indexBuffer.GetRenderer() as ZeroIndexBufferRenderer;
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
            if (this.vao.ID == 0)
            {
                this.vao.Create(e, this.shaderProgram);
            }

            this.vao.Render(e, this.shaderProgram);

        }

        public BlendingSourceFactor sFactor = BlendingSourceFactor.SourceAlpha;
        public BlendingDestinationFactor dFactor = BlendingDestinationFactor.OneMinusSourceAlpha;
        public bool blend = true;

        void IMVP.SetShaderProgram(mat4 mvp)
        {
            //this.tex.Bind();
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

        protected override void CleanUnmanagedRes()
        {
            this.vao.Dispose();

            base.CleanUnmanagedRes();
        }
    }
}
