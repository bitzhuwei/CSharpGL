namespace CSharpGL.LightEffects
{
    partial class FormDiffuseReflectionController
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
            this.trackKd = new System.Windows.Forms.TrackBar();
            this.lblKd = new System.Windows.Forms.Label();
            this.lightColorDlg = new System.Windows.Forms.ColorDialog();
            this.lblLightColorDisplay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLightColor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGlobalAmbient = new System.Windows.Forms.Label();
            this.lblGlobalAmbientDisplay = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLightPosition = new System.Windows.Forms.Label();
            this.trackLightPosition = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackKd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLightPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kd:";
            // 
            // trackKd
            // 
            this.trackKd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackKd.Location = new System.Drawing.Point(49, 12);
            this.trackKd.Maximum = 50;
            this.trackKd.Name = "trackKd";
            this.trackKd.Size = new System.Drawing.Size(649, 56);
            this.trackKd.TabIndex = 1;
            this.trackKd.Value = 5;
            this.trackKd.Scroll += new System.EventHandler(this.trackKd_Scroll);
            // 
            // lblKd
            // 
            this.lblKd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKd.AutoSize = true;
            this.lblKd.Location = new System.Drawing.Point(704, 26);
            this.lblKd.Name = "lblKd";
            this.lblKd.Size = new System.Drawing.Size(55, 15);
            this.lblKd.TabIndex = 0;
            this.lblKd.Text = "{0.00}";
            this.lblKd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLightColorDisplay
            // 
            this.lblLightColorDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLightColorDisplay.BackColor = System.Drawing.Color.Red;
            this.lblLightColorDisplay.Location = new System.Drawing.Point(145, 71);
            this.lblLightColorDisplay.Name = "lblLightColorDisplay";
            this.lblLightColorDisplay.Size = new System.Drawing.Size(460, 31);
            this.lblLightColorDisplay.TabIndex = 3;
            this.lblLightColorDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLightColorDisplay.Click += new System.EventHandler(this.lblLightColorDisplay_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "light color:";
            // 
            // lblLightColor
            // 
            this.lblLightColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLightColor.AutoSize = true;
            this.lblLightColor.Location = new System.Drawing.Point(611, 79);
            this.lblLightColor.Name = "lblLightColor";
            this.lblLightColor.Size = new System.Drawing.Size(143, 15);
            this.lblLightColor.TabIndex = 0;
            this.lblLightColor.Text = "R:{0} G:{1} B:{2}";
            this.lblLightColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "global ambient:";
            // 
            // lblGlobalAmbient
            // 
            this.lblGlobalAmbient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGlobalAmbient.AutoSize = true;
            this.lblGlobalAmbient.Location = new System.Drawing.Point(611, 119);
            this.lblGlobalAmbient.Name = "lblGlobalAmbient";
            this.lblGlobalAmbient.Size = new System.Drawing.Size(143, 15);
            this.lblGlobalAmbient.TabIndex = 0;
            this.lblGlobalAmbient.Text = "R:{0} G:{1} B:{2}";
            this.lblGlobalAmbient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGlobalAmbientDisplay
            // 
            this.lblGlobalAmbientDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGlobalAmbientDisplay.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblGlobalAmbientDisplay.Location = new System.Drawing.Point(145, 111);
            this.lblGlobalAmbientDisplay.Name = "lblGlobalAmbientDisplay";
            this.lblGlobalAmbientDisplay.Size = new System.Drawing.Size(460, 31);
            this.lblGlobalAmbientDisplay.TabIndex = 3;
            this.lblGlobalAmbientDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGlobalAmbientDisplay.Click += new System.EventHandler(this.lblGlobalAmbient_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "light position:";
            // 
            // lblLightPosition
            // 
            this.lblLightPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLightPosition.AutoSize = true;
            this.lblLightPosition.Location = new System.Drawing.Point(704, 159);
            this.lblLightPosition.Name = "lblLightPosition";
            this.lblLightPosition.Size = new System.Drawing.Size(55, 15);
            this.lblLightPosition.TabIndex = 0;
            this.lblLightPosition.Text = "{0.00}";
            this.lblLightPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackLightPosition
            // 
            this.trackLightPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackLightPosition.Location = new System.Drawing.Point(145, 145);
            this.trackLightPosition.Maximum = 100;
            this.trackLightPosition.Name = "trackLightPosition";
            this.trackLightPosition.Size = new System.Drawing.Size(553, 56);
            this.trackLightPosition.TabIndex = 1;
            this.trackLightPosition.Value = 5;
            this.trackLightPosition.Scroll += new System.EventHandler(this.trackLightPosition_Scroll);
            // 
            // FormDiffuseReflectionController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 473);
            this.Controls.Add(this.lblGlobalAmbientDisplay);
            this.Controls.Add(this.lblLightColorDisplay);
            this.Controls.Add(this.lblGlobalAmbient);
            this.Controls.Add(this.trackLightPosition);
            this.Controls.Add(this.trackKd);
            this.Controls.Add(this.lblLightPosition);
            this.Controls.Add(this.lblLightColor);
            this.Controls.Add(this.lblKd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FormDiffuseReflectionController";
            this.Text = "FormDiffuseReflectionController";
            this.Load += new System.EventHandler(this.FormDiffuseReflectionController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackKd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLightPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackKd;
        private System.Windows.Forms.Label lblKd;
        private System.Windows.Forms.ColorDialog lightColorDlg;
        private System.Windows.Forms.Label lblLightColorDisplay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLightColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGlobalAmbient;
        private System.Windows.Forms.Label lblGlobalAmbientDisplay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLightPosition;
        private System.Windows.Forms.TrackBar trackLightPosition;
    }
}