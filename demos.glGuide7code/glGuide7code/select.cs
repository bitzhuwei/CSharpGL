
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
   * select.c
   * This is an illustration of the selection mode and
   * name stack, which detects whether objects which collide
   * with a viewing volume.  First, four triangles and a
   * rectangular box representing a viewing volume are drawn
   * (drawScene routine).  The green triangle and yellow
   * triangles appear to lie within the viewing volume, but
   * the red triangle appears to lie outside it.  Then the
   * selection mode is entered (selectObjects routine).
   * Drawing to the screen ceases.  To see if any collisions
   * occur, the four triangles are called.  In this example,
   * the green triangle causes one hit with the name 1, and
   * the yellow triangles cause one hit with the name 3.f
   */
    public unsafe class select : _glGuide7code {

        public select(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        public override void init(CSharpGL.GL gl) {
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glShadeModel(GL.GL_FLAT);

            this.frmDump = new FormDump();
            this.frmDump.Show();
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            drawScene(gl);
            selectObjects(gl);
            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
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


        /* draw a triangle with vertices at (x1, y1), (x2, y2)
         * and (x3, y3) at z units away from the origin.
         */
        void drawTriangle(GLfloat x1, GLfloat y1, GLfloat x2,
            GLfloat y2, GLfloat x3, GLfloat y3, GLfloat z, CSharpGL.GL gl) {
            gl.glBegin(GL.GL_TRIANGLES);
            gl.glVertex3f(x1, y1, z);
            gl.glVertex3f(x2, y2, z);
            gl.glVertex3f(x3, y3, z);
            gl.glEnd();
        }

        /* draw a rectangular box with these outer x, y, and z values */
        void drawViewVolume(GLfloat x1, GLfloat x2, GLfloat y1,
            GLfloat y2, GLfloat z1, GLfloat z2, CSharpGL.GL gl) {
            gl.glColor3f(1.0f, 1.0f, 1.0f);
            gl.glBegin(GL.GL_LINE_LOOP);
            gl.glVertex3f(x1, y1, -z1);
            gl.glVertex3f(x2, y1, -z1);
            gl.glVertex3f(x2, y2, -z1);
            gl.glVertex3f(x1, y2, -z1);
            gl.glEnd();

            gl.glBegin(GL.GL_LINE_LOOP);
            gl.glVertex3f(x1, y1, -z2);
            gl.glVertex3f(x2, y1, -z2);
            gl.glVertex3f(x2, y2, -z2);
            gl.glVertex3f(x1, y2, -z2);
            gl.glEnd();

            gl.glBegin(GL.GL_LINES);    /*  4 lines	*/
            gl.glVertex3f(x1, y1, -z1);
            gl.glVertex3f(x1, y1, -z2);
            gl.glVertex3f(x1, y2, -z1);
            gl.glVertex3f(x1, y2, -z2);
            gl.glVertex3f(x2, y1, -z1);
            gl.glVertex3f(x2, y1, -z2);
            gl.glVertex3f(x2, y2, -z1);
            gl.glVertex3f(x2, y2, -z2);
            gl.glEnd();
        }

        /* drawScene draws 4 triangles and a wire frame
         * which represents the viewing volume.
         */
        void drawScene(CSharpGL.GL gl) {
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            //gl.gluPerspective(40.0f, 4.0f / 3.0f, 1.0f, 100.0f);
            glu.Perspective(40.0f, 4.0f / 3.0f, 1.0f, 100.0f);

            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
            //gl.gluLookAt(7.5f, 7.5f, 12.5f, 2.5f, 2.5f, -5.0f, 0.0f, 1.0f, 0.0f);
            glu.LookAt(7.5f, 7.5f, 12.5f, 2.5f, 2.5f, -5.0f, 0.0f, 1.0f, 0.0f);
            gl.glColor3f(0.0f, 1.0f, 0.0f); /*  green triangle	*/
            drawTriangle(2.0f, 2.0f, 3.0f, 2.0f, 2.5f, 3.0f, -5.0f, gl);
            gl.glColor3f(1.0f, 0.0f, 0.0f); /*  red triangle	*/
            drawTriangle(2.0f, 7.0f, 3.0f, 7.0f, 2.5f, 8.0f, -5.0f, gl);
            gl.glColor3f(1.0f, 1.0f, 0.0f); /*  yellow triangles	*/
            drawTriangle(2.0f, 2.0f, 3.0f, 2.0f, 2.5f, 3.0f, 0.0f, gl);
            drawTriangle(2.0f, 2.0f, 3.0f, 2.0f, 2.5f, 3.0f, -10.0f, gl);
            drawViewVolume(0.0f, 5.0f, 0.0f, 5.0f, 0.0f, 10.0f, gl);
        }

        /* processHits prints out the contents of the selection array
         */
        void processHits(GLint hits, GLuint* buffer) {
            if (this.frmDump == null) { return; }

            this.frmDump.ClearText();

            //printf("hits = %d\n", hits);
            this.frmDump.AppendLine($"hits = {hits}");
            //ptr = (GLuint*)buffer;
            var ptr = 0;
            for (var i = 0; i < hits; i++) {  /* for each hit  */
                //names = *ptr;
                var names = buffer[ptr];
                //printf(" number of names for hit = %d\n", names); ptr++;
                //printf("  z1 is %g;", (float)*ptr / 0x7fffffff); ptr++;
                //printf(" z2 is %g\n", (float)*ptr / 0x7fffffff); ptr++;
                //printf("   the name is ");
                this.frmDump.AppendLine($"number of names for hit = {names}"); ptr++;
                this.frmDump.Append($"  z1 is {(float)buffer[ptr] / 0x7fffffff};"); ptr++;
                this.frmDump.AppendLine($" z2 is {(float)buffer[ptr] / 0x7fffffff}"); ptr++;
                this.frmDump.Append($"   the name is ");
                for (var j = 0; j < names; j++) {  /* for each name */
                    //printf("%d ", *ptr); ptr++;
                    this.frmDump.Append($"{buffer[ptr]} "); ptr++;
                }
                this.frmDump.AppendLine("");
            }
        }
        /* selectObjects "draws" the triangles in selection mode,
         * assigning names for the triangles.  Note that the third
         * and fourth triangles share one name, so that if either
         * or both triangles intersects the viewing/clipping volume,
         * only one hit will be registered.
         */
        const int BUFSIZE = 512;
        private FormDump? frmDump;

        void selectObjects(CSharpGL.GL gl) {
            var selectBuf = stackalloc GLuint[BUFSIZE];
            GLint hits;

            gl.glSelectBuffer(BUFSIZE, selectBuf);
            gl.glRenderMode(GL.GL_SELECT);

            gl.glInitNames();
            gl.glPushName(0);

            gl.glPushMatrix();
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            gl.glOrtho(0.0f, 5.0f, 0.0f, 5.0f, 0.0f, 10.0f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
            gl.glLoadName(1);
            drawTriangle(2.0f, 2.0f, 3.0f, 2.0f, 2.5f, 3.0f, -5.0f, gl);
            gl.glLoadName(2);
            drawTriangle(2.0f, 7.0f, 3.0f, 7.0f, 2.5f, 8.0f, -5.0f, gl);
            gl.glLoadName(3);
            drawTriangle(2.0f, 2.0f, 3.0f, 2.0f, 2.5f, 3.0f, 0.0f, gl);
            drawTriangle(2.0f, 2.0f, 3.0f, 2.0f, 2.5f, 3.0f, -10.0f, gl);
            gl.glPopMatrix();
            gl.glFlush();

            hits = gl.glRenderMode(GL.GL_RENDER);
            processHits(hits, selectBuf);
        }
    }
}