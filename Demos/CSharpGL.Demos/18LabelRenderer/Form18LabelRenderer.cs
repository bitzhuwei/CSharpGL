using System;
using System.Drawing;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form18LabelRenderer : Form
    {
        private SatelliteManipulater rotator;

        public Form18LabelRenderer()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            //this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            //this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            //this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            //this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            //this.glCanvas1.Resize += glCanvas1_Resize;
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
            if (e.KeyChar == 'b')
            {
                BlendingSourceFactor source;
                BlendingDestinationFactor dest;
                this.blendFactorHelper.GetNext(out source, out dest);
                this.blendSwitch1.SourceFactor = source;
                this.blendSwitch1.DestFactor = dest;
                this.blendSwitch2.SourceFactor = source;
                this.blendSwitch2.DestFactor = dest;
            }
            else if (e.KeyChar == 'd')
            {
                this.labelRenderer1.DiscardTransparency = !this.labelRenderer1.DiscardTransparency;
                this.labelRenderer2.DiscardTransparency = !this.labelRenderer2.DiscardTransparency;
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

            this.UpdateLabel();
        }
    }
}