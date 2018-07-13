namespace d00_HelloSoftGL
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
            this.winSoftGLCanvas1 = new CSharpGL.WinSoftGLCanvas();
            ((System.ComponentModel.ISupportInitialize)(this.winSoftGLCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // winSoftGLCanvas1
            // 
            this.winSoftGLCanvas1.AccumAlphaBits = ((byte)(0));
            this.winSoftGLCanvas1.AccumBits = ((byte)(0));
            this.winSoftGLCanvas1.AccumBlueBits = ((byte)(0));
            this.winSoftGLCanvas1.AccumGreenBits = ((byte)(0));
            this.winSoftGLCanvas1.AccumRedBits = ((byte)(0));
            this.winSoftGLCanvas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winSoftGLCanvas1.Location = new System.Drawing.Point(0, 0);
            this.winSoftGLCanvas1.Name = "winSoftGLCanvas1";
            this.winSoftGLCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.winSoftGLCanvas1.Size = new System.Drawing.Size(616, 407);
            this.winSoftGLCanvas1.StencilBits = ((byte)(0));
            this.winSoftGLCanvas1.TabIndex = 0;
            this.winSoftGLCanvas1.TimerTriggerInterval = 40;
            this.winSoftGLCanvas1.UpdateContextVersion = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 407);
            this.Controls.Add(this.winSoftGLCanvas1);
            this.Name = "Form1";
            this.Text = "Hello SoftGL";
            ((System.ComponentModel.ISupportInitialize)(this.winSoftGLCanvas1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CSharpGL.WinSoftGLCanvas winSoftGLCanvas1;
    }
}

