using CSharpGL.Windows;
namespace CSharpGL.Demos
{
    partial class Form01Simple
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
            this.lblText = new System.Windows.Forms.Label();
            this.lblRightMouseMove = new System.Windows.Forms.Label();
            this.glCanvas1 = new CSharpGL.Windows.GLCanvas();
            this.lblRightMouseDown = new System.Windows.Forms.Label();
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
            this.lblReadColor.Location = new System.Drawing.Point(12, 9);
            this.lblReadColor.Name = "lblReadColor";
            this.lblReadColor.Size = new System.Drawing.Size(149, 20);
            this.lblReadColor.TabIndex = 1;
            this.lblReadColor.Text = "Color At Mouse";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("宋体", 12F);
            this.lblText.Location = new System.Drawing.Point(137, 9);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(149, 20);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "Color At Mouse";
            // 
            // lblRightMouseMove
            // 
            this.lblRightMouseMove.AutoSize = true;
            this.lblRightMouseMove.Font = new System.Drawing.Font("宋体", 12F);
            this.lblRightMouseMove.Location = new System.Drawing.Point(12, 65);
            this.lblRightMouseMove.Name = "lblRightMouseMove";
            this.lblRightMouseMove.Size = new System.Drawing.Size(169, 20);
            this.lblRightMouseMove.TabIndex = 1;
            this.lblRightMouseMove.Text = "Right Mouse Move";
            // 
            // glCanvas1
            // 
            this.glCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glCanvas1.Location = new System.Drawing.Point(13, 89);
            this.glCanvas1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.OpenGLVersion = CSharpGL.Windows.GLVersion.OpenGL2_1;
            this.glCanvas1.RenderTrigger = CSharpGL.Windows.RenderTriggers.TimerBased;
            this.glCanvas1.Size = new System.Drawing.Size(1180, 577);
            this.glCanvas1.TabIndex = 0;
            this.glCanvas1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.glCanvas1_KeyPress);
            this.glCanvas1.Resize += new System.EventHandler(this.glCanvas1_Resize);
            // 
            // lblRightMouseDown
            // 
            this.lblRightMouseDown.AutoSize = true;
            this.lblRightMouseDown.Font = new System.Drawing.Font("宋体", 12F);
            this.lblRightMouseDown.Location = new System.Drawing.Point(10, 36);
            this.lblRightMouseDown.Name = "lblRightMouseDown";
            this.lblRightMouseDown.Size = new System.Drawing.Size(169, 20);
            this.lblRightMouseDown.TabIndex = 1;
            this.lblRightMouseDown.Text = "Right Mouse Down";
            // 
            // Form01Simple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 679);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblRightMouseDown);
            this.Controls.Add(this.lblRightMouseMove);
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
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblRightMouseMove;
        private System.Windows.Forms.Label lblRightMouseDown;
    }
}