
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
  *  movelight.c
  *  This program demonstrates when to issue lighting and
  *  transformation commands to render a model with a light
  *  which is moved by a modeling transformation (rotate or
  *  translate).  The light position is reset after the modeling
  *  transformation is called.  The eye position does not change.
  *
  *  A sphere is drawn using a grey material characteristic.
  *  A single light source illuminates the object.
  *
  *  Interaction:  pressing the left mouse button alters
  *  the modeling transformation (x rotation) by 30 degrees.
  *  The scene is then redrawn with the light in a new position.
  */
    public unsafe class movelight : _glGuide7code {

        public movelight(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        int spin = 0;
        /*  Initialize material property, light source, lighting model,
    *  and depth buffer.
    */
        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glShadeModel(GL.GL_SMOOTH);
            gl.glEnable(GL.GL_LIGHTING);
            gl.glEnable(GL.GL_LIGHT0);
            gl.glEnable(GL.GL_DEPTH_TEST);
        }

        GLfloat[] position = { 0.0f, 0.0f, 1.5f, 1.0f };
        /*  Here is where the light position is reset after the modeling
    *  transformation (glRotated) is called.  This places the
    *  light at a new position in world coordinates.  The cube
    *  represents the position of the light.
    */
        public override void display(CSharpGL.GL gl) {

            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glPushMatrix();
            //gl.gluLookAt(0.0f, 0.0f, 5.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
            glu.LookAt(0.0f, 0.0f, 5.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);

            gl.glPushMatrix();
            gl.glRotated((GLdouble)spin, 1.0f, 0.0f, 0.0f);
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_POSITION, position);

            gl.glTranslated(0.0f, 0.0f, 1.5f);
            gl.glDisable(GL.GL_LIGHTING);
            gl.glColor3f(0.0f, 1.0f, 1.0f);
            //gl.glutWireCube(0.1f);
            glut.WireCube(0.1f);
            gl.glEnable(GL.GL_LIGHTING);
            gl.glPopMatrix();

            //gl.glutSolidTorus(0.275f, 0.85f, 8, 15);
            glut.SolidTorus(0.275f, 0.85f, 8, 15);
            gl.glPopMatrix();
            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            //gl.gluPerspective(40.0f, (GLfloat)w / (GLfloat)h, 1.0f, 20.0f);
            glu.Perspective(40.0f, (GLfloat)w / (GLfloat)h, 1.0f, 20.0f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
            var gl = GL.Current; if (gl == null) { return; }

            switch (button) {
            case MouseButtons.Left:
            if (state == MouseState.Down) {
                spin = (spin + 3) % 360;
                //gl.glutPostRedisplay();
                this.mainForm.Invalidate();
            }
            break;
            default:
            break;
            }
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
        public override MouseButtons[] ValidButtons => [MouseButtons.Left];

    }
}