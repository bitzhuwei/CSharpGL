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
    /// 用一个球体代表点光源的位置
    /// </summary>
    public class PointLightElement : SceneElementBase, IMVP
    {

        VertexArrayObject planVAO;
        BufferRenderer positionBufferRenderer;
        BufferRenderer colorBufferRenderer;
        IndexBufferRenderer indexBufferRenderer;

        /// <summary>
        /// shader program
        /// </summary>
        private ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_Color = "in_Color";
        const string strMVP = "MVP";

        private float radius;
        private float axisLength;
        private int faceCount;
        private vec3 planColor;
        private int indexCount;

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.PointLightElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.PointLightElement.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

        }

        protected unsafe void InitializeVAO()
        {
            SphereModel SphereElement = SphereModel.GetModel(1, 10, 40);

            //  Create a vertex buffer for the vertex data.
            using (var positionBuffer = new PointLightElementPositionBuffer(strin_Position))
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
            using (var colorBuffer = new PointLightElementColorBuffer(strin_Color))
            {
                colorBuffer.Alloc(SphereElement.colors.Length);
                vec3* colorArray = (vec3*)colorBuffer.FirstElement();
                for (int i = 0; i < SphereElement.colors.Length; i++)
                {
                    colorArray[i] = SphereElement.colors[i];
                }

                this.colorBufferRenderer = colorBuffer.GetRenderer();
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
            this.indexCount = SphereElement.indexes.Length;
        }

        protected override void DoInitialize()
        {
            InitializeShader(out shaderProgram);

            InitializeVAO();
        }

        protected override void DoRender(RenderEventArgs e)
        {
            if (this.planVAO == null)
            {
                var vao = new VertexArrayObject(this.positionBufferRenderer, colorBufferRenderer, this.indexBufferRenderer);
                vao.Create(e, this.shaderProgram);

                this.planVAO = vao;
            }

            // 绑定shader
            this.shaderProgram.Bind();

            this.planVAO.Render(e, this.shaderProgram);

            // 解绑shader
            this.shaderProgram.Unbind();
        }



        protected override void CleanUnmanagedRes()
        {
            if (this.planVAO != null)
            {
                this.planVAO.Dispose();
            }

            base.CleanUnmanagedRes();
        }

        void IMVP.SetShaderProgram(mat4 mvp)
        {
            IMVPHelper.SetMVP(this, mvp);
        }


        void IMVP.ResetShaderProgram()
        {
            IMVPHelper.ResetMVP(this);
        }

        ShaderProgram IMVP.GetShaderProgram()
        {
            return this.shaderProgram;
        }
    }

    class PointLightElementPositionBuffer : PropertyBuffer<vec3>
    {
        public PointLightElementPositionBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }

    class PointLightElementColorBuffer : PropertyBuffer<vec3>
    {
        public PointLightElementColorBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }

    class PointLightElementNormalBuffer : PropertyBuffer<vec3>
    {
        public PointLightElementNormalBuffer(string varNameInShader)
            : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
        {

        }
    }
}
