
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static demos.glSuperBible7code.csflocking;

namespace demos.glSuperBible7code {

    public unsafe class dispmap : _glSuperBible7code {
        ~dispmap() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public dispmap(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint program;
        GLuint vao;
        GLuint tex_displacement;
        GLuint tex_color;
        float dmap_depth;
        bool enable_displacement;
        bool wireframe;
        bool enable_fog;
        bool paused;

        struct _uniforms {
            public GLint mvp_matrix;
            public GLint mv_matrix;
            public GLint proj_matrix;
            public GLint dmap_depth;
            public GLint enable_fog;
        }
        _uniforms uniforms;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/dispmap.vert";
                var tcCodeFile = "media/shaders/dispmap.tesc";
                var teCodeFile = "media/shaders/dispmap.tese";
                var fsCodeFile = "media/shaders/dispmap.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, tcCodeFile, teCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program = programObj.programId;
                gl.glUseProgram(this.program);

                uniforms.mv_matrix = gl.glGetUniformLocation(program, "mv_matrix");
                uniforms.mvp_matrix = gl.glGetUniformLocation(program, "mvp_matrix");
                uniforms.proj_matrix = gl.glGetUniformLocation(program, "proj_matrix");
                uniforms.dmap_depth = gl.glGetUniformLocation(program, "dmap_depth");
                uniforms.enable_fog = gl.glGetUniformLocation(program, "enable_fog");
                dmap_depth = 6.0f;
            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);

                gl.glPatchParameteri(GL.GL_PATCH_VERTICES, 4);

                gl.glEnable(GL.GL_CULL_FACE);

                tex_displacement = sb7ktx.load("media/textures/terragen1.ktx");
                gl.glActiveTexture(GL.GL_TEXTURE1);
                tex_color = sb7ktx.load("media/textures/terragen_color.ktx");
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
            time += 0.01f;

            var proj_matrix = this.proj_matrix;


            float t = (float)time * 0.03f;
            float r = (float)Math.Sin(t * 5.37f) * 15.0f + 16.0f;
            float h = (float)Math.Cos(t * 4.79f) * 2.0f + 3.2f;

            mat4 mv_matrix = /* glm.translate(0.0f, 0.0f, -1.4f) *
								glm.translate(0.0f, -0.4f, 0.0f) * */
                // glm.rotate((float)currentTime * 6.0f, 0.0f, 1.0f, 0.0f) *
                glm.lookAt(new vec3((float)Math.Sin(t) * r, h, (float)Math.Cos(t) * r), new vec3(0.0f), new vec3(0.0f, 1.0f, 0.0f));

            gl.glUseProgram(program);

            gl.glUniformMatrix4fv(uniforms.mv_matrix, 1, false, (float*)&mv_matrix);
            gl.glUniformMatrix4fv(uniforms.proj_matrix, 1, false, (float*)&proj_matrix);
            var mvp = proj_matrix * mv_matrix;
            gl.glUniformMatrix4fv(uniforms.mvp_matrix, 1, false, (float*)&mvp);
            gl.glUniform1f(uniforms.dmap_depth, enable_displacement ? dmap_depth : 0.0f);
            gl.glUniform1i(uniforms.enable_fog, enable_fog ? 1 : 0);

            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glDepthFunc(GL.GL_LEQUAL);

            if (wireframe)
                gl.glPolygonMode(GL.GL_FRONT_AND_BACK, GL.GL_LINE);
            else
                gl.glPolygonMode(GL.GL_FRONT_AND_BACK, GL.GL_FILL);
            gl.glDrawArraysInstanced(GL.GL_PATCHES, 0, 4, 64 * 64);
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
            case Keys.W:
            dmap_depth += 0.1f;
            break;
            case Keys.S:
            dmap_depth -= 0.1f;
            break;
            case Keys.F:
            enable_fog = !enable_fog;
            break;
            case Keys.D:
            enable_displacement = !enable_displacement;
            break;
            case Keys.G:
            wireframe = !wireframe;
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.W, Keys.S, Keys.F, Keys.D, Keys.G];
        public override MouseButtons[] ValidButtons => [];

    }
}