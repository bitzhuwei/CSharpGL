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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
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
            this.txtFirstChar = new System.Windows.Forms.TextBox();
            this.txtLastChar = new System.Windows.Forms.TextBox();
            this.numMaxTexturWidth = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.saveBmpDlg = new System.Windows.Forms.SaveFileDialog();
            this.txtFirstIndex = new System.Windows.Forms.TextBox();
            this.txtLastIndex = new System.Windows.Forms.TextBox();
            this.rdoFirstChar = new System.Windows.Forms.RadioButton();
            this.rdoFirstIndex = new System.Windows.Forms.RadioButton();
            this.rdoLastChar = new System.Windows.Forms.RadioButton();
            this.rdoLastIndex = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numFontHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTexturWidth)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            //
            // openTTFFileDlg
            //
            this.openTTFFileDlg.Filter = "(字体文件 *.ttf)|*.ttf|(字体文件 *.ttc)|*.ttc|(字体文件 *.*)|*.*";
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
            this.btnStart.Location = new System.Drawing.Point(1019, 152);
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
            // txtFirstChar
            //
            this.txtFirstChar.Location = new System.Drawing.Point(137, 25);
            this.txtFirstChar.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstChar.Name = "txtFirstChar";
            this.txtFirstChar.Size = new System.Drawing.Size(57, 25);
            this.txtFirstChar.TabIndex = 4;
            this.txtFirstChar.Text = "!";
            this.txtFirstChar.TextChanged += new System.EventHandler(this.txtFirstChar_TextChanged);
            //
            // txtLastChar
            //
            this.txtLastChar.Location = new System.Drawing.Point(129, 25);
            this.txtLastChar.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastChar.Name = "txtLastChar";
            this.txtLastChar.Size = new System.Drawing.Size(57, 25);
            this.txtLastChar.TabIndex = 4;
            this.txtLastChar.Text = "~";
            this.txtLastChar.TextChanged += new System.EventHandler(this.txtLastChar_TextChanged);
            //
            // numMaxTexturWidth
            //
            this.numMaxTexturWidth.Location = new System.Drawing.Point(110, 113);
            this.numMaxTexturWidth.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMaxTexturWidth.Minimum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numMaxTexturWidth.Name = "numMaxTexturWidth";
            this.numMaxTexturWidth.Size = new System.Drawing.Size(94, 25);
            this.numMaxTexturWidth.TabIndex = 3;
            this.numMaxTexturWidth.Value = new decimal(new int[] {
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
            // txtFirstIndex
            //
            this.txtFirstIndex.Location = new System.Drawing.Point(137, 58);
            this.txtFirstIndex.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstIndex.Name = "txtFirstIndex";
            this.txtFirstIndex.ReadOnly = true;
            this.txtFirstIndex.Size = new System.Drawing.Size(57, 25);
            this.txtFirstIndex.TabIndex = 4;
            this.txtFirstIndex.Text = "33";
            this.txtFirstIndex.TextChanged += new System.EventHandler(this.txtFirstIndex_TextChanged);
            //
            // txtLastIndex
            //
            this.txtLastIndex.Location = new System.Drawing.Point(129, 58);
            this.txtLastIndex.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastIndex.Name = "txtLastIndex";
            this.txtLastIndex.ReadOnly = true;
            this.txtLastIndex.Size = new System.Drawing.Size(57, 25);
            this.txtLastIndex.TabIndex = 4;
            this.txtLastIndex.Text = "126";
            this.txtLastIndex.TextChanged += new System.EventHandler(this.txtLastIndex_TextChanged);
            //
            // rdoFirstChar
            //
            this.rdoFirstChar.AutoSize = true;
            this.rdoFirstChar.Checked = true;
            this.rdoFirstChar.Location = new System.Drawing.Point(6, 29);
            this.rdoFirstChar.Name = "rdoFirstChar";
            this.rdoFirstChar.Size = new System.Drawing.Size(116, 19);
            this.rdoFirstChar.TabIndex = 6;
            this.rdoFirstChar.TabStop = true;
            this.rdoFirstChar.Text = "first char:";
            this.rdoFirstChar.UseVisualStyleBackColor = true;
            this.rdoFirstChar.CheckedChanged += new System.EventHandler(this.rdoFirstChar_CheckedChanged);
            //
            // rdoFirstIndex
            //
            this.rdoFirstIndex.AutoSize = true;
            this.rdoFirstIndex.Location = new System.Drawing.Point(6, 59);
            this.rdoFirstIndex.Name = "rdoFirstIndex";
            this.rdoFirstIndex.Size = new System.Drawing.Size(124, 19);
            this.rdoFirstIndex.TabIndex = 6;
            this.rdoFirstIndex.Text = "first index:";
            this.rdoFirstIndex.UseVisualStyleBackColor = true;
            this.rdoFirstIndex.CheckedChanged += new System.EventHandler(this.rdoFirstIndex_CheckedChanged);
            //
            // rdoLastChar
            //
            this.rdoLastChar.AutoSize = true;
            this.rdoLastChar.Checked = true;
            this.rdoLastChar.Location = new System.Drawing.Point(6, 29);
            this.rdoLastChar.Name = "rdoLastChar";
            this.rdoLastChar.Size = new System.Drawing.Size(108, 19);
            this.rdoLastChar.TabIndex = 6;
            this.rdoLastChar.TabStop = true;
            this.rdoLastChar.Text = "last char:";
            this.rdoLastChar.UseVisualStyleBackColor = true;
            this.rdoLastChar.CheckedChanged += new System.EventHandler(this.rdoLastChar_CheckedChanged);
            //
            // rdoLastIndex
            //
            this.rdoLastIndex.AutoSize = true;
            this.rdoLastIndex.Location = new System.Drawing.Point(6, 59);
            this.rdoLastIndex.Name = "rdoLastIndex";
            this.rdoLastIndex.Size = new System.Drawing.Size(116, 19);
            this.rdoLastIndex.TabIndex = 6;
            this.rdoLastIndex.Text = "last index:";
            this.rdoLastIndex.UseVisualStyleBackColor = true;
            this.rdoLastIndex.CheckedChanged += new System.EventHandler(this.rdoLastIndex_CheckedChanged);
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.rdoFirstChar);
            this.groupBox1.Controls.Add(this.txtFirstChar);
            this.groupBox1.Controls.Add(this.rdoFirstIndex);
            this.groupBox1.Controls.Add(this.txtFirstIndex);
            this.groupBox1.Location = new System.Drawing.Point(210, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "first unicode";
            //
            // groupBox2
            //
            this.groupBox2.Controls.Add(this.rdoLastChar);
            this.groupBox2.Controls.Add(this.txtLastChar);
            this.groupBox2.Controls.Add(this.rdoLastIndex);
            this.groupBox2.Controls.Add(this.txtLastIndex);
            this.groupBox2.Location = new System.Drawing.Point(428, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "last unicode";
            //
            // FormMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 195);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numMaxTexturWidth);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "get bitmaps from a TTF file. (by bitzhuwei @ http://bitzhuwei.cnblogs.com)";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numFontHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTexturWidth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.TextBox txtFirstChar;
        private System.Windows.Forms.TextBox txtLastChar;
        private System.Windows.Forms.NumericUpDown numMaxTexturWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SaveFileDialog saveBmpDlg;
        private System.Windows.Forms.TextBox txtFirstIndex;
        private System.Windows.Forms.TextBox txtLastIndex;
        private System.Windows.Forms.RadioButton rdoFirstChar;
        private System.Windows.Forms.RadioButton rdoFirstIndex;
        private System.Windows.Forms.RadioButton rdoLastChar;
        private System.Windows.Forms.RadioButton rdoLastIndex;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}