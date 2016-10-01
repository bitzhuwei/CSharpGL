namespace CSharpGL.Demos
{
    partial class Form15UIRenderer
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
            this.openTextureDlg = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentBlend = new System.Windows.Forms.Label();
            this.glCanvas1 = new CSharpGL.GLCanvas();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // openTextureDlg
            // 
            this.openTextureDlg.Filter = "True Type Font File(*.TTF;*.OTF)|*.TTF;*.OTF";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Press \'b\' to switch blend factors.";
            // 
            // lblCurrentBlend
            // 
            this.lblCurrentBlend.AutoSize = true;
            this.lblCurrentBlend.Font = new System.Drawing.Font("宋体", 12F);
            this.lblCurrentBlend.Location = new System.Drawing.Point(9, 31);
            this.lblCurrentBlend.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentBlend.Name = "lblCurrentBlend";
            this.lblCurrentBlend.Size = new System.Drawing.Size(120, 16);
            this.lblCurrentBlend.TabIndex = 4;
            this.lblCurrentBlend.Text = "glBlendFunc();";
            // 
            // glCanvas1
            // 
            this.glCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glCanvas1.Location = new System.Drawing.Point(10, 50);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.glCanvas1.Size = new System.Drawing.Size(568, 378);
            this.glCanvas1.TabIndex = 0;
            // 
            // Form15LabelRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 438);
            this.Controls.Add(this.lblCurrentBlend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.glCanvas1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form15LabelRenderer";
            this.Text = "Form15Scene";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GLCanvas glCanvas1;
        private System.Windows.Forms.OpenFileDialog openTextureDlg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentBlend;
    }
}