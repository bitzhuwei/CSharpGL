using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.CSSLGenetator
{
    public partial class FormUpdateStructureField : Form
    {

        private CSSLTemplate template;
        private StructureField target;

        public FormUpdateStructureField(CSSLTemplate template, StructureField target)
        {
            InitializeComponent();

            this.template = template;
            this.target = target;
        }

        private void FormAddVertexShaderField_Load(object sender, EventArgs e)
        {
            {
                this.cmbType.Items.Clear();
                foreach (var item in this.template.GetAllIntermediateStructures())
                {
                    this.cmbType.Items.Add(item);
                }
                for (int i = 0; i < this.cmbType.Items.Count; i++)
                {
                    if (this.cmbType.Items[i].ToString() == this.target.FieldType)
                    {
                        this.cmbType.SelectedIndex = i;
                        break;
                    }
                }
            }

            this.txtName.Text = target.FieldName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.target.FieldType = this.cmbType.SelectedItem.ToString();
            this.target.FieldName = this.txtName.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
