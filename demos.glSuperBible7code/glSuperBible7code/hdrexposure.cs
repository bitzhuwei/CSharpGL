
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class hdrexposure : _glSuperBible7code {
        ~hdrexposure() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public hdrexposure(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint texture;
        GLuint program;
        int texLoc;
        int exposureLoc;
        GLuint vao;
        float exposure = 1;
        text_overlay overlay = new text_overlay();

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/hdrexposure.vert";
                var fsCodeFile = "media/shaders/hdrexposure.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program = programObj.programId;
                gl.glUseProgram(this.program);
                texLoc = gl.glGetUniformLocation(program, "s");
                exposureLoc = gl.glGetUniformLocation(program, "exposure");

            }
            {
                overlay.init(80, 50);
                var id = stackalloc GLuint[1];

                // Load texture from file
                texture = sb7ktx.load("media/textures/treelights_2k.ktx");

                // Now bind it to the context using the GL.GL_TEXTURE_2D binding point
                gl.glBindTexture(GL.GL_TEXTURE_2D, texture);

                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);
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

            gl.glUseProgram(program);
            const int textureUnitIndex = 0;
            gl.glActiveTexture(GL.GL_TEXTURE0 + textureUnitIndex);
            gl.glBindTexture(GL.GL_TEXTURE_2D, texture);
            gl.glUniform1i(texLoc, textureUnitIndex);
            //gl.glViewport(0, 0, this.width, this.height);
            gl.glUniform1f(exposureLoc, exposure);
            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);

            var buffer = $"exposure = {exposure} (W/S to change)";
            overlay.clear();
            overlay.drawText(buffer, 0, 0);
            overlay.draw();
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


        public override Keys[] ValidKeys => [Keys.W, Keys.S];
        public override MouseButtons[] ValidButtons => [];

    }
}