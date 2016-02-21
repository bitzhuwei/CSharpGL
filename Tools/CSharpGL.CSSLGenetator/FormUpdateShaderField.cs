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
        private ShaderField target;

        public FormUpdateShaderField(CSSLTemplate template, ShaderField target)
        {
            InitializeComponent();

            this.template = template;
            this.target = target;
        }

        private void FormAddVertexShaderField_Load(object sender, EventArgs e)
        {
            this.txtName.Text = this.target.FieldName;

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
                    if (this.cmbQualifier.Items[i].ToString() == this.target.Qualider.ToString())
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
                    if (this.cmbType.Items[i].ToString() == this.target.FieldType)
                    {
                        this.cmbType.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.target.Qualider = (FieldQualifier)this.cmbQualifier.SelectedItem;
            this.target.FieldType = this.cmbType.SelectedItem.ToString();
            this.target.FieldName = this.txtName.Text;
            this.target.PropertyType = PropertyType.Other;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
