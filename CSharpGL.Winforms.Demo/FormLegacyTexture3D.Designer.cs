namespace CSharpGL.Winforms.Demo
{
    partial class FormLegacyTexture3D
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
            this.positiveZ = new System.Windows.Forms.VScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.negtiveZ = new System.Windows.Forms.VScrollBar();
            this.positiveY = new System.Windows.Forms.VScrollBar();
            this.negtiveY = new System.Windows.Forms.VScrollBar();
            this.positiveX = new System.Windows.Forms.VScrollBar();
            this.negtiveX = new System.Windows.Forms.VScrollBar();
            this.label3 = new System.Windows.Forms.Label();
            this.glCanvas1 = new CSharpGL.Winforms.GLCanvas();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // positiveZ
            // 
            this.positiveZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.positiveZ.Location = new System.Drawing.Point(733, 34);
            this.positiveZ.Name = "positiveZ";
            this.positiveZ.Size = new System.Drawing.Size(21, 145);
            this.positiveZ.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(718, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Y";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(736, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Z";
            // 
            // negtiveZ
            // 
            this.negtiveZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.negtiveZ.Location = new System.Drawing.Point(733, 179);
            this.negtiveZ.Maximum = 0;
            this.negtiveZ.Minimum = -100;
            this.negtiveZ.Name = "negtiveZ";
            this.negtiveZ.Size = new System.Drawing.Size(21, 145);
            this.negtiveZ.TabIndex = 1;
            // 
            // positiveY
            // 
            this.positiveY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.positiveY.Location = new System.Drawing.Point(712, 34);
            this.positiveY.Name = "positiveY";
            this.positiveY.Size = new System.Drawing.Size(21, 145);
            this.positiveY.TabIndex = 1;
            // 
            // negtiveY
            // 
            this.negtiveY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.negtiveY.Location = new System.Drawing.Point(712, 179);
            this.negtiveY.Maximum = 0;
            this.negtiveY.Minimum = -100;
            this.negtiveY.Name = "negtiveY";
            this.negtiveY.Size = new System.Drawing.Size(21, 145);
            this.negtiveY.TabIndex = 1;
            // 
            // positiveX
            // 
            this.positiveX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.positiveX.Location = new System.Drawing.Point(691, 34);
            this.positiveX.Name = "positiveX";
            this.positiveX.Size = new System.Drawing.Size(21, 145);
            this.positiveX.TabIndex = 1;
            // 
            // negtiveX
            // 
            this.negtiveX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.negtiveX.Location = new System.Drawing.Point(691, 179);
            this.negtiveX.Maximum = 0;
            this.negtiveX.Minimum = -100;
            this.negtiveX.Name = "negtiveX";
            this.negtiveX.Size = new System.Drawing.Size(21, 145);
            this.negtiveX.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(697, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "X";
            // 
            // glCanvas1
            // 
            this.glCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glCanvas1.Location = new System.Drawing.Point(13, 13);
            this.glCanvas1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.OpenGLVersion = CSharpGL.Objects.RenderContexts.GLVersion.OpenGL2_1;
            this.glCanvas1.RenderTrigger = CSharpGL.Winforms.RenderTriggers.TimerBased;
            this.glCanvas1.Size = new System.Drawing.Size(674, 455);
            this.glCanvas1.TabIndex = 0;
            // 
            // FormLegacyTexture3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 481);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.negtiveX);
            this.Controls.Add(this.positiveX);
            this.Controls.Add(this.negtiveY);
            this.Controls.Add(this.positiveY);
            this.Controls.Add(this.negtiveZ);
            this.Controls.Add(this.positiveZ);
            this.Controls.Add(this.glCanvas1);
            this.Name = "FormLegacyTexture3D";
            this.Text = "FormLegacyTexture3D";
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GLCanvas glCanvas1;
        private System.Windows.Forms.VScrollBar positiveZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.VScrollBar negtiveZ;
        private System.Windows.Forms.VScrollBar positiveY;
        private System.Windows.Forms.VScrollBar negtiveY;
        private System.Windows.Forms.VScrollBar positiveX;
        private System.Windows.Forms.VScrollBar negtiveX;
        private System.Windows.Forms.Label label3;
    }
}