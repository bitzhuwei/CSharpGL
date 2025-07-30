
using CSharpGL;
using demos.glGuide8code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch03_xfb : _glGuide8code {

        public ch03_xfb(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        // Member variables
        float aspect;
        GLuint update_prog;
        GLuint[] vao = new uint[2];
        GLuint[] vbo = new uint[2];
        GLuint xfb;

        GLuint render_prog;
        GLuint geometry_vbo;
        GLuint render_vao;
        GLint render_model_matrix_loc;
        GLint render_projection_matrix_loc;

        GLuint geometry_tex;

        GLuint geometry_xfb;
        GLuint particle_xfb;

        GLint model_matrix_loc;
        GLint projection_matrix_loc;
        GLint triangle_count_loc;
        GLint time_step_loc;

        VBObject vbObject = new VBObject();

        const int point_count = 5000;
        static uint seed = 0x13371337;

        static float random_float() {
            float res;
            uint tmp;

            seed *= 16807;

            tmp = seed ^ (seed >> 4) ^ (seed << 15);

            *((uint*)&res) = (tmp >> 9) | 0x3F800000;

            return (res - 1.0f);
        }

        static vec3 random_vector(float minmag = 0.0f, float maxmag = 1.0f) {
            var randomvec = new vec3(random_float() * 2.0f - 1.0f, random_float() * 2.0f - 1.0f, random_float() * 2.0f - 1.0f);
            randomvec = randomvec.normalize();
            randomvec *= (random_float() * (maxmag - minmag) + minmag);

            return randomvec;
        }
        static string[] varyings = { "position_out", "velocity_out" };
        static string[] varyings2 = { "world_space_position" };
        struct buffer_t {
            public vec4 position;
            public vec3 velocity;
        }
        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "03/ch03_xfb/ch03_xfb.update.vs.glsl";
                var fsCodeFile = "03/ch03_xfb/ch03_xfb.update.fs.glsl";

                var program = Utility.LoadShaders(varyings, GLProgram.BufferMode.InterLeaved, vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.update_prog = program.programId; //this.program = program;
                gl.glUseProgram(this.update_prog);//this.program.Bind();

                model_matrix_loc = gl.glGetUniformLocation(update_prog, "model_matrix");
                projection_matrix_loc = gl.glGetUniformLocation(update_prog, "projection_matrix");
                triangle_count_loc = gl.glGetUniformLocation(update_prog, "triangle_count");
                time_step_loc = gl.glGetUniformLocation(update_prog, "time_step");
            }
            {
                var vsCodeFile = "03/ch03_xfb/ch03_xfb.render.vs.glsl";
                var fsCodeFile = "03/ch03_xfb/ch03_xfb.render.fs.glsl";

                var program = Utility.LoadShaders(varyings2, GLProgram.BufferMode.InterLeaved, vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.render_prog = program.programId; //this.program = program;
                gl.glUseProgram(this.render_prog);//this.program.Bind();

                render_model_matrix_loc = gl.glGetUniformLocation(render_prog, "model_matrix");
                render_projection_matrix_loc = gl.glGetUniformLocation(render_prog, "projection_matrix");
            }
            {
                var ids = stackalloc uint[2];
                gl.glGenVertexArrays(2, ids); this.vao[0] = ids[0]; this.vao[1] = ids[1];
                gl.glGenBuffers(2, ids); this.vbo[0] = ids[0]; this.vbo[1] = ids[1];

                for (var i = 0; i < 2; i++) {
                    gl.glBindBuffer(GL.GL_TRANSFORM_FEEDBACK_BUFFER, vbo[i]);
                    gl.glBufferData(GL.GL_TRANSFORM_FEEDBACK_BUFFER, point_count * (sizeof(vec4) + sizeof(vec3)), IntPtr.Zero, GL.GL_DYNAMIC_COPY);
                    if (i == 0) {
                        var buffer = (buffer_t*)gl.glMapBuffer(GL.GL_TRANSFORM_FEEDBACK_BUFFER, GL.GL_WRITE_ONLY);

                        for (var j = 0; j < point_count; j++) {
                            buffer[j].velocity = random_vector();
                            buffer[j].position = new vec4(buffer[j].velocity + new vec3(-0.5f, 40.0f, 0.0f), 1.0f);
                            buffer[j].velocity = new vec3(buffer[j].velocity[0], buffer[j].velocity[1] * 0.3f, buffer[j].velocity[2] * 0.3f);
                        }

                        gl.glUnmapBuffer(GL.GL_TRANSFORM_FEEDBACK_BUFFER);
                    }

                    gl.glBindVertexArray(vao[i]);
                    gl.glBindBuffer(GL.GL_ARRAY_BUFFER, vbo[i]);
                    gl.glVertexAttribPointer(0, 4, GL.GL_FLOAT, false, sizeof(vec4) + sizeof(vec3), IntPtr.Zero);
                    gl.glVertexAttribPointer(1, 3, GL.GL_FLOAT, false, sizeof(vec4) + sizeof(vec3), (IntPtr)sizeof(vec4));
                    gl.glEnableVertexAttribArray(0);
                    gl.glEnableVertexAttribArray(1);
                }

                var id = stackalloc GLuint[1];
                gl.glGenBuffers(1, id); this.geometry_vbo = id[0];
                gl.glGenTextures(1, id); geometry_tex = id[0];
                gl.glBindBuffer(GL.GL_TEXTURE_BUFFER, geometry_vbo);
                gl.glBufferData(GL.GL_TEXTURE_BUFFER, 1024 * 1024 * sizeof(vec4), IntPtr.Zero, GL.GL_DYNAMIC_COPY);
                gl.glBindTexture(GL.GL_TEXTURE_BUFFER, geometry_tex);
                gl.glTexBuffer(GL.GL_TEXTURE_BUFFER, GL.GL_RGBA32F, geometry_vbo);

                gl.glGenVertexArrays(1, id); render_vao = id[0];
                gl.glBindVertexArray(render_vao);
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, geometry_vbo);
                gl.glVertexAttribPointer(0, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                gl.glEnableVertexAttribArray(0);

                gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
                gl.glClearDepth(1.0f);

                vbObject.LoadFromVBM("media/armadillo_low.vbm", 0, 1, 2);
            }
        }

        int frame_count = 0;
        float q = 0;
        public override void display(CSharpGL.GL gl) {
            //float t = float(GetTickCount() & 0x3FFFF) / float(0x3FFFF);
            float t = q; q += 0.1f;
            //static float q = 0.0f;
            //static const vec3 X(1.0f, 0.0f, 0.0f);
            //static const vec3 Y(0.0f, 1.0f, 0.0f);
            //static const vec3 Z(0.0f, 0.0f, 1.0f);

            var projection_matrix = glm.frustum(-1.0f, 1.0f, -aspect, aspect, 1.0f, 5000.0f)
                * glm.translate(0.0f, 0.0f, -100.0f);
            var model_matrix = glm.rotate(t * 360.0f * 3.0f, 0.0f, 0.0f, 1.0f)
                * glm.rotate(t * 360.0f, 0.0f, 1.0f, 0.0f)
                * glm.scale(0.3f);

            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            gl.glEnable(GL.GL_CULL_FACE);
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glDepthFunc(GL.GL_LEQUAL);

            gl.glUseProgram(render_prog);
            gl.glUniformMatrix4fv(render_model_matrix_loc, 1, false, (float*)&model_matrix);
            gl.glUniformMatrix4fv(render_projection_matrix_loc, 1, false, (float*)&projection_matrix);

            gl.glBindVertexArray(render_vao);

            gl.glBindBufferBase(GL.GL_TRANSFORM_FEEDBACK_BUFFER, 0, geometry_vbo);

            gl.glBeginTransformFeedback(GL.GL_TRIANGLES);
            vbObject.Render();
            gl.glEndTransformFeedback();

            gl.glUseProgram(update_prog);
            model_matrix = mat4.identity();
            gl.glUniformMatrix4fv(model_matrix_loc, 1, false, (float*)&model_matrix);
            gl.glUniformMatrix4fv(projection_matrix_loc, 1, false, (float*)&projection_matrix);
            var count = vbObject.GetVertexCount() / 3;
            gl.glUniform1i(triangle_count_loc, (int)count);

            if (t > q) {
                gl.glUniform1f(time_step_loc, (t - q) * 2000.0f);
            }

            q = t;

            if ((frame_count & 1) != 0) {
                gl.glBindVertexArray(vao[1]);
                gl.glBindBufferBase(GL.GL_TRANSFORM_FEEDBACK_BUFFER, 0, vbo[0]);
            }
            else {
                gl.glBindVertexArray(vao[0]);
                gl.glBindBufferBase(GL.GL_TRANSFORM_FEEDBACK_BUFFER, 0, vbo[1]);
            }

            gl.glBeginTransformFeedback(GL.GL_POINTS);
            gl.glDrawArrays(GL.GL_POINTS, 0, Math.Min(point_count, (frame_count >> 3)));
            gl.glEndTransformFeedback();

            gl.glBindVertexArray(0);

            frame_count++;
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

        ~ch03_xfb() {
            var gl = GL.Current; if (gl == null) return;

            gl.glUseProgram(0);
            gl.glDeleteProgram(update_prog);
            fixed (GLuint* p = vao) {
                gl.glDeleteVertexArrays(2, p);
            }
            fixed (GLuint* p = vbo) {
                gl.glDeleteBuffers(2, p);
            }
        }
    }
}