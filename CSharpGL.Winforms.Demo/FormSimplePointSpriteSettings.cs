using CSharpGL.Objects.SceneElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Winforms.Demo
{
    public partial class FormSimplePointSpriteSettings : Form
    {
        public FormSimplePointSpriteSettings()
        {
            InitializeComponent();
        }

        private void FormSimplePointSpriteSettings_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(FragShaderType)))
            {
                this.cmbFragShaderType.Items.Add(item);
            }

            this.cmbFragShaderType.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public float FontSize
        {
            get { return float.Parse(this.txtFontSize.Text); }
        }

        public bool Foreshortening
        {
            get { return this.chkforeshortening.Checked; }
        }

        public FragShaderType FragmentShaderType
        {
            get { return (FragShaderType)this.cmbFragShaderType.SelectedItem; }
        }
    }
}
