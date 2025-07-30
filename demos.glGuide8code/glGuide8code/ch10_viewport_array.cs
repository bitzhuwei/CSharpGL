
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch10_viewport_array : _glGuide8code {
        ~ch10_viewport_array() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public ch10_viewport_array(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        // Member variables
        float aspect;
        GLuint prog;
        GLuint vao;
        GLuint vbo;
        VBObject vbObject = new VBObject();

        GLint model_matrix_pos;
        GLint projection_matrix_pos;


        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "10/ch10_viewport_array/render.vert";
                var gsCodeFile = "10/ch10_viewport_array/render.geom";
                var fsCodeFile = "10/ch10_viewport_array/render.frag";
                var program = Utility.LoadShaders(vsCodeFile, gsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.prog = program.programId;
                gl.glUseProgram(this.prog);

                model_matrix_pos = gl.glGetUniformLocation(prog, "model_matrix");
                projection_matrix_pos = gl.glGetUniformLocation(prog, "projection_matrix");
            }

            //vbObject.LoadFromVBM("media/ninja.vbm", 0, 1, 2);
            vbObject.LoadFromVBM("media/armadillo_low.vbm", 0, 1, 2);
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        public override void display(CSharpGL.GL gl) {
            gl.glClearDepth(1.0f);
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            //float t = q; q += 0.01f;
            gl.glUseProgram(prog);

            var model = stackalloc mat4[4];

            for (int i = 0; i < 4; i++) {
                var m = glm.rotate((float)i, Y);
                //m = glm.rotate(m, t * (5 - i), Z);
                //m = glm.translate(m, 0.0f, -80.0f, 0.0f);
                //m = glm.rotate(m, t * (5 - i), Z);
                //m = glm.rotate(m, t * (i + 2), Y);
                //m = glm.rotate(m, t * (i + 1), X);
                //m = glm.translate(m, 0.0f, 0.0f, 100.0f * (float)Math.Sin(6.28318531f * t + i) - 230.0f);
                model[i] = m;
            }

            //mat4 projection = glm.frustum(-1.0f, 1.0f, aspect, -aspect, 1.0f, 5000.0f);
            //var position = (glm.rotate(mat4.identity(), t, 0, 1, 0) * new vec4(5, 1, 3, 1));
            mat4 projection = glm.perspective(60.0f / 180.0f * (float)Math.PI, 1.0f / aspect, 0.1f, 1000f)
                * glm.lookAt(new vec3(5, 1, 4) * 50.0f, new vec3(0, 0, 0), new vec3(0, 1, 0));
            //mat4 projection = glm.ortho(-100, 100, -100, 100)
            //* glm.lookAt(new vec3(position) * 50.0f, new vec3(0, 0, 0), new vec3(0, 1, 0));

            gl.glUniformMatrix4fv(model_matrix_pos, 4, false, (float*)&model);
            gl.glUniformMatrix4fv(projection_matrix_pos, 1, false, (float*)&projection);

            gl.glEnable(GL.GL_CULL_FACE);
            gl.glCullFace(GL.GL_FRONT);
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glDepthFunc(GL.GL_LEQUAL);
            vbObject.Render();

        }

        public override void reshape(CSharpGL.GL gl, int width, int height) {
            //var value = stackalloc int[1];
            //gl.glGetIntegerv(0x825B/*GL_MAX_VIEWPORTS*/, value);

            //gl.glViewport(0, 0, width, height);

            float wot = width * 0.5f;
            float hot = height * 0.5f;

            gl.glViewportIndexedf(0, 0.0f, 0.0f, wot, hot);
            gl.glViewportIndexedf(1, wot, 0.0f, wot, hot);
            gl.glViewportIndexedf(2, 0.0f, hot, wot, hot);
            gl.glViewportIndexedf(3, wot, hot, wot, hot);

            aspect = hot / wot;
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