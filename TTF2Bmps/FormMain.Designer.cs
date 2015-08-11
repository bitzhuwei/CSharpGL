namespace Font2Bmps
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
            this.btnStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numFontHeight = new System.Windows.Forms.NumericUpDown();
            this.txtFirstChar = new System.Windows.Forms.TextBox();
            this.txtLastChar = new System.Windows.Forms.TextBox();
            this.numMaxTexturWidth = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFirstIndex = new System.Windows.Forms.TextBox();
            this.txtLastIndex = new System.Windows.Forms.TextBox();
            this.rdoFirstChar = new System.Windows.Forms.RadioButton();
            this.rdoFirstIndex = new System.Windows.Forms.RadioButton();
            this.rdoLastChar = new System.Windows.Forms.RadioButton();
            this.rdoLastIndex = new System.Windows.Forms.RadioButton();
            this.gbFirstUnicode = new System.Windows.Forms.GroupBox();
            this.gbLastUnicode = new System.Windows.Forms.GroupBox();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.pgbSingleFileProgress = new System.Windows.Forms.ProgressBar();
            this.chkDumpGlyphList = new System.Windows.Forms.CheckBox();
            this.lblSingleFileProgress = new System.Windows.Forms.Label();
            this.chkDrawBBox = new System.Windows.Forms.CheckBox();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numFontHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTexturWidth)).BeginInit();
            this.gbFirstUnicode.SuspendLayout();
            this.gbLastUnicode.SuspendLayout();
            this.SuspendLayout();
            //
            // openTTFFileDlg
            //
            this.openTTFFileDlg.Filter = "(字体文件 *.ttf;*.ttc)|*.ttf;*.ttc|(字体文件 *.*)|*.*";
            this.openTTFFileDlg.Multiselect = true;
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
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "height:";
            //
            // numFontHeight
            //
            this.numFontHeight.Location = new System.Drawing.Point(110, 48);
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
            30,
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
            this.txtLastChar.Text = "龟";
            this.txtLastChar.TextChanged += new System.EventHandler(this.txtLastChar_TextChanged);
            //
            // numMaxTexturWidth
            //
            this.numMaxTexturWidth.Location = new System.Drawing.Point(110, 79);
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
            16384,
            0,
            0,
            0});
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 81);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "max width:";
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
            // gbFirstUnicode
            //
            this.gbFirstUnicode.Controls.Add(this.rdoFirstChar);
            this.gbFirstUnicode.Controls.Add(this.txtFirstChar);
            this.gbFirstUnicode.Controls.Add(this.rdoFirstIndex);
            this.gbFirstUnicode.Controls.Add(this.txtFirstIndex);
            this.gbFirstUnicode.Location = new System.Drawing.Point(210, 47);
            this.gbFirstUnicode.Name = "gbFirstUnicode";
            this.gbFirstUnicode.Size = new System.Drawing.Size(212, 100);
            this.gbFirstUnicode.TabIndex = 7;
            this.gbFirstUnicode.TabStop = false;
            this.gbFirstUnicode.Text = "first unicode";
            //
            // gbLastUnicode
            //
            this.gbLastUnicode.Controls.Add(this.rdoLastChar);
            this.gbLastUnicode.Controls.Add(this.txtLastChar);
            this.gbLastUnicode.Controls.Add(this.rdoLastIndex);
            this.gbLastUnicode.Controls.Add(this.txtLastIndex);
            this.gbLastUnicode.Location = new System.Drawing.Point(428, 47);
            this.gbLastUnicode.Name = "gbLastUnicode";
            this.gbLastUnicode.Size = new System.Drawing.Size(212, 100);
            this.gbLastUnicode.TabIndex = 8;
            this.gbLastUnicode.TabStop = false;
            this.gbLastUnicode.Text = "last unicode";
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
            // chkGlyphList
            //
            this.chkDumpGlyphList.AutoSize = true;
            this.chkDumpGlyphList.Location = new System.Drawing.Point(19, 110);
            this.chkDumpGlyphList.Name = "chkGlyphList";
            this.chkDumpGlyphList.Size = new System.Drawing.Size(109, 19);
            this.chkDumpGlyphList.TabIndex = 10;
            this.chkDumpGlyphList.Text = "Dump glyph list";
            this.chkDumpGlyphList.UseVisualStyleBackColor = true;
            //
            // lblSingleFileProgress
            //
            this.lblSingleFileProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSingleFileProgress.AutoSize = true;
            this.lblSingleFileProgress.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSingleFileProgress.Location = new System.Drawing.Point(647, 56);
            this.lblSingleFileProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSingleFileProgress.Name = "lblSingleFileProgress";
            this.lblSingleFileProgress.Size = new System.Drawing.Size(151, 15);
            this.lblSingleFileProgress.TabIndex = 2;
            this.lblSingleFileProgress.Text = "singleFileProgress";
            //
            // chkFontHeightLine
            //
            this.chkDrawBBox.AutoSize = true;
            this.chkDrawBBox.Checked = true;
            this.chkDrawBBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDrawBBox.Location = new System.Drawing.Point(19, 135);
            this.chkDrawBBox.Name = "chkFontHeightLine";
            this.chkDrawBBox.Size = new System.Drawing.Size(117, 19);
            this.chkDrawBBox.TabIndex = 10;
            this.chkDrawBBox.Text = "Draw BBox";
            this.chkDrawBBox.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.chkDrawBBox);
            this.Controls.Add(this.chkDumpGlyphList);
            this.Controls.Add(this.pgbSingleFileProgress);
            this.Controls.Add(this.pgbProgress);
            this.Controls.Add(this.gbLastUnicode);
            this.Controls.Add(this.gbFirstUnicode);
            this.Controls.Add(this.numMaxTexturWidth);
            this.Controls.Add(this.numFontHeight);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblSingleFileProgress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtTTFFullname);
            this.Controls.Add(this.btnBrowseTTFFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(853, 207);
            this.Name = "FormMain";
            this.Text = "get bitmaps from a TTF file. (by bitzhuwei @ http://bitzhuwei.cnblogs.com)";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numFontHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTexturWidth)).EndInit();
            this.gbFirstUnicode.ResumeLayout(false);
            this.gbFirstUnicode.PerformLayout();
            this.gbLastUnicode.ResumeLayout(false);
            this.gbLastUnicode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openTTFFileDlg;
        private System.Windows.Forms.Button btnBrowseTTFFile;
        private System.Windows.Forms.TextBox txtTTFFullname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numFontHeight;
        private System.Windows.Forms.TextBox txtFirstChar;
        private System.Windows.Forms.TextBox txtLastChar;
        private System.Windows.Forms.NumericUpDown numMaxTexturWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFirstIndex;
        private System.Windows.Forms.TextBox txtLastIndex;
        private System.Windows.Forms.RadioButton rdoFirstChar;
        private System.Windows.Forms.RadioButton rdoFirstIndex;
        private System.Windows.Forms.RadioButton rdoLastChar;
        private System.Windows.Forms.RadioButton rdoLastIndex;
        private System.Windows.Forms.GroupBox gbFirstUnicode;
        private System.Windows.Forms.GroupBox gbLastUnicode;
        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar pgbSingleFileProgress;
        private System.Windows.Forms.CheckBox chkDumpGlyphList;
        private System.Windows.Forms.Label lblSingleFileProgress;
        private System.Windows.Forms.CheckBox chkDrawBBox;
        private System.Windows.Forms.Label lblTotal;
    }
}