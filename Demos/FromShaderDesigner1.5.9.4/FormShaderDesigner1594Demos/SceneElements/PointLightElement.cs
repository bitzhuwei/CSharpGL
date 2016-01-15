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

namespace FormShaderDesigner1594Demos.SceneElements
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

        private int elementCount;

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.PointLightElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.PointLightElement.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

        }

        protected void InitializeVAO()
        {
            IModel model = SphereModel.GetModel(1, 10, 40);

            this.positionBufferRenderer = model.GetPositionBufferRenderer(strin_Position);
            this.colorBufferRenderer = model.GetColorBufferRenderer(strin_Color);
            this.indexBufferRenderer = model.GetIndexes() as IndexBufferRenderer;

            this.elementCount = this.indexBufferRenderer.ElementCount;
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

}
