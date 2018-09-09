namespace MultipleContexts
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.winGLCanvas1 = new CSharpGL.WinGLCanvas();
            this.winGLCanvas2 = new CSharpGL.WinGLCanvas();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.winGLCanvas1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.winGLCanvas2);
            this.splitContainer1.Size = new System.Drawing.Size(824, 413);
            this.splitContainer1.SplitterDistance = 351;
            this.splitContainer1.TabIndex = 0;
            // 
            // winGLCanvas1
            // 
            this.winGLCanvas1.AccumAlphaBits = ((byte)(0));
            this.winGLCanvas1.AccumBits = ((byte)(0));
            this.winGLCanvas1.AccumBlueBits = ((byte)(0));
            this.winGLCanvas1.AccumGreenBits = ((byte)(0));
            this.winGLCanvas1.AccumRedBits = ((byte)(0));
            this.winGLCanvas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winGLCanvas1.Location = new System.Drawing.Point(0, 0);
            this.winGLCanvas1.Name = "winGLCanvas1";
            this.winGLCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.winGLCanvas1.Size = new System.Drawing.Size(351, 413);
            this.winGLCanvas1.StencilBits = ((byte)(0));
            this.winGLCanvas1.TabIndex = 0;
            this.winGLCanvas1.TimerTriggerInterval = 40;
            this.winGLCanvas1.UpdateContextVersion = true;
            // 
            // winGLCanvas2
            // 
            this.winGLCanvas2.AccumAlphaBits = ((byte)(0));
            this.winGLCanvas2.AccumBits = ((byte)(0));
            this.winGLCanvas2.AccumBlueBits = ((byte)(0));
            this.winGLCanvas2.AccumGreenBits = ((byte)(0));
            this.winGLCanvas2.AccumRedBits = ((byte)(0));
            this.winGLCanvas2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winGLCanvas2.Location = new System.Drawing.Point(0, 0);
            this.winGLCanvas2.Name = "winGLCanvas2";
            this.winGLCanvas2.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.winGLCanvas2.Size = new System.Drawing.Size(469, 413);
            this.winGLCanvas2.StencilBits = ((byte)(0));
            this.winGLCanvas2.TabIndex = 0;
            this.winGLCanvas2.TimerTriggerInterval = 40;
            this.winGLCanvas2.UpdateContextVersion = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 413);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private CSharpGL.WinGLCanvas winGLCanvas1;
        private CSharpGL.WinGLCanvas winGLCanvas2;
        private System.Windows.Forms.Timer timer1;

    }
}

