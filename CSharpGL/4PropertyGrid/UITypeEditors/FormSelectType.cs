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
    public partial class FormSelectType : Form
    {

        private Type baseType;

        public FormSelectType(Type baseType)
        {
            InitializeComponent();

            this.baseType = baseType;
        }

        private void FormGLSwtichType_Load(object sender, EventArgs e)
        {
            //if (typeList == null)
            //{ typeList = InitializeTypeList(); }
            List<Type> typeList = InitializeTypeList();

            foreach (var item in typeList)
            {
                this.lstGLSwtichType.Items.Add(item);
            }
        }

        private List<Type> InitializeTypeList()
        {
            var result = new List<Type>();
            Assembly[] assemblies = AssemblyHelper.GetAssemblies(Application.ExecutablePath);
            foreach (var asm in assemblies)
            {
                var list = from item in asm.DefinedTypes
                           where baseType.IsAssignableFrom(item) && (!item.IsAbstract)
                           orderby item.FullName
                           select item;
                foreach (var item in list)
                {
                    result.Add(item);
                }
            }

            result.Sort();

            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.lstGLSwtichType.SelectedItem == null)
            {
                MessageBox.Show("Please select a type first!");
                return;
            }

            this.SelectedType = this.lstGLSwtichType.SelectedItem as Type;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public Type SelectedType { get; set; }
    }
}
