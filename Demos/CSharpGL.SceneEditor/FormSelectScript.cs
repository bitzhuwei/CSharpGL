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

namespace CSharpGL.SceneEditor
{
    partial class FormSelectScript : Form
    {
        public FormSelectScript()
        {
            InitializeComponent();
        }

        private void FormGLSwtichType_Load(object sender, EventArgs e)
        {
            if (typeList == null)
            { typeList = InitializeTypeList(); }

            foreach (var item in typeList)
            {
                this.lstGLSwtichType.Items.Add(item);
            }
        }

        private List<Type> InitializeTypeList()
        {
            var result = new List<Type>();
            Type type = typeof(ScriptComponent);
            Assembly executingAsm = Assembly.GetExecutingAssembly();
            Assembly[] assemblies;
            {
                assemblies = AssemblyHelper.GetAssemblys(executingAsm.Location);
            }
            foreach (var asm in assemblies)
            {
                var list = from item in asm.DefinedTypes
                           where type.IsAssignableFrom(item) && (!item.IsAbstract)
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

        static List<Type> typeList;

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
