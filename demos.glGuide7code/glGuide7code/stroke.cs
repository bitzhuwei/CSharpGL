
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
   *  stroke.c
   *  This program demonstrates some characters of a
   *  stroke (vector) font.  The characters are represented
   *  by display lists, which are given numbers which
   *  correspond to the ASCII values of the characters.
   *  Use of gl.glCallLists() is demonstrated.
   */
    public unsafe class stroke : _glGuide7code {

        public stroke(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int PT = 1;
        const int STROKE = 2;
        const int END = 3;
        struct CharPoint {
            public GLfloat x, y;
            public int type;

            public CharPoint(float x, float y, int type) {
                this.x = x;
                this.y = y;
                this.type = type;
            }
        }

        /*  Create a display list for each of 6 characters	*/
        public override void init(CSharpGL.GL gl) {
            GLuint base_;

            gl.glShadeModel(GL.GL_FLAT);

            base_ = gl.glGenLists(128);
            gl.glListBase(base_);
            gl.glNewList(base_ + 'A', GL.GL_COMPILE); drawLetter(Adata, gl); gl.glEndList();
            gl.glNewList(base_ + 'E', GL.GL_COMPILE); drawLetter(Edata, gl); gl.glEndList();
            gl.glNewList(base_ + 'P', GL.GL_COMPILE); drawLetter(Pdata, gl); gl.glEndList();
            gl.glNewList(base_ + 'R', GL.GL_COMPILE); drawLetter(Rdata, gl); gl.glEndList();
            gl.glNewList(base_ + 'S', GL.GL_COMPILE); drawLetter(Sdata, gl); gl.glEndList();
            gl.glNewList(base_ + ' ', GL.GL_COMPILE); gl.glTranslatef(8.0f, 0.0f, 0.0f); gl.glEndList();
        }
        string test1 = "A SPARE SERAPE APPEARS AS";
        string test2 = "APES PREPARE RARE PEPPERS";
        //static void printStrokedString(char* s) {
        //    GLsizei len = strlen(s);
        //    gl.glCallLists(len, GL.GL_BYTE, (GLbyte*)s);
        //}
        static void printStrokedString(string s, GL gl) {
            //gl.glPushAttrib(GL.GL_LIST_BIT);
            //gl.glListBase(fontOffset);
            //gl.glCallLists(strlen(s), GL.GL_UNSIGNED_BYTE, (GLubyte*)s);
            var lists = (byte*)Marshal.AllocHGlobal(s.Length);
            for (int i = 0; i < s.Length; i++) {
                lists[i] = (byte)s[i];
            }
            //gl.glCallLists(s.Length, GL.GL_UNSIGNED_BYTE, (GLubyte*)s);
            gl.glCallLists(s.Length, GL.GL_UNSIGNED_BYTE, (IntPtr)lists);
            //gl.glPopAttrib();
            Marshal.FreeHGlobal((IntPtr)lists);
        }
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glColor3f(1.0f, 1.0f, 1.0f);
            gl.glPushMatrix();
            gl.glScalef(2.0f, 2.0f, 2.0f);
            gl.glTranslatef(10.0f, 30.0f, 0.0f);
            printStrokedString(test1, gl);
            gl.glPopMatrix();
            gl.glPushMatrix();
            gl.glScalef(2.0f, 2.0f, 2.0f);
            gl.glTranslatef(10.0f, 13.0f, 0.0f);
            printStrokedString(test2, gl);
            gl.glPopMatrix();
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

        CharPoint[] Adata = {
   new(0, 0, PT), new(0, 9, PT), new(1, 10, PT), new(4, 10, PT),
   new(5, 9, PT), new(5, 0, STROKE), new(0, 5, PT), new(5, 5, END)
};

        CharPoint[] Edata = {
   new(5, 0, PT), new(0, 0, PT), new(0, 10, PT), new(5, 10, STROKE),
   new(0, 5, PT), new(4, 5, END)
};

        CharPoint[] Pdata = {
   new(0, 0, PT), new(0, 10, PT), new(4, 10, PT), new(5, 9, PT), new(5, 6, PT),
   new(4, 5, PT), new(0, 5, END)
};

        CharPoint[] Rdata = {
   new(0, 0, PT), new(0, 10, PT), new(4, 10, PT), new(5, 9, PT), new(5, 6, PT),
   new(4, 5, PT), new(0, 5, STROKE), new(3, 5, PT), new(5, 0, END)
};

        CharPoint[] Sdata = {
   new(0, 1, PT), new(1, 0, PT), new(4, 0, PT), new(5, 1, PT), new(5, 4, PT),
   new(4, 5, PT), new(1, 5, PT), new(0, 6, PT), new(0, 9, PT), new(1, 10, PT),
   new(4, 10, PT), new(5, 9, END)
};

        /*  drawLetter() interprets the instructions from the array
         *  for that letter and renders the letter with line segments.
         */
        static void drawLetter(CharPoint[] charPoints, GL gl) {
            gl.glBegin(GL.GL_LINE_STRIP);
            foreach (CharPoint p in charPoints) {
                switch (p.type) {
                case PT:
                //gl.glVertex2fv(&p.x);
                gl.glVertex2f(p.x, p.y);
                break;
                case STROKE:
                //gl.glVertex2fv(&p.x);
                gl.glVertex2f(p.x, p.y);
                gl.glEnd();
                gl.glBegin(GL.GL_LINE_STRIP);
                break;
                case END:
                //gl.glVertex2fv(&p.x);
                gl.glVertex2f(p.x, p.y);
                gl.glEnd();
                gl.glTranslatef(8.0f, 0.0f, 0.0f);
                return;
                }
            }
        }
    }
}