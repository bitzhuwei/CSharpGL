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
    /// 球体
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
            SphereModel sphere = SphereModel.GetSphere(1, 3, 10);

            //  Create a vertex buffer for the vertex data.
            using (var positionBuffer = new SpherePositionBuffer(strin_Position))
            {
                positionBuffer.Alloc(sphere.positions.Length);
                vec3* positionArray = (vec3*)positionBuffer.FirstElement();
                for (int i = 0; i < sphere.positions.Length; i++)
                {
                    positionArray[i] = sphere.positions[i];
                }

                this.positionBufferRenderer = positionBuffer.GetRenderer();
            }

            //  Now do the same for the colour data.
            using (var colorBuffer = new SphereColorBuffer(strin_Color))
            {
                colorBuffer.Alloc(sphere.colors.Length);
                vec3* colorArray = (vec3*)colorBuffer.FirstElement();
                for (int i = 0; i < sphere.colors.Length; i++)
                {
                    colorArray[i] = sphere.colors[i];
                }

                this.colorBufferRenderer = colorBuffer.GetRenderer();
            }

            using (var normalBuffer = new SphereNormalBuffer(strin_Normal))
            {
                normalBuffer.Alloc(sphere.normals.Length);
                vec3* normalArray = (vec3*)normalBuffer.FirstElement();
                for (int i = 0; i < sphere.normals.Length; i++)
                {
                    normalArray[i] = sphere.normals[i];
                }

                this.normalBufferRenderer = normalBuffer.GetRenderer();
            }

            using (var indexBuffer = new IndexBuffer<uint>(DrawMode.QuadStrip, IndexElementType.UnsignedInt, BufferUsage.StaticDraw))
            {
                indexBuffer.Alloc(sphere.indexes.Length);
                uint* indexArray = (uint*)indexBuffer.FirstElement();
                for (int i = 0; i < sphere.indexes.Length; i++)
                {
                    indexArray[i] = sphere.indexes[i];
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

    class SpherePositionBuffer : PropertyBuffer<vec3>
    {
        public SpherePositionBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }

    class SphereColorBuffer : PropertyBuffer<vec3>
    {
        public SphereColorBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }

    class SphereNormalBuffer : PropertyBuffer<vec3>
    {
        public SphereNormalBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }
}
