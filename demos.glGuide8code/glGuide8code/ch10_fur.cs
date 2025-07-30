
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch10_fur : _glGuide8code {
        ~ch10_fur() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public ch10_fur(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        // Member variables
        float aspect;
        GLuint base_prog;
        GLuint fur_prog;
        GLuint fur_texture;
        VBObject vbObject = new VBObject();

        GLint fur_model_matrix_pos;
        GLint fur_projection_matrix_pos;
        GLint base_model_matrix_pos;
        GLint base_projection_matrix_pos;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "10/ch10_fur/base.vert";
                var fsCodeFile = "10/ch10_fur/base.frag";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.base_prog = program.programId;
                gl.glUseProgram(this.base_prog);

                base_model_matrix_pos = gl.glGetUniformLocation(base_prog, "model_matrix");
                base_projection_matrix_pos = gl.glGetUniformLocation(base_prog, "projection_matrix");
            }
            {
                var vsCodeFile = "10/ch10_fur/fur.vert";
                var gsCodeFile = "10/ch10_fur/fur.geom";
                var fsCodeFile = "10/ch10_fur/fur.frag";
                var program = Utility.LoadShaders(vsCodeFile, gsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.fur_prog = program.programId;
                gl.glUseProgram(this.fur_prog);

                fur_model_matrix_pos = gl.glGetUniformLocation(fur_prog, "model_matrix");
                fur_projection_matrix_pos = gl.glGetUniformLocation(fur_prog, "projection_matrix");
            }
            {
                var id = stackalloc uint[1];
                gl.glGenTextures(1, id); fur_texture = id[0];
                //unsigned char* tex = (unsigned char*)malloc(1024 * 1024 * 4);
                //memset(tex, 0, 1024 * 1024 * 4);
                var tex = new byte[1024 * 1024 * 4];
                var span = tex.AsSpan();

                var rand = new Random();
                for (var n = 0; n < 256; n++) {
                    for (var m = 0; m < 1270; m++) {
                        int x = rand.Next() & 0x3FF;
                        int y = rand.Next() & 0x3FF;
                        span[(y * 1024 + x) * 4 + 0] = (byte)((rand.Next() & 0x3F) + 0xC0);
                        span[(y * 1024 + x) * 4 + 1] = (byte)((rand.Next() & 0x3F) + 0xC0);
                        span[(y * 1024 + x) * 4 + 2] = (byte)((rand.Next() & 0x3F) + 0xC0);
                        span[(y * 1024 + x) * 4 + 3] = (byte)n;
                    }
                }

                gl.glBindTexture(GL.GL_TEXTURE_2D, fur_texture);
                var ptr = MemoryMarshal.GetReference(span);
                gl.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGBA, 1024, 1024, 0, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, ptr);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
                //free(tex);
            }
            vbObject.LoadFromVBM("media/ninja.vbm", 0, 1, 2);
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        public override void display(CSharpGL.GL gl) {
            float t = q; q += 1f;

            gl.glClearDepth(1.0f);
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            //mat4 projection = glm.frustum(-1.0f, 1.0f, aspect, -aspect, 1.0f, 5000.0f);
            var position = (glm.rotate(t, 0, 1, 0) * new vec4(5, 1, 3, 1));
            mat4 projection = glm.perspective(60.0f / 180.0f * (float)Math.PI, 1.0f / aspect, 0.1f, 1000f)
                * glm.lookAt(new vec3(position) * 50.0f, new vec3(0, 0, 0), new vec3(0, 1, 0));
            //mat4 model = mat4.identity();
            //model = glm.translate(model, 0.0f, -80.0f, 0.0f);
            //model = glm.rotate(model, 180.0f, Z);
            //model = glm.rotate(model, 360.0f * t * 1.0f, Y);
            //model = glm.translate(model, 0, 0, -130.0f);
            //var position = (glm.rotate(mat4.identity(), t, 0, 1, 0) * new vec4(5, 1, 3, 1));
            //mat4 model = glm.lookAt(new vec3(position) * 50f, new vec3(0, 0, 0), new vec3(0, 1, 0));
            mat4 model = mat4.identity();

            gl.glUseProgram(base_prog);

            gl.glUniformMatrix4fv(base_model_matrix_pos, 1, false, (float*)&model);
            gl.glUniformMatrix4fv(base_projection_matrix_pos, 1, false, (float*)&projection);

            gl.glDisable(GL.GL_BLEND);
            gl.glEnable(GL.GL_CULL_FACE);
            gl.glCullFace(GL.GL_FRONT);
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glDepthFunc(GL.GL_LEQUAL);

            vbObject.Render();

            gl.glUseProgram(fur_prog);

            gl.glUniformMatrix4fv(fur_model_matrix_pos, 1, false, (float*)&model);
            gl.glUniformMatrix4fv(fur_projection_matrix_pos, 1, false, (float*)&projection);

            gl.glEnable(GL.GL_BLEND);
            gl.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);

            gl.glDepthMask(false);

            vbObject.Render();

            gl.glDepthMask(true);
            gl.glDisable(GL.GL_BLEND);
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