
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
  *  unproject.c
  *  When the left mouse button is pressed, this program
  *  reads the mouse position and determines two 3D points
  *  from which it was transformed.  Very little is displayed.
  */
    public unsafe class unproject : _glGuide7code {
        private FormDump? frmDump;

        public unproject(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        public override void init(CSharpGL.GL gl) {
            this.frmDump = new FormDump();
            this.frmDump.Show();
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glFlush();
        }

        /* Change these values for a different transformation  */
        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            //gl.gluPerspective(45.0f, (GLfloat)w / (GLfloat)h, 1.0f, 100.0f);
            glu.Perspective(45.0f, (GLfloat)w / (GLfloat)h, 1.0f, 100.0f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
            if (this.frmDump == null) { return; }

            var gl = GL.Current; if (gl == null) { return; }

            var viewport = stackalloc GLint[4];
            var mvmatrix = stackalloc GLdouble[16];
            var projmatrix = stackalloc GLdouble[16];
            GLint realy;  /*  OpenGL y coordinate position  */
            GLdouble wx, wy, wz;  /*  returned world x, y, z coords  */

            switch (button) {
            case MouseButtons.Left:
            if (state == MouseState.Down) {
                gl.glGetIntegerv(GL.GL_VIEWPORT, viewport);
                gl.glGetDoublev(GL.GL_MODELVIEW_MATRIX, mvmatrix);
                gl.glGetDoublev(GL.GL_PROJECTION_MATRIX, projmatrix);
                /*  note viewport[3] is height of window in pixels  */
                realy = viewport[3] - (GLint)y - 1;
                //printf("Coordinates at cursor are (%4d, %4d)\n", x, realy);
                this.frmDump.AppendLine($"Coordinate at cursor is ({x}, {realy})");
                //gl.gluUnProject((GLdouble)x, (GLdouble)realy, 0.0f,
                //mvmatrix, projmatrix, viewport, &wx, &wy, &wz);
                glu.UnProject((GLdouble)x, (GLdouble)realy, 0.0f,
                    mvmatrix, projmatrix, viewport, out wx, out wy, out wz);
                //printf("World coords at z=0.0f are (%f, %f, %f)\n", wx, wy, wz);
                this.frmDump.AppendLine($"World coord at z=0.0f is ({wx}, {wy}, {wz})");
                //gl.gluUnProject((GLdouble)x, (GLdouble)realy, 1.0f,
                //mvmatrix, projmatrix, viewport, &wx, &wy, &wz);
                glu.UnProject((GLdouble)x, (GLdouble)realy, 1.0f,
                    mvmatrix, projmatrix, viewport, out wx, out wy, out wz);
                //printf("World coords at z=1.0f are (%f, %f, %f)\n", wx, wy, wz);
                this.frmDump.AppendLine($"World coord at z=1.0f is ({wx}, {wy}, {wz})");
            }
            break;
            default:
            break;
            }
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
        public override MouseButtons[] ValidButtons => [MouseButtons.Left];

    }
}