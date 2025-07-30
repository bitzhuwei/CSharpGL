
using CSharpGL;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
  * robot.c
  * This program shows how to composite modeling transformations
  * to draw translated and rotated hierarchical models.
  * Interaction:  pressing the s and e keys (shoulder and elbow)
  * alters the rotation of the robot arm.
  */
    public unsafe class robot : _glGuide7code {

        public robot(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        int shoulder = 0, elbow = 0;
        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glShadeModel(GL.GL_FLAT);
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glPushMatrix();
            gl.glTranslatef(-1.0f, 0.0f, 0.0f);
            gl.glRotatef((GLfloat)shoulder, 0.0f, 0.0f, 1.0f);
            gl.glTranslatef(1.0f, 0.0f, 0.0f);
            gl.glPushMatrix();
            gl.glScalef(2.0f, 0.4f, 1.0f);
            //gl.glutWireCube(1.0f);
            glut.WireCube(1.0f);
            gl.glPopMatrix();

            gl.glTranslatef(1.0f, 0.0f, 0.0f);
            gl.glRotatef((GLfloat)elbow, 0.0f, 0.0f, 1.0f);
            gl.glTranslatef(1.0f, 0.0f, 0.0f);
            gl.glPushMatrix();
            gl.glScalef(2.0f, 0.4f, 1.0f);
            //gl.glutWireCube(1.0f);
            glut.WireCube(1.0f);
            gl.glPopMatrix();

            gl.glPopMatrix();
            //gl.glutSwapBuffers();
        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            //gl.gluPerspective(65.0f, (GLfloat)w / (GLfloat)h, 1.0f, 20.0f);
            glu.Perspective(65.0f, (GLfloat)w / (GLfloat)h, 1.0f, 20.0f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
            gl.glTranslatef(0.0f, 0.0f, -5.0f);
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }

        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.W:
            shoulder = (shoulder + 5) % 360;
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.S:
            shoulder = (shoulder - 5) % 360;
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.D:
            elbow = (elbow + 5) % 360;
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.A:
            elbow = (elbow - 5) % 360;
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            default:
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.W, Keys.S, Keys.D, Keys.A];
        public override MouseButtons[] ValidButtons => [];

    }
}