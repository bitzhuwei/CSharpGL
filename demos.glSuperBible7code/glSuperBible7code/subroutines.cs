
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class subroutines : _glSuperBible7code {
        ~subroutines() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public subroutines(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        GLuint render_program;

        GLuint vao;

        GLuint[] _subroutines = new uint[2];

        struct _uniforms {
            public GLint subroutine1;
        }
        _uniforms uniforms;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/subroutines.vert";
                var fsCodeFile = "media/shaders/subroutines.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.render_program = programObj.programId;
                gl.glUseProgram(this.render_program);


                _subroutines[0] = gl.glGetSubroutineIndex(render_program, GL.GL_FRAGMENT_SHADER, "myFunction1");
                _subroutines[1] = gl.glGetSubroutineIndex(render_program, GL.GL_FRAGMENT_SHADER, "myFunction2");
                uniforms.subroutine1 = gl.glGetSubroutineUniformLocation(render_program, GL.GL_FRAGMENT_SHADER, "mySubroutineUniform");
            }
            {

                GLuint id;
                gl.glGenVertexArrays(1, &id); vao = id;
                gl.glBindVertexArray(vao);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float currentTime = 0;// time
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            currentTime += 0.01f;

            var proj_matrix = this.proj_matrix;

            int i = (int)(currentTime);

            gl.glUseProgram(render_program);

            {
                var value = _subroutines[i & 1];
                gl.glUniformSubroutinesuiv(GL.GL_FRAGMENT_SHADER, 1, &value);
            }

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