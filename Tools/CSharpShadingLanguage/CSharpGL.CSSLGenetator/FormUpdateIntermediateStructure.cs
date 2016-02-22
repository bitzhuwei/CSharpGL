using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.CSSLGenetator
{
    public partial class FormUpdateIntermediateStructure : Form
    {
        public IntermediateStructure Result { get; private set; }

        private CSSLTemplate template;
        private bool isDrag;
        private IntermediateStructure clonedTarget;

        public FormUpdateIntermediateStructure(CSSLTemplate template, IntermediateStructure target)
        {
            InitializeComponent();

            this.template = template;
            this.clonedTarget = target.Clone() as IntermediateStructure;
        }

        private void FormAddVertexShaderField_Load(object sender, EventArgs e)
        {
            this.txtName.Text = this.clonedTarget.Name;
            foreach (var item in this.clonedTarget.FieldList)
            {
                this.lstField.Items.Add(item);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.clonedTarget.Name = this.txtName.Text;
            foreach (var item in this.lstField.Items)
            {
                this.clonedTarget.FieldList.Add(item as StructureField);
            }

            this.Result = this.clonedTarget;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void addAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new FormInsertStructureField(this.template);
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StructureField field = dlg.Result;
                this.lstField.Items.Add(field);
            }
        }

        private void 修改UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstField.SelectedIndex >= 0)
            {
                if ((new FormUpdateStructureField(this.template, this.lstField.SelectedItem as StructureField)).ShowDialog()
                    == System.Windows.Forms.DialogResult.OK)
                {
                    var list = new List<object>();
                    foreach (var item in this.lstField.Items)
                    {
                        list.Add(item);
                    }
                    this.lstField.Items.Clear();
                    foreach (var item in list)
                    {
                        this.lstField.Items.Add(item);
                    }
                }
            }
        }

        private void lstField_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left) { return; }

            isDrag = true;
            var control = sender as ListBox;
            if (control.Items.Count == 0)
            {
                return;
            }
            // int index = control.IndexFromPoint(e.X, e.Y);
            int index = -1;
            for (int i = 0; i < control.Items.Count; i++)
            {//取得选中项的下表
                if (control.GetSelected(i))
                {
                    index = i;
                    break;
                }
            }
            //在指定坐标处找到的项的从零开始的索引；如果找不到匹配项，则返回 ListBox.NoMatches。
            if (index < 0)
            {
                return;
            }
            //index为listbox中的索引
            string s = control.Items[index].ToString();
            // DragDropEffects  指定拖放操作的可能效果
            DragDropEffects dde1 = DoDragDrop(s, DragDropEffects.Move);//开始拖拽操作，s为要拖拽的数据
            if (isDrag)
            {
                if (s == control.Items[index].ToString())
                {
                    control.Items.RemoveAt(index);//是把自己位置的删除掉
                }
                else
                {
                    control.Items.RemoveAt(index + 1);
                }
            }
        }

        private void lstField_DragDrop(object sender, DragEventArgs e)
        {
            //GetDataPresent()确定此实例中存储的数据是否与指定的格式关联，或是否可以转换成指定的格式。
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                var control = sender as ListBox;
                //PointToClient()将指定屏幕点的位置计算成工作区坐标。
                //IndexFromPoint()返回指定坐标处的项的从零开始的索引。
                int indexPos = control.IndexFromPoint(control.PointToClient(new Point(e.X, e.Y)));
                if (indexPos > -1)
                    control.Items.Insert(indexPos, control.SelectedItem);
                else
                    control.Items.Add(control.SelectedItem);
            }
        }

        private void lstField_DragEnter(object sender, DragEventArgs e)
        {
            //GetDataPresent()确定此实例中存储的数据是否与指定的格式关联，或是否可以转换成指定的格式。
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lstField_DragLeave(object sender, EventArgs e)
        {
            isDrag = false;
        }


    }
}
