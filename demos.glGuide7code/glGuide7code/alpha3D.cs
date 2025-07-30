
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {
    /*
     *  alpha3D.c
     *  This program demonstrates how to intermix opaque and
     *  alpha blended polygons in the same scene, by using
     *  gl.glDepthMask.  Press the 'a' key to animate moving the
     *  transparent object through the opaque object.  Press
     *  the 'r' key to reset the scene.
     */
    public unsafe class alpha3D : _glGuide7code {

        public alpha3D(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }
        const float MAXZ = 8.0f;
        const float MINZ = -8.0f;
        const float ZINC = 0.4f;

        static float solidZ = MAXZ;
        static float transparentZ = MINZ;
        static GLuint sphereList, cubeList;
        static readonly GLfloat[] mat_specular = { 1.0f, 1.0f, 1.0f, 0.15f };
        static readonly GLfloat[] mat_shininess = { 100.0f };
        static readonly GLfloat[] position = { 0.5f, 0.5f, 1.0f, 0.0f };

        public override void init(CSharpGL.GL gl) {

            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, mat_specular);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, mat_shininess);
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_POSITION, position);

            gl.glEnable(GL.GL_LIGHTING);
            gl.glEnable(GL.GL_LIGHT0);
            gl.glEnable(GL.GL_DEPTH_TEST);

            sphereList = gl.glGenLists(1);
            gl.glNewList(sphereList, GL.GL_COMPILE);
            //gl.glutSolidSphere(0.4f, 16, 16);
            glut.SolidSphere(0.4f, 16, 16);
            gl.glEndList();

            cubeList = gl.glGenLists(1);
            gl.glNewList(cubeList, GL.GL_COMPILE);
            //gl.glutSolidCube(0.6f);
            glut.SolidCube(0.6f);
            gl.glEndList();
        }

        private static readonly GLfloat[] mat_solid = { 0.75f, 0.75f, 0.0f, 1.0f };
        private static readonly GLfloat[] mat_zero = { 0.0f, 0.0f, 0.0f, 1.0f };
        private static readonly GLfloat[] mat_transparent = { 0.0f, 0.8f, 0.8f, 0.6f };
        private static readonly GLfloat[] mat_emission = { 0.0f, 0.3f, 0.3f, 0.6f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            gl.glPushMatrix();
            gl.glTranslatef(-0.15f, -0.15f, solidZ);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_EMISSION, mat_zero);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat_solid);
            gl.glCallList(sphereList);
            gl.glPopMatrix();

            gl.glPushMatrix();
            gl.glTranslatef(0.15f, 0.15f, transparentZ);
            gl.glRotatef(15.0f, 1.0f, 1.0f, 0.0f);
            gl.glRotatef(30.0f, 0.0f, 1.0f, 0.0f);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_EMISSION, mat_emission);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat_transparent);
            gl.glEnable(GL.GL_BLEND);
            //gl.glDepthMask(GL.GL_FALSE);
            gl.glDepthMask(false);
            gl.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE);
            gl.glCallList(cubeList);
            //gl.glDepthMask(GL.GL_TRUE);
            gl.glDepthMask(true);
            gl.glDisable(GL.GL_BLEND);
            gl.glPopMatrix();

            //gl.glutSwapBuffers();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLint)w, (GLint)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            if (w <= h)
                gl.glOrtho(-1.5f, 1.5f, -1.5f * (GLfloat)h / (GLfloat)w,
                    1.5f * (GLfloat)h / (GLfloat)w, -10.0f, 10.0f);
            else
                gl.glOrtho(-1.5f * (GLfloat)w / (GLfloat)h,
                    1.5f * (GLfloat)w / (GLfloat)h, -1.5f, 1.5f, -10.0f, 10.0f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
        }

        void animate(object? sender, EventArgs e) {
            if (solidZ <= MINZ || transparentZ >= MAXZ)
                glut.IdleFunc(null);
            else {
                solidZ -= ZINC;
                transparentZ += ZINC;
                //gl.glutPostRedisplay();
                this.mainForm.Invalidate();
            }
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }
        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.A:
            solidZ = MAXZ;
            transparentZ = MINZ;
            glut.IdleFunc(animate);
            break;
            case Keys.R:
            solidZ = MAXZ;
            transparentZ = MINZ;
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }

        }

        public override Keys[] ValidKeys => [Keys.A, Keys.R];
        public override MouseButtons[] ValidButtons => [];

    }
}