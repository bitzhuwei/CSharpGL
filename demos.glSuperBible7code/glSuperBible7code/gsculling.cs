
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class gsculling : _glSuperBible7code {
        ~gsculling() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public gsculling(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint program;
        GLint mv_location;
        GLint mvp_location;
        GLint viewpoint_location;

        sb7object sb7Obj = new sb7object();

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/gsculling.vert";
                var gsCodeFile = "media/shaders/gsculling.geom";
                var fsCodeFile = "media/shaders/gsculling.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, gsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program = programObj.programId;
                gl.glUseProgram(this.program);

                mv_location = gl.glGetUniformLocation(program, "mvMatrix");
                mvp_location = gl.glGetUniformLocation(program, "mvpMatrix");
                viewpoint_location = gl.glGetUniformLocation(program, "viewpoint");

            }
            {
                sb7Obj.load("media/objects/dragon.sbm");

                gl.glDisable(GL.GL_CULL_FACE);

                gl.glEnable(GL.GL_DEPTH_TEST);
                gl.glDepthFunc(GL.GL_LEQUAL);
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


            gl.glUseProgram(program);

            mat4 mv_matrix = glm.translate(0.0f, 0.0f, -20.0f) *
                glm.rotate((float)currentTime * 5.0f, 0.0f, 1.0f, 0.0f) *
                glm.rotate((float)currentTime * 100.0f, 1.0f, 0.0f, 0.0f);

            var mvp = proj_matrix * mv_matrix;
            gl.glUniformMatrix4fv(mvp_location, 1, false, (float*)&mvp);

            gl.glUniformMatrix4fv(mv_location, 1, false, (float*)&mv_matrix);

            GLfloat[] vViewpoint = {
                (float)Math.Sin(currentTime * 2.1f) * 70.0f,
                (float)Math.Cos(currentTime * 1.4f) * 70.0f,
                (float)Math.Sin(currentTime * 0.7f) * 70.0f
            };
            fixed (float* p = vViewpoint) {
                gl.glUniform3fv(viewpoint_location, 1, p);
            }

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