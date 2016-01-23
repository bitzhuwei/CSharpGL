using CSharpGL.Objects.Models;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.VertexBuffers;
using GLM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Demos
{
    public class DoubleTextureRenderer : RendererBase
    {
        ShaderProgram shaderProgram;

        #region VAO/VBO renderers

        VertexArrayObject vertexArrayObject;

        const string strin_Position = "in_Position";
        BufferRenderer positionBufferRenderer;

        const string strin_Color = "in_UV";
        BufferRenderer colorBufferRenderer;

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

        const string strtexture1 = "texture1";
        private Texture2D texture1;

        const string strtexture2 = "texture2";
        private Texture2D texture2;

        const string strpercent = "percent";
        public float percent = 0.5f;
        #endregion


        public PolygonModes polygonMode = PolygonModes.Filled;

        private int elementCount;

        private IModel model;

        public DoubleTextureRenderer(IModel model, Bitmap bitmap1, Bitmap bitmap2)
        {
            this.model = model;
            texture1 = new Texture2D();
            texture1.Initialize(bitmap1);
            this.texture2 = new Texture2D();
            this.texture2.Initialize(bitmap2);
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"DoubleTexture.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"DoubleTexture.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);
        }

        protected void InitializeVAO()
        {
            IModel model = this.model;

            this.positionBufferRenderer = model.GetPositionBufferRenderer(strin_Position);
            //this.colorBufferRenderer = model.GetColorBufferRenderer(strin_Color);
            using (var colorBuffer = new ColorBuffer(strin_Color))
            {
                colorBuffer.Alloc(4 * 6);
                for (int i = 0; i < 6; i++)
                {
                    colorBuffer[i * 4 + 0] = new vec2(0, 0);
                    colorBuffer[i * 4 + 1] = new vec2(0, 1);
                    colorBuffer[i * 4 + 2] = new vec2(1, 1);
                    colorBuffer[i * 4 + 3] = new vec2(1, 0);
                }

                this.colorBufferRenderer = colorBuffer.GetRenderer();
            }
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

            program.SetUniform(strtexture1, 0);//texture1.Name);
            GL.ActiveTexture(GL.GL_TEXTURE0);
            GL.Enable(GL.GL_TEXTURE_2D);
            texture1.Bind();
            
            program.SetUniform(strtexture2, 1);//texture2.Name);
            GL.ActiveTexture(GL.GL_TEXTURE1);
            GL.Enable(GL.GL_TEXTURE_2D);
            texture2.Bind();
            
            program.SetUniform(strpercent, percent);

            int[] originalPolygonMode = new int[1];
            GL.GetInteger(GetTarget.PolygonMode, originalPolygonMode);

            GL.PolygonMode(PolygonModeFaces.FrontAndBack, this.polygonMode);

            if (this.vertexArrayObject == null)
            {
                var vertexArrayObject = new VertexArrayObject(
                    this.positionBufferRenderer,
                    this.colorBufferRenderer,
                    //this.normalBufferRenderer,
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

            texture2.Unbind();
            texture1.Unbind();
        }



        protected override void CleanUnmanagedRes()
        {
            if (this.vertexArrayObject != null)
            {
                this.vertexArrayObject.Dispose();
            }
            this.texture1.Dispose();
            this.texture1 = null;
            this.texture2.Dispose();
            this.texture2 = null;

            base.CleanUnmanagedRes();
        }

        public void DecreaseVertexCount()
        {
            {
                IndexBufferRenderer renderer = this.indexBufferRenderer as IndexBufferRenderer;
                if (renderer != null)
                {
                    if (renderer.ElementCount > 0)
                        renderer.ElementCount--;
                }
            }
            {
                ZeroIndexBufferRenderer renderer = this.indexBufferRenderer as ZeroIndexBufferRenderer;
                if (renderer != null)
                {
                    if (renderer.VertexCount > 0)
                        renderer.VertexCount--;
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
                        renderer.ElementCount++;
                }
            }
            {
                ZeroIndexBufferRenderer renderer = this.indexBufferRenderer as ZeroIndexBufferRenderer;
                if (renderer != null)
                {
                    if (renderer.VertexCount < this.elementCount)
                        renderer.VertexCount++;
                }
            }
        }

        class ColorBuffer : PropertyBuffer<vec2>
        {
            public ColorBuffer(string varNameInShader)
                : base(varNameInShader, 2, GL.GL_FLOAT, BufferUsage.StaticDraw)
            { }
        }
    }


}
