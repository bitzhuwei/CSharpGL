
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {
    /*
     *  alpha.c
     *  This program draws several overlapping filled polygons
     *  to demonstrate the effect order has on alpha blending results.
     *  Use the 't' key to toggle the order of drawing polygons.
     */
    public unsafe class alpha : _glGuide7code {
        bool leftFirst = true;// GL.GL_TRUE;

        public alpha(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        /*  Initialize alpha blending function.
    */
        public override void init(CSharpGL.GL gl) {
            gl.glEnable(GL.GL_BLEND);
            gl.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
            gl.glShadeModel(GL.GL_FLAT);
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }

        static void drawLeftTriangle(GL gl) {
            /* draw yellow triangle on LHS of screen */

            gl.glBegin(GL.GL_TRIANGLES);
            gl.glColor4f(1.0f, 1.0f, 0.0f, 0.75f);
            gl.glVertex3f(0.1f, 0.9f, 0.0f);
            gl.glVertex3f(0.1f, 0.1f, 0.0f);
            gl.glVertex3f(0.7f, 0.5f, 0.0f);
            gl.glEnd();
        }

        static void drawRightTriangle(GL gl) {
            /* draw cyan triangle on RHS of screen */

            gl.glBegin(GL.GL_TRIANGLES);
            gl.glColor4f(0.0f, 1.0f, 1.0f, 0.75f);
            gl.glVertex3f(0.9f, 0.9f, 0.0f);
            gl.glVertex3f(0.3f, 0.5f, 0.0f);
            gl.glVertex3f(0.9f, 0.1f, 0.0f);
            gl.glEnd();
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            if (leftFirst) {
                drawLeftTriangle(gl);
                drawRightTriangle(gl);
            }
            else {
                drawRightTriangle(gl);
                drawLeftTriangle(gl);
            }

            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            if (w <= h) {
                //gl.gluOrtho2D(0.0f, 1.0f, 0.0f, 1.0f * (GLfloat)h / (GLfloat)w);
                glu.Ortho2D(0.0f, 1.0f, 0.0f, 1.0f * (GLfloat)h / (GLfloat)w);
            }
            else {
                //gl.gluOrtho2D(0.0f, 1.0f * (GLfloat)w / (GLfloat)h, 0.0f, 1.0f);
                glu.Ortho2D(0.0f, 1.0f * (GLfloat)w / (GLfloat)h, 0.0f, 1.0f);
            }
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }
        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.T:
            leftFirst = !leftFirst;
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.Escape:// 27:  /*  Escape key  */
            //exit(0);
            this.mainForm.Close();
            break;
            default:
            break;
            }

        }

        public override Keys[] ValidKeys => [Keys.T];
        public override MouseButtons[] ValidButtons => [];

    }
}