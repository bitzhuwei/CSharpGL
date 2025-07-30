
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
   * smooth.c
   * This program demonstrates smooth shading.
   * A smooth shaded polygon is drawn in a 2-D projection.
   */
    public unsafe class smooth : _glGuide7code {

        public smooth(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glShadeModel(GL.GL_SMOOTH);
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            triangle(gl);
            gl.glFlush();
        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            if (w <= h) {
                //gl.gluOrtho2D(0.0f, 30.0f, 0.0f, 30.0f * (GLfloat)h / (GLfloat)w);
                glu.Ortho2D(0.0f, 30.0f, 0.0f, 30.0f * (GLfloat)h / (GLfloat)w);
            }
            else {
                //gl.gluOrtho2D(0.0f, 30.0f * (GLfloat)w / (GLfloat)h, 0.0f, 30.0f);
                glu.Ortho2D(0.0f, 30.0f * (GLfloat)w / (GLfloat)h, 0.0f, 30.0f);
            }
            gl.glMatrixMode(GL.GL_MODELVIEW);
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


        void triangle(CSharpGL.GL gl) {
            gl.glBegin(GL.GL_TRIANGLES);
            gl.glColor3f(1.0f, 0.0f, 0.0f);
            gl.glVertex2f(5.0f, 5.0f);
            gl.glColor3f(0.0f, 1.0f, 0.0f);
            gl.glVertex2f(25.0f, 5.0f);
            gl.glColor3f(0.0f, 0.0f, 1.0f);
            gl.glVertex2f(5.0f, 25.0f);
            gl.glEnd();
        }
    }
}