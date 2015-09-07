using CSharpGL;
using GLM;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using Picture.DDS;
using RedBook.Common;
using RedBook.Common.LightingExample;
using System;
using System.Text;

namespace RedBook.Winforms.Demo
{
    class LoadTextureExample : SceneElementBase, IDisposable
    {
        const string quad_shader_vs =
   @"#version 330 core

layout (location = 0) in vec2 in_position;
layout (location = 1) in vec2 in_tex_coord;

out vec2 tex_coord;

void main(void)
{
    gl_Position = vec4(in_position, 0.5, 1.0);
    tex_coord = in_tex_coord;
}";

        const string quad_shader_fs =
@"#version 330 core

in vec2 tex_coord;

layout (location = 0) out vec4 color;

uniform sampler2D tex;

void main(void)
{
    color = texture(tex, tex_coord);
}";

        public virtual void Reshape(int width, int height)
        {
            GL.Viewport(0, 0, width, height);
        }

        // Member variables
        float aspect;
        uint base_prog;
        uint[] vao = new uint[1];

        uint[] quad_vbo = new uint[1];

        uint tex;
        // Object to render
        VBObject vboObject = new VBObject();


        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        } // end sub

        /// <summary>
        /// Destruct instance of the class.
        /// </summary>
        ~LoadTextureExample()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Backing field to track whether Dispose has been called.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Dispose managed and unmanaged resources of this instance.
        /// </summary>
        /// <param name="disposing">If disposing equals true, managed and unmanaged resources can be disposed. If disposing equals false, only unmanaged resources can be disposed. </param>
        protected virtual void Dispose(bool disposing)
        {

            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // TODO: Dispose managed resources.
                    this.vboObject.Dispose();
                } // end if

                // TODO: Dispose unmanaged resources.
            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion

        protected override void DoInitialize()
        {
            base_prog = GL.CreateProgram();

            ShaderHelper.vglAttachShaderSource(base_prog, ShaderType.VertexShader, quad_shader_vs);
            ShaderHelper.vglAttachShaderSource(base_prog, ShaderType.FragmentShader, quad_shader_fs);

            GL.GenBuffers(1, quad_vbo);
            GL.BindBuffer(BufferTarget.ArrayBuffer, quad_vbo[0]);

            var quad_data = new UnmanagedArray<vec2>(8);
            quad_data[0] = new vec2(1.0f, -1.0f);
            quad_data[1] = new vec2(-1.0f, -1.0f);
            quad_data[2] = new vec2(-1.0f, 1.0f);
            quad_data[3] = new vec2(1.0f, 1.0f);
            quad_data[4] = new vec2(0.0f, 0.0f);
            quad_data[5] = new vec2(1.0f, 0.0f);
            quad_data[6] = new vec2(1.0f, 1.0f);
            quad_data[7] = new vec2(0.0f, 1.0f);

            GL.BufferData(BufferTarget.ArrayBuffer, quad_data, BufferUsage.StaticDraw);

            GL.GenVertexArrays(1, vao);
            GL.BindVertexArray(vao[0]);

            GL.VertexAttribPointer(0, 2, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            GL.VertexAttribPointer(1, 2, GL.GL_FLOAT, false, 0, new IntPtr(8 * sizeof(float)));

            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);

            GL.LinkProgram(base_prog);

            StringBuilder buf = new StringBuilder(1024);
            GL.GetProgramInfoLog(base_prog, 1024, IntPtr.Zero, buf);

            vglImageData image = new vglImageData();

            tex = vgl.vglLoadTexture(@"media\test.dds", 0, ref image);

            GL.TexParameteri(image.target, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR_MIPMAP_LINEAR);

            vgl.vglUnloadImage(ref image);
        }

        static float factor = 0x3FFF;

        static readonly vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static readonly vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static readonly vec3 Z = new vec3(0.0f, 0.0f, 1.0f);

        protected override void DoRender(RenderEventArgs e)
        {
            float t = (float)(TimerHelper.GetTickCount() & 0x3FFF) / factor;


            //GL.ClearColor(0.0f, 1.0f, 0.0f, 1.0f);
            //GL.ClearDepth(1.0f);
            //GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            GL.Disable(GL.GL_CULL_FACE);
            GL.UseProgram(base_prog);

            GL.BindVertexArray(vao[0]);
            GL.DrawArrays(GL.GL_TRIANGLE_FAN, 0, 4);
        }

    }
}
