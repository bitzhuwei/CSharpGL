
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch06_static_texture : _glGuide8code {
        ~ch06_static_texture() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public ch06_static_texture(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        // Member variables
        float aspect;
        GLuint base_prog;
        GLuint vao;

        GLuint quad_vbo;

        GLuint tex;

        static GLfloat[] quad_data =
        {
         0.75f, -0.75f,
        -0.75f, -0.75f,
        -0.75f, 0.75f,
         0.75f, 0.75f,

         0.0f, 0.0f,
         1.0f, 0.0f,
         1.0f, 1.0f,
         0.0f, 1.0f
        };
        static byte[] texture_data =
        {
        0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00,
        0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF,
        0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00,
        0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF,
        0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00,
        0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF,
        0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00,
        0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF
        };
        static GLint[] swizzles = { (GLint)GL.GL_RED, (GLint)GL.GL_RED, (GLint)GL.GL_RED, (GLint)GL.GL_ONE };

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "06/ch06_static_texture/quad_shader.vs.glsl";
                var fsCodeFile = "06/ch06_static_texture/quad_shader.fs.glsl";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.base_prog = program.programId;
                gl.glUseProgram(this.base_prog);

            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenBuffers(1, id); quad_vbo = id[0];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, quad_vbo);
                fixed (float* p = quad_data) {
                    gl.glBufferData(GL.GL_ARRAY_BUFFER,
                        sizeof(float) * quad_data.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }

                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);

                gl.glVertexAttribPointer(0, 2, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                gl.glVertexAttribPointer(1, 2, GL.GL_FLOAT, false, 0, (IntPtr)(8 * sizeof(float)));

                gl.glEnableVertexAttribArray(0);
                gl.glEnableVertexAttribArray(1);

                gl.glGenTextures(1, id); tex = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D, tex);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 4, GL.GL_RGBA8, 8, 8);


                fixed (byte* p = texture_data) {
                    gl.glTexSubImage2D(GL.GL_TEXTURE_2D,
                                    0,
                                    0, 0,
                                    8, 8,
                                    GL.GL_RED, GL.GL_UNSIGNED_BYTE,
                                    (IntPtr)p);
                }

                fixed (int* p = swizzles) {
                    gl.glTexParameteriv(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_SWIZZLE_RGBA, p);
                }
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (GLint)GL.GL_NEAREST);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (GLint)GL.GL_NEAREST);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (GLint)GL.GL_CLAMP_TO_EDGE);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (GLint)GL.GL_CLAMP_TO_EDGE);

                gl.glGenerateMipmap(GL.GL_TEXTURE_2D);
            }
        }

        public override void display(CSharpGL.GL gl) {

            gl.glClearDepth(1.0f);
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            gl.glDisable(GL.GL_CULL_FACE);
            gl.glUseProgram(base_prog);

            gl.glBindVertexArray(vao);
            gl.glDrawArrays(GL.GL_TRIANGLE_FAN, 0, 4);
        }

        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);

            aspect = (float)height / (float)width;
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