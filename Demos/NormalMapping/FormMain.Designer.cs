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
            this.winGLCanvas1 = new CSharpGL.WinGLCanvas();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.rdoNormalMapping = new System.Windows.Forms.RadioButton();
            this.rdoNotNormalMapping = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // winGLCanvas1
            // 
            this.winGLCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winGLCanvas1.Location = new System.Drawing.Point(12, 34);
            this.winGLCanvas1.Name = "winGLCanvas1";
            this.winGLCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.winGLCanvas1.Size = new System.Drawing.Size(961, 531);
            this.winGLCanvas1.TabIndex = 0;
            this.winGLCanvas1.TimerTriggerInterval = 40;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "*.obj|*.obj|*.obj_|*.obj_";
            // 
            // rdoNormalMapping
            // 
            this.rdoNormalMapping.AutoSize = true;
            this.rdoNormalMapping.Checked = true;
            this.rdoNormalMapping.Location = new System.Drawing.Point(12, 12);
            this.rdoNormalMapping.Name = "rdoNormalMapping";
            this.rdoNormalMapping.Size = new System.Drawing.Size(107, 16);
            this.rdoNormalMapping.TabIndex = 1;
            this.rdoNormalMapping.TabStop = true;
            this.rdoNormalMapping.Text = "Normal Mapping";
            this.rdoNormalMapping.UseVisualStyleBackColor = true;
            this.rdoNormalMapping.CheckedChanged += new System.EventHandler(this.rdoNormalMapping_CheckedChanged);
            // 
            // rdoNotNormalMapping
            // 
            this.rdoNotNormalMapping.AutoSize = true;
            this.rdoNotNormalMapping.Location = new System.Drawing.Point(125, 12);
            this.rdoNotNormalMapping.Name = "rdoNotNormalMapping";
            this.rdoNotNormalMapping.Size = new System.Drawing.Size(131, 16);
            this.rdoNotNormalMapping.TabIndex = 1;
            this.rdoNotNormalMapping.Text = "Not Normal Mapping";
            this.rdoNotNormalMapping.UseVisualStyleBackColor = true;
            this.rdoNotNormalMapping.CheckedChanged += new System.EventHandler(this.rdoNormalMapping_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 577);
            this.Controls.Add(this.rdoNotNormalMapping);
            this.Controls.Add(this.rdoNormalMapping);
            this.Controls.Add(this.winGLCanvas1);
            this.Name = "FormMain";
            this.Text = "Normal(Bump) Mapping - CSharpGL";
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharpGL.WinGLCanvas winGLCanvas1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton rdoNormalMapping;
        private System.Windows.Forms.RadioButton rdoNotNormalMapping;
    }
}