namespace CSharpGL.Demos
{
    partial class Form12Billboard
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
            this.openTextureDlg = new System.Windows.Forms.OpenFileDialog();
            this.glCanvas1 = new CSharpGL.GLCanvas();
            this.lblCubePosition = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTimerEnabled = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // openTextureDlg
            // 
            this.openTextureDlg.Filter = "True Type Font File(*.TTF;*.OTF)|*.TTF;*.OTF";
            // 
            // glCanvas1
            // 
            this.glCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glCanvas1.Location = new System.Drawing.Point(10, 26);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.OpenGLVersion = CSharpGL.GLVersion.OpenGL2_1;
            this.glCanvas1.RenderTrigger = CSharpGL.RenderTriggers.TimerBased;
            this.glCanvas1.ShowSystemCursor = true;
            this.glCanvas1.Size = new System.Drawing.Size(568, 402);
            this.glCanvas1.TabIndex = 0;
            this.glCanvas1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.glCanvas1_KeyPress);
            // 
            // lblCubePosition
            // 
            this.lblCubePosition.AutoSize = true;
            this.lblCubePosition.Font = new System.Drawing.Font("宋体", 12F);
            this.lblCubePosition.Location = new System.Drawing.Point(7, 7);
            this.lblCubePosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCubePosition.Name = "lblCubePosition";
            this.lblCubePosition.Size = new System.Drawing.Size(144, 16);
            this.lblCubePosition.TabIndex = 4;
            this.lblCubePosition.Text = "Cube Pos: x, y, z";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTimerEnabled
            // 
            this.lblTimerEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimerEnabled.AutoSize = true;
            this.lblTimerEnabled.Font = new System.Drawing.Font("宋体", 12F);
            this.lblTimerEnabled.Location = new System.Drawing.Point(544, 7);
            this.lblTimerEnabled.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimerEnabled.Name = "lblTimerEnabled";
            this.lblTimerEnabled.Size = new System.Drawing.Size(32, 16);
            this.lblTimerEnabled.TabIndex = 4;
            this.lblTimerEnabled.Text = "-|-";
            // 
            // Form12Billboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 438);
            this.Controls.Add(this.lblTimerEnabled);
            this.Controls.Add(this.lblCubePosition);
            this.Controls.Add(this.glCanvas1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form12Billboard";
            this.Text = "Form12Billboard";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GLCanvas glCanvas1;
        private System.Windows.Forms.OpenFileDialog openTextureDlg;
        private System.Windows.Forms.Label lblCubePosition;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTimerEnabled;
    }
}