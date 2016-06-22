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
    partial class FormIListEditor<T> : Form
    {

        IList<T> list;

        public FormIListEditor(IList<T> list)
        {
            InitializeComponent();

            if (list != null)
            {
                foreach (var item in list)
                {
                    this.lstMember.Items.Add(item);
                }

                this.list = list;

                this.Text = string.Format("{0} List Editor", typeof(T).Name);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmSelectType = new FormSelectType(typeof(T));
            if (frmSelectType.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Type type = frmSelectType.SelectedType;
                try
                {
                    T obj;
                    var ctor = (from item in type.GetConstructors() orderby item.GetParameters().Length select item).First();
                    ParameterInfo[] parameterInfos = ctor.GetParameters();
                    if (parameterInfos.Length == 0)
                    { obj = (T)Activator.CreateInstance(type); }
                    else
                    {
                        object[] parameters = new object[parameterInfos.Length];
                        for (int i = 0; i < parameterInfos.Length; i++)
                        {
                            if (parameterInfos[i].ParameterType.IsClass)
                            { parameters[i] = null; }
                            else
                            { parameters[i] = Activator.CreateInstance(parameterInfos[i].ParameterType); }
                        }
                        obj = (T)Activator.CreateInstance(type, parameters);
                    }
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
            if (0 <= index)
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
                T obj = this.list[index];
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
                T obj = this.list[index];
                this.list.RemoveAt(index);

                this.lstMember.Items.Insert(index + 1, item);
                this.list.Insert(index + 1, obj);

                this.lstMember.SelectedIndex = index + 1;
            }
        }

    }
}
