using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormShaderDesigner1594Demos
{
    public partial class FormDemosPanel : Form
    {
        public FormDemosPanel()
        {
            InitializeComponent();
        }
        private void btnGooch_Click(object sender, EventArgs e)
        {
            (new FormGooch()).Show();
        }

        private void btnXRay_Click(object sender, EventArgs e)
        {
            (new FormXRay()).Show();
        }

        private void btnBrick_Click(object sender, EventArgs e)
        {
            (new FormBrick()).Show();
        }

    }
}
