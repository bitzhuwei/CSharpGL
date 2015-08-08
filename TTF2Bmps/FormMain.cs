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
        string[] selectedTTFFiles;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnBrowseTTFFile_Click(object sender, EventArgs e)
        {
            if (openTTFFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.selectedTTFFiles = openTTFFileDlg.FileNames;
                StringBuilder builder = new StringBuilder();
                foreach (var item in openTTFFileDlg.FileNames)
                {
                    builder.Append("\"");
                    builder.Append(item);
                    builder.Append("\" ");
                }

                this.txtTTFFullname.Text = builder.ToString();

                txtTTFFullname_DoubleClick(sender, e);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTTFFullname.Text) || this.selectedTTFFiles == null)
            {
                string message = string.Format("{0}", "Please select a TTF file first!");
                MessageBox.Show(message);
                return;
            }

            //if (string.IsNullOrEmpty(this.txtDestFilename.Text))
            //{
            //    string message = string.Format("{0}", "Please select the path to save bitmaps to first!");
            //    MessageBox.Show(message);
            //    return;
            //}

            this.btnStart.Enabled = false;
            this.btnBrowseTTFFile.Enabled = false;
            this.numFontHeight.Enabled = false;
            this.numMaxTexturWidth.Enabled = false;
            this.gbFirstUnicode.Enabled = false;
            this.gbLastUnicode.Enabled = false;
            this.pgbProgress.Visible = true;

            int fontHeight = (int)numFontHeight.Value;
            int maxTexturWidth = (int)numMaxTexturWidth.Value;
            char firstChar = (char)int.Parse(this.txtFirstIndex.Text);
            char lastChar = (char)int.Parse(this.txtLastIndex.Text);
            WorkerData data = new WorkerData(fontHeight, maxTexturWidth, firstChar, lastChar, this.selectedTTFFiles);
            this.bgWorker.RunWorkerAsync(data);


        }

        private void txtTTFFullname_DoubleClick(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(this.txtTTFFullname.Text))
            //{ return; }

            //FileInfo ttfFile = new FileInfo(this.txtTTFFullname.Text);
            //this.txtDestFilename.Text = Path.Combine(ttfFile.DirectoryName, ttfFile.Name + ".png");
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

            if (this.rdoFirstChar.Checked)
            {
                char firstChar = this.txtFirstChar.Text.First();
                int firstIndex = (int)firstChar;
                this.txtFirstIndex.Text = firstIndex.ToString();
            }
        }

        private void txtFirstIndex_TextChanged(object sender, EventArgs e)
        {
            if (this.rdoFirstIndex.Checked)
            {
                int value;
                if (int.TryParse(this.txtFirstIndex.Text, out value))
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

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            WorkerData data = e.Argument as WorkerData;
            int count = data.selectedTTFFiles.Length;
            int index = 0;

            StringBuilder builder = new StringBuilder();
            WorkerResult result = new WorkerResult(builder, data);
            e.Result = result;

            foreach (var item in this.selectedTTFFiles)
            {
                try
                {
                    string fontFullname = item;
                    builder.Append(index); builder.Append("/"); builder.Append(count);
                    builder.Append(": "); builder.AppendLine(fontFullname);

                    string destFullname = fontFullname + ".png";

                    var ttfTexture = TTFTexture.GetTTFTexture(fontFullname,
                        data.fontHeight, data.firstChar, data.lastChar, data.maxTexturWidth);

                    ttfTexture.BigBitmap.Save(destFullname);
                    ttfTexture.Dispose();

                    bgWorker.ReportProgress(index++ * 100 / count);

                    //Process.Start("explorer", destFullname);
                }
                catch (ArgumentException ex)
                {
                    string message = string.Format("{0}", ex);
                    builder.AppendLine(message);
                    builder.AppendLine("Please try a smaller font height.");
                    //MessageBox.Show(message);
                    //MessageBox.Show("Please try a smaller font height.");
                }
                catch (Exception ex)
                {
                    string message = string.Format("{0}", ex);
                    builder.AppendLine(message);
                    //MessageBox.Show(message);
                }
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var value = e.ProgressPercentage;
            if (value < pgbProgress.Minimum) value = pgbProgress.Minimum;
            if (value > pgbProgress.Maximum) value = pgbProgress.Maximum;
            pgbProgress.Value = value;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            WorkerResult result = e.Result as WorkerResult;
            FileInfo file = new FileInfo(result.data.selectedTTFFiles[0]);
            string log = file.FullName + ".log";
            File.WriteAllText(log, result.builder.ToString());
            Process.Start("explorer", log);

            string directory = file.DirectoryName;

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString(), "发生异常");
                if (MessageBox.Show("是否打开保存结果的文件夹？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    Process.Start("explorer", directory);
                }
            }
            else if (e.Cancelled)
            {
                if (MessageBox.Show("您取消了操作，是否打开保存结果的文件夹？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    Process.Start("explorer", directory);
                }
            }
            else
            {
                if (MessageBox.Show("操作已完成，是否打开保存结果的文件夹？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    Process.Start("explorer", directory);
                }

            }

            pgbProgress.Value = pgbProgress.Minimum;

            this.btnStart.Enabled = true;
            this.btnBrowseTTFFile.Enabled = true;
            this.numFontHeight.Enabled = true;
            this.numMaxTexturWidth.Enabled = true;
            this.gbFirstUnicode.Enabled = true;
            this.gbLastUnicode.Enabled = true;
            this.pgbProgress.Visible = false;
        }

    }
}
