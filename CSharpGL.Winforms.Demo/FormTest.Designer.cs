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
            this.btnModernSingleTextureFont = new System.Windows.Forms.Button();
            this.btnPyramidVAOElement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // btnUnmanagedArray
            //
            this.btnUnmanagedArray.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnmanagedArray.Location = new System.Drawing.Point(16, 15);
            this.btnUnmanagedArray.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnmanagedArray.Name = "btnUnmanagedArray";
            this.btnUnmanagedArray.Size = new System.Drawing.Size(347, 29);
            this.btnUnmanagedArray.TabIndex = 0;
            this.btnUnmanagedArray.Text = "UnmanagedArray";
            this.btnUnmanagedArray.UseVisualStyleBackColor = true;
            this.btnUnmanagedArray.Click += new System.EventHandler(this.btnUnmanagedArray_Click);
            //
            // btnGLCanvas
            //
            this.btnGLCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGLCanvas.Location = new System.Drawing.Point(16, 51);
            this.btnGLCanvas.Margin = new System.Windows.Forms.Padding(4);
            this.btnGLCanvas.Name = "btnGLCanvas";
            this.btnGLCanvas.Size = new System.Drawing.Size(347, 29);
            this.btnGLCanvas.TabIndex = 0;
            this.btnGLCanvas.Text = "GLCanvas";
            this.btnGLCanvas.UseVisualStyleBackColor = true;
            this.btnGLCanvas.Click += new System.EventHandler(this.btnGLCanvas_Click);
            //
            // btnModernSingleTextureFont
            //
            this.btnModernSingleTextureFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModernSingleTextureFont.Location = new System.Drawing.Point(16, 125);
            this.btnModernSingleTextureFont.Margin = new System.Windows.Forms.Padding(4);
            this.btnModernSingleTextureFont.Name = "btnModernSingleTextureFont";
            this.btnModernSingleTextureFont.Size = new System.Drawing.Size(347, 29);
            this.btnModernSingleTextureFont.TabIndex = 0;
            this.btnModernSingleTextureFont.Text = "ModernSingleTextureFont";
            this.btnModernSingleTextureFont.UseVisualStyleBackColor = true;
            this.btnModernSingleTextureFont.Click += new System.EventHandler(this.btnFreeTypeTextVAOElement_Click);
            //
            // btnPyramidVAOElement
            //
            this.btnPyramidVAOElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPyramidVAOElement.Location = new System.Drawing.Point(16, 88);
            this.btnPyramidVAOElement.Margin = new System.Windows.Forms.Padding(4);
            this.btnPyramidVAOElement.Name = "btnPyramidVAOElement";
            this.btnPyramidVAOElement.Size = new System.Drawing.Size(347, 29);
            this.btnPyramidVAOElement.TabIndex = 0;
            this.btnPyramidVAOElement.Text = "PyramidVAOElement";
            this.btnPyramidVAOElement.UseVisualStyleBackColor = true;
            this.btnPyramidVAOElement.Click += new System.EventHandler(this.btnPyramidVAOElement_Click);
            //
            // FormTest
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 328);
            this.Controls.Add(this.btnPyramidVAOElement);
            this.Controls.Add(this.btnModernSingleTextureFont);
            this.Controls.Add(this.btnGLCanvas);
            this.Controls.Add(this.btnUnmanagedArray);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUnmanagedArray;
        private System.Windows.Forms.Button btnGLCanvas;
        private System.Windows.Forms.Button btnModernSingleTextureFont;
        private System.Windows.Forms.Button btnPyramidVAOElement;
    }
}