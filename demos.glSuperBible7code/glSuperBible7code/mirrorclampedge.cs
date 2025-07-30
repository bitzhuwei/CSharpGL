
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class mirrorclampedge : _glSuperBible7code {
        ~mirrorclampedge() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public mirrorclampedge(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int TEXTURE_WIDTH = 512;
        const int TEXTURE_HEIGHT = 512;

        GLuint render_program;
        GLuint input_texture;
        GLuint output_texture;
        GLuint output_buffer;
        GLuint output_buffer_texture;
        GLuint dummy_vao;

        const int CLAMP_TO_BORDER = 0,
            MIRROR_CLAMP_TO_EDGE = 1,
            MAX_MODE = 2;

        int display_mode = CLAMP_TO_BORDER;
        int texLoc;

        text_overlay overlay = new text_overlay();

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/mirrorclampedge.vert";
                var fsCodeFile = "media/shaders/mirrorclampedge.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.render_program = programObj.programId;
                gl.glUseProgram(this.render_program);

                //texLoc = gl.glGetUniformLocation(this.render_program, "tex");

            }
            {
                overlay.init(80, 50);

                input_texture = sb7ktx.load("media/textures/rocks.ktx");

                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); dummy_vao = id[0];
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

            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, input_texture);

            gl.glBindVertexArray(dummy_vao);
            gl.glUseProgram(render_program);

            switch (display_mode) {
            case CLAMP_TO_BORDER:
            gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_BORDER);
            gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP_TO_BORDER);
            break;
            case MIRROR_CLAMP_TO_EDGE:
            gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)0x8743/*GL_MIRROR_CLAMP_TO_EDGE*/);
            gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)0x8743/*GL_MIRROR_CLAMP_TO_EDGE*/);
            break;
            }
            //gl.glUniform1i(texLoc, 0);
            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);

            overlay.clear();
            overlay.drawText(display_mode == CLAMP_TO_BORDER ? "Mode = GL.GL_CLAMP_TO_BORDER (M toggles)" : "Mode = GL.GL_MIRROR_CLAMP_TO_EDGE (M toggles)", 0, 0);
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
            case Keys.M:
            display_mode = display_mode + 1;
            if (display_mode == MAX_MODE)
                display_mode = CLAMP_TO_BORDER;
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.M];
        public override MouseButtons[] ValidButtons => [];

    }
}