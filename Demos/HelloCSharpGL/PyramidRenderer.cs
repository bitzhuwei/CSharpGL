using CSharpGL;
using CSharpGL.Objects;
using CSharpGL.Objects.Models;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.VertexBuffers;
using GLM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharpGL
{
    /// <summary>
    /// 一个<see cref="PyramidRenderer"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// </summary>
    public class PyramidRenderer : RendererBase
    {
        ShaderProgram shaderProgram;

        #region VAO/VBO renderers

        VertexArrayObject vertexArrayObject;

        const string strin_Position = "in_Position";
        BufferRenderer positionBufferRenderer;

        const string strin_Color = "in_Color";
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

        #endregion


        public PolygonModes polygonMode = PolygonModes.Filled;

        private int elementCount;

        private IModel model;

        public PyramidRenderer(IModel model)
        {
            this.model = model;
        }

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"Pyramid.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"Pyramid.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);
        }

        protected void InitializeVAO()
        {
            IModel model = this.model;

            this.positionBufferRenderer = model.GetPositionBufferRenderer(strin_Position);
            this.colorBufferRenderer = model.GetColorBufferRenderer(strin_Color);
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
        }



        protected override void CleanUnmanagedRes()
        {
            if (this.vertexArrayObject != null)
            {
                this.vertexArrayObject.Dispose();
            }

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
    }

    // 这是旧版的PyramidRenderer，对比一下吧。
    //class PyramidDemo : CSharpGL.Objects.RendererBase
    //{
    //    private ShaderProgram shaderProgram;
    //    private uint[] vertexArrayObject;

    //    private void InitVAO()
    //    {
    //        // reserve a vertex array object(VAO) 预约一个VAO
    //        this.vertexArrayObject = new uint[1];
    //        GL.GenVertexArrays(1, this.vertexArrayObject);

    //        // prepare vertex buffer object(VBO) for vertexes' positions 为顶点位置准备VBO
    //        uint[] positionBufferObject = new uint[1];
    //        {
    //            // specify position array
    //            var positionArray = new UnmanagedArray<vec3>(vertexCount);
    //            positionArray[0] = new vec3(0.0f, 1.0f, 0.0f);
    //            positionArray[1] = new vec3(-1.0f, -1.0f, 1.0f);
    //            positionArray[2] = new vec3(1.0f, -1.0f, 1.0f);
    //            positionArray[3] = new vec3(0.0f, 1.0f, 0.0f);
    //            positionArray[4] = new vec3(1.0f, -1.0f, 1.0f);
    //            positionArray[5] = new vec3(1.0f, -1.0f, -1.0f);
    //            positionArray[6] = new vec3(0.0f, 1.0f, 0.0f);
    //            positionArray[7] = new vec3(1.0f, -1.0f, -1.0f);
    //            positionArray[8] = new vec3(-1.0f, -1.0f, -1.0f);
    //            positionArray[9] = new vec3(0.0f, 1.0f, 0.0f);
    //            positionArray[10] = new vec3(-1.0f, -1.0f, -1.0f);
    //            positionArray[11] = new vec3(-1.0f, -1.0f, 1.0f);

    //            // put positions into VBO
    //            GL.GenBuffers(1, positionBufferObject);
    //            GL.BindBuffer(BufferTarget.ArrayBuffer, positionBufferObject[0]);
    //            GL.BufferData(BufferTarget.ArrayBuffer, positionArray, BufferUsage.StaticDraw);

    //            positionArray.Dispose();
    //        }

    //        // prepare vertex buffer object(VBO) for vertexes' colors
    //        uint[] colorBufferObject = new uint[1];
    //        {
    //            // specify color array
    //            UnmanagedArray<vec3> colorArray = new UnmanagedArray<vec3>(vertexCount);
    //            colorArray[0] = new vec3(1.0f, 0.0f, 0.0f);
    //            colorArray[1] = new vec3(0.0f, 1.0f, 0.0f);
    //            colorArray[2] = new vec3(0.0f, 0.0f, 1.0f);
    //            colorArray[3] = new vec3(1.0f, 0.0f, 0.0f);
    //            colorArray[4] = new vec3(0.0f, 0.0f, 1.0f);
    //            colorArray[5] = new vec3(0.0f, 1.0f, 0.0f);
    //            colorArray[6] = new vec3(1.0f, 0.0f, 0.0f);
    //            colorArray[7] = new vec3(0.0f, 1.0f, 0.0f);
    //            colorArray[8] = new vec3(0.0f, 0.0f, 1.0f);
    //            colorArray[9] = new vec3(1.0f, 0.0f, 0.0f);
    //            colorArray[10] = new vec3(0.0f, 0.0f, 1.0f);
    //            colorArray[11] = new vec3(0.0f, 1.0f, 0.0f);

    //            // put colors into VBO
    //            GL.GenBuffers(1, colorBufferObject);
    //            GL.BindBuffer(BufferTarget.ArrayBuffer, colorBufferObject[0]);
    //            GL.BufferData(BufferTarget.ArrayBuffer, colorArray, BufferUsage.StaticDraw);

    //            colorArray.Dispose();
    //        }

    //        uint positionLocation = shaderProgram.GetAttributeLocation("in_Position");
    //        uint colorLocation = shaderProgram.GetAttributeLocation("in_Color");

    //        {
    //            // bind the vertex array object(VAO), we are going to specify data for it.
    //            GL.BindVertexArray(vertexArrayObject[0]);

    //            // specify vertexes' positions
    //            GL.BindBuffer(BufferTarget.ArrayBuffer, positionBufferObject[0]);
    //            GL.VertexAttribPointer(positionLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
    //            GL.EnableVertexAttribArray(positionLocation);

    //            // specify vertexes' colors
    //            GL.BindBuffer(BufferTarget.ArrayBuffer, colorBufferObject[0]);
    //            GL.VertexAttribPointer(colorLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
    //            GL.EnableVertexAttribArray(colorLocation);

    //            //  Unbind the vertex array object(VAO), we've finished specifying data for it.
    //            GL.BindVertexArray(0);
    //        }
    //    }

    //    private void InitShaderProgram()
    //    {
    //        var vertexShaderSource = File.ReadAllText(@"PyramidDemo.vert");
    //        var fragmentShaderSource = File.ReadAllText(@"PyramidDemo.frag");

    //        var shaderProgram = new CSharpGL.Objects.Shaders.ShaderProgram();
    //        shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

    //        this.shaderProgram = shaderProgram;
    //    }

    //    private float rotation;

    //    protected override void DoInitialize()
    //    {
    //        InitShaderProgram();

    //        InitVAO();
    //    }

    //    protected override void DoRender(CSharpGL.Objects.RenderEventArgs e)
    //    {
    //        mat4 mvp;
    //        {
    //            // model rotates
    //            mat4 modelMatrix = glm.rotate(rotation, new vec3(0, 1, 0));

    //            // same as gluLookAt()
    //            mat4 viewMatrix = glm.lookAt(new vec3(-5, 5, -5), new vec3(0, 0, 0), new vec3(0, 1, 0));

    //            // same as gluPerspective()
    //            int[] viewport = new int[4];
    //            GL.GetInteger(GetTarget.Viewport, viewport);
    //            float width = viewport[2];
    //            float height = viewport[3];
    //            mat4 projectionMatrix = glm.perspective((float)(60.0f * Math.PI / 180.0f), width / height, 0.01f, 100.0f);

    //            // get MVP in "uniform mat4 MVP;" in the vertex shader
    //            mvp = projectionMatrix * viewMatrix * modelMatrix;
    //        }

    //        // bind the shader program to setup uniforms
    //        this.shaderProgram.Bind();
    //        // setup MVP
    //        this.shaderProgram.SetUniformMatrix4("MVP", mvp.to_array());
    //        {
    //            // bind vertex array object(VAO)
    //            GL.BindVertexArray(this.vertexArrayObject[0]);
    //            // draw the model: in GL_TRIANGLES mode, there are 'vertexCount' vertexes
    //            GL.DrawArrays(GL.GL_TRIANGLES, 0, vertexCount);
    //            // unbind vertex array object(VAO)
    //            GL.BindVertexArray(0);
    //        }
    //        // unbind the shader program
    //        this.shaderProgram.Unbind();

    //        rotation += 3.0f;
    //    }
    //}
}
