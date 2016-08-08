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
    public partial class Form02OrderIndependentTransparency : Form
    {

        private IMouseHandler rotator;

        public Form02OrderIndependentTransparency()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            //this.glCanvas1.Resize +=  glCanvas1_Resize;

            Application.Idle += Application_Idle;
            // 天蓝色背景
            OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.glCanvas1.FPS.ToShortString());
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            this.scene.Render(RenderModes.Render, this.glCanvas1.ClientRectangle, this.glCanvas1.PointToClient(Control.MousePosition));
        }


        private const float crossCursorSize = 40.0f;

        private Point offset = new Point(13, 11);

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            ICamera camera = this.scene.Camera;
            if (camera != null)
            {
                camera.MouseWheel(e.Delta);
            }
        }

    }
}
