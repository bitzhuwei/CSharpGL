
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {
    /*  accanti.c
     *  Use the accumulation buffer to do full-scene antialiasing
     *  on a scene with orthographic parallel projection.
     */
    public unsafe class accanti : _glGuide7code {
        float rotAngle = 0.0f;

        public accanti(Form mainForm, int width, int height, GL gl)
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
            var viewport = stackalloc int[4];

            gl.glGetIntegerv(GL.GL_VIEWPORT, viewport);

            gl.glClear(GL.GL_ACCUM_BUFFER_BIT);
            for (var jitter = 0; jitter < ACSIZE; jitter++) {
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                gl.glPushMatrix();
                /*	Note that 4.5f is the distance in world space between
                 *	left and right and bottom and top.
                 *	This formula converts fractional pixel movement to
                 *	world coordinates.
                 */
                gl.glTranslatef(jitter_point.j8[jitter].x * 4.5f / viewport[2],
                    jitter_point.j8[jitter].y * 4.5f / viewport[3], 0.0f);
                displayObjects(gl);
                gl.glPopMatrix();
                gl.glAccum(GL.GL_ACCUM, 1.0f / ACSIZE);
            }
            gl.glAccum(GL.GL_RETURN, 1.0f);
            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            if (w <= h)
                gl.glOrtho(-2.25f, 2.25f, -2.25f * h / w, 2.25f * h / w, -10.0f, 10.0f);
            else
                gl.glOrtho(-2.25f * w / h, 2.25f * w / h, -2.25f, 2.25f, -10.0f, 10.0f);
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