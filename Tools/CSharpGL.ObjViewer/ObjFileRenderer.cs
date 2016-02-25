
namespace CSharpGL.ObjViewer
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
    using System.Windows.Forms;
    /// <summary>
    /// 一个<see cref="ObjFileRenderer"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// </summary>
    public class ObjFileRenderer : RendererBase
    {
        ShaderProgram shaderProgram;

        #region VAO/VBO renderers

        VertexArrayObject vertexArrayObject;

        const string strin_Position = "in_Position";
        BufferPointer positionBufferRenderer;

        //const string strin_Color = "in_Color";
        //BufferRenderer colorBufferRenderer;

        const string strin_Normal = "in_Normal";
        BufferPointer normalBufferRenderer;

        IndexBufferPointerBase indexBufferRenderer;

        #endregion

        #region uniforms

        const string strmodelMatrix = "modelMatrix";
        public mat4 modelMatrix;

        const string strviewMatrix = "viewMatrix";
        public mat4 viewMatrix;

        const string strprojectionMatrix = "projectionMatrix";
        public mat4 projectionMatrix;

        #endregion


        public PolygonModes polygonMode = PolygonModes.Filled;

        private int elementCount;

        private IModel model;

        public ObjFileRenderer(IModel model)
        {
            this.model = model;
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile("ObjFile.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile("ObjFile.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);
        }

        protected void InitializeVAO()
        {
            IModel model = this.model;

            this.positionBufferRenderer = model.GetPositionBufferRenderer(strin_Position);
            //this.colorBufferRenderer = model.GetColorBufferRenderer(strin_Color);
            this.normalBufferRenderer = model.GetNormalBufferRenderer(strin_Normal);
            this.indexBufferRenderer = model.GetIndexes() as IndexBufferPointerBase;

            {
                IndexBufferPointer renderer = this.indexBufferRenderer as IndexBufferPointer;
                if (renderer != null)
                {
                    this.elementCount = renderer.ElementCount;
                }
            }
            {
                ZeroIndexBufferPointer renderer = this.indexBufferRenderer as ZeroIndexBufferPointer;
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

            int[] originalPolygonMode = new int[1];
            GL.GetInteger(GetTarget.PolygonMode, originalPolygonMode);

            GL.PolygonMode(PolygonModeFaces.FrontAndBack, this.polygonMode);

            GL.Enable(GL.GL_PRIMITIVE_RESTART);
            GL.PrimitiveRestartIndex(uint.MaxValue);

            if (this.vertexArrayObject == null)
            {
                var vertexArrayObject = new VertexArrayObject(
                    this.indexBufferRenderer,
                    this.positionBufferRenderer,
                    //this.colorBufferRenderer,
                    this.normalBufferRenderer);
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
                IndexBufferPointer renderer = this.indexBufferRenderer as IndexBufferPointer;
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
                ZeroIndexBufferPointer renderer = this.indexBufferRenderer as ZeroIndexBufferPointer;
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
                IndexBufferPointer renderer = this.indexBufferRenderer as IndexBufferPointer;
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
                ZeroIndexBufferPointer renderer = this.indexBufferRenderer as ZeroIndexBufferPointer;
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

