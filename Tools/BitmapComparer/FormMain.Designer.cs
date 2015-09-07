namespace BitmapComparer
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBitmapFullname2 = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.txtBitmapFullname1 = new System.Windows.Forms.TextBox();
            this.btnBrowseBMP1 = new System.Windows.Forms.Button();
            this.openBmpDlg = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "bitmap 2:";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "bitmap 1:";
            //
            // txtBitmapFullname2
            //
            this.txtBitmapFullname2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBitmapFullname2.Location = new System.Drawing.Point(103, 50);
            this.txtBitmapFullname2.Margin = new System.Windows.Forms.Padding(4);
            this.txtBitmapFullname2.Name = "txtBitmapFullname2";
            this.txtBitmapFullname2.ReadOnly = true;
            this.txtBitmapFullname2.Size = new System.Drawing.Size(907, 25);
            this.txtBitmapFullname2.TabIndex = 10;
            //
            // btnStart
            //
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(1019, 93);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 29);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            //
            // btnBrowseFolder
            //
            this.btnBrowseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFolder.Location = new System.Drawing.Point(1019, 47);
            this.btnBrowseFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(100, 29);
            this.btnBrowseFolder.TabIndex = 6;
            this.btnBrowseFolder.Text = "Browse...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseBMP2_Click);
            //
            // txtBitmapFullname1
            //
            this.txtBitmapFullname1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBitmapFullname1.Location = new System.Drawing.Point(103, 16);
            this.txtBitmapFullname1.Margin = new System.Windows.Forms.Padding(4);
            this.txtBitmapFullname1.Name = "txtBitmapFullname1";
            this.txtBitmapFullname1.ReadOnly = true;
            this.txtBitmapFullname1.Size = new System.Drawing.Size(907, 25);
            this.txtBitmapFullname1.TabIndex = 9;
            //
            // btnBrowseBMP1
            //
            this.btnBrowseBMP1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseBMP1.Location = new System.Drawing.Point(1019, 13);
            this.btnBrowseBMP1.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseBMP1.Name = "btnBrowseBMP1";
            this.btnBrowseBMP1.Size = new System.Drawing.Size(100, 29);
            this.btnBrowseBMP1.TabIndex = 8;
            this.btnBrowseBMP1.Text = "Browse...";
            this.btnBrowseBMP1.UseVisualStyleBackColor = true;
            this.btnBrowseBMP1.Click += new System.EventHandler(this.btnBrowseBMP1_Click);
            //
            // openBmpDlg
            //
            this.openBmpDlg.Filter = "*.*|*.*";
            //
            // FormMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 135);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBitmapFullname2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.txtBitmapFullname1);
            this.Controls.Add(this.btnBrowseBMP1);
            this.Name = "FormMain";
            this.Text = "Compare bitmaps using GetPixel()";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBitmapFullname2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.TextBox txtBitmapFullname1;
        private System.Windows.Forms.Button btnBrowseBMP1;
        private System.Windows.Forms.OpenFileDialog openBmpDlg;
    }
}