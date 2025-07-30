
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {
    /*
     *  aargb.c
     *  This program draws shows how to draw anti-aliased lines. It draws
     *  two diagonal lines to form an X; when 'r' is typed in the window,
     *  the lines are rotated in opposite directions.
     */
    public unsafe class aargb : _glGuide7code {
        float rotAngle = 0.0f;


        public aargb(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        /*  Initialize antialiasing for RGBA mode, including alpha
     *  blending, hint, and line width.  Print out implementation
     *  specific info on line width granularity and width.
     */
        public override void init(CSharpGL.GL gl) {
            var values = stackalloc GLfloat[2];
            gl.glGetFloatv(GL.GL_LINE_WIDTH_GRANULARITY, values);
            //printf("GL.GL_LINE_WIDTH_GRANULARITY value is %3.1f\n", values[0]);

            gl.glGetFloatv(GL.GL_LINE_WIDTH_RANGE, values);
            //printf("GL.GL_LINE_WIDTH_RANGE values are %3.1f %3.1f\n", values[0], values[1]);

            gl.glEnable(GL.GL_LINE_SMOOTH);
            gl.glEnable(GL.GL_BLEND);
            gl.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
            gl.glHint(GL.GL_LINE_SMOOTH_HINT, GL.GL_DONT_CARE);
            gl.glLineWidth(1.5f);

            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }


        /* Draw 2 diagonal lines to form an X
         */
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            //gl.glClear(GL.GL_COLOR_BUFFER_BIT);

            gl.glColor3f(0.0f, 1.0f, 0.0f);
            gl.glPushMatrix();
            gl.glRotatef(-rotAngle, 0.0f, 0.0f, 0.1f);
            gl.glBegin(GL.GL_LINES);
            gl.glVertex2f(-0.5f, 0.5f);
            gl.glVertex2f(0.5f, -0.5f);
            gl.glEnd();
            gl.glPopMatrix();

            gl.glColor3f(0.0f, 0.0f, 1.0f);
            gl.glPushMatrix();
            gl.glRotatef(rotAngle, 0.0f, 0.0f, 0.1f);
            gl.glBegin(GL.GL_LINES);
            gl.glVertex2f(0.5f, 0.5f);
            gl.glVertex2f(-0.5f, -0.5f);
            gl.glEnd();
            gl.glPopMatrix();

            gl.glFlush();
        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, w, h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            if (w <= h) {
                //gl.gluOrtho2D(-1.0f, 1.0f, -1.0f * (GLfloat)h / (GLfloat)w, 1.0f * (GLfloat)h / (GLfloat)w);
                glu.Ortho2D(-1.0f, 1.0f, -1.0f * (GLfloat)h / (GLfloat)w, 1.0f * (GLfloat)h / (GLfloat)w);
            }
            else {
                //gl.gluOrtho2D(-1.0f * (GLfloat)w / (GLfloat)h, 1.0f * (GLfloat)w / (GLfloat)h, -1.0f, 1.0f);
                glu.Ortho2D(-1.0f * (GLfloat)w / (GLfloat)h, 1.0f * (GLfloat)w / (GLfloat)h, -1.0f, 1.0f);
            }
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }
        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.T:
            rotAngle += 20.0f;
            if (rotAngle >= 360.0f) rotAngle = 0.0f;
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.Escape:// 27:  /*  Escape Key  */
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