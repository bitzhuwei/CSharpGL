
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
  *  stencil.c
  *  This program demonstrates use of the stencil buffer for
  *  masking nonrectangular regions.
  *  Whenever the window is redrawn, a value of 1 is drawn
  *  into a diamond-shaped region in the stencil buffer.
  *  Elsewhere in the stencil buffer, the value is 0.0f
  *  Then a blue sphere is drawn where the stencil value is 1,
  *  and yellow torii are drawn where the stencil value is not 1.f
  */
    public unsafe class stencil : _glGuide7code {

        public stencil(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int YELLOWMAT = 1;
        const int BLUEMAT = 2;
        static GLfloat[] yellow_diffuse = { 0.7f, 0.7f, 0.0f, 1.0f };
        static GLfloat[] yellow_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
        static GLfloat[] blue_diffuse = { 0.1f, 0.1f, 0.7f, 1.0f };
        static GLfloat[] blue_specular = { 0.1f, 1.0f, 1.0f, 1.0f };
        static GLfloat[] position_one = { 1.0f, 1.0f, 1.0f, 0.0f };
        public override void init(CSharpGL.GL gl) {
            gl.glNewList(YELLOWMAT, GL.GL_COMPILE);
            fixed (GLfloat* p = yellow_diffuse) {
                gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, p);
            }
            fixed (GLfloat* p = yellow_specular) {
                gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, p);
            }
            gl.glMaterialf(GL.GL_FRONT, GL.GL_SHININESS, 64.0f);
            gl.glEndList();

            gl.glNewList(BLUEMAT, GL.GL_COMPILE);
            fixed (GLfloat* p = blue_diffuse) {
                gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, p);
            }
            fixed (GLfloat* p = blue_specular) {
                gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, p);
            }
            gl.glMaterialf(GL.GL_FRONT, GL.GL_SHININESS, 45.0f);
            gl.glEndList();

            gl.glLightfv(GL.GL_LIGHT0, GL.GL_POSITION, position_one);

            gl.glEnable(GL.GL_LIGHT0);
            gl.glEnable(GL.GL_LIGHTING);
            gl.glEnable(GL.GL_DEPTH_TEST);

            gl.glClearStencil(0x0);
            gl.glEnable(GL.GL_STENCIL_TEST);
        }

        /* Draw a sphere in a diamond-shaped section in the
   * middle of a window with 2 torii.
   */
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            /* draw blue sphere where the stencil is 1 */
            gl.glStencilFunc(GL.GL_EQUAL, 0x1, 0x1);
            gl.glStencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_KEEP);
            gl.glCallList(BLUEMAT);
            //gl.glutSolidSphere(0.5f, 15, 15);
            glut.SolidSphere(0.5f, 15, 15);

            /* draw the tori where the stencil is not 1 */
            gl.glStencilFunc(GL.GL_NOTEQUAL, 0x1, 0x1);
            gl.glPushMatrix();
            gl.glRotatef(45.0f, 0.0f, 0.0f, 1.0f);
            gl.glRotatef(45.0f, 0.0f, 1.0f, 0.0f);
            gl.glCallList(YELLOWMAT);
            //gl.glutSolidTorus(0.275f, 0.85f, 15, 15);
            glut.SolidTorus(0.275f, 0.85f, 15, 15);
            gl.glPushMatrix();
            gl.glRotatef(90.0f, 1.0f, 0.0f, 0.0f);
            //gl.glutSolidTorus(0.275f, 0.85f, 15, 15);
            glut.SolidTorus(0.275f, 0.85f, 15, 15);
            gl.glPopMatrix();
            gl.glPopMatrix();

        }

        /*  Whenever the window is reshaped, redefine the
    *  coordinate system and redraw the stencil area.
    */
        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);

            /* create a diamond shaped stencil area */
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            if (w <= h) {
                //gl.gluOrtho2D(-3.0f, 3.0f, -3.0f * (GLfloat)h / (GLfloat)w, 3.0f * (GLfloat)h / (GLfloat)w);
                glu.Ortho2D(-3.0f, 3.0f, -3.0f * (GLfloat)h / (GLfloat)w, 3.0f * (GLfloat)h / (GLfloat)w);
            }
            else {
                //gl.gluOrtho2D(-3.0f * (GLfloat)w / (GLfloat)h, 3.0f * (GLfloat)w / (GLfloat)h, -3.0f, 3.0f);
                glu.Ortho2D(-3.0f * (GLfloat)w / (GLfloat)h, 3.0f * (GLfloat)w / (GLfloat)h, -3.0f, 3.0f);
            }
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();

            gl.glClear(GL.GL_STENCIL_BUFFER_BIT);
            gl.glStencilFunc(GL.GL_ALWAYS, 0x1, 0x1);
            gl.glStencilOp(GL.GL_REPLACE, GL.GL_REPLACE, GL.GL_REPLACE);
            gl.glBegin(GL.GL_QUADS);
            gl.glVertex2f(-1.0f, 0.0f);
            gl.glVertex2f(0.0f, 1.0f);
            gl.glVertex2f(1.0f, 0.0f);
            gl.glVertex2f(0.0f, -1.0f);
            gl.glEnd();

            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            //gl.gluPerspective(45.0f, (GLfloat)w / (GLfloat)h, 3.0f, 7.0f);
            glu.Perspective(45.0f, (GLfloat)w / (GLfloat)h, 3.0f, 7.0f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
            gl.glTranslatef(0.0f, 0.0f, -5.0f);
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