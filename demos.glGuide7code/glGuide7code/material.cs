
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
   * material.c
   * This program demonstrates the use of the GL lighting model.
   * Several objects are drawn using different material characteristics.
   * A single light source illuminates the objects.
   */
    public unsafe class material : _glGuide7code {

        public material(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLfloat[] ambient = { 0.0f, 0.0f, 0.0f, 1.0f };
        GLfloat[] diffuse = { 1.0f, 1.0f, 1.0f, 1.0f };
        GLfloat[] specular = { 1.0f, 1.0f, 1.0f, 1.0f };
        GLfloat[] position = { 0.0f, 3.0f, 2.0f, 0.0f };
        GLfloat[] lmodel_ambient = { 0.4f, 0.4f, 0.4f, 1.0f };
        GLfloat[] local_view = { 0.0f };
        /*  Initialize z-buffer, projection matrix, light source,
         *  and lighting model.  Do not specify a material property here.
         */
        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.1f, 0.1f, 0.0f);
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glShadeModel(GL.GL_SMOOTH);

            gl.glLightfv(GL.GL_LIGHT0, GL.GL_AMBIENT, ambient);
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_DIFFUSE, diffuse);
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_POSITION, position);
            gl.glLightModelfv(GL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);
            gl.glLightModelfv(GL.GL_LIGHT_MODEL_LOCAL_VIEWER, local_view);

            gl.glEnable(GL.GL_LIGHTING);
            gl.glEnable(GL.GL_LIGHT0);
        }

        GLfloat[] no_mat = { 0.0f, 0.0f, 0.0f, 1.0f };
        GLfloat[] mat_ambient = { 0.7f, 0.7f, 0.7f, 1.0f };
        GLfloat[] mat_ambient_color = { 0.8f, 0.8f, 0.2f, 1.0f };
        GLfloat[] mat_diffuse = { 0.1f, 0.5f, 0.8f, 1.0f };
        GLfloat[] mat_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
        GLfloat[] no_shininess = { 0.0f };
        GLfloat[] low_shininess = { 5.0f };
        GLfloat[] high_shininess = { 100.0f };
        GLfloat[] mat_emission = { 0.3f, 0.2f, 0.2f, 0.0f };
        /*  Draw twelve spheres in 3 rows with 4 columns.
         *  The spheres in the first row have materials with no ambient reflection.
         *  The second row has materials with significant ambient reflection.
         *  The third row has materials with colored ambient reflection.
         *
         *  The first column has materials with blue, diffuse reflection only.
         *  The second column has blue diffuse reflection, as well as specular
         *  reflection with a low shininess exponent.
         *  The third column has blue diffuse reflection, as well as specular
         *  reflection with a high shininess exponent (a more concentrated highlight).
         *  The fourth column has materials which also include an emissive component.
         *
         *  gl.glTranslatef() is used to move spheres to their appropriate locations.
         */
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            /*  draw sphere in first row, first column
             *  diffuse reflection only; no ambient or specular
             */
            gl.glPushMatrix();
            gl.glTranslatef(-3.75f, 3.0f, 0.0f);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT, no_mat);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat_diffuse);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, no_mat);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, no_shininess);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_EMISSION, no_mat);
            //gl.glutSolidSphere(1.0f, 16, 16);
            glut.SolidSphere(1.0f, 16, 16);
            gl.glPopMatrix();

            /*  draw sphere in first row, second column
             *  diffuse and specular reflection; low shininess; no ambient
             */
            gl.glPushMatrix();
            gl.glTranslatef(-1.25f, 3.0f, 0.0f);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT, no_mat);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat_diffuse);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, mat_specular);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, low_shininess);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_EMISSION, no_mat);
            //gl.glutSolidSphere(1.0f, 16, 16);
            glut.SolidSphere(1.0f, 16, 16);
            gl.glPopMatrix();

            /*  draw sphere in first row, third column
             *  diffuse and specular reflection; high shininess; no ambient
             */
            gl.glPushMatrix();
            gl.glTranslatef(1.25f, 3.0f, 0.0f);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT, no_mat);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat_diffuse);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, mat_specular);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, high_shininess);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_EMISSION, no_mat);
            //gl.glutSolidSphere(1.0f, 16, 16);
            glut.SolidSphere(1.0f, 16, 16);
            gl.glPopMatrix();

            /*  draw sphere in first row, fourth column
             *  diffuse reflection; emission; no ambient or specular reflection
             */
            gl.glPushMatrix();
            gl.glTranslatef(3.75f, 3.0f, 0.0f);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT, no_mat);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat_diffuse);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, no_mat);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, no_shininess);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_EMISSION, mat_emission);
            //gl.glutSolidSphere(1.0f, 16, 16);
            glut.SolidSphere(1.0f, 16, 16);
            gl.glPopMatrix();

            /*  draw sphere in second row, first column
             *  ambient and diffuse reflection; no specular
             */
            gl.glPushMatrix();
            gl.glTranslatef(-3.75f, 0.0f, 0.0f);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT, mat_ambient);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat_diffuse);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, no_mat);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, no_shininess);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_EMISSION, no_mat);
            //gl.glutSolidSphere(1.0f, 16, 16);
            glut.SolidSphere(1.0f, 16, 16);
            gl.glPopMatrix();

            /*  draw sphere in second row, second column
             *  ambient, diffuse and specular reflection; low shininess
             */
            gl.glPushMatrix();
            gl.glTranslatef(-1.25f, 0.0f, 0.0f);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT, mat_ambient);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat_diffuse);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, mat_specular);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, low_shininess);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_EMISSION, no_mat);
            //gl.glutSolidSphere(1.0f, 16, 16);
            glut.SolidSphere(1.0f, 16, 16);
            gl.glPopMatrix();

            /*  draw sphere in second row, third column
             *  ambient, diffuse and specular reflection; high shininess
             */
            gl.glPushMatrix();
            gl.glTranslatef(1.25f, 0.0f, 0.0f);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT, mat_ambient);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat_diffuse);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, mat_specular);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, high_shininess);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_EMISSION, no_mat);
            //gl.glutSolidSphere(1.0f, 16, 16);
            glut.SolidSphere(1.0f, 16, 16);
            gl.glPopMatrix();

            /*  draw sphere in second row, fourth column
             *  ambient and diffuse reflection; emission; no specular
             */
            gl.glPushMatrix();
            gl.glTranslatef(3.75f, 0.0f, 0.0f);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT, mat_ambient);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat_diffuse);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, no_mat);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, no_shininess);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_EMISSION, mat_emission);
            //gl.glutSolidSphere(1.0f, 16, 16);
            glut.SolidSphere(1.0f, 16, 16);
            gl.glPopMatrix();

            /*  draw sphere in third row, first column
             *  colored ambient and diffuse reflection; no specular
             */
            gl.glPushMatrix();
            gl.glTranslatef(-3.75f, -3.0f, 0.0f);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT, mat_ambient_color);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat_diffuse);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, no_mat);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, no_shininess);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_EMISSION, no_mat);
            //gl.glutSolidSphere(1.0f, 16, 16);
            glut.SolidSphere(1.0f, 16, 16);
            gl.glPopMatrix();

            /*  draw sphere in third row, second column
             *  colored ambient, diffuse and specular reflection; low shininess
             */
            gl.glPushMatrix();
            gl.glTranslatef(-1.25f, -3.0f, 0.0f);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT, mat_ambient_color);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat_diffuse);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, mat_specular);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, low_shininess);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_EMISSION, no_mat);
            //gl.glutSolidSphere(1.0f, 16, 16);
            glut.SolidSphere(1.0f, 16, 16);
            gl.glPopMatrix();

            /*  draw sphere in third row, third column
             *  colored ambient, diffuse and specular reflection; high shininess
             */
            gl.glPushMatrix();
            gl.glTranslatef(1.25f, -3.0f, 0.0f);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT, mat_ambient_color);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat_diffuse);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, mat_specular);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, high_shininess);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_EMISSION, no_mat);
            //gl.glutSolidSphere(1.0f, 16, 16);
            glut.SolidSphere(1.0f, 16, 16);
            gl.glPopMatrix();

            /*  draw sphere in third row, fourth column
             *  colored ambient and diffuse reflection; emission; no specular
             */
            gl.glPushMatrix();
            gl.glTranslatef(3.75f, -3.0f, 0.0f);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT, mat_ambient_color);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat_diffuse);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, no_mat);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, no_shininess);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_EMISSION, mat_emission);
            //gl.glutSolidSphere(1.0f, 16, 16);
            glut.SolidSphere(1.0f, 16, 16);
            gl.glPopMatrix();

            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, w, h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            if (w <= (h * 2))
                gl.glOrtho(-6.0f, 6.0f, -3.0f * ((GLfloat)h * 2) / (GLfloat)w,
                    3.0f * ((GLfloat)h * 2) / (GLfloat)w, -10.0f, 10.0f);
            else
                gl.glOrtho(-6.0f * (GLfloat)w / ((GLfloat)h * 2),
                    6.0f * (GLfloat)w / ((GLfloat)h * 2), -3.0f, 3.0f, -10.0f, 10.0f);
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