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

namespace Font2Bmps
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

            //this.btnStart.Enabled = false;
            //this.btnBrowseTTFFile.Enabled = false;
            //this.numFontHeight.Enabled = false;
            //this.numMaxTexturWidth.Enabled = false;
            //this.gbFirstUnicode.Enabled = false;
            //this.gbLastUnicode.Enabled = false;
            //this.chkGlyphList.Enabled = false;
            //this.chkFontHeightLine.Enabled = false;

            //this.pgbProgress.Visible = true;
            //this.pgbSingleFileProgress.Visible = true;
            WorkingSwitch(true);

            int fontHeight = (int)numFontHeight.Value;
            int maxTexturWidth = (int)numMaxTexturWidth.Value;
            char firstChar = (char)int.Parse(this.txtFirstIndex.Text);
            char lastChar = (char)int.Parse(this.txtLastIndex.Text);
            bool generateGlyphList = this.chkGlyphList.Checked;
            bool drawHeightLine = this.chkFontHeightLine.Checked;
            WorkerData data = new WorkerData(fontHeight, maxTexturWidth,
                firstChar, lastChar, this.selectedTTFFiles,
                generateGlyphList, drawHeightLine);
            this.bgWorker.RunWorkerAsync(data);
        }

        void WorkingSwitch(bool working)
        {
            bool starting = working;
            bool ended = !working;

            this.btnStart.Enabled = ended;
            this.btnBrowseTTFFile.Enabled = ended;
            this.numFontHeight.Enabled = ended;
            this.numMaxTexturWidth.Enabled = ended;
            this.gbFirstUnicode.Enabled = ended;
            this.gbLastUnicode.Enabled = ended;
            this.chkGlyphList.Enabled = ended;
            this.chkFontHeightLine.Enabled = ended;

            this.pgbProgress.Visible = starting;
            this.pgbSingleFileProgress.Visible = starting;

            //this.lblSingleFileProgress.Text = string.Empty;
            //this.lblTotal.Text = string.Empty;
            this.lblSingleFileProgress.Visible = starting;
            this.lblTotal.Visible = starting;
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

            WorkingSwitch(false);
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
            int index = 1;
            const int magicNumber = 100;

            WorkerResult result = new WorkerResult(null, data);
            e.Result = result;

            StringBuilder builder = new StringBuilder();

            foreach (var fontFullname in this.selectedTTFFiles)
            {
                builder.Append(index); builder.Append("/"); builder.Append(count);
                builder.Append(": "); builder.AppendLine(fontFullname);

                string destFullname = fontFullname + ".png";

                FontTexture ttfTexture = null;

                try
                {
                    foreach (var progress in FontTextureYieldHelper.GetTTFTexture(
                        fontFullname, data.fontHeight, data.firstChar, data.lastChar, data.maxTexturWidth))
                    {
                        ttfTexture = progress.ttfTexture;
                        var singleFileProgress = new SingleFileProgress() { progress = progress.percent, message = progress.message };
                        bgWorker.ReportProgress(index * magicNumber / count, singleFileProgress);
                    }

                    if(data.drawHeightLine)
                    {
                        System.Drawing.Bitmap bigBitmap = new System.Drawing.Bitmap(ttfTexture.BigBitmap);
                        Graphics g = Graphics.FromImage(bigBitmap);
                        for (int row = 0; row < bigBitmap.Height; row += ttfTexture.FontHeight)
                        {
                            g.DrawLine(redDotPen, new Point(0, row - 1), new Point(bigBitmap.Width, row - 1));
                        }
                        bigBitmap.Save(destFullname);
                        bigBitmap.Dispose();
                    }
                    else
                    {
                        ttfTexture.BigBitmap.Save(destFullname);
                    }

                    {
                        FontTextureXmlPrinter printer = new FontTextureXmlPrinter(ttfTexture);
                        printer.Print(fontFullname);
                    }

                    if (data.generateGlyphList)
                    {
                        FontTexturePNGPrinter printer = new FontTexturePNGPrinter(ttfTexture);
                        foreach (var progress in printer.Print(fontFullname, data.maxTexturWidth))
                        {
                            bgWorker.ReportProgress(index * magicNumber / count, progress);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string message = string.Format("{0}", ex);
                    builder.AppendLine(message);
                    result.builder = builder;
                }

                builder.AppendLine("sucessfully done!");
                builder.AppendLine();

                if (ttfTexture != null) { ttfTexture.Dispose(); }

                FileInfo fileInfo = new FileInfo(fontFullname);
                SingleFileProgress thisFileDone = new SingleFileProgress()
                {
                    progress = magicNumber,
                    message = string.Format("All is done for {0}", fileInfo.Name),
                };
                bgWorker.ReportProgress(index++ * magicNumber / count, thisFileDone);
                //bgWorker.ReportProgress(magicNumber, thisFileDone);

                //Process.Start("explorer", destFullname);
            }
        }

        Pen redDotPen = new Pen(Color.Red) { DashStyle = System.Drawing.Drawing2D.DashStyle.Custom, DashPattern = new float[] { 5, 5 } };
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            {
                var value = e.ProgressPercentage;
                if (value < pgbProgress.Minimum) value = pgbProgress.Minimum;
                if (value > pgbProgress.Maximum) value = pgbProgress.Maximum;
                pgbProgress.Value = value;
                this.lblTotal.Text = string.Format("Total: {0}%", value);
            }
            {
                SingleFileProgress progress = e.UserState as SingleFileProgress;
                var value = progress.progress;
                if (value < pgbSingleFileProgress.Minimum) value = pgbSingleFileProgress.Minimum;
                if (value > pgbSingleFileProgress.Maximum) value = pgbSingleFileProgress.Maximum;
                pgbSingleFileProgress.Value = value;

                this.lblSingleFileProgress.Text = progress.message;
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WorkerResult result = e.Result as WorkerResult;
            FileInfo file = new FileInfo(result.data.selectedTTFFiles[0]);

            string directory = file.DirectoryName;
            if (result.builder != null)
            {
                try
                {
                    string log = file.FullName + ".log";
                    File.WriteAllText(log, result.builder.ToString());
                    Process.Start("explorer", log);
                }
                catch (Exception ex)
                {
                    string message = string.Format("{0}", ex);
                    MessageBox.Show(message);
                }
            }

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
            pgbSingleFileProgress.Value = pgbSingleFileProgress.Minimum;

            //this.btnStart.Enabled = true;
            //this.btnBrowseTTFFile.Enabled = true;
            //this.numFontHeight.Enabled = true;
            //this.numMaxTexturWidth.Enabled = true;
            //this.gbFirstUnicode.Enabled = true;
            //this.gbLastUnicode.Enabled = true;
            //this.chkGlyphList.Enabled = true;
            //this.chkFontHeightLine.Enabled = true;

            //this.pgbProgress.Visible = false;
            //this.pgbSingleFileProgress.Visible = false;
            WorkingSwitch(false);
        }

    }
}
