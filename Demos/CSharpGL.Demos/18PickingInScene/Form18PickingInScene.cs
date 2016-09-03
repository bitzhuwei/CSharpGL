using System;
using System.Drawing;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form18PickingInScene : Form
    {

        public Form18PickingInScene()
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
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            Point mousePosition = this.glCanvas1.PointToClient(Control.MousePosition);

            this.scene.Render(RenderModes.Render, this.glCanvas1.ClientRectangle, mousePosition);

            //// Cross cursor shows where the mouse is.
            //OpenGL.DrawText(mousePosition.X - offset.X,
            //    this.glCanvas1.Height - (mousePosition.Y + offset.Y) - 1,
            //    Color.Red, "Courier New", crossCursorSize, "o");
        }

        private const float crossCursorSize = 40.0f;

        private Point offset = new Point(13, 11);

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'x')
            {
                var frmPropertyGrid = new FormProperyGrid(this.scene);
                frmPropertyGrid.Show();
            }
            else if (e.KeyChar == 'z')
            {
                var frmPropertyGrid = new FormProperyGrid(this.glCanvas1);
                frmPropertyGrid.Show();
            }

        }
    }
}