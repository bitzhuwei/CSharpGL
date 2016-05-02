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
            this.btnForm01Renderer = new System.Windows.Forms.Button();
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
            // btnForm01Renderer
            // 
            this.btnForm01Renderer.Font = new System.Drawing.Font("宋体", 12F);
            this.btnForm01Renderer.Location = new System.Drawing.Point(12, 55);
            this.btnForm01Renderer.Name = "btnForm01Renderer";
            this.btnForm01Renderer.Size = new System.Drawing.Size(269, 37);
            this.btnForm01Renderer.TabIndex = 0;
            this.btnForm01Renderer.Text = "Form01 Renderer";
            this.btnForm01Renderer.UseVisualStyleBackColor = true;
            this.btnForm01Renderer.Click += new System.EventHandler(this.btnForm01Renderer_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 545);
            this.Controls.Add(this.btnForm01Renderer);
            this.Controls.Add(this.btnForm00GLCanvas);
            this.Name = "FormMain";
            this.Text = "CSharpGL Test/Demo Panel - http://bitzhuwei.cnblogs.com";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnForm00GLCanvas;
        private System.Windows.Forms.Button btnForm01Renderer;
    }
}