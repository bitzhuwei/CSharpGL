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
            this.txtDestFilename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numFontHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFirstChar = new System.Windows.Forms.TextBox();
            this.txtLastChar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numMaxWidth = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.saveBmpDlg = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numFontHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxWidth)).BeginInit();
            this.SuspendLayout();
            //
            // openTTFFileDlg
            //
            this.openTTFFileDlg.Filter = "(字体文件 *.ttf)|*.ttf";
            //
            // btnBrowseTTFFile
            //
            this.btnBrowseTTFFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseTTFFile.Location = new System.Drawing.Point(1019, 12);
            this.btnBrowseTTFFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseTTFFile.Name = "btnBrowseTTFFile";
            this.btnBrowseTTFFile.Size = new System.Drawing.Size(100, 29);
            this.btnBrowseTTFFile.TabIndex = 0;
            this.btnBrowseTTFFile.Text = "Browse...";
            this.btnBrowseTTFFile.UseVisualStyleBackColor = true;
            this.btnBrowseTTFFile.Click += new System.EventHandler(this.btnBrowseTTFFile_Click);
            //
            // txtTTFFullname
            //
            this.txtTTFFullname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTTFFullname.Location = new System.Drawing.Point(110, 15);
            this.txtTTFFullname.Margin = new System.Windows.Forms.Padding(4);
            this.txtTTFFullname.Name = "txtTTFFullname";
            this.txtTTFFullname.ReadOnly = true;
            this.txtTTFFullname.Size = new System.Drawing.Size(900, 25);
            this.txtTTFFullname.TabIndex = 1;
            this.txtTTFFullname.DoubleClick += new System.EventHandler(this.txtTTFFullname_DoubleClick);
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "TTF file:";
            //
            // btnBrowseFolder
            //
            this.btnBrowseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFolder.Location = new System.Drawing.Point(1019, 46);
            this.btnBrowseFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(100, 29);
            this.btnBrowseFolder.TabIndex = 0;
            this.btnBrowseFolder.Text = "Browse...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            //
            // txtDestFilename
            //
            this.txtDestFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestFilename.Location = new System.Drawing.Point(110, 49);
            this.txtDestFilename.Margin = new System.Windows.Forms.Padding(4);
            this.txtDestFilename.Name = "txtDestFilename";
            this.txtDestFilename.ReadOnly = true;
            this.txtDestFilename.Size = new System.Drawing.Size(900, 25);
            this.txtDestFilename.TabIndex = 1;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "save to:";
            //
            // btnStart
            //
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(1019, 122);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 29);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "height:";
            //
            // numFontHeight
            //
            this.numFontHeight.Location = new System.Drawing.Point(110, 82);
            this.numFontHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numFontHeight.Minimum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numFontHeight.Name = "numFontHeight";
            this.numFontHeight.Size = new System.Drawing.Size(94, 25);
            this.numFontHeight.TabIndex = 3;
            this.numFontHeight.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "first char:";
            //
            // txtFirstChar
            //
            this.txtFirstChar.Location = new System.Drawing.Point(314, 82);
            this.txtFirstChar.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstChar.Name = "txtFirstChar";
            this.txtFirstChar.Size = new System.Drawing.Size(57, 25);
            this.txtFirstChar.TabIndex = 4;
            this.txtFirstChar.Text = "!";
            //
            // txtLastChar
            //
            this.txtLastChar.Location = new System.Drawing.Point(474, 82);
            this.txtLastChar.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastChar.Name = "txtLastChar";
            this.txtLastChar.Size = new System.Drawing.Size(57, 25);
            this.txtLastChar.TabIndex = 4;
            this.txtLastChar.Text = "~";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(379, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "last char:";
            //
            // numMaxWidth
            //
            this.numMaxWidth.Location = new System.Drawing.Point(110, 113);
            this.numMaxWidth.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMaxWidth.Minimum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numMaxWidth.Name = "numMaxWidth";
            this.numMaxWidth.Size = new System.Drawing.Size(94, 25);
            this.numMaxWidth.TabIndex = 3;
            this.numMaxWidth.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 115);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "max width:";
            //
            // saveBmpDlg
            //
            this.saveBmpDlg.Filter = "*.bmp|*.bmp|*.*|*.*";
            //
            // FormMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 165);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLastChar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFirstChar);
            this.Controls.Add(this.numMaxWidth);
            this.Controls.Add(this.numFontHeight);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDestFilename);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.txtTTFFullname);
            this.Controls.Add(this.btnBrowseTTFFile);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "get bitmaps from a TTF file. (by bitzhuwei @ http://bitzhuwei.cnblogs.com)";
            ((System.ComponentModel.ISupportInitialize)(this.numFontHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openTTFFileDlg;
        private System.Windows.Forms.Button btnBrowseTTFFile;
        private System.Windows.Forms.TextBox txtTTFFullname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.TextBox txtDestFilename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numFontHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFirstChar;
        private System.Windows.Forms.TextBox txtLastChar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numMaxWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SaveFileDialog saveBmpDlg;
    }
}