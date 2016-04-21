namespace Radar.Winform
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
            this.glCanvas1 = new CSharpGL.Winforms.GLCanvas();
            this.trackPointSize = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPointSize)).BeginInit();
            this.SuspendLayout();
            // 
            // glCanvas1
            // 
            this.glCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glCanvas1.Location = new System.Drawing.Point(13, 75);
            this.glCanvas1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.OpenGLVersion = CSharpGL.Objects.RenderContexts.GLVersion.OpenGL2_1;
            this.glCanvas1.RenderTrigger = CSharpGL.Winforms.RenderTriggers.Manual;
            this.glCanvas1.Size = new System.Drawing.Size(980, 585);
            this.glCanvas1.TabIndex = 0;
            // 
            // trackPointSize
            // 
            this.trackPointSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackPointSize.Location = new System.Drawing.Point(111, 12);
            this.trackPointSize.Maximum = 20;
            this.trackPointSize.Minimum = 1;
            this.trackPointSize.Name = "trackPointSize";
            this.trackPointSize.Size = new System.Drawing.Size(883, 56);
            this.trackPointSize.TabIndex = 1;
            this.trackPointSize.Value = 2;
            this.trackPointSize.Scroll += new System.EventHandler(this.trackPointSize_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "point size:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 673);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackPointSize);
            this.Controls.Add(this.glCanvas1);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPointSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharpGL.Winforms.GLCanvas glCanvas1;
        private System.Windows.Forms.TrackBar trackPointSize;
        private System.Windows.Forms.Label label1;
    }
}