
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class simpletexture : _glSuperBible7code {
        ~simpletexture() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public simpletexture(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint texture;
        GLuint program;
        GLuint vao;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/simpletexture.vert";
                var fsCodeFile = "media/shaders/simpletexture.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program = programObj.programId;
                gl.glUseProgram(this.program);

            }
            {
                GLuint id;
                // Generate a name for the texture
                gl.glGenTextures(1, &id); texture = id;

                // Now bind it to the context using the GL.GL_TEXTURE_2D binding point
                gl.glBindTexture(GL.GL_TEXTURE_2D, texture);

                // Specify the amount of storage we want to use for the texture
                gl.glTexStorage2D(GL.GL_TEXTURE_2D,   // 2D texture
                    8,               // 8 mipmap levels
                    GL.GL_RGBA32F,      // 32-bit floating-point RGBA data
                    256, 256);       // 256 x 256 texels

                // Define some data to upload into the texture
                var data = new float[256 * 256 * 4];

                // generate_texture() is a function that fills memory with image data
                generate_texture(data, 256, 256);

                // Assume the texture is already bound to the GL.GL_TEXTURE_2D target
                fixed (float* p = data) {
                    gl.glTexSubImage2D(GL.GL_TEXTURE_2D,  // 2D texture
                        0,              // Level 0
                        0, 0,           // Offset 0, 0
                        256, 256,       // 256 x 256 texels, replace entire image
                        GL.GL_RGBA,        // Four channel data
                        GL.GL_FLOAT,       // Floating point data
                        (IntPtr)p);          // Pointer to data
                }

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
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            t += 0.01f;

            var proj_matrix = this.proj_matrix;

            gl.glUseProgram(program);
            gl.glDrawArrays(GL.GL_TRIANGLES, 0, 3);
        }
        void generate_texture(float[] data, int width, int height) {
            for (var y = 0; y < height; y++) {
                for (var x = 0; x < width; x++) {
                    data[(y * width + x) * 4 + 0] = (float)((x & y) & 0xFF) / 255.0f;
                    data[(y * width + x) * 4 + 1] = (float)((x | y) & 0xFF) / 255.0f;
                    data[(y * width + x) * 4 + 2] = (float)((x ^ y) & 0xFF) / 255.0f;
                    data[(y * width + x) * 4 + 3] = 1.0f;
                }
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