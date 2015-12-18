namespace CSharpGL.Winforms.Demo
{
    partial class FormVolumeRendering04
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
            this.cmbRenderOrder = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.glCanvas1 = new CSharpGL.Winforms.GLCanvas();
            this.chkBlend = new System.Windows.Forms.CheckBox();
            this.cmbDFactor = new System.Windows.Forms.ComboBox();
            this.cmbSFactor = new System.Windows.Forms.ComboBox();
            this.trackAlpha = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAlphaThreshold = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblCameraType = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAlpha)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbRenderOrder
            // 
            this.cmbRenderOrder.FormattingEnabled = true;
            this.cmbRenderOrder.Location = new System.Drawing.Point(135, 104);
            this.cmbRenderOrder.Name = "cmbRenderOrder";
            this.cmbRenderOrder.Size = new System.Drawing.Size(248, 23);
            this.cmbRenderOrder.TabIndex = 14;
            this.cmbRenderOrder.SelectedIndexChanged += new System.EventHandler(this.cmbRenderOrder_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "render order:";
            // 
            // glCanvas1
            // 
            this.glCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glCanvas1.Location = new System.Drawing.Point(13, 149);
            this.glCanvas1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.OpenGLVersion = CSharpGL.Objects.RenderContexts.GLVersion.OpenGL2_1;
            this.glCanvas1.RenderTrigger = CSharpGL.Winforms.RenderTriggers.TimerBased;
            this.glCanvas1.Size = new System.Drawing.Size(762, 393);
            this.glCanvas1.TabIndex = 0;
            // 
            // chkBlend
            // 
            this.chkBlend.AutoSize = true;
            this.chkBlend.Checked = true;
            this.chkBlend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBlend.Location = new System.Drawing.Point(18, 78);
            this.chkBlend.Name = "chkBlend";
            this.chkBlend.Size = new System.Drawing.Size(69, 19);
            this.chkBlend.TabIndex = 15;
            this.chkBlend.Text = "blend";
            this.chkBlend.UseVisualStyleBackColor = true;
            this.chkBlend.CheckedChanged += new System.EventHandler(this.chkBlend_CheckedChanged);
            // 
            // cmbDFactor
            // 
            this.cmbDFactor.FormattingEnabled = true;
            this.cmbDFactor.Location = new System.Drawing.Point(409, 74);
            this.cmbDFactor.Name = "cmbDFactor";
            this.cmbDFactor.Size = new System.Drawing.Size(248, 23);
            this.cmbDFactor.TabIndex = 14;
            this.cmbDFactor.SelectedIndexChanged += new System.EventHandler(this.cmbDFactor_SelectedIndexChanged);
            // 
            // cmbSFactor
            // 
            this.cmbSFactor.FormattingEnabled = true;
            this.cmbSFactor.Location = new System.Drawing.Point(99, 75);
            this.cmbSFactor.Name = "cmbSFactor";
            this.cmbSFactor.Size = new System.Drawing.Size(248, 23);
            this.cmbSFactor.TabIndex = 14;
            this.cmbSFactor.SelectedIndexChanged += new System.EventHandler(this.cmbSFactor_SelectedIndexChanged);
            // 
            // trackAlpha
            // 
            this.trackAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackAlpha.Location = new System.Drawing.Point(110, 12);
            this.trackAlpha.Maximum = 100;
            this.trackAlpha.Name = "trackAlpha";
            this.trackAlpha.Size = new System.Drawing.Size(620, 56);
            this.trackAlpha.TabIndex = 8;
            this.trackAlpha.Value = 5;
            this.trackAlpha.Scroll += new System.EventHandler(this.trackAlpha_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Alpha阀值：";
            // 
            // lblAlphaThreshold
            // 
            this.lblAlphaThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlphaThreshold.AutoSize = true;
            this.lblAlphaThreshold.Location = new System.Drawing.Point(736, 13);
            this.lblAlphaThreshold.Name = "lblAlphaThreshold";
            this.lblAlphaThreshold.Size = new System.Drawing.Size(39, 15);
            this.lblAlphaThreshold.TabIndex = 11;
            this.lblAlphaThreshold.Text = "0.05";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "图片文件(*.jpg,*.gif,*.bmp,*.png)|*.jpg;*.gif;*.bmp;*.png";
            // 
            // lblCameraType
            // 
            this.lblCameraType.Name = "lblCameraType";
            this.lblCameraType.Size = new System.Drawing.Size(126, 20);
            this.lblCameraType.Text = "camera type: {0}";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCameraType});
            this.statusStrip1.Location = new System.Drawing.Point(0, 546);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(788, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // FormVolumeRendering04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 571);
            this.Controls.Add(this.chkBlend);
            this.Controls.Add(this.cmbDFactor);
            this.Controls.Add(this.cmbRenderOrder);
            this.Controls.Add(this.cmbSFactor);
            this.Controls.Add(this.lblAlphaThreshold);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackAlpha);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.glCanvas1);
            this.Name = "FormVolumeRendering04";
            this.Text = "FormVolumeRendering04-3d texture(points) in modern opengl-double order render";
            this.Load += new System.EventHandler(this.FormSatelliteRotation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAlpha)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRenderOrder;
        private System.Windows.Forms.Label label3;
        private GLCanvas glCanvas1;
        private System.Windows.Forms.CheckBox chkBlend;
        private System.Windows.Forms.ComboBox cmbDFactor;
        private System.Windows.Forms.ComboBox cmbSFactor;
        private System.Windows.Forms.TrackBar trackAlpha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAlphaThreshold;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripStatusLabel lblCameraType;
        private System.Windows.Forms.StatusStrip statusStrip1;


    }
}