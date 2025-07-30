
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class blendmatrix : _glSuperBible7code {
        ~blendmatrix() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public blendmatrix(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint program;
        GLuint vao;
        GLuint position_buffer;
        GLuint index_buffer;
        GLint mv_location;
        GLint proj_location;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/blendmatrix.vert";
                var fsCodeFile = "media/shaders/blendmatrix.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program = programObj.programId;
                gl.glUseProgram(this.program);

                mv_location = gl.glGetUniformLocation(this.program, "mv_matrix");
                proj_location = gl.glGetUniformLocation(this.program, "proj_matrix");
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
                gl.glVertexAttribPointer(0, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                gl.glEnableVertexAttribArray(0);

                gl.glGenBuffers(1, id); index_buffer = id[0];
                gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, index_buffer);
                fixed (GLushort* p = vertex_indices) {
                    gl.glBufferData(GL.GL_ELEMENT_ARRAY_BUFFER,
                        sizeof(GLushort) * vertex_indices.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }

                gl.glEnable(GL.GL_CULL_FACE);
                //gl.glFrontFace(GL.GL_CW);

                //gl.glEnable(GL.GL_DEPTH_TEST);
                //gl.glDepthFunc(GL.GL_LEQUAL);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float time = 0;
        //static int num_blend_funcs = blend_func.Length;
        static float x_scale = 20.0f / (float)(num_blend_funcs);
        static float y_scale = 16.0f / (float)(num_blend_funcs);
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            time += 0.01f;

            fixed (float* p = orange) {
                gl.glClearBufferfv(GL.GL_COLOR, 0, p);
            }
            var _one = one;
            gl.glClearBufferfv(GL.GL_DEPTH, 0, &_one);

            gl.glUseProgram(program);

            var proj_matrix = this.proj_matrix;
            gl.glUniformMatrix4fv(proj_location, 1, false, (float*)&proj_matrix);

            gl.glEnable(GL.GL_BLEND);
            gl.glBlendColor(0.2f, 0.5f, 0.7f, 0.5f);
            for (var j = 0; j < num_blend_funcs; j++) {
                for (var i = 0; i < num_blend_funcs; i++) {
                    //mv_matrix = glm.lookAt(new vec3(5, 1, 4), new vec3(0, 0, 0), new vec3(0, 1, 0));
                    //mv_matrix = glm.rotate(mv_matrix, time * -21.0f, 1.0f, 0.0f, 0.0f);
                    //mv_matrix = glm.rotate(mv_matrix, time * -45.0f, 0.0f, 1.0f, 0.0f);
                    var mv_matrix = glm.translate(9.5f - x_scale * i, 7.5f - y_scale * j, -20.0f);
                    gl.glUniformMatrix4fv(mv_location, 1, false, (float*)&mv_matrix);
                    gl.glBlendFunc(blend_func[i], blend_func[j]);
                    gl.glDrawElements(GL.GL_TRIANGLES, 36, GL.GL_UNSIGNED_SHORT, 0);
                }
            }
        }

        mat4 proj_matrix;
        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);

            //aspect = (float)height / (float)width;
            this.proj_matrix = glm.perspective(50.0f * (float)Math.PI / 180.0f,
                    (float)width / (float)height, 0.1f, 1000.0f);
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

        static GLfloat[] orange = { 0.6f, 0.4f, 0.1f, 1.0f };
        static GLfloat one = 1.0f;

        const int num_blend_funcs = 19;
        static GLenum[] blend_func = new uint[num_blend_funcs]
        {
            GL.GL_ZERO,
            GL.GL_ONE,
            GL.GL_SRC_COLOR,
            GL.GL_ONE_MINUS_SRC_COLOR,
            GL.GL_DST_COLOR,
            GL.GL_ONE_MINUS_DST_COLOR,
            GL.GL_SRC_ALPHA,
            GL.GL_ONE_MINUS_SRC_ALPHA,
            GL.GL_DST_ALPHA,
            GL.GL_ONE_MINUS_DST_ALPHA,
            GL.GL_CONSTANT_COLOR,
            GL.GL_ONE_MINUS_CONSTANT_COLOR,
            GL.GL_CONSTANT_ALPHA,
            GL.GL_ONE_MINUS_CONSTANT_ALPHA,
            GL.GL_SRC_ALPHA_SATURATE,
            0x88F9/*GL_SRC1_COLOR*/,
            0x88FA/*GL_ONE_MINUS_SRC1_COLOR*/,
            0x8589/*GL_SRC1_ALPHA*/,
            0x88FB/*GL_ONE_MINUS_SRC1_ALPHA*/
        };
    }
}