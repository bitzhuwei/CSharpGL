namespace CSharpShadingLanguage.Convertor
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.openCSharpShaderFilesDlg = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowseCSharpShaderFiles = new System.Windows.Forms.Button();
            this.txtCSharpShaderFiles = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.pgbSingleFileProgress = new System.Windows.Forms.ProgressBar();
            this.lblSingleFileProgress = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openCSharpShaderFilesDlg
            // 
            this.openCSharpShaderFilesDlg.Filter = "*.cs|*.cs";
            this.openCSharpShaderFilesDlg.Multiselect = true;
            // 
            // btnBrowseCSharpShaderFiles
            // 
            this.btnBrowseCSharpShaderFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseCSharpShaderFiles.Location = new System.Drawing.Point(1019, 12);
            this.btnBrowseCSharpShaderFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseCSharpShaderFiles.Name = "btnBrowseCSharpShaderFiles";
            this.btnBrowseCSharpShaderFiles.Size = new System.Drawing.Size(100, 29);
            this.btnBrowseCSharpShaderFiles.TabIndex = 0;
            this.btnBrowseCSharpShaderFiles.Text = "Browse...";
            this.btnBrowseCSharpShaderFiles.UseVisualStyleBackColor = true;
            this.btnBrowseCSharpShaderFiles.Click += new System.EventHandler(this.btnBrowseCSharpShaderFiles_Click);
            // 
            // txtCSharpShaderFiles
            // 
            this.txtCSharpShaderFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCSharpShaderFiles.Location = new System.Drawing.Point(143, 15);
            this.txtCSharpShaderFiles.Margin = new System.Windows.Forms.Padding(4);
            this.txtCSharpShaderFiles.Name = "txtCSharpShaderFiles";
            this.txtCSharpShaderFiles.ReadOnly = true;
            this.txtCSharpShaderFiles.Size = new System.Drawing.Size(867, 25);
            this.txtCSharpShaderFiles.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "C#Shader file:";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(1019, 124);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 29);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pgbProgress
            // 
            this.pgbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbProgress.Location = new System.Drawing.Point(650, 124);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(469, 29);
            this.pgbProgress.TabIndex = 9;
            this.pgbProgress.Visible = false;
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // pgbSingleFileProgress
            // 
            this.pgbSingleFileProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbSingleFileProgress.Location = new System.Drawing.Point(650, 74);
            this.pgbSingleFileProgress.Name = "pgbSingleFileProgress";
            this.pgbSingleFileProgress.Size = new System.Drawing.Size(469, 29);
            this.pgbSingleFileProgress.TabIndex = 9;
            this.pgbSingleFileProgress.Visible = false;
            // 
            // lblSingleFileProgress
            // 
            this.lblSingleFileProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSingleFileProgress.AutoSize = true;
            this.lblSingleFileProgress.BackColor = System.Drawing.SystemColors.Control;
            this.lblSingleFileProgress.Location = new System.Drawing.Point(647, 56);
            this.lblSingleFileProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSingleFileProgress.Name = "lblSingleFileProgress";
            this.lblSingleFileProgress.Size = new System.Drawing.Size(151, 15);
            this.lblSingleFileProgress.TabIndex = 2;
            this.lblSingleFileProgress.Text = "singleFileProgress";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(647, 106);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(127, 15);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Working on: {0}";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 167);
            this.Controls.Add(this.pgbSingleFileProgress);
            this.Controls.Add(this.pgbProgress);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblSingleFileProgress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtCSharpShaderFiles);
            this.Controls.Add(this.btnBrowseCSharpShaderFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(853, 207);
            this.Name = "FormMain";
            this.Text = "get GLSL shader from a C#Shader file. (by bitzhuwei @ http://bitzhuwei.cnblogs.co" +
    "m)";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openCSharpShaderFilesDlg;
        private System.Windows.Forms.Button btnBrowseCSharpShaderFiles;
        private System.Windows.Forms.TextBox txtCSharpShaderFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar pgbSingleFileProgress;
        private System.Windows.Forms.Label lblSingleFileProgress;
        private System.Windows.Forms.Label lblTotal;
    }
}