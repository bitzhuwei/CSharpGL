
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
   *  light.c
   *  This program demonstrates the use of the OpenGL lighting
   *  model.  A sphere is drawn using a grey material characteristic.
   *  A single light source illuminates the object.
   */
    public unsafe class light : _glGuide7code {

        public light(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLfloat[] light_position = { 1.0f, 1.0f, 1.0f, 0.0f };
        /*  Initialize material property, light source, lighting model,
      *  and depth buffer.
      */
        public override void init(CSharpGL.GL gl) {

            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glShadeModel(GL.GL_SMOOTH);

            var mat_specular = stackalloc GLfloat[] { 1.0f, 1.0f, 1.0f, 1.0f };
            var mat_shininess = stackalloc GLfloat[] { 50.0f };
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, mat_specular);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, mat_shininess);
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_POSITION, light_position);

            gl.glEnable(GL.GL_LIGHTING);
            gl.glEnable(GL.GL_LIGHT0);
            gl.glEnable(GL.GL_DEPTH_TEST);
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