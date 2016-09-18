using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// Select a type from all types that derived from specified base type.
    /// </summary>
    public partial class FormSelectType : Form
    {
        private static Dictionary<Type, List<Type>> dict = new Dictionary<Type, List<Type>>();

        private readonly Type baseType;
        private readonly bool forceReload;
        private Func<Type, bool> addtionalFilter;

        /// <summary>
        /// Select a type from all types that derived from specified base type.
        /// </summary>
        /// <param name="baseType">base type.</param>
        /// <param name="forceReload">reload types that derived from specified base type.
        /// <para>Set this to true if new assemblies loaded or old assemblies removed.</para></param>
        /// <param name="addtionalFilter">addtional filter.</param>
        public FormSelectType(Type baseType, bool forceReload = false, Func<Type, bool> addtionalFilter = null)
        {
            InitializeComponent();

            this.baseType = baseType;
            this.forceReload = forceReload;
            if (addtionalFilter == null)
            {
                this.addtionalFilter = x => !x.IsAbstract;
            }
            else
            {
                this.addtionalFilter = addtionalFilter;
            }

            this.Text = string.Format("Select type derived from {0}", baseType);
        }

        private void FormGLSwtichType_Load(object sender, EventArgs e)
        {
            List<Type> typeList;

            if (this.forceReload)
            {
                typeList = this.baseType.GetAllDerivedTypes(this.addtionalFilter);
                if (dict.ContainsKey(this.baseType))
                { dict[this.baseType] = typeList; }
                else
                { dict.Add(this.baseType, typeList); }
            }
            else
            {
                if (dict.ContainsKey(this.baseType))
                { typeList = dict[this.baseType]; }
                else
                {
                    typeList = this.baseType.GetAllDerivedTypes(this.addtionalFilter);
                    dict.Add(this.baseType, typeList);
                }
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

            this.SelectedType = this.lstType.SelectedItem as Type;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        ///
        /// </summary>
        public Type SelectedType { get; set; }

        private void lstType_DoubleClick(object sender, EventArgs e)
        {
            btnOK_Click(sender, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<Type> typeList = this.baseType.GetAllDerivedTypes(this.addtionalFilter);
            dict[this.baseType] = typeList;
            this.lstType.Items.Clear();
            foreach (var item in typeList)
            {
                this.lstType.Items.Add(item);
            }
        }
    }
}