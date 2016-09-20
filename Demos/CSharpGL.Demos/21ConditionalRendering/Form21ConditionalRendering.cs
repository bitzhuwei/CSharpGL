using System;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form21ConditionalRendering : Form
    {
        private Camera camera;
        private SatelliteManipulater rotator;

        public Form21ConditionalRendering()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;

            Application.Idle += Application_Idle;
            OpenGL.ClearColor(0, 0, 0, 0);
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.glCanvas1.FPS.ToShortString());
            ConditionalRenderer renderer = this.conditionalRenderer;
            if (conditionalRenderer != null)
            {
                this.lblState.Text = string.Format(
                    "box:{0}, target:{1}, Conditional Rendering:{2}",
                    renderer.RenderBoundingBox,
                    renderer.RenderTargetModel,
                    renderer.ConditionalRendering);
            }
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            this.scene.Render(RenderModes.Render, this.glCanvas1.ClientRectangle, this.glCanvas1.PointToClient(Control.MousePosition));
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
            else if (e.KeyChar == 'b')
            {
                this.conditionalRenderer.RenderBoundingBox = !this.conditionalRenderer.RenderBoundingBox;
            }
            else if (e.KeyChar == 't')
            {
                this.conditionalRenderer.RenderTargetModel = !this.conditionalRenderer.RenderTargetModel;
            }
            else if (e.KeyChar == 'r')
            {
                this.conditionalRenderer.ConditionalRendering = !this.conditionalRenderer.ConditionalRendering;
            }
        }
    }
}