
using CSharpGL;
using demos.glSuperBible7code;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static demos.glSuperBible7code.csflocking;

namespace demos.glSuperBible7code {

    public unsafe class multimaterial : _glSuperBible7code {
        ~multimaterial() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public multimaterial(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int NUM_PASSES = 200;
        const int NUM_CUBES = 256;


        struct transform_t {
            public mat4 mv_matrix;
            public mat4 proj_matrix;
        };
        transform_t[] transforms = new transform_t[NUM_CUBES];
        GLuint simple_uniform_program;
        GLuint ubo_plus_uniform_program;
        GLuint ubo_plus_base_instance_program;
        GLuint vao;
        GLuint buffer;
        struct _uniforms {
            public struct _simple_uniforms {
                public GLint mv_location;
                public GLint proj_location;
            }
            public _simple_uniforms simple_uniforms;
            public struct _ubo_plus_uniform {
                public GLint transform_index;
            }
            public _ubo_plus_uniform ubo_plus_uniform;
        }
        _uniforms uniforms;

        GLuint transform_ubo;
        GLuint indirect_buffer;

        enum MODE {
            SIMPLE_UNIFORM,
            BIG_UBO_WITH_UNIFORM,
            BIG_UBO_WITH_BASEVERTEX,
            BIG_UBO_WITH_INSTANCING,
            BIG_UBO_INDIRECT,
        }
        MODE mode = MODE.BIG_UBO_INDIRECT;
        bool draw_triangles = true;
        bool paused;

        struct draw_indirect_cmd_t {
            public uint count;
            public uint primCount;
            public uint first;
            public uint baseInstance;
        }

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/multimaterial.simpleuniforms.vert";
                var fsCodeFile = "media/shaders/multimaterial.simpleuniforms.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.simple_uniform_program = programObj.programId;
                gl.glUseProgram(this.simple_uniform_program);

                uniforms.simple_uniforms.mv_location = gl.glGetUniformLocation(simple_uniform_program, "mv_matrix");
                uniforms.simple_uniforms.proj_location = gl.glGetUniformLocation(simple_uniform_program, "proj_matrix");
            }
            {
                var vsCodeFile = "media/shaders/multimaterial.ubo-plus-uniform.vert";
                var fsCodeFile = "media/shaders/multimaterial.ubo-plus-uniform.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.ubo_plus_uniform_program = programObj.programId;
                gl.glUseProgram(this.ubo_plus_uniform_program);

                uniforms.ubo_plus_uniform.transform_index = gl.glGetUniformLocation(ubo_plus_uniform_program, "transform_index");
            }
            {
                var vsCodeFile = "media/shaders/multimaterial.ubo-plus-base-instance.vert";
                var fsCodeFile = "media/shaders/multimaterial.ubo-plus-base-instance.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.ubo_plus_base_instance_program = programObj.programId;
                gl.glUseProgram(this.ubo_plus_base_instance_program);

            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);


                gl.glGenBuffers(1, id); buffer = id[0];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, buffer);
                fixed (GLfloat* p = vertex_positions) {
                    gl.glBufferData(GL.GL_ARRAY_BUFFER,
                        sizeof(float) * vertex_positions.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }
                gl.glVertexAttribPointer(0, 3, GL.GL_FLOAT, false, 0, 0);
                gl.glEnableVertexAttribArray(0);

                gl.glEnable(GL.GL_CULL_FACE);
                gl.glFrontFace(GL.GL_CW);

                gl.glEnable(GL.GL_DEPTH_TEST);
                gl.glDepthFunc(GL.GL_LEQUAL);

                gl.glGenBuffers(1, id); transform_ubo = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, transform_ubo);
                gl.glBufferData(GL.GL_UNIFORM_BUFFER, 256 * sizeof(transform_t), 0, GL.GL_DYNAMIC_DRAW);


                gl.glGenBuffers(1, id); indirect_buffer = id[0];
                gl.glBindBuffer(0x8F3F/*GL_DRAW_INDIRECT_BUFFER*/, indirect_buffer);
                gl.glBufferData(0x8F3F/*GL_DRAW_INDIRECT_BUFFER*/, NUM_CUBES * sizeof(draw_indirect_cmd_t), 0, GL.GL_STATIC_DRAW);
                var ind = (draw_indirect_cmd_t*)gl.glMapBufferRange(0x8F3F/*GL_DRAW_INDIRECT_BUFFER*/,
                    0, NUM_CUBES * sizeof(draw_indirect_cmd_t), GL.GL_MAP_INVALIDATE_BUFFER_BIT | GL.GL_MAP_WRITE_BIT);
                for (uint i = 0; i < NUM_CUBES; i++) {
                    ind[i].count = 36;
                    ind[i].primCount = 1;
                    ind[i].first = 0;
                    ind[i].baseInstance = i;
                }
                gl.glUnmapBuffer(0x8F3F/*GL_DRAW_INDIRECT_BUFFER*/);
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

