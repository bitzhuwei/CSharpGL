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

            WorkingSwitch(true);

            int fontHeight = (int)numFontHeight.Value;
            int maxTexturWidth = (int)numMaxTexturWidth.Value;
            char firstChar = (char)int.Parse(this.txtFirstIndex.Text);
            char lastChar = (char)int.Parse(this.txtLastIndex.Text);
            bool generateGlyphList = this.chkDumpGlyphList.Checked;
            bool drawBBox = this.chkDrawBBox.Checked;
            WorkerData data = new WorkerData(fontHeight, maxTexturWidth,
                firstChar, lastChar, this.selectedTTFFiles,
                generateGlyphList, drawBBox);
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
            this.chkDumpGlyphList.Enabled = ended;
            this.chkDrawBBox.Enabled = ended;

            this.pgbProgress.Visible = starting;
            this.pgbSingleFileProgress.Visible = starting;

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
            int fontFileCount = data.selectedTTFFiles.Length;
            int fontFileIndex = 1;
            const int magicNumber = 100;

            WorkerResult result = new WorkerResult(null, data);
            e.Result = result;

            StringBuilder builder = new StringBuilder();

            foreach (var fontFullname in this.selectedTTFFiles)
            {
                builder.Append(fontFileIndex); builder.Append("/"); builder.Append(fontFileCount);
                builder.Append(": "); builder.AppendLine(fontFullname);

                FileInfo fileInfo = new FileInfo(fontFullname);
                string fontName = fileInfo.Name;
                string destFullname = fontFullname + ".png";

                FontTexture ttfTexture = null;

                try
                {
                    {
                        int lastPercent = 0;
                        foreach (var progress in FontTextureYieldHelper.GetTTFTexture(
                            fontFullname, data.fontHeight, data.maxTexturWidth, data.firstChar, data.lastChar))
                        {
                            ttfTexture = progress.ttfTexture;
                            if (progress.percent != lastPercent)
                            {
                                var singleFileProgress = new SingleFileProgress() { fontName = fontName, progress = progress.percent, message = progress.message };
                                bgWorker.ReportProgress(fontFileIndex * magicNumber / fontFileCount, singleFileProgress);
                                lastPercent = progress.percent;
                            }
                        }
                    }

                    System.Drawing.Bitmap bigBitmap = ttfTexture.BigBitmap;
                    if (data.drawBBox)
                    {
                        Graphics g = Graphics.FromImage(bigBitmap);
                        int vertialLineIndex = 0;
                        int characterCount = ttfTexture.CharInfoDict.Values.Count;
                        int lastPercent = 0;
                        foreach (var item in ttfTexture.CharInfoDict.Values)
                        {
                            int left = item.xoffset;
                            int right = item.xoffset + item.width - 1;
                            int top = item.yoffset;
                            int bottom = item.yoffset + ttfTexture.FontHeight - 1;
                            Point[] points = new Point[] { new Point(left, top), new Point(right, top), new Point(right, bottom), new Point(left, bottom), new Point(left, top) };
                            g.DrawLines(pen, points);

                            int percent = vertialLineIndex++ * 100 / characterCount;
                            if (percent != lastPercent)
                            {
                                var singleFileProgress = new SingleFileProgress() { fontName = fontName, progress = percent, message = "drawing bboxes" };
                                bgWorker.ReportProgress(fontFileIndex * magicNumber / fontFileCount, singleFileProgress);
                                lastPercent = percent;
                            }
                        }
                        g.Dispose();
                        bigBitmap.Save(destFullname);
                    }

                    bigBitmap.Save(destFullname);

                    {
                        FontTextureXmlPrinter printer = new FontTextureXmlPrinter(ttfTexture);
                        printer.Print(fontFullname);
                    }

                    if (data.generateGlyphList)
                    {
                        FontTexturePNGPrinter printer = new FontTexturePNGPrinter(ttfTexture);
                        foreach (var progress in printer.Print(fontFullname, data.maxTexturWidth))
                        {
                            bgWorker.ReportProgress(fontFileIndex * magicNumber / fontFileCount, progress);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string message = string.Format("{0}", ex);
                    builder.AppendLine(message);
                    result.builder = builder;
                }

                if (ttfTexture != null) { ttfTexture.Dispose(); }

                if (result.builder != builder) { builder.AppendLine("sucessfully done!"); }
                builder.AppendLine();

                SingleFileProgress thisFileDone = new SingleFileProgress()
                {
                    fontName = fontName,
                    progress = magicNumber,
                    message = string.Format("All is done for {0}", fileInfo.Name),
                };
                bgWorker.ReportProgress(fontFileIndex++ * magicNumber / fontFileCount, thisFileDone);
            }
        }

        const int horizontalFactor = 1;
        Pen pen = new Pen(Color.Red) { DashStyle = System.Drawing.Drawing2D.DashStyle.Custom, DashPattern = new float[] { horizontalFactor, horizontalFactor }, };

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SingleFileProgress progress = e.UserState as SingleFileProgress;
            {
                var value = e.ProgressPercentage;
                if (value < pgbProgress.Minimum) value = pgbProgress.Minimum;
                if (value > pgbProgress.Maximum) value = pgbProgress.Maximum;
                pgbProgress.Value = value;
                this.lblTotal.Text = string.Format("Working on: {0}", progress.fontName);
            }
            {
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

            WorkingSwitch(false);
        }

    }
}
