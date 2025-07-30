
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class shapedpoints : _glSuperBible7code {
        ~shapedpoints() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public shapedpoints(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int NUM_STARS = 2000;
        GLuint render_prog;
        GLuint render_vao;
        //GLint shapeLoc;
        //int shape = 0;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/shapedpoints.vert";
                var fsCodeFile = "media/shaders/shapedpoints.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.render_prog = programObj.programId;
                gl.glUseProgram(this.render_prog);
                //shapeLoc = gl.glGetUniformLocation(this.render_prog, "shape");
            }
            {
                GLuint id;
                gl.glGenVertexArrays(1, &id); render_vao = id;
                gl.glBindVertexArray(render_vao);

                gl.glEnable(GL.GL_POINT_SPRITE);
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
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            t += 0.01f;

            var proj_matrix = this.proj_matrix;

            gl.glUseProgram(render_prog);
            //gl.glUniform1i(shapeLoc, this.shape);

            gl.glPointSize(100.0f);
            gl.glBindVertexArray(render_vao);
            gl.glDrawArrays(GL.GL_POINTS, 0, 4);
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
            //case Keys.M:
            //this.shape = (this.shape + 1) % 4;
            //break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [];
        public override MouseButtons[] ValidButtons => [];


        // Random number generator
        static uint seed = 0x13371337;

        static float random_float() {
            float res;
            uint tmp;

            seed *= 16807;

            tmp = seed ^ (seed >> 4) ^ (seed << 15);

            *((uint*)&res) = (tmp >> 9) | 0x3F800000;

            return (res - 1.0f);
        }
    }
}