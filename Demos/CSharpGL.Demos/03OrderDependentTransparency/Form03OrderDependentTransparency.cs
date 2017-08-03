using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form03OrderDependentTransparency : Form
    {
        private IMouseHandler rotator;

        public Form03OrderDependentTransparency()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;

            Application.Idle += Application_Idle;
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '1')
            {
                var frmPropertyGrid = new FormProperyGrid(this.scene);
                frmPropertyGrid.Show();
            }
            else if (e.KeyChar == '2')
            {
                var frmPropertyGrid = new FormProperyGrid(this.glCanvas1);
                frmPropertyGrid.Show();
            }
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.glCanvas1.FPS.ToShortString());
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            //OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            //Point mousePosition = this.glCanvas1.PointToClient(Control.MousePosition);
            this.scene.Render();
        }

        internal void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (sender == this.glCanvas1)
            {
            }
            else
            {
                this.rotator.canvas_MouseWheel(sender, e);
            }
        }
    }
}