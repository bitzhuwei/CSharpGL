namespace IntroductionVideo {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.winGLCanvas1 = new CSharpGL.WinGLCanvas();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnPoints = new System.Windows.Forms.Button();
            this.btnLines = new System.Windows.Forms.Button();
            this.btnPrintCanvas = new System.Windows.Forms.Button();
            this.btnAutoPrintCanvas = new System.Windows.Forms.Button();
            this.btnTexture = new System.Windows.Forms.Button();
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
            this.winGLCanvas1.Location = new System.Drawing.Point(12, 12);
            this.winGLCanvas1.Name = "winGLCanvas1";
            this.winGLCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.winGLCanvas1.Size = new System.Drawing.Size(800, 600);
            this.winGLCanvas1.StencilBits = ((byte)(0));
            this.winGLCanvas1.TabIndex = 0;
            this.winGLCanvas1.TimerTriggerInterval = 40;
            this.winGLCanvas1.UpdateContextVersion = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnPoints
            // 
            this.btnPoints.Location = new System.Drawing.Point(818, 12);
            this.btnPoints.Name = "btnPoints";
            this.btnPoints.Size = new System.Drawing.Size(75, 23);
            this.btnPoints.TabIndex = 1;
            this.btnPoints.Text = "Point";
            this.btnPoints.UseVisualStyleBackColor = true;
            this.btnPoints.Click += new System.EventHandler(this.btnPoint_Click);
            // 
            // btnLines
            // 
            this.btnLines.Location = new System.Drawing.Point(899, 12);
            this.btnLines.Name = "btnLines";
            this.btnLines.Size = new System.Drawing.Size(75, 23);
            this.btnLines.TabIndex = 1;
            this.btnLines.Text = "Lines";
            this.btnLines.UseVisualStyleBackColor = true;
            this.btnLines.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnPrintCanvas
            // 
            this.btnPrintCanvas.Location = new System.Drawing.Point(818, 250);
            this.btnPrintCanvas.Name = "btnPrintCanvas";
            this.btnPrintCanvas.Size = new System.Drawing.Size(145, 23);
            this.btnPrintCanvas.TabIndex = 1;
            this.btnPrintCanvas.Text = "Print Canvas";
            this.btnPrintCanvas.UseVisualStyleBackColor = true;
            this.btnPrintCanvas.Click += new System.EventHandler(this.btnPrintCanvas_Click);
            // 
            // btnAutoPrintCanvas
            // 
            this.btnAutoPrintCanvas.Location = new System.Drawing.Point(818, 221);
            this.btnAutoPrintCanvas.Name = "btnAutoPrintCanvas";
            this.btnAutoPrintCanvas.Size = new System.Drawing.Size(145, 23);
            this.btnAutoPrintCanvas.TabIndex = 1;
            this.btnAutoPrintCanvas.Text = "Auto Print Canvas";
            this.btnAutoPrintCanvas.UseVisualStyleBackColor = true;
            this.btnAutoPrintCanvas.Click += new System.EventHandler(this.btnAutoPrintCanvas_Click);
            // 
            // btnTexture
            // 
            this.btnTexture.Location = new System.Drawing.Point(980, 12);
            this.btnTexture.Name = "btnTexture";
            this.btnTexture.Size = new System.Drawing.Size(75, 23);
            this.btnTexture.TabIndex = 1;
            this.btnTexture.Text = "Texture";
            this.btnTexture.UseVisualStyleBackColor = true;
            this.btnTexture.Click += new System.EventHandler(this.btnTexture_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 623);
            this.Controls.Add(this.btnTexture);
            this.Controls.Add(this.btnLines);
            this.Controls.Add(this.btnAutoPrintCanvas);
            this.Controls.Add(this.btnPrintCanvas);
            this.Controls.Add(this.btnPoints);
            this.Controls.Add(this.winGLCanvas1);
            this.Name = "Form1";
            this.Text = "Cube - CSharpGL";
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CSharpGL.WinGLCanvas winGLCanvas1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnPoints;
        private System.Windows.Forms.Button btnLines;
        private System.Windows.Forms.Button btnPrintCanvas;
        private System.Windows.Forms.Button btnAutoPrintCanvas;
        private System.Windows.Forms.Button btnTexture;
    }
}

