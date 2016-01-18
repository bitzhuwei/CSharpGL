using CSharpGL;
using CSharpGL.Objects;
using CSharpGL.Objects.Models;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.VertexBuffers;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormShaderDesigner1594Demos.SceneElements
{
    class Polkadot3dElement : SceneElementBase
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

        BufferRenderer indexBufferRenderer;

        #endregion

        #region uniforms

        const string strmodelMatrix = "modelMatrix";
        public mat4 modelMatrix;

        const string strviewMatrix = "viewMatrix";
        public mat4 viewMatrix;

        const string strprojectionMatrix = "projectionMatrix";
        public mat4 projectionMatrix;

        const string strSpecularContribution = "SpecularContribution";
        public float SpecularContribution = 0.36f;

        const string strLightPosition = "LightPosition";
        public vec3 LightPosition = new vec3(0, 4, 5);

        const string strSpacing = "Spacing";
        public vec3 Spacing = new vec3(0.314f, 0.36f, 0.261f);

        const string strDotSize = "DotSize";
        public float DotSize = 0.123f;

        const string strModelColor = "ModelColor";
        public vec3 ModelColor = new vec3(0.75f, 0.2f, 0.1f);

        const string strPolkaDotColor = "PolkaDotColor";
        public vec3 PolkaDotColor = new vec3(1, 1, 1);

        #endregion


        public PolygonModes polygonMode = PolygonModes.Filled;

        private int indexCount;

        private IModel model;

        public Polkadot3dElement(IModel model)
        {
            this.model = model;
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.Polkadot3dElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.Polkadot3dElement.frag");

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

            IndexBufferRenderer renderer = this.indexBufferRenderer as IndexBufferRenderer;
            if (renderer != null)
            {
                this.indexCount = renderer.ElementCount;
            }
        }

        protected override void DoInitialize()
        {
            InitializeShader(out shaderProgram);

            InitializeVAO();
        }

        protected override void DoRender(RenderEventArgs e)
        {
            if (this.vertexArrayObject == null)
            {
                var vao = new VertexArrayObject(
                    this.positionBufferRenderer,
                    //this.colorBufferRenderer,
                    this.normalBufferRenderer,
                    this.indexBufferRenderer);
                vao.Create(e, this.shaderProgram);

                this.vertexArrayObject = vao;
            }

            ShaderProgram program = this.shaderProgram;
            // 绑定shader
            program.Bind();

            program.SetUniformMatrix4(strprojectionMatrix, projectionMatrix.to_array());
            program.SetUniformMatrix4(strviewMatrix, viewMatrix.to_array());
            program.SetUniformMatrix4(strmodelMatrix, modelMatrix.to_array());
            program.SetUniform(strSpecularContribution, SpecularContribution);
            program.SetUniform(strLightPosition, LightPosition.x, LightPosition.y, LightPosition.z);
            program.SetUniform(strSpacing, Spacing.x, Spacing.y, Spacing.z);
            program.SetUniform(strDotSize, DotSize);
            program.SetUniform(strModelColor, ModelColor.x, ModelColor.y, ModelColor.z);
            program.SetUniform(strPolkaDotColor, PolkaDotColor.x, PolkaDotColor.y, PolkaDotColor.z);

            int[] originalPolygonMode = new int[1];
            GL.GetInteger(GetTarget.PolygonMode, originalPolygonMode);

            GL.Enable(GL.GL_PRIMITIVE_RESTART);
            GL.PrimitiveRestartIndex(uint.MaxValue);
            GL.PolygonMode(PolygonModeFaces.FrontAndBack, this.polygonMode);
            GL.Enable(GL.GL_BLEND);
            GL.BlendFunc(CSharpGL.Enumerations.BlendingSourceFactor.SourceAlpha, CSharpGL.Enumerations.BlendingDestinationFactor.OneMinusSourceAlpha);
            this.vertexArrayObject.Render(e, this.shaderProgram);
            GL.Disable(GL.GL_BLEND);
            GL.PolygonMode(PolygonModeFaces.FrontAndBack, (PolygonModes)(originalPolygonMode[0]));
            GL.Disable(GL.GL_PRIMITIVE_RESTART);

            // 解绑shader
            program.Unbind();
        }



        protected override void CleanUnmanagedRes()
        {
            if (this.vertexArrayObject != null)
            {
                this.vertexArrayObject.Dispose();
            }

            base.CleanUnmanagedRes();
        }

        public void DecreaseVertexCount()
        {
            IndexBufferRenderer renderer = this.indexBufferRenderer as IndexBufferRenderer;
            if (renderer != null)
            {
                if (renderer.ElementCount > 0)
                    renderer.ElementCount--;
            }
        }

        public void IncreaseVertexCount()
        {
            IndexBufferRenderer renderer = this.indexBufferRenderer as IndexBufferRenderer;
            if (renderer != null)
            {
                if (renderer.ElementCount < this.indexCount)
                    renderer.ElementCount++;
            }
        }
    }
}
