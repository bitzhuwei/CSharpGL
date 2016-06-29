using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form04SimpleCompute : Form
    {

        private Camera camera;
        private RendererBase renderer;

        public Form04SimpleCompute()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            //this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            //this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            //this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            //this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.Resize += glCanvas1_Resize;

            // 天蓝色背景
            OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            RenderEventArg arg = new RenderEventArg(RenderModes.Render, this.glCanvas1.ClientRectangle, this.camera);
            IRenderable renderer = this.renderer;
            if (renderer != null)
            {
                renderer.Render(arg);
            }

            Point mousePosition = this.glCanvas1.PointToClient(Control.MousePosition);
            // Cross cursor shows where the mouse is.
            OpenGL.DrawText(mousePosition.X - offset.X,
                this.glCanvas1.Height - (mousePosition.Y + offset.Y) - 1,
                Color.Red, "Courier New", crossCursorSize, "o");
        }


        private const float crossCursorSize = 40.0f;

        private Point offset = new Point(13, 11);

        //void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    ICamera camera = this.camera;
        //    if (camera != null)
        //    {
        //        camera.MouseWheel(e.Delta);
        //    }
        //}

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
        }

    }
}
