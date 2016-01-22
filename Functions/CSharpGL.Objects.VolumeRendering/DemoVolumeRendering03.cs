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
    /// 用多个六面体进行VR渲染。
    /// </summary>
    public class DemoVolumeRendering03 : RendererBase
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
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"DemoVolumeRendering03.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"DemoVolumeRendering03.frag");

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

        const int downSizing = 3;
        const int zFrameCount = 109 / downSizing;
        const int xFrameCount = 256 / downSizing;
        const int yFrameCount = 256 / downSizing;

        const float hexahedronHalfLength = factor * 3.0f / 255.0f;
        const float factor = 256;

        const float xLength = 1;
        const float yLength = 1;

        public float alphaThreshold = 0.05f;
        private unsafe void InitVertexBuffers()
        {
            // http://images.cnblogs.com/cnblogs_com/bitzhuwei/482613/o_Cube-small.jpg
            {
                VR03PositionBuffer positionBuffer = new VR03PositionBuffer(strin_Position);
                positionBuffer.Alloc(xFrameCount * yFrameCount * zFrameCount);
                HexahedronPosition* array = (HexahedronPosition*)positionBuffer.FirstElement();
                int index = 0;
                for (int i = 0; i < xFrameCount; i++)
                {
                    for (int j = 0; j < yFrameCount; j++)
                    {
                        for (int k = 0; k < zFrameCount; k++)
                        {
                            var x = ((float)i / (float)xFrameCount - 0.5f) * factor;
                            var y = ((float)j / (float)yFrameCount - 0.5f) * factor;
                            var z = (((float)k / (float)zFrameCount - 0.5f) * 109.0f / 256.0f) * factor;
                            var hexahedron = new HexahedronPosition();
                            hexahedron.v0 = new vec3(x + hexahedronHalfLength, y + hexahedronHalfLength, z + hexahedronHalfLength);
                            hexahedron.v1 = new vec3(x - hexahedronHalfLength, y + hexahedronHalfLength, z + hexahedronHalfLength);
                            hexahedron.v2 = new vec3(x + hexahedronHalfLength, y - hexahedronHalfLength, z + hexahedronHalfLength);
                            hexahedron.v3 = new vec3(x - hexahedronHalfLength, y - hexahedronHalfLength, z + hexahedronHalfLength);
                            hexahedron.v4 = new vec3(x + hexahedronHalfLength, y + hexahedronHalfLength, z - hexahedronHalfLength);
                            hexahedron.v5 = new vec3(x - hexahedronHalfLength, y + hexahedronHalfLength, z - hexahedronHalfLength);
                            hexahedron.v6 = new vec3(x + hexahedronHalfLength, y - hexahedronHalfLength, z - hexahedronHalfLength);
                            hexahedron.v7 = new vec3(x - hexahedronHalfLength, y - hexahedronHalfLength, z - hexahedronHalfLength);
                            array[index++] = hexahedron;
                        }
                    }
                }
                this.positionBufferRenderer = positionBuffer.GetRenderer();
                positionBuffer.Dispose();
            }

            {
                VR03UVBuffer uvBuffer = new VR03UVBuffer(strin_uv);
                uvBuffer.Alloc(xFrameCount * yFrameCount * zFrameCount);
                HexahedronUV* array = (HexahedronUV*)uvBuffer.FirstElement();
                int index = 0;
                for (int i = 0; i < xFrameCount; i++)
                {
                    for (int j = 0; j < yFrameCount; j++)
                    {
                        for (int k = 0; k < zFrameCount; k++)
                        {
                            var x = (float)i / (float)xFrameCount;
                            var y = (float)j / (float)yFrameCount;
                            var z = (float)k / (float)zFrameCount;
                            var color = new vec3(x, y, z);
                            var uv = new HexahedronUV();
                            uv.v0 = color;
                            uv.v1 = color;
                            uv.v2 = color;
                            uv.v3 = color;
                            uv.v4 = color;
                            uv.v5 = color;
                            uv.v6 = color;
                            uv.v7 = color;
                            array[index++] = uv;
                        }
                    }
                }
                this.uvBufferRenderer = uvBuffer.GetRenderer();
                uvBuffer.Dispose();
            }
            {
                var indexBuffer = new VR03IndexBuffer();
                indexBuffer.Alloc(xFrameCount * yFrameCount * zFrameCount);
                HexahedronIndex* array = (HexahedronIndex*)indexBuffer.FirstElement();
                int index = 0;
                for (int i = 0; i < xFrameCount; i++)
                {
                    for (int j = 0; j < yFrameCount; j++)
                    {
                        for (int k = 0; k < zFrameCount; k++)
                        {
                            uint centerIndex = (uint)((i * yFrameCount * zFrameCount + j * zFrameCount + k) * 8);
                            array[index++] = new HexahedronIndex(centerIndex);
                        }
                    }
                }
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
            //this.tex.Bind();
            //GL.CullFace(GL.GL_FRONT_AND_BACK);
            //GL.PolygonMode(PolygonModeFaces.FrontAndBack, PolygonModes.Filled);

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

            GL.Enable(GL.GL_PRIMITIVE_RESTART);
            GL.PrimitiveRestartIndex(uint.MaxValue);
            if (this.vao.ID == 0)
            {
                this.vao.Create(e, this.shaderProgram);
            }
            else
            {
                this.vao.Render(e, this.shaderProgram);
            }
            GL.Disable(GL.GL_PRIMITIVE_RESTART);

            //this.tex.Unbind();
            this.shaderProgram.Unbind();
            GL.BindTexture(GL.GL_TEXTURE_3D, 0);

            if (blend)
            {
                GL.Disable(GL.GL_BLEND);
            }
            GL.Disable(GL.GL_ALPHA_TEST);
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
