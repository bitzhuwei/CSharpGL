using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL
{
    partial class FormPropertyGridEditor : Form
    {

        public FormPropertyGridEditor(object obj)
        {
            InitializeComponent();

            this.propertyGrid.SelectedObject = obj;
            this.Text = string.Format("{0} - Property Editor", obj);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }


    }
}
