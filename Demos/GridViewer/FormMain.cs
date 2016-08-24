using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace GridViewer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
        }

        private void lblTimerEnabled_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = !this.timer1.Enabled;
            this.scientificCanvas.Scene.Running = this.timer1.Enabled;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.scientificCanvas.Scene.Update();
            this.scientificCanvas.Invalidate();
        }



    }
}
