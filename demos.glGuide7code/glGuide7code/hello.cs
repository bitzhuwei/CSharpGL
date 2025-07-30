
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
   * hello.c
   * This is a simple, introductory OpenGL program.
   */
    public unsafe class hello : _glGuide7code {

        public hello(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        public override void init(CSharpGL.GL gl) {
            /* select clearing color 	*/
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            /* initialize viewing values  */
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            gl.glOrtho(0.0f, 1.0f, 0.0f, 1.0f, -1.0f, 1.0f);
        }

        public override void display(CSharpGL.GL gl) {
            /* clear all pixels  */
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            /* draw white polygon (rectangle) with corners at
             * (0.25f, 0.25f, 0.0f) and (0.75f, 0.75f, 0.0f)
             */
            gl.glColor3f(1.0f, 1.0f, 1.0f);
            gl.glBegin(GL.GL_POLYGON);
            gl.glVertex3f(0.25f, 0.25f, 0.0f);
            gl.glVertex3f(0.75f, 0.25f, 0.0f);
            gl.glVertex3f(0.75f, 0.75f, 0.0f);
            gl.glVertex3f(0.25f, 0.75f, 0.0f);
            gl.glEnd();

            /* don't wait!
             * start processing buffered OpenGL routines
             */
            gl.glFlush();
        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }

        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {

        }


        public override Keys[] ValidKeys => [];
        public override MouseButtons[] ValidButtons => [];

    }
}