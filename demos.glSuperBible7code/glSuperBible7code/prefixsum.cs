
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class prefixsum : _glSuperBible7code {
        ~prefixsum() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public prefixsum(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int NUM_ELEMENTS = 2048;

        GLuint[] data_buffer = new uint[2];

        float[] input_data = new float[NUM_ELEMENTS];
        float[] output_data = new float[NUM_ELEMENTS];

        GLuint prefix_sum_prog;
        text_overlay overlay = new text_overlay();

        public override void init(CSharpGL.GL gl) {
            {
                var csCodeFile = "media/shaders/prefixsum.comp";
                var programObj = Utility.LoadShaders((csCodeFile, Shader.Kind.comp));
                Debug.Assert(programObj != null); this.prefix_sum_prog = programObj.programId;
                gl.glUseProgram(this.prefix_sum_prog);
                /*
                prefix_sum_prog = gl.glCreateProgram();
                gl.glAttachShader(prefix_sum_prog, cs);

                gl.glLinkProgram(prefix_sum_prog);

                int n;
                gl.glGetIntegerv(GL.GL_MAX_SHADER_STORAGE_BUFFER_BINDINGS, &n);
                */

                gl.glShaderStorageBlockBinding(prefix_sum_prog, 0, 0);
                gl.glShaderStorageBlockBinding(prefix_sum_prog, 1, 1);
            }
            {
                overlay.init(80, 50);

                var ids = stackalloc GLuint[2];
                gl.glGenBuffers(2, ids); data_buffer[0] = ids[0]; data_buffer[1] = ids[1];

                gl.glBindBuffer(GL.GL_SHADER_STORAGE_BUFFER, data_buffer[0]);
                gl.glBufferData(GL.GL_SHADER_STORAGE_BUFFER, NUM_ELEMENTS * sizeof(float), 0, GL.GL_DYNAMIC_DRAW);

                gl.glBindBuffer(GL.GL_SHADER_STORAGE_BUFFER, data_buffer[1]);
                gl.glBufferData(GL.GL_SHADER_STORAGE_BUFFER, NUM_ELEMENTS * sizeof(float), 0, GL.GL_DYNAMIC_COPY);

                int i;

                for (i = 0; i < NUM_ELEMENTS; i++) {
                    input_data[i] = random_float();
                }

                prefix_sum(input_data, output_data, NUM_ELEMENTS);

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

            gl.glBindBufferRange(GL.GL_SHADER_STORAGE_BUFFER, 0, data_buffer[0], 0, sizeof(float) * NUM_ELEMENTS);
            fixed (float* p = input_data) {
                gl.glBufferSubData(GL.GL_SHADER_STORAGE_BUFFER, 0, sizeof(float) * NUM_ELEMENTS, (IntPtr)p);
            }

            gl.glBindBufferRange(GL.GL_SHADER_STORAGE_BUFFER, 1, data_buffer[1], 0, sizeof(float) * NUM_ELEMENTS);

            gl.glUseProgram(prefix_sum_prog);
            gl.glDispatchCompute(1, 1, 1);

            gl.glMemoryBarrier(GL.GL_SHADER_STORAGE_BARRIER_BIT);
            gl.glFinish();

            gl.glBindBufferRange(GL.GL_SHADER_STORAGE_BUFFER, 0, data_buffer[1], 0, sizeof(float) * NUM_ELEMENTS);
            var ptr = (float*)gl.glMapBufferRange(GL.GL_SHADER_STORAGE_BUFFER,
                0, sizeof(float) * NUM_ELEMENTS, GL.GL_MAP_READ_BIT);
            var builder = new StringBuilder(); builder.Append("sum: ");
            for (int i = 0; i < 16; i++) {
                if (i == 8) { builder.Append('\n'); }
                builder.Append(ptr[i]);
            }
            gl.glUnmapBuffer(GL.GL_SHADER_STORAGE_BUFFER);
            overlay.clear();
            overlay.drawText(builder.ToString(), 0, 0);
            overlay.draw();
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