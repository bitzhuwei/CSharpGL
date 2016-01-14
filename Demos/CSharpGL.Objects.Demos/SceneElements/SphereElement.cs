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
    /// 类似冰激凌形状的物体
    /// </summary>
    public class SphereElement : SceneElementBase
    {

        VertexArrayObject vertexArrayObject;
        BufferRenderer positionBufferRenderer;
        BufferRenderer colorBufferRenderer;
        BufferRenderer normalBufferRenderer;
        IndexBufferRenderer indexBufferRenderer;

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
        const string strlightPosition = "lightPosition";
        public vec3 lightPosition = new vec3(0, 0, 0);

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.SphereElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.SphereElement.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

        }

        protected unsafe void InitializeVAO()
        {
            SphereModel SphereElement = SphereModel.GetModel(1, 10, 80);

            //  Create a vertex buffer for the vertex data.
            using (var positionBuffer = new SphereElementPositionBuffer(strin_Position))
            {
                positionBuffer.Alloc(SphereElement.positions.Length);
                vec3* positionArray = (vec3*)positionBuffer.FirstElement();
                for (int i = 0; i < SphereElement.positions.Length; i++)
                {
                    positionArray[i] = SphereElement.positions[i];
                }

                this.positionBufferRenderer = positionBuffer.GetRenderer();
            }

            //  Now do the same for the colour data.
            using (var colorBuffer = new SphereElementColorBuffer(strin_Color))
            {
                colorBuffer.Alloc(SphereElement.colors.Length);
                vec3* colorArray = (vec3*)colorBuffer.FirstElement();
                for (int i = 0; i < SphereElement.colors.Length; i++)
                {
                    colorArray[i] = SphereElement.colors[i];
                }

                this.colorBufferRenderer = colorBuffer.GetRenderer();
            }

            using (var normalBuffer = new SphereElementNormalBuffer(strin_Normal))
            {
                normalBuffer.Alloc(SphereElement.normals.Length);
                vec3* normalArray = (vec3*)normalBuffer.FirstElement();
                for (int i = 0; i < SphereElement.normals.Length; i++)
                {
                    normalArray[i] = SphereElement.normals[i];
                }

                this.normalBufferRenderer = normalBuffer.GetRenderer();
            }

            using (var indexBuffer = new IndexBuffer<uint>(DrawMode.QuadStrip, IndexElementType.UnsignedInt, BufferUsage.StaticDraw))
            {
                indexBuffer.Alloc(SphereElement.indexes.Length);
                uint* indexArray = (uint*)indexBuffer.FirstElement();
                for (int i = 0; i < SphereElement.indexes.Length; i++)
                {
                    indexArray[i] = SphereElement.indexes[i];
                }

                this.indexBufferRenderer = indexBuffer.GetRenderer() as IndexBufferRenderer;
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

            GL.Enable(GL.GL_PRIMITIVE_RESTART);
            GL.PrimitiveRestartIndex(uint.MaxValue);
            this.vertexArrayObject.Render(e, this.shaderProgram);
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

        public void SetMatrix(mat4 projectionMatrix, mat4 viewMatrix, mat4 modelMatrix)
        {
            this.shaderProgram.Bind();
            this.shaderProgram.SetUniformMatrix4(strprojectionMatrix, projectionMatrix.to_array());
            this.shaderProgram.SetUniformMatrix4(strviewMatrix, viewMatrix.to_array());
            this.shaderProgram.SetUniformMatrix4(strmodelMatrix, modelMatrix.to_array());
            this.shaderProgram.SetUniform(strlightPosition, this.lightPosition.x, this.lightPosition.y, this.lightPosition.z);
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
            if (this.indexBufferRenderer.ElementCount < 4 * 6)
                this.indexBufferRenderer.ElementCount++;
        }

    }

    class SphereElementPositionBuffer : PropertyBuffer<vec3>
    {
        public SphereElementPositionBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }

    class SphereElementColorBuffer : PropertyBuffer<vec3>
    {
        public SphereElementColorBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }

    class SphereElementNormalBuffer : PropertyBuffer<vec3>
    {
        public SphereElementNormalBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }
}
