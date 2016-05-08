using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{
    class SimpleComputeRenderer : RendererBase
    {
        private ShaderProgram computeProgram;
        private uint[] output_image = new uint[1];
        private ShaderProgram visualProgram;
        private uint[] render_vao = new uint[1];
        private uint[] render_vbo = new uint[1];

        static readonly float[] vertsData = new float[]
        {
            -1.0f, -1.0f, 0.5f, 1.0f,
             1.0f, -1.0f, 0.5f, 1.0f,
             1.0f,  1.0f, 0.5f, 1.0f,
            -1.0f,  1.0f, 0.5f, 1.0f,
        };

        UnmanagedArray<float> verts = new UnmanagedArray<float>(16);

        protected override void DoInitialize()
        {
            {
                // Initialize our compute program
                var computeProgram = new ShaderProgram();
                var shaderCode = new ShaderCode(File.ReadAllText(@"Shaders\compute.comp"), ShaderType.ComputeShader);
                Shader shader = shaderCode.CreateShader();
                computeProgram.Create(shader);
                shader.Delete();
                this.computeProgram = computeProgram;
            }
            {
                // This is the texture that the compute program will write into
                GL.GenTextures(1, output_image);
                GL.BindTexture(GL.GL_TEXTURE_2D, output_image[0]);
                GL.TexStorage2D(TexStorage2DTarget.Texture2D, 8, GL.GL_RGBA32F, 256, 256);
            }
            {
                // Now create a simple program to visualize the result
                var visualProgram = new ShaderProgram();
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"Shaders\compute.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"Shaders\compute.frag"), ShaderType.FragmentShader);
                var shaders = (from item in shaderCodes select item.CreateShader()).ToArray();
                visualProgram.Create(shaders);
                foreach (var item in shaders) { item.Delete(); }
                this.visualProgram = visualProgram;
            }
            {
                // This is the VAO containing the data to draw the quad (including its associated VBO)
                GL.GetDelegateFor<GL.glGenVertexArrays>()(1, render_vao);
                GL.GetDelegateFor<GL.glBindVertexArray>()(render_vao[0]);
                GL.GetDelegateFor<GL.glEnableVertexAttribArray>()(0);
                GL.GetDelegateFor<GL.glGenBuffers>()(1, render_vbo);
                GL.BindBuffer(BufferTarget.ArrayBuffer, render_vbo[0]);
                for (int i = 0; i < vertsData.Length; i++)
                {
                    verts[i] = vertsData[i];
                }
                GL.BufferData(BufferTarget.ArrayBuffer, verts, BufferUsage.StaticDraw);
                GL.GetDelegateFor<GL.glVertexAttribPointer>()(0, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            }
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            // Activate the compute program and bind the output texture image
            computeProgram.Bind();
            GL.GetDelegateFor<GL.glBindImageTexture>()(0, output_image[0], 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32F);
            GL.GetDelegateFor<GL.glDispatchCompute>()(8, 16, 1);
            //computeProgram.Unbind();

            // Now bind the texture for rendering _from_
            GL.BindTexture(GL.GL_TEXTURE_2D, output_image[0]);

            // Clear, select the rendering program and draw a full screen quad
            //GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            visualProgram.Bind();

            //mat4 model = mat4.identity();
            //mat4 view = arg.Camera.GetViewMat4();
            //mat4 projection = arg.Camera.GetProjectionMat4();
            //visualProgram.SetUniformMatrix4("modelMatrix", model.to_array());
            //visualProgram.SetUniformMatrix4("viewMatrix", view.to_array());
            //visualProgram.SetUniformMatrix4("projectionMatrix", projection.to_array());

            GL.DrawArrays(DrawMode.TriangleFan, 0, 4);
            visualProgram.Unbind();

            //GL.BindTexture(GL.GL_TEXTURE_2D, 0);
        }

        protected override void DisposeUnmanagedResources()
        {
            computeProgram.Delete();
            GL.DeleteTextures(1, output_image);
            visualProgram.Delete();
            IntPtr ptr = Win32.wglGetCurrentContext();
            if (ptr != IntPtr.Zero)
            {
                GL.GetDelegateFor<GL.glDeleteVertexArrays>()(1, render_vao);
            }
            GL.DeleteBuffers(1, render_vbo);
        }

    }
}
