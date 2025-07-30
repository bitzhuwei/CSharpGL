
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class springmass : _glSuperBible7code {
        ~springmass() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public springmass(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int POSITION_A = 0, POSITION_B = 1, VELOCITY_A = 2, VELOCITY_B = 3, CONNECTION = 4;
        const int POINTS_X = 50, POINTS_Y = 50, POINTS_TOTAL = (POINTS_X * POINTS_Y),
            CONNECTIONS_TOTAL = (POINTS_X - 1) * POINTS_Y + (POINTS_Y - 1) * POINTS_X;

        GLuint[] m_vao = new uint[2];
        GLuint[] m_vbo = new uint[5];
        GLuint m_index_buffer;
        GLuint[] m_pos_tbo = new uint[2];
        GLuint m_update_program;
        GLuint m_render_program;
        GLuint m_C_loc;
        GLuint m_iteration_index;

        bool draw_points = true;
        bool draw_lines = true;
        int iterations_per_frame = 16;
        static string[] tf_varyings = {
            "tf_position_mass",
            "tf_velocity"
        };
        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/springmass.update.vert";
                var programObj = Utility.LoadShaders(
                    tf_varyings, GLProgram.BufferMode.Separate,
                    (vsCodeFile, Shader.Kind.vert));
                Debug.Assert(programObj != null); this.m_update_program = programObj.programId;
                gl.glUseProgram(this.m_update_program);

            }
            {
                var vsCodeFile = "media/shaders/springmass.render.vert";
                var fsCodeFile = "media/shaders/springmass.render.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.m_render_program = programObj.programId;
                gl.glUseProgram(this.m_render_program);

            }
            {

                var initial_positions = new vec4[POINTS_TOTAL];
                var initial_velocities = new vec3[POINTS_TOTAL];
                var connection_vectors = new ivec4[POINTS_TOTAL];

                int n = 0;

                for (var j = 0; j < POINTS_Y; j++) {
                    float fj = (float)j / (float)POINTS_Y;
                    for (var i = 0; i < POINTS_X; i++) {
                        float fi = (float)i / (float)POINTS_X;

                        initial_positions[n] = new vec4((fi - 0.5f) * (float)POINTS_X,
                            (fj - 0.5f) * (float)POINTS_Y,
                            0.6f * (float)Math.Sin(fi) * (float)Math.Cos(fj),
                            1.0f);
                        initial_velocities[n] = new vec3(0.0f);

                        connection_vectors[n] = new ivec4(-1);

                        if (j != (POINTS_Y - 1)) {
                            if (i != 0)
                                connection_vectors[n][0] = n - 1;

                            if (j != 0)
                                connection_vectors[n][1] = n - POINTS_X;

                            if (i != (POINTS_X - 1))
                                connection_vectors[n][2] = n + 1;

                            if (j != (POINTS_Y - 1))
                                connection_vectors[n][3] = n + POINTS_X;
                        }
                        n++;
                    }
                }

                var ids = stackalloc uint[5];
                gl.glGenVertexArrays(2, ids); for (int i = 0; i < 2; i++) { m_vao[i] = ids[i]; }
                gl.glGenBuffers(5, ids); for (int i = 0; i < 5; i++) { m_vbo[i] = ids[i]; }

                for (var i = 0; i < 2; i++) {
                    gl.glBindVertexArray(m_vao[i]);

                    gl.glBindBuffer(GL.GL_ARRAY_BUFFER, m_vbo[POSITION_A + i]);
                    fixed (vec4* p = initial_positions) {
                        gl.glBufferData(GL.GL_ARRAY_BUFFER, POINTS_TOTAL * sizeof(vec4), (IntPtr)p, GL.GL_DYNAMIC_COPY);
                    }
                    gl.glVertexAttribPointer(0, 4, GL.GL_FLOAT, false, 0, 0);
                    gl.glEnableVertexAttribArray(0);

                    gl.glBindBuffer(GL.GL_ARRAY_BUFFER, m_vbo[VELOCITY_A + i]);
                    fixed (vec3* p = initial_velocities) {
                        gl.glBufferData(GL.GL_ARRAY_BUFFER, POINTS_TOTAL * sizeof(vec3), (IntPtr)p, GL.GL_DYNAMIC_COPY);
                    }
                    gl.glVertexAttribPointer(1, 3, GL.GL_FLOAT, false, 0, 0);
                    gl.glEnableVertexAttribArray(1);

                    gl.glBindBuffer(GL.GL_ARRAY_BUFFER, m_vbo[CONNECTION]);
                    fixed (ivec4* p = connection_vectors) {
                        gl.glBufferData(GL.GL_ARRAY_BUFFER, POINTS_TOTAL * sizeof(ivec4), (IntPtr)p, GL.GL_STATIC_DRAW);
                    }
                    gl.glVertexAttribIPointer(2, 4, GL.GL_INT, 0, 0);
                    gl.glEnableVertexAttribArray(2);
                }

                gl.glGenTextures(2, ids); for (int i = 0; i < 2; i++) { m_pos_tbo[i] = ids[i]; }
                gl.glBindTexture(GL.GL_TEXTURE_BUFFER, m_pos_tbo[0]);
                gl.glTexBuffer(GL.GL_TEXTURE_BUFFER, GL.GL_RGBA32F, m_vbo[POSITION_A]);
                gl.glBindTexture(GL.GL_TEXTURE_BUFFER, m_pos_tbo[1]);
                gl.glTexBuffer(GL.GL_TEXTURE_BUFFER, GL.GL_RGBA32F, m_vbo[POSITION_B]);

                int lines = (POINTS_X - 1) * POINTS_Y + (POINTS_Y - 1) * POINTS_X;

                gl.glGenBuffers(1, ids); for (int i = 0; i < 1; i++) { m_index_buffer = ids[i]; }
                gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, m_index_buffer);
                gl.glBufferData(GL.GL_ELEMENT_ARRAY_BUFFER, lines * 2 * sizeof(int), 0, GL.GL_STATIC_DRAW);

                var e = (int*)gl.glMapBufferRange(GL.GL_ELEMENT_ARRAY_BUFFER,
                    0, lines * 2 * sizeof(int), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
                for (var j = 0; j < POINTS_Y; j++) {
                    for (var i = 0; i < POINTS_X - 1; i++) {
                        *e++ = i + j * POINTS_X;
                        *e++ = 1 + i + j * POINTS_X;
                    }
                }
                for (var i = 0; i < POINTS_X; i++) {
                    for (var j = 0; j < POINTS_Y - 1; j++) {
                        *e++ = i + j * POINTS_X;
                        *e++ = POINTS_X + i + j * POINTS_X;
                    }
                }
                gl.glUnmapBuffer(GL.GL_ELEMENT_ARRAY_BUFFER);
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
        static GLfloat[] black = { 0.0f, 0.0f, 0.0f, 0.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            t += 0.1f;

            var proj_matrix = this.proj_matrix;
            gl.glUseProgram(m_update_program);

            gl.glEnable(GL.GL_RASTERIZER_DISCARD);

            for (var i = iterations_per_frame; i != 0; --i) {
                gl.glBindVertexArray(m_vao[m_iteration_index & 1]);
                gl.glBindTexture(GL.GL_TEXTURE_BUFFER, m_pos_tbo[m_iteration_index & 1]);
                m_iteration_index++;
                gl.glBindBufferBase(GL.GL_TRANSFORM_FEEDBACK_BUFFER, 0, m_vbo[POSITION_A + (m_iteration_index & 1)]);
                gl.glBindBufferBase(GL.GL_TRANSFORM_FEEDBACK_BUFFER, 1, m_vbo[VELOCITY_A + (m_iteration_index & 1)]);
                gl.glBeginTransformFeedback(GL.GL_POINTS);
                gl.glDrawArrays(GL.GL_POINTS, 0, POINTS_TOTAL);
                gl.glEndTransformFeedback();
            }

            gl.glDisable(GL.GL_RASTERIZER_DISCARD);


            //gl.glViewport(0, 0, this.width, this.height);
            //gl.glClearBufferfv(GL.GL_COLOR, 0, black);

            gl.glUseProgram(m_render_program);

            if (draw_points) {
                gl.glPointSize(4.0f);
                gl.glDrawArrays(GL.GL_POINTS, 0, POINTS_TOTAL);
            }

            if (draw_lines) {
                gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, m_index_buffer);
                gl.glDrawElements(GL.GL_LINES, CONNECTIONS_TOTAL * 2, GL.GL_UNSIGNED_INT, 0);
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
            case Keys.L:
            draw_lines = !draw_lines;
            break;
            case Keys.P:
            draw_points = !draw_points;
            break;
            case Keys.Add:
            iterations_per_frame++;
            break;
            case Keys.Subtract:
            iterations_per_frame--;
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.L, Keys.P, Keys.Add, Keys.Subtract];
        public override MouseButtons[] ValidButtons => [];

    }
}