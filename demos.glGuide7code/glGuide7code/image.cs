
using CSharpGL;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*  image.c
   *  This program demonstrates drawing pixels and shows the effect
   *  of gl.glDrawPixels(), gl.glCopyPixels(), and gl.glPixelZoom().
   *  Interaction: moving the mouse while pressing the mouse button
   *  will copy the image in the lower-left corner of the window
   *  to the mouse position, using the current pixel zoom factors.
   *  There is no attempt to prevent you from drawing over the original
   *  image.  If you press the 'r' key, the original image and zoom
   *  factors are reset.  If you press the 'z' or 'Z' keys, you change
   *  the zoom factors.
   */
    public unsafe class image : _glGuide7code {

        public image(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        /*	Create checkerboard image	*/
        const int checkImageWidth = 64;
        const int checkImageHeight = 64;
        static GLubyte[] checkImage;// [checkImageHeight][checkImageWidth][3];
        GLdouble zoomFactor = 1.0f;
        GLint height;
        private FormDump? frmDump;

        static GLubyte[] makeCheckImage() {
            var result = new GLubyte[checkImageHeight * checkImageWidth * 3];
            for (var i = 0; i < checkImageHeight; i++) {
                for (var j = 0; j < checkImageWidth; j++) {
                    var a = (i & 0x8) == 0 ? 1 : 0; var b = (j & 0x8);
                    var c = ((a ^ b) == 0) ? 255 : 0;
                    result[(i * checkImageWidth + j) * 3 + 0] = (GLubyte)c;
                    result[(i * checkImageWidth + j) * 3 + 1] = (GLubyte)c;
                    result[(i * checkImageWidth + j) * 3 + 2] = (GLubyte)c;
                }
            }
            return result;
        }
        static image() {
            checkImage = makeCheckImage();
        }
        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glShadeModel(GL.GL_FLAT);
            //makeCheckImage();
            gl.glPixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);

            this.frmDump = new FormDump();
            this.frmDump.Show();
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glRasterPos2i(0, 0);
            fixed (GLubyte* p = checkImage) {
                gl.glDrawPixels(checkImageWidth, checkImageHeight, GL.GL_RGB,
                    GL.GL_UNSIGNED_BYTE, (IntPtr)p);
            }
            gl.glFlush();
        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            height = (GLint)h;
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            //gl.gluOrtho2D(0.0f, (GLdouble)w, 0.0f, (GLdouble)h);
            glu.Ortho2D(0.0f, w, 0.0f, h);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
            if (state == MouseState.Down) {
                motion(x, y);
            }
        }

        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            if (this.frmDump == null) { return; }

            switch (key) {
            case Keys.R:
            zoomFactor = 1.0f;
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            //printf("zoomFactor reset to 1.0f\n");
            this.frmDump.AppendLine("zoomFactor reset to 1.0f");
            break;
            case Keys.Z:
            zoomFactor += 0.5f;
            if (zoomFactor >= 3.0f)
                zoomFactor = 3.0f;
            //printf("zoomFactor is now %4.1f\n", zoomFactor);
            this.frmDump.AppendLine($"zoomFactor is now {zoomFactor}");
            break;
            case Keys.X:
            zoomFactor -= 0.5f;
            if (zoomFactor <= 0.5f)
                zoomFactor = 0.5f;
            //printf("zoomFactor is now %4.1f\n", zoomFactor);
            this.frmDump.AppendLine($"zoomFactor is now {zoomFactor}");
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            default:
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.R, Keys.Z, Keys.X];
        public override MouseButtons[] ValidButtons => [];


        void motion(int x, int y) {
            var gl = GL.Current; if (gl == null) return;

            GLint screeny;

            screeny = height - (GLint)y;
            gl.glRasterPos2i(x, screeny);
            gl.glPixelZoom((float)zoomFactor, (float)zoomFactor);
            gl.glCopyPixels(0, 0, checkImageWidth, checkImageHeight, GL.GL_COLOR);
            gl.glPixelZoom(1.0f, 1.0f);
            gl.glFlush();
        }
    }
}