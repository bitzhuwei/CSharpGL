using CSharpGL.Maths;
using CSharpGL.Objects;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.SceneElements
{
    public class PyramidElement : SceneElementBase, IMVP
    {

        /// <summary>
        /// shader program
        /// </summary>
        public ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_Color = "in_Color";
        public const string strMVP = "MVP";

        /// <summary>
        /// VAO
        /// </summary>
        protected uint[] vao;

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

            shaderProgram.AssertValid();
        }

        protected void InitializeVAO(out uint[] vao, out DrawMode primitiveMode, out int vertexCount)
        {
            primitiveMode = DrawMode.Triangles;
            vertexCount = positions.Length;

            vao = new uint[1];
            GL.GenVertexArrays(1, vao);
            GL.BindVertexArray(vao[0]);

            //  Create a vertex buffer for the vertex data.
            {
                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
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
                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
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

            InitializeVAO(out vao, out primitiveMode, out vertexCount);

            //base.BeforeRendering += IMVPHelper.Getelement_BeforeRendering();
            //base.AfterRendering += IMVPHelper.Getelement_AfterRendering();
        }

        protected override void DoRender(RenderEventArgs e)
        {
            GL.BindVertexArray(vao[0]);

            GL.DrawArrays(primitiveMode, 0, vertexCount);

            GL.BindVertexArray(0);
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
