using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL
{
    partial class FormGLSwitchEditor : Form
    {

        public FormGLSwitchEditor(GLSwitch glSwitch)
        {
            InitializeComponent();

            this.propertyGrid.SelectedObject = glSwitch;
            this.lblSwitchName.Text = string.Format("{0}", glSwitch);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }


    }
}
