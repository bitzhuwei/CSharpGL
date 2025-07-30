
using CSharpGL;
using System.CodeDom;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
  * pickdepth.c
  * Picking is demonstrated in this program.  In
  * rendering mode, three overlapping rectangles are
  * drawn.  When the left mouse button is pressed,
  * selection mode is entered with the picking matrix.
  * Rectangles which are drawn under the cursor position
  * are "picked."  Pay special attention to the depth
  * value range, which is returned.
  */
    public unsafe class pickdepth : _glGuide7code {
        private FormDump? frmDump;

        public pickdepth(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glShadeModel(GL.GL_FLAT);
            gl.glDepthRange(0.0f, 1.0f);  /* The default z mapping */

            this.frmDump = new FormDump();
            this.frmDump.Show();
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            drawRects(GL.GL_RENDER, gl);
            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            gl.glOrtho(0.0f, 8.0f, 0.0f, 8.0f, -0.5f, 2.5f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
            var gl = GL.Current; if (gl == null) { return; }

            pickRects(button, state, x, y, gl);
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


        /* The three rectangles are drawn.  In selection mode,
         * each rectangle is given the same name.  Note that
         * each rectangle is drawn with a different z value.
         */
        void drawRects(GLenum mode, CSharpGL.GL gl) {
            if (mode == GL.GL_SELECT)
                gl.glLoadName(1);
            gl.glBegin(GL.GL_QUADS);
            gl.glColor3f(1.0f, 1.0f, 0.0f);
            gl.glVertex3i(2, 0, 0);
            gl.glVertex3i(2, 6, 0);
            gl.glVertex3i(6, 6, 0);
            gl.glVertex3i(6, 0, 0);
            gl.glEnd();
            if (mode == GL.GL_SELECT)
                gl.glLoadName(2);
            gl.glBegin(GL.GL_QUADS);
            gl.glColor3f(0.0f, 1.0f, 1.0f);
            gl.glVertex3i(3, 2, -1);
            gl.glVertex3i(3, 8, -1);
            gl.glVertex3i(8, 8, -1);
            gl.glVertex3i(8, 2, -1);
            gl.glEnd();
            if (mode == GL.GL_SELECT)
                gl.glLoadName(3);
            gl.glBegin(GL.GL_QUADS);
            gl.glColor3f(1.0f, 0.0f, 1.0f);
            gl.glVertex3i(0, 2, -2);
            gl.glVertex3i(0, 7, -2);
            gl.glVertex3i(5, 7, -2);
            gl.glVertex3i(5, 2, -2);
            gl.glEnd();
        }

        /*  processHits() prints out the contents of the
         *  selection array.
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

        /*  pickRects() sets up selection mode, name stack,
         *  and projection matrix for picking.  Then the objects
         *  are drawn.
         */
        const int BUFSIZE = 512;

        void pickRects(MouseButtons button, MouseState state, int x, int y, CSharpGL.GL gl) {
            if (button != MouseButtons.Left || state != MouseState.Down) return;

            var selectBuf = stackalloc GLuint[BUFSIZE];
            GLint hits;
            var viewport = stackalloc GLint[4];

            gl.glGetIntegerv(GL.GL_VIEWPORT, viewport);

            gl.glSelectBuffer(BUFSIZE, selectBuf);
            gl.glRenderMode(GL.GL_SELECT);

            gl.glInitNames();
            gl.glPushName(0);

            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glPushMatrix();
            gl.glLoadIdentity();
            /*  create 5x5 pixel picking region near cursor location */
            //gl.gluPickMatrix((GLdouble)x, (GLdouble)(viewport[3] - y), 5.0f, 5.0f, viewport);
            glu.PickMatrix((GLdouble)x, (GLdouble)(viewport[3] - y), 5.0f, 5.0f, viewport);
            gl.glOrtho(0.0f, 8.0f, 0.0f, 8.0f, -0.5f, 2.5f);
            drawRects(GL.GL_SELECT, gl);
            gl.glPopMatrix();
            gl.glFlush();

            hits = gl.glRenderMode(GL.GL_RENDER);
            processHits(hits, selectBuf);
        }
    }
}