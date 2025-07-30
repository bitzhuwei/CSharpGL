
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class hdrtonemap : _glSuperBible7code {
        ~hdrtonemap() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public hdrtonemap(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint tex_src;
        GLuint tex_lut;

        GLuint program_naive;
        GLuint program_exposure;
        GLuint program_adaptive;
        GLuint vao;
        float exposure = 1;
        int mode;

        struct _uniforms {
            public struct _exposure {
                public int exposure;
            }
            public _exposure exposure;
        }
        _uniforms uniforms;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/hdrtonemap.vert";
                var fsCodeFile = "media/shaders/hdrtonemap.naive.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program_naive = programObj.programId;
                gl.glUseProgram(this.program_naive);

            }
            {
                var vsCodeFile = "media/shaders/hdrtonemap.vert";
                var fsCodeFile = "media/shaders/hdrtonemap.adaptive.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program_adaptive = programObj.programId;
                gl.glUseProgram(this.program_adaptive);

            }
            {
                var vsCodeFile = "media/shaders/hdrtonemap.vert";
                var fsCodeFile = "media/shaders/hdrtonemap.exposure.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program_exposure = programObj.programId;
                gl.glUseProgram(this.program_exposure);

                uniforms.exposure.exposure = gl.glGetUniformLocation(program_exposure, "exposure");

            }
            {
                // Load texture from file
                tex_src = sb7ktx.load("media/textures/treelights_2k.ktx");

                // Now bind it to the context using the GL.GL_TEXTURE_2D binding point
                gl.glBindTexture(GL.GL_TEXTURE_2D, tex_src);
                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);

                var exposureLUT = stackalloc GLfloat[20] { 11.0f, 6.0f, 3.2f, 2.8f, 2.2f, 1.90f, 1.80f, 1.80f, 1.70f, 1.70f, 1.60f, 1.60f, 1.50f, 1.50f, 1.40f, 1.40f, 1.30f, 1.20f, 1.10f, 1.00f };

                gl.glGenTextures(1, id); tex_lut = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_1D, tex_lut);
                gl.glTexStorage1D(GL.GL_TEXTURE_1D, 1, GL.GL_R32F, 20);
                gl.glTexSubImage1D(GL.GL_TEXTURE_1D, 0, 0, 20, GL.GL_RED, GL.GL_FLOAT, (IntPtr)exposureLUT);
                gl.glTexParameteri(GL.GL_TEXTURE_1D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
                gl.glTexParameteri(GL.GL_TEXTURE_1D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
                gl.glTexParameteri(GL.GL_TEXTURE_1D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_EDGE);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float t = 0;// time
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            t += 0.01f;

            var proj_matrix = this.proj_matrix;

            gl.glActiveTexture(GL.GL_TEXTURE1);
            gl.glBindTexture(GL.GL_TEXTURE_1D, tex_lut);
            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, tex_src);

            // glUseProgram(mode ? program_adaptive : program_naive);
            switch (mode) {
            case 0:
            gl.glUseProgram(program_naive);
            break;
            case 1:
            gl.glUseProgram(program_exposure);
            gl.glUniform1f(uniforms.exposure.exposure, exposure);
            break;
            case 2:
            gl.glUseProgram(program_adaptive);
            break;
            }
            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);
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
            case Keys.D1:
            case Keys.D2:
            case Keys.D3:
            mode = key - Keys.D1;
            break;
            case Keys.M:
            mode = (mode + 1) % 3;
            break;
            case Keys.W:
            exposure *= 1.1f;
            break;
            case Keys.S:
            exposure /= 1.1f;
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.D1, Keys.D2, Keys.D3, Keys.M, Keys.W, Keys.S];
        public override MouseButtons[] ValidButtons => [];

    }
}