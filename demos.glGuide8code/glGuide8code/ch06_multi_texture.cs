
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static demos.glGuide8code.vgl;

namespace demos.glGuide8code {

    public unsafe class ch06_multi_texture : _glGuide8code {
        ~ch06_multi_texture() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public ch06_multi_texture(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        // Member variables
        float aspect;
        GLuint base_prog;
        GLuint vao;

        GLuint quad_vbo;

        GLuint tex1;
        GLuint tex2;

        GLint time_loc;

        static GLfloat[] quad_data =
        {
         1.0f, -1.0f,
        -1.0f, -1.0f,
        -1.0f, 1.0f,
         1.0f, 1.0f,

         0.0f, 0.0f,
         1.0f, 0.0f,
         1.0f, 1.0f,
         0.0f, 1.0f
        };

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "06/ch06_multi_texture/quad_shader.vs.glsl";
                var fsCodeFile = "06/ch06_multi_texture/quad_shader.fs.glsl";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.base_prog = program.programId;
                gl.glUseProgram(this.base_prog);
                time_loc = gl.glGetUniformLocation(base_prog, "time");
                {
                    var loc = gl.glGetUniformLocation(base_prog, "tex1");
                    gl.glUniform1i(loc, 0);
                }
                {
                    var loc = gl.glGetUniformLocation(base_prog, "tex2");
                    gl.glUniform1i(loc, 1);
                }
            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenBuffers(1, id); quad_vbo = id[0];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, quad_vbo);

                fixed (GLfloat* p = quad_data) {
                    gl.glBufferData(GL.GL_ARRAY_BUFFER,
                        sizeof(GLfloat) * quad_data.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }

                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);

                gl.glVertexAttribPointer(0, 2, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                gl.glVertexAttribPointer(1, 2, GL.GL_FLOAT, false, 0, (IntPtr)(8 * sizeof(float)));

                gl.glEnableVertexAttribArray(0);
                gl.glEnableVertexAttribArray(1);
            }
            {
                var image = new vgl.vglImageData();
                //tex1 = vglLoadTexture("d:/svn/Vermilion-Book/trunk/Code/media/test.dds", 0, &image);
                vgl.vglLoadDDS("media/test.dds", ref image);
                var id = stackalloc GLuint[1];
                gl.glGenTextures(1, id); this.tex1 = id[0];
                gl.glBindTexture(image.target, this.tex1);
                vgl.vglLoadTexture(gl, ref image); var error = gl.glGetError();
                gl.glTexParameteri(image.target, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR_MIPMAP_LINEAR);
                vgl.vglUnloadImage(ref image);
            }
            {
                var image = new vgl.vglImageData();
                vgl.vglLoadDDS("media/test3.dds", ref image);
                var id = stackalloc GLuint[1];
                gl.glGenTextures(1, id); this.tex2 = id[0];
                gl.glBindTexture(image.target, this.tex2);
                vgl.vglLoadTexture(gl, ref image); var error = gl.glGetError();
                vgl.vglUnloadImage(ref image);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        public override void display(CSharpGL.GL gl) {

            //static const unsigned int start_time = GetTickCount();
            //float t = float((GetTickCount() - start_time)) / float(0x3FFF);
            float t = q; q += 0.01f;

            gl.glClearDepth(1.0f);
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            gl.glDisable(GL.GL_CULL_FACE);
            gl.glUseProgram(base_prog);

            gl.glUniform1f(time_loc, t);

            gl.glBindVertexArray(vao);
            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, tex1);
            gl.glActiveTexture(GL.GL_TEXTURE1);
            gl.glBindTexture(GL.GL_TEXTURE_2D, tex2);
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