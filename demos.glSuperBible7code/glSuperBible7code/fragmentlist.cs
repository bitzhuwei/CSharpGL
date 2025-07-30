
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static demos.glSuperBible7code.csflocking;

namespace demos.glSuperBible7code {

    public unsafe class fragmentlist : _glSuperBible7code {
        ~fragmentlist() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public fragmentlist(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        GLuint clear_program;
        GLuint append_program;
        GLuint resolve_program;

        struct _textures {
            public GLuint color;
            public GLuint normals;
        }
        _textures textures;

        struct uniforms_block {
            public mat4 mv_matrix;
            public mat4 view_matrix;
            public mat4 proj_matrix;
        };

        GLuint uniforms_buffer;

        struct _uniforms {
            public GLint mvp;
        }
        _uniforms uniforms;

        sb7object sb7Obj = new sb7object();

        GLuint fragment_buffer;
        GLuint head_pointer_image;
        GLuint atomic_counter_buffer;
        GLuint dummy_vao;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/fragmentlist.clear.vert";
                var fsCodeFile = "media/shaders/fragmentlist.clear.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.clear_program = programObj.programId;
                gl.glUseProgram(this.clear_program);

            }
            {
                var vsCodeFile = "media/shaders/fragmentlist.append.vert";
                var fsCodeFile = "media/shaders/fragmentlist.append.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.append_program = programObj.programId;
                gl.glUseProgram(this.append_program);

                uniforms.mvp = gl.glGetUniformLocation(append_program, "mvp");

            }
            {
                var vsCodeFile = "media/shaders/fragmentlist.resolve.vert";
                var fsCodeFile = "media/shaders/fragmentlist.resolve.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.resolve_program = programObj.programId;
                gl.glUseProgram(this.resolve_program);

            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenBuffers(1, id); uniforms_buffer = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, uniforms_buffer);
                gl.glBufferData(GL.GL_UNIFORM_BUFFER, sizeof(uniforms_block), 0, GL.GL_DYNAMIC_DRAW);

                sb7Obj.load("media/objects/dragon.sbm");

                gl.glGenBuffers(1, id); fragment_buffer = id[0];
                gl.glBindBuffer(GL.GL_SHADER_STORAGE_BUFFER, fragment_buffer);
                gl.glBufferData(GL.GL_SHADER_STORAGE_BUFFER, 1024 * 1024 * 16, 0, GL.GL_DYNAMIC_COPY);

                gl.glGenBuffers(1, id); atomic_counter_buffer = id[0];
                gl.glBindBuffer(GL.GL_ATOMIC_COUNTER_BUFFER, atomic_counter_buffer);
                gl.glBufferData(GL.GL_ATOMIC_COUNTER_BUFFER, 4, 0, GL.GL_DYNAMIC_COPY);

                gl.glGenTextures(1, id); head_pointer_image = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D, head_pointer_image);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_R32UI, 1024, 1024);

                gl.glGenVertexArrays(1, id); dummy_vao = id[0];
                gl.glBindVertexArray(dummy_vao);
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
            currentTime += 0.01f;

            var proj_matrix = this.proj_matrix;


            gl.glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT | GL.GL_ATOMIC_COUNTER_BARRIER_BIT | GL.GL_SHADER_STORAGE_BARRIER_BIT);

            gl.glUseProgram(clear_program);
            gl.glBindVertexArray(dummy_vao);
            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);

            gl.glUseProgram(append_program);

            mat4 model_matrix = glm.scale(7.0f);
            vec3 view_position = new vec3((float)Math.Cos(currentTime * 0.35f) * 120.0f, (float)Math.Cos(currentTime * 0.4f) * 30.0f, (float)Math.Sin(currentTime * 0.35f) * 120.0f);
            mat4 view_matrix = glm.lookAt(view_position,
                new vec3(0.0f, 30.0f, 0.0f),
                new vec3(0.0f, 1.0f, 0.0f));

            mat4 mv_matrix = view_matrix * model_matrix;
            mat4 mvp = proj_matrix * mv_matrix;
            gl.glUniformMatrix4fv(uniforms.mvp, 1, false, (float*)&mvp);

            uint zero = 0;
            gl.glBindBufferBase(GL.GL_ATOMIC_COUNTER_BUFFER, 0, atomic_counter_buffer);
            gl.glBufferSubData(GL.GL_ATOMIC_COUNTER_BUFFER, 0, sizeof(uint), (IntPtr)(&zero));

            gl.glBindBufferBase(GL.GL_SHADER_STORAGE_BUFFER, 0, fragment_buffer);

            gl.glBindImageTexture(0, head_pointer_image, 0, false, 0, GL.GL_READ_WRITE, GL.GL_R32UI);

            gl.glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT | GL.GL_ATOMIC_COUNTER_BARRIER_BIT | GL.GL_SHADER_STORAGE_BARRIER_BIT);

            sb7Obj.render();

            gl.glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT | GL.GL_ATOMIC_COUNTER_BARRIER_BIT | GL.GL_SHADER_STORAGE_BARRIER_BIT);

            gl.glUseProgram(resolve_program);

            gl.glBindVertexArray(dummy_vao);

            gl.glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT | GL.GL_ATOMIC_COUNTER_BARRIER_BIT | GL.GL_SHADER_STORAGE_BARRIER_BIT);

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
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [];
        public override MouseButtons[] ValidButtons => [];

    }
}