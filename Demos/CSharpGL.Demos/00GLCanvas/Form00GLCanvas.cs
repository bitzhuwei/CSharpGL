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
        private string content;

        public Form00GLCanvas()
        {
            InitializeComponent();

            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            // 天蓝色背景
            OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);

            var builder = new StringBuilder();
            int[] maxTextureSize = new int[1];
            OpenGL.GetInteger(GetTarget.MaxTextureSize, maxTextureSize);
            builder.Append("Max Texture Width: ");
            builder.Append(maxTextureSize[0]);

            this.content = builder.ToString();
        }

        void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            this.mousePosition = new Point(e.X, e.Y);
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {

            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            OpenGL.DrawText(1, this.glCanvas1.Height - 14 - 1, Color.Red, "Courier New",
                14.0f, content);

            OpenGL.DrawText(this.mousePosition.X,
                this.glCanvas1.Height - this.mousePosition.Y - 1, Color.Red, "Courier New",
                14.0f, string.Format("Mouse Position: {0}", this.mousePosition));
        }

    }
}
