
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class pmbfractal : _glSuperBible7code {
        ~pmbfractal() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public pmbfractal(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        text_overlay overlay = new text_overlay();
        const int FRACTAL_WIDTH = 512,
            FRACTAL_HEIGHT = 512,
            BUFFER_SIZE = (FRACTAL_WIDTH * FRACTAL_HEIGHT);

        GLuint vao;
        GLuint program;
        GLuint buffer;
        GLuint texture;
        byte* mapped_buffer;

        struct _fractparams {
            public vec2 C;
            public vec2 offset;
            public float zoom;
        }
        _fractparams fractparams;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/pmbfractal.vert";
                var fsCodeFile = "media/shaders/pmbfractal.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program = programObj.programId;
                gl.glUseProgram(this.program);

            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenBuffers(1, id); buffer = id[0];
                gl.glBindBuffer(GL.GL_PIXEL_UNPACK_BUFFER, buffer);

                gl.glBufferStorage(GL.GL_PIXEL_UNPACK_BUFFER,
                    BUFFER_SIZE, 0,
                    GL.GL_MAP_WRITE_BIT | 0x0040/*GL_MAP_PERSISTENT_BIT*/ | 0x0080/*GL_MAP_COHERENT_BIT*/);
                mapped_buffer = (byte*)gl.glMapBufferRange(GL.GL_PIXEL_UNPACK_BUFFER,
                    0, BUFFER_SIZE,
                    GL.GL_MAP_WRITE_BIT | 0x0040/*GL_MAP_PERSISTENT_BIT*/ | 0x0080/*GL_MAP_COHERENT_BIT*/);

                gl.glBindBuffer(GL.GL_PIXEL_UNPACK_BUFFER, 0);

                gl.glGenTextures(1, id); texture = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D, texture);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_R8, FRACTAL_WIDTH, FRACTAL_HEIGHT);

                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);

                overlay.init(128, 50);

                //int maxThreads = omp_get_max_threads();
                //omp_set_num_threads(maxThreads);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float nowTime = 0;// time
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            nowTime += 0.01f;

            var proj_matrix = this.proj_matrix;


            fractparams.C = new vec2(1.5f - (float)Math.Cos(nowTime * 0.4f) * 0.5f,
                1.5f + (float)Math.Cos(nowTime * 0.5f) * 0.5f) * 0.3f;
            fractparams.offset = new vec2((float)Math.Cos(nowTime * 0.14f),
                (float)Math.Cos(nowTime * 0.25f)) * 0.25f;
            fractparams.zoom = ((float)Math.Sin(nowTime) + 1.3f) * 0.7f;

            update_fractal();

            gl.glViewport(0, 0, this.width, this.height);

            gl.glUseProgram(program);
            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, texture);

            gl.glBindBuffer(GL.GL_PIXEL_UNPACK_BUFFER, buffer);
            gl.glTexSubImage2D(GL.GL_TEXTURE_2D, 0, 0, 0, FRACTAL_WIDTH, FRACTAL_HEIGHT, GL.GL_RED, GL.GL_UNSIGNED_BYTE, 0);
            gl.glBindBuffer(GL.GL_PIXEL_UNPACK_BUFFER, 0);

            gl.glBindVertexArray(vao);
            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);

            updateOverlay();

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


        void updateOverlay() {
            overlay.clear();
            overlay.drawText($"time: {nowTime}", 0, 0);
            overlay.draw();
        }

        void update_fractal() {
            vec2 C = fractparams.C; // (0.03f, -0.2f);
            float thresh_squared = 256.0f;
            float zoom = fractparams.zoom;
            vec2 offset = fractparams.offset;

            //#pragma omp parallel for schedule (dynamic, 16)
            for (int y = 0; y < FRACTAL_HEIGHT; y++) {
                for (int x = 0; x < FRACTAL_WIDTH; x++) {
                    vec2 Z = new vec2();
                    Z[0] = zoom * ((float)x / (float)(FRACTAL_WIDTH) - 0.5f) + offset[0];
                    Z[1] = zoom * ((float)y / (float)(FRACTAL_HEIGHT) - 0.5f) + offset[1];
                    byte* ptr = mapped_buffer + y * FRACTAL_WIDTH + x;

                    int it;
                    for (it = 0; it < 256; it++) {
                        vec2 Z_squared = new vec2();

                        Z_squared[0] = Z[0] * Z[0] - Z[1] * Z[1];
                        Z_squared[1] = 2.0f * Z[0] * Z[1];
                        Z = Z_squared + C;

                        if ((Z[0] * Z[0] + Z[1] * Z[1]) > thresh_squared)
                            break;
                    }
                    *ptr = (byte)it;
                }
            }
        }
    }
}