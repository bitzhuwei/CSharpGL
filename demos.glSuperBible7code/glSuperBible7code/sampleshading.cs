
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class sampleshading : _glSuperBible7code {
        ~sampleshading() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public sampleshading(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint program;
        GLuint vao;
        GLuint position_buffer;
        GLuint index_buffer;
        GLint mv_location;
        GLint proj_location;
        bool sample_shading;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/sampleshading.vert";
                var fsCodeFile = "media/shaders/sampleshading.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program = programObj.programId;
                gl.glUseProgram(this.program);

                mv_location = gl.glGetUniformLocation(program, "mv_matrix");
                proj_location = gl.glGetUniformLocation(program, "proj_matrix");

            }
            {
                GLuint id;
                gl.glGenVertexArrays(1, &id); vao = id;
                gl.glBindVertexArray(vao);

                gl.glGenBuffers(1, &id); position_buffer = id;
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, position_buffer);
                fixed (GLfloat* p = vertex_positions) {
                    gl.glBufferData(GL.GL_ARRAY_BUFFER,
                        sizeof(float) * vertex_positions.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }
                gl.glVertexAttribPointer(0, 3, GL.GL_FLOAT, false, 0, 0);
                gl.glEnableVertexAttribArray(0);

                gl.glGenBuffers(1, &id); index_buffer = id;
                gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, index_buffer);
                fixed (GLushort* p = vertex_indices) {
                    gl.glBufferData(GL.GL_ELEMENT_ARRAY_BUFFER,
                        sizeof(GLushort) * vertex_indices.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }
                gl.glEnable(GL.GL_CULL_FACE);
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


            gl.glUseProgram(program);

            gl.glUniformMatrix4fv(proj_location, 1, false, (float*)&proj_matrix);

            // glPolygonMode(GL.GL_FRONT_AND_BACK, GL.GL_LINE);

            if (sample_shading) {
                gl.glEnable(0x8C36/*GL_SAMPLE_SHADING*/);
                gl.glMinSampleShading(1.0f);
            }
            else {
                gl.glDisable(0x8C36/*GL_SAMPLE_SHADING*/);
            }

            if (MANY_CUBES) {
                for (var i = 0; i < 24; i++) {
                    float f = (float)i + (float)currentTime * 0.3f;
                    mat4 mv_matrix = glm.translate(0.0f, 0.0f, -20.0f) *
                        glm.rotate((float)currentTime * 45.0f, 0.0f, 1.0f, 0.0f) *
                        glm.rotate((float)currentTime * 21.0f, 1.0f, 0.0f, 0.0f) *
                        glm.translate((float)Math.Sin(2.1f * f) * 2.0f,
                            (float)Math.Cos(1.7f * f) * 2.0f,
                            (float)Math.Sin(1.3f * f) * (float)Math.Cos(1.5f * f) * 2.0f);
                    gl.glUniformMatrix4fv(mv_location, 1, false, (float*)&mv_matrix);
                    gl.glDrawElements(GL.GL_TRIANGLES, 36, GL.GL_UNSIGNED_SHORT, 0);
                }
            }
            else {
                float f = (float)currentTime * 0.3f;
                // currentTime = 3.15;
                mat4 mv_matrix = glm.translate(0.0f, 0.0f, -2.0f) *
                    /*glm.translate((float)Math.Sin(2.1f * f) * 0.5f,
                                        (float)Math.Cos(1.7f * f) * 0.5f,
                                        (float)Math.Sin(1.3f * f) * (float)Math.Cos(1.5f * f) * 2.0f) **/
                    glm.rotate((float)currentTime * 45.0f, 0.0f, 1.0f, 0.0f) *
                    glm.rotate((float)currentTime * 81.0f, 1.0f, 0.0f, 0.0f);
                gl.glUniformMatrix4fv(mv_location, 1, false, (float*)&mv_matrix);
                gl.glDrawElements(GL.GL_TRIANGLES, 36, GL.GL_UNSIGNED_SHORT, 0);
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

        bool MANY_CUBES = true;
        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.M:
            MANY_CUBES = !MANY_CUBES;
            break;
            case Keys.S:
            sample_shading = !sample_shading;
            break;
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