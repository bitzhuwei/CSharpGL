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
        }

        private void 新建NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.currentFile = new CSSLTemplate();

            Map2UI(this.currentFile);
        }

        private void Map2UI(CSSLTemplate cSSLTemplate)
        {
            throw new NotImplementedException();
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
            this.新建NToolStripMenuItem_Click(sender, e);
        }
    }
}
