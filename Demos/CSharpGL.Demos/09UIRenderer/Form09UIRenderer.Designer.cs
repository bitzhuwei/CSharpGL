namespace CSharpGL.Demos
{
    partial class Form09UIRenderer
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
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(599, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Press \'b\' to switch blend factors. Press \'o\' to select TTF.";
            // 
            // lblCurrentBlend
            // 
            this.lblCurrentBlend.AutoSize = true;
            this.lblCurrentBlend.Font = new System.Drawing.Font("宋体", 12F);
            this.lblCurrentBlend.Location = new System.Drawing.Point(12, 39);
            this.lblCurrentBlend.Name = "lblCurrentBlend";
            this.lblCurrentBlend.Size = new System.Drawing.Size(149, 20);
            this.lblCurrentBlend.TabIndex = 4;
            this.lblCurrentBlend.Text = "glBlendFunc();";
            // 
            // glCanvas1
            // 
            this.glCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glCanvas1.Location = new System.Drawing.Point(13, 63);
            this.glCanvas1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.OpenGLVersion = CSharpGL.GLVersion.OpenGL2_1;
            this.glCanvas1.RenderTrigger = CSharpGL.RenderTriggers.TimerBased;
            this.glCanvas1.Size = new System.Drawing.Size(757, 472);
            this.glCanvas1.TabIndex = 0;
            this.glCanvas1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.glCanvas1_KeyPress);
            // 
            // Form09UIRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 548);
            this.Controls.Add(this.lblCurrentBlend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.glCanvas1);
            this.Name = "Form09UIRenderer";
            this.Text = "Form09UIRenderer";
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