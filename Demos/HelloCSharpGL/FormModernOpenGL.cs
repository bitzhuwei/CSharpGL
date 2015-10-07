using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharpGL
{
    public partial class FormModernOpenGL : Form
    {
        private Stopwatch watch = new Stopwatch();

        private PyramidDemo pyramidElement;

        public FormModernOpenGL()
        {
            InitializeComponent();
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            watch.Restart();

            //  Clear the color and depth buffer.
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            this.pyramidElement.Render();

            watch.Stop();

            this.Text = string.Format("FormModernOpenGL FPS: {0}", 1000.0 / (watch.Elapsed.TotalMilliseconds));

        }

        private void FormModernOpenGL_Load(object sender, EventArgs e)
        {
            this.pyramidElement = new PyramidDemo();
            this.pyramidElement.Initilize();
        }
    }
}
