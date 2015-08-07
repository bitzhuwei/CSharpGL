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

            try
            {
                string fontFullname = this.txtTTFFullname.Text;
                int fontHeight = (int)numFontHeight.Value;
                int maxTexturWidth = (int)numMaxTexturWidth.Value;
                char firstChar = (char)int.Parse(this.txtFirstIndex.Text);
                char lastChar = (char)int.Parse(this.txtLastIndex.Text);
                string destFullname = this.txtDestFilename.Text;

                var ttfTexture = TTFTexture.GetTTFTexture(fontFullname, fontHeight, firstChar, lastChar, maxTexturWidth);

                ttfTexture.BigBitmap.Save(destFullname);

                Process.Start("explorer", destFullname);
            }
            catch (Exception ex)
            {
                string message = string.Format("{0}", ex);
                MessageBox.Show(message);
            }
        }

        private void txtTTFFullname_DoubleClick(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtTTFFullname.Text))
            { return; }

            FileInfo ttfFile = new FileInfo(this.txtTTFFullname.Text);
            this.txtDestFilename.Text = Path.Combine(ttfFile.DirectoryName, ttfFile.Name + ".png");
        }



        private void FormMain_Load(object sender, EventArgs e)
        {
            char firstChar = this.txtFirstChar.Text.First();
            this.txtFirstChar.Text = firstChar.ToString();
            int firstIndex = (int)firstChar;
            this.txtFirstIndex.Text = firstIndex.ToString();

            char lastChar = this.txtLastChar.Text.First();
            this.txtLastChar.Text = lastChar.ToString();
            int lastIndex = (int)lastChar;
            this.txtLastIndex.Text = lastIndex.ToString();
        }

        private void rdoFirstChar_CheckedChanged(object sender, EventArgs e)
        {
            this.txtFirstChar.ReadOnly = !this.rdoFirstChar.Checked;
            this.txtFirstIndex.ReadOnly = this.rdoFirstChar.Checked;
        }

        private void rdoFirstIndex_CheckedChanged(object sender, EventArgs e)
        {
            this.txtFirstChar.ReadOnly = this.rdoFirstIndex.Checked;
            this.txtFirstIndex.ReadOnly = !this.rdoFirstIndex.Checked;
        }

        private void rdoLastChar_CheckedChanged(object sender, EventArgs e)
        {
            this.txtLastChar.ReadOnly = !this.rdoLastChar.Checked;
            this.txtLastIndex.ReadOnly = this.rdoLastChar.Checked;
        }

        private void rdoLastIndex_CheckedChanged(object sender, EventArgs e)
        {
            this.txtLastChar.ReadOnly = this.rdoLastIndex.Checked;
            this.txtLastIndex.ReadOnly = !this.rdoLastIndex.Checked;
        }

        private void txtFirstChar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFirstChar.Text)) { return; }

            if(this.rdoFirstChar.Checked)
            {
                char firstChar = this.txtFirstChar.Text.First();
                int firstIndex = (int)firstChar;
                this.txtFirstIndex.Text = firstIndex.ToString();
            }
        }

        private void txtFirstIndex_TextChanged(object sender, EventArgs e)
        {
            if(this.rdoFirstIndex.Checked)
            {
                int value;
                if(int.TryParse(this.txtFirstIndex.Text, out value))
                {
                    if (value < 0) { value = 0; }
                    else if (value > char.MaxValue) { value = char.MaxValue; }

                    char firstChar = (char)value;
                    this.txtFirstChar.Text = firstChar.ToString();
                    this.txtFirstIndex.Text = value.ToString();
                }
            }
        }

        private void txtLastChar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtLastChar.Text)) { return; }

            if (this.rdoLastChar.Checked)
            {
                char lastChar = this.txtLastChar.Text.First();
                int lastIndex = (int)lastChar;
                this.txtLastIndex.Text = lastIndex.ToString();
            }
        }

        private void txtLastIndex_TextChanged(object sender, EventArgs e)
        {
            if (this.rdoLastIndex.Checked)
            {
                int value;
                if (int.TryParse(this.txtLastIndex.Text, out value))
                {
                    if (value < 0) { value = 0; }
                    else if (value > char.MaxValue) { value = char.MaxValue; }

                    char lastChar = (char)value;
                    this.txtLastChar.Text = lastChar.ToString();
                    this.txtLastIndex.Text = value.ToString();
                }
            }
        }

    }
}
