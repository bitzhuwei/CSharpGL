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
            this.btnLegacyMultiTextureFont = new System.Windows.Forms.Button();
            this.btnModernSingleTextureFont = new System.Windows.Forms.Button();
            this.btnModernMultiTextureFont = new System.Windows.Forms.Button();
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
            // btnLegacyMultiTextureFont
            //
            this.btnLegacyMultiTextureFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLegacyMultiTextureFont.Location = new System.Drawing.Point(16, 88);
            this.btnLegacyMultiTextureFont.Margin = new System.Windows.Forms.Padding(4);
            this.btnLegacyMultiTextureFont.Name = "btnLegacyMultiTextureFont";
            this.btnLegacyMultiTextureFont.Size = new System.Drawing.Size(347, 29);
            this.btnLegacyMultiTextureFont.TabIndex = 0;
            this.btnLegacyMultiTextureFont.Text = "LegacyMultiTextureFont";
            this.btnLegacyMultiTextureFont.UseVisualStyleBackColor = true;
            this.btnLegacyMultiTextureFont.Click += new System.EventHandler(this.btnLegacyMultiTextureFont_Click);
            //
            // btnModernSingleTextureFont
            //
            this.btnModernSingleTextureFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModernSingleTextureFont.Location = new System.Drawing.Point(19, 162);
            this.btnModernSingleTextureFont.Margin = new System.Windows.Forms.Padding(4);
            this.btnModernSingleTextureFont.Name = "btnModernSingleTextureFont";
            this.btnModernSingleTextureFont.Size = new System.Drawing.Size(347, 29);
            this.btnModernSingleTextureFont.TabIndex = 0;
            this.btnModernSingleTextureFont.Text = "ModernSingleTextureFont";
            this.btnModernSingleTextureFont.UseVisualStyleBackColor = true;
            this.btnModernSingleTextureFont.Click += new System.EventHandler(this.btnFreeTypeTextVAOElement_Click);
            //
            // btnModernMultiTextureFont
            //
            this.btnModernMultiTextureFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModernMultiTextureFont.Location = new System.Drawing.Point(16, 125);
            this.btnModernMultiTextureFont.Margin = new System.Windows.Forms.Padding(4);
            this.btnModernMultiTextureFont.Name = "btnModernMultiTextureFont";
            this.btnModernMultiTextureFont.Size = new System.Drawing.Size(347, 29);
            this.btnModernMultiTextureFont.TabIndex = 0;
            this.btnModernMultiTextureFont.Text = "ModernMultiTextureFont";
            this.btnModernMultiTextureFont.UseVisualStyleBackColor = true;
            this.btnModernMultiTextureFont.Click += new System.EventHandler(this.btnModernMultiTextureFont_Click);
            //
            // FormTest
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 328);
            this.Controls.Add(this.btnModernMultiTextureFont);
            this.Controls.Add(this.btnModernSingleTextureFont);
            this.Controls.Add(this.btnLegacyMultiTextureFont);
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
        private System.Windows.Forms.Button btnLegacyMultiTextureFont;
        private System.Windows.Forms.Button btnModernSingleTextureFont;
        private System.Windows.Forms.Button btnModernMultiTextureFont;
    }
}