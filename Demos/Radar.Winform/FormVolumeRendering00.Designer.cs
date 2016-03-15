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
            this.lblBlendFuncParams = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCameraDirection = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.trackAlpha = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAlphaThreshold = new System.Windows.Forms.Label();
            this.trackSectionPosition = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.glCanvas1 = new CSharpGL.Winforms.GLCanvas();
            this.trackSectionThickness = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSectionPosition = new System.Windows.Forms.Label();
            this.lblSectionThick = new System.Windows.Forms.Label();
            this.rdoSliceX = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoSliceY = new System.Windows.Forms.RadioButton();
            this.rdoSliceZ = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSectionPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSectionThickness)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblBlendFuncParams,
            this.lblCameraDirection});
            this.statusStrip1.Location = new System.Drawing.Point(0, 546);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(715, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblBlendFuncParams
            // 
            this.lblBlendFuncParams.Name = "lblBlendFuncParams";
            this.lblBlendFuncParams.Size = new System.Drawing.Size(139, 20);
            this.lblBlendFuncParams.Text = "blendfunc params";
            // 
            // lblCameraDirection
            // 
            this.lblCameraDirection.Name = "lblCameraDirection";
            this.lblCameraDirection.Size = new System.Drawing.Size(132, 20);
            this.lblCameraDirection.Text = "camera direction";
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
            this.lblAlphaThreshold.Text = "0.00";
            // 
            // trackSectionPosition
            // 
            this.trackSectionPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackSectionPosition.Location = new System.Drawing.Point(94, 74);
            this.trackSectionPosition.Maximum = 100;
            this.trackSectionPosition.Minimum = -100;
            this.trackSectionPosition.Name = "trackSectionPosition";
            this.trackSectionPosition.Size = new System.Drawing.Size(563, 56);
            this.trackSectionPosition.TabIndex = 4;
            this.trackSectionPosition.Scroll += new System.EventHandler(this.trackSectionHeight_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "剖面位置：";
            // 
            // glCanvas1
            // 
            this.glCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glCanvas1.Location = new System.Drawing.Point(13, 224);
            this.glCanvas1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.OpenGLVersion = CSharpGL.Objects.RenderContexts.GLVersion.OpenGL2_1;
            this.glCanvas1.RenderTrigger = CSharpGL.Winforms.RenderTriggers.TimerBased;
            this.glCanvas1.Size = new System.Drawing.Size(689, 321);
            this.glCanvas1.TabIndex = 3;
            // 
            // trackSectionThickness
            // 
            this.trackSectionThickness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackSectionThickness.Location = new System.Drawing.Point(94, 136);
            this.trackSectionThickness.Maximum = 100;
            this.trackSectionThickness.Name = "trackSectionThickness";
            this.trackSectionThickness.Size = new System.Drawing.Size(563, 56);
            this.trackSectionThickness.TabIndex = 4;
            this.trackSectionThickness.Value = 100;
            this.trackSectionThickness.Scroll += new System.EventHandler(this.trackSectionThickness_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "剖面厚度：";
            // 
            // lblSectionPosition
            // 
            this.lblSectionPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSectionPosition.AutoSize = true;
            this.lblSectionPosition.Location = new System.Drawing.Point(663, 74);
            this.lblSectionPosition.Name = "lblSectionPosition";
            this.lblSectionPosition.Size = new System.Drawing.Size(39, 15);
            this.lblSectionPosition.TabIndex = 5;
            this.lblSectionPosition.Text = "0.00";
            // 
            // lblSectionThick
            // 
            this.lblSectionThick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSectionThick.AutoSize = true;
            this.lblSectionThick.Location = new System.Drawing.Point(664, 136);
            this.lblSectionThick.Name = "lblSectionThick";
            this.lblSectionThick.Size = new System.Drawing.Size(39, 15);
            this.lblSectionThick.TabIndex = 5;
            this.lblSectionThick.Text = "2.00";
            // 
            // rdoSliceX
            // 
            this.rdoSliceX.AutoSize = true;
            this.rdoSliceX.Location = new System.Drawing.Point(94, 198);
            this.rdoSliceX.Name = "rdoSliceX";
            this.rdoSliceX.Size = new System.Drawing.Size(81, 19);
            this.rdoSliceX.TabIndex = 6;
            this.rdoSliceX.Text = "切割X轴";
            this.rdoSliceX.UseVisualStyleBackColor = true;
            this.rdoSliceX.CheckedChanged += new System.EventHandler(this.rdoSliceX_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "切割方向：";
            // 
            // rdoSliceY
            // 
            this.rdoSliceY.AutoSize = true;
            this.rdoSliceY.Location = new System.Drawing.Point(181, 198);
            this.rdoSliceY.Name = "rdoSliceY";
            this.rdoSliceY.Size = new System.Drawing.Size(81, 19);
            this.rdoSliceY.TabIndex = 6;
            this.rdoSliceY.Text = "切割Y轴";
            this.rdoSliceY.UseVisualStyleBackColor = true;
            this.rdoSliceY.CheckedChanged += new System.EventHandler(this.rdoSliceY_CheckedChanged);
            // 
            // rdoSliceZ
            // 
            this.rdoSliceZ.AutoSize = true;
            this.rdoSliceZ.Checked = true;
            this.rdoSliceZ.Location = new System.Drawing.Point(268, 198);
            this.rdoSliceZ.Name = "rdoSliceZ";
            this.rdoSliceZ.Size = new System.Drawing.Size(81, 19);
            this.rdoSliceZ.TabIndex = 6;
            this.rdoSliceZ.TabStop = true;
            this.rdoSliceZ.Text = "切割Z轴";
            this.rdoSliceZ.UseVisualStyleBackColor = true;
            this.rdoSliceZ.CheckedChanged += new System.EventHandler(this.rdoSliceZ_CheckedChanged);
            // 
            // FormVolumeRendering00
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 571);
            this.Controls.Add(this.rdoSliceZ);
            this.Controls.Add(this.rdoSliceY);
            this.Controls.Add(this.rdoSliceX);
            this.Controls.Add(this.lblSectionThick);
            this.Controls.Add(this.lblSectionPosition);
            this.Controls.Add(this.lblAlphaThreshold);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackSectionThickness);
            this.Controls.Add(this.trackSectionPosition);
            this.Controls.Add(this.trackAlpha);
            this.Controls.Add(this.glCanvas1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormVolumeRendering00";
            this.Text = "FormVolumeRendering00-3d texture in legacy opengl";
            this.Load += new System.EventHandler(this.FormVolumeRendering01_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSectionPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSectionThickness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private GLCanvas glCanvas1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TrackBar trackAlpha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAlphaThreshold;
        private System.Windows.Forms.ToolStripStatusLabel lblBlendFuncParams;
        private System.Windows.Forms.TrackBar trackSectionPosition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripStatusLabel lblCameraDirection;
        private System.Windows.Forms.TrackBar trackSectionThickness;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSectionPosition;
        private System.Windows.Forms.Label lblSectionThick;
        private System.Windows.Forms.RadioButton rdoSliceX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoSliceY;
        private System.Windows.Forms.RadioButton rdoSliceZ;
    }
}