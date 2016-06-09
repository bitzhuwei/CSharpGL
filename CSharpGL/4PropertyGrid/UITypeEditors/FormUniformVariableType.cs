using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL
{
    public partial class FormUniformVariableType : Form
    {
        public FormUniformVariableType()
        {
            InitializeComponent();
        }

        private void FormGLSwtichType_Load(object sender, EventArgs e)
        {
            if (tyepList == null)
            { tyepList = InitializeTypeList(); }

            foreach (var item in tyepList)
            {
                this.lstType.Items.Add(item);
            }
        }

        private List<Type> InitializeTypeList()
        {
            Type type = typeof(UniformVariableBase);
            Assembly asm = Assembly.GetAssembly(type);
            var result = (from item in asm.ExportedTypes
                          where type.IsAssignableFrom(item) && (!item.IsAbstract)
                          select item).ToList();
            return result;
        }

        static List<Type> tyepList;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.lstType.SelectedItem == null)
            {
                MessageBox.Show("Please select a type first!");
                return;
            }
            if(string.IsNullOrEmpty(this.txtVarNameInShader.Text))
            {
                MessageBox.Show("Please type in the variable name in Vertex Shader!");
                return;
            }

            this.SelectedType = this.lstType.SelectedItem as Type;
            this.VarNameInShader = this.txtVarNameInShader.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public Type SelectedType { get; set; }

        public string VarNameInShader { get; set; }
    }
}