            switch (mode) {
            case MODE.SIMPLE_UNIFORM:
            render_simple_uniform(total_time, gl);
            break;
            case MODE.BIG_UBO_WITH_UNIFORM:
            render_big_ubo_plus_uniform(total_time, gl);
            break;
            case MODE.BIG_UBO_WITH_BASEVERTEX:
            render_big_ubo_base_vertex(total_time, gl);
            break;
            case MODE.BIG_UBO_WITH_INSTANCING:
            render_big_ubo_with_instancing(total_time, gl);
            break;
            case MODE.BIG_UBO_INDIRECT:
            render_big_ubo_indirect(total_time, gl);
            break;
            }
        }

        void render_simple_uniform(float currentTime, GL gl) {
            //static const GLfloat green[] = { 0.0f, 0.25f, 0.0f, 1.0f };
            //static const GLfloat one = 1.0f;
            float f = (float)currentTime * 0.3f;

            //gl.glViewport(0, 0, this.width, this.height);
            //gl.glClearBufferfv(GL_COLOR, 0, green);
            //gl.glClearBufferfv(GL_DEPTH, 0, &one);

            gl.glUseProgram(simple_uniform_program);

            for (var i = 0; i < NUM_CUBES; i++) {
                float fi = 4.0f * (float)i / (float)NUM_CUBES;
                fi = 0.0f;
                transforms[i].proj_matrix = this.proj_matrix;
                transforms[i].mv_matrix =
                    glm.translate(0.0f, 0.0f, -4.0f)
                  * glm.translate((float)Math.Sin(5.1f * f + fi) * 1.0f,
                                  (float)Math.Cos(7.7f * f + fi) * 1.0f,
                                  (float)Math.Sin(6.3f * f + fi) * (float)Math.Cos(1.5f * f + fi) * 2.0f)
                  * glm.rotate(f * 45.0f + fi, 0.0f, 1.0f, 0.0f)
                  * glm.rotate(f * 81.0f + fi, 1.0f, 0.0f, 0.0f);
            }

            for (var j = 0; j < NUM_PASSES; j++) {
                for (var i = 0; i < NUM_CUBES; i++) {
                    {
                        var v = transforms[i].proj_matrix;
                        gl.glUniformMatrix4fv(uniforms.simple_uniforms.proj_location, 1, false, (float*)&v);
                    }
                    {
                        var v = transforms[i].mv_matrix;
                        gl.glUniformMatrix4fv(uniforms.simple_uniforms.mv_location, 1, false, (float*)&v);
                    }
                    gl.glDrawArraysInstancedBaseInstance(draw_triangles ? GL.GL_TRIANGLES : GL.GL_POINTS, 0, 36, 1, 0);
                }
            }
        }

        void render_big_ubo_plus_uniform(float currentTime, GL gl) {
            //static const GLfloat blue[] = { 0.0f, 0.0f, 0.25f, 1.0f };
            //static const GLfloat one = 1.0f;
            float f = (float)currentTime * 0.3f;

            //gl.glViewport(0, 0, this.width, this.height);
            //gl.glClearBufferfv(GL.GL_COLOR, 0, blue);
            //gl.glClearBufferfv(GL.GL_DEPTH, 0, &one);

            gl.glUseProgram(ubo_plus_uniform_program);

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, transform_ubo);
            transform_t* transform = (transform_t*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                0, NUM_CUBES * sizeof(transform_t), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
            for (var i = 0; i < NUM_CUBES; i++) {
                float fi = 4.0f * (float)i / (float)NUM_CUBES;
                fi = 0.0f;
                transform[i].proj_matrix = this.proj_matrix;
                transform[i].mv_matrix =
                    glm.translate(0.0f, 0.0f, -4.0f)
                  * glm.translate((float)Math.Sin(5.1f * f + fi) * 1.0f,
                                  (float)Math.Cos(7.7f * f + fi) * 1.0f,
                                  (float)Math.Sin(6.3f * f + fi) * (float)Math.Cos(1.5f * f + fi) * 2.0f)
                  * glm.rotate(f * 45.0f + fi, 0.0f, 1.0f, 0.0f)
                  * glm.rotate(f * 81.0f + fi, 1.0f, 0.0f, 0.0f);
            }
            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            for (var j = 0; j < NUM_PASSES; j++) {
                for (var i = 0; i < NUM_CUBES; i++) {
                    gl.glUniform1i(uniforms.ubo_plus_uniform.transform_index, i);
                    gl.glDrawArraysInstancedBaseInstance(draw_triangles ? GL.GL_TRIANGLES : GL.GL_POINTS, 0, 36, 1, 0);
                }
            }
        }

        void render_big_ubo_base_vertex(float currentTime, GL gl) {
            //static const GLfloat red[] = { 0.25f, 0.0f, 0.0f, 1.0f };
            //static const GLfloat one = 1.0f;
            float f = (float)currentTime * 0.3f;

            //gl.glViewport(0, 0, this.width, this.height);
            //gl.glClearBufferfv(GL.GL_COLOR, 0, red);
            //gl.glClearBufferfv(GL.GL_DEPTH, 0, &one);

            gl.glUseProgram(ubo_plus_base_instance_program);

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, transform_ubo);
            transform_t* transform = (transform_t*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                0, NUM_CUBES * sizeof(transform_t), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
            for (var i = 0; i < NUM_CUBES; i++) {
                float fi = 4.0f * (float)i / (float)NUM_CUBES;
                fi = 0.0f;
                transform[i].proj_matrix = this.proj_matrix;
                transform[i].mv_matrix =
                    glm.translate(0.0f, 0.0f, -4.0f)
                  * glm.translate((float)Math.Sin(5.1f * f + fi) * 1.0f,
                                  (float)Math.Cos(7.7f * f + fi) * 1.0f,
                                  (float)Math.Sin(6.3f * f + fi) * (float)Math.Cos(1.5f * f + fi) * 2.0f)
                  * glm.rotate(f * 45.0f + fi, 0.0f, 1.0f, 0.0f)
                  * glm.rotate(f * 81.0f + fi, 1.0f, 0.0f, 0.0f);
            }
            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            for (var j = 0; j < NUM_PASSES; j++) {
                for (uint i = 0; i < NUM_CUBES; i++) {
                    gl.glDrawArraysInstancedBaseInstance(draw_triangles ? GL.GL_TRIANGLES : GL.GL_POINTS, 0, 36, 1, i);
                }
            }
        }

        void render_big_ubo_with_instancing(float currentTime, GL gl) {
            //static const GLfloat yellow[] = { 0.25f, 0.25f, 0.0f, 1.0f };
            //static const GLfloat one = 1.0f;
            float f = (float)currentTime * 0.3f;

            //gl.glViewport(0, 0, this.width, this.height);
            //gl.glClearBufferfv(GL.GL_COLOR, 0, yellow);
            //gl.glClearBufferfv(GL.GL_DEPTH, 0, &one);

            gl.glUseProgram(ubo_plus_base_instance_program);

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, transform_ubo);
            transform_t* transform = (transform_t*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                0, NUM_CUBES * sizeof(transform_t), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
            for (var i = 0; i < NUM_CUBES; i++) {
                float fi = 4.0f * (float)i / (float)NUM_CUBES;
                fi = 0.0f;
                transform[i].proj_matrix = this.proj_matrix;
                transform[i].mv_matrix =
                    glm.translate(0.0f, 0.0f, -4.0f)
                  * glm.translate((float)Math.Sin(5.1f * f + fi) * 1.0f,
                                  (float)Math.Cos(7.7f * f + fi) * 1.0f,
                                  (float)Math.Sin(6.3f * f + fi) * (float)Math.Cos(1.5f * f + fi) * 2.0f)
                  * glm.rotate(f * 45.0f + fi, 0.0f, 1.0f, 0.0f)
                  * glm.rotate(f * 81.0f + fi, 1.0f, 0.0f, 0.0f);
            }
            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            for (var j = 0; j < NUM_PASSES; j++) {
                gl.glDrawArraysInstancedBaseInstance(draw_triangles ? GL.GL_TRIANGLES : GL.GL_POINTS, 0, 36, NUM_CUBES, 0);
            }
        }

        void render_big_ubo_indirect(float currentTime, GL gl) {
            //static const GLfloat purple[] = { 0.25f, 0.0f, 0.25f, 1.0f };
            //static const GLfloat one = 1.0f;
            float f = (float)currentTime * 0.3f;

            //gl.glViewport(0, 0, this.width, this.height);
            //gl.glClearBufferfv(GL.GL_COLOR, 0, purple);
            //gl.glClearBufferfv(GL.GL_DEPTH, 0, &one);

            gl.glUseProgram(ubo_plus_base_instance_program);

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, transform_ubo);
            transform_t* transform = (transform_t*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                0, NUM_CUBES * sizeof(transform_t), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
            for (var i = 0; i < NUM_CUBES; i++) {
                float fi = 4.0f * (float)i / (float)NUM_CUBES;
                fi = 0.0f;
                transform[i].proj_matrix = this.proj_matrix;
                transform[i].mv_matrix =
                    glm.translate(0.0f, 0.0f, -4.0f)
                  * glm.translate((float)Math.Sin(5.1f * f + fi) * 1.0f,
                                  (float)Math.Cos(7.7f * f + fi) * 1.0f,
                                  (float)Math.Sin(6.3f * f + fi) * (float)Math.Cos(1.5f * f + fi) * 2.0f)
                  * glm.rotate(f * 45.0f + fi, 0.0f, 1.0f, 0.0f)
                  * glm.rotate(f * 81.0f + fi, 1.0f, 0.0f, 0.0f);
            }
            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            gl.glBindBuffer(0x8F3F/*GL_DRAW_INDIRECT_BUFFER*/, indirect_buffer);

            for (var j = 0; j < NUM_PASSES; j++) {
                gl.glMultiDrawArraysIndirect(draw_triangles ? GL.GL_TRIANGLES : GL.GL_POINTS, 0, NUM_CUBES, 0);
                /*
                for (var i = 0; i < NUM_CUBES; i++)
                {
                    glDrawArraysInstancedBaseInstance(draw_triangles ? GL.GL_TRIANGLES : GL.GL_POINTS, 0, 36, 1, i);
                }
                */
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
            case Keys.T:
            draw_triangles = !draw_triangles;
            break;
            case Keys.M:
            mode = (MODE)(mode + 1);
            if (mode > MODE.BIG_UBO_INDIRECT)
                mode = MODE.SIMPLE_UNIFORM;
            break;
            case Keys.Escape:// 27:
                             //exit(0);
            this.mainForm.Close();
            break;
            }
        }

        public override Keys[] ValidKeys => [Keys.T, Keys.M];
        public override MouseButtons[] ValidButtons => [];


        static GLfloat[] vertex_positions =
        {
            -0.25f,  0.25f, -0.25f,
            -0.25f, -0.25f, -0.25f,
             0.25f, -0.25f, -0.25f,

             0.25f, -0.25f, -0.25f,
             0.25f,  0.25f, -0.25f,
            -0.25f,  0.25f, -0.25f,

             0.25f, -0.25f, -0.25f,
             0.25f, -0.25f,  0.25f,
             0.25f,  0.25f, -0.25f,

             0.25f, -0.25f,  0.25f,
             0.25f,  0.25f,  0.25f,
             0.25f,  0.25f, -0.25f,

             0.25f, -0.25f,  0.25f,
            -0.25f, -0.25f,  0.25f,
             0.25f,  0.25f,  0.25f,

            -0.25f, -0.25f,  0.25f,
            -0.25f,  0.25f,  0.25f,
             0.25f,  0.25f,  0.25f,

            -0.25f, -0.25f,  0.25f,
            -0.25f, -0.25f, -0.25f,
            -0.25f,  0.25f,  0.25f,

            -0.25f, -0.25f, -0.25f,
            -0.25f,  0.25f, -0.25f,
            -0.25f,  0.25f,  0.25f,

            -0.25f, -0.25f,  0.25f,
             0.25f, -0.25f,  0.25f,
             0.25f, -0.25f, -0.25f,

             0.25f, -0.25f, -0.25f,
            -0.25f, -0.25f, -0.25f,
            -0.25f, -0.25f,  0.25f,

            -0.25f,  0.25f, -0.25f,
             0.25f,  0.25f, -0.25f,
             0.25f,  0.25f,  0.25f,

             0.25f,  0.25f,  0.25f,
            -0.25f,  0.25f,  0.25f,
            -0.25f,  0.25f, -0.25f
        };
    }
}