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
    public partial class FormUpdateShaderField : Form
    {

        public ShaderField Result { get; private set; }

        private CSSLTemplate template;
        private ShaderField clonedTarget;

        public FormUpdateShaderField(CSSLTemplate template, ShaderField target)
        {
            InitializeComponent();

            this.template = template;
            this.clonedTarget = target.Clone() as ShaderField;
        }

        private void FormAddVertexShaderField_Load(object sender, EventArgs e)
        {
            this.txtName.Text = this.clonedTarget.FieldName;

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
                for (int i = 0; i < this.cmbQualifier.Items.Count; i++)
                {
                    if (this.cmbQualifier.Items[i].ToString() == this.clonedTarget.Qualider.ToString())
                    {
                        this.cmbQualifier.SelectedIndex = i;
                        break;
                    }
                }
            }
            {
                this.cmbType.Items.Clear();
                foreach (var item in this.template.GetAllIntermediateStructures())
                {
                    this.cmbType.Items.Add(item);
                }
                for (int i = 0; i < this.cmbType.Items.Count; i++)
                {
                    if (this.cmbType.Items[i].ToString() == this.clonedTarget.FieldType)
                    {
                        this.cmbType.SelectedIndex = i;
                        break;
                    }
                }
            }

            this.txtValue.Text = this.clonedTarget.FieldValue;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.clonedTarget.Qualider = (FieldQualifier)this.cmbQualifier.SelectedItem;
            this.clonedTarget.FieldType = this.cmbType.SelectedItem.ToString();
            this.clonedTarget.FieldName = this.txtName.Text;

            this.Result = this.clonedTarget;

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
