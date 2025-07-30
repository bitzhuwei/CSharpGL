
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {
    /*  bezcurve.c
     *  This program uses evaluators to draw a Bezier curve.
     */
    public unsafe class bezcurve : _glGuide7code {

        public bezcurve(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }
        GLfloat[] ctrlpoints = {
            -4.0f, -4.0f, 0.0f,
            -2.0f, 4.0f, 0.0f,
            2.0f, -4.0f, 0.0f,
            4.0f, 4.0f, 0.0f
        };

        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glShadeModel(GL.GL_FLAT);
            gl.glMap1f(GL.GL_MAP1_VERTEX_3, 0.0f, 1.0f, 3, 4, ctrlpoints);
            gl.glEnable(GL.GL_MAP1_VERTEX_3);
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glColor3f(1.0f, 1.0f, 1.0f);
            gl.glBegin(GL.GL_LINE_STRIP);
            for (var i = 0; i <= 30; i++)
                gl.glEvalCoord1f((GLfloat)i / 30.0f);
            gl.glEnd();
            /* The following code displays the control points as dots. */
            gl.glPointSize(5.0f);
            gl.glColor3f(1.0f, 1.0f, 0.0f);
            gl.glBegin(GL.GL_POINTS);
            for (var i = 0; i < 4; i++)
                gl.glVertex3f(ctrlpoints[i * 3 + 0], ctrlpoints[i * 3 + 1], ctrlpoints[i * 3 + 2]);
            gl.glEnd();
            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            if (w <= h)
                gl.glOrtho(-5.0f, 5.0f, -5.0f * (GLfloat)h / (GLfloat)w,
                    5.0f * (GLfloat)h / (GLfloat)w, -5.0f, 5.0f);
            else
                gl.glOrtho(-5.0f * (GLfloat)w / (GLfloat)h,
                    5.0f * (GLfloat)w / (GLfloat)h, -5.0f, 5.0f, -5.0f, 5.0f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
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

    }
}