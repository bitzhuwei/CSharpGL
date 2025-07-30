
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class hqfilter : _glSuperBible7code {
        ~hqfilter() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public hqfilter(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint draw_tex_program;
        GLuint dummy_vao;
        GLuint source_tex;
        bool paused;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/hqfilter.vert";
                var fsCodeFile = "media/shaders/hqfilter.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.draw_tex_program = programObj.programId;
                gl.glUseProgram(this.draw_tex_program);

            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); dummy_vao = id[0];
                gl.glBindVertexArray(dummy_vao);

                //source_tex = sb7ktx.load("media/textures/baboon.ktx");
                source_tex = sb7ktx.load("media/textures/rocks.ktx");
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float total_time = 0;// time
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            total_time += 0.01f;

            var proj_matrix = this.proj_matrix;

            //gl.glViewport(0, 0, this.width, this.height);
            //gl.glClearBufferfv(GL.GL_COLOR, 0, gray);
            //gl.glClearBufferfv(GL.GL_DEPTH, 0, &one);

            gl.glUseProgram(draw_tex_program);

            //Sleep(20);

            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, source_tex);
            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);
        }

        int width, height;
        mat4 proj_matrix;
        public override void reshape(CSharpGL.GL gl, int width, int height) {
            this.width = width; this.height = height;
            gl.glViewport(0, 0, width, height);

            //aspect = (float)height / (float)width;
            this.proj_matrix = glm.perspective(50.0f * (float)Math.PI / 180.0f, (float)width / (float)height, 0.1f, 1000.0f);
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