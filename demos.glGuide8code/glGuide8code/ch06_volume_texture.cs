
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static demos.glGuide8code.vgl;

namespace demos.glGuide8code {

    public unsafe class ch06_volume_texture : _glGuide8code {
        ~ch06_volume_texture() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public ch06_volume_texture(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        // Member variables
        float aspect;
        GLuint base_prog;
        GLuint vao;

        GLuint quad_vbo;

        GLuint tex;
        GLint tc_rotate_loc;

        static GLfloat[] quad_data =
        {
         1.0f, -1.0f,
        -1.0f, -1.0f,
        -1.0f, 1.0f,
         1.0f, 1.0f,

         0.0f, 0.0f,
         1.0f, 0.0f,
         1.0f, 1.0f,
         0.0f, 1.0f
        };

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "06/ch06_volume_texture/quad_shader.vs.glsl";
                var fsCodeFile = "06/ch06_volume_texture/quad_shader.fs.glsl";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.base_prog = program.programId;
                gl.glUseProgram(this.base_prog);
                tc_rotate_loc = gl.glGetUniformLocation(base_prog, "tc_rotate");

            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenBuffers(1, id); quad_vbo = id[0];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, quad_vbo);
                fixed (float* p = quad_data) {
                    gl.glBufferData(GL.GL_ARRAY_BUFFER,
                        sizeof(float) * quad_data.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }

                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);

                gl.glVertexAttribPointer(0, 2, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                gl.glVertexAttribPointer(1, 2, GL.GL_FLOAT, false, 0, (IntPtr)(8 * sizeof(float)));

                gl.glEnableVertexAttribArray(0);
                gl.glEnableVertexAttribArray(1);

            }
            {
                var image = new vgl.vglImageData();
                vgl.vglLoadDDS("media/cloud.dds", ref image);
                var id = stackalloc GLuint[1];
                gl.glGenTextures(1, id); this.tex = id[0];
                gl.glBindTexture(image.target, this.tex);
                vgl.vglLoadTexture(gl, ref image); var error = gl.glGetError();
                gl.glTexParameteri(image.target, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
                vgl.vglUnloadImage(ref image);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            var tc_matrix = mat4.identity();

            gl.glClearDepth(1.0f);
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            gl.glDisable(GL.GL_CULL_FACE);
            gl.glUseProgram(base_prog);

            var t = q; q += 0.01f;
            tc_matrix = glm.rotate(t * 93.0f, Z);
            tc_matrix = glm.rotate(t * 137.0f, Y) * tc_matrix;
            tc_matrix = glm.rotate(t * 170.0f, X) * tc_matrix;

            gl.glUniformMatrix4fv(tc_rotate_loc, 1, false, (float*)&tc_matrix);
            gl.glBindVertexArray(vao);
            gl.glDrawArrays(GL.GL_TRIANGLE_FAN, 0, 4);
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