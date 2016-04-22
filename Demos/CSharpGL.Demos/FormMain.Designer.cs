namespace CSharpGL.Demos
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
            this.btnForm00GLCanvas = new System.Windows.Forms.Button();
            this.btnForm02BigDipper = new System.Windows.Forms.Button();
            this.btnEmitNormalLine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnForm00GLCanvas
            // 
            this.btnForm00GLCanvas.Font = new System.Drawing.Font("宋体", 12F);
            this.btnForm00GLCanvas.Location = new System.Drawing.Point(12, 12);
            this.btnForm00GLCanvas.Name = "btnForm00GLCanvas";
            this.btnForm00GLCanvas.Size = new System.Drawing.Size(269, 37);
            this.btnForm00GLCanvas.TabIndex = 0;
            this.btnForm00GLCanvas.Text = "Form00 GLCanvas";
            this.btnForm00GLCanvas.UseVisualStyleBackColor = true;
            this.btnForm00GLCanvas.Click += new System.EventHandler(this.btnForm00GLCanvas_Click);
            // 
            // btnForm02BigDipper
            // 
            this.btnForm02BigDipper.Font = new System.Drawing.Font("宋体", 12F);
            this.btnForm02BigDipper.Location = new System.Drawing.Point(12, 55);
            this.btnForm02BigDipper.Name = "btnForm02BigDipper";
            this.btnForm02BigDipper.Size = new System.Drawing.Size(269, 37);
            this.btnForm02BigDipper.TabIndex = 0;
            this.btnForm02BigDipper.Text = "Form02 BigDipper";
            this.btnForm02BigDipper.UseVisualStyleBackColor = true;
            this.btnForm02BigDipper.Click += new System.EventHandler(this.btnForm02BigDipper_Click);
            // 
            // btnEmitNormalLine
            // 
            this.btnEmitNormalLine.Font = new System.Drawing.Font("宋体", 12F);
            this.btnEmitNormalLine.Location = new System.Drawing.Point(12, 98);
            this.btnEmitNormalLine.Name = "btnEmitNormalLine";
            this.btnEmitNormalLine.Size = new System.Drawing.Size(269, 37);
            this.btnEmitNormalLine.TabIndex = 0;
            this.btnEmitNormalLine.Text = "Form02 EmitNormalLine";
            this.btnEmitNormalLine.UseVisualStyleBackColor = true;
            this.btnEmitNormalLine.Click += new System.EventHandler(this.btnEmitNormalLine_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 545);
            this.Controls.Add(this.btnEmitNormalLine);
            this.Controls.Add(this.btnForm02BigDipper);
            this.Controls.Add(this.btnForm00GLCanvas);
            this.Name = "FormMain";
            this.Text = "CSharpGL Test/Demo Panel - http://bitzhuwei.cnblogs.com";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnForm00GLCanvas;
        private System.Windows.Forms.Button btnForm02BigDipper;
        private System.Windows.Forms.Button btnEmitNormalLine;
    }
}