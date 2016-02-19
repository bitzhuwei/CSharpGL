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

        public FormMain()
        {
            InitializeComponent();

            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("CSSL generator - {0}", this.currentFile.Fullname);
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

        private void addAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
