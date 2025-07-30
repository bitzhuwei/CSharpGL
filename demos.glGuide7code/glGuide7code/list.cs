
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
     *  list.c
     *  This program demonstrates how to make and execute a
     *  display list.  Note that attributes, such as current
     *  color and matrix, are changed.
     */
    public unsafe class list : _glGuide7code {

        public list(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint listName;
        public override void init(CSharpGL.GL gl) {
            listName = gl.glGenLists(1);
            gl.glNewList(listName, GL.GL_COMPILE);
            gl.glColor3f(1.0f, 0.0f, 0.0f);  /*  current color red  */
            gl.glBegin(GL.GL_TRIANGLES);
            gl.glVertex2f(0.0f, 0.0f);
            gl.glVertex2f(1.0f, 0.0f);
            gl.glVertex2f(0.0f, 1.0f);
            gl.glEnd();
            gl.glTranslatef(1.5f, 0.0f, 0.0f); /*  move position  */
            gl.glEndList();
            gl.glShadeModel(GL.GL_FLAT);
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            gl.glColor3f(0.0f, 1.0f, 0.0f);  /*  current color green  */
            for (var i = 0; i < 10; i++)    /*  draw 10 triangles    */
                gl.glCallList(listName);
            drawLine(gl);  /*  is this line green?  NO!  */
            /*  where is the line drawn?  */
            gl.glTranslatef(-1.5f * 10, 0.0f, 0.0f); /*  move position  */

            gl.glFlush();
        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, w, h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            if (w <= h) {
                //gl.gluOrtho2D(0.0f, 2.0f, -0.5f * (GLfloat)h / (GLfloat)w,
                //1.5f * (GLfloat)h / (GLfloat)w);
                glu.Ortho2D(0.0f, 2.0f, -0.5f * (GLfloat)h / (GLfloat)w,
                    1.5f * (GLfloat)h / (GLfloat)w);
            }
            else {
                //gl.gluOrtho2D(0.0f, 2.0f * (GLfloat)w / (GLfloat)h, -0.5f, 1.5f);
                glu.Ortho2D(0.0f, 2.0f * (GLfloat)w / (GLfloat)h, -0.5f, 1.5f);
            }
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


        static void drawLine(GL gl) {
            gl.glBegin(GL.GL_LINES);
            gl.glVertex2f(0.0f, 0.5f);
            gl.glVertex2f(15.0f, 0.5f);
            gl.glEnd();
        }
    }
}