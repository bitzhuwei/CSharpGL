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

            Application.Idle += Application_Idle;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            //this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.glCanvas1.FPS.ToShortString());
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
