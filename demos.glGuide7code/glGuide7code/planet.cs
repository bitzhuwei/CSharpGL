
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
  *  planet.c
  *  This program shows how to composite modeling transformations
  *  to draw translated and rotated models.
  *  Interaction:  pressing the d and y keys (day and year)
  *  alters the rotation of the planet around the sun.
  */
    public unsafe class planet : _glGuide7code {

        public planet(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        int year = 0; int day = 0;
        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glShadeModel(GL.GL_FLAT);
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glColor3f(1.0f, 1.0f, 1.0f);

            gl.glPushMatrix();
            //gl.glutWireSphere(1.0f, 20, 16);   /* draw sun */
            glut.WireSphere(1.0f, 20, 16);   /* draw sun */
            gl.glRotatef((GLfloat)year, 0.0f, 1.0f, 0.0f);
            gl.glTranslatef(2.0f, 0.0f, 0.0f);
            gl.glRotatef((GLfloat)day, 0.0f, 1.0f, 0.0f);
            //gl.glutWireSphere(0.2f, 10, 8);    /* draw smaller planet */
            glut.WireSphere(0.2f, 10, 8);    /* draw smaller planet */
            gl.glPopMatrix();
            //gl.glutSwapBuffers();
        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            //gl.gluPerspective(60.0f, (GLfloat)w / (GLfloat)h, 1.0f, 20.0f);
            glu.Perspective(60.0f, (GLfloat)w / (GLfloat)h, 1.0f, 20.0f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
            //gl.gluLookAt(0.0f, 0.0f, 5.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
            glu.LookAt(0.0f, 0.0f, 5.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }

        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.D:
            day = (day + 10) % 360;
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.A:
            day = (day - 10) % 360;
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.W:
            year = (year + 5) % 360;
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.S:
            year = (year - 5) % 360;
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


        public override Keys[] ValidKeys => [Keys.W, Keys.S, Keys.A, Keys.D];
        public override MouseButtons[] ValidButtons => [];

    }
}