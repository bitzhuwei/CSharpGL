
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class fragcolorfrompos : _glSuperBible7code {
        ~fragcolorfrompos() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public fragcolorfrompos(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint currentProgram;
        GLuint program1;
        GLuint program2;
        GLuint vao;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/fragcolorfrompos.1.vert";
                var fsCodeFile = "media/shaders/fragcolorfrompos.1.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program1 = programObj.programId;
                gl.glUseProgram(this.program1);
                this.currentProgram = this.program1;

            }
            {
                var vsCodeFile = "media/shaders/fragcolorfrompos.2.vert";
                var fsCodeFile = "media/shaders/fragcolorfrompos.2.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program2 = programObj.programId;
                gl.glUseProgram(this.program2);

            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float t = 0;// time
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        static GLfloat[] green = { 0.0f, 0.25f, 0.0f, 1.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            t += 0.01f;

            var proj_matrix = this.proj_matrix;

            //fixed (float* p = green) {
            //    gl.glClearBufferfv(GL.GL_COLOR, 0, p);
            //}

            gl.glUseProgram(this.currentProgram);
            gl.glDrawArrays(GL.GL_TRIANGLES, 0, 3);
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
            case Keys.D1: this.currentProgram = this.program1; break;
            case Keys.D2: this.currentProgram = this.program2; break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.D1, Keys.D2];
        public override MouseButtons[] ValidButtons => [];

    }
}