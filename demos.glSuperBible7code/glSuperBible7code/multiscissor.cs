
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class multiscissor : _glSuperBible7code {
        ~multiscissor() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public multiscissor(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint program;
        GLuint vao;
        GLuint position_buffer;
        GLuint index_buffer;
        GLuint uniform_buffer;
        GLint mv_location;
        GLint proj_location;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/multiscissor.vert";
                var gsCodeFile = "media/shaders/multiscissor.geom";
                var fsCodeFile = "media/shaders/multiscissor.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, gsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program = programObj.programId;
                gl.glUseProgram(this.program);

                mv_location = gl.glGetUniformLocation(program, "mv_matrix");
                proj_location = gl.glGetUniformLocation(program, "proj_matrix");

            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);


                gl.glGenBuffers(1, id); position_buffer = id[0];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, position_buffer);
                fixed (float* p = vertex_positions) {
                    gl.glBufferData(GL.GL_ARRAY_BUFFER,
                        sizeof(float) * vertex_positions.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }
                gl.glVertexAttribPointer(0, 3, GL.GL_FLOAT, false, 0, 0);
                gl.glEnableVertexAttribArray(0);

                gl.glGenBuffers(1, id); index_buffer = id[0];
                gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, index_buffer);
                fixed (GLushort* p = vertex_indices) {
                    gl.glBufferData(GL.GL_ELEMENT_ARRAY_BUFFER,
                        sizeof(GLushort) * vertex_indices.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }

                gl.glGenBuffers(1, id); uniform_buffer = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, uniform_buffer);
                gl.glBufferData(GL.GL_UNIFORM_BUFFER, 4 * sizeof(mat4), 0, GL.GL_DYNAMIC_DRAW);

                gl.glEnable(GL.GL_CULL_FACE);
                // glFrontFace(GL.GL_CW);

                gl.glEnable(GL.GL_DEPTH_TEST);
                gl.glDepthFunc(GL.GL_LEQUAL);
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
        static GLfloat[] black = { 0.0f, 0.0f, 0.0f, 1.0f };
        static GLfloat one = 1.0f;
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            currentTime += 0.01f;

            var proj_matrix = this.proj_matrix;

            gl.glDisable(GL.GL_SCISSOR_TEST);

            //gl.glViewport(0, 0, this.width, this.height);
            fixed (GLfloat* p = black) {
                gl.glClearBufferfv(GL.GL_COLOR, 0, p);
            }
            var one_ = one;
            gl.glClearBufferfv(GL.GL_DEPTH, 0, &one_);

            // Turn on scissor testing
            gl.glEnable(GL.GL_SCISSOR_TEST);

            // Each rectangle will be 7/16 of the screen
            int scissor_width = (7 * this.width) / 16;
            int scissor_height = (7 * this.height) / 16;

            // Four rectangles - lower left first...
            gl.glScissorIndexed(0,
                0, 0,
                scissor_width, scissor_height);

            // Lower right...
            gl.glScissorIndexed(1,
                this.width - scissor_width, 0,
                scissor_width, scissor_height);

            // Upper left...
            gl.glScissorIndexed(2,
                0, this.height - scissor_height,
                scissor_width, scissor_height);

            // Upper right...
            gl.glScissorIndexed(3,
                this.width - scissor_width,
                this.height - scissor_height,
                scissor_width, scissor_height);

            gl.glUseProgram(program);

            float f = (float)currentTime * 0.3f;

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, uniform_buffer);
            mat4* mv_matrix_array = (mat4*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                0, 4 * sizeof(mat4), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);

            for (var i = 0; i < 4; i++) {
                mv_matrix_array[i] = proj_matrix *
                    glm.translate(0.0f, 0.0f, -2.0f) *
                    glm.rotate((float)currentTime * 45.0f * (float)(i + 1), 0.0f, 1.0f, 0.0f) *
                    glm.rotate((float)currentTime * 81.0f * (float)(i + 1), 1.0f, 0.0f, 0.0f);
            }

            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            gl.glDrawElements(GL.GL_TRIANGLES, 36, GL.GL_UNSIGNED_SHORT, 0);
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


        static GLushort[] vertex_indices =
        {
            0, 1, 2,
            2, 1, 3,
            2, 3, 4,
            4, 3, 5,
            4, 5, 6,
            6, 5, 7,
            6, 7, 0,
            0, 7, 1,
            6, 0, 2,
            2, 4, 6,
            7, 5, 3,
            7, 3, 1
        };

        static GLfloat[] vertex_positions =
        {
            -0.25f, -0.25f, -0.25f,
            -0.25f,  0.25f, -0.25f,
             0.25f, -0.25f, -0.25f,
             0.25f,  0.25f, -0.25f,
             0.25f, -0.25f,  0.25f,
             0.25f,  0.25f,  0.25f,
            -0.25f, -0.25f,  0.25f,
            -0.25f,  0.25f,  0.25f,
        };
    }
}