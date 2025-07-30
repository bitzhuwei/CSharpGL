
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch08_lightmodels : _glGuide8code {
        ~ch08_lightmodels() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public ch08_lightmodels(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        float aspect;
        // Texture for compute shader to write into
        GLuint output_image;

        // Program, vao and vbo to render a full screen quad
        GLuint render_prog;

        // Uniform locations
        GLint mv_mat_loc;
        GLint prj_mat_loc;
        GLint col_amb_loc;
        GLint col_diff_loc;
        GLint col_spec_loc;

        // Object to render
        VBObject vbObject = new VBObject();

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "08/ch08_lightmodels/render.vs.glsl";
                var fsCodeFile = "08/ch08_lightmodels/render.fs.glsl";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.render_prog = program.programId;
                gl.glUseProgram(this.render_prog);

                mv_mat_loc = gl.glGetUniformLocation(render_prog, "model_matrix");
                prj_mat_loc = gl.glGetUniformLocation(render_prog, "proj_matrix");
                col_amb_loc = gl.glGetUniformLocation(render_prog, "color_ambient");
                col_diff_loc = gl.glGetUniformLocation(render_prog, "color_diffuse");
                col_spec_loc = gl.glGetUniformLocation(render_prog, "color_specular");
            }

            //vbObject.LoadFromVBM("media/unit_torus.vbm", 0, 1, 2);
            vbObject.LoadFromVBM("media/armadillo_low.vbm", 0, 1, 2);

        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        public override void display(CSharpGL.GL gl) {

            float time = q; q += 1f; // float(GetTickCount() & 0xFFFF) / float(0xFFFF);

            //var mv_matrix = mat4.identity();
            //mv_matrix = glm.rotate(mv_matrix, time * 3.14159f, 1.0f, 0.0f, 0.0f);
            //mv_matrix = glm.rotate(mv_matrix, time * 3.14159f, 0.0f, 0.0f, 1.0f);
            //mv_matrix = glm.translate(mv_matrix, 0.0f, 0.0f, -4.0f);
            var position = (glm.rotate(time, new vec3(0, 1, 0)) * new vec4(100, 0, 30, 1));
            var mv_matrix = glm.lookAt(new vec3(position) * 3, new vec3(0, 0, 0), new vec3(0, 1, 0));
            var prj_matrix = glm.perspective(60.0f / 180.0f * (float)Math.PI, 1 / aspect, 0.1f, 1000.0f);

            gl.glUseProgram(render_prog);

            gl.glUniformMatrix4fv(mv_mat_loc, 1, false, (float*)&mv_matrix);
            gl.glUniformMatrix4fv(prj_mat_loc, 1, false, (float*)&prj_matrix);

            // Clear, select the rendering program and draw a full screen quad
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glCullFace(GL.GL_BACK);
            gl.glEnable(GL.GL_CULL_FACE);
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glDepthFunc(GL.GL_LEQUAL);

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