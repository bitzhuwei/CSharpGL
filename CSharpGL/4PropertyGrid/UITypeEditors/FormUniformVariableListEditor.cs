using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL
{
    partial class FormUniformVariableListEditor : Form
    {

        IList<UniformVariable> list;

        public FormUniformVariableListEditor(IList<UniformVariable> list)
        {
            InitializeComponent();

            if (list != null)
            {
                foreach (var item in list)
                {
                    this.lstMember.Items.Add(item);
                }

                this.list = list;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmSelectType = new FormUniformVariableType();
            if (frmSelectType.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Type type = frmSelectType.SelectedType;
                try
                {
                    var obj = Activator.CreateInstance(type, frmSelectType.VarNameInShader) as UniformVariable;
                    this.lstMember.Items.Add(obj);
                    this.list.Add(obj);
                    this.propertyGrid.SelectedObject = obj;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    MessageBox.Show(ex.Message,
                        string.Format("Error when Adding instance of [{0}]!", type.Name));
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int index = this.lstMember.SelectedIndex;
            if (index >= 0)
            {
                this.lstMember.Items.RemoveAt(index);
                this.list.RemoveAt(index);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void lstMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = this.lstMember.SelectedItem;
            this.propertyGrid.SelectedObject = obj;
            this.lblProperty.Text = string.Format("{0}", obj);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            int index = this.lstMember.SelectedIndex;
            if (0 < index)
            {
                object item = this.lstMember.Items[index];
                this.lstMember.Items.RemoveAt(index);
                UniformVariable obj = this.list[index];
                this.list.RemoveAt(index);

                this.lstMember.Items.Insert(index - 1, item);
                this.list.Insert(index - 1, obj);

                this.lstMember.SelectedIndex = index - 1;
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            int index = this.lstMember.SelectedIndex;
            if (0 <= index && index + 1 < this.lstMember.Items.Count)
            {
                object item = this.lstMember.Items[index];
                this.lstMember.Items.RemoveAt(index);
                UniformVariable obj = this.list[index];
                this.list.RemoveAt(index);

                this.lstMember.Items.Insert(index + 1, item);
                this.list.Insert(index + 1, obj);

                this.lstMember.SelectedIndex = index + 1;
            }
        }
    }
}
