
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*  wrap.c
   *  This program texture maps a checkerboard image onto
   *  two rectangles.  This program demonstrates the wrapping
   *  modes, if the texture coordinates fall outside 0.0f and 1.0f.
   *  Interaction: Pressing the 's' and 'S' keys switch the
   *  wrapping between clamping and repeating for the s parameter.
   *  The 't' and 'T' keys control the wrapping for the t parameter.
   *
   *  If running this program on OpenGL 1.0f, texture objects are
   *  not used.
   */
    public unsafe class wrap : _glGuide7code {

        public wrap(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glShadeModel(GL.GL_FLAT);
            gl.glEnable(GL.GL_DEPTH_TEST);

            makeCheckImage();
            gl.glPixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);

            if (texName == 0) {
                var texture = stackalloc GLuint[1];
                gl.glGenTextures(1, texture); texName = texture[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D, texName);

                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_REPEAT);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_REPEAT);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST);
                fixed (byte* p = checkImage) {
                    gl.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGBA, checkImageWidth, checkImageHeight,
                        0, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, (IntPtr)p);
                }
            }
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glEnable(GL.GL_TEXTURE_2D);
            gl.glTexEnvf(GL.GL_TEXTURE_ENV, GL.GL_TEXTURE_ENV_MODE, GL.GL_DECAL);
            gl.glBindTexture(GL.GL_TEXTURE_2D, texName);

            gl.glBegin(GL.GL_QUADS);
            gl.glTexCoord2f(0.0f, 0.0f); gl.glVertex3f(-2.0f, -1.0f, 0.0f);
            gl.glTexCoord2f(0.0f, 3.0f); gl.glVertex3f(-2.0f, 1.0f, 0.0f);
            gl.glTexCoord2f(3.0f, 3.0f); gl.glVertex3f(0.0f, 1.0f, 0.0f);
            gl.glTexCoord2f(3.0f, 0.0f); gl.glVertex3f(0.0f, -1.0f, 0.0f);

            gl.glTexCoord2f(0.0f, 0.0f); gl.glVertex3f(1.0f, -1.0f, 0.0f);
            gl.glTexCoord2f(0.0f, 3.0f); gl.glVertex3f(1.0f, 1.0f, 0.0f);
            gl.glTexCoord2f(3.0f, 3.0f); gl.glVertex3f(2.41421f, 1.0f, -1.41421f);
            gl.glTexCoord2f(3.0f, 0.0f); gl.glVertex3f(2.41421f, -1.0f, -1.41421f);
            gl.glEnd();
            gl.glFlush();
            gl.glDisable(GL.GL_TEXTURE_2D);

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            //gl.gluPerspective(60.0f, (GLfloat)w / (GLfloat)h, 1.0f, 30.0f);
            glu.Perspective(60.0f, (GLfloat)w / (GLfloat)h, 1.0f, 30.0f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
            gl.glTranslatef(0.0f, 0.0f, -3.6f);
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }

        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.W:
            gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP);
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.S:
            gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_REPEAT);
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.G:
            gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP);
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.T:
            gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_REPEAT);
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            default:
            break;
            }

        }


        public override Keys[] ValidKeys => [Keys.W, Keys.S, Keys.G, Keys.T];
        public override MouseButtons[] ValidButtons => [];

        /*	Create checkerboard texture	*/
        const int checkImageWidth = 64;
        const int checkImageHeight = 64;
        static GLubyte[] checkImage = new GLubyte[checkImageHeight * checkImageWidth * 4];

        static GLuint texName = 0;

        void makeCheckImage() {
            for (var i = 0; i < checkImageHeight; i++) {
                for (var j = 0; j < checkImageWidth; j++) {
                    var a = (i & 0x8) == 0 ? 1 : 0; var b = (j & 0x8);
                    var c = ((a ^ b) == 0) ? 255 : 0;
                    checkImage[(i * checkImageWidth + j) * 4 + 0] = (GLubyte)c;
                    checkImage[(i * checkImageWidth + j) * 4 + 1] = (GLubyte)c;
                    checkImage[(i * checkImageWidth + j) * 4 + 2] = (GLubyte)c;
                    checkImage[(i * checkImageWidth + j) * 4 + 3] = (GLubyte)255;
                }
            }
        }
    }
}