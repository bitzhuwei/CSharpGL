namespace c13d01_QueryObject
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDrawMode = new System.Windows.Forms.ComboBox();
            this.rdoSmooth = new System.Windows.Forms.RadioButton();
            this.rdoFlat = new System.Windows.Forms.RadioButton();
            this.lblSampleCount = new System.Windows.Forms.Label();
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
            this.winGLCanvas1.Location = new System.Drawing.Point(353, 12);
            this.winGLCanvas1.Name = "winGLCanvas1";
            this.winGLCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.winGLCanvas1.Size = new System.Drawing.Size(620, 553);
            this.winGLCanvas1.StencilBits = ((byte)(0));
            this.winGLCanvas1.TabIndex = 0;
            this.winGLCanvas1.TimerTriggerInterval = 40;
            this.winGLCanvas1.UpdateContextVersion = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 18F);
            this.textBox1.Location = new System.Drawing.Point(12, 74);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(335, 423);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Draw Mode:";
            // 
            // cmbDrawMode
            // 
            this.cmbDrawMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrawMode.Font = new System.Drawing.Font("宋体", 14F);
            this.cmbDrawMode.FormattingEnabled = true;
            this.cmbDrawMode.Location = new System.Drawing.Point(125, 12);
            this.cmbDrawMode.Name = "cmbDrawMode";
            this.cmbDrawMode.Size = new System.Drawing.Size(222, 27);
            this.cmbDrawMode.TabIndex = 3;
            this.cmbDrawMode.SelectedIndexChanged += new System.EventHandler(this.cmbDrawMode_SelectedIndexChanged);
            // 
            // rdoSmooth
            // 
            this.rdoSmooth.AutoSize = true;
            this.rdoSmooth.Checked = true;
            this.rdoSmooth.Font = new System.Drawing.Font("宋体", 14F);
            this.rdoSmooth.Location = new System.Drawing.Point(12, 45);
            this.rdoSmooth.Name = "rdoSmooth";
            this.rdoSmooth.Size = new System.Drawing.Size(87, 23);
            this.rdoSmooth.TabIndex = 4;
            this.rdoSmooth.TabStop = true;
            this.rdoSmooth.Text = "smooth";
            this.rdoSmooth.UseVisualStyleBackColor = true;
            this.rdoSmooth.CheckedChanged += new System.EventHandler(this.rdoSmooth_CheckedChanged);
            // 
            // rdoFlat
            // 
            this.rdoFlat.AutoSize = true;
            this.rdoFlat.Font = new System.Drawing.Font("宋体", 14F);
            this.rdoFlat.Location = new System.Drawing.Point(105, 45);
            this.rdoFlat.Name = "rdoFlat";
            this.rdoFlat.Size = new System.Drawing.Size(67, 23);
            this.rdoFlat.TabIndex = 4;
            this.rdoFlat.Text = "flat";
            this.rdoFlat.UseVisualStyleBackColor = true;
            this.rdoFlat.CheckedChanged += new System.EventHandler(this.rdoFlat_CheckedChanged);
            // 
            // lblSampleCount
            // 
            this.lblSampleCount.AutoSize = true;
            this.lblSampleCount.Font = new System.Drawing.Font("宋体", 14F);
            this.lblSampleCount.ForeColor = System.Drawing.Color.Red;
            this.lblSampleCount.Location = new System.Drawing.Point(12, 500);
            this.lblSampleCount.Name = "lblSampleCount";
            this.lblSampleCount.Size = new System.Drawing.Size(209, 19);
            this.lblSampleCount.TabIndex = 2;
            this.lblSampleCount.Text = "Rendered Sample: {0}";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 577);
            this.Controls.Add(this.rdoFlat);
            this.Controls.Add(this.rdoSmooth);
            this.Controls.Add(this.cmbDrawMode);
            this.Controls.Add(this.lblSampleCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.winGLCanvas1);
            this.Name = "FormMain";
            this.Text = "c13d01_QueryObject - CSharpGL";
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharpGL.WinGLCanvas winGLCanvas1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDrawMode;
        private System.Windows.Forms.RadioButton rdoSmooth;
        private System.Windows.Forms.RadioButton rdoFlat;
        private System.Windows.Forms.Label lblSampleCount;
    }
}