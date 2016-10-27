using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpGL;

namespace FeasibilityTest
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            this.Load += Form_Load;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;

            Application.Idle += Application_Idle;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.glCanvas1.FPS.ToShortString());
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

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.scene.Render();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (this.openFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = this.openFileDlg.FileName;
                List<vec3> pointList = PointListFactory.OpenFile(filename);
                PointsRenderer renderer = PointsRenderer.Create(pointList);
                SceneObject obj = renderer.WrapToSceneObject(generateBoundingBox: true);
                this.scene.RootObject.Children.Add(obj);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {

        }
    }
}
