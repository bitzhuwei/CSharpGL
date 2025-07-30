
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class csflocking : _glSuperBible7code {
        ~csflocking() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public csflocking(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int WORKGROUP_SIZE = 256, NUM_WORKGROUPS = 64, FLOCK_SIZE = (NUM_WORKGROUPS * WORKGROUP_SIZE);
        GLuint flock_update_program;
        GLuint flock_render_program;

        GLuint[] flock_buffer = new uint[2];

        GLuint[] flock_render_vao = new uint[2];
        GLuint geometry_buffer;

        public struct flock_member {
            public vec3 position;
            public uint noUse;// 32;
            public vec3 velocity;
            public uint noUse2;// 32;
        }

        public struct _uniforms {
            public struct _update {
                public GLint goal;
            }
            public _update update;
            public struct _render {
                public GLint mvp;
            }
            public _render render;
        }
        public _uniforms uniforms;

        GLuint frame_index;
        public override void init(CSharpGL.GL gl) {
            {
                var csCodeFile = "media/shaders/csflocking.comp";
                var programObj = Utility.LoadShaders((csCodeFile, Shader.Kind.comp));
                Debug.Assert(programObj != null); this.flock_update_program = programObj.programId;
                gl.glUseProgram(this.flock_update_program);

            }
            {
                var vsCodeFile = "media/shaders/csflocking.vert";
                var fsCodeFile = "media/shaders/csflocking.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.flock_render_program = programObj.programId;
                gl.glUseProgram(this.flock_render_program);
                uniforms.render.mvp = gl.glGetUniformLocation(flock_render_program, "mvp");

            }
            {
                var id2 = stackalloc GLuint[2];
                gl.glGenBuffers(2, id2); flock_buffer[0] = id2[0]; flock_buffer[1] = id2[1];
                gl.glBindBuffer(GL.GL_SHADER_STORAGE_BUFFER, flock_buffer[0]);
                gl.glBufferData(GL.GL_SHADER_STORAGE_BUFFER, FLOCK_SIZE * sizeof(flock_member), 0, GL.GL_DYNAMIC_COPY);
                gl.glBindBuffer(GL.GL_SHADER_STORAGE_BUFFER, flock_buffer[1]);
                gl.glBufferData(GL.GL_SHADER_STORAGE_BUFFER, FLOCK_SIZE * sizeof(flock_member), 0, GL.GL_DYNAMIC_COPY);

                int i;

                var id = stackalloc GLuint[1];
                gl.glGenBuffers(1, id); geometry_buffer = id[0];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, geometry_buffer);
                fixed (vec3* p = geometry) {
                    gl.glBufferData(GL.GL_ARRAY_BUFFER, sizeof(vec3) * geometry.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }

                gl.glGenVertexArrays(2, id2); flock_render_vao[0] = id2[0]; flock_render_vao[1] = id2[1];

                for (i = 0; i < 2; i++) {
                    gl.glBindVertexArray(flock_render_vao[i]);
                    gl.glBindBuffer(GL.GL_ARRAY_BUFFER, geometry_buffer);
                    gl.glVertexAttribPointer(0, 3, GL.GL_FLOAT, false, 0, 0);
                    gl.glVertexAttribPointer(1, 3, GL.GL_FLOAT, false, 0, (8 * sizeof(vec3)));

                    gl.glBindBuffer(GL.GL_ARRAY_BUFFER, flock_buffer[i]);
                    gl.glVertexAttribPointer(2, 3, GL.GL_FLOAT, false, sizeof(flock_member), 0);
                    gl.glVertexAttribPointer(3, 3, GL.GL_FLOAT, false, sizeof(flock_member), sizeof(vec4));
                    gl.glVertexAttribDivisor(2, 1);
                    gl.glVertexAttribDivisor(3, 1);

                    gl.glEnableVertexAttribArray(0);
                    gl.glEnableVertexAttribArray(1);
                    gl.glEnableVertexAttribArray(2);
                    gl.glEnableVertexAttribArray(3);
                }

                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, flock_buffer[0]);
                var ptr = (flock_member*)gl.glMapBufferRange(GL.GL_ARRAY_BUFFER,
                    0, FLOCK_SIZE * sizeof(flock_member), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
                var random = new Random();
                for (i = 0; i < FLOCK_SIZE; i++) {
                    ptr[i].position = (new vec3(random.NextSingle(), random.NextSingle(), random.NextSingle()) - new vec3(0.5f)) * 300.0f;
                    ptr[i].velocity = (new vec3(random.NextSingle(), random.NextSingle(), random.NextSingle()) - new vec3(0.5f));
                }
                gl.glUnmapBuffer(GL.GL_ARRAY_BUFFER);

                gl.glEnable(GL.GL_DEPTH_TEST);
                gl.glDepthFunc(GL.GL_LEQUAL);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float time = 0;
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            time += 0.01f;

            var proj_matrix = this.proj_matrix;

            gl.glUseProgram(flock_update_program);

            var goal = new vec3(
                (float)Math.Sin(time * 0.34f),
                (float)Math.Cos(time * 0.29f),
                (float)Math.Sin(time * 0.12f) * (float)Math.Cos(time * 0.5f)
                );

            goal = goal * new vec3(35.0f, 25.0f, 60.0f);

            gl.glUniform3fv(uniforms.update.goal, 1, (float*)&goal);

            gl.glBindBufferBase(GL.GL_SHADER_STORAGE_BUFFER, 0, flock_buffer[frame_index]);
            gl.glBindBufferBase(GL.GL_SHADER_STORAGE_BUFFER, 1, flock_buffer[frame_index ^ 1]);

            gl.glDispatchCompute(NUM_WORKGROUPS, 1, 1);

            //gl.glClearBufferfv(GL.GL_COLOR, 0, black);
            //gl.glClearBufferfv(GL.GL_DEPTH, 0, &one);

            gl.glUseProgram(flock_render_program);

            var mv_matrix = glm.lookAt(
                new vec3(0.0f, 0.0f, -400.0f),
                new vec3(0.0f, 0.0f, 0.0f),
                new vec3(0.0f, 1.0f, 0.0f));
            var mvp = proj_matrix * mv_matrix;

            gl.glUniformMatrix4fv(uniforms.render.mvp, 1, false, (float*)&mvp);

            gl.glBindVertexArray(flock_render_vao[frame_index]);

            gl.glDrawArraysInstanced(GL.GL_TRIANGLE_STRIP, 0, 8, FLOCK_SIZE);

            frame_index ^= 1;
        }

        mat4 proj_matrix;
        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);

            //aspect = (float)height / (float)width;
            this.proj_matrix = glm.perspective(60.0f * (float)Math.PI / 180.0f, (float)width / (float)height, 0.1f, 1000.0f);
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

        // This is position and normal data for a paper airplane
        static vec3[] geometry =
        {
			// Positions
			new vec3(-5.0f, 1.0f, 0.0f),
            new vec3(-1.0f, 1.5f, 0.0f),
            new vec3(-1.0f, 1.5f, 7.0f),
            new vec3(0.0f, 0.0f, 0.0f),
            new vec3(0.0f, 0.0f, 10.0f),
            new vec3(1.0f, 1.5f, 0.0f),
            new vec3(1.0f, 1.5f, 7.0f),
            new vec3(5.0f, 1.0f, 0.0f),

			// Normals
			new vec3(0.0f),
            new vec3(0.0f),
            new vec3(0.107f, -0.859f, 0.00f),
            new vec3(0.832f, 0.554f, 0.00f),
            new vec3(-0.59f, -0.395f, 0.00f),
            new vec3(-0.832f, 0.554f, 0.00f),
            new vec3(0.295f, -0.196f, 0.00f),
            new vec3(0.124f, 0.992f, 0.00f),
        };
    }
}