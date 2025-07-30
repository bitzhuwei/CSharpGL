
using CSharpGL;
using demos.glSuperBible7code;
using SixLabors.ImageSharp.Memory;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class spinnycube : _glSuperBible7code {
        ~spinnycube() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public spinnycube(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint program;
        GLuint vao;
        GLuint buffer;
        GLint mv_location;
        GLint proj_location;

        float aspect;
        mat4 proj_matrix;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/spinnycube.vert";
                var fsCodeFile = "media/shaders/spinnycube.frag";
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

                gl.glGenBuffers(1, &id); buffer = id;
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, buffer);
                fixed (float* p = vertex_positions) {
                    gl.glBufferData(GL.GL_ARRAY_BUFFER,
                        sizeof(float) * vertex_positions.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }
                gl.glVertexAttribPointer(0, 3, GL.GL_FLOAT, false, 0, 0);
                gl.glEnableVertexAttribArray(0);

                gl.glEnable(GL.GL_CULL_FACE);
                gl.glFrontFace(GL.GL_CW);

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
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            currentTime += 0.01f;

            var proj_matrix = this.proj_matrix;

            gl.glUseProgram(program);

            gl.glUniformMatrix4fv(proj_location, 1, false, (float*)&proj_matrix);

            if (MANY_CUBES) {
                int i;
                for (i = 0; i < 24; i++) {
                    float f = (float)i + (float)currentTime * 0.3f;
                    mat4 mv_matrix = glm.translate(0.0f, 0.0f, -6.0f) *
                        glm.rotate((float)currentTime * 45.0f, 0.0f, 1.0f, 0.0f) *
                        glm.rotate((float)currentTime * 21.0f, 1.0f, 0.0f, 0.0f) *
                        glm.translate((float)Math.Sin(2.1f * f) * 2.0f,
                            (float)Math.Cos(1.7f * f) * 2.0f,
                            (float)Math.Sin(1.3f * f) * (float)Math.Cos(1.5f * f) * 2.0f);
                    gl.glUniformMatrix4fv(mv_location, 1, false, (float*)&mv_matrix);
                    gl.glDrawArrays(GL.GL_TRIANGLES, 0, 36);
                }
            }
            else {
                float f = (float)currentTime * 0.3f;
                mat4 mv_matrix = glm.translate(0.0f, 0.0f, -4.0f) *
                    glm.translate((float)Math.Sin(2.1f * f) * 0.5f,
                        (float)Math.Cos(1.7f * f) * 0.5f,
                        (float)Math.Sin(1.3f * f) * (float)Math.Cos(1.5f * f) * 2.0f) *
                    glm.rotate((float)currentTime * 45.0f, 0.0f, 1.0f, 0.0f) *
                    glm.rotate((float)currentTime * 81.0f, 1.0f, 0.0f, 0.0f);
                gl.glUniformMatrix4fv(mv_location, 1, false, (float*)&mv_matrix);
                gl.glDrawArrays(GL.GL_TRIANGLES, 0, 36);
            }
        }

        int width, height;
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
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.M];
        public override MouseButtons[] ValidButtons => [];


        static GLfloat[] vertex_positions = {
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