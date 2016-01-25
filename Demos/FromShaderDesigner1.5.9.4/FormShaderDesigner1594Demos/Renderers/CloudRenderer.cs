using CSharpGL;
using CSharpGL.Objects;
using CSharpGL.Objects.Models;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.VertexBuffers;
using CSharpGL.Objects.VolumeRendering;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormShaderDesigner1594Demos.Renderers
{
    public class CloudRenderer : ShaderDesignerRendererBase
    {
        ShaderProgram shaderProgram;

        #region VAO/VBO renderers

        VertexArrayObject vertexArrayObject;

        const string strin_Position = "in_Position";
        BufferRenderer positionBufferRenderer;

        //const string strin_Color = "in_Color";
        //BufferRenderer colorBufferRenderer;

        const string strin_Normal = "in_Normal";
        BufferRenderer normalBufferRenderer;

        #endregion

        #region uniforms

        const string strLightPos = "LightPos";
        public vec3 LightPos = new vec3(0, 4, 4);

        const string strScale = "Scale";
        public float Scale = 0.759f;

        const string strTimeFromInit = "TIME_FROM_INIT";
        public float TIME_FROM_INIT;

        const string strNoise = "Noise";
        private uint NoiseTextureID;

        //vec3 Offset = vec3(0,0,0);

        const string strSkyColor = "SkyColor";
        public vec3 SkyColor = new vec3(0.0f, 0.0f, 0.8f);

        const string strCloudColor = "CloudColor";
        public vec3 CloudColor = new vec3(0.8f, 0.8f, 0.8f);

        #endregion


        private IModel model;
        private static CRawDataProcessor texture3D;

        public CloudRenderer(IModel model)
        {
            this.model = model;
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"Renderers.Cloud.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"Renderers.Cloud.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);
        }

        protected void InitializeVAO()
        {
            IModel model = this.model;

            this.positionBufferRenderer = model.GetPositionBufferRenderer(strin_Position);
            //this.colorBufferRenderer = model.GetColorBufferRenderer(strin_Color);
            this.normalBufferRenderer = model.GetNormalBufferRenderer(strin_Normal);
            this.indexBufferRenderer = model.GetIndexes();

            {
                IndexBufferRenderer renderer = this.indexBufferRenderer as IndexBufferRenderer;
                if (renderer != null)
                {
                    this.indexCount = renderer.ElementCount;
                }
            }
            {
                ZeroIndexBufferRenderer renderer = this.indexBufferRenderer as ZeroIndexBufferRenderer;
                if (renderer != null)
                {
                    this.indexCount = renderer.VertexCount;
                }
            }
        }

        protected override void DoInitialize()
        {
            InitNoiseTexture();

            InitializeShader(out shaderProgram);

            InitializeVAO();
        }

        private void InitNoiseTexture()
        {
            if (texture3D == null)
            {
                texture3D = new CRawDataProcessor();
                texture3D.ReadFile("head256x256x109", 256, 256, 109);
            }

            this.NoiseTextureID = texture3D.GetTexture3D();
        }

        protected override void DoRender(RenderEventArgs e)
        {
            GL.BindTexture(GL.GL_TEXTURE_3D, this.NoiseTextureID);

            ShaderProgram program = this.shaderProgram;
            // 绑定shader
            program.Bind();

            program.SetUniformMatrix4(strprojectionMatrix, projectionMatrix.to_array());
            program.SetUniformMatrix4(strviewMatrix, viewMatrix.to_array());
            program.SetUniformMatrix4(strmodelMatrix, modelMatrix.to_array());
            program.SetUniform(strLightPos, LightPos.x, LightPos.y, LightPos.z);
            program.SetUniform(strScale, this.Scale);
            program.SetUniform(strTimeFromInit, this.TIME_FROM_INIT);
            this.TIME_FROM_INIT += 0.0001f;
            program.SetUniform(strNoise, this.NoiseTextureID);
            program.SetUniform(strSkyColor, this.SkyColor.x, SkyColor.y, SkyColor.z);
            program.SetUniform(strCloudColor, CloudColor.x, CloudColor.y, CloudColor.z);

            int[] originalPolygonMode = new int[1];
            GL.GetInteger(GetTarget.PolygonMode, originalPolygonMode);

            GL.PolygonMode(PolygonModeFaces.FrontAndBack, this.polygonMode);

            if (this.vertexArrayObject == null)
            {
                var vertexArrayObject = new VertexArrayObject(
                    this.positionBufferRenderer,
                    //this.colorBufferRenderer,
                    this.normalBufferRenderer,
                    this.indexBufferRenderer);
                vertexArrayObject.Create(e, this.shaderProgram);

                this.vertexArrayObject = vertexArrayObject;
            }
            else
            {
                this.vertexArrayObject.Render(e, this.shaderProgram);
            }

            GL.PolygonMode(PolygonModeFaces.FrontAndBack, (PolygonModes)(originalPolygonMode[0]));

            // 解绑shader
            program.Unbind();

            GL.BindTexture(GL.GL_TEXTURE_3D, 0);

        }



        protected override void DisposeUnmanagedResources()
        {
            if (this.vertexArrayObject != null)
            {
                this.vertexArrayObject.Dispose();
            }

        }

    }
}
