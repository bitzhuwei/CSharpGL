
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static demos.glSuperBible7code.csflocking;

namespace demos.glSuperBible7code {

    public unsafe class toonshading : _glSuperBible7code {
        ~toonshading() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public toonshading(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint render_prog;

        GLuint tex_toon;

        struct _uniforms {
            public GLint mv_matrix;
            public GLint proj_matrix;
        }
        _uniforms uniforms;

        sb7object sb7Obj = new sb7object();

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/toonshading.vert";
                var fsCodeFile = "media/shaders/toonshading.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.render_prog = programObj.programId;
                gl.glUseProgram(this.render_prog);

                uniforms.mv_matrix = gl.glGetUniformLocation(render_prog, "mv_matrix");
                uniforms.proj_matrix = gl.glGetUniformLocation(render_prog, "proj_matrix");
            }
            {
                GLuint id;
                gl.glGenTextures(1, &id); tex_toon = id;
                gl.glBindTexture(GL.GL_TEXTURE_1D, tex_toon);

                gl.glTexStorage1D(GL.GL_TEXTURE_1D, 1, GL.GL_RGB8, sizeof(GLubyte) * toon_tex_data.Length / 4);
                fixed (GLubyte* p = toon_tex_data) {
                    gl.glTexSubImage1D(GL.GL_TEXTURE_1D, 0, 0,
                        sizeof(GLubyte) * toon_tex_data.Length / 4, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE,
                        (IntPtr)p);
                }
                gl.glTexParameteri(GL.GL_TEXTURE_1D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);
                gl.glTexParameteri(GL.GL_TEXTURE_1D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST);
                gl.glTexParameteri(GL.GL_TEXTURE_1D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_EDGE);

                sb7Obj.load("media/objects/torus_nrms_tc.sbm");

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

            gl.glBindTexture(GL.GL_TEXTURE_1D, tex_toon);

            gl.glUseProgram(render_prog);

            mat4 mv_matrix = glm.translate(0.0f, 0.0f, -3.0f) *
                glm.rotate((float)currentTime * 13.75f, 0.0f, 1.0f, 0.0f) *
                glm.rotate((float)currentTime * 7.75f, 0.0f, 0.0f, 1.0f) *
                glm.rotate((float)currentTime * 15.3f, 1.0f, 0.0f, 0.0f);

            gl.glUniformMatrix4fv(uniforms.mv_matrix, 1, false, (float*)&mv_matrix);
            gl.glUniformMatrix4fv(uniforms.proj_matrix, 1, false, (float*)&proj_matrix);

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

        static GLubyte[] toon_tex_data = {
            0x44, 0x00, 0x00, 0x00,
            0x88, 0x00, 0x00, 0x00,
            0xCC, 0x00, 0x00, 0x00,
            0xFF, 0x00, 0x00, 0x00
        };
    }
}