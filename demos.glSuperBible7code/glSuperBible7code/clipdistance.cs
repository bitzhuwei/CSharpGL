
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class clipdistance : _glSuperBible7code {
        ~clipdistance() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public clipdistance(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        sb7object sb7Obj = new sb7object();
        GLuint render_program;
        bool paused;

        struct _uniforms {
            public GLint proj_matrix;
            public GLint mv_matrix;
            public GLint clip_plane;
            public GLint clip_sphere;
        }
        _uniforms uniforms;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/clipdistance.vert";
                var fsCodeFile = "media/shaders/clipdistance.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.render_program = programObj.programId;
                gl.glUseProgram(this.render_program);

                uniforms.proj_matrix = gl.glGetUniformLocation(render_program, "proj_matrix");
                uniforms.mv_matrix = gl.glGetUniformLocation(render_program, "mv_matrix");
                uniforms.clip_plane = gl.glGetUniformLocation(render_program, "clip_plane");
                uniforms.clip_sphere = gl.glGetUniformLocation(render_program, "clip_sphere");
            }

            sb7Obj.load("media/objects/dragon.sbm");
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float time = 0;
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            time += 0.01f;

            gl.glUseProgram(render_program);

            //mv_matrix = glm.translate(mv_matrix, 0.0f, -4.0f, 0.0f);
            //mv_matrix = glm.rotate(mv_matrix, time * 0.34f, 0.0f, 1.0f, 0.0f);
            //mv_matrix = glm.translate(mv_matrix, 0.0f, 0.0f, -15.0f);
            var position = (glm.rotate(time * 50, new vec3(0, 1, 0)) * (new vec4(5, 4, 4, 1)));
            var mv_matrix = glm.lookAt(new vec3(position) * 3, new vec3(0, 0, 0), new vec3(0, 1, 0));

            var plane_matrix = glm.rotate(time * 7.3f, 0.0f, 1.0f, 0.0f)
                * glm.rotate(time * 6.0f, 1.0f, 0.0f, 0.0f);

            vec4 plane = plane_matrix[0];
            plane[3] = 0.0f; plane = plane.normalize();

            vec4 clip_sphere = new vec4(
                (float)Math.Sin(time * 0.7f) * 3.0f,
                (float)Math.Cos(time * 1.9f) * 3.0f,
                (float)Math.Sin(time * 0.1f) * 3.0f,
                (float)Math.Cos(time * 1.7f) + 2.5f);

            var proj_matrix = this.proj_matrix;
            gl.glUniformMatrix4fv(uniforms.proj_matrix, 1, false, (float*)&proj_matrix);
            gl.glUniformMatrix4fv(uniforms.mv_matrix, 1, false, (float*)&mv_matrix);
            gl.glUniform4fv(uniforms.clip_plane, 1, (float*)&plane);
            gl.glUniform4fv(uniforms.clip_sphere, 1, (float*)&clip_sphere);

            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glEnable(GL.GL_CLIP_DISTANCE0);
            gl.glEnable(GL.GL_CLIP_DISTANCE1);

            sb7Obj.render();
        }

        mat4 proj_matrix;
        public override void reshape(CSharpGL.GL gl, int width, int height) {
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