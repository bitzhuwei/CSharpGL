
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*  bezmesh.c
    *  This program renders a lighted, filled Bezier surface,
    *  using two-dimensional evaluators.
    */
    public unsafe class bezmesh : _glGuide7code {

        public bezmesh(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }
        private static readonly GLfloat[] ctrlpoints = {//[4][4][3]
            -1.5f, -1.5f, 4.0f,
            -0.5f, -1.5f, 2.0f,
             0.5f, -1.5f, -1.0f,
             1.5f, -1.5f, 2.0f,
            -1.5f, -0.5f, 1.0f,
            -0.5f, -0.5f, 3.0f,
             0.5f, -0.5f, 0.0f,
             1.5f, -0.5f, -1.0f,
            -1.5f, 0.5f, 4.0f,
            -0.5f, 0.5f, 0.0f,
             0.5f, 0.5f, 3.0f,
             1.5f, 0.5f, 4.0f,
            -1.5f, 1.5f, -2.0f,
            -0.5f, 1.5f, -2.0f,
             0.5f, 1.5f, 0.0f,
             1.5f, 1.5f, -1.0f
        };


        private static readonly GLfloat[] ambient = { 0.2f, 0.2f, 0.2f, 1.0f };
        private static readonly GLfloat[] position = { 0.0f, 0.0f, 2.0f, 1.0f };
        private static readonly GLfloat[] mat_diffuse = { 0.6f, 0.6f, 0.6f, 1.0f };
        private static readonly GLfloat[] mat_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
        private static readonly GLfloat[] mat_shininess = { 50.0f };
        void initlights(GL gl) {
            gl.glEnable(GL.GL_LIGHTING);
            gl.glEnable(GL.GL_LIGHT0);

            gl.glLightfv(GL.GL_LIGHT0, GL.GL_AMBIENT, ambient);
            gl.glLightfv(GL.GL_LIGHT0, GL.GL_POSITION, position);

            gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat_diffuse);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, mat_specular);
            gl.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, mat_shininess);
        }
        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glEnable(GL.GL_DEPTH_TEST);
            fixed (float* p = ctrlpoints) {
                gl.glMap2f(GL.GL_MAP2_VERTEX_3, 0, 1, 3, 4, 0, 1, 12, 4, p);
            }
            gl.glEnable(GL.GL_MAP2_VERTEX_3);
            gl.glEnable(GL.GL_AUTO_NORMAL);
            gl.glMapGrid2f(20, 0.0f, 1.0f, 20, 0.0f, 1.0f);
            initlights(gl);       /* for lighted version only */
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glPushMatrix();
            gl.glRotatef(85.0f, 1.0f, 1.0f, 1.0f);
            gl.glEvalMesh2(GL.GL_FILL, 0, 20, 0, 20);
            gl.glPopMatrix();
            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            if (w <= h)
                gl.glOrtho(-4.0f, 4.0f, -4.0f * (GLfloat)h / (GLfloat)w,
                    4.0f * (GLfloat)h / (GLfloat)w, -4.0f, 4.0f);
            else
                gl.glOrtho(-4.0f * (GLfloat)w / (GLfloat)h,
                    4.0f * (GLfloat)w / (GLfloat)h, -4.0f, 4.0f, -4.0f, 4.0f);
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