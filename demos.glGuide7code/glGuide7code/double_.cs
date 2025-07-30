
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
    *  double.c
    *  This is a simple double buffered program.
    *  Pressing the left mouse button rotates the rectangle.
    *  Pressing the middle mouse button stops the rotation.
    */
    public unsafe class double_ : _glGuide7code {

        public double_(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLfloat spin = 0.0f;
        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glShadeModel(GL.GL_FLAT);
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glPushMatrix();
            gl.glRotatef(spin, 0.0f, 0.0f, 1.0f);
            gl.glColor3f(1.0f, 1.0f, 1.0f);
            gl.glRectf(-25.0f, -25.0f, 25.0f, 25.0f);
            gl.glPopMatrix();

            //gl.glutSwapBuffers();

        }

        void spinDisplay(object? sender, EventArgs e) {
            spin = spin + 2.0f;
            if (spin > 360.0f) {
                spin = spin - 360.0f;
            }
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            gl.glOrtho(-50.0f, 50.0f, -50.0f, 50.0f, -1.0f, 1.0f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
            switch (button) {
            case MouseButtons.Left:
            if (state == MouseState.Down) {
                //gl.glutIdleFunc(spinDisplay);
                glut.IdleFunc(spinDisplay);
            }
            break;
            case MouseButtons.Middle:
            case MouseButtons.Right:
            if (state == MouseState.Down) {
                //gl.glutIdleFunc(NULL);
                glut.IdleFunc(null);
            }
            break;
            default:
            break;
            }
        }

        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {

        }


        public override Keys[] ValidKeys => [Keys.T];
        public override MouseButtons[] ValidButtons => [MouseButtons.Left, MouseButtons.Middle, MouseButtons.Right];

    }
}