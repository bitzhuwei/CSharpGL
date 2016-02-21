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
    public partial class FormUpdateVertexShaderField : Form
    {

        public ShaderField Result { get; private set; }

        private CSSLTemplate template;

        public FormUpdateVertexShaderField(CSSLTemplate template)
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
            {
                PropertyType[] qualifiers = new PropertyType[]
                {
                    PropertyType.Other,
                    PropertyType.Position,
                    PropertyType.Color,
                    PropertyType.Normal,
                };
                this.cmbPropertyType.Items.Clear();
                foreach (var item in qualifiers)
                {
                    this.cmbPropertyType.Items.Add(item);
                }
                this.cmbPropertyType.SelectedIndex = 0;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Result = new ShaderField()
            {
                Qualider = (FieldQualifier)this.cmbQualifier.SelectedItem,
                FieldType = this.cmbType.SelectedItem.ToString(),
                FieldName = this.txtName.Text,
                PropertyType = (PropertyType)this.cmbPropertyType.SelectedItem,
            };

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void cmbQualifier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((FieldQualifier)(this.cmbQualifier.SelectedItem) == FieldQualifier.In)
            {
                this.lblPropertyType.Visible = true;
                this.cmbPropertyType.Visible = true;
            }
            else
            {
                this.lblPropertyType.Visible = false;
                this.cmbPropertyType.Visible = false;
                this.cmbPropertyType.SelectedIndex = 0;
            }
        }
    }
}
