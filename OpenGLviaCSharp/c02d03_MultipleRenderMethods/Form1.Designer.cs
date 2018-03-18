namespace c02d03_MultipleRenderMethods
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.winGLCanvas1 = new CSharpGL.WinGLCanvas();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rdoSingleColor = new System.Windows.Forms.RadioButton();
            this.rdoMultipleTextures = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // winGLCanvas1
            // 
            this.winGLCanvas1.AccumAlphaBits = ((byte)(0));
            this.winGLCanvas1.AccumBits = ((byte)(0));
            this.winGLCanvas1.AccumBlueBits = ((byte)(0));
            this.winGLCanvas1.AccumGreenBits = ((byte)(0));
            this.winGLCanvas1.AccumRedBits = ((byte)(0));
            this.winGLCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winGLCanvas1.Location = new System.Drawing.Point(0, 37);
            this.winGLCanvas1.Name = "winGLCanvas1";
            this.winGLCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.winGLCanvas1.Size = new System.Drawing.Size(604, 425);
            this.winGLCanvas1.StencilBits = ((byte)(0));
            this.winGLCanvas1.TabIndex = 0;
            this.winGLCanvas1.TimerTriggerInterval = 40;
            this.winGLCanvas1.UpdateContextVersion = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rdoSingleColor
            // 
            this.rdoSingleColor.AutoSize = true;
            this.rdoSingleColor.Checked = true;
            this.rdoSingleColor.Location = new System.Drawing.Point(12, 12);
            this.rdoSingleColor.Name = "rdoSingleColor";
            this.rdoSingleColor.Size = new System.Drawing.Size(95, 16);
            this.rdoSingleColor.TabIndex = 1;
            this.rdoSingleColor.TabStop = true;
            this.rdoSingleColor.Text = "Single Color";
            this.rdoSingleColor.UseVisualStyleBackColor = true;
            this.rdoSingleColor.CheckedChanged += new System.EventHandler(this.rdoSingleColor_CheckedChanged);
            // 
            // rdoMultipleTextures
            // 
            this.rdoMultipleTextures.AutoSize = true;
            this.rdoMultipleTextures.Location = new System.Drawing.Point(113, 12);
            this.rdoMultipleTextures.Name = "rdoMultipleTextures";
            this.rdoMultipleTextures.Size = new System.Drawing.Size(125, 16);
            this.rdoMultipleTextures.TabIndex = 2;
            this.rdoMultipleTextures.Text = "Multiple Textures";
            this.rdoMultipleTextures.UseVisualStyleBackColor = true;
            this.rdoMultipleTextures.CheckedChanged += new System.EventHandler(this.rdoMultipleTextures_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 462);
            this.Controls.Add(this.rdoMultipleTextures);
            this.Controls.Add(this.rdoSingleColor);
            this.Controls.Add(this.winGLCanvas1);
            this.Name = "Form1";
            this.Text = "Multiple Render Methods - CSharpGL";
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharpGL.WinGLCanvas winGLCanvas1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton rdoSingleColor;
        private System.Windows.Forms.RadioButton rdoMultipleTextures;
    }
}

