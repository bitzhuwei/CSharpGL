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

            this.drvSimuControl1.KeyPress += drvSimuControl1_KeyPress;

            Application.Idle += Application_Idle;

            {
                var builder = new StringBuilder();
                builder.AppendLine("1: Scene's property grid.");
                builder.AppendLine("2: Canvas' property grid.");
                builder.AppendLine("3: Form's property grid.");
                MessageBox.Show(builder.ToString());
            }
        }

        void drvSimuControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '1')
            {
                var frmPropertyGrid = new FormProperyGrid(this.drvSimuControl1.Scene);
                frmPropertyGrid.Show();
            }
            else if (e.KeyChar == '2')
            {
                var frmPropertyGrid = new FormProperyGrid(this.drvSimuControl1);
                frmPropertyGrid.Show();
            }
            else if (e.KeyChar == '3')
            {
                var frmPropertyGrid = new FormProperyGrid(this);
                frmPropertyGrid.Show();
            }
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.drvSimuControl1.FPS.ToShortString());
        }

        Random random = new Random();
        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            var point = new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
            this.drvSimuControl1.AddPoint(point);
        }

        private void btnSetColor_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Color color = this.colorDialog1.Color;
                this.drvSimuControl1.SetColor(color);
            }
        }

    }
}
