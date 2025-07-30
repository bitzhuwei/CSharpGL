
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class rimlight : _glSuperBible7code {
        ~rimlight() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public rimlight(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint program;
        struct _uniforms {
            public GLint mv_matrix;
            public GLint proj_matrix;
            public GLint rim_color;
            public GLint rim_power;
        }
        _uniforms uniforms;

        mat4 mat_rotation;

        sb7object sb7Obj = new sb7object();
        bool paused;
        vec3 rim_color = new vec3(0.3f, 0.3f, 0.3f);
        float rim_power = 2.5f;
        bool rim_enable;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/rimlight.vert";
                var fsCodeFile = "media/shaders/rimlight.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program = programObj.programId;
                gl.glUseProgram(this.program);

                uniforms.mv_matrix = gl.glGetUniformLocation(program, "mv_matrix");
                uniforms.proj_matrix = gl.glGetUniformLocation(program, "proj_matrix");
                uniforms.rim_color = gl.glGetUniformLocation(program, "rim_color");
                uniforms.rim_power = gl.glGetUniformLocation(program, "rim_power");
            }
            {

                sb7Obj.load("media/objects/dragon.sbm");

                gl.glEnable(GL.GL_CULL_FACE);
                //glCullFace(GL.GL_FRONT);

                gl.glEnable(GL.GL_DEPTH_TEST);
                gl.glDepthFunc(GL.GL_LEQUAL);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float time = 0;// time
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            time += 0.1f;

            var proj_matrix = this.proj_matrix;

            gl.glUseProgram(program);

            gl.glUniformMatrix4fv(uniforms.proj_matrix, 1, false, (float*)&proj_matrix);

            mat4 mv_matrix = glm.translate(0.0f, -5.0f, -20.0f) *
                glm.rotate(time * 5.0f, 0.0f, 1.0f, 0.0f) *
                mat4.identity();
            gl.glUniformMatrix4fv(uniforms.mv_matrix, 1, false, (float*)&mv_matrix);

            {
                var value = rim_enable ? rim_color : new vec3(0.0f);
                gl.glUniform3fv(uniforms.rim_color, 1, (float*)&value);
            }
            gl.glUniform1f(uniforms.rim_power, rim_power);

            sb7Obj.render();
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
            case Keys.Q:
            rim_color[0] += 0.1f;
            break;
            case Keys.W:
            rim_color[1] += 0.1f;
            break;
            case Keys.E:
            rim_color[2] += 0.1f;
            break;
            case Keys.R:
            rim_power *= 1.5f;
            break;
            case Keys.A:
            rim_color[0] -= 0.1f;
            break;
            case Keys.S:
            rim_color[1] -= 0.1f;
            break;
            case Keys.D:
            rim_color[2] -= 0.1f;
            break;
            case Keys.F:
            rim_power /= 1.5f;
            break;
            case Keys.Z:
            rim_enable = !rim_enable;
            break;
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