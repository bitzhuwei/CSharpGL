using System;
using System.Drawing;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form26DirectionalLight : Form
    {
        private SatelliteManipulater cameraManipulater;

        public Form26DirectionalLight()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;

            Application.Idle += Application_Idle;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.glCanvas1.FPS.ToShortString());
            this.lblInfo.Text = string.Format("binded: {0}", false);
            if (this.pickedGeometry != null)
            {
                var modelRenderer = this.pickedGeometry.FromRenderer as DirectonalLightRenderer;
                if (modelRenderer != null)
                {
                    var script = modelRenderer.BindingSceneObject.GetScript<ModelScript>();
                    this.lblInfo.Text = string.Format("binded: {0}", script.Manipulater.IsBinded);
                }
            }
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.scene.Render();
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
    }
}