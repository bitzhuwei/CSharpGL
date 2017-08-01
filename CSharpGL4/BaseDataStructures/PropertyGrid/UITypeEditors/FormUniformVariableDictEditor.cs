using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

using System.Windows.Forms;

namespace CSharpGL
{
    partial class FormUniformVariableDictEditor : Form
    {
        private ITypeDescriptorContext context;
        private IServiceProvider provider;
        private IDictionary<string, UniformVariable> dict;

        public FormUniformVariableDictEditor(ITypeDescriptorContext context, IServiceProvider provider, IDictionary<string, UniformVariable> dict)
        {
            InitializeComponent();

            this.lblSelectedType.Text = string.Empty;

            this.context = context;
            this.provider = provider;

            if (dict != null)
            {
                foreach (var item in dict)
                {
                    this.lstMember.Items.Add(item.Value);
                }

                this.dict = dict;
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
                    string varName = frmSelectType.VarNameInShader;
                    var obj = Activator.CreateInstance(type, varName) as UniformVariable;
                    this.lstMember.Items.Add(obj);
                    this.dict.Add(varName, obj);
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
                var item = this.lstMember.Items[index] as UniformVariable;
                this.lstMember.Items.RemoveAt(index);
                this.dict.Remove(item.VarName);
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
            if (obj != null)
            { this.lblSelectedType.Text = string.Format("{0}", obj.GetType()); }
            else
            { this.lblSelectedType.Text = string.Format("NULL"); }
        }
    }
}