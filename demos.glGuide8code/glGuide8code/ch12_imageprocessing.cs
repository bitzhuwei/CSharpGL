
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch12_imageprocessing : _glGuide8code {
        ~ch12_imageprocessing() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public ch12_imageprocessing(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        float aspect;

        // Member variables
        GLuint compute_prog;
        GLuint compute_shader;

        // Texture to process
        GLuint input_image;

        // Texture for compute shader to write into
        GLuint intermediate_image;
        GLuint output_image;

        // Program, vao and vbo to render a full screen quad
        GLuint render_prog;
        GLuint render_vao;
        GLuint render_vbo;

        static readonly float[] verts = {
        -1.0f, -1.0f, 0.5f, 1.0f,
         1.0f, -1.0f, 0.5f, 1.0f,
         1.0f,  1.0f, 0.5f, 1.0f,
        -1.0f,  1.0f, 0.5f, 1.0f,
        };
        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "12/ch12_imageprocessing/imageProc.comp";
                var program = Utility.LoadShaders((vsCodeFile, Shader.Kind.comp));
                Debug.Assert(program != null); this.compute_prog = program.programId;
                gl.glUseProgram(this.compute_prog);
            }
            {
                // Load a texture to process
                //input_image =vgl.vglLoadTexture vglLoadTexture("D:/svn/Vermilion-Book/trunk/Code/media/curiosity.dds", 0, NULL);
                var image = new vgl.vglImageData();
                vgl.vglLoadDDS("media/test2.dds", ref image);
                var id = stackalloc GLuint[1];
                gl.glGenTextures(1, id); this.input_image = id[0];
                gl.glBindTexture(image.target, this.input_image);
                vgl.vglLoadTexture(gl, ref image); var error = gl.glGetError();
                vgl.vglUnloadImage(ref image);

                gl.glGenTextures(1, id); intermediate_image = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D, intermediate_image);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 8, GL.GL_RGBA32F, 1024, 1024);

                // This is the texture that the compute program will write into
                gl.glGenTextures(1, id); output_image = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D, output_image);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 8, GL.GL_RGBA32F, 1024, 1024);
            }
            {
                var vsCodeFile = "12/ch12_imageprocessing/render.vert";
                var fsCodeFile = "12/ch12_imageprocessing/render.frag";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.render_prog = program.programId;
                gl.glUseProgram(this.render_prog);
            }
            {
                var id = stackalloc GLuint[1];
                // This is the VAO containing the data to draw the quad (including its associated VBO)
                gl.glGenVertexArrays(1, id); render_vao = id[0];
                gl.glBindVertexArray(render_vao);
                gl.glEnableVertexAttribArray(0);
                gl.glGenBuffers(1, id); render_vbo = id[0];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, render_vbo);
                fixed (float* p = verts) {
                    gl.glBufferData(GL.GL_ARRAY_BUFFER,
                        sizeof(float) * verts.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }
                gl.glVertexAttribPointer(0, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        public override void display(CSharpGL.GL gl) {
            // Activate the compute program and bind the output texture image
            gl.glUseProgram(compute_prog);
            gl.glBindImageTexture(0, input_image, 0, false, 0, GL.GL_READ_ONLY, GL.GL_RGBA32F);
            gl.glBindImageTexture(1, intermediate_image, 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32F);
            gl.glDispatchCompute(1, 1024, 1);

            gl.glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);

            gl.glBindImageTexture(0, intermediate_image, 0, false, 0, GL.GL_READ_ONLY, GL.GL_RGBA32F);
            gl.glBindImageTexture(1, output_image, 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32F);
            gl.glDispatchCompute(1, 1024, 1);

            // Now bind the texture for rendering _from_
            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, output_image);

            // Clear, select the rendering program and draw a full screen quad
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glUseProgram(render_prog);
            gl.glDrawArrays(GL.GL_TRIANGLE_FAN, 0, 4);
        }

        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);

            aspect = (float)height / (float)width;
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }

        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [];
        public override MouseButtons[] ValidButtons => [];

    }
}