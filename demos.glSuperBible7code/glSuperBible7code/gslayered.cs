
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static CSharpGL.TransformFeedbackObject;

namespace demos.glSuperBible7code {

    public unsafe class gslayered : _glSuperBible7code {
        ~gslayered() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public gslayered(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint program_gslayers;
        GLuint program_showlayers;
        GLuint vao;
        int mode;
        GLuint transform_ubo;

        GLuint layered_fbo;
        GLuint array_texture;
        GLuint array_depth;

        sb7object obj = new sb7object();

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/gslayered.showlayers.vert";
                var fsCodeFile = "media/shaders/gslayered.showlayers.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program_showlayers = programObj.programId;
                gl.glUseProgram(this.program_showlayers);

            }
            {
                var vsCodeFile = "media/shaders/gslayered.gslayers.vert";
                var gsCodeFile = "media/shaders/gslayered.gslayers.geom";
                var fsCodeFile = "media/shaders/gslayered.gslayers.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, gsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program_gslayers = programObj.programId;
                gl.glUseProgram(this.program_gslayers);

            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);

                obj.load("media/objects/torus.sbm");

                gl.glGenBuffers(1, id); transform_ubo = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, transform_ubo);
                gl.glBufferData(GL.GL_UNIFORM_BUFFER, 17 * sizeof(mat4), 0, GL.GL_DYNAMIC_DRAW);

                gl.glGenTextures(1, id); array_texture = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D_ARRAY, array_texture);
                gl.glTexStorage3D(GL.GL_TEXTURE_2D_ARRAY, 1, GL.GL_RGBA8, 256, 256, 16);

                gl.glGenTextures(1, id); array_depth = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D_ARRAY, array_depth);
                gl.glTexStorage3D(GL.GL_TEXTURE_2D_ARRAY, 1, GL.GL_DEPTH_COMPONENT32, 256, 256, 16);

                gl.glGenFramebuffers(1, id); layered_fbo = id[0];
                gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, layered_fbo);
                gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT0, array_texture, 0);
                gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_DEPTH_ATTACHMENT, array_depth, 0);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float t = 0;// time
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        static GLfloat[] black = { 0.0f, 0.0f, 0.0f, 1.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 1.0f };
        static GLfloat one = 1.0f;

        struct TRANSFORM_BUFFER {
            public mat4 proj_matrix;
            //public fixed mat4 mv_matrix[16];
            public fixed float mv_matrix[16 * 16];

            public void SetMat(int index, mat4 mat) {
                for (int i = 0; i < 4; i++) {
                    var col = mat[i];
                    mv_matrix[index * 16 + i * 4 + 0] = col.x;
                    mv_matrix[index * 16 + i * 4 + 1] = col.y;
                    mv_matrix[index * 16 + i * 4 + 2] = col.z;
                    mv_matrix[index * 16 + i * 4 + 3] = col.w;
                }
            }
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            t += 0.01f;

            var proj_matrix = this.proj_matrix;

            mat4 mv_matrix = glm.translate(0.0f, 0.0f, -4.0f) *
                glm.rotate((float)t * 5.0f, 0.0f, 0.0f, 1.0f) *
                glm.rotate((float)t * 30.0f, 1.0f, 0.0f, 0.0f);
            mat4 mvp = proj_matrix * mv_matrix;

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, transform_ubo);

            var buffer = (TRANSFORM_BUFFER*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                0, sizeof(TRANSFORM_BUFFER), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
            buffer->proj_matrix = proj_matrix;// glm.perspective(50.0f, 1.0f, 0.1f, 1000.0f); // proj_matrix;
            for (var i = 0; i < 16; i++) {
                float fi = (float)(i + 12) / 16.0f;
                var mat = glm.translate(0.0f, 0.0f, -4.0f) *
                        glm.rotate((float)t * 25.0f * fi, 0.0f, 0.0f, 1.0f) *
                        glm.rotate((float)t * 30.0f * fi, 1.0f, 0.0f, 0.0f);
                buffer->SetMat(i, mat);
            }
            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            GLenum ca0 = GL.GL_COLOR_ATTACHMENT0;

            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, layered_fbo);
            gl.glDrawBuffers(1, &ca0);
            gl.glViewport(0, 0, 256, 256);
            //fixed (float* p = black) {
            //    gl.glClearBufferfv(GL.GL_COLOR, 0, p);
            //}
            //var one_ = one;
            //gl.glClearBufferfv(GL.GL_DEPTH, 0, &one_);
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glDepthFunc(GL.GL_LEQUAL);

            gl.glUseProgram(program_gslayers);

            obj.render();

            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, 0);
            gl.glDrawBuffer(GL.GL_BACK);
            gl.glUseProgram(program_showlayers);

            gl.glViewport(0, 0, this.width, this.height);
            fixed (float* p = gray) {
                gl.glClearBufferfv(GL.GL_COLOR, 0, p);
            }
            //gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            gl.glBindTexture(GL.GL_TEXTURE_2D_ARRAY, array_texture);
            gl.glDisable(GL.GL_DEPTH_TEST);

            gl.glBindVertexArray(vao);
            gl.glDrawArraysInstanced(GL.GL_TRIANGLE_FAN, 0, 4, 16);

            gl.glBindTexture(GL.GL_TEXTURE_2D_ARRAY, 0);
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
            case Keys.M:
            mode = (mode + 1) % 2;
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