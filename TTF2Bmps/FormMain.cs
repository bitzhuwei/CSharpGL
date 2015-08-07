using CSharpGL;
using CSharpGL.Objects.Texts;
using CSharpGL.Objects.Texts.FreeTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTF2Bmps
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnBrowseTTFFile_Click(object sender, EventArgs e)
        {
            if (openTTFFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtTTFFullname.Text = openTTFFileDlg.FileName;

                txtTTFFullname_DoubleClick(sender, e);
            }
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            if(saveBmpDlg.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                this.txtDestFilename.Text = saveBmpDlg.FileName;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTTFFullname.Text))
            {
                string message = string.Format("{0}", "Please select a TTF file first!");
                MessageBox.Show(message);
                return;
            }

            if (string.IsNullOrEmpty(this.txtDestFilename.Text))
            {
                string message = string.Format("{0}", "Please select the path to save bitmaps to first!");
                MessageBox.Show(message);
                return;
            }

            if (this.txtFirstChar.Text.Length != 1)
            {
                string message = string.Format("{0}", "Please type in only 1 char for the 'first char'!");
                MessageBox.Show(message);
                return;
            }

            if (this.txtLastChar.Text.Length != 1)
            {
                string message = string.Format("{0}", "Please type in only 1 char for the 'last char'!");
                MessageBox.Show(message);
                return;
            }

            string fontFullname = this.txtTTFFullname.Text;
            int fontHeight = (int)numFontHeight.Value;
            int maxWidth = (int)numMaxWidth.Value;
            char firstChar = this.txtFirstChar.Text.First();
            char lastChar = this.txtLastChar.Text.First();
            string destFullname = this.txtDestFilename.Text;
            var bmpGenerator = new ModernSingleTextureFont(fontFullname, fontHeight, firstChar, lastChar, maxWidth);
			System.Drawing.Bitmap bitmap = bmpGenerator.GetBitmap();
            bitmap.Save(destFullname);
			bitmap.Dispose();

            Process.Start("explorer", destFullname);
        }

        private void txtTTFFullname_DoubleClick(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtTTFFullname.Text))
            { return; }

            FileInfo ttfFile = new FileInfo(this.txtTTFFullname.Text);
            string bmpFilename = ttfFile.Name.Substring(0, ttfFile.Name.Length - ".ttf".Length);
            this.txtDestFilename.Text = string.Format("{0}\\{1}.png", ttfFile.DirectoryName, bmpFilename);
        }

    }
}
