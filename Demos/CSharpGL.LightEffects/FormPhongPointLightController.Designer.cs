namespace CSharpGL.LightEffects
{
    partial class FormPhongPointLightController
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
            this.lblLightPositionX = new System.Windows.Forms.Label();
            this.trackLightPositionX = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLightPositionY = new System.Windows.Forms.Label();
            this.trackLightPositionY = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLightPositionZ = new System.Windows.Forms.Label();
            this.trackLightPositionZ = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.lblKs = new System.Windows.Forms.Label();
            this.trackKs = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.lblShininess = new System.Windows.Forms.Label();
            this.trackShininess = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackKd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLightPositionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLightPositionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLightPositionZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackKs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackShininess)).BeginInit();
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
            this.label4.Size = new System.Drawing.Size(143, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "light position.x:";
            // 
            // lblLightPositionX
            // 
            this.lblLightPositionX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLightPositionX.AutoSize = true;
            this.lblLightPositionX.Location = new System.Drawing.Point(704, 159);
            this.lblLightPositionX.Name = "lblLightPositionX";
            this.lblLightPositionX.Size = new System.Drawing.Size(55, 15);
            this.lblLightPositionX.TabIndex = 0;
            this.lblLightPositionX.Text = "{0.00}";
            this.lblLightPositionX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackLightPositionX
            // 
            this.trackLightPositionX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackLightPositionX.Location = new System.Drawing.Point(161, 145);
            this.trackLightPositionX.Maximum = 100;
            this.trackLightPositionX.Name = "trackLightPositionX";
            this.trackLightPositionX.Size = new System.Drawing.Size(537, 56);
            this.trackLightPositionX.TabIndex = 1;
            this.trackLightPositionX.Value = 5;
            this.trackLightPositionX.Scroll += new System.EventHandler(this.trackLightPositionX_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "light position.y:";
            // 
            // lblLightPositionY
            // 
            this.lblLightPositionY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLightPositionY.AutoSize = true;
            this.lblLightPositionY.Location = new System.Drawing.Point(704, 221);
            this.lblLightPositionY.Name = "lblLightPositionY";
            this.lblLightPositionY.Size = new System.Drawing.Size(55, 15);
            this.lblLightPositionY.TabIndex = 0;
            this.lblLightPositionY.Text = "{0.00}";
            this.lblLightPositionY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackLightPositionY
            // 
            this.trackLightPositionY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackLightPositionY.Location = new System.Drawing.Point(161, 207);
            this.trackLightPositionY.Maximum = 100;
            this.trackLightPositionY.Name = "trackLightPositionY";
            this.trackLightPositionY.Size = new System.Drawing.Size(537, 56);
            this.trackLightPositionY.TabIndex = 1;
            this.trackLightPositionY.Value = 5;
            this.trackLightPositionY.Scroll += new System.EventHandler(this.trackLightPositionY_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 283);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "light position.z:";
            // 
            // lblLightPositionZ
            // 
            this.lblLightPositionZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLightPositionZ.AutoSize = true;
            this.lblLightPositionZ.Location = new System.Drawing.Point(704, 283);
            this.lblLightPositionZ.Name = "lblLightPositionZ";
            this.lblLightPositionZ.Size = new System.Drawing.Size(55, 15);
            this.lblLightPositionZ.TabIndex = 0;
            this.lblLightPositionZ.Text = "{0.00}";
            this.lblLightPositionZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackLightPositionZ
            // 
            this.trackLightPositionZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackLightPositionZ.Location = new System.Drawing.Point(161, 269);
            this.trackLightPositionZ.Maximum = 100;
            this.trackLightPositionZ.Name = "trackLightPositionZ";
            this.trackLightPositionZ.Size = new System.Drawing.Size(537, 56);
            this.trackLightPositionZ.TabIndex = 1;
            this.trackLightPositionZ.Value = 5;
            this.trackLightPositionZ.Scroll += new System.EventHandler(this.trackLightPositionZ_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 345);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ks:";
            // 
            // lblKs
            // 
            this.lblKs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKs.AutoSize = true;
            this.lblKs.Location = new System.Drawing.Point(704, 345);
            this.lblKs.Name = "lblKs";
            this.lblKs.Size = new System.Drawing.Size(55, 15);
            this.lblKs.TabIndex = 0;
            this.lblKs.Text = "{0.00}";
            this.lblKs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackKs
            // 
            this.trackKs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackKs.Location = new System.Drawing.Point(49, 331);
            this.trackKs.Maximum = 50;
            this.trackKs.Name = "trackKs";
            this.trackKs.Size = new System.Drawing.Size(649, 56);
            this.trackKs.TabIndex = 1;
            this.trackKs.Value = 5;
            this.trackKs.Scroll += new System.EventHandler(this.trackKs_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 407);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "shininess:";
            // 
            // lblShininess
            // 
            this.lblShininess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShininess.AutoSize = true;
            this.lblShininess.Location = new System.Drawing.Point(704, 407);
            this.lblShininess.Name = "lblShininess";
            this.lblShininess.Size = new System.Drawing.Size(55, 15);
            this.lblShininess.TabIndex = 0;
            this.lblShininess.Text = "{0.00}";
            this.lblShininess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackShininess
            // 
            this.trackShininess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackShininess.Location = new System.Drawing.Point(105, 393);
            this.trackShininess.Maximum = 100;
            this.trackShininess.Name = "trackShininess";
            this.trackShininess.Size = new System.Drawing.Size(593, 56);
            this.trackShininess.TabIndex = 1;
            this.trackShininess.Value = 5;
            this.trackShininess.Scroll += new System.EventHandler(this.trackShininess_Scroll);
            // 
            // FormPhongPointLightController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 473);
            this.Controls.Add(this.lblGlobalAmbientDisplay);
            this.Controls.Add(this.lblLightColorDisplay);
            this.Controls.Add(this.lblGlobalAmbient);
            this.Controls.Add(this.trackLightPositionZ);
            this.Controls.Add(this.trackLightPositionY);
            this.Controls.Add(this.lblLightPositionZ);
            this.Controls.Add(this.trackLightPositionX);
            this.Controls.Add(this.lblLightPositionY);
            this.Controls.Add(this.trackShininess);
            this.Controls.Add(this.trackKs);
            this.Controls.Add(this.trackKd);
            this.Controls.Add(this.lblLightPositionX);
            this.Controls.Add(this.lblShininess);
            this.Controls.Add(this.lblLightColor);
            this.Controls.Add(this.lblKs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblKd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FormPhongPointLightController";
            this.Text = "FormPhongPointLightController";
            this.Load += new System.EventHandler(this.FormDiffuseReflectionController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackKd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLightPositionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLightPositionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLightPositionZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackKs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackShininess)).EndInit();
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
        private System.Windows.Forms.Label lblLightPositionX;
        private System.Windows.Forms.TrackBar trackLightPositionX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLightPositionY;
        private System.Windows.Forms.TrackBar trackLightPositionY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLightPositionZ;
        private System.Windows.Forms.TrackBar trackLightPositionZ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblKs;
        private System.Windows.Forms.TrackBar trackKs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblShininess;
        private System.Windows.Forms.TrackBar trackShininess;
    }
}