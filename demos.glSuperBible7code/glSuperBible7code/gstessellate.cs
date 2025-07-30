
using CSharpGL;
using demos.glSuperBible7code;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class gstessellate : _glSuperBible7code {
        ~gstessellate() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public gstessellate(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint program;
        GLint mv_location;
        GLint mvp_location;
        GLint stretch_location;
        GLuint vao;
        GLuint buffer;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/gstessellate.vert";
                var gsCodeFile = "media/shaders/gstessellate.geom";
                var fsCodeFile = "media/shaders/gstessellate.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, gsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program = programObj.programId;
                gl.glUseProgram(this.program);

                mv_location = gl.glGetUniformLocation(program, "mvMatrix");
                mvp_location = gl.glGetUniformLocation(program, "mvpMatrix");
                stretch_location = gl.glGetUniformLocation(program, "stretch");

            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);

                gl.glGenBuffers(1, id); buffer = id[0];
                gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, buffer);
                gl.glBufferData(GL.GL_ELEMENT_ARRAY_BUFFER,
                    sizeof(float) * tetrahedron_verts.Length
                    + sizeof(GLushort) * tetrahedron_indices.Length, 0, GL.GL_STATIC_DRAW);
                fixed (GLushort* p = tetrahedron_indices) {
                    gl.glBufferSubData(GL.GL_ELEMENT_ARRAY_BUFFER,
                        0, sizeof(GLushort) * tetrahedron_indices.Length, (IntPtr)p);
                }
                fixed (GLfloat* p = tetrahedron_verts) {
                    gl.glBufferSubData(GL.GL_ELEMENT_ARRAY_BUFFER,
                        sizeof(GLushort) * tetrahedron_indices.Length,
                        sizeof(float) * tetrahedron_verts.Length, (IntPtr)p);
                }

                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, buffer);
                gl.glVertexAttribPointer(0, 3, GL.GL_FLOAT, false, 0, sizeof(GLushort) * tetrahedron_indices.Length);
                gl.glEnableVertexAttribArray(0);

                gl.glEnable(GL.GL_CULL_FACE);
                // glDisable(GL.GL_CULL_FACE);

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

            mat4 mv_matrix = glm.translate(0.0f, 0.0f, -8.0f) *
                glm.rotate((float)currentTime * 71.0f, 0.0f, 1.0f, 0.0f) *
                glm.rotate((float)currentTime * 10.0f, 1.0f, 0.0f, 0.0f);
            mat4 mvp = proj_matrix * mv_matrix;
            gl.glUniformMatrix4fv(mvp_location, 1, false, (float*)&mvp);

            gl.glUniformMatrix4fv(mv_location, 1, false, (float*)&mv_matrix);

            gl.glUniform1f(stretch_location, (float)Math.Sin(currentTime * 4.0f) * 0.75f + 1.0f);

            gl.glBindVertexArray(vao);
            gl.glDrawElements(GL.GL_TRIANGLES, 12, GL.GL_UNSIGNED_SHORT, 0);
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


        static GLfloat[] tetrahedron_verts =
        {
             0.000f,  0.000f,  1.000f,
             0.943f,  0.000f, -0.333f,
            -0.471f,  0.816f, -0.333f,
            -0.471f, -0.816f, -0.333f
        };

        static GLushort[] tetrahedron_indices =
        {
            0, 1, 2,
            0, 2, 3,
            0, 3, 1,
            3, 2, 1
        };
    }
}