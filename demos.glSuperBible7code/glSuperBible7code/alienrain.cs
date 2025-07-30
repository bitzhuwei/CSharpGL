
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class alienrain : _glSuperBible7code {
        ~alienrain() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public alienrain(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint render_prog;
        GLuint render_vao;

        GLuint tex_alien_array;
        GLuint rain_buffer;

        float[] droplet_x_offset = new float[256];
        float[] droplet_rot_speed = new float[256];
        float[] droplet_fall_speed = new float[256];

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/alienrain.vert";
                var fsCodeFile = "media/shaders/alienrain.frag";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.render_prog = program.programId;
                gl.glUseProgram(this.render_prog);
            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); render_vao = id[0];
                gl.glBindVertexArray(render_vao);

                tex_alien_array = sb7ktx.load("media/textures/aliens.ktx");
                gl.glBindTexture(GL.GL_TEXTURE_2D_ARRAY, tex_alien_array);
                gl.glTexParameteri(GL.GL_TEXTURE_2D_ARRAY, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR_MIPMAP_LINEAR);

                gl.glGenBuffers(1, id); rain_buffer = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, rain_buffer);
                gl.glBufferData(GL.GL_UNIFORM_BUFFER, 256 * sizeof(vec4), IntPtr.Zero, GL.GL_DYNAMIC_DRAW);

                for (int i = 0; i < 256; i++) {
                    droplet_x_offset[i] = random_float() * 2.0f - 1.0f;
                    droplet_rot_speed[i] = (random_float() + 0.5f) * ((i % 2 == 1) ? -3.0f : 3.0f);
                    droplet_fall_speed[i] = random_float() + 0.2f;
                }

                gl.glBindVertexArray(render_vao);
                gl.glEnable(GL.GL_BLEND);
                gl.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        //static GLfloat[] black = { 0.0f, 0.0f, 0.0f, 0.0f };
        float time = 0;
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            //float t = (float)currentTime;
            time = time + 0.01f;

            //gl.glClearBufferfv(GL.GL_COLOR, 0, black);

            gl.glUseProgram(render_prog);

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, rain_buffer);
            var droplet = (vec4*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER, 0, 256 * sizeof(vec4), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);

            for (int i = 0; i < 256; i++) {
                droplet[i][0] = droplet_x_offset[i];
                droplet[i][1] = 2.0f - ((time + i) * droplet_fall_speed[i]) % (4.31f);
                droplet[i][2] = time * droplet_rot_speed[i];
                droplet[i][3] = 0.0f;
            }
            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            int alien_index;
            for (alien_index = 0; alien_index < 256; alien_index++) {
                gl.glVertexAttribI1i(0, alien_index);
                gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);
            }
        }

        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);

            //aspect = (float)height / (float)width;
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


        // Random number generator
        uint seed = 0x13371337;

        float random_float() {
            float res;
            uint tmp;

            seed *= 16807;

            tmp = seed ^ (seed >> 4) ^ (seed << 15);

            *((uint*)&res) = (tmp >> 9) | 0x3F800000;

            return (res - 1.0f);
        }
    }
}