using GLM;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGL.Objects.VertexBuffers;
using CSharpGL.Objects.Models;
using CSharpGL;

namespace FormShaderDesigner1594Demos.Renderers
{
    public class ToonRenderer : ShaderDesignerRendererBase
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

        const string strDiffuseColor = "DiffuseColor";
        public vec3 DiffuseColor = new vec3(0, 0.25f, 1);

        const string strPhongColor = "PhongColor";
        public vec3 PhongColor = new vec3(0.75f, 0.75f, 1);

        const string strEdge = "Edge";
        public float Edge = 0.64f;

        const string strPhong = "Phong";
        public float Phong = 0.954f;

        #endregion

        private IModel model;

        public ToonRenderer(IModel model)
        {
            this.model = model;
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"Renderers.Toon.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"Renderers.Toon.frag");

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
            
            ShaderProgram program = this.shaderProgram;
            // 绑定shader
            program.Bind();

            program.SetUniformMatrix4(strprojectionMatrix, projectionMatrix.to_array());
            program.SetUniformMatrix4(strviewMatrix, viewMatrix.to_array());
            program.SetUniformMatrix4(strmodelMatrix, modelMatrix.to_array());
            program.SetUniform(strDiffuseColor, this.DiffuseColor.x, this.DiffuseColor.y, this.DiffuseColor.z);
            program.SetUniform(strPhongColor, this.PhongColor.x, this.PhongColor.y, this.PhongColor.z);
            program.SetUniform(strEdge, this.Edge);
            program.SetUniform(strPhong, this.Phong);

            int[] originalPolygonMode = new int[1];
            GL.GetInteger(GetTarget.PolygonMode, originalPolygonMode);

            GL.Enable(GL.GL_PRIMITIVE_RESTART);
            GL.PrimitiveRestartIndex(uint.MaxValue);
            GL.PolygonMode(PolygonModeFaces.FrontAndBack, this.polygonMode);
            GL.Enable(GL.GL_BLEND);
            GL.BlendFunc(CSharpGL.Enumerations.BlendingSourceFactor.SourceAlpha, CSharpGL.Enumerations.BlendingDestinationFactor.OneMinusSourceAlpha);
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
            else
            {
                this.vertexArrayObject.Render(e, this.shaderProgram);
            }
            GL.Disable(GL.GL_BLEND);
            GL.PolygonMode(PolygonModeFaces.FrontAndBack, (PolygonModes)(originalPolygonMode[0]));
            GL.Disable(GL.GL_PRIMITIVE_RESTART);

            // 解绑shader
            program.Unbind();
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
