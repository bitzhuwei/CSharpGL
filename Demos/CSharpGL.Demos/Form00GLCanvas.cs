using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form00GLCanvas : Form
    {

        private Point mousePosition;

        public Form00GLCanvas()
        {
            InitializeComponent();

            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            // 天蓝色背景
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
        }

        void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            this.mousePosition = new Point(e.X, e.Y);
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            GL.DrawText(this.mousePosition.X,
                this.glCanvas1.Height - this.mousePosition.Y - 1, Color.Red, "Courier New",
                14.0f, string.Format("Mouse Position: {0}", this.mousePosition));
        }

    }
}
