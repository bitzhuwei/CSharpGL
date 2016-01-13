namespace FormShaderDesigner1594Demos
{
    partial class FormDemosPanel
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
            this.btnXRay = new System.Windows.Forms.Button();
            this.btnBrick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnXRay
            // 
            this.btnXRay.Location = new System.Drawing.Point(12, 57);
            this.btnXRay.Name = "btnXRay";
            this.btnXRay.Size = new System.Drawing.Size(283, 39);
            this.btnXRay.TabIndex = 0;
            this.btnXRay.Text = "xray";
            this.btnXRay.UseVisualStyleBackColor = true;
            this.btnXRay.Click += new System.EventHandler(this.btnXRay_Click);
            // 
            // btnBrick
            // 
            this.btnBrick.Location = new System.Drawing.Point(12, 12);
            this.btnBrick.Name = "btnBrick";
            this.btnBrick.Size = new System.Drawing.Size(283, 39);
            this.btnBrick.TabIndex = 0;
            this.btnBrick.Text = "brick";
            this.btnBrick.UseVisualStyleBackColor = true;
            this.btnBrick.Click += new System.EventHandler(this.btnBrick_Click);
            // 
            // FormDemosPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 401);
            this.Controls.Add(this.btnBrick);
            this.Controls.Add(this.btnXRay);
            this.Name = "FormDemosPanel";
            this.Text = "FormDemosPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXRay;
        private System.Windows.Forms.Button btnBrick;
    }
}