namespace ParticleSystem.TransformFeedback
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
            this.chkRenderWireframe = new System.Windows.Forms.CheckBox();
            this.chkRenderBody = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // winGLCanvas1
            // 
            this.winGLCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winGLCanvas1.Location = new System.Drawing.Point(12, 38);
            this.winGLCanvas1.Name = "winGLCanvas1";
            this.winGLCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.winGLCanvas1.Size = new System.Drawing.Size(961, 527);
            this.winGLCanvas1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkRenderWireframe
            // 
            this.chkRenderWireframe.AutoSize = true;
            this.chkRenderWireframe.Checked = true;
            this.chkRenderWireframe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRenderWireframe.Font = new System.Drawing.Font("宋体", 12F);
            this.chkRenderWireframe.Location = new System.Drawing.Point(12, 12);
            this.chkRenderWireframe.Name = "chkRenderWireframe";
            this.chkRenderWireframe.Size = new System.Drawing.Size(155, 20);
            this.chkRenderWireframe.TabIndex = 1;
            this.chkRenderWireframe.Text = "Render Wireframe";
            this.chkRenderWireframe.UseVisualStyleBackColor = true;
            this.chkRenderWireframe.CheckedChanged += new System.EventHandler(this.chkRenderWireframe_CheckedChanged);
            // 
            // chkRenderBody
            // 
            this.chkRenderBody.AutoSize = true;
            this.chkRenderBody.Checked = true;
            this.chkRenderBody.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRenderBody.Font = new System.Drawing.Font("宋体", 12F);
            this.chkRenderBody.Location = new System.Drawing.Point(173, 12);
            this.chkRenderBody.Name = "chkRenderBody";
            this.chkRenderBody.Size = new System.Drawing.Size(115, 20);
            this.chkRenderBody.TabIndex = 2;
            this.chkRenderBody.Text = "Render Body";
            this.chkRenderBody.UseVisualStyleBackColor = true;
            this.chkRenderBody.CheckedChanged += new System.EventHandler(this.chkRenderBody_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 577);
            this.Controls.Add(this.chkRenderBody);
            this.Controls.Add(this.chkRenderWireframe);
            this.Controls.Add(this.winGLCanvas1);
            this.Name = "FormMain";
            this.Text = "Color Coded Picking - CSharpGL";
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharpGL.WinGLCanvas winGLCanvas1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkRenderWireframe;
        private System.Windows.Forms.CheckBox chkRenderBody;
    }
}