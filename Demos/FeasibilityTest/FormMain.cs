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
            MessageBox.Show("001");
            InitializeComponent();
            MessageBox.Show("002");

            this.Load += Form_Load;
            MessageBox.Show("003");

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            MessageBox.Show("004");

            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            MessageBox.Show("005");

            Application.Idle += Application_Idle;
            MessageBox.Show("006");
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
                MessageBox.Show("007");
                string filename = this.openFileDlg.FileName;
                List<vec3> pointList = PointListFactory.OpenFile(filename);
                MessageBox.Show("008");
                PointsRenderer renderer = PointsRenderer.Create(pointList);
                MessageBox.Show("009");
                SceneObject obj = renderer.WrapToSceneObject(generateBoundingBox: true);
                MessageBox.Show("010");
                this.scene.RootObject.Children.Add(obj);
                MessageBox.Show("011");
                this.glCanvas1.Invalidate();
                MessageBox.Show("012");
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {

        }
    }
}
