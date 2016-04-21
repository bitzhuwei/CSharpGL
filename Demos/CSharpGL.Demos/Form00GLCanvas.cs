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

        float[] clearColor = new float[4];

        Random random = new Random();

        public Form00GLCanvas()
        {
            InitializeComponent();

            // 天蓝色背景
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            GL.ClearColor(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);

            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                clearColor[i] = (float)random.NextDouble();
            }
        }

    }
}
