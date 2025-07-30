
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class instancedattribs : _glSuperBible7code {
        ~instancedattribs() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public instancedattribs(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint square_buffer;
        GLuint square_vao;

        GLuint square_program;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/instancedattribs.square.vert";
                var fsCodeFile = "media/shaders/instancedattribs.square.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.square_program = programObj.programId;
                gl.glUseProgram(this.square_program);

            }
            {


                GLint offset = 0;

                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); square_vao = id[0];
                gl.glGenBuffers(1, id); square_buffer = id[0];
                gl.glBindVertexArray(square_vao);
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, square_buffer);
                gl.glBufferData(GL.GL_ARRAY_BUFFER,
                    sizeof(float) * (square_vertices.Length + instance_colors.Length + instance_positions.Length),
                    0, GL.GL_STATIC_DRAW);
                fixed (GLfloat* p = square_vertices) {
                    gl.glBufferSubData(GL.GL_ARRAY_BUFFER, offset, sizeof(float) * square_vertices.Length, (IntPtr)p);
                }
                offset += sizeof(float) * square_vertices.Length;
                fixed (GLfloat* p = instance_colors) {
                    gl.glBufferSubData(GL.GL_ARRAY_BUFFER, offset, sizeof(float) * instance_colors.Length, (IntPtr)p);
                }
                offset += sizeof(float) * instance_colors.Length;
                fixed (GLfloat* p = instance_positions) {
                    gl.glBufferSubData(GL.GL_ARRAY_BUFFER, offset, sizeof(float) * instance_positions.Length, (IntPtr)p);
                }
                offset += sizeof(float) * instance_positions.Length;

                gl.glVertexAttribPointer(0, 4, GL.GL_FLOAT, false, 0, 0);
                gl.glVertexAttribPointer(1, 4, GL.GL_FLOAT, false, 0, sizeof(float) * square_vertices.Length);
                gl.glVertexAttribPointer(2, 4, GL.GL_FLOAT, false, 0, sizeof(float) * (square_vertices.Length + instance_colors.Length));

                gl.glEnableVertexAttribArray(0);
                gl.glEnableVertexAttribArray(1);
                gl.glEnableVertexAttribArray(2);

                gl.glVertexAttribDivisor(1, 1);
                gl.glVertexAttribDivisor(2, 1);

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
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            t += 0.01f;

            var proj_matrix = this.proj_matrix;

            gl.glUseProgram(square_program);
            gl.glBindVertexArray(square_vao);
            gl.glDrawArraysInstanced(GL.GL_TRIANGLE_FAN, 0, 4, 4);
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

        static GLfloat[] square_vertices =
               {
            -1.0f, -1.0f, 0.0f, 1.0f,
             1.0f, -1.0f, 0.0f, 1.0f,
             1.0f,  1.0f, 0.0f, 1.0f,
            -1.0f,  1.0f, 0.0f, 1.0f
        };

        static GLfloat[] instance_colors =
        {
            1.0f, 0.0f, 0.0f, 1.0f,
            0.0f, 1.0f, 0.0f, 1.0f,
            0.0f, 0.0f, 1.0f, 1.0f,
            1.0f, 1.0f, 0.0f, 1.0f
        };

        static GLfloat[] instance_positions =
        {
            -2.0f, -2.0f, 0.0f, 0.0f,
             2.0f, -2.0f, 0.0f, 0.0f,
             2.0f,  2.0f, 0.0f, 0.0f,
            -2.0f,  2.0f, 0.0f, 0.0f
        };
    }
}