using System;
using System.Drawing;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form25Light : Form
    {
        private SatelliteManipulater cameraManipulater;

        public Form25Light()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;

            Application.Idle += Application_Idle;
            OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.glCanvas1.FPS.ToShortString());
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.scene.Render();
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'o')
            {
                if (openTextureDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (var bitmap = new Bitmap(openTextureDlg.FileName))
                    {
                        this.renderer.SetupTexture(bitmap);
                    }
                }
            }
            else if (e.KeyChar == 'p')
            {
                bool original = false;
                if (this.renderer.GetUniformValue<bool>("original", out original))
                {
                    this.renderer.SetUniform("original", !original);
                }
                else
                {
                    this.renderer.SetUniform("original", original);
                }
            }
            else if (e.KeyChar == '2')
            {
                var frmPropertyGrid = new FormProperyGrid(this.glCanvas1);
                frmPropertyGrid.Show();
            }
        }
    }
}