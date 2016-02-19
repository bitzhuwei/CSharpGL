
namespace CSharpGL.Objects.Demos
{
    using CSharpGL;
    using CSharpGL.Objects;
    using CSharpGL.Objects.Models;
    using CSharpGL.Objects.Shaders;
    using CSharpGL.Objects.VertexBuffers;
    using GLM;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// 一个<see cref="LifeBarRenderer"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// </summary>
    public class LifeBarRenderer : RendererBase
    {
        ShaderProgram shaderProgram;

        #region VAO/VBO renderers

        VertexArrayObject vertexArrayObject;

        const string strin_Position = "in_Position";
        BufferRenderer positionBufferRenderer;

        //const string strin_Color = "in_Color";
        //BufferRenderer colorBufferRenderer;

        //const string strin_Normal = "in_Normal";
        //BufferRenderer normalBufferRenderer;

        BufferRenderer indexBufferRenderer;

        #endregion

        #region uniforms

        const string strmodelMatrix = "modelMatrix";
        public mat4 modelMatrix;

        const string strviewMatrix = "viewMatrix";
        public mat4 viewMatrix;

        const string strprojectionMatrix = "projectionMatrix";
        public mat4 projectionMatrix;

        const string strLength = "length";
        const string strWdith = "width";
        const string strHeight = "height";
        const string strColor = "color";
        //const string strcameraDistance = "cameraDistance";
        //public float cameraDistance = 1.0f;

        #endregion


        public PolygonModes polygonMode = PolygonModes.Filled;

        private int elementCount;

        public LifeBar model;

        public LifeBarRenderer(LifeBar model)
        {
            this.model = model;
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile("LifeBar.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile("LifeBar.frag");
            var geometryShaderSource = ManifestResourceLoader.LoadTextFile("LifeBar.geom");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, geometryShaderSource);
        }

        protected void InitializeVAO()
        {
            IModel model = this.model;

            this.positionBufferRenderer = model.GetPositionBufferRenderer(strin_Position);
            //this.colorBufferRenderer = model.GetColorBufferRenderer(strin_Color);
            //this.normalBufferRenderer = model.GetNormalBufferRenderer(strin_Normal);
            this.indexBufferRenderer = model.GetIndexes();

            {
                IndexBufferRenderer renderer = this.indexBufferRenderer as IndexBufferRenderer;
                if (renderer != null)
                {
                    this.elementCount = renderer.ElementCount;
                }
            }
            {
                ZeroIndexBufferRenderer renderer = this.indexBufferRenderer as ZeroIndexBufferRenderer;
                if (renderer != null)
                {
                    this.elementCount = renderer.VertexCount;
                }
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
            program.SetUniform(strLength, this.model.Length);
            program.SetUniform(strWdith, this.model.Wdith);
            program.SetUniform(strHeight, this.model.Height);
            //program.SetUniform(strColor, this.model.Color.x, this.model.Color.y, this.model.Color.z);
            //program.SetUniform(strcameraDistance, this.cameraDistance);

            int[] originalPolygonMode = new int[1];
            GL.GetInteger(GetTarget.PolygonMode, originalPolygonMode);

            GL.PolygonMode(PolygonModeFaces.FrontAndBack, this.polygonMode);

            GL.Enable(GL.GL_PRIMITIVE_RESTART);
            GL.PrimitiveRestartIndex(uint.MaxValue);

            if (this.vertexArrayObject == null)
            {
                var vertexArrayObject = new VertexArrayObject(
                    this.positionBufferRenderer,
                    //this.colorBufferRenderer,
                    //this.normalBufferRenderer,
                    this.indexBufferRenderer);
                vertexArrayObject.Create(e, this.shaderProgram);

                this.vertexArrayObject = vertexArrayObject;
            }
            else
            {
                this.vertexArrayObject.Render(e, this.shaderProgram);
            }

            GL.Disable(GL.GL_PRIMITIVE_RESTART);

            GL.PolygonMode(PolygonModeFaces.FrontAndBack, (PolygonModes)(originalPolygonMode[0]));

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

        public void DecreaseVertexCount()
        {
            {
                IndexBufferRenderer renderer = this.indexBufferRenderer as IndexBufferRenderer;
                if (renderer != null)
                {
                    if (renderer.ElementCount > 0)
                    {
                        renderer.ElementCount--;
                    }
                    return;
                }
            }
            {
                ZeroIndexBufferRenderer renderer = this.indexBufferRenderer as ZeroIndexBufferRenderer;
                if (renderer != null)
                {
                    if (renderer.VertexCount > 0)
                    {
                        renderer.VertexCount--;
                    }
                    return;
                }
            }
        }

        public void IncreaseVertexCount()
        {
            {
                IndexBufferRenderer renderer = this.indexBufferRenderer as IndexBufferRenderer;
                if (renderer != null)
                {
                    if (renderer.ElementCount < this.elementCount)
                    {
                        renderer.ElementCount++;
                    }
                    return;
                }
            }
            {
                ZeroIndexBufferRenderer renderer = this.indexBufferRenderer as ZeroIndexBufferRenderer;
                if (renderer != null)
                {
                    if (renderer.VertexCount < this.elementCount)
                    {
                        renderer.VertexCount++;
                    }
                    return;
                }
            }
        }
    }
}

