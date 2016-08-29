namespace CSharpGL.Demos
{
    partial class Form01Renderer
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
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.lblReadColor = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblDrawText = new System.Windows.Forms.Label();
            this.glCanvas1 = new CSharpGL.GLCanvas();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // dlgSaveFile
            // 
            this.dlgSaveFile.DefaultExt = "png";
            this.dlgSaveFile.FileName = "*.png";
            this.dlgSaveFile.Filter = "(*.png)|*.png";
            this.dlgSaveFile.RestoreDirectory = true;
            // 
            // lblReadColor
            // 
            this.lblReadColor.AutoSize = true;
            this.lblReadColor.Font = new System.Drawing.Font("宋体", 12F);
            this.lblReadColor.Location = new System.Drawing.Point(62, 7);
            this.lblReadColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReadColor.Name = "lblReadColor";
            this.lblReadColor.Size = new System.Drawing.Size(120, 16);
            this.lblReadColor.TabIndex = 1;
            this.lblReadColor.Text = "Color At Mouse";
            // 
            // lblColor
            // 
            this.lblColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblColor.Font = new System.Drawing.Font("宋体", 12F);
            this.lblColor.Location = new System.Drawing.Point(9, 7);
            this.lblColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(48, 16);
            this.lblColor.TabIndex = 1;
            // 
            // lblDrawText
            // 
            this.lblDrawText.AutoSize = true;
            this.lblDrawText.Font = new System.Drawing.Font("宋体", 12F);
            this.lblDrawText.Location = new System.Drawing.Point(9, 26);
            this.lblDrawText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDrawText.Name = "lblDrawText";
            this.lblDrawText.Size = new System.Drawing.Size(72, 16);
            this.lblDrawText.TabIndex = 1;
            this.lblDrawText.Text = "DrawText";
            // 
            // glCanvas1
            // 
            this.glCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glCanvas1.Location = new System.Drawing.Point(10, 45);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.OpenGLVersion = CSharpGL.GLVersion.OpenGL2_1;
            this.glCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.glCanvas1.ShowSystemCursor = true;
            this.glCanvas1.Size = new System.Drawing.Size(540, 333);
            this.glCanvas1.TabIndex = 0;
            this.glCanvas1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.glCanvas1_KeyPress);
            this.glCanvas1.Resize += new System.EventHandler(this.glCanvas1_Resize);
            // 
            // Form01Renderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 388);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblDrawText);
            this.Controls.Add(this.lblReadColor);
            this.Controls.Add(this.glCanvas1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form01Renderer";
            this.Text = "Form01Renderer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form01Renderer_FormClosed);
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GLCanvas glCanvas1;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.Windows.Forms.Label lblReadColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblDrawText;
    }
}