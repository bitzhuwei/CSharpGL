using CSharpGL;
using System;
using System.Windows.Forms;

namespace ArmadaTank
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            Application.Idle += Application_Idle;
            this.Load += FormMain_Load;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
        }

        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.scene.Render(RenderModes.Render, this.glCanvas1.ClientRectangle);
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("Armada Tank FPS: {0}", this.glCanvas1.FPS.ToShortString());
        }
    }
}