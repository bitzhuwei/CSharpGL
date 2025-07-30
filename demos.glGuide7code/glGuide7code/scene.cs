
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
  *  scene.c
  *  This program demonstrates the use of the GL lighting model.
  *  Objects are drawn using a grey material characteristic.
  *  A single light source illuminates the objects.
  */
    public unsafe class scene : _glGuide7code {

        public scene(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        static GLfloat[] light_ambient = { 0.0f, 0.0f, 0.0f, 1.0f };
        static GLfloat[] light_diffuse = { 1.0f, 1.0f, 1.0f, 1.0f };
        static GLfloat[] light_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
        /*	light_position is NOT default value	*/
        static GLfloat[] light_position = { 1.0f, 1.0f, 1.0f, 0.0f };
        /*  Initialize material property and light source.
         */
        public override void init(CSharpGL.GL gl) {
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_AMBIENT, light_ambient);
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_DIFFUSE, light_diffuse);
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_SPECULAR, light_specular);
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_POSITION, light_position);

            gl.glEnable(GL.GL_LIGHTING);
            gl.glEnable(GL.GL_LIGHT0);
            gl.glEnable(GL.GL_DEPTH_TEST);
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            gl.glPushMatrix();
            gl.glRotatef(20.0f, 1.0f, 0.0f, 0.0f);

            gl.glPushMatrix();
            gl.glTranslatef(-0.75f, 0.5f, 0.0f);
            gl.glRotatef(90.0f, 1.0f, 0.0f, 0.0f);
            //gl.glutSolidTorus(0.275f, 0.85f, 15, 15);
            glut.SolidTorus(0.275f, 0.85f, 15, 15);
            gl.glPopMatrix();

            gl.glPushMatrix();
            gl.glTranslatef(-0.75f, -0.5f, 0.0f);
            gl.glRotatef(270.0f, 1.0f, 0.0f, 0.0f);
            //gl.glutSolidCone(1.0f, 2.0f, 15, 15);
            glut.SolidCone(1.0f, 2.0f, 15, 15);
            gl.glPopMatrix();

            gl.glPushMatrix();
            gl.glTranslatef(0.75f, 0.0f, -1.0f);
            //gl.glutSolidSphere(1.0f, 15, 15);
            glut.SolidSphere(1.0f, 15, 15);
            gl.glPopMatrix();

            gl.glPopMatrix();
            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            if (w <= h)
                gl.glOrtho(-2.5f, 2.5f, -2.5f * (GLfloat)h / (GLfloat)w,
                    2.5f * (GLfloat)h / (GLfloat)w, -10.0f, 10.0f);
            else
                gl.glOrtho(-2.5f * (GLfloat)w / (GLfloat)h,
                    2.5f * (GLfloat)w / (GLfloat)h, -2.5f, 2.5f, -10.0f, 10.0f);
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