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
    public class GoochElement : SceneElementBase
    {

        VertexArrayObject vertexArrayObject;
        BufferRenderer positionBufferRenderer;
        //BufferRenderer colorBufferRenderer;
        BufferRenderer normalBufferRenderer;
        IndexBufferRenderer indexBufferRenderer;

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
        private vec3 lightPosition = new vec3(0.0f, 10.0f, 4.0f);

        public vec3 LightPosition
        {
            get { return lightPosition; }
            set { lightPosition = value; }
        }

        const string strSurfaceColor = "SurfaceColor";
        private vec3 surfaceColor = new vec3(0.75f, 0.75f, 0.75f);

        public vec3 SurfaceColor
        {
            get { return surfaceColor; }
            set { surfaceColor = value; }
        }

        const string strWarmColor = "WarmColor";
        private vec3 warmColor = new vec3(0.6f, 0.6f, 0.0f);

        public vec3 WarmColor
        {
            get { return warmColor; }
            set { warmColor = value; }
        }

        const string strCoolColor = "CoolColor";

        private vec3 coolColor = new vec3(0.0f, 0.0f, 0.6f);

        public vec3 CoolColor
        {
            get { return coolColor; }
            set { coolColor = value; }
        }

        const string strDiffuseWarm = "DiffuseWarm";
        private float diffuseWarm = 0.45f;

        public float DiffuseWarm
        {
            get { return diffuseWarm; }
            set { diffuseWarm = value; }
        }

        const string strDiffuseCool = "DiffuseCool";
        private float diffuseCool = 0.45f;

        public float DiffuseCool
        {
            get { return diffuseCool; }
            set { diffuseCool = value; }
        }

        private PolygonModes polygonMode = PolygonModes.Filled;

        public PolygonModes PolygonMode
        {
            get { return polygonMode; }
            set { polygonMode = value; }
        }

        private int indexCount;
        private IModel model;

        public GoochElement(IModel model)
        {
            this.model = model;
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.GoochElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.GoochElement.frag");

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
