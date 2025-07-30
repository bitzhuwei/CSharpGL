
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
    *  clip.c
    *  This program demonstrates arbitrary clipping planes.
    */
    public unsafe class clip : _glGuide7code {

        public clip(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glShadeModel(GL.GL_FLAT);
        }

        GLdouble[] eqn = { 0.0f, 1.0f, 0.0f, 0.0f };
        GLdouble[] eqn2 = { 1.0f, 0.0f, 0.0f, 0.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            gl.glColor3f(1.0f, 1.0f, 1.0f);
            gl.glPushMatrix();
            gl.glTranslatef(0.0f, 0.0f, -5.0f);

            /*    clip lower half -- y < 0          */
            gl.glClipPlane(GL.GL_CLIP_PLANE0, eqn);
            gl.glEnable(GL.GL_CLIP_PLANE0);
            /*    clip left half -- x < 0           */
            gl.glClipPlane(GL.GL_CLIP_PLANE1, eqn2);
            gl.glEnable(GL.GL_CLIP_PLANE1);

            gl.glRotatef(90.0f, 1.0f, 0.0f, 0.0f);
            //gl.glutWireSphere(1.0f, 20, 16);
            glut.WireSphere(1.0f, 20, 16);
            gl.glPopMatrix();

            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            //gl.gluPerspective(60.0f, (GLfloat)w / (GLfloat)h, 1.0f, 20.0f);
            glu.Perspective(60.0f, (GLfloat)w / (GLfloat)h, 1.0f, 20.0f);
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

    }
}