
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;
using static demos.glSuperBible7code.csflocking;

namespace demos.glSuperBible7code {

    public unsafe class starfield : _glSuperBible7code {
        ~starfield() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public starfield(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int NUM_STARS = 2000;
        GLuint render_prog;
        GLuint star_texture;
        GLuint star_vao;
        GLuint star_buffer;

        struct _uniforms {
            public int time;
            public int proj_matrix;
        }
        _uniforms uniforms;

        struct star_t {
            public vec3 position;
            public vec3 color;
        };

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/starfield.vert";
                var fsCodeFile = "media/shaders/starfield.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.render_prog = programObj.programId;
                gl.glUseProgram(this.render_prog);

                uniforms.time = gl.glGetUniformLocation(render_prog, "time");
                uniforms.proj_matrix = gl.glGetUniformLocation(render_prog, "proj_matrix");

            }
            {

                star_texture = sb7ktx.load("media/textures/star.ktx");
                GLuint id;
                gl.glGenVertexArrays(1, &id); star_vao = id;
                gl.glBindVertexArray(star_vao);

                gl.glGenBuffers(1, &id); star_buffer = id;
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, star_buffer);
                gl.glBufferData(GL.GL_ARRAY_BUFFER, NUM_STARS * sizeof(star_t), 0, GL.GL_STATIC_DRAW);

                var star = (star_t*)gl.glMapBufferRange(GL.GL_ARRAY_BUFFER,
                    0, NUM_STARS * sizeof(star_t), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
                for (var i = 0; i < 1000; i++) {
                    star[i].position[0] = (random_float() * 2.0f - 1.0f) * 100.0f;
                    star[i].position[1] = (random_float() * 2.0f - 1.0f) * 100.0f;
                    star[i].position[2] = random_float();
                    star[i].color[0] = 0.8f + random_float() * 0.2f;
                    star[i].color[1] = 0.8f + random_float() * 0.2f;
                    star[i].color[2] = 0.8f + random_float() * 0.2f;
                }
                gl.glUnmapBuffer(GL.GL_ARRAY_BUFFER);

                gl.glVertexAttribPointer(0, 3, GL.GL_FLOAT, false, sizeof(star_t), 0);
                gl.glVertexAttribPointer(1, 3, GL.GL_FLOAT, false, sizeof(star_t), sizeof(vec3));
                gl.glEnableVertexAttribArray(0);
                gl.glEnableVertexAttribArray(1);

                gl.glEnable(GL.GL_PROGRAM_POINT_SIZE);
                gl.glEnable(GL.GL_POINT_SPRITE);
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
            currentTime += 0.001f;

            var proj_matrix = this.proj_matrix;// * glm.lookAt(new vec3(5, 4, 4), new vec3(0, 0, 0), new vec3(0, 1, 0));

            float t = (float)currentTime;

            t -= (float)Math.Floor(t);

            //gl.glViewport(0, 0, this.width, this.height);
            fixed (float* p = gray) {
                gl.glClearBufferfv(GL.GL_COLOR, 0, p);
            }
            fixed (float* p = ones) {
                gl.glClearBufferfv(GL.GL_DEPTH, 0, p);
            }

            gl.glUseProgram(render_prog);

            gl.glUniform1f(uniforms.time, t);
            gl.glUniformMatrix4fv(uniforms.proj_matrix, 1, false, (float*)&proj_matrix);

            gl.glEnable(GL.GL_BLEND);
            gl.glBlendFunc(GL.GL_ONE, GL.GL_ONE);

            gl.glBindVertexArray(star_vao);

            gl.glEnable(GL.GL_PROGRAM_POINT_SIZE);
            gl.glDrawArrays(GL.GL_POINTS, 0, NUM_STARS);
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


        // Random number generator
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