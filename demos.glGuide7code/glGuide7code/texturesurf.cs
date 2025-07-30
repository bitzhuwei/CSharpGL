
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*  texturesurf.c
    *  This program uses evaluators to generate a curved
    *  surface and automatically generated texture coordinates.
    */
    public unsafe class texturesurf : _glGuide7code {

        public texturesurf(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLfloat[] ctrlpoints = new GLfloat[4 * 4 * 3] {
            -1.5f, -1.5f,  4.0f ,  -0.5f, -1.5f,  2.0f,
             0.5f, -1.5f, -1.0f ,   1.5f, -1.5f,  2.0f,
            -1.5f, -0.5f,  1.0f ,  -0.5f, -0.5f,  3.0f,
             0.5f, -0.5f,  0.0f ,   1.5f, -0.5f, -1.0f,
            -1.5f,  0.5f,  4.0f ,  -0.5f,  0.5f,  0.0f,
             0.5f,  0.5f,  3.0f ,   1.5f,  0.5f,  4.0f,
            -1.5f,  1.5f, -2.0f ,  -0.5f,  1.5f, -2.0f,
             0.5f,  1.5f,  0.0f ,   1.5f,  1.5f, -1.0f
        };

        GLfloat[] texpts = new GLfloat[2 * 2 * 2] {
            0.0f, 0.0f ,  0.0f, 1.0f,
            1.0f, 0.0f ,  1.0f, 1.0f
        };

        public override void init(CSharpGL.GL gl) {
            fixed (GLfloat* p = ctrlpoints) {
                gl.glMap2f(GL.GL_MAP2_VERTEX_3, 0, 1, 3, 4, 0, 1, 12, 4, p);
            }
            fixed (GLfloat* p = texpts) {
                gl.glMap2f(GL.GL_MAP2_TEXTURE_COORD_2, 0, 1, 2, 2, 0, 1, 4, 2, p);
            }
            gl.glEnable(GL.GL_MAP2_TEXTURE_COORD_2);
            gl.glEnable(GL.GL_MAP2_VERTEX_3);
            gl.glMapGrid2f(20, 0.0f, 1.0f, 20, 0.0f, 1.0f);
            makeImage();
            gl.glTexEnvf(GL.GL_TEXTURE_ENV, GL.GL_TEXTURE_ENV_MODE, (int)GL.GL_DECAL);
            gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_REPEAT);
            gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_REPEAT);
            gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);
            gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST);
            fixed (byte* p = image) {
                gl.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGB, imageWidth, imageHeight, 0,
                    GL.GL_RGB, GL.GL_UNSIGNED_BYTE, (IntPtr)p);
            }
            gl.glEnable(GL.GL_TEXTURE_2D);
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glShadeModel(GL.GL_FLAT);
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glColor3f(1.0f, 1.0f, 1.0f);
            gl.glEvalMesh2(GL.GL_FILL, 0, 20, 0, 20);
            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            if (w <= h)
                gl.glOrtho(-4.0f, 4.0f, -4.0f * (GLfloat)h / (GLfloat)w,
                    4.0f * (GLfloat)h / (GLfloat)w, -4.0f, 4.0f);
            else
                gl.glOrtho(-4.0f * (GLfloat)w / (GLfloat)h,
                    4.0f * (GLfloat)w / (GLfloat)h, -4.0f, 4.0f, -4.0f, 4.0f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
            gl.glRotatef(85.0f, 1.0f, 1.0f, 1.0f);
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

        const int imageWidth = 64;
        const int imageHeight = 64;
        static GLubyte[] image = new GLubyte[3 * imageWidth * imageHeight];

        static void makeImage() {
            int i, j;
            float ti, tj;

            for (i = 0; i < imageWidth; i++) {
                ti = 2.0f * 3.14159265f * i / imageWidth;
                for (j = 0; j < imageHeight; j++) {
                    tj = 2.0f * 3.14159265f * j / imageHeight;

                    image[3 * (imageHeight * i + j)] = (GLubyte)(127 * (1.0f + Math.Sin(ti)));
                    image[3 * (imageHeight * i + j) + 1] = (GLubyte)(127 * (1.0f + Math.Cos(2 * tj)));
                    image[3 * (imageHeight * i + j) + 2] = (GLubyte)(127 * (1.0f + Math.Cos(ti + tj)));
                }
            }
        }
    }
}