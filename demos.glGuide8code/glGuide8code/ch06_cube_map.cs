
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch06_cube_map : _glGuide8code {
        ~ch06_cube_map() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
            gl.glUseProgram(0);
            gl.glDeleteProgram(skybox_prog);
            gl.glDeleteProgram(object_prog);
            var id = tex;
            gl.glDeleteTextures(1, &id);
            id = vao;
            gl.glDeleteVertexArrays(1, &id);
        }
        public ch06_cube_map(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        // Member variables
        float aspect;
        GLuint skybox_prog;
        GLuint object_prog;
        GLuint vao;

        GLuint cube_vbo;
        GLuint cube_element_buffer;

        GLuint tex;
        GLint skybox_rotate_loc;

        GLint object_mat_mvp_loc;
        GLint object_mat_mv_loc;

        VBObject vbObject = new VBObject();

        static GLfloat[] cube_vertices =
        {
        -1.0f, -1.0f, -1.0f,
        -1.0f, -1.0f,  1.0f,
        -1.0f,  1.0f, -1.0f,
        -1.0f,  1.0f,  1.0f,
         1.0f, -1.0f, -1.0f,
         1.0f, -1.0f,  1.0f,
         1.0f,  1.0f, -1.0f,
         1.0f,  1.0f,  1.0f
        };

        static GLushort[] cube_indices =
        {
        0, 1, 2, 3, 6, 7, 4, 5,         // First strip
		2, 6, 0, 4, 1, 5, 3, 7          // Second strip
	    };
        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "06/ch06_cube_map/skybox_shader.vs.glsl";
                var fsCodeFile = "06/ch06_cube_map/skybox_shader.fs.glsl";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.skybox_prog = program.programId;
            }
            {
                var vsCodeFile = "06/ch06_cube_map/object_shader.vs.glsl";
                var fsCodeFile = "06/ch06_cube_map/object_shader.fs.glsl";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.object_prog = program.programId;
            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenBuffers(1, id); cube_vbo = id[0];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, cube_vbo);
                fixed (float* p = cube_vertices) {
                    gl.glBufferData(GL.GL_ARRAY_BUFFER,
                        sizeof(float) * cube_vertices.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }

                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);

                gl.glVertexAttribPointer(0, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                gl.glEnableVertexAttribArray(0);

                gl.glGenBuffers(1, id); cube_element_buffer = id[0];
                gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, cube_element_buffer);
                fixed (GLushort* p = cube_indices) {
                    gl.glBufferData(GL.GL_ELEMENT_ARRAY_BUFFER,
                        sizeof(GLushort) * cube_indices.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }

                skybox_rotate_loc = gl.glGetUniformLocation(skybox_prog, "tc_rotate");
                object_mat_mvp_loc = gl.glGetUniformLocation(object_prog, "mat_mvp");
                object_mat_mv_loc = gl.glGetUniformLocation(object_prog, "mat_mv");

                var image = new vgl.vglImageData();
                //vgl.vglLoadImage(filename, ref image);
                vgl.vglLoadDDS("media/TantolundenCube.dds", ref image);

                gl.glGenTextures(1, id); this.tex = id[0];
                gl.glBindTexture(image.target, this.tex);
                vgl.vglLoadTexture(gl, ref image);

                var error = gl.glGetError();

                vgl.vglUnloadImage(ref image);

                //vbObject.LoadFromVBM("media/unit_torus.vbm", 0, 1, 2);
                vbObject.LoadFromVBM("media/armadillo_low.vbm", 0, 1, 2);
            }
        }

        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        static float q;
        public override void display(CSharpGL.GL gl) {
            //gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            //float t = float((GetTickCount() - start_time)) / float(0x3FFF);
            float t = q; q += 0.01f;

            //gl.glClearColor(0.0f, 0.25f, 0.3f, 1.0f);
            gl.glClearDepth(1.0f);
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glDepthFunc(GL.GL_LEQUAL);
            gl.glDisable(GL.GL_CULL_FACE);
            gl.glUseProgram(skybox_prog);

            gl.glEnable(GL.GL_TEXTURE_CUBE_MAP_SEAMLESS);

            {
                // var tc_matrix = glm.rotate(80.0f * 3.0f * t, Y);// * glm.rotate(22.0f, Z);
                var tc_matrix = glm.perspective(35.0f / 180.0f * (float)Math.PI, 1.0f / aspect, 0.1f, 1000.0f);
                gl.glUniformMatrix4fv(skybox_rotate_loc, 1, false, (float*)&tc_matrix);
            }

            gl.glBindVertexArray(vao);
            gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, cube_element_buffer);

            //gl.glPolygonMode(GL.GL_FRONT_AND_BACK, GL.GL_LINE);
            gl.glDrawElements(GL.GL_TRIANGLE_STRIP, 8, GL.GL_UNSIGNED_SHORT, IntPtr.Zero);
            gl.glDrawElements(GL.GL_TRIANGLE_STRIP, 8, GL.GL_UNSIGNED_SHORT, (IntPtr)(8 * sizeof(GLushort)));

            gl.glUseProgram(object_prog);

            {
                var position = glm.rotate(80.0f * 3.0f * t, Y) * glm.rotate(70.0f * 3.0f * t, Z)
                    * (new vec4(50, 40, 30, 1));
                var tc_matrix = glm.lookAt(new vec3(position) * 4f, new vec3(0, 0, 0), new vec3(0, 1, 0));
                //var tc_matrix =
                //    glm.translate(mat4.identity(), 0.0f, 0.0f, -4.0f)
                //  * glm.rotate(80.0f * 3.0f * t, Y) * glm.rotate(70.0f * 3.0f * t, Z);
                gl.glUniformMatrix4fv(object_mat_mv_loc, 1, false, (float*)&tc_matrix);
                tc_matrix =
                    glm.perspective(35.0f * (float)Math.PI / 180.0f, 1.0f / aspect, 0.1f, 1000.0f) * tc_matrix;
                gl.glUniformMatrix4fv(object_mat_mvp_loc, 1, false, (float*)&tc_matrix);
            }

            gl.glClear(GL.GL_DEPTH_BUFFER_BIT);

            vbObject.Render();
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