namespace CSharpGL.Winforms.Demo
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
            this.btnUnmanagedArray = new System.Windows.Forms.Button();
            this.btnGLCanvas = new System.Windows.Forms.Button();
            this.btnFreeType = new System.Windows.Forms.Button();
            this.btnFreeTypeTextVAOElement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUnmanagedArray
            // 
            this.btnUnmanagedArray.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnmanagedArray.Location = new System.Drawing.Point(12, 12);
            this.btnUnmanagedArray.Name = "btnUnmanagedArray";
            this.btnUnmanagedArray.Size = new System.Drawing.Size(260, 23);
            this.btnUnmanagedArray.TabIndex = 0;
            this.btnUnmanagedArray.Text = "UnmanagedArray";
            this.btnUnmanagedArray.UseVisualStyleBackColor = true;
            this.btnUnmanagedArray.Click += new System.EventHandler(this.btnUnmanagedArray_Click);
            // 
            // btnGLCanvas
            // 
            this.btnGLCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGLCanvas.Location = new System.Drawing.Point(12, 41);
            this.btnGLCanvas.Name = "btnGLCanvas";
            this.btnGLCanvas.Size = new System.Drawing.Size(260, 23);
            this.btnGLCanvas.TabIndex = 0;
            this.btnGLCanvas.Text = "GLCanvas";
            this.btnGLCanvas.UseVisualStyleBackColor = true;
            this.btnGLCanvas.Click += new System.EventHandler(this.btnGLCanvas_Click);
            // 
            // btnFreeType
            // 
            this.btnFreeType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFreeType.Location = new System.Drawing.Point(12, 70);
            this.btnFreeType.Name = "btnFreeType";
            this.btnFreeType.Size = new System.Drawing.Size(260, 23);
            this.btnFreeType.TabIndex = 0;
            this.btnFreeType.Text = "FreeType";
            this.btnFreeType.UseVisualStyleBackColor = true;
            this.btnFreeType.Click += new System.EventHandler(this.btnFreeType_Click);
            // 
            // btnFreeTypeTextVAOElement
            // 
            this.btnFreeTypeTextVAOElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFreeTypeTextVAOElement.Location = new System.Drawing.Point(12, 99);
            this.btnFreeTypeTextVAOElement.Name = "btnFreeTypeTextVAOElement";
            this.btnFreeTypeTextVAOElement.Size = new System.Drawing.Size(260, 23);
            this.btnFreeTypeTextVAOElement.TabIndex = 0;
            this.btnFreeTypeTextVAOElement.Text = "FreeTypeTextVAOElement";
            this.btnFreeTypeTextVAOElement.UseVisualStyleBackColor = true;
            this.btnFreeTypeTextVAOElement.Click += new System.EventHandler(this.btnFreeTypeTextVAOElement_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnFreeTypeTextVAOElement);
            this.Controls.Add(this.btnFreeType);
            this.Controls.Add(this.btnGLCanvas);
            this.Controls.Add(this.btnUnmanagedArray);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUnmanagedArray;
        private System.Windows.Forms.Button btnGLCanvas;
        private System.Windows.Forms.Button btnFreeType;
        private System.Windows.Forms.Button btnFreeTypeTextVAOElement;
    }
}