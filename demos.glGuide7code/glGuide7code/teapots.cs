
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
   *  teapots.c
   *  This program demonstrates lots of material properties.
   *  A single light source illuminates the objects.
   */
    public unsafe class teapots : _glGuide7code {

        public teapots(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint teapotList;
        GLfloat[] ambient = { 0.0f, 0.0f, 0.0f, 1.0f };
        GLfloat[] diffuse = { 1.0f, 1.0f, 1.0f, 1.0f };
        GLfloat[] specular = { 1.0f, 1.0f, 1.0f, 1.0f };
        GLfloat[] position = { 0.0f, 3.0f, 3.0f, 0.0f };

        GLfloat[] lmodel_ambient = { 0.2f, 0.2f, 0.2f, 1.0f };
        GLfloat[] local_view = { 0.0f };
        /*
        * Initialize depth buffer, projection matrix, light source, and lighting
        * model.  Do not specify a material property here.
        */
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
            /*  be efficient--make teapot display list  */
            teapotList = gl.glGenLists(1);
            gl.glNewList(teapotList, GL.GL_COMPILE);
            //gl.glutSolidTeapot(1.0f);
            glut.SolidTeapot(1.0f);
            gl.glEndList();
        }

        /**
    *  First column:  emerald, jade, obsidian, pearl, ruby, turquoise
    *  2nd column:  brass, bronze, chrome, copper, gold, silver
    *  3rd column:  black, cyan, green, red, white, yellow plastic
    *  4th column:  black, cyan, green, red, white, yellow rubber
    */
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            renderTeapot(2.0f, 17.0f, 0.0215f, 0.1745f, 0.0215f,
                0.07568f, 0.61424f, 0.07568f, 0.633f, 0.727811f, 0.633f, 0.6f);
            renderTeapot(2.0f, 14.0f, 0.135f, 0.2225f, 0.1575f,
                0.54f, 0.89f, 0.63f, 0.316228f, 0.316228f, 0.316228f, 0.1f);
            renderTeapot(2.0f, 11.0f, 0.05375f, 0.05f, 0.06625f,
                0.18275f, 0.17f, 0.22525f, 0.332741f, 0.328634f, 0.346435f, 0.3f);
            renderTeapot(2.0f, 8.0f, 0.25f, 0.20725f, 0.20725f,
                1, 0.829f, 0.829f, 0.296648f, 0.296648f, 0.296648f, 0.088f);
            renderTeapot(2.0f, 5.0f, 0.1745f, 0.01175f, 0.01175f,
                0.61424f, 0.04136f, 0.04136f, 0.727811f, 0.626959f, 0.626959f, 0.6f);
            renderTeapot(2.0f, 2.0f, 0.1f, 0.18725f, 0.1745f,
                0.396f, 0.74151f, 0.69102f, 0.297254f, 0.30829f, 0.306678f, 0.1f);
            renderTeapot(6.0f, 17.0f, 0.329412f, 0.223529f, 0.027451f,
                0.780392f, 0.568627f, 0.113725f, 0.992157f, 0.941176f, 0.807843f,
                0.21794872f);
            renderTeapot(6.0f, 14.0f, 0.2125f, 0.1275f, 0.054f,
                0.714f, 0.4284f, 0.18144f, 0.393548f, 0.271906f, 0.166721f, 0.2f);
            renderTeapot(6.0f, 11.0f, 0.25f, 0.25f, 0.25f,
                0.4f, 0.4f, 0.4f, 0.774597f, 0.774597f, 0.774597f, 0.6f);
            renderTeapot(6.0f, 8.0f, 0.19125f, 0.0735f, 0.0225f,
                0.7038f, 0.27048f, 0.0828f, 0.256777f, 0.137622f, 0.086014f, 0.1f);
            renderTeapot(6.0f, 5.0f, 0.24725f, 0.1995f, 0.0745f,
                0.75164f, 0.60648f, 0.22648f, 0.628281f, 0.555802f, 0.366065f, 0.4f);
            renderTeapot(6.0f, 2.0f, 0.19225f, 0.19225f, 0.19225f,
                0.50754f, 0.50754f, 0.50754f, 0.508273f, 0.508273f, 0.508273f, 0.4f);
            renderTeapot(10.0f, 17.0f, 0.0f, 0.0f, 0.0f, 0.01f, 0.01f, 0.01f,
                0.50f, 0.50f, 0.50f, 0.25f);
            renderTeapot(10.0f, 14.0f, 0.0f, 0.1f, 0.06f, 0.0f, 0.50980392f, 0.50980392f,
                0.50196078f, 0.50196078f, 0.50196078f, 0.25f);
            renderTeapot(10.0f, 11.0f, 0.0f, 0.0f, 0.0f,
                0.1f, 0.35f, 0.1f, 0.45f, 0.55f, 0.45f, 0.25f);
            renderTeapot(10.0f, 8.0f, 0.0f, 0.0f, 0.0f, 0.5f, 0.0f, 0.0f,
                0.7f, 0.6f, 0.6f, 0.25f);
            renderTeapot(10.0f, 5.0f, 0.0f, 0.0f, 0.0f, 0.55f, 0.55f, 0.55f,
                0.70f, 0.70f, 0.70f, 0.25f);
            renderTeapot(10.0f, 2.0f, 0.0f, 0.0f, 0.0f, 0.5f, 0.5f, 0.0f,
                0.60f, 0.60f, 0.50f, 0.25f);
            renderTeapot(14.0f, 17.0f, 0.02f, 0.02f, 0.02f, 0.01f, 0.01f, 0.01f,
                0.4f, 0.4f, 0.4f, 0.078125f);
            renderTeapot(14.0f, 14.0f, 0.0f, 0.05f, 0.05f, 0.4f, 0.5f, 0.5f,
                0.04f, 0.7f, 0.7f, 0.078125f);
            renderTeapot(14.0f, 11.0f, 0.0f, 0.05f, 0.0f, 0.4f, 0.5f, 0.4f,
                0.04f, 0.7f, 0.04f, 0.078125f);
            renderTeapot(14.0f, 8.0f, 0.05f, 0.0f, 0.0f, 0.5f, 0.4f, 0.4f,
                0.7f, 0.04f, 0.04f, 0.078125f);
            renderTeapot(14.0f, 5.0f, 0.05f, 0.05f, 0.05f, 0.5f, 0.5f, 0.5f,
                0.7f, 0.7f, 0.7f, 0.078125f);
            renderTeapot(14.0f, 2.0f, 0.05f, 0.05f, 0.0f, 0.5f, 0.5f, 0.4f,
                0.7f, 0.7f, 0.04f, 0.078125f);
            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            if (w <= h)
                gl.glOrtho(0.0f, 16.0f, 0.0f, 16.0f * (GLfloat)h / (GLfloat)w,
                    -10.0f, 10.0f);
            else
                gl.glOrtho(0.0f, 16.0f * (GLfloat)w / (GLfloat)h, 0.0f, 16.0f,
                    -10.0f, 10.0f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
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


        /*
         * Move object into position.  Use 3rd through 12th
         * parameters to specify the material property.  Draw a teapot.
         */
        void renderTeapot(GLfloat x, GLfloat y,
            GLfloat ambr, GLfloat ambg, GLfloat ambb,
            GLfloat difr, GLfloat difg, GLfloat difb,
            GLfloat specr, GLfloat specg, GLfloat specb, GLfloat shine) {
            var gl = GL.Current; if (gl == null) return;

            var mat = new GLfloat[4];

            gl.glPushMatrix();
            gl.glTranslatef(x, y, 0.0f);
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