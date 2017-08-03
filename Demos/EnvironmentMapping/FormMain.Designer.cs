namespace EnvironmentMapping
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rdoReflection = new System.Windows.Forms.RadioButton();
            this.rdoRefraction = new System.Windows.Forms.RadioButton();
            this.cmbRatios = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // winGLCanvas1
            // 
            this.winGLCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winGLCanvas1.Location = new System.Drawing.Point(12, 38);
            this.winGLCanvas1.Name = "winGLCanvas1";
            this.winGLCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.winGLCanvas1.Size = new System.Drawing.Size(961, 527);
            this.winGLCanvas1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rdoReflection
            // 
            this.rdoReflection.AutoSize = true;
            this.rdoReflection.Checked = true;
            this.rdoReflection.Font = new System.Drawing.Font("宋体", 12F);
            this.rdoReflection.Location = new System.Drawing.Point(12, 12);
            this.rdoReflection.Name = "rdoReflection";
            this.rdoReflection.Size = new System.Drawing.Size(106, 20);
            this.rdoReflection.TabIndex = 1;
            this.rdoReflection.TabStop = true;
            this.rdoReflection.Text = "Reflection";
            this.rdoReflection.UseVisualStyleBackColor = true;
            this.rdoReflection.CheckedChanged += new System.EventHandler(this.rdoReflection_CheckedChanged);
            // 
            // rdoRefraction
            // 
            this.rdoRefraction.AutoSize = true;
            this.rdoRefraction.Font = new System.Drawing.Font("宋体", 12F);
            this.rdoRefraction.Location = new System.Drawing.Point(124, 12);
            this.rdoRefraction.Name = "rdoRefraction";
            this.rdoRefraction.Size = new System.Drawing.Size(106, 20);
            this.rdoRefraction.TabIndex = 1;
            this.rdoRefraction.Text = "Refraction";
            this.rdoRefraction.UseVisualStyleBackColor = true;
            this.rdoRefraction.CheckedChanged += new System.EventHandler(this.rdoRefraction_CheckedChanged);
            // 
            // cmbRatios
            // 
            this.cmbRatios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRatios.Enabled = false;
            this.cmbRatios.FormattingEnabled = true;
            this.cmbRatios.Location = new System.Drawing.Point(236, 12);
            this.cmbRatios.Name = "cmbRatios";
            this.cmbRatios.Size = new System.Drawing.Size(121, 20);
            this.cmbRatios.TabIndex = 2;
            this.cmbRatios.SelectedIndexChanged += new System.EventHandler(this.cmbRatios_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 577);
            this.Controls.Add(this.cmbRatios);
            this.Controls.Add(this.rdoRefraction);
            this.Controls.Add(this.rdoReflection);
            this.Controls.Add(this.winGLCanvas1);
            this.Name = "FormMain";
            this.Text = "Environment Mapping - CSharpGL";
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharpGL.WinGLCanvas winGLCanvas1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton rdoReflection;
        private System.Windows.Forms.RadioButton rdoRefraction;
        private System.Windows.Forms.ComboBox cmbRatios;
    }
}