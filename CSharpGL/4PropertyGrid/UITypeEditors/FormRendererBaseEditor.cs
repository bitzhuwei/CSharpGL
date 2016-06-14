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
    partial class FormRendererBaseEditor : Form
    {

        public FormRendererBaseEditor(RendererBase renderer)
        {
            InitializeComponent();

            this.propertyGrid.SelectedObject = renderer;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}
