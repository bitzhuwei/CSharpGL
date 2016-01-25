using GLM;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Demos
{
    public class DemoTexImage2D : RendererBase
    {

        public DemoTexImage2D(string textureFile)
        {
            this.textureFile = textureFile;
        }

        const string strtex = "tex";
        Texture2D tex = new Texture2D();

        /// <summary>
        /// shader program
        /// </summary>
        public ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_uv = "in_uv";
        const string strMVP = "MVP";
        public mat4 mvp;

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
			new vec3(-1.0f, -1.0f, 1.0f),	
			new vec3(1.0f, -1.0f, 1.0f),	
			new vec3(1.0f, 1.0f, 1.0f),	
			new vec3(-1.0f, 1.0f, 1.0f),	
			new vec3(-1.0f, -1.0f, -1.0f),
			new vec3(-1.0f, 1.0f, -1.0f),	
			new vec3(1.0f, 1.0f, -1.0f),	
			new vec3(1.0f, -1.0f, -1.0f),	
			new vec3(-1.0f, 1.0f, -1.0f),	
			new vec3(-1.0f, 1.0f, 1.0f),	
			new vec3(1.0f, 1.0f, 1.0f),	
			new vec3(1.0f, 1.0f, -1.0f),	
			new vec3(-1.0f, -1.0f, -1.0f),
			new vec3(1.0f, -1.0f, -1.0f),	
			new vec3(1.0f, -1.0f, 1.0f),	
			new vec3(-1.0f, -1.0f, 1.0f),	
			new vec3(1.0f, -1.0f, -1.0f),	
			new vec3(1.0f, 1.0f, -1.0f),	
			new vec3(1.0f, 1.0f, 1.0f),	
			new vec3(1.0f, -1.0f, 1.0f),	
			new vec3(-1.0f, -1.0f, -1.0f),
			new vec3(-1.0f, -1.0f, 1.0f),	
			new vec3(-1.0f, 1.0f, 1.0f),	
			new vec3(-1.0f, 1.0f, -1.0f),	
		};

        static readonly vec2[] uvs = new vec2[]
        {
            new vec2(0.0f, 0.0f),
            new vec2(1.0f, 0.0f),
            new vec2(1.0f, 1.0f),
            new vec2(0.0f, 1.0f),
            new vec2(1.0f, 0.0f),
            new vec2(1.0f, 1.0f),
            new vec2(0.0f, 1.0f),
            new vec2(0.0f, 0.0f),
            new vec2(0.0f, 1.0f),
            new vec2(0.0f, 0.0f),
            new vec2(1.0f, 0.0f),
            new vec2(1.0f, 1.0f),
            new vec2(1.0f, 1.0f),
            new vec2(0.0f, 1.0f),
            new vec2(0.0f, 0.0f),
            new vec2(1.0f, 0.0f),
            new vec2(1.0f, 0.0f),
            new vec2(1.0f, 1.0f),
            new vec2(0.0f, 1.0f),
            new vec2(0.0f, 0.0f),
            new vec2(0.0f, 0.0f),
            new vec2(1.0f, 0.0f),
            new vec2(1.0f, 1.0f),
            new vec2(0.0f, 1.0f),
        };
        private string textureFile;

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"DemoTexImage2D.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"DemoTexImage2D.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

        }

        protected void InitializeVAO(out uint[] vao, out DrawMode primitiveMode, out int vertexCount)
        {
            primitiveMode = DrawMode.Quads;
            vertexCount = positions.Length;

            vao = new uint[1];
            GL.GenVertexArrays(1, vao);
            GL.BindVertexArray(vao[0]);

            //  Create a vertex buffer for the vertex data.
            {
                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                var positionArray = new UnmanagedArray<vec3>(positions.Length);
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
            //  Create a vertex buffer for the uv data.
            {
                uint[] ids = new uint[1];
                GL.GenBuffers(1, ids);
                GL.BindBuffer(BufferTarget.ArrayBuffer, ids[0]);
                var uvArray = new UnmanagedArray<vec2>(uvs.Length);
                for (int i = 0; i < uvs.Length; i++)
                {
                    uvArray[i] = uvs[i];
                }

                uint uvLocation = shaderProgram.GetAttributeLocation(strin_uv);

                GL.BufferData(BufferTarget.ArrayBuffer, uvArray, BufferUsage.StaticDraw);
                GL.VertexAttribPointer(uvLocation, 2, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(uvLocation);

                uvArray.Dispose();
            }
            //  Unbind the vertex array, we've finished specifying data for it.
            GL.BindVertexArray(0);
        }

        protected override void DoInitialize()
        {
            InitializeTexture2D();

            InitializeShader(out shaderProgram);

            InitializeVAO(out vao, out primitiveMode, out vertexCount);

        }

        private void InitializeTexture2D()
        {
            this.tex = new Texture2D();
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(this.textureFile);
            this.tex.Initialize(bmp);
        }

        protected override void DoRender(RenderEventArgs e)
        {
            this.shaderProgram.Bind();
            this.shaderProgram.SetUniformMatrix4(strMVP, mvp.to_array());
            GL.ActiveTexture(GL.GL_TEXTURE0);
            GL.Enable(GL.GL_TEXTURE_2D);
            this.tex.Bind();
            this.shaderProgram.SetUniform(strtex, 0);//texture1.Name);
            GL.BindVertexArray(vao[0]);

            GL.DrawArrays(primitiveMode, 0, vertexCount);

            GL.BindVertexArray(0);

            this.tex.Unbind();
            this.shaderProgram.Unbind();
        }


        protected override void DisposeUnmanagedResources()
        {
            GL.DeleteVertexArrays(vao.Length, vao);
            this.shaderProgram.Delete();
        }
    }
}
