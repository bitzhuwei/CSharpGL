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

namespace CSharpShaderLanguage.Convertor
{
    public partial class FormMain : Form
    {
        string[] selectedTTFFiles;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnBrowseCSharpShaderFile_Click(object sender, EventArgs e)
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
                string message = string.Format("{0}", "Please select a C#Shader file first!");
                MessageBox.Show(message);
                return;
            }

            WorkingSwitch(true);

            this.bgWorker.RunWorkerAsync();
        }

        void WorkingSwitch(bool working)
        {
            bool starting = working;
            bool ended = !working;

            this.btnStart.Enabled = ended;
            this.btnBrowseCSharpShaderFile.Enabled = ended;

            this.pgbProgress.Visible = starting;
            this.pgbSingleFileProgress.Visible = starting;

            this.lblSingleFileProgress.Visible = starting;
            this.lblTotal.Visible = starting;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            WorkingSwitch(false);
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
        }

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
