using GLM;
using CSharpGL.Objects;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.SceneElements
{
    public class PyramidElement : SceneElementBase
    {

        /// <summary>
        /// shader program
        /// </summary>
        public ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_Color = "in_Color";
        const string strMVP = "MVP";
        public mat4 mvp;

        /// <summary>
        /// VAO
        /// </summary>
        protected uint[] vao;
        protected uint[] positionBufferObject;
        protected uint[] colorBufferObject;

        /// <summary>
        /// 图元类型
        /// </summary>
        protected DrawMode primitiveMode;

        /// <summary>
        /// 顶点数
        /// </summary>
        protected int vertexCount;

        /// <summary>
        /// 金字塔的posotion array.
        /// </summary>
        static vec3[] positions = new vec3[]
		{
			new vec3(0.0f, 1.0f, 0.0f),
			new vec3(-1.0f, -1.0f, 1.0f),
			new vec3(1.0f, -1.0f, 1.0f),
			new vec3(0.0f, 1.0f, 0.0f),
			new vec3(1.0f, -1.0f, 1.0f),
			new vec3(1.0f, -1.0f, -1.0f),
			new vec3(0.0f, 1.0f, 0.0f),
			new vec3(1.0f, -1.0f, -1.0f),
			new vec3(-1.0f, -1.0f, -1.0f),
			new vec3(0.0f, 1.0f, 0.0f),
			new vec3(-1.0f, -1.0f, -1.0f),
			new vec3(-1.0f, -1.0f, 1.0f),
		};

        /// <summary>
        /// 金字塔的color array.
        /// </summary>
        static vec3[] colors = new vec3[]
		{
			new vec3(1.0f, 0.0f, 0.0f),
			new vec3(0.0f, 1.0f, 0.0f),
			new vec3(0.0f, 0.0f, 1.0f),
			new vec3(1.0f, 0.0f, 0.0f),
			new vec3(0.0f, 0.0f, 1.0f),
			new vec3(0.0f, 1.0f, 0.0f),
			new vec3(1.0f, 0.0f, 0.0f),
			new vec3(0.0f, 1.0f, 0.0f),
			new vec3(0.0f, 0.0f, 1.0f),
			new vec3(1.0f, 0.0f, 0.0f),
			new vec3(0.0f, 0.0f, 1.0f),
			new vec3(0.0f, 1.0f, 0.0f),
		};

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.PyramidElement.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"SceneElements.PyramidElement.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

        }

        //protected void InitializeVAO(out uint[] vao, out DrawMode primitiveMode, out int vertexCount)
        protected void InitializeVAO()
        {
            this.primitiveMode = DrawMode.Triangles;
            this.vertexCount = positions.Length;

            this.vao = new uint[1];
            GL.GenVertexArrays(1, vao);
            GL.BindVertexArray(vao[0]);

            //  Create a vertex buffer for the vertex data.
            {
                //uint[] ids = new uint[1];
                this.positionBufferObject = new uint[1];
                GL.GenBuffers(1, this.positionBufferObject);
                GL.BindBuffer(BufferTarget.ArrayBuffer, this.positionBufferObject[0]);
                UnmanagedArray<vec3> positionArray = new UnmanagedArray<vec3>(positions.Length);
                for (int i = 0; i < positions.Length; i++)
                {
                    positionArray[i] = positions[i];
                }

                uint positionLocation = shaderProgram.GetAttributeLocation(strin_Position);

                GL.BufferData(BufferTarget.ArrayBuffer, positionArray, BufferUsage.StaticDraw);
                GL.VertexAttribPointer(positionLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(positionLocation);

                positionArray.Dispose();
            }

            //  Now do the same for the colour data.
            {
                //uint[] ids = new uint[1];
                this.colorBufferObject = new uint[1];
                GL.GenBuffers(1, this.colorBufferObject);
                GL.BindBuffer(BufferTarget.ArrayBuffer, this.colorBufferObject[0]);
                UnmanagedArray<vec3> colorArray = new UnmanagedArray<vec3>(positions.Length);
                for (int i = 0; i < colors.Length; i++)
                {
                    colorArray[i] = colors[i];
                }

                uint colorLocation = shaderProgram.GetAttributeLocation(strin_Color);

                GL.BufferData(BufferTarget.ArrayBuffer, colorArray, BufferUsage.StaticDraw);
                GL.VertexAttribPointer(colorLocation, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(colorLocation);

                colorArray.Dispose();
            }

            //  Unbind the vertex array, we've finished specifying data for it.
            GL.BindVertexArray(0);
        }

        protected override void DoInitialize()
        {
            InitializeShader(out shaderProgram);

            //InitializeVAO(out vao, out primitiveMode, out vertexCount);
            InitializeVAO();

            //base.BeforeRendering += IMVPHelper.Getelement_BeforeRendering();
            //base.AfterRendering += IMVPHelper.Getelement_AfterRendering();
        }

        protected override void DoRender(RenderEventArgs e)
        {
            this.shaderProgram.Bind();
            this.shaderProgram.SetUniformMatrix4(strMVP, mvp.to_array());

            GL.BindVertexArray(vao[0]);

            GL.DrawArrays(primitiveMode, 0, vertexCount);

            GL.BindVertexArray(0);

            this.shaderProgram.Unbind();
        }

        protected override void CleanUnmanagedRes()
        {
            try
            {
                GL.DeleteBuffers(this.positionBufferObject.Length, this.positionBufferObject);
                GL.DeleteBuffers(this.colorBufferObject.Length, this.colorBufferObject);
                GL.DeleteVertexArrays(this.vao.Length, this.vao);
            }
            catch (Exception)
            {

            }
        }
    }
}
