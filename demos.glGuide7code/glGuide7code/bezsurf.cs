
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*  bezsurf.c
   *  This program renders a wireframe Bezier surface,
   *  using two-dimensional evaluators.
   */
    public unsafe class bezsurf : _glGuide7code {

        public bezsurf(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLfloat[] ctrlpoints = {// [4][4][3]
            -1.5f, -1.5f, 4.0f, -0.5f, -1.5f, 2.0f,
             0.5f, -1.5f, -1.0f, 1.5f, -1.5f, 2.0f,
            -1.5f, -0.5f, 1.0f, -0.5f, -0.5f, 3.0f,
             0.5f, -0.5f, 0.0f, 1.5f, -0.5f, -1.0f,
            -1.5f, 0.5f, 4.0f, -0.5f, 0.5f, 0.0f,
             0.5f, 0.5f, 3.0f, 1.5f, 0.5f, 4.0f,
            -1.5f, 1.5f, -2.0f, -0.5f, 1.5f, -2.0f,
             0.5f, 1.5f, 0.0f, 1.5f, 1.5f, -1.0f
        };

        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            fixed (float* p = ctrlpoints) {
                gl.glMap2f(GL.GL_MAP2_VERTEX_3, 0, 1, 3, 4, 0, 1, 12, 4, p);
            }
            gl.glEnable(GL.GL_MAP2_VERTEX_3);
            gl.glMapGrid2f(20, 0.0f, 1.0f, 20, 0.0f, 1.0f);
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glShadeModel(GL.GL_FLAT);
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glColor3f(1.0f, 1.0f, 1.0f);
            gl.glPushMatrix();
            gl.glRotatef(85.0f, 1.0f, 1.0f, 1.0f);
            for (var j = 0; j <= 8; j++) {
                gl.glBegin(GL.GL_LINE_STRIP);
                for (var i = 0; i <= 30; i++)
                    gl.glEvalCoord2f((GLfloat)i / 30.0f, (GLfloat)j / 8.0f);
                gl.glEnd();
                gl.glBegin(GL.GL_LINE_STRIP);
                for (var i = 0; i <= 30; i++)
                    gl.glEvalCoord2f((GLfloat)j / 8.0f, (GLfloat)i / 30.0f);
                gl.glEnd();
            }
            gl.glPopMatrix();
            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            if (w <= h)
                gl.glOrtho(-4.0f, 4.0f, -4.0f * (GLfloat)h / (GLfloat)w,
                    4.0f * (GLfloat)h / (GLfloat)w, -4.0f, 4.0f);
            else
                gl.glOrtho(-4.0f * (GLfloat)w / (GLfloat)h,
                    4.0f * (GLfloat)w / (GLfloat)h, -4.0f, 4.0f, -4.0f, 4.0f);
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