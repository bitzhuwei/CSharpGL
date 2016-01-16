namespace ShaderLab
{
    partial class FormShaderLab
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtVertexShader = new System.Windows.Forms.TextBox();
            this.btnOpenVertexShader = new System.Windows.Forms.Button();
            this.txtFragmentShader = new System.Windows.Forms.TextBox();
            this.btnFragmentShader = new System.Windows.Forms.Button();
            this.btnCompile = new System.Windows.Forms.Button();
            this.openShaderFile = new System.Windows.Forms.OpenFileDialog();
            this.glCanvas1 = new CSharpGL.Winforms.GLCanvas();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtVertexShader);
            this.splitContainer1.Panel1.Controls.Add(this.btnOpenVertexShader);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtFragmentShader);
            this.splitContainer1.Panel2.Controls.Add(this.btnFragmentShader);
            this.splitContainer1.Size = new System.Drawing.Size(802, 470);
            this.splitContainer1.SplitterDistance = 370;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtVertexShader
            // 
            this.txtVertexShader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVertexShader.Location = new System.Drawing.Point(12, 41);
            this.txtVertexShader.Multiline = true;
            this.txtVertexShader.Name = "txtVertexShader";
            this.txtVertexShader.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtVertexShader.Size = new System.Drawing.Size(355, 414);
            this.txtVertexShader.TabIndex = 1;
            // 
            // btnOpenVertexShader
            // 
            this.btnOpenVertexShader.Location = new System.Drawing.Point(12, 12);
            this.btnOpenVertexShader.Name = "btnOpenVertexShader";
            this.btnOpenVertexShader.Size = new System.Drawing.Size(174, 23);
            this.btnOpenVertexShader.TabIndex = 0;
            this.btnOpenVertexShader.Text = "vertex shader";
            this.btnOpenVertexShader.UseVisualStyleBackColor = true;
            this.btnOpenVertexShader.Click += new System.EventHandler(this.btnOpenVertexShader_Click);
            // 
            // txtFragmentShader
            // 
            this.txtFragmentShader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFragmentShader.Location = new System.Drawing.Point(3, 41);
            this.txtFragmentShader.Multiline = true;
            this.txtFragmentShader.Name = "txtFragmentShader";
            this.txtFragmentShader.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFragmentShader.Size = new System.Drawing.Size(413, 414);
            this.txtFragmentShader.TabIndex = 1;
            // 
            // btnFragmentShader
            // 
            this.btnFragmentShader.Location = new System.Drawing.Point(3, 12);
            this.btnFragmentShader.Name = "btnFragmentShader";
            this.btnFragmentShader.Size = new System.Drawing.Size(174, 23);
            this.btnFragmentShader.TabIndex = 0;
            this.btnFragmentShader.Text = "fragment shader";
            this.btnFragmentShader.UseVisualStyleBackColor = true;
            this.btnFragmentShader.Click += new System.EventHandler(this.btnFragmentShader_Click);
            // 
            // btnCompile
            // 
            this.btnCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompile.Location = new System.Drawing.Point(640, 488);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(174, 23);
            this.btnCompile.TabIndex = 0;
            this.btnCompile.Text = "compile";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // openShaderFile
            // 
            this.openShaderFile.Title = "open shader file";
            // 
            // glCanvas1
            // 
            this.glCanvas1.Location = new System.Drawing.Point(12, 489);
            this.glCanvas1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.OpenGLVersion = CSharpGL.Objects.RenderContexts.GLVersion.OpenGL2_1;
            this.glCanvas1.RenderTrigger = CSharpGL.Winforms.RenderTriggers.TimerBased;
            this.glCanvas1.Size = new System.Drawing.Size(200, 22);
            this.glCanvas1.TabIndex = 1;
            this.glCanvas1.Visible = false;
            // 
            // FormShaderLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 523);
            this.Controls.Add(this.glCanvas1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnCompile);
            this.Name = "FormShaderLab";
            this.Text = "FormShaderLab";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtVertexShader;
        private System.Windows.Forms.Button btnOpenVertexShader;
        private System.Windows.Forms.TextBox txtFragmentShader;
        private System.Windows.Forms.Button btnFragmentShader;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.OpenFileDialog openShaderFile;
        private CSharpGL.Winforms.GLCanvas glCanvas1;
    }
}