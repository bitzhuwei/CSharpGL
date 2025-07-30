
using CSharpGL;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
    *  varray.c
    *  This program demonstrates vertex arrays.
    */
    public unsafe class varray : _glGuide7code {

        public varray(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glShadeModel(GL.GL_SMOOTH);
            setupPointers(gl);
        }

        static GLuint[] indices = { 0, 1, 3, 4 };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            if (derefMethod == DRAWARRAY)
                gl.glDrawArrays(GL.GL_TRIANGLES, 0, 6);
            else if (derefMethod == ARRAYELEMENT) {
                gl.glBegin(GL.GL_TRIANGLES);
                gl.glArrayElement(2);
                gl.glArrayElement(3);
                gl.glArrayElement(5);
                gl.glEnd();
            }
            else if (derefMethod == DRAWELEMENTS) {
                fixed (GLuint* p = indices) {
                    gl.glDrawElements(GL.GL_POLYGON, 4, GL.GL_UNSIGNED_INT, (IntPtr)p);
                }
            }
            gl.glFlush();
        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            //gl.gluOrtho2D(0.0f, (GLdouble)w, 0.0f, (GLdouble)h);
            glu.Ortho2D(0.0f, w, 0.0f, h);
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
            var gl = GL.Current; if (gl == null) { return; }

            switch (button) {
            case MouseButtons.Left:
            if (state == MouseState.Down) {
                if (setupMethod == POINTER) {
                    setupMethod = INTERLEAVED;
                    setupInterleave(gl);
                }
                else if (setupMethod == INTERLEAVED) {
                    setupMethod = POINTER;
                    setupPointers(gl);
                }
                //gl.glutPostRedisplay();
                this.mainForm.Invalidate();
            }
            break;
            case MouseButtons.Right:
            if (state == MouseState.Down) {
                if (derefMethod == DRAWARRAY)
                    derefMethod = ARRAYELEMENT;
                else if (derefMethod == ARRAYELEMENT)
                    derefMethod = DRAWELEMENTS;
                else if (derefMethod == DRAWELEMENTS)
                    derefMethod = DRAWARRAY;
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
        public override MouseButtons[] ValidButtons => [MouseButtons.Left, MouseButtons.Right];

        const int POINTER = 1;
        const int INTERLEAVED = 2;

        const int DRAWARRAY = 1;
        const int ARRAYELEMENT = 2;
        const int DRAWELEMENTS = 3;

        int setupMethod = POINTER;
        int derefMethod = DRAWARRAY;

        static GLint[] vertices = { 25, 25,
                        100, 325,
                        175, 25,
                        175, 325,
                        250, 25,
                        325, 325 };
        static GLfloat[] colors = { 1.0f, 0.2f, 0.2f,
                        0.2f, 0.2f, 1.0f,
                        0.8f, 1.0f, 0.2f,
                        0.75f, 0.75f, 0.75f,
                        0.35f, 0.35f, 0.35f,
                        0.5f, 0.5f, 0.5f };
        static void setupPointers(GL gl) {
            gl.glEnableClientState(GL.GL_VERTEX_ARRAY);
            gl.glEnableClientState(GL.GL_COLOR_ARRAY);

            fixed (GLint* p = vertices) {
                gl.glVertexPointer(2, GL.GL_INT, 0, (IntPtr)p);
            }
            fixed (GLfloat* p = colors) {
                gl.glColorPointer(3, GL.GL_FLOAT, 0, (IntPtr)p);
            }
        }

        static GLfloat[] intertwined =
        { 1.0f, 0.2f, 1.0f, 100.0f, 100.0f, 0.0f,
     1.0f, 0.2f, 0.2f, 0.0f, 200.0f, 0.0f,
     1.0f, 1.0f, 0.2f, 100.0f, 300.0f, 0.0f,
     0.2f, 1.0f, 0.2f, 200.0f, 300.0f, 0.0f,
     0.2f, 1.0f, 1.0f, 300.0f, 200.0f, 0.0f,
     0.2f, 0.2f, 1.0f, 200.0f, 100.0f, 0.0f };
        static void setupInterleave(GL gl) {
            fixed (GLfloat* p = intertwined) {
                gl.glInterleavedArrays(GL.GL_C3F_V3F, 0, (IntPtr)p);
            }
        }
    }
}