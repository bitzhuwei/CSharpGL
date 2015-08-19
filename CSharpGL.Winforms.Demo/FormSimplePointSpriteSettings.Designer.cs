namespace CSharpGL.Winforms.Demo
{
    partial class FormSimplePointSpriteSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFontSize = new System.Windows.Forms.TextBox();
            this.chkforeshortening = new System.Windows.Forms.CheckBox();
            this.cmbFragShaderType = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "font size:";
            // 
            // txtFontSize
            // 
            this.txtFontSize.Location = new System.Drawing.Point(105, 12);
            this.txtFontSize.Name = "txtFontSize";
            this.txtFontSize.Size = new System.Drawing.Size(165, 25);
            this.txtFontSize.TabIndex = 1;
            this.txtFontSize.Text = "64.0";
            // 
            // chkforeshortening
            // 
            this.chkforeshortening.AutoSize = true;
            this.chkforeshortening.Checked = true;
            this.chkforeshortening.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkforeshortening.Location = new System.Drawing.Point(15, 43);
            this.chkforeshortening.Name = "chkforeshortening";
            this.chkforeshortening.Size = new System.Drawing.Size(141, 19);
            this.chkforeshortening.TabIndex = 2;
            this.chkforeshortening.Text = "foreshortening";
            this.chkforeshortening.UseVisualStyleBackColor = true;
            // 
            // cmbFragShaderType
            // 
            this.cmbFragShaderType.FormattingEnabled = true;
            this.cmbFragShaderType.Location = new System.Drawing.Point(15, 68);
            this.cmbFragShaderType.Name = "cmbFragShaderType";
            this.cmbFragShaderType.Size = new System.Drawing.Size(255, 23);
            this.cmbFragShaderType.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(195, 112);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormSimplePointSpriteSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 147);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbFragShaderType);
            this.Controls.Add(this.chkforeshortening);
            this.Controls.Add(this.txtFontSize);
            this.Controls.Add(this.label1);
            this.Name = "FormSimplePointSpriteSettings";
            this.Text = "FormSimplePointSpriteSettings";
            this.Load += new System.EventHandler(this.FormSimplePointSpriteSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFontSize;
        private System.Windows.Forms.CheckBox chkforeshortening;
        private System.Windows.Forms.ComboBox cmbFragShaderType;
        private System.Windows.Forms.Button btnOK;
    }
}