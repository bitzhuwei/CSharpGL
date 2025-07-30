
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;
using static demos.glSuperBible7code.csflocking;

namespace demos.glSuperBible7code {

    public unsafe class ssao : _glSuperBible7code {
        ~ssao() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public ssao(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        GLuint render_program;
        GLuint ssao_program;
        bool paused;

        GLuint render_fbo;
        GLuint[] fbo_textures = new uint[3];
        GLuint quad_vao;
        GLuint points_buffer;

        sb7object sb7Obj = new sb7object();
        sb7object cube = new sb7object();

        struct _uniforms {
            public struct _render {
                public GLint mv_matrix;
                public GLint proj_matrix;
                public GLint shading_level;
            }
            public _render render;
            public struct _ssao {
                public GLint ssao_level;
                public GLint object_level;
                public GLint ssao_radius;
                public GLint weight_by_angle;
                public GLint randomize_points;
                public GLint point_count;
            }
            public _ssao ssao;
        }
        _uniforms uniforms;

        bool show_shading = true;
        bool show_ao = true;
        float ssao_level = 1;
        float ssao_radius = 0.05f;
        bool weight_by_angle = true;
        bool randomize_points = true;
        uint point_count = 10;

        struct SAMPLE_POINTS {
            //vec4 point[256];
            public fixed float point[256 * 4];
            //vec4 random_vectors[256];
            public fixed float random_vectors[256 * 4];
        };

        static GLenum[] draw_buffers = { GL.GL_COLOR_ATTACHMENT0, GL.GL_COLOR_ATTACHMENT1 };
        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/ssao.render.vert";
                var fsCodeFile = "media/shaders/ssao.render.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.render_program = programObj.programId;
                gl.glUseProgram(this.render_program);

                uniforms.render.mv_matrix = gl.glGetUniformLocation(render_program, "mv_matrix");
                uniforms.render.proj_matrix = gl.glGetUniformLocation(render_program, "proj_matrix");
                uniforms.render.shading_level = gl.glGetUniformLocation(render_program, "shading_level");
            }
            {
                var vsCodeFile = "media/shaders/ssao.vert";
                var fsCodeFile = "media/shaders/ssao.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.ssao_program = programObj.programId;
                gl.glUseProgram(this.ssao_program);

                uniforms.ssao.ssao_radius = gl.glGetUniformLocation(ssao_program, "ssao_radius");
                uniforms.ssao.ssao_level = gl.glGetUniformLocation(ssao_program, "ssao_level");
                uniforms.ssao.object_level = gl.glGetUniformLocation(ssao_program, "object_level");
                uniforms.ssao.weight_by_angle = gl.glGetUniformLocation(ssao_program, "weight_by_angle");
                uniforms.ssao.randomize_points = gl.glGetUniformLocation(ssao_program, "randomize_points");
                uniforms.ssao.point_count = gl.glGetUniformLocation(ssao_program, "point_count");
            }
            {
                GLuint id;
                gl.glGenFramebuffers(1, &id); render_fbo = id;
                gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, render_fbo);
                var ids = stackalloc GLuint[3];
                gl.glGenTextures(3, ids); for (var i = 0; i < 3; i++) { fbo_textures[i] = ids[i]; }

