
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
   *  dof.c
   *  This program demonstrates use of the accumulation buffer to
   *  create an out-of-focus depth-of-field effect.  The teapots
   *  are drawn several times into the accumulation buffer.  The
   *  viewing volume is jittered, except at the focal point, where
   *  the viewing volume is at the same position, each time.  In
   *  this case, the gold teapot remains in focus.
   */
    public unsafe class dof : _glGuide7code {

        public dof(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint teapotList;
        private static readonly GLfloat[] ambient = { 0.0f, 0.0f, 0.0f, 1.0f };
        private static readonly GLfloat[] diffuse = { 1.0f, 1.0f, 1.0f, 1.0f };
        private static readonly GLfloat[] specular = { 1.0f, 1.0f, 1.0f, 1.0f };
        private static readonly GLfloat[] position = { 0.0f, 3.0f, 3.0f, 0.0f };

        private static readonly GLfloat[] lmodel_ambient = { 0.2f, 0.2f, 0.2f, 1.0f };
        private static readonly GLfloat[] local_view = { 0.0f };
        public override void init(CSharpGL.GL gl) {
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_AMBIENT, ambient);
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_DIFFUSE, diffuse);
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_POSITION, position);

            gl.glLightModelfv(GL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);
            gl.glLightModelfv(GL.GL_LIGHT_MODEL_LOCAL_VIEWER, local_view);

            gl.glFrontFace(GL.GL_CW);
            gl.glEnable(GL.GL_LIGHTING);
            gl.glEnable(GL.GL_LIGHT0);
            gl.glEnable(GL.GL_AUTO_NORMAL);
            gl.glEnable(GL.GL_NORMALIZE);
            gl.glEnable(GL.GL_DEPTH_TEST);

            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glClearAccum(0.0f, 0.0f, 0.0f, 0.0f);
            /*  make teapot display list */
            teapotList = gl.glGenLists(1);
            gl.glNewList(teapotList, GL.GL_COMPILE);
            //gl.glutSolidTeapot(0.5f);
            glut.SolidTeapot(0.5f);
            gl.glEndList();
        }

        /*  display() draws 5 teapots into the accumulation buffer
     *  several times; each time with a jittered perspective.
     *  The focal point is at z = 5.0f, so the gold teapot will
     *  stay in focus.  The amount of jitter is adjusted by the
     *  magnitude of the accPerspective() jitter; in this example, 0.33f.
     *  In this example, the teapots are drawn 8 times.  See jitter.h
     */
        public override void display(CSharpGL.GL gl) {
            //int jitter;
            var viewport = stackalloc GLint[4];

            gl.glGetIntegerv(GL.GL_VIEWPORT, viewport);
            gl.glClear(GL.GL_ACCUM_BUFFER_BIT);

            for (var jitter = 0; jitter < 8; jitter++) {
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                accPerspective(45.0f,
                    (GLdouble)viewport[2] / (GLdouble)viewport[3],
                    1.0f, 15.0f, 0.0f, 0.0f,
                    0.33f * jitter_point.j8[jitter].x, 0.33f * jitter_point.j8[jitter].y, 5.0f);

                /*	ruby, gold, silver, emerald, and cyan teapots	*/
                renderTeapot(-1.1f, -0.5f, -4.5f, 0.1745f, 0.01175f,
                    0.01175f, 0.61424f, 0.04136f, 0.04136f,
                    0.727811f, 0.626959f, 0.626959f, 0.6f);
                renderTeapot(-0.5f, -0.5f, -5.0f, 0.24725f, 0.1995f,
                    0.0745f, 0.75164f, 0.60648f, 0.22648f,
                    0.628281f, 0.555802f, 0.366065f, 0.4f);
                renderTeapot(0.2f, -0.5f, -5.5f, 0.19225f, 0.19225f,
                    0.19225f, 0.50754f, 0.50754f, 0.50754f,
                    0.508273f, 0.508273f, 0.508273f, 0.4f);
                renderTeapot(1.0f, -0.5f, -6.0f, 0.0215f, 0.1745f, 0.0215f,
                    0.07568f, 0.61424f, 0.07568f, 0.633f,
                    0.727811f, 0.633f, 0.6f);
                renderTeapot(1.8f, -0.5f, -6.5f, 0.0f, 0.1f, 0.06f, 0.0f,
                    0.50980392f, 0.50980392f, 0.50196078f,
                    0.50196078f, 0.50196078f, 0.25f);
                gl.glAccum(GL.GL_ACCUM, 0.125f);
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

            GLdouble xwsize, ywsize;
            GLdouble dx, dy;
            var viewport = stackalloc GLint[4];

            gl.glGetIntegerv(GL.GL_VIEWPORT, viewport);

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
            gl.glTranslated(-eyedx, -eyedy, 0.0);
        }

        /*  accPerspective()
         *
         *  The first 4 arguments are identical to the gl.gluPerspective() call.
         *  pixdx and pixdy are anti-alias jitter in pixels.
         *  Set both equal to 0.0f for no anti-alias jitter.
         *  eyedx and eyedy are depth-of field jitter in pixels.
         *  Set both equal to 0.0f for no depth of field effects.
         *
         *  focus is distance from eye to plane in focus.
         *  focus must be greater than, but not equal to 0.0f.
         *
         *  Note that accPerspective() calls accFrustum().
         */
        void accPerspective(GLdouble fovy, GLdouble aspect,
            GLdouble near, GLdouble far, GLdouble pixdx, GLdouble pixdy,
            GLdouble eyedx, GLdouble eyedy, GLdouble focus) {
            var gl = GL.Current; if (gl == null) { return; }

            var fov2 = ((fovy * Math.PI) / 180.0f) / 2.0f;

            var top = near / (Math.Cos(fov2) / Math.Sin(fov2));
            var bottom = -top;

            var right = top * aspect;
            var left = -right;

            accFrustum(left, right, bottom, top, near, far,
                pixdx, pixdy, eyedx, eyedy, focus);
        }

        void renderTeapot(GLfloat x, GLfloat y, GLfloat z,
            GLfloat ambr, GLfloat ambg, GLfloat ambb,
            GLfloat difr, GLfloat difg, GLfloat difb,
            GLfloat specr, GLfloat specg, GLfloat specb, GLfloat shine) {
            var gl = GL.Current; if (gl == null) { return; }
            var mat = new GLfloat[4];

            gl.glPushMatrix();
            gl.glTranslatef(x, y, z);
            mat[0] = ambr; mat[1] = ambg; mat[2] = ambb; mat[3] = 1.0f;
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT, mat);
            mat[0] = difr; mat[1] = difg; mat[2] = difb;
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat);
            mat[0] = specr; mat[1] = specg; mat[2] = specb;
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, mat);
            gl.glMaterialf(GL.GL_FRONT, GL.GL_SHININESS, shine * 128.0f);
            gl.glCallList(teapotList);
            gl.glPopMatrix();
        }

    }
}