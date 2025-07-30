
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
   *  colormat.c
   *  After initialization, the program will be in
   *  ColorMaterial mode.  Interaction:  pressing the
   *  mouse buttons will change the diffuse reflection values.
   */
    public unsafe class colormat : _glGuide7code {

        public colormat(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        static readonly GLfloat[] diffuseMaterial = { 0.5f, 0.5f, 0.5f, 1.0f };
        static readonly GLfloat[] mat_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
        static readonly GLfloat[] light_position = { 1.0f, 1.0f, 1.0f, 0.0f };
        /*  Initialize material property, light source, lighting model,
      *  and depth buffer.
      */
        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glShadeModel(GL.GL_SMOOTH);
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, diffuseMaterial);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, mat_specular);
            gl.glMaterialf(GL.GL_FRONT, GL.GL_SHININESS, 25.0f);
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_POSITION, light_position);
            gl.glEnable(GL.GL_LIGHTING);
            gl.glEnable(GL.GL_LIGHT0);

            gl.glColorMaterial(GL.GL_FRONT, GL.GL_DIFFUSE);
            gl.glEnable(GL.GL_COLOR_MATERIAL);
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            //gl.glutSolidSphere(1.0f, 20, 16);
            glut.SolidSphere(1.0f, 20, 16);
            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
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


        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
            var gl = GL.Current; if (gl == null) { return; }

            switch (button) {
            case MouseButtons.Left:
            if (state == MouseState.Down) {
                diffuseMaterial[0] += 0.1f;
                if (diffuseMaterial[0] > 1.0f)
                    diffuseMaterial[0] = 0.0f;
                gl.glColor4fv(diffuseMaterial);
                //gl.glutPostRedisplay();
                this.mainForm.Invalidate();
            }
            break;
            case MouseButtons.Middle:
            if (state == MouseState.Down) {
                diffuseMaterial[1] += 0.1f;
                if (diffuseMaterial[1] > 1.0f)
                    diffuseMaterial[1] = 0.0f;
                gl.glColor4fv(diffuseMaterial);
                //gl.glutPostRedisplay();
                this.mainForm.Invalidate();
            }
            break;
            case MouseButtons.Right:
            if (state == MouseState.Down) {
                diffuseMaterial[2] += 0.1f;
                if (diffuseMaterial[2] > 1.0f)
                    diffuseMaterial[2] = 0.0f;
                gl.glColor4fv(diffuseMaterial);
                //gl.glutPostRedisplay();
                this.mainForm.Invalidate();
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
        public override MouseButtons[] ValidButtons => [MouseButtons.Left, MouseButtons.Middle, MouseButtons.Right];

    }
}