                gl.glBindTexture(GL.GL_TEXTURE_2D, fbo_textures[0]);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_RGB16F, 2048, 2048);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);

                gl.glBindTexture(GL.GL_TEXTURE_2D, fbo_textures[1]);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_RGBA32F, 2048, 2048);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);

                gl.glBindTexture(GL.GL_TEXTURE_2D, fbo_textures[2]);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_DEPTH_COMPONENT32F, 2048, 2048);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_EDGE);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP_TO_EDGE);

                gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT0, fbo_textures[0], 0);
                gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT1, fbo_textures[1], 0);
                gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_DEPTH_ATTACHMENT, fbo_textures[2], 0);

                fixed (GLenum* p = draw_buffers) {
                    gl.glDrawBuffers(2, p);
                }

                gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, 0);

                gl.glGenVertexArrays(1, &id); quad_vao = id;
                gl.glBindVertexArray(quad_vao);

                sb7Obj.load("media/objects/dragon.sbm");
                cube.load("media/objects/cube.sbm");

                gl.glEnable(GL.GL_DEPTH_TEST);
                gl.glEnable(GL.GL_CULL_FACE);

                SAMPLE_POINTS point_data = new SAMPLE_POINTS();

                for (var i = 0; i < 256; i++) {
                    float length2;
                    do {
                        point_data.point[i * 4 + 0] = random_float() * 2.0f - 1.0f;
                        point_data.point[i * 4 + 1] = random_float() * 2.0f - 1.0f;
                        point_data.point[i * 4 + 2] = random_float(); //  * 2.0f - 1.0f;
                        point_data.point[i * 4 + 3] = 0.0f;
                        var x = point_data.point[i * 4 + 0];
                        var y = point_data.point[i * 4 + 1];
                        var z = point_data.point[i * 4 + 2];
                        var w = point_data.point[i * 4 + 3];
                        length2 = x * x + y * y + z * z + w * w;
                    } while (length2 > 1.0f);
                    {
                        var x = point_data.point[i * 4 + 0];
                        var y = point_data.point[i * 4 + 1];
                        var z = point_data.point[i * 4 + 2];
                        var w = point_data.point[i * 4 + 3];
                        var point = new vec4(x, y, z, w); point = point.normalize();
                        point_data.point[i * 4 + 0] = point.x;
                        point_data.point[i * 4 + 1] = point.y;
                        point_data.point[i * 4 + 2] = point.z;
                        point_data.point[i * 4 + 3] = point.w;
                    }
                }
                for (var i = 0; i < 256; i++) {
                    point_data.random_vectors[i * 4 + 0] = random_float();
                    point_data.random_vectors[i * 4 + 1] = random_float();
                    point_data.random_vectors[i * 4 + 2] = random_float();
                    point_data.random_vectors[i * 4 + 3] = random_float();
                }

                gl.glGenBuffers(1, &id); points_buffer = id;
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, points_buffer);
                gl.glBufferData(GL.GL_UNIFORM_BUFFER, sizeof(SAMPLE_POINTS), (IntPtr)(&point_data), GL.GL_STATIC_DRAW);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float time = 0;// time
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        static GLfloat[] black = { 0.0f, 0.0f, 0.0f, 0.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            time += 0.01f;

            var proj_matrix = this.proj_matrix;

            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, render_fbo);
            gl.glEnable(GL.GL_DEPTH_TEST);

            fixed (GLfloat* p = black) {
                gl.glClearBufferfv(GL.GL_COLOR, 0, p);
                gl.glClearBufferfv(GL.GL_COLOR, 1, p);
            }
            fixed (GLfloat* p = ones) {
                gl.glClearBufferfv(GL.GL_DEPTH, 0, p);
            }

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, points_buffer);

            gl.glUseProgram(render_program);

            mat4 lookat_matrix = glm.lookAt(
                new vec3(0.0f, 3.0f, 15.0f),
                new vec3(0.0f, 0.0f, 0.0f),
                new vec3(0.0f, 1.0f, 0.0f));

            gl.glUniformMatrix4fv(uniforms.render.proj_matrix, 1, false, (float*)&proj_matrix);

            mat4 mv_matrix = glm.translate(0.0f, -5.0f, 0.0f) *
                glm.rotate(time * 5.0f, 0.0f, 1.0f, 0.0f) *
                mat4.identity();
            {
                var value = lookat_matrix * mv_matrix;
                gl.glUniformMatrix4fv(uniforms.render.mv_matrix, 1, false, (float*)&value);
            }

            gl.glUniform1f(uniforms.render.shading_level, show_shading ? (show_ao ? 0.7f : 1.0f) : 0.0f);

            sb7Obj.render();

            mv_matrix = glm.translate(0.0f, -4.5f, 0.0f) *
                glm.rotate(time * 5.0f, 0.0f, 1.0f, 0.0f) *
            glm.scale(4000.0f, 0.1f, 4000.0f) *
                mat4.identity();
            {
                var value = lookat_matrix * mv_matrix;
                gl.glUniformMatrix4fv(uniforms.render.mv_matrix, 1, false, (float*)&value);
            }

            cube.render();

            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, 0);
            gl.glUseProgram(ssao_program);

            gl.glUniform1f(uniforms.ssao.ssao_radius, ssao_radius * (float)(this.width) / 1000.0f);
            gl.glUniform1f(uniforms.ssao.ssao_level, show_ao ? (show_shading ? 0.3f : 1.0f) : 0.0f);
            //gl.glUniform1i(uniforms.ssao.weight_by_angle, weight_by_angle ? 1 : 0);
            gl.glUniform1i(uniforms.ssao.randomize_points, randomize_points ? 1 : 0);
            gl.glUniform1ui(uniforms.ssao.point_count, point_count);

            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, fbo_textures[0]);
            gl.glActiveTexture(GL.GL_TEXTURE1);
            gl.glBindTexture(GL.GL_TEXTURE_2D, fbo_textures[1]);

            gl.glDisable(GL.GL_DEPTH_TEST);
            gl.glBindVertexArray(quad_vao);
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
            case Keys.N:
            weight_by_angle = !weight_by_angle;
            break;
            case Keys.R:
            randomize_points = !randomize_points;
            break;
            case Keys.S:
            point_count++;
            break;
            case Keys.X:
            point_count--;
            break;
            case Keys.Q:
            show_shading = !show_shading;
            break;
            case Keys.W:
            show_ao = !show_ao;
            break;
            case Keys.A:
            ssao_radius += 0.01f;
            break;
            case Keys.Z:
            ssao_radius -= 0.01f;
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.N, Keys.R, Keys.S, Keys.X, Keys.Q, Keys.W, Keys.A, Keys.Z];
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