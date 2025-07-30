
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
   *  model.c
   *  This program demonstrates modeling transformations
   */
    public unsafe class model : _glGuide7code {

        public model(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        public override void init(CSharpGL.GL gl) {
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.glShadeModel(GL.GL_FLAT);
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glColor3f(1.0f, 1.0f, 1.0f);

            gl.glLoadIdentity();
            gl.glColor3f(1.0f, 1.0f, 1.0f);
            draw_triangle(gl);

            gl.glEnable(GL.GL_LINE_STIPPLE);
            gl.glLineStipple(1, 0xF0F0);
            gl.glLoadIdentity();
            gl.glTranslatef(-20.0f, 0.0f, 0.0f);
            draw_triangle(gl);

            gl.glLineStipple(1, 0xF00F);
            gl.glLoadIdentity();
            gl.glScalef(1.5f, 0.5f, 1.0f);
            draw_triangle(gl);

            gl.glLineStipple(1, 0x8888);
            gl.glLoadIdentity();
            gl.glRotatef(90.0f, 0.0f, 0.0f, 1.0f);
            draw_triangle(gl);
            gl.glDisable(GL.GL_LINE_STIPPLE);

            gl.glFlush();
        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            if (w <= h)
                gl.glOrtho(-50.0f, 50.0f, -50.0f * (GLfloat)h / (GLfloat)w,
                    50.0f * (GLfloat)h / (GLfloat)w, -1.0f, 1.0f);
            else
                gl.glOrtho(-50.0f * (GLfloat)w / (GLfloat)h,
                    50.0f * (GLfloat)w / (GLfloat)h, -50.0f, 50.0f, -1.0f, 1.0f);
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


        void draw_triangle(GL gl) {
            gl.glBegin(GL.GL_LINE_LOOP);
            gl.glVertex2f(0.0f, 25.0f);
            gl.glVertex2f(25.0f, -25.0f);
            gl.glVertex2f(-25.0f, -25.0f);
            gl.glEnd();
        }
    }
}