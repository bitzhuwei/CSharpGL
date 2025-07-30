
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {

    /*
   *  texprox.c
   *  The brief program illustrates use of texture proxies.
   *  This program only prints out some messages about whether
   *  certain size textures are supported and then exits.
   */
    public unsafe class texprox : _glGuide7code {

        public texprox(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        public override void init(CSharpGL.GL gl) {
            var frmDump = new FormDump();
            frmDump.Show();

            var proxyComponents = stackalloc GLint[1];

            uint GL_TEXTURE_COMPONENTS = 0x1003;
            gl.glTexImage2D(GL.GL_PROXY_TEXTURE_2D, 0, (int)GL.GL_RGBA8,
                64, 64, 0,
                GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, IntPtr.Zero);
            gl.glGetTexLevelParameteriv(GL.GL_PROXY_TEXTURE_2D, 0,
                GL_TEXTURE_COMPONENTS, proxyComponents);
            //printf("proxyComponents are %d\n", proxyComponents);
            frmDump.AppendLine($"proxyComponents are {proxyComponents[0]}");
            if (proxyComponents[0] == GL.GL_RGBA8) {
                //printf("proxy allocation succeeded\n");
                frmDump.AppendLine($"proxy allocation succeeded");
            }
            else {
                //printf("proxy allocation failed\n");
                frmDump.AppendLine($"proxy allocation failed");
            }

            gl.glTexImage2D(GL.GL_PROXY_TEXTURE_2D, 0, (int)GL.GL_RGBA16,
                2048, 2048, 0,
                GL.GL_RGBA, GL.GL_UNSIGNED_SHORT, IntPtr.Zero);
            gl.glGetTexLevelParameteriv(GL.GL_PROXY_TEXTURE_2D, 0,
                GL_TEXTURE_COMPONENTS, proxyComponents);
            //printf("proxyComponents are %d\n", proxyComponents);
            frmDump.AppendLine($"proxyComponents are {proxyComponents[0]}");
            if (proxyComponents[0] == GL.GL_RGBA16) {
                //printf("proxy allocation succeeded\n");
                frmDump.AppendLine($"proxy allocation succeeded");
            }
            else {
                //printf("proxy allocation failed\n");
                frmDump.AppendLine($"proxy allocation failed");
            }
        }

        public override void display(CSharpGL.GL gl) {

        }

        public override void reshape(CSharpGL.GL gl, int w, int h) {
            gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
            gl.glMatrixMode(GL.GL_PROJECTION);
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

    }
}