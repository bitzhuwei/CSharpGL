using CSharpGL.Windows;
namespace CSharpGL.Demos
{
    partial class Form01ModernRenderer
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
            this.glCanvas1 = new CSharpGL.Windows.GLCanvas();
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
            this.lblReadColor.Location = new System.Drawing.Point(82, 9);
            this.lblReadColor.Name = "lblReadColor";
            this.lblReadColor.Size = new System.Drawing.Size(149, 20);
            this.lblReadColor.TabIndex = 1;
            this.lblReadColor.Text = "Color At Mouse";
            // 
            // lblColor
            // 
            this.lblColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblColor.Font = new System.Drawing.Font("宋体", 12F);
            this.lblColor.Location = new System.Drawing.Point(12, 9);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(64, 20);
            this.lblColor.TabIndex = 1;
            // 
            // glCanvas1
            // 
            this.glCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glCanvas1.Location = new System.Drawing.Point(13, 33);
            this.glCanvas1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.OpenGLVersion = CSharpGL.Windows.GLVersion.OpenGL2_1;
            this.glCanvas1.RenderTrigger = CSharpGL.Windows.RenderTriggers.TimerBased;
            this.glCanvas1.Size = new System.Drawing.Size(720, 439);
            this.glCanvas1.TabIndex = 0;
            this.glCanvas1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glCanvas1_KeyDown);
            this.glCanvas1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.glCanvas1_KeyPress);
            this.glCanvas1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.glCanvas1_KeyUp);
            this.glCanvas1.Resize += new System.EventHandler(this.glCanvas1_Resize);
            // 
            // Form01Simple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 485);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblReadColor);
            this.Controls.Add(this.glCanvas1);
            this.Name = "Form01Simple";
            this.Text = "Form01Simple";
            this.Load += new System.EventHandler(this.Form01ModernRenderer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GLCanvas glCanvas1;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.Windows.Forms.Label lblReadColor;
        private System.Windows.Forms.Label lblColor;
    }
}