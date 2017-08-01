namespace Normal
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
            this.chkRotate = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lblColorDisply = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
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
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkRotate
            // 
            this.chkRotate.AutoSize = true;
            this.chkRotate.Checked = true;
            this.chkRotate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRotate.Font = new System.Drawing.Font("宋体", 12F);
            this.chkRotate.Location = new System.Drawing.Point(12, 12);
            this.chkRotate.Name = "chkRotate";
            this.chkRotate.Size = new System.Drawing.Size(123, 20);
            this.chkRotate.TabIndex = 1;
            this.chkRotate.Text = "Rotate Model";
            this.chkRotate.UseVisualStyleBackColor = true;
            this.chkRotate.CheckedChanged += new System.EventHandler(this.chkRotate_CheckedChanged);
            // 
            // lblColorDisply
            // 
            this.lblColorDisply.AutoSize = true;
            this.lblColorDisply.BackColor = System.Drawing.Color.Gold;
            this.lblColorDisply.Font = new System.Drawing.Font("宋体", 12F);
            this.lblColorDisply.Location = new System.Drawing.Point(292, 13);
            this.lblColorDisply.Name = "lblColorDisply";
            this.lblColorDisply.Size = new System.Drawing.Size(48, 16);
            this.lblColorDisply.TabIndex = 2;
            this.lblColorDisply.Text = "     ";
            this.lblColorDisply.Click += new System.EventHandler(this.lblColorDisply_Click);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("宋体", 12F);
            this.lblColor.Location = new System.Drawing.Point(346, 13);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(40, 16);
            this.lblColor.TabIndex = 2;
            this.lblColor.Text = "Gold";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 577);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblColorDisply);
            this.Controls.Add(this.chkRotate);
            this.Controls.Add(this.winGLCanvas1);
            this.Name = "FormMain";
            this.Text = "Normal - CSharpGL";
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharpGL.WinGLCanvas winGLCanvas1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkRotate;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblColorDisply;
        private System.Windows.Forms.Label lblColor;
    }
}