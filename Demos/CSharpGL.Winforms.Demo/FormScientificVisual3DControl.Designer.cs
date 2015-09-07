namespace CSharpGL.Winforms.Demo
{
    partial class FormScientificVisual3DControl
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
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.scientificVisual3DControl1 = new CSharpGL.Winforms.Demo.ScientificVisual3DControl();
            ((System.ComponentModel.ISupportInitialize)(this.scientificVisual3DControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.Location = new System.Drawing.Point(13, 12);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(857, 133);
            this.txtInfo.TabIndex = 1;
            // 
            // scientificVisual3DControl1
            // 
            this.scientificVisual3DControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scientificVisual3DControl1.Location = new System.Drawing.Point(13, 152);
            this.scientificVisual3DControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scientificVisual3DControl1.Name = "scientificVisual3DControl1";
            this.scientificVisual3DControl1.OpenGLVersion = CSharpGL.Objects.RenderContexts.GLVersion.OpenGL2_1;
            this.scientificVisual3DControl1.RenderTrigger = CSharpGL.Winforms.RenderTriggers.TimerBased;
            this.scientificVisual3DControl1.Size = new System.Drawing.Size(857, 454);
            this.scientificVisual3DControl1.TabIndex = 0;
            // 
            // FormScientificVisual3DControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 619);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.scientificVisual3DControl1);
            this.Name = "FormScientificVisual3DControl";
            this.Text = "FormScientificVisual3DControl";
            ((System.ComponentModel.ISupportInitialize)(this.scientificVisual3DControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScientificVisual3DControl scientificVisual3DControl1;
        private System.Windows.Forms.TextBox txtInfo;
    }
}