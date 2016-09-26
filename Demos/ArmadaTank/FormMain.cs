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

namespace ArmadaTank
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("Armada Tank FPS: {0}", this.glCanvas1.FPS.ToShortString());
        }
    }
}
