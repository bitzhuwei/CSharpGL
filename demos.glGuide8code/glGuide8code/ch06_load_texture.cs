
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static demos.glGuide8code.vgl;

namespace demos.glGuide8code {

    public unsafe class ch06_load_texture : _glGuide8code {
        ~ch06_load_texture() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
            gl.glUseProgram(0);
            gl.glDeleteProgram(base_prog);
            var id = tex;
            gl.glDeleteTextures(1, &id);
            id = vao;
            gl.glDeleteVertexArrays(1, &id);
        }

        public ch06_load_texture(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        // Member variables
        float aspect;
        GLuint base_prog;
        GLuint vao;

        GLuint quad_vbo;

        GLuint tex;

        static readonly GLfloat[] quad_data = {
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
                var vsCodeFile = "06/ch06_load_texture/quad_shader.vs.glsl";
                var fsCodeFile = "06/ch06_load_texture/quad_shader.fs.glsl";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.base_prog = program.programId;
                gl.glUseProgram(this.base_prog);

            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenBuffers(1, id); quad_vbo = id[0];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, quad_vbo);

                fixed (GLfloat* p = quad_data) {
                    gl.glBufferData(GL.GL_ARRAY_BUFFER, sizeof(GLfloat) * quad_data.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
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
                vgl.vglLoadDDS("media/test.dds", ref image);

                var id = stackalloc GLuint[1];
                gl.glGenTextures(1, id); this.tex = id[0];
                gl.glBindTexture(image.target, this.tex);
                vgl.vglLoadTexture(gl, ref image); var error = gl.glGetError();
                gl.glTexParameteri(image.target, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR_MIPMAP_LINEAR);

                vgl.vglUnloadImage(ref image);
            }
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            //float t = float(GetTickCount() & 0x3FFF) / float(0x3FFF);
            //static const vmath::vec3 X(1.0f, 0.0f, 0.0f);
            //static const vmath::vec3 Y(0.0f, 1.0f, 0.0f);
            //static const vmath::vec3 Z(0.0f, 0.0f, 1.0f);

            gl.glClearColor(0.0f, 1.0f, 0.0f, 1.0f);
            gl.glClearDepth(1.0f);
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            gl.glDisable(GL.GL_CULL_FACE);
            gl.glUseProgram(base_prog);

            gl.glBindVertexArray(vao);
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