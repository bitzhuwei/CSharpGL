
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {
    /*
     *  aapoly.c
     *  This program draws filled polygons with antialiased
     *  edges.  The special GL.GL_SRC_ALPHA_SATURATE blending
     *  function is used.
     *  Pressing the 't' key turns the antialiasing on and off.
     */


    public unsafe class aapoly : _glGuide7code {
        GLboolean polySmooth = true;// GL.GL_TRUE;
        const int NFACE = 6;
        const int NVERT = 8;

        public aapoly(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        public override void init(CSharpGL.GL gl) {
            gl.glCullFace(GL.GL_BACK);
            gl.glEnable(GL.GL_CULL_FACE);
            gl.glBlendFunc(GL.GL_SRC_ALPHA_SATURATE, GL.GL_ONE);
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }
        static GLfloat[] v = new float[8 * 3];
        static GLfloat[] c = new float[8 * 4]  {
            0.0f, 0.0f, 0.0f, 1.0f,
            1.0f, 0.0f, 0.0f, 1.0f,
            0.0f, 1.0f, 0.0f, 1.0f,
            1.0f, 1.0f, 0.0f, 1.0f,
            0.0f, 0.0f, 1.0f, 1.0f,
            1.0f, 0.0f, 1.0f, 1.0f,
            0.0f, 1.0f, 1.0f, 1.0f,
            1.0f, 1.0f, 1.0f, 1.0f
        };

        /*  indices of front, top, left, bottom, right, back faces  */
        static GLubyte[] indices = new GLubyte[/*NFACE][*4*/]{
            4, 5, 6, 7,
            2, 3, 7, 6,
            0, 4, 7, 3,
            0, 1, 5, 4,
            1, 5, 6, 2,
            0, 3, 2, 1
        };
        void drawCube(GL gl, GLfloat x0, GLfloat x1, GLfloat y0, GLfloat y1,
            GLfloat z0, GLfloat z1) {
            v[0 * 3 + 0] = v[3 * 3 + 0] = v[4 * 3 + 0] = v[7 * 3 + 0] = x0;
            v[1 * 3 + 0] = v[2 * 3 + 0] = v[5 * 3 + 0] = v[6 * 3 + 0] = x1;
            v[0 * 3 + 1] = v[1 * 3 + 1] = v[4 * 3 + 1] = v[5 * 3 + 1] = y0;
            v[2 * 3 + 1] = v[3 * 3 + 1] = v[6 * 3 + 1] = v[7 * 3 + 1] = y1;
            v[0 * 3 + 2] = v[1 * 3 + 2] = v[2 * 3 + 2] = v[3 * 3 + 2] = z0;
            v[4 * 3 + 2] = v[5 * 3 + 2] = v[6 * 3 + 2] = v[7 * 3 + 2] = z1;

            //# ifdef GL.GL_VERSION_1_1
            gl.glEnableClientState(GL.GL_VERTEX_ARRAY);
            gl.glEnableClientState(GL.GL_COLOR_ARRAY);
            fixed (GLfloat* p = v) {
                var ptr = (IntPtr)p;
                gl.glVertexPointer(3, GL.GL_FLOAT, 0, ptr);
            }
            fixed (GLfloat* p = c) {
                var ptr = (IntPtr)p;
                gl.glColorPointer(4, GL.GL_FLOAT, 0, ptr);
            }
            fixed (GLubyte* p = indices) {
                var ptr = (IntPtr)p;
                gl.glDrawElements(GL.GL_QUADS, NFACE * 4, GL.GL_UNSIGNED_BYTE, ptr);
            }
            gl.glDisableClientState(GL.GL_VERTEX_ARRAY);
            gl.glDisableClientState(GL.GL_COLOR_ARRAY);
            //#else
            //printf("If this is GL Version 1.0f, ");
            //printf("vertex arrays are not supported.\n");
            //exit(1);
            //#endif
        }

        /*  Note:  polygons must be drawn from front to back
         *  for proper blending.
         */
        public override void display(CSharpGL.GL gl) {
            if (polySmooth) {
                gl.glClear(GL.GL_COLOR_BUFFER_BIT);
                gl.glEnable(GL.GL_BLEND);
                gl.glEnable(GL.GL_POLYGON_SMOOTH);
                gl.glDisable(GL.GL_DEPTH_TEST);
            }
            else {
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                gl.glDisable(GL.GL_BLEND);
                gl.glDisable(GL.GL_POLYGON_SMOOTH);
                gl.glEnable(GL.GL_DEPTH_TEST);
            }

            gl.glPushMatrix();
            gl.glTranslatef(0.0f, 0.0f, -8.0f);
            gl.glRotatef(30.0f, 1.0f, 0.0f, 0.0f);
            gl.glRotatef(60.0f, 0.0f, 1.0f, 0.0f);
            drawCube(gl, -0.5f, 0.5f, -0.5f, 0.5f, -0.5f, 0.5f);
            gl.glPopMatrix();

            gl.glFlush();
        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            //gl.gluPerspective(30.0f, (GLfloat)w / (GLfloat)h, 1.0f, 20.0f);
            glu.Perspective(30.0f, (GLfloat)w / (GLfloat)h, 1.0f, 20.0f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }
        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.T:
            polySmooth = !polySmooth;
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
            break;
            case Keys.Escape:// 27:
                             //exit(0);  /*  Escape key  */
            this.mainForm.Close();
            break;
            default:
            break;
            }
        }

        public override Keys[] ValidKeys => [Keys.T];
        public override MouseButtons[] ValidButtons => [];

    }
}