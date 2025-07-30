
using CSharpGL;

namespace demos.glGuide7code {

    /*
  * picksquare.c
  * Use of multiple names and picking are demonstrated.
  * A 3x3 grid of squares is drawn.  When the left mouse
  * button is pressed, all squares under the cursor position
  * have their color changed.
  */
    public unsafe class picksquare : _glGuide7code {

        public picksquare(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        int[][] board = new int[3][];//[3][3];   /*  amount of color for each square	*/
        private FormDump? frmDump;

        /*  Clear color value for every square on the board   */
        public override void init(CSharpGL.GL gl) {
            for (var i = 0; i < 3; i++) {
                board[i] = new int[3];
                for (var j = 0; j < 3; j++) {
                    board[i][j] = 0;
                }
            }

            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            this.frmDump = new FormDump();
            this.frmDump.Show();
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            drawSquares(GL.GL_RENDER);
            gl.glFlush();
        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, w, h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            //gl.gluOrtho2D(0.0f, 3.0f, 0.0f, 3.0f);
            glu.Ortho2D(0.0f, 3.0f, 0.0f, 3.0f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
            pickSquares(button, state, x, y);
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

        /*  The nine squares are drawn.  In selection mode, each
       *  square is given two names:  one for the row and the
       *  other for the column on the grid.  The color of each
       *  square is determined by its position on the grid, and
       *  the value in the board[][] array.
       */
        void drawSquares(GLenum mode) {
            var gl = GL.Current; if (gl == null) return;

            for (var i = 0; i < 3; i++) {
                if (mode == GL.GL_SELECT)
                    gl.glLoadName((uint)i);
                for (var j = 0; j < 3; j++) {
                    if (mode == GL.GL_SELECT)
                        gl.glPushName((uint)j);
                    gl.glColor3f((GLfloat)i / 3.0f, (GLfloat)j / 3.0f,
                        (GLfloat)board[i][j] / 3.0f);
                    gl.glRecti(i, j, i + 1, j + 1);
                    if (mode == GL.GL_SELECT)
                        gl.glPopName();
                }
            }
        }

        /*  processHits prints out the contents of the
         *  selection array.
         */
        void processHits(GLint hits, GLuint* buffer) {
            if (this.frmDump == null) { return; }
            this.frmDump.ClearText();
            GLuint ii = 0, jj = 0;

            //printf("hits = %d\n", hits);
            this.frmDump.AppendLine($"hits = {hits}");
            //ptr = (GLuint*)buffer;
            var ptr = 0;
            for (var i = 0; i < hits; i++) {    /*  for each hit  */
                var names = buffer[ptr];
                //printf(" number of names for this hit = %d\n", names); ptr++;
                //printf("  z1 is %g;", (float)*ptr / 0x7fffffff); ptr++;
                //printf(" z2 is %g\n", (float)*ptr / 0x7fffffff); ptr++;
                //printf("   names are ");
                this.frmDump.AppendLine($" number of names for this hit = {names}"); ptr++;
                this.frmDump.Append($"  z1 is {(float)buffer[ptr] / 0x7fffffff};"); ptr++;
                this.frmDump.AppendLine($" z2 is {(float)buffer[ptr] / 0x7fffffff}"); ptr++;
                this.frmDump.AppendLine($"   names are ");
                for (var j = 0; j < names; j++) { /*  for each name */
                    //printf("%d ", *ptr);
                    this.frmDump.Append($"{buffer[ptr]} ");
                    /*  set row and column  */
                    if (j == 0) { ii = buffer[ptr]; }
                    else if (j == 1) { jj = buffer[ptr]; }
                    ptr++;
                }
                //printf("\n");
                this.frmDump.AppendLine("");
                board[ii][jj] = (board[ii][jj] + 1) % 3;
            }
        }

        /*  pickSquares() sets up selection mode, name stack,
         *  and projection matrix for picking.  Then the
         *  objects are drawn.
         */
        const int BUFSIZE = 512;

        void pickSquares(MouseButtons button, MouseState state, int x, int y) {
            var gl = GL.Current; if (gl == null) return;

            var selectBuf = stackalloc GLuint[BUFSIZE];
            GLint hits;
            var viewport = stackalloc GLint[4];

            if (button != MouseButtons.Left || state != MouseState.Down) return;

            gl.glGetIntegerv(GL.GL_VIEWPORT, viewport);

            gl.glSelectBuffer(BUFSIZE, selectBuf);
            gl.glRenderMode(GL.GL_SELECT);

            gl.glInitNames();
            gl.glPushName(0);

            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glPushMatrix();
            gl.glLoadIdentity();
            /*  create 5x5 pixel picking region near cursor location	*/
            //gl.gluPickMatrix((GLdouble)x, (GLdouble)(viewport[3] - y), 5.0f, 5.0f, viewport);
            glu.PickMatrix((GLdouble)x, (GLdouble)(viewport[3] - y), 5.0f, 5.0f, viewport);
            //gl.gluOrtho2D(0.0f, 3.0f, 0.0f, 3.0f);
            glu.Ortho2D(0.0f, 3.0f, 0.0f, 3.0f);
            drawSquares(GL.GL_SELECT);

            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glPopMatrix();
            gl.glFlush();

            hits = gl.glRenderMode(GL.GL_RENDER);
            processHits(hits, selectBuf);
            //gl.glutPostRedisplay();
            this.mainForm.Invalidate();
        }
    }
}