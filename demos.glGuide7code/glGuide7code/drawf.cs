
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
   *  drawf.c
   *  Draws the bitmapped letter F on the screen (several times).
   *  This demonstrates use of the gl.glBitmap() call.
   */
    public unsafe class drawf : _glGuide7code {

        public drawf(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        private static readonly GLubyte[] rasters = {
            0xc0, 0x00, 0xc0, 0x00, 0xc0, 0x00, 0xc0, 0x00, 0xc0, 0x00,
            0xff, 0x00, 0xff, 0x00, 0xc0, 0x00, 0xc0, 0x00, 0xc0, 0x00,
            0xff, 0xc0, 0xff, 0xc0
        };
        public override void init(CSharpGL.GL gl) {
            gl.glPixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);
            gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glColor3f(1.0f, 1.0f, 1.0f);
            gl.glRasterPos2i(20, 20);
            gl.glBitmap(10, 12, 0.0f, 0.0f, 11.0f, 0.0f, rasters);
            gl.glBitmap(10, 12, 0.0f, 0.0f, 11.0f, 0.0f, rasters);
            gl.glBitmap(10, 12, 0.0f, 0.0f, 11.0f, 0.0f, rasters);
            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            gl.glOrtho(0, w, 0, h, -1.0f, 1.0f);
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

    }
}