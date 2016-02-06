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
            ((System.ComponentModel.ISupportInitialize)(this.trackKd)).BeginInit();
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
            this.trackKd.Maximum = 100;
            this.trackKd.Name = "trackKd";
            this.trackKd.Size = new System.Drawing.Size(649, 56);
            this.trackKd.TabIndex = 1;
            this.trackKd.Value = 20;
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
            // 
            // FormDiffuseReflectionController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 473);
            this.Controls.Add(this.trackKd);
            this.Controls.Add(this.lblKd);
            this.Controls.Add(this.label1);
            this.Name = "FormDiffuseReflectionController";
            this.Text = "FormDiffuseReflectionController";
            this.Load += new System.EventHandler(this.FormDiffuseReflectionController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackKd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackKd;
        private System.Windows.Forms.Label lblKd;
    }
}