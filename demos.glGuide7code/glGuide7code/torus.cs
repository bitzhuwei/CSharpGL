
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
  *  torus.c
  *  This program demonstrates the creation of a display list.
  */
    public unsafe class torus : _glGuide7code {

        public torus(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        /* Create display list with Torus and initialize state */
        public override void init(CSharpGL.GL gl) {
            theTorus = gl.glGenLists(1);
            gl.glNewList(theTorus, GL.GL_COMPILE);
            drawTorus(8, 25);
            gl.glEndList();

            gl.glShadeModel(GL.GL_FLAT);
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }

        /* Clear window and draw torus */
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glColor3f(1.0f, 1.0f, 1.0f);
            gl.glCallList(theTorus);
            gl.glFlush();
        }

        /* Handle window resize */
        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            //gl.gluPerspective(30, (GLfloat)w / (GLfloat)h, 1.0f, 100.0f);
            glu.Perspective(30, (GLfloat)w / (GLfloat)h, 1.0f, 100.0f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
            //gl.gluLookAt(0, 0, 10, 0, 0, 0, 0, 1, 0);
            glu.LookAt(0, 0, 10, 0, 0, 0, 0, 1, 0);
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }

        /* Rotate about x-axis when "x" typed; rotate about y-axis
     when "y" typed; "i" returns torus to original view */
        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.X:
            gl.glRotatef(30.0f, 1.0f, 0.0f, 0.0f);
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.Y:
            gl.glRotatef(30.0f, 0.0f, 1.0f, 0.0f);
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.I:
            gl.glLoadIdentity();
            //gl.gluLookAt(0, 0, 10, 0, 0, 0, 0, 1, 0);
            glu.LookAt(0, 0, 10, 0, 0, 0, 0, 1, 0);
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [];
        public override MouseButtons[] ValidButtons => [];


        GLuint theTorus;

        /* Draw a torus */
        static void drawTorus(int numc, int numt) {
            var gl = GL.Current; if (gl == null) { return; }

            int i, j, k;
            double s, t, x, y, z, twopi;

            twopi = 2 * Math.PI;
            for (i = 0; i < numc; i++) {
                gl.glBegin(GL.GL_QUAD_STRIP);
                for (j = 0; j <= numt; j++) {
                    for (k = 1; k >= 0; k--) {
                        s = (i + k) % numc + 0.5f;
                        t = j % numt;

                        x = (1 + .1 * Math.Cos(s * twopi / numc)) * Math.Cos(t * twopi / numt);
                        y = (1 + .1 * Math.Cos(s * twopi / numc)) * Math.Sin(t * twopi / numt);
                        z = 0.1 * Math.Sin(s * twopi / numc);
                        //gl.glVertex3f(x, y, z);
                        gl.glVertex3d(x, y, z);
                    }
                }
                gl.glEnd();
            }
        }
    }
}