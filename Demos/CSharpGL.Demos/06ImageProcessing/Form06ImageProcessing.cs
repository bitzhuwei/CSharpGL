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
    public partial class Form06ImageProcessing : Form
    {

        private SatelliteManipulater rotator;

        public Form06ImageProcessing()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;

            Application.Idle += Application_Idle;
            OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            //GL.ClearColor(0, 0, 0, 0);
        }

        void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's')
            {
                var frmPropertyGrid = new FormProperyGrid(this.scene);
                frmPropertyGrid.Show();
            }
            else if (e.KeyChar == 'c')
            {
                var frmPropertyGrid = new FormProperyGrid(this.glCanvas1);
                frmPropertyGrid.Show();
            }
            if (e.KeyChar == 's')
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

        void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.glCanvas1.FPS.ToShortString());
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            this.scene.Render(RenderModes.Render, this.glCanvas1.ClientRectangle, this.glCanvas1.PointToClient(Control.MousePosition));
        }

    }
}
