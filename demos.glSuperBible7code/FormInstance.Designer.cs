namespace demos.glSuperBible7code {
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
            lblValidKeys = new Label();
            lblValidButtons = new Label();
            SuspendLayout();
            // 
            // glCanvas1
            // 
            glCanvas1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            glCanvas1.Location = new Point(10, 45);
            glCanvas1.Margin = new Padding(2);
            glCanvas1.Name = "glCanvas1";
            glCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            glCanvas1.Size = new Size(660, 355);
            glCanvas1.TabIndex = 0;
            glCanvas1.TimerTriggerInterval = 1;
            // 
            // lblValidKeys
            // 
            lblValidKeys.AutoSize = true;
            lblValidKeys.Location = new Point(312, 15);
            lblValidKeys.Name = "lblValidKeys";
            lblValidKeys.Size = new Size(83, 20);
            lblValidKeys.TabIndex = 2;
            lblValidKeys.Text = "valid keys:";
            // 
            // lblValidButtons
            // 
            lblValidButtons.AutoSize = true;
            lblValidButtons.Location = new Point(464, 15);
            lblValidButtons.Name = "lblValidButtons";
            lblValidButtons.Size = new Size(108, 20);
            lblValidButtons.TabIndex = 3;
            lblValidButtons.Text = "valid buttons:";
            // 
            // FormInstance
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 410);
            Controls.Add(lblValidButtons);
            Controls.Add(lblValidKeys);
            Controls.Add(glCanvas1);
            Margin = new Padding(2);
            Name = "FormInstance";
            Text = "openGL Program Guide 8th Edition";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private WindowsGLCanvas glCanvas1;
        private Label lblValidKeys;
        private Label lblValidButtons;
    }
}
