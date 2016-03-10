using CSharpGL.Winforms;
namespace Radar.Winform
{
    partial class FormVolumeRendering00
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblExport3DTexture = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.trackAlpha = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAlphaThreshold = new System.Windows.Forms.Label();
            this.glCanvas1 = new CSharpGL.Winforms.GLCanvas();
            this.trackNegativeZ = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPositiveZ = new System.Windows.Forms.Label();
            this.trackPositiveZ = new System.Windows.Forms.TrackBar();
            this.lblNegativeZ = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackNegativeZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPositiveZ)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblExport3DTexture});
            this.statusStrip1.Location = new System.Drawing.Point(0, 546);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(715, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblExport3DTexture
            // 
            this.lblExport3DTexture.Name = "lblExport3DTexture";
            this.lblExport3DTexture.Size = new System.Drawing.Size(119, 20);
            this.lblExport3DTexture.Text = "点此导出3D贴图";
            this.lblExport3DTexture.Click += new System.EventHandler(this.lblExport3DTexture_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // trackAlpha
            // 
            this.trackAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackAlpha.Location = new System.Drawing.Point(110, 12);
            this.trackAlpha.Maximum = 100;
            this.trackAlpha.Name = "trackAlpha";
            this.trackAlpha.Size = new System.Drawing.Size(547, 56);
            this.trackAlpha.TabIndex = 4;
            this.trackAlpha.Value = 5;
            this.trackAlpha.Scroll += new System.EventHandler(this.trackAlpha_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Alpha阀值：";
            // 
            // lblAlphaThreshold
            // 
            this.lblAlphaThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlphaThreshold.AutoSize = true;
            this.lblAlphaThreshold.Location = new System.Drawing.Point(663, 13);
            this.lblAlphaThreshold.Name = "lblAlphaThreshold";
            this.lblAlphaThreshold.Size = new System.Drawing.Size(39, 15);
            this.lblAlphaThreshold.TabIndex = 5;
            this.lblAlphaThreshold.Text = "0.05";
            // 
            // glCanvas1
            // 
            this.glCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glCanvas1.Location = new System.Drawing.Point(13, 137);
            this.glCanvas1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.OpenGLVersion = CSharpGL.Objects.RenderContexts.GLVersion.OpenGL2_1;
            this.glCanvas1.RenderTrigger = CSharpGL.Winforms.RenderTriggers.TimerBased;
            this.glCanvas1.Size = new System.Drawing.Size(689, 408);
            this.glCanvas1.TabIndex = 3;
            // 
            // trackNegativeZ
            // 
            this.trackNegativeZ.Location = new System.Drawing.Point(93, 75);
            this.trackNegativeZ.Maximum = 0;
            this.trackNegativeZ.Minimum = -100;
            this.trackNegativeZ.Name = "trackNegativeZ";
            this.trackNegativeZ.Size = new System.Drawing.Size(248, 56);
            this.trackNegativeZ.TabIndex = 4;
            this.trackNegativeZ.Value = -100;
            this.trackNegativeZ.Scroll += new System.EventHandler(this.trackNegativeZ_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Z轴阀值：";
            // 
            // lblPositiveZ
            // 
            this.lblPositiveZ.AutoSize = true;
            this.lblPositiveZ.Location = new System.Drawing.Point(663, 75);
            this.lblPositiveZ.Name = "lblPositiveZ";
            this.lblPositiveZ.Size = new System.Drawing.Size(15, 15);
            this.lblPositiveZ.TabIndex = 5;
            this.lblPositiveZ.Text = "1";
            // 
            // trackPositiveZ
            // 
            this.trackPositiveZ.Location = new System.Drawing.Point(403, 74);
            this.trackPositiveZ.Maximum = 100;
            this.trackPositiveZ.Name = "trackPositiveZ";
            this.trackPositiveZ.Size = new System.Drawing.Size(254, 56);
            this.trackPositiveZ.TabIndex = 4;
            this.trackPositiveZ.Value = 100;
            this.trackPositiveZ.Scroll += new System.EventHandler(this.trackPositiveZ_Scroll);
            // 
            // lblNegativeZ
            // 
            this.lblNegativeZ.AutoSize = true;
            this.lblNegativeZ.Location = new System.Drawing.Point(347, 75);
            this.lblNegativeZ.Name = "lblNegativeZ";
            this.lblNegativeZ.Size = new System.Drawing.Size(23, 15);
            this.lblNegativeZ.TabIndex = 5;
            this.lblNegativeZ.Text = "-1";
            // 
            // FormVolumeRendering00
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 571);
            this.Controls.Add(this.lblNegativeZ);
            this.Controls.Add(this.lblPositiveZ);
            this.Controls.Add(this.lblAlphaThreshold);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackPositiveZ);
            this.Controls.Add(this.trackNegativeZ);
            this.Controls.Add(this.trackAlpha);
            this.Controls.Add(this.glCanvas1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormVolumeRendering00";
            this.Text = "FormVolumeRendering00-3d texture in legacy opengl";
            this.Load += new System.EventHandler(this.FormVolumeRendering01_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackNegativeZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPositiveZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private GLCanvas glCanvas1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripStatusLabel lblExport3DTexture;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TrackBar trackAlpha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAlphaThreshold;
        private System.Windows.Forms.TrackBar trackNegativeZ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPositiveZ;
        private System.Windows.Forms.TrackBar trackPositiveZ;
        private System.Windows.Forms.Label lblNegativeZ;
    }
}