namespace TessellatedTriangle
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInner0 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOuter0 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOuter1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOuter2 = new System.Windows.Forms.TextBox();
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
            this.winGLCanvas1.Location = new System.Drawing.Point(237, 12);
            this.winGLCanvas1.Name = "winGLCanvas1";
            this.winGLCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.winGLCanvas1.Size = new System.Drawing.Size(696, 535);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "gl_TessLevelInner[0]:";
            // 
            // txtInner0
            // 
            this.txtInner0.Font = new System.Drawing.Font("宋体", 14F);
            this.txtInner0.Location = new System.Drawing.Point(16, 34);
            this.txtInner0.Name = "txtInner0";
            this.txtInner0.Size = new System.Drawing.Size(100, 29);
            this.txtInner0.TabIndex = 2;
            this.txtInner0.Text = "5.0";
            this.txtInner0.TextChanged += new System.EventHandler(this.txtInner0_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "gl_TessLevelOuter[0]:";
            // 
            // txtOuter0
            // 
            this.txtOuter0.Font = new System.Drawing.Font("宋体", 14F);
            this.txtOuter0.Location = new System.Drawing.Point(16, 98);
            this.txtOuter0.Name = "txtOuter0";
            this.txtOuter0.Size = new System.Drawing.Size(100, 29);
            this.txtOuter0.TabIndex = 2;
            this.txtOuter0.Text = "5.0";
            this.txtOuter0.TextChanged += new System.EventHandler(this.txtOuter0_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14F);
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "gl_TessLevelOuter[1]:";
            // 
            // txtOuter1
            // 
            this.txtOuter1.Font = new System.Drawing.Font("宋体", 14F);
            this.txtOuter1.Location = new System.Drawing.Point(16, 163);
            this.txtOuter1.Name = "txtOuter1";
            this.txtOuter1.Size = new System.Drawing.Size(100, 29);
            this.txtOuter1.TabIndex = 2;
            this.txtOuter1.Text = "5.0";
            this.txtOuter1.TextChanged += new System.EventHandler(this.txtOuter1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14F);
            this.label4.Location = new System.Drawing.Point(12, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "gl_TessLevelOuter[2]:";
            // 
            // txtOuter2
            // 
            this.txtOuter2.Font = new System.Drawing.Font("宋体", 14F);
            this.txtOuter2.Location = new System.Drawing.Point(16, 228);
            this.txtOuter2.Name = "txtOuter2";
            this.txtOuter2.Size = new System.Drawing.Size(100, 29);
            this.txtOuter2.TabIndex = 2;
            this.txtOuter2.Text = "5.0";
            this.txtOuter2.TextChanged += new System.EventHandler(this.txtOuter2_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 559);
            this.Controls.Add(this.txtOuter2);
            this.Controls.Add(this.txtOuter1);
            this.Controls.Add(this.txtOuter0);
            this.Controls.Add(this.txtInner0);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.winGLCanvas1);
            this.Name = "Form1";
            this.Text = "Cube - CSharpGL";
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharpGL.WinGLCanvas winGLCanvas1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInner0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOuter0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOuter1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOuter2;
    }
}

