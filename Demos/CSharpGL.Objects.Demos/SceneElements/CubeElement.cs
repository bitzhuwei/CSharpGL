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

namespace CSharpGL.Objects.SceneElements
{
    /// <summary>
    /// 立方体
    /// </summary>
    public class CubeElement : SceneElementBase
    {

        VertexArrayObject vertexArrayObject;
        BufferRenderer positionBufferRenderer;
        BufferRenderer colorBufferRenderer;
        ZeroIndexBufferRenderer indexBufferRenderer;

        /// <summary>
        /// shader program
        /// </summary>
        private ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_Normal = "in_Normal";
        const string strin_Color = "in_Color";
        const string strmodelMatrix = "modelMatrix";
        const string strviewMatrix = "viewMatrix";
        const string strprojectionMatrix = "projectionMatrix";


        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.CubeElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.CubeElement.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

        }

        protected unsafe void InitializeVAO()
        {

            //  Create a vertex buffer for the vertex data.
            using (var positionBuffer = new CubePositionBuffer(strin_Position))
            {
                positionBuffer.Alloc(1);
                CubePosition* plan = (CubePosition*)positionBuffer.FirstElement();
                plan[0] = CubeModel.position;

                this.positionBufferRenderer = positionBuffer.GetRenderer();
            }

            //  Now do the same for the colour data.
            using (var colorBuffer = new CubeColorBuffer(strin_Color))
            {
                colorBuffer.Alloc(1);
                CubeColor* colorArray = (CubeColor*)colorBuffer.FirstElement();
                colorArray[0] = CubeModel.color;
                //colorArray[0] = CubeModel.GetRandomColor();

                this.colorBufferRenderer = colorBuffer.GetRenderer();
            }

            using (var indexBuffer = new ZeroIndexBuffer(DrawMode.Quads, 0, 4 * 6))
            {
                indexBuffer.Alloc(0);

                this.indexBufferRenderer = indexBuffer.GetRenderer() as ZeroIndexBufferRenderer;
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
                var vao = new VertexArrayObject(this.positionBufferRenderer, colorBufferRenderer, this.indexBufferRenderer);
                vao.Create(e, this.shaderProgram);

                this.vertexArrayObject = vao;
            }

            // 绑定shader
            this.shaderProgram.Bind();

            this.vertexArrayObject.Render(e, this.shaderProgram);

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

        public void SetMatrix(mat4 projectionMatrix, mat4 viewMatrix, mat4 modelMatrix)
        {
            this.shaderProgram.Bind();
            this.shaderProgram.SetUniformMatrix4(strprojectionMatrix, projectionMatrix.to_array());
            this.shaderProgram.SetUniformMatrix4(strviewMatrix, viewMatrix.to_array());
            this.shaderProgram.SetUniformMatrix4(strmodelMatrix, modelMatrix.to_array());
        }

        public void ResetShaderProgram()
        {
            this.shaderProgram.Unbind();
        }

        public void DecreaseVertexCount()
        {
            if (this.indexBufferRenderer.VertexCount > 0)
                this.indexBufferRenderer.VertexCount -= 4;
        }

        public void IncreaseVertexCount()
        {
            if (this.indexBufferRenderer.VertexCount < 4 * 6)
                this.indexBufferRenderer.VertexCount += 4;
        }
    }

    class CubePositionBuffer : PropertyBuffer<CubePosition>
    {
        public CubePositionBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }

    class CubeColorBuffer : PropertyBuffer<CubeColor>
    {
        public CubeColorBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }

    class CubeNormalBuffer : PropertyBuffer<CubeNormal>
    {
        public CubeNormalBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }
}
