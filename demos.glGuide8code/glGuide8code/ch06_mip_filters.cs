
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch06_mip_filters : _glGuide8code {
        ~ch06_mip_filters() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public ch06_mip_filters(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        // Member variables
        float aspect;
        GLuint mipmap_prog;
        GLuint vao;

        GLuint cube_vbo;
        GLuint cube_element_buffer;

        GLuint tex;
        GLint skybox_rotate_loc;

        GLint object_mat_mvp_loc;
        GLint object_mat_mv_loc;

        VBObject vbObject = new VBObject();


        static GLfloat[] plane_vertices =
        {
        -20.0f, 0.0f, -50.0f,
        -20.0f, 0.0f,  50.0f,
         20.0f, 0.0f, -50.0f,
         20.0f, 0.0f,  50.0f
        };

        static GLfloat[] plane_texcoords =
        {
        0.0f, 0.0f,
        0.0f, 1.0f,
        1.0f, 0.0f,
        1.0f, 1.0f
        };

        static GLushort[] plane_indices =
        {
        0, 1, 2, 3
        };

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "06/ch06_mip_filters/skybox_shader.vs.glsl";
                var fsCodeFile = "06/ch06_mip_filters/skybox_shader.fs.glsl";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.mipmap_prog = program.programId;
                gl.glUseProgram(this.mipmap_prog);
                skybox_rotate_loc = gl.glGetUniformLocation(mipmap_prog, "tc_rotate");
            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenBuffers(1, id); cube_vbo = id[0];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, cube_vbo);
                gl.glBufferData(GL.GL_ARRAY_BUFFER,
                    sizeof(float) * (plane_vertices.Length + plane_texcoords.Length), IntPtr.Zero, GL.GL_STATIC_DRAW);
                fixed (GLfloat* p = plane_vertices) {
                    gl.glBufferSubData(GL.GL_ARRAY_BUFFER,
                        0, sizeof(float) * plane_vertices.Length, (IntPtr)p);
                }
                fixed (GLfloat* p = plane_texcoords) {
                    gl.glBufferSubData(GL.GL_ARRAY_BUFFER,
                        sizeof(float) * plane_vertices.Length, sizeof(float) * plane_texcoords.Length, (IntPtr)p);
                }

                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);

                gl.glVertexAttribPointer(0, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                gl.glEnableVertexAttribArray(0);
                gl.glVertexAttribPointer(1, 2, GL.GL_FLOAT, false, 0, (IntPtr)(sizeof(float) * plane_vertices.Length));
                gl.glEnableVertexAttribArray(1);

                gl.glGenBuffers(1, id); cube_element_buffer = id[0];
                gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, cube_element_buffer);
                fixed (GLushort* p = plane_indices) {
                    gl.glBufferData(GL.GL_ELEMENT_ARRAY_BUFFER,
                        sizeof(GLushort) * plane_indices.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }

            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenTextures(1, id); tex = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D, tex);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 7, GL.GL_RGBA8, 64, 64);

                var data = new uint[64 * 64];
                //var colors = new uint[] { 0xFF0000FF, 0xFF00FF00, 0xFFFF0000, 0xFF00FFFF, 0xFFFF00FF, 0xFFFFFF00, 0xFFFFFFFF };
                for (var i = 0; i < 7; i++) {
                    var n = 0;
                    for (uint j = 0; j < (64 >> i); j++) {
                        for (uint k = 0; k < (64 >> i); k++) {
                            data[n] = (k ^ (64 - j)) * 0x04040404;
                            n++;
                        }
                    }
                    fixed (uint* p = data) {
                        gl.glTexSubImage2D(GL.GL_TEXTURE_2D, i, 0, 0, 64 >> i, 64 >> i,
                            GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, (IntPtr)p);
                    }
                }

                gl.glTexParameterf(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_LOD_BIAS, 4.5f);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        public override void display(CSharpGL.GL gl) {

            //float t = float((GetTickCount() - start_time)) / float(0x3FFF);
            float t = q; q += 0.01f;

            gl.glClearDepth(1.0f);
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glDepthFunc(GL.GL_ALWAYS);
            gl.glDisable(GL.GL_CULL_FACE);
            gl.glUseProgram(mipmap_prog);

            //var tc_matrix = glm.rotate(t * 10, X);
            //tc_matrix = glm.translate(tc_matrix, new vec3(0.0f, 0.0f, -60.0f));
            //tc_matrix = glm.perspective(35.0f, 1.0f / aspect, 0.1f, 700.0f) * tc_matrix;

            //var tc_matrix = glm.rotate(mat4.identity(), 80.0f * 3.0f * 0.03f, X);
            //tc_matrix = glm.translate(mat4.identity(), 0.0f, 0.0f, -60.0f) * tc_matrix;
            //tc_matrix = glm.perspective(35.0f / 180.0f * (float)Math.PI, 1.0f / aspect, 0.1f, 700.0f) * tc_matrix;
            var tc_matrix = glm.perspective(35.0f / 180.0f * (float)Math.PI, 1.0f / aspect, 0.1f, 700.0f)
                * glm.translate(0.0f, 0.0f, -60.0f)
                * glm.rotate(80.0f * 3.0f * 0.03f, X);

            gl.glUniformMatrix4fv(skybox_rotate_loc, 1, false, (float*)&tc_matrix);
            gl.glBindVertexArray(vao);
            gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, cube_element_buffer);

            t = t % 2.0f;// fmodf(t, 1.0f);

            if (false) { }
            else if (t < 0.25f) {
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST_MIPMAP_NEAREST);
            }
            else if (t < 0.5f) {
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR_MIPMAP_NEAREST);
            }
            else if (t < 0.75f) {
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST_MIPMAP_LINEAR);
            }
            else {
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR_MIPMAP_LINEAR);
            }

            gl.glDrawElements(GL.GL_TRIANGLE_STRIP, 8, GL.GL_UNSIGNED_SHORT, IntPtr.Zero);
            gl.glDrawElements(GL.GL_TRIANGLE_STRIP, 8, GL.GL_UNSIGNED_SHORT, (IntPtr)(8 * sizeof(GLushort)));
        }

        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);

            aspect = (float)height / (float)width;
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