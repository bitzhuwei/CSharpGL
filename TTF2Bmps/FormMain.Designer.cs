namespace TTF2Bmps
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
            this.openTTFFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowseTTFFile = new System.Windows.Forms.Button();
            this.txtTTFFullname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.txtDestFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveToFolderDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openTTFFileDlg
            // 
            this.openTTFFileDlg.Filter = "(字体文件 *.ttf)|*.ttf";
            // 
            // btnBrowseTTFFile
            // 
            this.btnBrowseTTFFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseTTFFile.Location = new System.Drawing.Point(483, 10);
            this.btnBrowseTTFFile.Name = "btnBrowseTTFFile";
            this.btnBrowseTTFFile.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseTTFFile.TabIndex = 0;
            this.btnBrowseTTFFile.Text = "Browse...";
            this.btnBrowseTTFFile.UseVisualStyleBackColor = true;
            this.btnBrowseTTFFile.Click += new System.EventHandler(this.btnBrowseTTFFile_Click);
            // 
            // txtTTFFullname
            // 
            this.txtTTFFullname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTTFFullname.Location = new System.Drawing.Point(77, 12);
            this.txtTTFFullname.Name = "txtTTFFullname";
            this.txtTTFFullname.ReadOnly = true;
            this.txtTTFFullname.Size = new System.Drawing.Size(400, 21);
            this.txtTTFFullname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "TTF file:";
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFolder.Location = new System.Drawing.Point(483, 37);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFolder.TabIndex = 0;
            this.btnBrowseFolder.Text = "Browse...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // txtDestFolder
            // 
            this.txtDestFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestFolder.Location = new System.Drawing.Point(77, 39);
            this.txtDestFolder.Name = "txtDestFolder";
            this.txtDestFolder.ReadOnly = true;
            this.txtDestFolder.Size = new System.Drawing.Size(400, 21);
            this.txtDestFolder.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "save to:";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(483, 71);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 106);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDestFolder);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.txtTTFFullname);
            this.Controls.Add(this.btnBrowseTTFFile);
            this.Name = "FormMain";
            this.Text = "get bitmaps from a TTF file. (by bitzhuwei @ http://bitzhuwei.cnblogs.com)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openTTFFileDlg;
        private System.Windows.Forms.Button btnBrowseTTFFile;
        private System.Windows.Forms.TextBox txtTTFFullname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.TextBox txtDestFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog saveToFolderDlg;
        private System.Windows.Forms.Button btnStart;
    }
}