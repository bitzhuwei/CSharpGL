
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*  mipmap.c
    *  This program demonstrates using mipmaps for texture maps.
    *  To overtly show the effect of mipmaps, each mipmap reduction
    *  level has a solidly colored, contrasting texture image.
    *  Thus, the quadrilateral which is drawn is drawn with several
    *  different colors.
    */
    public unsafe class mipmap : _glGuide7code {

        public mipmap(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        public override void init(CSharpGL.GL gl) {
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glShadeModel(GL.GL_FLAT);

            gl.glTranslatef(0.0f, 0.0f, -3.6f);
            //makeImages();
            gl.glPixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);

            if (texName == 0) {
                var texture = stackalloc GLuint[1];
                gl.glGenTextures(1, texture); texName = texture[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D, texName);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_REPEAT);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_REPEAT);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST_MIPMAP_NEAREST);
                fixed (byte* p = mipmapImage32) {
                    gl.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGBA, 32, 32, 0,
                        GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, (IntPtr)p);
                }
                fixed (byte* p = mipmapImage16) {
                    gl.glTexImage2D(GL.GL_TEXTURE_2D, 1, (int)GL.GL_RGBA, 16, 16, 0,
                    GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, (IntPtr)p);
                }
                fixed (byte* p = mipmapImage8) {
                    gl.glTexImage2D(GL.GL_TEXTURE_2D, 2, (int)GL.GL_RGBA, 8, 8, 0,
                    GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, (IntPtr)p);
                }
                fixed (byte* p = mipmapImage4) {
                    gl.glTexImage2D(GL.GL_TEXTURE_2D, 3, (int)GL.GL_RGBA, 4, 4, 0,
                    GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, (IntPtr)p);
                }
                fixed (byte* p = mipmapImage2) {
                    gl.glTexImage2D(GL.GL_TEXTURE_2D, 4, (int)GL.GL_RGBA, 2, 2, 0,
                    GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, (IntPtr)p);
                }
                fixed (byte* p = mipmapImage1) {
                    gl.glTexImage2D(GL.GL_TEXTURE_2D, 5, (int)GL.GL_RGBA, 1, 1, 0,
                    GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, (IntPtr)p);
                }
            }
            gl.glTexEnvf(GL.GL_TEXTURE_ENV, GL.GL_TEXTURE_ENV_MODE, GL.GL_DECAL);
            gl.glEnable(GL.GL_TEXTURE_2D);
        }

        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glBindTexture(GL.GL_TEXTURE_2D, texName);
            gl.glBegin(GL.GL_QUADS);
            gl.glTexCoord2f(0.0f, 0.0f); gl.glVertex3f(-2.0f, -1.0f, 0.0f);
            gl.glTexCoord2f(0.0f, 8.0f); gl.glVertex3f(-2.0f, 1.0f, 0.0f);
            gl.glTexCoord2f(8.0f, 8.0f); gl.glVertex3f(2000.0f, 1.0f, -6000.0f);
            gl.glTexCoord2f(8.0f, 0.0f); gl.glVertex3f(2000.0f, -1.0f, -6000.0f);
            gl.glEnd();
            gl.glFlush();

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
            gl.glLoadIdentity();
            //gl.gluPerspective(60.0f, (GLfloat)w / (GLfloat)h, 1.0f, 30000.0f);
            glu.Perspective(60.0f, (GLfloat)w / (GLfloat)h, 1.0f, 30000.0f);
            gl.glMatrixMode(GL.GL_MODELVIEW);
            gl.glLoadIdentity();
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


        static GLubyte[] mipmapImage32 = new GLubyte[32 * 32 * 4];
        static GLubyte[] mipmapImage16 = new GLubyte[16 * 16 * 4];
        static GLubyte[] mipmapImage8 = new GLubyte[8 * 8 * 4];
        static GLubyte[] mipmapImage4 = new GLubyte[4 * 4 * 4];
        static GLubyte[] mipmapImage2 = new GLubyte[2 * 2 * 4];
        static GLubyte[] mipmapImage1 = new GLubyte[1 * 1 * 4];

        static GLuint texName = 0;

        static mipmap() {
            for (var i = 0; i < 32; i++) {
                for (var j = 0; j < 32; j++) {
                    mipmapImage32[(i * 32 + j) * 4 + 0] = 255;
                    mipmapImage32[(i * 32 + j) * 4 + 1] = 255;
                    mipmapImage32[(i * 32 + j) * 4 + 2] = 0;
                    mipmapImage32[(i * 32 + j) * 4 + 3] = 255;
                }
            }
            for (var i = 0; i < 16; i++) {
                for (var j = 0; j < 16; j++) {
                    mipmapImage16[(i * 16 + j) * 4 + 0] = 255;
                    mipmapImage16[(i * 16 + j) * 4 + 1] = 0;
                    mipmapImage16[(i * 16 + j) * 4 + 2] = 255;
                    mipmapImage16[(i * 16 + j) * 4 + 3] = 255;
                }
            }
            for (var i = 0; i < 8; i++) {
                for (var j = 0; j < 8; j++) {
                    mipmapImage8[(i * 8 + j) * 4 + 0] = 255;
                    mipmapImage8[(i * 8 + j) * 4 + 1] = 0;
                    mipmapImage8[(i * 8 + j) * 4 + 2] = 0;
                    mipmapImage8[(i * 8 + j) * 4 + 3] = 255;
                }
            }
            for (var i = 0; i < 4; i++) {
                for (var j = 0; j < 4; j++) {
                    mipmapImage4[(i * 4 + j) * 4 + 0] = 0;
                    mipmapImage4[(i * 4 + j) * 4 + 1] = 255;
                    mipmapImage4[(i * 4 + j) * 4 + 2] = 0;
                    mipmapImage4[(i * 4 + j) * 4 + 3] = 255;
                }
            }
            for (var i = 0; i < 2; i++) {
                for (var j = 0; j < 2; j++) {
                    mipmapImage2[(i * 2 + j) * 4 + 0] = 0;
                    mipmapImage2[(i * 2 + j) * 4 + 1] = 0;
                    mipmapImage2[(i * 2 + j) * 4 + 2] = 255;
                    mipmapImage2[(i * 2 + j) * 4 + 3] = 255;
                }
            }
            mipmapImage1[0] = 255;
            mipmapImage1[1] = 255;
            mipmapImage1[2] = 255;
            mipmapImage1[3] = 255;
        }
    }
}