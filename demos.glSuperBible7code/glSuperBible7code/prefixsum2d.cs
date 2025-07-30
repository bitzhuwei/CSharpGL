
using CSharpGL;
using System.CodeDom;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class prefixsum2d : _glSuperBible7code {
        ~prefixsum2d() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public prefixsum2d(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int NUM_ELEMENTS = 2048;

        GLuint[] images = new uint[3];
        GLuint prefix_sum_prog;
        GLuint show_image_prog;
        GLuint dummy_vao;

        public override void init(CSharpGL.GL gl) {
            {
                var csCodeFile = "media/shaders/prefixsum2d.comp";
                var programObj = Utility.LoadShaders((csCodeFile, Shader.Kind.comp));
                Debug.Assert(programObj != null); this.prefix_sum_prog = programObj.programId;
                gl.glUseProgram(this.prefix_sum_prog);

            }
            {
                var vsCodeFile = "media/shaders/prefixsum2d.vert";
                var fsCodeFile = "media/shaders/prefixsum2d.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.show_image_prog = programObj.programId;
                gl.glUseProgram(this.show_image_prog);

            }
            {
                var ids = stackalloc GLuint[3];
                gl.glGenTextures(3, ids); for (int i = 0; i < 3; i++) { images[i] = ids[i]; }

                images[0] = sb7ktx.load("media/textures/salad-gray.ktx");

                for (var i = 1; i < 3; i++) {
                    gl.glBindTexture(GL.GL_TEXTURE_2D, images[i]);
                    gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_R32F, NUM_ELEMENTS, NUM_ELEMENTS);
                }

                gl.glGenVertexArrays(1, ids); dummy_vao = ids[0];
                gl.glBindVertexArray(dummy_vao);
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
            gl.glUseProgram(prefix_sum_prog);

            gl.glBindImageTexture(0, images[0], 0, false, 0, GL.GL_READ_ONLY, GL.GL_R32F);
            gl.glBindImageTexture(1, images[1], 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_R32F);

            gl.glDispatchCompute(NUM_ELEMENTS, 1, 1);

            gl.glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);

            gl.glBindImageTexture(0, images[1], 0, false, 0, GL.GL_READ_ONLY, GL.GL_R32F);
            gl.glBindImageTexture(1, images[2], 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_R32F);

            gl.glDispatchCompute(NUM_ELEMENTS, 1, 1);

            gl.glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);

            gl.glBindTexture(GL.GL_TEXTURE_2D, images[2]);

            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, images[2]);

            gl.glUseProgram(show_image_prog);

            gl.glViewport(0, 0, this.width, this.height);
            gl.glBindVertexArray(dummy_vao);
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


        void prefix_sum(float[] input, float[] output, int elements) {
            float f = 0.0f;
            int i;

            for (i = 0; i < elements; i++) {
                f += input[i];
                output[i] = f;
            }
        }

        static uint seed = 0x13371337;
        static float random_float() {

            float res;
            uint tmp;

            seed *= 16807;

            tmp = seed ^ (seed >> 4) ^ (seed << 15);

            *((uint*)&res) = (tmp >> 9) | 0x3F800000;

            return (res - 1.0f);
        }
    }
}