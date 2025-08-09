
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
    *  polyoff.c
    *  This program demonstrates polygon offset to draw a shaded
    *  polygon and its wireframe counterpart without ugly visual
    *  artifacts ("stitching").
    */
    public unsafe class polyoff : _glGuide7code {

        public polyoff(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint list;
        GLint spinx = 0;
        GLint spiny = 0;
        GLfloat tdist = 0.0f;
        GLfloat polyfactor = 1.0f;
        GLfloat polyunits = 1.0f;


        GLfloat[] light_ambient = { 0.0f, 0.0f, 0.0f, 1.0f };
        GLfloat[] light_diffuse = { 1.0f, 1.0f, 1.0f, 1.0f };
        GLfloat[] light_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
        GLfloat[] light_position = { 1.0f, 1.0f, 1.0f, 0.0f };
        GLfloat[] global_ambient = { 0.2f, 0.2f, 0.2f, 1.0f };
        /*  specify initial properties
              *  create display list with sphere
              *  initialize lighting and depth buffer
              */
        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            list = gl.glGenLists(1);
            gl.glNewList(list, GL.GL_COMPILE);
            //gl.glutSolidSphere(1.0f, 20, 12);
            glut.SolidSphere(1.0f, 20, 12);
            gl.glEndList();

            gl.glEnable(GL.GL_DEPTH_TEST);

            gl.glLightfv(GL.GL_LIGHT0, GL.GL_AMBIENT, light_ambient);
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_DIFFUSE, light_diffuse);
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_SPECULAR, light_specular);
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_POSITION, light_position);
            gl.glLightModelfv(GL.GL_LIGHT_MODEL_AMBIENT, global_ambient);

            this.frmDump = new FormDump();
            this.frmDump.Show();
        }

        GLfloat[] mat_ambient = { 0.8f, 0.8f, 0.8f, 1.0f };
        GLfloat[] mat_diffuse = { 1.0f, 0.0f, 0.5f, 1.0f };
        GLfloat[] mat_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
        GLfloat[] gray = { 0.8f, 0.8f, 0.8f, 1.0f };
        GLfloat[] black = { 0.0f, 0.0f, 0.0f, 1.0f };
        private FormDump? frmDump;

        /*  display() draws two spheres, one with a gray, diffuse material,
*  the other sphere with a magenta material with a specular highlight.
*/
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glPushMatrix();
            gl.glTranslatef(0.0f, 0.0f, tdist);
            gl.glRotatef((GLfloat)spinx, 1.0f, 0.0f, 0.0f);
            gl.glRotatef((GLfloat)spiny, 0.0f, 1.0f, 0.0f);

            fixed (GLfloat* p = gray) {
                gl.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT_AND_DIFFUSE, p);
            }
            fixed (GLfloat* p = black) {
                gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, p);
            }
            gl.glMaterialf(GL.GL_FRONT, GL.GL_SHININESS, 0.0f);
            gl.glEnable(GL.GL_LIGHTING);
            gl.glEnable(GL.GL_LIGHT0);
            gl.glEnable(GL.GL_POLYGON_OFFSET_FILL);
            gl.glPolygonOffset(polyfactor, polyunits);
            gl.glCallList(list);
            gl.glDisable(GL.GL_POLYGON_OFFSET_FILL);

            gl.glDisable(GL.GL_LIGHTING);
            gl.glDisable(GL.GL_LIGHT0);
            gl.glColor3f(1.0f, 1.0f, 1.0f);
            gl.glPolygonMode(GL.GL_FRONT_AND_BACK, GL.GL_LINE);
            gl.glCallList(list);
            gl.glPolygonMode(GL.GL_FRONT_AND_BACK, GL.GL_FILL);

            gl.glPopMatrix();
            gl.glFlush();

        }

        /*  call when window is resized  */
        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            //gl.gluPerspective(45.0f, (GLdouble)width / (GLdouble)height, 1.0f, 10.0f);
            glu.Perspective(45.0f, (float)width / (float)height, 1.0f, 10.0f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
            //gl.gluLookAt(0.0f, 0.0f, 5.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
            glu.LookAt(0.0f, 0.0f, 5.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
        }

        /*  call when mouse button is pressed  */
        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
            switch (button) {
            case MouseButtons.Left:
            spinx = (spinx + 5) % 360;
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case MouseButtons.Right:
            spiny = (spiny + 5) % 360;
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            default:
            break;
            }
        }

        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            if (this.frmDump == null) { return; }

            switch (key) {
            case Keys.W:
            if (tdist < 4.0f) {
                tdist = (tdist + 0.5f);
                //gl.glutPostRedisplay();
                this.mainForm.Invalidate();
            }
            break;
            case Keys.S:
            if (tdist > -5.0f) {
                tdist = (tdist - 0.5f);
                //gl.glutPostRedisplay();
                this.mainForm.Invalidate();
            }
            break;
            case Keys.D:
            polyfactor = polyfactor + 0.1f;
            //printf("polyfactor is %f\n", polyfactor);
            this.frmDump.AppendLine($"polyfactor is {polyfactor}");
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.A:
            polyfactor = polyfactor - 0.1f;
            //printf("polyfactor is %f\n", polyfactor);
            this.frmDump.AppendLine($"polyfactor is {polyfactor}");
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.E:
            polyunits = polyunits + 1.0f;
            //printf("polyunits is %f\n", polyunits);
            this.frmDump.AppendLine($"polyfactor is {polyfactor}");
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.Q:
            polyunits = polyunits - 1.0f;
            //printf("polyunits is %f\n", polyunits);
            this.frmDump.AppendLine($"polyfactor is {polyfactor}");
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            default:
            break;
            }

        }


        public override Keys[] ValidKeys => [Keys.W, Keys.S, Keys.D, Keys.A, Keys.E, Keys.Q];
        public override MouseButtons[] ValidButtons => [MouseButtons.Left, MouseButtons.Right];

    }
}