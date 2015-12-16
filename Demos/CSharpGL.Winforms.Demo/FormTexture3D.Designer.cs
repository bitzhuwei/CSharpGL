namespace CSharpGL.Winforms.Demo
{
    partial class FormTexture3D
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
            this.glCanvas1 = new CSharpGL.Winforms.GLCanvas();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCameraType = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTextureFile = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cmbInternalformat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFormat = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glCanvas1
            // 
            this.glCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glCanvas1.Location = new System.Drawing.Point(13, 73);
            this.glCanvas1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.OpenGLVersion = CSharpGL.Objects.RenderContexts.GLVersion.OpenGL2_1;
            this.glCanvas1.RenderTrigger = CSharpGL.Winforms.RenderTriggers.TimerBased;
            this.glCanvas1.Size = new System.Drawing.Size(774, 407);
            this.glCanvas1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCameraType});
            this.statusStrip1.Location = new System.Drawing.Point(0, 484);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblCameraType
            // 
            this.lblCameraType.Name = "lblCameraType";
            this.lblCameraType.Size = new System.Drawing.Size(126, 20);
            this.lblCameraType.Text = "camera type: {0}";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Texture:";
            // 
            // txtTextureFile
            // 
            this.txtTextureFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextureFile.Location = new System.Drawing.Point(145, 12);
            this.txtTextureFile.Name = "txtTextureFile";
            this.txtTextureFile.Size = new System.Drawing.Size(539, 25);
            this.txtTextureFile.TabIndex = 3;
            this.txtTextureFile.Text = "DemoTexImage2D.bmp";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(690, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(97, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cmbInternalformat
            // 
            this.cmbInternalformat.FormattingEnabled = true;
            this.cmbInternalformat.Location = new System.Drawing.Point(145, 43);
            this.cmbInternalformat.Name = "cmbInternalformat";
            this.cmbInternalformat.Size = new System.Drawing.Size(121, 23);
            this.cmbInternalformat.TabIndex = 5;
            this.cmbInternalformat.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "internalformat:";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "format:";
            this.label3.Visible = false;
            // 
            // cmbFormat
            // 
            this.cmbFormat.FormattingEnabled = true;
            this.cmbFormat.Location = new System.Drawing.Point(341, 43);
            this.cmbFormat.Name = "cmbFormat";
            this.cmbFormat.Size = new System.Drawing.Size(121, 23);
            this.cmbFormat.TabIndex = 8;
            this.cmbFormat.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(690, 43);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(97, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "图片文件(*.jpg,*.gif,*.bmp,*.png)|*.jpg;*.gif;*.bmp;*.png";
            // 
            // FormTexImage2D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 509);
            this.Controls.Add(this.cmbFormat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbInternalformat);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtTextureFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.glCanvas1);
            this.Name = "FormTexImage2D";
            this.Text = "FormTexImage2D";
            this.Load += new System.EventHandler(this.FormSatelliteRotation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GLCanvas glCanvas1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblCameraType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTextureFile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox cmbInternalformat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFormat;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}