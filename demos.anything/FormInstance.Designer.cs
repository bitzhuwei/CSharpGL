namespace demos.anything {
    partial class FormInstance {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            glCanvas1 = new WindowsGLCanvas();
            statusStrip1 = new StatusStrip();
            lblInfo = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // glCanvas1
            // 
            glCanvas1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            glCanvas1.Location = new Point(10, 11);
            glCanvas1.Margin = new Padding(2);
            glCanvas1.Name = "glCanvas1";
            glCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            glCanvas1.Size = new Size(660, 375);
            glCanvas1.TabIndex = 0;
            glCanvas1.TimerTriggerInterval = 1;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblInfo });
            statusStrip1.Location = new Point(0, 384);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(680, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblInfo
            // 
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(13, 20);
            lblInfo.Text = " ";
            // 
            // FormInstance
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 410);
            Controls.Add(statusStrip1);
            Controls.Add(glCanvas1);
            Margin = new Padding(2);
            Name = "FormInstance";
            Text = "openGL Program Guide 8th Edition";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private WindowsGLCanvas glCanvas1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblInfo;
    }
}
