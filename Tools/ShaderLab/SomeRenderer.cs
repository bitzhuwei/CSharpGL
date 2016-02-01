





#if DEBUG
namespace CSharpShaders
{
	// 注意：请把CSharp Shader代码放到单独的文件，并且不要加任何其他的using ...;
    using CSharpShadingLanguage;

    /// <summary>
    /// 一个<see cref="DemoShaderVert"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// 这就是C#Shader形式的vertex shader。
    /// </summary>
    class DemoShaderVert : VertexCSShaderCode
    {
        [In]
        vec3 in_Position;
        [In]
        vec3 in_Color;

        [Out]
        vec4 pass_Color;

        [Uniform]
        mat4 modelMatrix;
        [Uniform]
        mat4 viewMatrix;
        [Uniform]
        mat4 projectionMatrix;

        public override void main()
        {
            gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);

            pass_Color = vec4(in_Color, 1.0f);
        }
    }

    /// <summary>
    /// 一个<see cref="DemoShaderFrag"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// 这就是C#Shader形式的fragment shader。
    /// </summary>
    class DemoShaderFrag : FragmentCSShaderCode
    {
        [In]
        vec4 pass_Color;

        [Out]
        vec4 out_Color;

        public override void main()
        {
            out_Color = pass_Color;
        }
    }
}
#endif

// 注意：请把ShaderRenderer代码放到单独的文件，并且不要加任何其他的using ...;
namespace ShaderLab
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
    /// 一个<see cref="DemoShaderRenderer"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// </summary>
    public class DemoShaderRenderer : RendererBase
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

        BufferRenderer indexBufferRenderer;

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

        public DemoShaderRenderer(IModel model)
        {
            this.model = model;
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"DemoShader.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"DemoShader.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);
        }

        protected void InitializeVAO()
        {
            IModel model = this.model;

            this.positionBufferRenderer = model.GetPositionBufferRenderer(strin_Position);
            this.colorBufferRenderer = model.GetColorBufferRenderer(strin_Color);
            this.normalBufferRenderer = model.GetNormalBufferRenderer(strin_Normal);
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

            int[] originalPolygonMode = new int[1];
            GL.GetInteger(GetTarget.PolygonMode, originalPolygonMode);

            GL.PolygonMode(PolygonModeFaces.FrontAndBack, this.polygonMode);

            if (this.vertexArrayObject == null)
            {
                var vertexArrayObject = new VertexArrayObject(
                    this.positionBufferRenderer,
                    this.colorBufferRenderer,
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
