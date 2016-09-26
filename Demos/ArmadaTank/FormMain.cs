using CSharpGL;
using System;
using System.Windows.Forms;

namespace ArmadaTank
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            Application.Idle += Application_Idle;
            this.Load += FormMain_Load;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("Armada Tank FPS: {0}", this.glCanvas1.FPS.ToShortString());
        }
    }
}