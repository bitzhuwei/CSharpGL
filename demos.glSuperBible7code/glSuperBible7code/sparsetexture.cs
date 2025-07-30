
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class sparsetexture : _glSuperBible7code {
        ~sparsetexture() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public sparsetexture(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int PAGE_SIZE = 128, TEX_SIZE = 16 * PAGE_SIZE;
        GLuint texture;
        GLuint program;
        GLuint vao;

        struct _uniforms {
            GLint mv_matrix;
            GLint vp_matrix;
        }
        _uniforms uniforms;

        byte[] texture_data;

        static byte[] bit_reversal_table = new byte[256] {
        0x00, 0x80, 0x40, 0xc0, 0x20, 0xa0, 0x60, 0xe0,
        0x10, 0x90, 0x50, 0xd0, 0x30, 0xb0, 0x70, 0xf0,
        0x08, 0x88, 0x48, 0xc8, 0x28, 0xa8, 0x68, 0xe8,
        0x18, 0x98, 0x58, 0xd8, 0x38, 0xb8, 0x78, 0xf8,
        0x04, 0x84, 0x44, 0xc4, 0x24, 0xa4, 0x64, 0xe4,
        0x14, 0x94, 0x54, 0xd4, 0x34, 0xb4, 0x74, 0xf4,
        0x0c, 0x8c, 0x4c, 0xcc, 0x2c, 0xac, 0x6c, 0xec,
        0x1c, 0x9c, 0x5c, 0xdc, 0x3c, 0xbc, 0x7c, 0xfc,
        0x02, 0x82, 0x42, 0xc2, 0x22, 0xa2, 0x62, 0xe2,
        0x12, 0x92, 0x52, 0xd2, 0x32, 0xb2, 0x72, 0xf2,
        0x0a, 0x8a, 0x4a, 0xca, 0x2a, 0xaa, 0x6a, 0xea,
        0x1a, 0x9a, 0x5a, 0xda, 0x3a, 0xba, 0x7a, 0xfa,
        0x06, 0x86, 0x46, 0xc6, 0x26, 0xa6, 0x66, 0xe6,
        0x16, 0x96, 0x56, 0xd6, 0x36, 0xb6, 0x76, 0xf6,
        0x0e, 0x8e, 0x4e, 0xce, 0x2e, 0xae, 0x6e, 0xee,
        0x1e, 0x9e, 0x5e, 0xde, 0x3e, 0xbe, 0x7e, 0xfe,
        0x01, 0x81, 0x41, 0xc1, 0x21, 0xa1, 0x61, 0xe1,
        0x11, 0x91, 0x51, 0xd1, 0x31, 0xb1, 0x71, 0xf1,
        0x09, 0x89, 0x49, 0xc9, 0x29, 0xa9, 0x69, 0xe9,
        0x19, 0x99, 0x59, 0xd9, 0x39, 0xb9, 0x79, 0xf9,
        0x05, 0x85, 0x45, 0xc5, 0x25, 0xa5, 0x65, 0xe5,
        0x15, 0x95, 0x55, 0xd5, 0x35, 0xb5, 0x75, 0xf5,
        0x0d, 0x8d, 0x4d, 0xcd, 0x2d, 0xad, 0x6d, 0xed,
        0x1d, 0x9d, 0x5d, 0xdd, 0x3d, 0xbd, 0x7d, 0xfd,
        0x03, 0x83, 0x43, 0xc3, 0x23, 0xa3, 0x63, 0xe3,
        0x13, 0x93, 0x53, 0xd3, 0x33, 0xb3, 0x73, 0xf3,
        0x0b, 0x8b, 0x4b, 0xcb, 0x2b, 0xab, 0x6b, 0xeb,
        0x1b, 0x9b, 0x5b, 0xdb, 0x3b, 0xbb, 0x7b, 0xfb,
        0x07, 0x87, 0x47, 0xc7, 0x27, 0xa7, 0x67, 0xe7,
        0x17, 0x97, 0x57, 0xd7, 0x37, 0xb7, 0x77, 0xf7,
        0x0f, 0x8f, 0x4f, 0xcf, 0x2f, 0xaf, 0x6f, 0xef,
        0x1f, 0x9f, 0x5f, 0xdf, 0x3f, 0xbf, 0x7f, 0xff
        };

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/sparsetexture.vert";
                var fsCodeFile = "media/shaders/sparsetexture.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program = programObj.programId;
                gl.glUseProgram(this.program);

            }
            {
                GLuint id;
                gl.glGenTextures(1, &id); texture = id;
                gl.glBindTexture(GL.GL_TEXTURE_2D, texture);

                gl.glTexParameteri(GL.GL_TEXTURE_2D, 0x91A6/*GL_TEXTURE_SPARSE_ARB*/, 1/*GL_TRUE*/);

                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 11, GL.GL_RGBA8, TEX_SIZE, TEX_SIZE);

                gl.glGenVertexArrays(1, &id); vao = id;

                //texture_data = new byte[PAGE_SIZE * PAGE_SIZE * 4];
                //f = fopen("media/textures/smiley.raw", "rb");
                //fread(texture_data, 128 * 128 * 4, 1, f);
                //fclose(f);
                texture_data = File.ReadAllBytes("media/textures/smiley.raw");
            }
        }
        static int t = 0;
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

            mat4 mv_matrix = glm.translate(0.0f, 0.0f, -2.0f) *
                glm.rotate(time * 40.0f, 0.0f, 1.0f, 0.0f);

            mat4 vp_matrix = this.proj_matrix;

            //gl.glViewport(0, 0, this.width, this.height);
            //gl.glClearBufferfv(GL.GL_COLOR, 0, sb7::color::Black);

            gl.glBindVertexArray(vao);
            gl.glUseProgram(program);

            gl.glBindTexture(GL.GL_TEXTURE_2D, texture);

            int r = (t & 0x100);
            int tile = bit_reversal_table[(t & 0xFF)];

            int x = (tile >> 0) & 0xF;
            int y = (tile >> 4) & 0xF;

            if (r == 0) {
                gl.glTexPageCommitmentARB(GL.GL_TEXTURE_2D,
                    0,
                    x * PAGE_SIZE, y * PAGE_SIZE, 0,
                    PAGE_SIZE, PAGE_SIZE, 1,
                    true/*GL_TRUE*/);
                fixed (byte* p = texture_data) {
                    gl.glTexSubImage2D(GL.GL_TEXTURE_2D,
                        0,
                        x * PAGE_SIZE, y * PAGE_SIZE,
                        PAGE_SIZE, PAGE_SIZE,
                        GL.GL_RGBA, GL.GL_UNSIGNED_BYTE,
                        (IntPtr)p);
                }
            }
            else {
                gl.glTexPageCommitmentARB(GL.GL_TEXTURE_2D,
                    0,
                    x * PAGE_SIZE, y * PAGE_SIZE, 0,
                    PAGE_SIZE, PAGE_SIZE, 1,
                    false);
            }

            t += 17;

            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);
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