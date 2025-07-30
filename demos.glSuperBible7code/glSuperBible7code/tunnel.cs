
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static demos.glSuperBible7code.csflocking;

namespace demos.glSuperBible7code {

    public unsafe class tunnel : _glSuperBible7code {
        ~tunnel() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public tunnel(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint render_prog;
        GLuint render_vao;
        struct _uniforms {
            public GLint mvp;
            public GLint offset;
        }
        _uniforms uniforms;

        GLuint tex_wall;
        GLuint tex_ceiling;
        GLuint tex_floor;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/tunnel.vert";
                var fsCodeFile = "media/shaders/tunnel.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.render_prog = programObj.programId;
                gl.glUseProgram(this.render_prog);

                uniforms.mvp = gl.glGetUniformLocation(render_prog, "mvp");
                uniforms.offset = gl.glGetUniformLocation(render_prog, "offset");
            }
            {
                GLuint id;
                gl.glGenVertexArrays(1, &id); render_vao = id;
                gl.glBindVertexArray(render_vao);

                tex_wall = sb7ktx.load("media/textures/brick.ktx");
                tex_ceiling = sb7ktx.load("media/textures/ceiling.ktx");
                tex_floor = sb7ktx.load("media/textures/floor.ktx");

                GLuint[] textures = { tex_floor, tex_wall, tex_ceiling };

                for (var i = 0; i < 3; i++) {
                    gl.glBindTexture(GL.GL_TEXTURE_2D, textures[i]);
                    gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR_MIPMAP_LINEAR);
                    gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
                }

                gl.glBindVertexArray(render_vao);
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

            gl.glUniform1f(uniforms.offset, t * 0.003f);

            GLuint[] textures = { tex_wall, tex_floor, tex_wall, tex_ceiling };
            for (var i = 0; i < 4; i++) {
                mat4 mv_matrix =
                    glm.rotate(90.0f * (float)i, new vec3(0.0f, 0.0f, 1.0f)) *
                    glm.translate(-0.5f, 0.0f, -10.0f) *
                    glm.rotate(90.0f, 0.0f, 1.0f, 0.0f) *
                    glm.scale(30.0f, 1.0f, 1.0f);
                mat4 mvp = proj_matrix * mv_matrix;

                gl.glUniformMatrix4fv(uniforms.mvp, 1, false, (float*)&mvp);

                gl.glBindTexture(GL.GL_TEXTURE_2D, textures[i]);
                gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);
            }
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