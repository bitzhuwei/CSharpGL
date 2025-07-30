
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class fontdemo : _glSuperBible7code {
        ~fontdemo() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public fontdemo(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        text_overlay text_overlay = new text_overlay();

        static string string1 = "This a test. Can you hear me?";
        static string string2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*();:<>,./?~`'\"";
        static string string3 = "The quick brown fox jumped over the lazy dog.";

        public override void init(CSharpGL.GL gl) {
            {

                // _text_overlay.init(48, 32, "media/textures/font16x16.ktx");
                text_overlay.init(64, 32, "media/textures/cp437_9x16.ktx");
                text_overlay.clear();
                text_overlay.print("This is a demo of bitmap font rendering.\n\n"
                    + "This was printed as one string with newlines.\n\n"
                    + "If you have a really, really, really, really, really, really, really, really, really, really long string like this one, it will wrap.\n\n"
                    + "The final text buffer is composited over whatever was drawn into the framebuffer below.\n\n\n\n\n"
                    + "It's not all that pretty, but it's fast:");
                text_overlay.print("\n\n\n\n");
                text_overlay.print(string2);
                text_overlay.print("\n");
                text_overlay.print(string3);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        static int frame = 0;
        float currentTime = 0;// time
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            currentTime += 0.01f;

            var proj_matrix = this.proj_matrix;

            frame++;
            if ((frame & 0x1FF) == 0x100) {
                //sprintf(buffer, "%d frames in %lf secs = %3.3f fps", frame, currentTime, (float)frame / (float)currentTime);
                var buffer = $"frame: {frame}, time: {currentTime}";
                text_overlay.drawText(buffer, 0, 16);
            }

            var green = Utility.color.Green;
            gl.glClearBufferfv(GL.GL_COLOR, 0, (float*)&green);

            gl.glViewport(0, 0, this.width, this.height);

            text_overlay.draw();
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