using System;

using System.Windows.Forms;

namespace CSharpGL.CSSLGenetator
{
    public partial class FormInsertShaderField : Form
    {
        public ShaderField Result { get; private set; }

        private CSSLTemplate template;

        public FormInsertShaderField(CSSLTemplate template)
        {
            InitializeComponent();

            this.template = template;
        }

        private void FormAddVertexShaderField_Load(object sender, EventArgs e)
        {
            {
                FieldQualifier[] qualifiers = new FieldQualifier[]
                {
                    FieldQualifier.In,
                    FieldQualifier.Out,
                    FieldQualifier.Uniform,
                };
                this.cmbQualifier.Items.Clear();
                foreach (var item in qualifiers)
                {
                    this.cmbQualifier.Items.Add(item);
                }
                this.cmbQualifier.SelectedIndex = 0;
            }
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
            this.Result = new ShaderField()
            {
                Qualider = (FieldQualifier)this.cmbQualifier.SelectedItem,
                FieldType = this.cmbType.SelectedItem.ToString(),
                FieldName = this.txtName.Text,
                FieldValue = this.txtValue.Text,
            };

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            IntermediateStructure structure = this.cmbType.SelectedItem as IntermediateStructure;
            if (structure != null)
            {
                this.txtValue.Text = structure.DefaultValue;
            }
        }
    }
}