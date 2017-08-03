namespace RenderToTexture
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
            this.components = new System.ComponentModel.Container();
            this.winGLCanvas1 = new CSharpGL.WinGLCanvas();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkRotateRect = new System.Windows.Forms.CheckBox();
            this.chkRotateTeapot = new System.Windows.Forms.CheckBox();
            this.chkRenderBackground = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // winGLCanvas1
            // 
            this.winGLCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winGLCanvas1.Location = new System.Drawing.Point(0, 38);
            this.winGLCanvas1.Name = "winGLCanvas1";
            this.winGLCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.winGLCanvas1.Size = new System.Drawing.Size(826, 504);
            this.winGLCanvas1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkRotateRect
            // 
            this.chkRotateRect.AutoSize = true;
            this.chkRotateRect.Checked = true;
            this.chkRotateRect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRotateRect.Font = new System.Drawing.Font("宋体", 12F);
            this.chkRotateRect.Location = new System.Drawing.Point(12, 12);
            this.chkRotateRect.Name = "chkRotateRect";
            this.chkRotateRect.Size = new System.Drawing.Size(115, 20);
            this.chkRotateRect.TabIndex = 1;
            this.chkRotateRect.Text = "Rotate Rect";
            this.chkRotateRect.UseVisualStyleBackColor = true;
            this.chkRotateRect.CheckedChanged += new System.EventHandler(this.chkRotateRect_CheckedChanged);
            // 
            // chkRotateTeapot
            // 
            this.chkRotateTeapot.AutoSize = true;
            this.chkRotateTeapot.Checked = true;
            this.chkRotateTeapot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRotateTeapot.Font = new System.Drawing.Font("宋体", 12F);
            this.chkRotateTeapot.Location = new System.Drawing.Point(133, 12);
            this.chkRotateTeapot.Name = "chkRotateTeapot";
            this.chkRotateTeapot.Size = new System.Drawing.Size(131, 20);
            this.chkRotateTeapot.TabIndex = 1;
            this.chkRotateTeapot.Text = "Rotate Teapot";
            this.chkRotateTeapot.UseVisualStyleBackColor = true;
            this.chkRotateTeapot.CheckedChanged += new System.EventHandler(this.chkRotateTeapot_CheckedChanged);
            // 
            // chkRenderBackground
            // 
            this.chkRenderBackground.AutoSize = true;
            this.chkRenderBackground.Font = new System.Drawing.Font("宋体", 12F);
            this.chkRenderBackground.Location = new System.Drawing.Point(270, 12);
            this.chkRenderBackground.Name = "chkRenderBackground";
            this.chkRenderBackground.Size = new System.Drawing.Size(203, 20);
            this.chkRenderBackground.TabIndex = 1;
            this.chkRenderBackground.Text = "Transparent Background";
            this.chkRenderBackground.UseVisualStyleBackColor = true;
            this.chkRenderBackground.CheckedChanged += new System.EventHandler(this.chkTransparentBackground_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 542);
            this.Controls.Add(this.chkRenderBackground);
            this.Controls.Add(this.chkRotateTeapot);
            this.Controls.Add(this.chkRotateRect);
            this.Controls.Add(this.winGLCanvas1);
            this.Name = "FormMain";
            this.Text = "Render To Texture - CSharpGL";
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharpGL.WinGLCanvas winGLCanvas1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkRotateRect;
        private System.Windows.Forms.CheckBox chkRotateTeapot;
        private System.Windows.Forms.CheckBox chkRenderBackground;
    }
}