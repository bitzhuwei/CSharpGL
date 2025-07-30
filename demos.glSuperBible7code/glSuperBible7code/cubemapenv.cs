
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static demos.glSuperBible7code.csflocking;

namespace demos.glSuperBible7code {

    public unsafe class cubemapenv : _glSuperBible7code {
        ~cubemapenv() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public cubemapenv(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint render_prog;
        GLuint skybox_prog;

        GLuint tex_envmap;
        int envmap_index;

        struct _uniforms {
            public struct _render {
                public GLint mv_matrix;
                public GLint proj_matrix;
            }
            public _render render;
            public struct _skybox {
                public GLint view_matrix;
            }
            public _skybox skybox;
        }
        _uniforms uniforms;

        sb7object sb7Obj = new sb7object();

        GLuint skybox_vao;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/cubemapenv.render.vert";
                var fsCodeFile = "media/shaders/cubemapenv.render.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.render_prog = programObj.programId;
                gl.glUseProgram(this.render_prog);

                uniforms.render.mv_matrix = gl.glGetUniformLocation(render_prog, "mv_matrix");
                uniforms.render.proj_matrix = gl.glGetUniformLocation(render_prog, "proj_matrix");
            }
            {
                var vsCodeFile = "media/shaders/cubemapenv.skybox.vert";
                var fsCodeFile = "media/shaders/cubemapenv.skybox.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.skybox_prog = programObj.programId;
                gl.glUseProgram(this.skybox_prog);

                uniforms.skybox.view_matrix = gl.glGetUniformLocation(skybox_prog, "view_matrix");
            }
            {
                tex_envmap = sb7ktx.load("media/textures/mountaincube.ktx");

                gl.glTexParameteri(GL.GL_TEXTURE_CUBE_MAP, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
                gl.glTexParameteri(GL.GL_TEXTURE_CUBE_MAP, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);

                gl.glEnable(GL.GL_TEXTURE_CUBE_MAP_SEAMLESS);

                sb7Obj.load("media/objects/dragon.sbm");

                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); skybox_vao = id[0];
                gl.glBindVertexArray(skybox_vao);

                gl.glDepthFunc(GL.GL_LEQUAL);
            }
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

            var proj_matrix = this.proj_matrix;
            var position = glm.rotate(time * 50, new vec3(0, 1, 0)) * new vec4(5, 4, 4, 1);
            var view_matrix = glm.lookAt(
                //new vec3(15.0f * (float)Math.Sin(time), 10.0f, 15.0f * (float)Math.Cos(time)),
                new vec3(position) * 3,
                new vec3(0.0f, 0.0f, 0.0f),
                new vec3(0.0f, 1.0f, 0.0f));
            var mv_matrix = view_matrix;
            //vmath::rotate(t, 1.0f, 0.0f, 0.0f) *
            //vmath::rotate(t * 130.1f, 0.0f, 1.0f, 0.0f) *
            //vmath::translate(0.0f, -4.0f, 0.0f);

            gl.glBindTexture(GL.GL_TEXTURE_CUBE_MAP, tex_envmap);

            gl.glUseProgram(skybox_prog);
            gl.glBindVertexArray(skybox_vao);

            gl.glUniformMatrix4fv(uniforms.skybox.view_matrix, 1, false, (float*)&view_matrix);

            gl.glDisable(GL.GL_DEPTH_TEST);

            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);
            gl.glUseProgram(render_prog);

            gl.glUniformMatrix4fv(uniforms.render.mv_matrix, 1, false, (float*)&mv_matrix);
            gl.glUniformMatrix4fv(uniforms.render.proj_matrix, 1, false, (float*)&proj_matrix);

            gl.glEnable(GL.GL_DEPTH_TEST);

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