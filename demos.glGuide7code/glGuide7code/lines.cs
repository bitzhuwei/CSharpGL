
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
   *  lines.c
   *  This program demonstrates geometric primitives and
   *  their attributes.
   */
    public unsafe class lines : _glGuide7code {

        public lines(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glShadeModel(GL.GL_FLAT);
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            /* select white for all lines  */
            gl.glColor3f(1.0f, 1.0f, 1.0f);

            /* in 1st row, 3 lines, each with a different stipple  */
            gl.glEnable(GL.GL_LINE_STIPPLE);

            gl.glLineStipple(1, 0x0101);  /*  dotted  */
            drawOneLine(50.0f, 125.0f, 150.0f, 125.0f);
            gl.glLineStipple(1, 0x00FF);  /*  dashed  */
            drawOneLine(150.0f, 125.0f, 250.0f, 125.0f);
            gl.glLineStipple(1, 0x1C47);  /*  dash/dot/dash  */
            drawOneLine(250.0f, 125.0f, 350.0f, 125.0f);

            /* in 2nd row, 3 wide lines, each with different stipple */
            gl.glLineWidth(5.0f);
            gl.glLineStipple(1, 0x0101);  /*  dotted  */
            drawOneLine(50.0f, 100.0f, 150.0f, 100.0f);
            gl.glLineStipple(1, 0x00FF);  /*  dashed  */
            drawOneLine(150.0f, 100.0f, 250.0f, 100.0f);
            gl.glLineStipple(1, 0x1C47);  /*  dash/dot/dash  */
            drawOneLine(250.0f, 100.0f, 350.0f, 100.0f);
            gl.glLineWidth(1.0f);

            /* in 3rd row, 6 lines, with dash/dot/dash stipple  */
            /* as part of a single connected line strip         */
            gl.glLineStipple(1, 0x1C47);  /*  dash/dot/dash  */
            gl.glBegin(GL.GL_LINE_STRIP);
            for (var i = 0; i < 7; i++)
                gl.glVertex2f(50.0f + ((GLfloat)i * 50.0f), 75.0f);
            gl.glEnd();

            /* in 4th row, 6 independent lines with same stipple  */
            for (var i = 0; i < 6; i++) {
                drawOneLine(50.0f + ((GLfloat)i * 50.0f), 50.0f,
                    50.0f + ((GLfloat)(i + 1) * 50.0f), 50.0f);
            }

            /* in 5th row, 1 line, with dash/dot/dash stipple    */
            /* and a stipple repeat factor of 5                  */
            gl.glLineStipple(5, 0x1C47);  /*  dash/dot/dash  */
            drawOneLine(50.0f, 25.0f, 350.0f, 25.0f);

            gl.glDisable(GL.GL_LINE_STIPPLE);
            gl.glFlush();
        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            //gl.gluOrtho2D(0.0f, (GLdouble)w, 0.0f, (GLdouble)h);
            glu.Ortho2D(0.0f, w, 0.0f, h);
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

        private static void drawOneLine(float x1, float y1, float x2, float y2) {
            var gl = GL.Current; if (gl == null) { return; }

            gl.glBegin(GL.GL_LINES);
            gl.glVertex2f((x1), (y1)); gl.glVertex2f((x2), (y2));
            gl.glEnd();
        }
    }
}
