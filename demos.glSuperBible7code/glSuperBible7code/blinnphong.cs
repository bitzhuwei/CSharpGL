
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class blinnphong : _glSuperBible7code {
        ~blinnphong() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public blinnphong(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        GLuint per_fragment_program;

        struct _textures {
            public GLuint color;
            public GLuint normals;
        }
        _textures textures;

        struct uniforms_block {
            public mat4 mv_matrix;
            public mat4 view_matrix;
            public mat4 proj_matrix;
        }

        GLuint uniforms_buffer;

        struct _uniforms {
            public GLint diffuse_albedo;
            public GLint specular_albedo;
            public GLint specular_power;
        }
        _uniforms[] uniforms = new _uniforms[2];

        sb7object sb7Obj = new sb7object();

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/blinnphong.vert";
                var fsCodeFile = "media/shaders/blinnphong.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.per_fragment_program = programObj.programId;
                gl.glUseProgram(this.per_fragment_program);

                uniforms[0].diffuse_albedo = gl.glGetUniformLocation(per_fragment_program, "diffuse_albedo");
                uniforms[0].specular_albedo = gl.glGetUniformLocation(per_fragment_program, "specular_albedo");
                uniforms[0].specular_power = gl.glGetUniformLocation(per_fragment_program, "specular_power");
            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenBuffers(1, id); uniforms_buffer = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, uniforms_buffer);
                gl.glBufferData(GL.GL_UNIFORM_BUFFER, sizeof(uniforms_block), 0, GL.GL_DYNAMIC_DRAW);

                sb7Obj.load("media/objects/sphere.sbm");

                gl.glEnable(GL.GL_CULL_FACE);
                gl.glEnable(GL.GL_DEPTH_TEST);
                gl.glDepthFunc(GL.GL_LEQUAL);
            }
        }

        bool MANY_OBJECTS = true;

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float time = 0;
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        //static GLfloat[] ones = { 1.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            time += 0.01f;

            gl.glUseProgram(per_fragment_program);
            /*
            vmath::mat4 model_matrix = glm.rotate((float)currentTime * 14.5f, 0.0f, 1.0f, 0.0f) *
                                       glm.rotate(180.0f, 0.0f, 0.0f, 1.0f) *
                                       glm.rotate(20.0f, 1.0f, 0.0f, 0.0f);
                                       */

            var view_position = new vec3(0.0f, 0.0f, 50.0f);
            var view_matrix = glm.lookAt(
                view_position,
                new vec3(0.0f, 0.0f, 0.0f),
                new vec3(0.0f, 1.0f, 0.0f));

            var light_position = new vec3(-20.0f, -20.0f, 0.0f);

            var light_proj_matrix = glm.frustum(-1.0f, 1.0f, -1.0f, 1.0f, 1.0f, 200.0f);
            var light_view_matrix = glm.lookAt(
                light_position,
                new vec3(0.0f), new vec3(0.0f, 1.0f, 0.0f));

            if (MANY_OBJECTS) {
                int i, j;

                for (j = 0; j < 7; j++) {
                    for (i = 0; i < 7; i++) {
                        gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, uniforms_buffer);
                        uniforms_block* block = (uniforms_block*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                            0,
                            sizeof(uniforms_block),
                            GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);

                        var model_matrix = glm.translate((float)i * 2.75f - 8.25f, 6.75f - (float)j * 2.25f, 0.0f);

                        block->mv_matrix = view_matrix * model_matrix;
                        block->view_matrix = view_matrix;
                        block->proj_matrix = this.proj_matrix;

                        gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

                        {
                            var value = (float)Math.Pow(2.0f, (float)j + 2.0f);
                            gl.glUniform1f(uniforms[0].specular_power, value);
                        }
                        {
                            var value = new vec3((float)i / 9.0f + 1.0f / 9.0f);
                            gl.glUniform3fv(uniforms[0].specular_albedo, 1, (float*)&value);
                        }

                        sb7Obj.render();
                    }
                }
            }
            else {
                gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, uniforms_buffer);
                uniforms_block* block = (uniforms_block*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                    0,
                    sizeof(uniforms_block),
                    GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);

                var model_matrix = glm.scale(7.0f);

                block->mv_matrix = view_matrix * model_matrix;
                block->view_matrix = view_matrix;
                block->proj_matrix = this.proj_matrix;

                gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

                gl.glUniform1f(uniforms[0].specular_power, 30.0f);
                {
                    var value = new vec3(1.0f);
                    gl.glUniform3fv(uniforms[0].specular_albedo, 1, (float*)&value);
                }

                sb7Obj.render();
            }
        }
        mat4 proj_matrix;
        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);
            this.proj_matrix = glm.perspective(50.0f * (float)Math.PI / 180.0f, (float)width / (float)height, 0.1f, 1000.0f);

            //aspect = (float)height / (float)width;
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }

        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.M:
            MANY_OBJECTS = !MANY_OBJECTS;
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.M];
        public override MouseButtons[] ValidButtons => [];

    }
}