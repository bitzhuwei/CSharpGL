namespace RedBook.Winforms.Demo
{
    partial class FormTest
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
            this.btnLightingExample = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.btnLightingExample.Location = new System.Drawing.Point(12, 12);
            this.btnLightingExample.Name = "button1";
            this.btnLightingExample.Size = new System.Drawing.Size(254, 23);
            this.btnLightingExample.TabIndex = 0;
            this.btnLightingExample.Text = "LightingExample";
            this.btnLightingExample.UseVisualStyleBackColor = true;
            this.btnLightingExample.Click += new System.EventHandler(this.btnLightingExample_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 626);
            this.Controls.Add(this.btnLightingExample);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLightingExample;
    }
}