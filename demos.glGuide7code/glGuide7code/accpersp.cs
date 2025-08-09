
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {
    /*  accpersp.c
     *  Use the accumulation buffer to do full-scene antialiasing
     *  on a scene with perspective projection, using the special
     *  routines accFrustum() and accPerspective().
     */
    public unsafe class accpersp : _glGuide7code {

        public accpersp(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        /*  Initialize lighting and other values.
         */
        public override void init(CSharpGL.GL gl) {
            var mat_ambient = stackalloc GLfloat[] { 1.0f, 1.0f, 1.0f, 1.0f };
            var mat_specular = stackalloc GLfloat[] { 1.0f, 1.0f, 1.0f, 1.0f };
            var light_position = new GLfloat[] { 0.0f, 0.0f, 10.0f, 1.0f };
            var lm_ambient = new GLfloat[] { 0.2f, 0.2f, 0.2f, 1.0f };

            gl.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT, mat_ambient);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, mat_specular);
            gl.glMaterialf(GL.GL_FRONT, GL.GL_SHININESS, 50.0f);
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_POSITION, light_position);
            gl.glLightModelfv(GL.GL_LIGHT_MODEL_AMBIENT, lm_ambient);

            gl.glEnable(GL.GL_LIGHTING);
            gl.glEnable(GL.GL_LIGHT0);
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glShadeModel(GL.GL_FLAT);

            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glClearAccum(0.0f, 0.0f, 0.0f, 0.0f);
        }

        void displayObjects(GL gl) {
            var torus_diffuse = stackalloc GLfloat[] { 0.7f, 0.7f, 0.0f, 1.0f };
            var cube_diffuse = stackalloc GLfloat[] { 0.0f, 0.7f, 0.7f, 1.0f };
            var sphere_diffuse = stackalloc GLfloat[] { 0.7f, 0.0f, 0.7f, 1.0f };
            var octa_diffuse = stackalloc GLfloat[] { 0.7f, 0.4f, 0.4f, 1.0f };

            gl.glPushMatrix();
            gl.glTranslatef(0.0f, 0.0f, -5.0f);
            gl.glRotatef(30.0f, 1.0f, 0.0f, 0.0f);

            gl.glPushMatrix();
            gl.glTranslatef(-0.80f, 0.35f, 0.0f);
            gl.glRotatef(100.0f, 1.0f, 0.0f, 0.0f);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, torus_diffuse);
            //gl.glutSolidTorus(0.275f, 0.85f, 16, 16);
            glut.SolidTorus(0.275f, 0.85f, 16, 16);
            gl.glPopMatrix();

            gl.glPushMatrix();
            gl.glTranslatef(-0.75f, -0.50f, 0.0f);
            gl.glRotatef(45.0f, 0.0f, 0.0f, 1.0f);
            gl.glRotatef(45.0f, 1.0f, 0.0f, 0.0f);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, cube_diffuse);
            //gl.glutSolidCube(1.5f);
            glut.SolidCube(1.5f);
            gl.glPopMatrix();

            gl.glPushMatrix();
            gl.glTranslatef(0.75f, 0.60f, 0.0f);
            gl.glRotatef(30.0f, 1.0f, 0.0f, 0.0f);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, sphere_diffuse);
            //gl.glutSolidSphere(1.0f, 16, 16);
            glut.SolidSphere(1.0f, 16, 16);
            gl.glPopMatrix();

            gl.glPushMatrix();
            gl.glTranslatef(0.70f, -0.90f, 0.25f);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, octa_diffuse);
            //gl.glutSolidOctahedron();
            glut.SolidOctahedron();
            gl.glPopMatrix();

            gl.glPopMatrix();
        }

        const int ACSIZE = 8;

        public override void display(CSharpGL.GL gl) {
            var viewport = stackalloc GLint[4];

            gl.glGetIntegerv(GL.GL_VIEWPORT, viewport);

            gl.glClear(GL.GL_ACCUM_BUFFER_BIT);
            for (var jitter = 0; jitter < ACSIZE; jitter++) {
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                accPerspective(50.0f,
                    (GLdouble)viewport[2] / (GLdouble)viewport[3],
                    1.0f, 15.0f, jitter_point.j8[jitter].x, jitter_point.j8[jitter].y, 0.0f, 0.0f, 1.0f);
                displayObjects(gl);
                gl.glAccum(GL.GL_ACCUM, 1.0f / ACSIZE);
            }
            gl.glAccum(GL.GL_RETURN, 1.0f);
            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
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

        /* accFrustum()
           * The first 6 arguments are identical to the gl.glFrustum() call.
           *
           * pixdx and pixdy are anti-alias jitter in pixels.
           * Set both equal to 0.0f for no anti-alias jitter.
           * eyedx and eyedy are depth-of field jitter in pixels.
           * Set both equal to 0.0f for no depth of field effects.
           *
           * focus is distance from eye to plane in focus.
           * focus must be greater than, but not equal to 0.0f.
           *
           * Note that accFrustum() calls gl.glTranslatef().  You will
           * probably want to insure that your ModelView matrix has been
           * initialized to identity before calling accFrustum().
           */
        void accFrustum(GLdouble left, GLdouble right, GLdouble bottom,
            GLdouble top, GLdouble near, GLdouble far, GLdouble pixdx,
            GLdouble pixdy, GLdouble eyedx, GLdouble eyedy, GLdouble focus) {
            var gl = GL.Current; if (gl == null) { return; }

            var viewport = stackalloc GLint[4];
            gl.glGetIntegerv(GL.GL_VIEWPORT, viewport);

            GLdouble xwsize, ywsize;
            GLdouble dx, dy;
            xwsize = right - left;
            ywsize = top - bottom;

            dx = -(pixdx * xwsize / (GLdouble)viewport[2] + eyedx * near / focus);
            dy = -(pixdy * ywsize / (GLdouble)viewport[3] + eyedy * near / focus);

            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            gl.glFrustum(left + dx, right + dx, bottom + dy, top + dy, near, far);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
            //gl.glTranslatef(-eyedx, -eyedy, 0.0f);
            gl.glTranslated(-eyedx, -eyedy, 0.0f);
        }

        /* accPerspective()
         *
         * The first 4 arguments are identical to the gl.gluPerspective() call.
         * pixdx and pixdy are anti-alias jitter in pixels.
         * Set both equal to 0.0f for no anti-alias jitter.
         * eyedx and eyedy are depth-of field jitter in pixels.
         * Set both equal to 0.0f for no depth of field effects.
         *
         * focus is distance from eye to plane in focus.
         * focus must be greater than, but not equal to 0.0f.
         *
         * Note that accPerspective() calls accFrustum().
         */
        void accPerspective(GLdouble fovy, GLdouble aspect,
            GLdouble near, GLdouble far, GLdouble pixdx, GLdouble pixdy,
            GLdouble eyedx, GLdouble eyedy, GLdouble focus) {
            GLdouble fov2, left, right, bottom, top;

            fov2 = ((fovy * Math.PI) / 180.0f) / 2.0f;

            top = near / (Math.Cos(fov2) / Math.Sin(fov2));
            bottom = -top;

            right = top * aspect;
            left = -right;

            accFrustum(left, right, bottom, top, near, far,
                pixdx, pixdy, eyedx, eyedy, focus);
        }

    }
}