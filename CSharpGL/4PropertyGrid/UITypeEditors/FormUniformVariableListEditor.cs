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
    partial class FormUniformVariableListEditor : Form
    {

        public FormUniformVariableListEditor(List<UniformVariable> list)
        {
            InitializeComponent();

            if (list != null)
            {
                foreach (var item in list)
                {
                    this.lstMember.Items.Add(item);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmSelectType = new FormUniformVariableType();
            if (frmSelectType.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Type type = frmSelectType.SelectedType;
                object obj = Activator.CreateInstance(type, frmSelectType.VarNameInShader);
                this.lstMember.Items.Add(obj);
                this.propertyGrid.SelectedObject = obj;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int index = this.lstMember.SelectedIndex;
            if (index >= 0)
            {
                this.lstMember.Items.RemoveAt(index);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var list = new List<UniformVariable>();
            foreach (UniformVariable item in this.lstMember.Items)
            {
                list.Add(item);
            }

            this.UniformVariableList = list;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public List<UniformVariable> UniformVariableList { get; set; }

        private void lstMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = this.lstMember.SelectedItem;
            this.propertyGrid.SelectedObject = obj;
            this.lblProperty.Text = string.Format("{0}", obj);
        }

    }
}
