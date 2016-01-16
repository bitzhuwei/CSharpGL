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
using FormShaderDesigner1594Demos.Models;
using CSharpGL;

namespace FormShaderDesigner1594Demos.SceneElements
{
    public class XRayElement : SceneElementBase
    {
        ShaderProgram shaderProgram;

        #region VAO/VBO renderers

        VertexArrayObject vertexArrayObject;

        const string strin_Position = "in_Position";
        BufferRenderer positionBufferRenderer;

        const string strin_Color = "in_Color";
        BufferRenderer colorBufferRenderer;

        const string strin_Normal = "in_Normal";
        BufferRenderer normalBufferRenderer;

        IndexBufferRenderer indexBufferRenderer;

        #endregion

        #region uniforms


        const string strmodelMatrix = "modelMatrix";
        public mat4 modelMatrix;

        const string strviewMatrix = "viewMatrix";
        public mat4 viewMatrix;

        const string strprojectionMatrix = "projectionMatrix";
        public mat4 projectionMatrix;

        const string strEdgeFallOff = "edgefalloff";
        public float edgeFallOff = 1.0f;

        #endregion


        public PolygonModes polygonMode = PolygonModes.Filled;

        private int indexCount;

        private IModel model;

        public XRayElement(IModel model)
        {
            this.model = model;
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.XRayElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.XRayElement.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

        }

        protected void InitializeVAO()
        {
            IModel model = this.model;

            this.positionBufferRenderer = model.GetPositionBufferRenderer(strin_Position);
            this.colorBufferRenderer = model.GetColorBufferRenderer(strin_Color);
            this.normalBufferRenderer = model.GetNormalBufferRenderer(strin_Normal);
            this.indexBufferRenderer = model.GetIndexes() as IndexBufferRenderer;
            this.indexCount = this.indexBufferRenderer.ElementCount;
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
                    this.colorBufferRenderer, 
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
            program.SetUniform(strEdgeFallOff, this.edgeFallOff);

            int[] originalPolygonMode = new int[1];
            GL.GetInteger(GetTarget.PolygonMode, originalPolygonMode);

            GL.Enable(GL.GL_PRIMITIVE_RESTART);
            GL.PrimitiveRestartIndex(uint.MaxValue);
            GL.PolygonMode(PolygonModeFaces.FrontAndBack, this.polygonMode);
            this.vertexArrayObject.Render(e, this.shaderProgram);
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
            if (this.indexBufferRenderer.ElementCount > 0)
                this.indexBufferRenderer.ElementCount--;
        }

        public void IncreaseVertexCount()
        {
            if (this.indexBufferRenderer.ElementCount < this.indexCount)
                this.indexBufferRenderer.ElementCount++;
        }


    }

}
