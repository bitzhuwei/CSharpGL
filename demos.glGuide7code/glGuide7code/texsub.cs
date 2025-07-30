
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*  texsub.c
    *  This program texture maps a checkerboard image onto
    *  two rectangles.  This program clamps the texture, if
    *  the texture coordinates fall outside 0.0f and 1.0f.
    *  If the s key is pressed, a texture subimage is used to
    *  alter the original texture.  If the r key is pressed,
    *  the original texture is restored.
    */
    public unsafe class texsub : _glGuide7code {

        public texsub(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glShadeModel(GL.GL_FLAT);
            gl.glEnable(GL.GL_DEPTH_TEST);

            makeCheckImages();
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
            gl.glTexCoord2f(0.0f, 1.0f); gl.glVertex3f(-2.0f, 1.0f, 0.0f);
            gl.glTexCoord2f(1.0f, 1.0f); gl.glVertex3f(0.0f, 1.0f, 0.0f);
            gl.glTexCoord2f(1.0f, 0.0f); gl.glVertex3f(0.0f, -1.0f, 0.0f);

            gl.glTexCoord2f(0.0f, 0.0f); gl.glVertex3f(1.0f, -1.0f, 0.0f);
            gl.glTexCoord2f(0.0f, 1.0f); gl.glVertex3f(1.0f, 1.0f, 0.0f);
            gl.glTexCoord2f(1.0f, 1.0f); gl.glVertex3f(2.41421f, 1.0f, -1.41421f);
            gl.glTexCoord2f(1.0f, 0.0f); gl.glVertex3f(2.41421f, -1.0f, -1.41421f);
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
            case Keys.S:
            gl.glBindTexture(GL.GL_TEXTURE_2D, texName);
            fixed (byte* p = subImage) {
                gl.glTexSubImage2D(GL.GL_TEXTURE_2D, 0, 12, 44, subImageWidth,
                    subImageHeight, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, (IntPtr)p);
            }
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.R:
            gl.glBindTexture(GL.GL_TEXTURE_2D, texName);
            fixed (byte* p = checkImage) {
                gl.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGBA, checkImageWidth,
                    checkImageHeight, 0, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, (IntPtr)p);
            }
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


        public override Keys[] ValidKeys => [Keys.S, Keys.R];
        public override MouseButtons[] ValidButtons => [];

        /*  Create checkerboard textures  */
        const int checkImageWidth = 64;
        const int checkImageHeight = 64;
        const int subImageWidth = 16;
        const int subImageHeight = 16;
        static GLubyte[] checkImage = new GLubyte[checkImageHeight * checkImageWidth * 4];
        static GLubyte[] subImage = new GLubyte[subImageHeight * subImageWidth * 4];

        static GLuint texName;

        static void makeCheckImages() {
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
            for (var i = 0; i < subImageHeight; i++) {
                for (var j = 0; j < subImageWidth; j++) {
                    var a = (i & 0x4) == 0 ? 1 : 0; var b = (j & 0x4);
                    var c = ((a ^ b) == 0) ? 255 : 0;
                    subImage[(i * subImageWidth + j) * 4 + 0] = (GLubyte)c;
                    subImage[(i * subImageWidth + j) * 4 + 1] = (GLubyte)0;
                    subImage[(i * subImageWidth + j) * 4 + 2] = (GLubyte)0;
                    subImage[(i * subImageWidth + j) * 4 + 3] = (GLubyte)255;
                }
            }
        }
    }
}