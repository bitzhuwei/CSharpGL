
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class multidrawindirect : _glSuperBible7code {
        ~multidrawindirect() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public multidrawindirect(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int NUM_DRAWS = 50000;

        struct DrawArraysIndirectCommand {
            public GLuint count;
            public GLuint primCount;
            public GLuint first;
            public GLuint baseInstance;
        };

        GLuint render_program;

        sb7object sb7Obj = new sb7object();

        GLuint indirect_draw_buffer;
        GLuint draw_index_buffer;

        struct _uniforms {
            public GLint time;
            public GLint view_matrix;
            public GLint proj_matrix;
            public GLint viewproj_matrix;
        }
        _uniforms uniforms;

        enum MODE {
            MODE_FIRST,
            MODE_MULTIDRAW = 0,
            MODE_SEPARATE_DRAWS,
            MODE_MAX = MODE_SEPARATE_DRAWS
        }

        MODE mode = MODE.MODE_MULTIDRAW;
        bool paused;
        bool vsync;
        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/multidrawindirect.vert";
                var fsCodeFile = "media/shaders/multidrawindirect.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.render_program = programObj.programId;
                gl.glUseProgram(this.render_program);

                uniforms.time = gl.glGetUniformLocation(render_program, "time");
                uniforms.view_matrix = gl.glGetUniformLocation(render_program, "view_matrix");
                uniforms.proj_matrix = gl.glGetUniformLocation(render_program, "proj_matrix");
                uniforms.viewproj_matrix = gl.glGetUniformLocation(render_program, "viewproj_matrix");
            }
            {

                sb7Obj.load("media/objects/asteroids.sbm");
                var id = stackalloc GLuint[1];
                gl.glGenBuffers(1, id); indirect_draw_buffer = id[0];
                gl.glBindBuffer(0x8F3F/*GL_DRAW_INDIRECT_BUFFER*/, indirect_draw_buffer);
                gl.glBufferData(0x8F3F/*GL_DRAW_INDIRECT_BUFFER*/,
                    NUM_DRAWS * sizeof(DrawArraysIndirectCommand), 0, GL.GL_STATIC_DRAW);

                var cmd = (DrawArraysIndirectCommand*)gl.glMapBufferRange(0x8F3F/*GL_DRAW_INDIRECT_BUFFER*/,
                        0, NUM_DRAWS * sizeof(DrawArraysIndirectCommand), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);

                for (uint i = 0; i < NUM_DRAWS; i++) {
                    sb7Obj.get_sub_object_info(i % sb7Obj.get_sub_object_count(),
                        &cmd[i].first, &cmd[i].count);
                    cmd[i].primCount = 1;
                    cmd[i].baseInstance = i;
                }

                gl.glUnmapBuffer(0x8F3F/*GL_DRAW_INDIRECT_BUFFER*/);

                gl.glBindVertexArray(sb7Obj.get_vao());

                gl.glGenBuffers(1, id); draw_index_buffer = id[0];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, draw_index_buffer);
                gl.glBufferData(GL.GL_ARRAY_BUFFER,
                    NUM_DRAWS * sizeof(GLuint),
                    0,
                    GL.GL_STATIC_DRAW);

                var draw_index = (GLuint*)gl.glMapBufferRange(GL.GL_ARRAY_BUFFER,
                        0, NUM_DRAWS * sizeof(GLuint),
                        GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);

                for (GLuint i = 0; i < NUM_DRAWS; i++) {
                    draw_index[i] = i;
                }

                gl.glUnmapBuffer(GL.GL_ARRAY_BUFFER);

                gl.glVertexAttribIPointer(10, 1, GL.GL_UNSIGNED_INT, 0, 0);
                gl.glVertexAttribDivisor(10, 1);
                gl.glEnableVertexAttribArray(10);

                gl.glEnable(GL.GL_DEPTH_TEST);
                gl.glDepthFunc(GL.GL_LEQUAL);

                gl.glEnable(GL.GL_CULL_FACE);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float total_time = 0;// time
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            total_time += 0.01f;

            var proj_matrix = this.proj_matrix;
            var i = (int)(total_time * 3.0f);

            //gl.glViewport(0, 0, this.width, this.height);
            //gl.glClearBufferfv(GL.GL_COLOR, 0, black);
            //gl.glClearBufferfv(GL.GL_DEPTH, 0, &one);

            mat4 view_matrix = glm.lookAt(
                new vec3(100.0f * (float)Math.Cos(total_time * 0.023f), 100.0f * (float)Math.Cos(total_time * 0.023f), 300.0f * (float)Math.Sin(total_time * 0.037f) - 600.0f),
                new vec3(0.0f, 0.0f, 260.0f),
                (new vec3(0.1f - (float)Math.Cos(total_time * 0.1f) * 0.3f, 1.0f, 0.0f)).normalize());

            gl.glUseProgram(render_program);

            gl.glUniform1f(uniforms.time, total_time);
            gl.glUniformMatrix4fv(uniforms.view_matrix, 1, false, (float*)&view_matrix);
            gl.glUniformMatrix4fv(uniforms.proj_matrix, 1, false, (float*)&proj_matrix);
            var vp = proj_matrix * view_matrix;
            gl.glUniformMatrix4fv(uniforms.viewproj_matrix, 1, false, (float*)&vp);

            gl.glBindVertexArray(sb7Obj.get_vao());

            if (mode == MODE.MODE_MULTIDRAW) {
                gl.glMultiDrawArraysIndirect(GL.GL_TRIANGLES, 0, NUM_DRAWS, 0);
            }
            else if (mode == MODE.MODE_SEPARATE_DRAWS) {
                for (uint j = 0; j < NUM_DRAWS; j++) {
                    GLuint first, count;
                    sb7Obj.get_sub_object_info(j % sb7Obj.get_sub_object_count(), &first, &count);
                    gl.glDrawArraysInstancedBaseInstance(GL.GL_TRIANGLES,
                        (int)first, (int)count, 1, j);
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
            case Keys.V:
            vsync = !vsync;
            //setVsync(vsync);
            gl.wglSwapIntervalEXT(vsync ? 1 : 0);
            break;
            case Keys.D:
            mode = (MODE)(mode + 1);
            if (mode > MODE.MODE_MAX)
                mode = MODE.MODE_FIRST;
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }

        public override Keys[] ValidKeys => [Keys.V, Keys.D];
        public override MouseButtons[] ValidButtons => [];

    }
}