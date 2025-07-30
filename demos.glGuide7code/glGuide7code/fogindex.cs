
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
   *  fogindex.c
   *  This program draws 5 wireframe spheres, each at
   *  a different z distance from the eye, in linear fog.
   */
    public unsafe class fogindex : _glGuide7code {

        public fogindex(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        /*  Initialize color map and fog.  Set screen clear color
       *  to end of color ramp.
       */
        const int NUMCOLORS = 32;
        const int RAMPSTART = 16;
        public override void init(CSharpGL.GL gl) {
            int i;

            gl.glEnable(GL.GL_DEPTH_TEST);

            for (i = 0; i < NUMCOLORS; i++) {
                GLfloat shade;
                shade = (GLfloat)(NUMCOLORS - i) / (GLfloat)NUMCOLORS;
                //gl.glutSetColor(RAMPSTART + i, shade, shade, shade);
                //glut.SetColor(RAMPSTART + i, shade, shade, shade);
            }
            gl.glEnable(GL.GL_FOG);

            gl.glFogi(GL.GL_FOG_MODE, (GLint)GL.GL_LINEAR);
            gl.glFogi(GL.GL_FOG_INDEX, NUMCOLORS);
            gl.glFogf(GL.GL_FOG_START, 1.0f);
            gl.glFogf(GL.GL_FOG_END, 6.0f);
            gl.glHint(GL.GL_FOG_HINT, GL.GL_NICEST);
            gl.glClearIndex((GLfloat)(NUMCOLORS + RAMPSTART - 1));
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glIndexi(RAMPSTART);

            renderSphere(-2.0f, -0.5f, -1.0f);
            renderSphere(-1.0f, -0.5f, -2.0f);
            renderSphere(0.0f, -0.5f, -3.0f);
            renderSphere(1.0f, -0.5f, -4.0f);
            renderSphere(2.0f, -0.5f, -5.0f);

            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, w, h);
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
            switch (key) {
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }

        }


        public override Keys[] ValidKeys => [];
        public override MouseButtons[] ValidButtons => [];


        static void renderSphere(GLfloat x, GLfloat y, GLfloat z) {
            var gl = GL.Current; if (gl == null) { return; }

            gl.glPushMatrix();
            gl.glTranslatef(x, y, z);
            //gl.glutWireSphere(0.4f, 16, 16);
            glut.WireSphere(0.4f, 16, 16);
            gl.glPopMatrix();
        }
    }
}