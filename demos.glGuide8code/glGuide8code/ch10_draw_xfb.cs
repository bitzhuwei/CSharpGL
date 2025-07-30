
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch10_draw_xfb : _glGuide8code {
        ~ch10_draw_xfb() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public ch10_draw_xfb(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        // Member variables
        float aspect;
        GLuint sort_prog;
        GLuint render_prog;
        GLuint[] vao = new uint[2];
        GLuint[] vbo = new uint[2];
        GLuint xfb;
        VBObject vbObject = new VBObject();

        GLint model_matrix_pos;
        GLint projection_matrix_pos;

        static string[] varyings =
        {
        "rf_position", "rf_normal",
        "gl_NextBuffer",
        "lf_position", "lf_normal"
        };
        public override void init(CSharpGL.GL gl) {
            {
                var id = stackalloc uint[1];
                gl.glGenTransformFeedbacks(1, id); xfb = id[0];
                gl.glBindTransformFeedback(GL.GL_TRANSFORM_FEEDBACK, xfb);
            }
            {
                var vsCodeFile = "10/ch10_draw_xfb/sort.vert";
                var gsCodeFile = "10/ch10_draw_xfb/sort.geom";
                var program = Utility.LoadShaders(varyings, GLProgram.BufferMode.InterLeaved,
                    (vsCodeFile, Shader.Kind.vert),
                    (gsCodeFile, Shader.Kind.geom));
                Debug.Assert(program != null); this.sort_prog = program.programId;
                gl.glUseProgram(this.sort_prog);

                model_matrix_pos = gl.glGetUniformLocation(sort_prog, "model_matrix");
                projection_matrix_pos = gl.glGetUniformLocation(sort_prog, "projection_matrix");
            }
            {
                var id = stackalloc uint[2];

                gl.glGenVertexArrays(2, id); vao[0] = id[0]; vao[1] = id[1];
                gl.glGenBuffers(2, id); vbo[0] = id[0]; vbo[1] = id[1];

                for (uint i = 0; i < 2; i++) {
                    gl.glBindBuffer(GL.GL_TRANSFORM_FEEDBACK_BUFFER, vbo[i]);
                    gl.glBufferData(GL.GL_TRANSFORM_FEEDBACK_BUFFER, 1024 * 1024 * sizeof(GLfloat), IntPtr.Zero, GL.GL_DYNAMIC_COPY);
                    gl.glBindBufferBase(GL.GL_TRANSFORM_FEEDBACK_BUFFER, i, vbo[i]);

                    gl.glBindVertexArray(vao[i]);
                    gl.glBindBuffer(GL.GL_ARRAY_BUFFER, vbo[i]);
                    gl.glVertexAttribPointer(0, 4, GL.GL_FLOAT, false,
                        sizeof(vec4) + sizeof(vec3), IntPtr.Zero);
                    gl.glVertexAttribPointer(1, 3, GL.GL_FLOAT, false,
                        sizeof(vec4) + sizeof(vec3), (IntPtr)(sizeof(vec4)));
                    gl.glEnableVertexAttribArray(0);
                    gl.glEnableVertexAttribArray(1);
                }

            }
            {
                var vsCodeFile = "10/ch10_draw_xfb/render.vert";
                var fsCodeFile = "10/ch10_draw_xfb/render.frag";
                var program = Utility.LoadShaders(
                    (vsCodeFile, Shader.Kind.vert),
                    (fsCodeFile, Shader.Kind.frag));
                Debug.Assert(program != null); this.render_prog = program.programId;
                gl.glUseProgram(this.render_prog);
            }
            vbObject.LoadFromVBM("media/ninja.vbm", 0, 1, 2);
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);

        static readonly vec4[] colors = {
        new vec4(0.8f, 0.8f, 0.9f, 0.5f),
        new vec4(0.3f, 1.0f, 0.3f, 0.8f)
        };
        public override void display(CSharpGL.GL gl) {
            float t = q; q += 0.1f;

            gl.glDisable(GL.GL_CULL_FACE);
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glDepthFunc(GL.GL_LEQUAL);

            gl.glClearDepth(1.0f);
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            gl.glUseProgram(sort_prog);

            //model = glm.translate(model, 0.0f, -80.0f, 0.0f);
            var model = glm.rotate(t * 5.0f, Z)
                * glm.rotate(t * 2.0f, Y)
                * glm.rotate(t, X)
                * glm.translate(0.0f, 0.0f, (float)Math.Sin(6.28318531f * t));

            //mat4 projection = glm.frustum(-1.0f, 1.0f, aspect, -aspect, 1.0f, 5000.0f);
            var projection = glm.perspective(60.0f / 180.0f * (float)Math.PI, 1.0f / aspect, 0.1f, 1000f)
                * glm.lookAt(new vec3(5, 1, 3) * 40, new vec3(0, 0, 0), new vec3(0, 1, 0));

            gl.glUniformMatrix4fv(model_matrix_pos, 1, false, (float*)&model);
            gl.glUniformMatrix4fv(projection_matrix_pos, 1, false, (float*)&projection);

            gl.glEnable(GL.GL_RASTERIZER_DISCARD);

            gl.glBindTransformFeedback(GL.GL_TRANSFORM_FEEDBACK, xfb);
            gl.glBeginTransformFeedback(GL.GL_POINTS);

            vbObject.Render();

            gl.glEndTransformFeedback();
            gl.glBindTransformFeedback(GL.GL_TRANSFORM_FEEDBACK, 0);

            gl.glDisable(GL.GL_RASTERIZER_DISCARD);


            gl.glUseProgram(render_prog);

            fixed (vec4* p = colors) {
                gl.glUniform4fv(0, 1, (float*)p);
            }
            gl.glBindVertexArray(vao[0]);
            gl.glDrawTransformFeedbackStream(GL.GL_TRIANGLES, xfb, 0);

            fixed (vec4* p = colors) {
                gl.glUniform4fv(0, 1, (float*)(p + 1));
            }
            gl.glBindVertexArray(vao[1]);
            gl.glDrawTransformFeedbackStream(GL.GL_TRIANGLES, xfb, 1);
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