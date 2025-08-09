
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
  *  fog.c
  *  This program draws 5 red spheres, each at a different
  *  z distance from the eye, in different types of fog.
  *  Pressing the f key chooses between 3 types of
  *  fog:  exponential, exponential squared, and linear.
  *  In this program, there is a fixed density value, as well
  *  as fixed start and end values for the linear fog.
  */
    public unsafe class fog : _glGuide7code {

        public fog(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        /*  Initialize depth buffer, fog, light source,
     *  material property, and lighting model.
     */
        private GLuint fogMode = GL.GL_EXP;
        private FormDump? frmDump;
        private static readonly GLfloat[] position = { 0.5f, 0.5f, 3.0f, 0.0f };
        private static readonly GLfloat[] fogColor = { 0.5f, 0.5f, 0.5f, 1.0f };
        /*  Initialize depth buffer, fog, light source,
   *  material property, and lighting model.
   */
        public override void init(CSharpGL.GL gl) {

            gl.glEnable(GL.GL_DEPTH_TEST);

            gl.glLightfv(GL.GL_LIGHT0, GL.GL_POSITION, position);
            gl.glEnable(GL.GL_LIGHTING);
            gl.glEnable(GL.GL_LIGHT0);
            {
                var mat = stackalloc GLfloat[] { 0.1745f, 0.01175f, 0.01175f };
                gl.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT, mat);
                mat[0] = 0.61424f; mat[1] = 0.04136f; mat[2] = 0.04136f;
                gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat);
                mat[0] = 0.727811f; mat[1] = 0.626959f; mat[2] = 0.626959f;
                gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, mat);
                gl.glMaterialf(GL.GL_FRONT, GL.GL_SHININESS, 0.6f * 128.0f);
            }

            gl.glEnable(GL.GL_FOG);
            {

                gl.glFogi(GL.GL_FOG_MODE, (GLint)fogMode);
                gl.glFogfv(GL.GL_FOG_COLOR, fogColor);
                gl.glFogf(GL.GL_FOG_DENSITY, 0.35f);
                gl.glHint(GL.GL_FOG_HINT, GL.GL_DONT_CARE);
                gl.glFogf(GL.GL_FOG_START, 1.0f);
                gl.glFogf(GL.GL_FOG_END, 5.0f);
            }
            gl.glClearColor(0.5f, 0.5f, 0.5f, 1.0f);  /* fog color */

            this.frmDump = new FormDump();
            this.frmDump.Show();
        }

        /* display() draws 5 spheres at different z positions.
      */
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            renderSphere(-2.0f, -0.5f, -1.0f);
            renderSphere(-1.0f, -0.5f, -2.0f);
            renderSphere(0.0f, -0.5f, -3.0f);
            renderSphere(1.0f, -0.5f, -4.0f);
            renderSphere(2.0f, -0.5f, -5.0f);
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
            if (this.frmDump == null) { return; }

            switch (key) {
            case Keys.F:
            if (fogMode == GL.GL_EXP) {
                fogMode = GL.GL_EXP2;
                //printf("Fog mode is GL.GL_EXP2\n");
                this.frmDump.AppendLine("Fog mode is GL.GL_EXP2");
            }
            else if (fogMode == GL.GL_EXP2) {
                fogMode = GL.GL_LINEAR;
                //printf("Fog mode is GL.GL_LINEAR\n");
                this.frmDump.AppendLine("Fog mode is GL.GL_LINEAR");
            }
            else if (fogMode == GL.GL_LINEAR) {
                fogMode = GL.GL_EXP;
                //printf("Fog mode is GL.GL_EXP\n");
                this.frmDump.AppendLine("Fog mode is GL.GL_EXP");
            }
            gl.glFogi(GL.GL_FOG_MODE, (GLint)fogMode);
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


        public override Keys[] ValidKeys => [Keys.F];
        public override MouseButtons[] ValidButtons => [];


        static void renderSphere(GLfloat x, GLfloat y, GLfloat z) {
            var gl = GL.Current; if (gl == null) { return; }

            gl.glPushMatrix();
            gl.glTranslatef(x, y, z);
            //gl.glutSolidSphere(0.4f, 16, 16);
            glut.SolidSphere(0.4f, 16, 16);
            gl.glPopMatrix();
        }
    }
}