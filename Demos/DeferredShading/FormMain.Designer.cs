namespace DeferredShading
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
            this.winGLCanvas1 = new CSharpGL.WinGLCanvas();
            this.openImageDlg = new System.Windows.Forms.OpenFileDialog();
            this.chkDeferredShading = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // winGLCanvas1
            // 
            this.winGLCanvas1.AccumAlphaBits = ((byte)(0));
            this.winGLCanvas1.AccumBits = ((byte)(0));
            this.winGLCanvas1.AccumBlueBits = ((byte)(0));
            this.winGLCanvas1.AccumGreenBits = ((byte)(0));
            this.winGLCanvas1.AccumRedBits = ((byte)(0));
            this.winGLCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winGLCanvas1.Location = new System.Drawing.Point(12, 34);
            this.winGLCanvas1.Name = "winGLCanvas1";
            this.winGLCanvas1.RenderTrigger = CSharpGL.RenderTrigger.Manual;
            this.winGLCanvas1.Size = new System.Drawing.Size(927, 638);
            this.winGLCanvas1.StencilBits = ((byte)(0));
            this.winGLCanvas1.TabIndex = 0;
            this.winGLCanvas1.TimerTriggerInterval = 40;
            this.winGLCanvas1.UpdateContextVersion = true;
            // 
            // openImageDlg
            // 
            this.openImageDlg.Filter = "*.*|*.*";
            // 
            // chkDeferredShading
            // 
            this.chkDeferredShading.AutoSize = true;
            this.chkDeferredShading.Checked = true;
            this.chkDeferredShading.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeferredShading.Location = new System.Drawing.Point(12, 12);
            this.chkDeferredShading.Name = "chkDeferredShading";
            this.chkDeferredShading.Size = new System.Drawing.Size(120, 16);
            this.chkDeferredShading.TabIndex = 1;
            this.chkDeferredShading.Text = "Deferred Shading";
            this.chkDeferredShading.UseVisualStyleBackColor = true;
            this.chkDeferredShading.CheckedChanged += new System.EventHandler(this.chkDeferredShading_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 684);
            this.Controls.Add(this.chkDeferredShading);
            this.Controls.Add(this.winGLCanvas1);
            this.Name = "FormMain";
            this.Text = "Deferred Shading - CSharpGL";
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharpGL.WinGLCanvas winGLCanvas1;
        private System.Windows.Forms.OpenFileDialog openImageDlg;
        private System.Windows.Forms.CheckBox chkDeferredShading;
    }
}