using CSharpGL.Windows;
namespace CSharpGL.Demos
{
    partial class Form02EmitNormalLine
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
            this.glCanvas1 = new CSharpGL.Windows.GLCanvas();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.lblText = new System.Windows.Forms.Label();
            this.lblReadColor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // glCanvas1
            // 
            this.glCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glCanvas1.Location = new System.Drawing.Point(13, 28);
            this.glCanvas1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.OpenGLVersion = CSharpGL.Windows.GLVersion.OpenGL2_1;
            this.glCanvas1.RenderTrigger = CSharpGL.Windows.RenderTriggers.TimerBased;
            this.glCanvas1.Size = new System.Drawing.Size(705, 493);
            this.glCanvas1.TabIndex = 0;
            this.glCanvas1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.glCanvas1_KeyPress);
            // 
            // dlgSaveFile
            // 
            this.dlgSaveFile.DefaultExt = "bmp";
            this.dlgSaveFile.FileName = "*.bmp";
            this.dlgSaveFile.Filter = "*.bmp|*.bmp";
            this.dlgSaveFile.RestoreDirectory = true;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(137, 9);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(119, 15);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "Color At Mouse";
            // 
            // lblReadColor
            // 
            this.lblReadColor.AutoSize = true;
            this.lblReadColor.Location = new System.Drawing.Point(12, 9);
            this.lblReadColor.Name = "lblReadColor";
            this.lblReadColor.Size = new System.Drawing.Size(119, 15);
            this.lblReadColor.TabIndex = 3;
            this.lblReadColor.Text = "Color At Mouse";
            // 
            // Form02EmitNormalLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 534);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblReadColor);
            this.Controls.Add(this.glCanvas1);
            this.Name = "Form02EmitNormalLine";
            this.Text = "Form02EmitNormalLine";
            this.Load += new System.EventHandler(this.Form01ModernRenderer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GLCanvas glCanvas1;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblReadColor;
    }
}