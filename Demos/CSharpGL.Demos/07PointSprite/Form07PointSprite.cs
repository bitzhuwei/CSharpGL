using System;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form07PointSprite : Form
    {
        private Camera camera;
        private SatelliteManipulater rotator;
        private PointSpriteRenderer renderer;

        public Form07PointSprite()
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
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            this.scene.Render(RenderModes.Render, this.glCanvas1.ClientRectangle, this.glCanvas1.PointToClient(Control.MousePosition));
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'o')
            {
                if (this.openTextureDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.renderer.UpdateTexture(this.openTextureDlg.FileName);
                }
            }
            else if (e.KeyChar == 's')
            {
                var frmPropertyGrid = new FormProperyGrid(this.scene);
                frmPropertyGrid.Show();
            }
            else if (e.KeyChar == 'c')
            {
                var frmPropertyGrid = new FormProperyGrid(this.glCanvas1);
                frmPropertyGrid.Show();
            }
        }
    }
}