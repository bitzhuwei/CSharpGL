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
    partial class FormUniformVariableType : Form
    {

        private static List<Type> cachedList;

        private Type baseType;
        private bool forceReload;

        /// <summary>
        /// Select a type from all types that derived from specified base type.
        /// </summary>
        /// <param name="forceReload">reload types that derived from specified base type.</param>
        public FormUniformVariableType(bool forceReload = false)
        {
            InitializeComponent();

            this.baseType = typeof(UniformVariable);
            this.forceReload = forceReload;
        }

        private void FormUniformVariableType_Load(object sender, EventArgs e)
        {
            List<Type> typeList;

            if (this.forceReload)
            {
                typeList = this.baseType.GetAllDerivedTypes();
                cachedList = typeList;
            }
            else
            {
                if (cachedList == null)
                {
                    typeList = this.baseType.GetAllDerivedTypes();
                    cachedList = typeList;
                }
                else
                { typeList = cachedList; }
            }

            foreach (var item in typeList)
            {
                this.lstType.Items.Add(item);
            }
        }

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
            if (string.IsNullOrEmpty(this.txtVarNameInShader.Text.Trim()))
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
