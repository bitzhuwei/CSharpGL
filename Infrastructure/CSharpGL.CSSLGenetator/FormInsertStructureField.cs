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
    public partial class FormInsertStructureField : Form
    {

        public StructureField Result { get; private set; }

        private CSSLTemplate template;

        public FormInsertStructureField(CSSLTemplate template)
        {
            InitializeComponent();

            this.template = template;
        }

        private void FormAddVertexShaderField_Load(object sender, EventArgs e)
        {
            {
                this.cmbType.Items.Clear();
                foreach (var item in this.template.GetAllIntermediateStructures())
                {
                    this.cmbType.Items.Add(item);
                }
                this.cmbType.SelectedIndex = 0;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Result = new StructureField() 
            {
                FieldType = this.cmbType.SelectedItem.ToString(), 
                FieldName = this.txtName.Text, 
            };

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
