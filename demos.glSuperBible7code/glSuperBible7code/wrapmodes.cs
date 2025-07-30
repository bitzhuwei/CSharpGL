
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class wrapmodes : _glSuperBible7code {
        ~wrapmodes() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public wrapmodes(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint texture;
        GLuint program;
        GLuint vao;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/wrapmodes.vert";
                var fsCodeFile = "media/shaders/wrapmodes.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program = programObj.programId;
                gl.glUseProgram(this.program);

            }
            {
                // Load texture from file
                texture = sb7ktx.load("media/textures/rightarrows.ktx");

                // Now bind it to the context using the GL.GL_TEXTURE_2D binding point
                gl.glBindTexture(GL.GL_TEXTURE_2D, texture);

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
        float t = 0;// time
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        static GLenum[] _wrapmodes = { GL.GL_CLAMP_TO_EDGE, GL.GL_REPEAT, GL.GL_CLAMP_TO_BORDER, GL.GL_MIRRORED_REPEAT };

        static float[] offsets = {
            -0.5f, -0.5f,
            0.5f, -0.5f,
            -0.5f,  0.5f,
            0.5f,  0.5f
        };
        static GLfloat[] yellow = { 0.4f, 0.4f, 0.0f, 1.0f };

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            t += 0.01f;

            var proj_matrix = this.proj_matrix;


            gl.glUseProgram(program);
            //gl.glViewport(0, 0, this.width, this.height);

            gl.glTexParameterfv(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_BORDER_COLOR, yellow);

            for (int i = 0; i < 4; i++) {
                {
                    var value = offsets[i * 2];
                    gl.glUniform2fv(0, 1, (float*)&value);
                }
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)_wrapmodes[i]);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)_wrapmodes[i]);

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