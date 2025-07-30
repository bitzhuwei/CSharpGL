
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
    * feedback.c
    * This program demonstrates use of OpenGL feedback.  First,
    * a lighting environment is set up and a few lines are drawn.
    * Then feedback mode is entered, and the same lines are
    * drawn.  The results in the feedback buffer are printed.
    */
    public unsafe class feedback : _glGuide7code {
        private FormDump? frmDump;

        public feedback(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        /*  Initialize lighting.
    */
        public override void init(CSharpGL.GL gl) {
            gl.glEnable(GL.GL_LIGHTING);
            gl.glEnable(GL.GL_LIGHT0);

            this.frmDump = new FormDump();
            this.frmDump.Show();
        }

        GLfloat[] feedBuffer = new GLfloat[1024];
        public override void display(CSharpGL.GL gl) {

            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            gl.glOrtho(0.0f, 100.0f, 0.0f, 100.0f, 0.0f, 1.0f);

            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            drawGeometry(GL.GL_RENDER);

            var GL_3D_COLOR = 0x0602;// 0x0003;//0x1C03;
            gl.glFeedbackBuffer(1024, (GLenum)GL_3D_COLOR, feedBuffer);
            gl.glRenderMode(GL.GL_FEEDBACK);
            drawGeometry(GL.GL_FEEDBACK);

            GLint size = gl.glRenderMode(GL.GL_RENDER);
            printBuffer(size, feedBuffer);
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


        /* Draw a few lines and two points, one of which will
         * be clipped.  If in feedback mode, a passthrough token
         * is issued between the each primitive.
         */
        void drawGeometry(GLenum mode) {
            var gl = GL.Current; if (gl == null) { return; }

            gl.glBegin(GL.GL_LINE_STRIP);
            gl.glNormal3f(0.0f, 0.0f, 1.0f);
            gl.glVertex3f(30.0f, 30.0f, 0.0f);
            gl.glVertex3f(50.0f, 60.0f, 0.0f);
            gl.glVertex3f(70.0f, 40.0f, 0.0f);
            gl.glEnd();
            if (mode == GL.GL_FEEDBACK)
                gl.glPassThrough(1.0f);
            gl.glBegin(GL.GL_POINTS);
            gl.glVertex3f(-100.0f, -100.0f, -100.0f);  /*  will be clipped  */
            gl.glEnd();
            if (mode == GL.GL_FEEDBACK)
                gl.glPassThrough(2.0f);
            gl.glBegin(GL.GL_POINTS);
            gl.glNormal3f(0.0f, 0.0f, 1.0f);
            gl.glVertex3f(50.0f, 50.0f, 0.0f);
            gl.glEnd();
        }

        /* Write contents of one vertex to stdout.	*/
        void print3DcolorVertex(GLint size, GLint* count,
            GLfloat[] buffer) {
            if (this.frmDump == null) { return; }

            //printf("  ");
            this.frmDump.Append("  ");
            for (var i = 0; i < 7; i++) {
                //printf("%4.2f ", buffer[size - (*count)]);
                this.frmDump.Append($"{buffer[size - (*count)]}");
                *count = *count - 1;
            }
            //printf("\n");
            this.frmDump.AppendLine();
        }

        /*  Write contents of entire buffer.  (Parse tokens!)	*/
        void printBuffer(GLint size, GLfloat[] buffer) {
            if (this.frmDump == null) { return; }
            this.frmDump.ClearText();

            var count = size;
            while (count != 0) {
                var token = buffer[size - count]; count--;
                if (token == GL.GL_PASS_THROUGH_TOKEN) {
                    //printf("GL.GL_PASS_THROUGH_TOKEN\n");
                    //printf("  %4.2f\n", buffer[size - count]);
                    this.frmDump.AppendLine("GL.GL_PASS_THROUGH_TOKEN");
                    this.frmDump.AppendLine($"{buffer[size - count]}");
                    count--;
                }
                else if (token == GL.GL_POINT_TOKEN) {
                    //printf("GL.GL_POINT_TOKEN\n");
                    this.frmDump.Append("GL.GL_POINT_TOKEN");
                    print3DcolorVertex(size, &count, buffer);
                }
                else if (token == GL.GL_LINE_TOKEN) {
                    //printf("GL.GL_LINE_TOKEN\n");
                    this.frmDump.AppendLine("GL.GL_LINE_TOKEN");
                    print3DcolorVertex(size, &count, buffer);
                    print3DcolorVertex(size, &count, buffer);
                }
                else if (token == GL.GL_LINE_RESET_TOKEN) {
                    //printf("GL.GL_LINE_RESET_TOKEN\n");
                    this.frmDump.AppendLine("GL.GL_LINE_RESET_TOKEN");
                    print3DcolorVertex(size, &count, buffer);
                    print3DcolorVertex(size, &count, buffer);
                }
            }
        }
    }
}