
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class basicfbo : _glSuperBible7code {
        ~basicfbo() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public basicfbo(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint program1;
        GLuint program2;
        GLuint vao;
        GLuint position_buffer;
        GLuint index_buffer;
        GLuint fbo;
        GLuint color_texture;
        GLuint depth_texture;
        GLint mv_location;
        GLint proj_location;
        GLint mv_location2;
        GLint proj_location2;
        mat4 proj_matrix;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/basicfbo.vert";
                var fsCodeFile = "media/shaders/basicfbo.1.frag";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.program1 = program.programId;
                gl.glUseProgram(this.program1);
                mv_location = gl.glGetUniformLocation(program1, "mv_matrix");
                proj_location = gl.glGetUniformLocation(program1, "proj_matrix");
            }
            {
                var vsCodeFile = "media/shaders/basicfbo.vert";
                var fsCodeFile = "media/shaders/basicfbo.2.frag";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.program2 = program.programId;
                gl.glUseProgram(this.program2);
                mv_location2 = gl.glGetUniformLocation(program2, "mv_matrix");
                proj_location2 = gl.glGetUniformLocation(program2, "proj_matrix");
            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);

                gl.glGenBuffers(1, id); position_buffer = id[0];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, position_buffer);
                fixed (float* p = vertex_data) {
                    gl.glBufferData(GL.GL_ARRAY_BUFFER,
                        sizeof(float) * vertex_data.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }
                gl.glVertexAttribPointer(0, 3, GL.GL_FLOAT, false, 5 * sizeof(GLfloat), 0);
                gl.glEnableVertexAttribArray(0);
                gl.glVertexAttribPointer(1, 2, GL.GL_FLOAT, false, 5 * sizeof(GLfloat), (3 * sizeof(GLfloat)));
                gl.glEnableVertexAttribArray(1);

                gl.glGenBuffers(1, id); index_buffer = id[0];
                gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, index_buffer);
                fixed (GLushort* p = vertex_indices) {
                    gl.glBufferData(GL.GL_ELEMENT_ARRAY_BUFFER,
                        sizeof(GLushort) * vertex_indices.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }

                gl.glEnable(GL.GL_CULL_FACE);

                gl.glEnable(GL.GL_DEPTH_TEST);
                gl.glDepthFunc(GL.GL_LEQUAL);

                fixed (GLenum* p = draw_buffers) {
                    gl.glDrawBuffers(1, p);
                }
            }
        }
        static GLenum[] draw_buffers = { GL.GL_COLOR_ATTACHMENT0 };

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        static GLfloat[] blue = { 0.0f, 0.0f, 0.3f, 1.0f };
        float time = 0;
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            var proj_matrix = this.proj_matrix;

            time += 0.03f;
            var position = glm.rotate(time * 10, new vec3(0, 1, 0)) * new vec4(5, 1, 4, 1);
            mat4 mv_matrix = glm.lookAt(new vec3(position) * 0.2f, new vec3(0, 0, 0), new vec3(0, 1, 0));
            //mv_matrix = glm.rotate(mv_matrix, time * 81.0f, 1.0f, 0.0f, 0.0f);
            //mv_matrix = glm.rotate(mv_matrix, time * 45.0f, 0.0f, 1.0f, 0.0f);
            //mv_matrix = glm.translate(mv_matrix,
            //    (float)Math.Sin(2.1f * time) * 0.5f,
            //    (float)Math.Cos(1.7f * time) * 0.5f,
            //    (float)Math.Sin(1.3f * time) * (float)Math.Cos(1.5f * time) * 2.0f);
            //mv_matrix = glm.translate(mv_matrix, 0.0f, 0.0f, -4.0f);

            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, fbo);
            {
                //gl.glViewport(0, 0, 512, 512);
                //var green = Utility.color.Green;
                //gl.glClearBufferfv(GL.GL_COLOR, 0, (float*)&green);
                //gl.glClearBufferfi(GL.GL_DEPTH_STENCIL, 0, 1.0f, 0);

                gl.glUseProgram(program1);

                gl.glUniformMatrix4fv(proj_location, 1, false, (float*)&proj_matrix);
                gl.glUniformMatrix4fv(mv_location, 1, false, (float*)&mv_matrix);
                gl.glDrawArrays(GL.GL_TRIANGLES, 0, 36);
            }
            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, 0);

            //fixed (float* p = blue) {
            //    gl.glClearBufferfv(GL.GL_COLOR, 0, p);
            //}

            //GLfloat one = 1.0f;
            //gl.glClearBufferfv(GL.GL_DEPTH, 0, &one);

            gl.glBindTexture(GL.GL_TEXTURE_2D, color_texture);

            gl.glUseProgram(program2);

            gl.glUniformMatrix4fv(proj_location2, 1, false, (float*)&proj_matrix);
            gl.glUniformMatrix4fv(mv_location2, 1, false, (float*)&mv_matrix);

            gl.glDrawArrays(GL.GL_TRIANGLES, 0, 36);

            gl.glBindTexture(GL.GL_TEXTURE_2D, 0);
        }

        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);

            this.proj_matrix = glm.perspective(50.0f / 180.0f * (float)Math.PI,
                      (float)width / (float)height,
                      0.1f, 1000.0f);

            var id = stackalloc GLuint[1];
            gl.glGenFramebuffers(1, id); fbo = id[0];
            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, fbo);

            gl.glGenTextures(1, id); color_texture = id[0];
            gl.glBindTexture(GL.GL_TEXTURE_2D, color_texture);
            gl.glTexStorage2D(GL.GL_TEXTURE_2D, 9, GL.GL_RGBA8, width, height);

            gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
            gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);

            gl.glGenTextures(1, id); depth_texture = id[0];
            gl.glBindTexture(GL.GL_TEXTURE_2D, depth_texture);
            gl.glTexStorage2D(GL.GL_TEXTURE_2D, 9, GL.GL_DEPTH_COMPONENT32F, width, height);

            gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT0, color_texture, 0);
            gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_DEPTH_ATTACHMENT, depth_texture, 0);

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

        static GLfloat[] vertex_data =
        {
			// Position                 Tex Coord
		   -0.25f, -0.25f,  0.25f,      0.0f, 1.0f,
           -0.25f, -0.25f, -0.25f,      0.0f, 0.0f,
            0.25f, -0.25f, -0.25f,      1.0f, 0.0f,

            0.25f, -0.25f, -0.25f,      1.0f, 0.0f,
            0.25f, -0.25f,  0.25f,      1.0f, 1.0f,
           -0.25f, -0.25f,  0.25f,      0.0f, 1.0f,

            0.25f, -0.25f, -0.25f,      0.0f, 0.0f,
            0.25f,  0.25f, -0.25f,      1.0f, 0.0f,
            0.25f, -0.25f,  0.25f,      0.0f, 1.0f,

            0.25f,  0.25f, -0.25f,      1.0f, 0.0f,
            0.25f,  0.25f,  0.25f,      1.0f, 1.0f,
            0.25f, -0.25f,  0.25f,      0.0f, 1.0f,

            0.25f,  0.25f, -0.25f,      1.0f, 0.0f,
           -0.25f,  0.25f, -0.25f,      0.0f, 0.0f,
            0.25f,  0.25f,  0.25f,      1.0f, 1.0f,

           -0.25f,  0.25f, -0.25f,      0.0f, 0.0f,
           -0.25f,  0.25f,  0.25f,      0.0f, 1.0f,
            0.25f,  0.25f,  0.25f,      1.0f, 1.0f,

           -0.25f,  0.25f, -0.25f,      1.0f, 0.0f,
           -0.25f, -0.25f, -0.25f,      0.0f, 0.0f,
           -0.25f,  0.25f,  0.25f,      1.0f, 1.0f,

           -0.25f, -0.25f, -0.25f,      0.0f, 0.0f,
           -0.25f, -0.25f,  0.25f,      0.0f, 1.0f,
           -0.25f,  0.25f,  0.25f,      1.0f, 1.0f,

           -0.25f,  0.25f, -0.25f,      0.0f, 1.0f,
            0.25f,  0.25f, -0.25f,      1.0f, 1.0f,
            0.25f, -0.25f, -0.25f,      1.0f, 0.0f,

            0.25f, -0.25f, -0.25f,      1.0f, 0.0f,
           -0.25f, -0.25f, -0.25f,      0.0f, 0.0f,
           -0.25f,  0.25f, -0.25f,      0.0f, 1.0f,

           -0.25f, -0.25f,  0.25f,      0.0f, 0.0f,
            0.25f, -0.25f,  0.25f,      1.0f, 0.0f,
            0.25f,  0.25f,  0.25f,      1.0f, 1.0f,

            0.25f,  0.25f,  0.25f,      1.0f, 1.0f,
           -0.25f,  0.25f,  0.25f,      0.0f, 1.0f,
           -0.25f, -0.25f,  0.25f,      0.0f, 0.0f,
        };
    }
}