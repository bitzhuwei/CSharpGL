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

namespace FormShaderDesigner1594Demos.SceneElements
{
    public class ToonElement : SceneElementBase
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

        const string strDiffuseColor = "DiffuseColor";
        public vec3 DiffuseColor = new vec3(0, 0.25f, 1);

        const string strPhongColor = "PhongColor";
        public vec3 PhongColor = new vec3(0.75f, 0.75f, 1);

        const string strEdge = "Edge";
        public float Edge = 0.64f;

        const string strPhong = "Phong";
        public float Phong = 0.954f;

        #endregion


        public PolygonModes polygonMode = PolygonModes.Filled;

        private int indexCount;

        private IModel model;

        public ToonElement(IModel model)
        {
            this.model = model;
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.ToonElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.ToonElement.frag");

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
