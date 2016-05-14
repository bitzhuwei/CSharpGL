using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{

    class ImageProcessingRenderer : RendererBase
    {
        private ShaderProgram computeProgram;
        private uint[] input_image = new uint[1];
        private uint[] intermediate_image = new uint[1];
        private uint[] output_image = new uint[1];
        private ShaderProgram visualProgram;
        private uint[] render_vao = new uint[1];
        private uint[] render_vbo = new uint[1];

        protected override void DoInitialize()
        {
            {
                var computeProgram = new ShaderProgram();
                var shaderCode = new ShaderCode(File.ReadAllText(@"Form06ImageProcessing\ImageProcessing.comp"), ShaderType.ComputeShader);
                var shader = shaderCode.CreateShader();
                computeProgram.Create(shader);
                shader.Delete();
                this.computeProgram = computeProgram;
            }
            {
                sampler2D texture = new sampler2D();
                texture.Initialize(new System.Drawing.Bitmap(@"Form06ImageProcessing\teapot.png"));
                this.input_image[0] = texture.Id;
            }
            {
                GL.GenTextures(1, intermediate_image);
                GL.BindTexture(GL.GL_TEXTURE_2D, intermediate_image[0]);
                GL.TexStorage2D(TexStorage2DTarget.Texture2D, 8, GL.GL_RGBA32F, 512, 512);

                // This is the texture that the compute program will write into
                GL.GenTextures(1, output_image);
                GL.BindTexture(GL.GL_TEXTURE_2D, output_image[0]);
                GL.TexStorage2D(TexStorage2DTarget.Texture2D, 8, GL.GL_RGBA32F, 512, 512);
            }
            {
                var visualProgram = new ShaderProgram();
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"Form06ImageProcessing\ImageProcessing.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"Form06ImageProcessing\ImageProcessing.frag"), ShaderType.FragmentShader);
                var shaders = (from item in shaderCodes select item.CreateShader()).ToArray();
                visualProgram.Create(shaders);
                foreach (var item in shaders) { item.Delete(); }
                this.visualProgram = visualProgram;
            }
            {
                GL.GetDelegateFor<GL.glGenVertexArrays>()(1, render_vao);
                GL.GetDelegateFor<GL.glBindVertexArray>()(render_vao[0]);
                GL.GetDelegateFor<GL.glEnableVertexAttribArray>()(0);
                // position
                GL.GetDelegateFor<GL.glGenBuffers>()(1, render_vbo);
                GL.BindBuffer(BufferTarget.ArrayBuffer, render_vbo[0]);
                var positions = new UnmanagedArray<vec4>(4);
                unsafe
                {
                    var array = (vec4*)positions.FirstElement();
                    array[0] = new vec4(-1.0f, -1.0f, 0.5f, 1.0f);
                    array[1] = new vec4(1.0f, -1.0f, 0.5f, 1.0f);
                    array[2] = new vec4(1.0f, 1.0f, 0.5f, 1.0f);
                    array[3] = new vec4(-1.0f, 1.0f, 0.5f, 1.0f);
                }
                GL.BufferData(BufferTarget.ArrayBuffer, positions, BufferUsage.StaticDraw);
                positions.Dispose();
                GL.GetDelegateFor<GL.glVertexAttribPointer>()(0, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            }

        }


        protected override void DoRender(RenderEventArgs arg)
        {
            // Activate the compute program and bind the output texture image
            computeProgram.Bind();
            GL.GetDelegateFor<GL.glBindImageTexture>()(0, input_image[0], 0, false, 0, GL.GL_READ_ONLY, GL.GL_RGBA32F);
            GL.GetDelegateFor<GL.glBindImageTexture>()(1, intermediate_image[0], 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32F);
            // Dispatch
            GL.GetDelegateFor<GL.glDispatchCompute>()(512, 1, 1);

            GL.GetDelegateFor<GL.glMemoryBarrier>()(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);

            GL.GetDelegateFor<GL.glBindImageTexture>()(0, intermediate_image[0], 0, false, 0, GL.GL_READ_ONLY, GL.GL_RGBA32F);
            GL.GetDelegateFor<GL.glBindImageTexture>()(1, output_image[0], 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32F);
            // Dispatch
            GL.GetDelegateFor<GL.glDispatchCompute>()(512, 1, 1);

            // Now bind the texture for rendering _from_
            GL.GetDelegateFor<GL.glActiveTexture>()(GL.GL_TEXTURE0);
            GL.BindTexture(GL.GL_TEXTURE_2D, output_image[0]);

            // Clear, select the rendering program and draw a full screen quad
            visualProgram.Bind();
            mat4 view = arg.Camera.GetViewMat4();
            mat4 projection = arg.Camera.GetProjectionMat4();
            visualProgram.SetUniformMatrix4("mvp", (projection * view).to_array());
            GL.GetDelegateFor<GL.glBindVertexArray>()(render_vao[0]);
            // glPointSize(2.0f);
            GL.DrawArrays(DrawMode.TriangleFan, 0, 4);
            visualProgram.Unbind();
        }

        protected override void DisposeUnmanagedResources()
        {
            computeProgram.Delete();
            GL.DeleteTextures(1, input_image);
            GL.DeleteTextures(1, intermediate_image);
            GL.DeleteTextures(1, output_image);
            IntPtr ptr = Win32.wglGetCurrentContext();
            if (ptr != IntPtr.Zero)
            {
                GL.GetDelegateFor<GL.glDeleteVertexArrays>()(1, render_vao);
            }
            GL.DeleteBuffers(1, render_vbo);
            visualProgram.Delete();
        }


    }
}