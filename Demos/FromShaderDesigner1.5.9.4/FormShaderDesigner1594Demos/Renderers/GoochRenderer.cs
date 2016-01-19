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
    public class GoochRenderer : SceneElementBase
    {

        VertexArrayObject vertexArrayObject;
        BufferRenderer positionBufferRenderer;
        //BufferRenderer colorBufferRenderer;
        BufferRenderer normalBufferRenderer;
        BufferRenderer indexBufferRenderer;

        /// <summary>
        /// shader program
        /// </summary>
        private ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_Normal = "in_Normal";
        //const string strin_Color = "in_Color";
        const string strmodelMatrix = "modelMatrix";
        const string strviewMatrix = "viewMatrix";
        const string strprojectionMatrix = "projectionMatrix";

        const string strlightPosition = "lightPosition";
        public vec3 lightPosition = new vec3(0.0f, 10.0f, 4.0f);

        const string strSurfaceColor = "SurfaceColor";
        public vec3 surfaceColor = new vec3(0.75f, 0.75f, 0.75f);

        const string strWarmColor = "WarmColor";
        public vec3 warmColor = new vec3(0.6f, 0.6f, 0.0f);

        const string strCoolColor = "CoolColor";

        public vec3 coolColor = new vec3(0.0f, 0.0f, 0.6f);

        const string strDiffuseWarm = "DiffuseWarm";
        public float diffuseWarm = 0.45f;

        const string strDiffuseCool = "DiffuseCool";
        public float diffuseCool = 0.45f;

        public PolygonModes polygonMode = PolygonModes.Filled;

        private int indexCount;
        private IModel model;

        public GoochRenderer(IModel model)
        {
            this.model = model;
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"Renderer.GoochRenderer.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"Renderer.GoochRenderer.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

        }

        protected void InitializeVAO()
        {
            //IModel model = IceCreamModel.GetModel(1, 10, 10);
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
                    //colorBufferRenderer, 
                    this.normalBufferRenderer,
                    this.indexBufferRenderer);
                vao.Create(e, this.shaderProgram);

                this.vertexArrayObject = vao;
            }

            // 绑定shader
            this.shaderProgram.Bind();

            int[] originalPolygonMode = new int[1];
            GL.GetInteger(GetTarget.PolygonMode, originalPolygonMode);

            GL.Enable(GL.GL_PRIMITIVE_RESTART);
            GL.PrimitiveRestartIndex(uint.MaxValue);
            GL.PolygonMode(PolygonModeFaces.FrontAndBack, this.polygonMode);
            this.vertexArrayObject.Render(e, this.shaderProgram);
            GL.PolygonMode(PolygonModeFaces.FrontAndBack, (PolygonModes)(originalPolygonMode[0]));
            GL.Disable(GL.GL_PRIMITIVE_RESTART);

            // 解绑shader
            this.shaderProgram.Unbind();
        }



        protected override void CleanUnmanagedRes()
        {
            if (this.vertexArrayObject != null)
            {
                this.vertexArrayObject.Dispose();
            }

            base.CleanUnmanagedRes();
        }

        public void SetUniforms(mat4 projectionMatrix, mat4 viewMatrix, mat4 modelMatrix)
        {
            this.shaderProgram.Bind();
            this.shaderProgram.SetUniformMatrix4(strprojectionMatrix, projectionMatrix.to_array());
            this.shaderProgram.SetUniformMatrix4(strviewMatrix, viewMatrix.to_array());
            this.shaderProgram.SetUniformMatrix4(strmodelMatrix, modelMatrix.to_array());
            this.shaderProgram.SetUniform(strlightPosition, this.lightPosition.x, this.lightPosition.y, this.lightPosition.z);
            this.shaderProgram.SetUniform(strSurfaceColor, this.surfaceColor.x, this.surfaceColor.y, this.surfaceColor.z);
            this.shaderProgram.SetUniform(strWarmColor, this.warmColor.x, this.warmColor.y, this.warmColor.z);
            this.shaderProgram.SetUniform(strCoolColor, this.coolColor.x, this.coolColor.y, this.coolColor.z);
            this.shaderProgram.SetUniform(strDiffuseWarm, this.diffuseWarm);
            this.shaderProgram.SetUniform(strDiffuseCool, this.diffuseCool);

        }

        public void ResetShaderProgram()
        {
            this.shaderProgram.Unbind();
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
