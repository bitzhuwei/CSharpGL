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
    public partial class FormMain : Form
    {
        CSSLTemplate currentFile;
        private bool isDrag;

        public FormMain()
        {
            InitializeComponent();

            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("CSSL Generator - {0}", this.currentFile.Fullname);
        }

        private void 新建NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.currentFile = new CSSLTemplate();

            Map2UI(this.currentFile);
        }

        private void Map2UI(CSSLTemplate template)
        {
            this.txtShaderName.Text = template.ShaderName;
            {
                for (int index = 0; index < this.cmbShaderProgramType.Items.Count; index++)
                {
                    if (this.cmbShaderProgramType.Items[index].ToString() == template.ProgramType.ToString())
                    {
                        this.cmbShaderProgramType.SelectedIndex = index;
                        break;
                    }
                }
            }
            {
                this.lstVertexShaderField.Items.Clear();
                foreach (var item in template.VertexShaderFieldList)
                {
                    this.lstVertexShaderField.Items.Add(item);
                }
            }
            {
                this.lstGeometryShaderField.Items.Clear();
                foreach (var item in template.GeometryShaderFieldList)
                {
                    this.lstGeometryShaderField.Items.Add(item);
                }
            }
            {
                this.lstFragmentShaderField.Items.Clear();
                foreach (var item in template.FragmentShaderFieldList)
                {
                    this.lstFragmentShaderField.Items.Add(item);
                }
            }
            {
                this.lstStructure.Items.Clear();
                foreach (var item in template.StrutureList)
                {
                    this.lstStructure.Items.Add(item);
                }
            }

        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.currentFile = CSSLTemplate.Load(this.openFileDlg.FileName);

                Map2UI(this.currentFile);
            }
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.currentFile.Fullname))
            {
                if (this.saveFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.currentFile.Fullname = this.saveFileDlg.FileName;
                }
            }

            this.currentFile.Save();
        }

        private void 另存为AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CSSLTemplate newFile = ((ICloneable)this.currentFile).Clone() as CSSLTemplate;

            if (this.saveFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                newFile.Fullname = this.saveFileDlg.FileName;
                newFile.Save();
                this.currentFile = newFile;
            }
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            {
                ShaderProgramType[] types = new ShaderProgramType[] 
                {
                   ShaderProgramType.VertexFragment, 
                   ShaderProgramType.VertexGeometryFragment,
                };
                if (types.Length != Enum.GetNames(typeof(ShaderProgramType)).Length)
                {
                    throw new Exception("not all members are included in types.");
                }
                this.cmbShaderProgramType.Items.Clear();
                foreach (var item in types)
                {
                    this.cmbShaderProgramType.Items.Add(item);
                }
            }
            this.新建NToolStripMenuItem_Click(sender, e);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Map2Template(this.currentFile);

            保存SToolStripMenuItem_Click(sender, e);

            this.currentFile.Generate();
        }

        private void Map2Template(CSSLTemplate cSSLTemplate)
        {
            this.currentFile.ShaderName = this.txtShaderName.Text;
            this.currentFile.ProgramType = (ShaderProgramType)(this.cmbShaderProgramType.SelectedItem);
            {
                this.currentFile.VertexShaderFieldList.Clear();
                foreach (var item in this.lstVertexShaderField.Items)
                {
                    ShaderField shaderField = item as ShaderField;
                    this.currentFile.VertexShaderFieldList.Add(shaderField);
                }
            }
            {
                this.currentFile.GeometryShaderFieldList.Clear();
                foreach (var item in this.lstGeometryShaderField.Items)
                {
                    ShaderField shaderField = item as ShaderField;
                    this.currentFile.GeometryShaderFieldList.Add(shaderField);
                }
            }
            {
                this.currentFile.FragmentShaderFieldList.Clear();
                foreach (var item in this.lstFragmentShaderField.Items)
                {
                    ShaderField shaderField = item as ShaderField;
                    this.currentFile.FragmentShaderFieldList.Add(shaderField);
                }
            }
            {
                this.currentFile.StrutureList.Clear();
                foreach (var item in this.lstStructure.Items)
                {
                    IntermediateStructure structure = item as IntermediateStructure;
                    this.currentFile.StrutureList.Add(structure);
                }
            }
        }

        private void vertexShaderAddField_Click(object sender, EventArgs e)
        {
            var dlg = new FormInsertVertexShaderField(this.currentFile);
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ShaderField field = dlg.Result;
                this.lstVertexShaderField.Items.Add(field);
                this.currentFile.VertexShaderFieldList.Add(field);
            }
        }

        private void geometryShaderAddField_Click(object sender, EventArgs e)
        {
            var dlg = new FormInsertShaderField(this.currentFile);
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ShaderField field = dlg.Result;
                this.lstGeometryShaderField.Items.Add(field);
                this.currentFile.GeometryShaderFieldList.Add(field);
            }
        }

        private void fragmentShaderAddField_Click(object sender, EventArgs e)
        {
            var dlg = new FormInsertShaderField(this.currentFile);
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ShaderField field = dlg.Result;
                this.lstFragmentShaderField.Items.Add(field);
                this.currentFile.FragmentShaderFieldList.Add(field);
            }
        }

        private void addIntermediateStructure_Click(object sender, EventArgs e)
        {
            var dlg = new FormInsertIntermediateStructure(this.currentFile);
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IntermediateStructure field = dlg.Result;
                this.lstStructure.Items.Add(field);
                this.currentFile.StrutureList.Add(field);
            }
        }

        private void RemoveVertexShaderFIeld_Click(object sender, EventArgs e)
        {
            if (this.lstVertexShaderField.SelectedIndex >= 0)
            {
                ShaderField field = this.lstVertexShaderField.SelectedItem as ShaderField;
                this.currentFile.VertexShaderFieldList.Remove(field);
                this.lstVertexShaderField.Items.Remove(field);
            }
        }

        private void RemoveGeometryShaderFIeld_Click(object sender, EventArgs e)
        {
            if (this.lstGeometryShaderField.SelectedIndex >= 0)
            {
                ShaderField field = this.lstGeometryShaderField.SelectedItem as ShaderField;
                this.currentFile.GeometryShaderFieldList.Remove(field);
                this.lstGeometryShaderField.Items.Remove(field);
            }
        }

        private void RemoveFragmentShaderField_Click(object sender, EventArgs e)
        {
            if (this.lstFragmentShaderField.SelectedIndex >= 0)
            {
                ShaderField field = this.lstFragmentShaderField.SelectedItem as ShaderField;
                this.currentFile.FragmentShaderFieldList.Remove(field);
                this.lstFragmentShaderField.Items.Remove(field);
            }
        }

        private void cmbShaderProgramType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((ShaderProgramType)(this.cmbShaderProgramType.SelectedItem))
            {
                case ShaderProgramType.VertexFragment:
                    this.lstGeometryShaderField.Visible = false;
                    break;
                case ShaderProgramType.VertexGeometryFragment:
                    this.lstGeometryShaderField.Visible = true;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void lstVertexShaderField_DragDrop(object sender, DragEventArgs e)
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

        private void lstVertexShaderField_DragEnter(object sender, DragEventArgs e)
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

        private void lstVertexShaderField_MouseDown(object sender, MouseEventArgs e)
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

        private void lstVertexShaderField_DragLeave(object sender, EventArgs e)
        {
            isDrag = false;
            var control = sender as ListBox;
            //PointToClient()将指定屏幕点的位置计算成工作区坐标。
            //IndexFromPoint()返回指定坐标处的项的从零开始的索引。
            if (control == this.lstVertexShaderField)
            {
                this.currentFile.VertexShaderFieldList.Clear();
                foreach (var item in control.Items)
                {
                    this.currentFile.VertexShaderFieldList.Add(item as ShaderField);
                }
            }
            else if (control == this.lstGeometryShaderField)
            {
                this.currentFile.GeometryShaderFieldList.Clear();
                foreach (var item in control.Items)
                {
                    this.currentFile.GeometryShaderFieldList.Add(item as ShaderField);
                }
            }
            else if (control == this.lstFragmentShaderField)
            {
                this.currentFile.FragmentShaderFieldList.Clear();
                foreach (var item in control.Items)
                {
                    this.currentFile.FragmentShaderFieldList.Add(item as ShaderField);
                }
            }
            else if (control == this.lstStructure)
            {
                this.currentFile.StrutureList.Clear();
                foreach (var item in control.Items)
                {
                    this.currentFile.StrutureList.Add(item as IntermediateStructure);
                }
            }
        }

        private void UpdateVertexShaderField_Click(object sender, EventArgs e)
        {
            if (this.lstVertexShaderField.SelectedIndex >= 0)
            {
                if ((new FormUpdateVertexShaderField(
                     this.currentFile, this.lstVertexShaderField.SelectedItem as ShaderField)).ShowDialog()
                    == System.Windows.Forms.DialogResult.OK)
                {
                    this.lstVertexShaderField.Items.Clear();
                    foreach (var item in this.currentFile.VertexShaderFieldList)
                    {
                        this.lstVertexShaderField.Items.Add(item);
                    }
                }
            }
        }

        private void UpdateGeometryShaderField_Click(object sender, EventArgs e)
        {
            if (this.lstGeometryShaderField.SelectedIndex >= 0)
            {
                if ((new FormUpdateShaderField(
                     this.currentFile, this.lstGeometryShaderField.SelectedItem as ShaderField)).ShowDialog()
                    == System.Windows.Forms.DialogResult.OK)
                {
                    this.lstGeometryShaderField.Items.Clear();
                    foreach (var item in this.currentFile.GeometryShaderFieldList)
                    {
                        this.lstGeometryShaderField.Items.Add(item);
                    }
                }
            }
        }

        private void UpdateFragmentShaderField_Click(object sender, EventArgs e)
        {
            if (this.lstFragmentShaderField.SelectedIndex >= 0)
            {
                if ((new FormUpdateShaderField(
                     this.currentFile, this.lstFragmentShaderField.SelectedItem as ShaderField)).ShowDialog()
                    == System.Windows.Forms.DialogResult.OK)
                {
                    this.lstFragmentShaderField.Items.Clear();
                    foreach (var item in this.currentFile.FragmentShaderFieldList)
                    {
                        this.lstFragmentShaderField.Items.Add(item);
                    }
                }
            }
        }

        private void UpdateFieldStructure_Click(object sender, EventArgs e)
        {

        }

    }
}
