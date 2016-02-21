using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.CSSLGenetator
{
    public partial class FormInsertIntermediateStructure : Form
    {

        public IntermediateStructure Result { get; private set; }

        private CSSLTemplate template;

        public FormInsertIntermediateStructure(CSSLTemplate template)
        {
            InitializeComponent();

            this.template = template;
        }

        private void FormAddVertexShaderField_Load(object sender, EventArgs e)
        {
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var result = new IntermediateStructure()
            {
                Name = this.txtName.Text,
            };
            foreach (var item in this.lstFIeld.Items)
            {
                result.FieldList.Add(item as StructureField);
            }
            this.Result = result;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void addAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new FormInsertStructureField(this.template);
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StructureField field = dlg.Result;
                this.lstFIeld.Items.Add(field);
            }
        }
    }
}
