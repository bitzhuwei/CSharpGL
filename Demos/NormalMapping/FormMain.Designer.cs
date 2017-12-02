namespace NormalMapping
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.winGLCanvas1 = new CSharpGL.WinGLCanvas();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // winGLCanvas1
            // 
            this.winGLCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winGLCanvas1.Location = new System.Drawing.Point(12, 12);
            this.winGLCanvas1.Name = "winGLCanvas1";
            this.winGLCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.winGLCanvas1.Size = new System.Drawing.Size(961, 553);
            this.winGLCanvas1.TabIndex = 0;
            this.winGLCanvas1.TimerTriggerInterval = 40;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "*.obj|*.obj|*.obj_|*.obj_";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 577);
            this.Controls.Add(this.winGLCanvas1);
            this.Name = "FormMain";
            this.Text = "Normal(Bump) Mapping - CSharpGL";
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CSharpGL.WinGLCanvas winGLCanvas1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}