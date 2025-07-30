namespace c11d00_Arcball {
    partial class FormArcball {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.canvas = new demos.OpenGLviaCSharp.WindowsGLCanvas();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.canvas.Size = new System.Drawing.Size(571, 496);
            this.canvas.TabIndex = 0;
            this.canvas.TimerTriggerInterval = 40;
            // 
            // FormArcball
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 496);
            this.Controls.Add(this.canvas);
            this.Name = "FormArcball";
            this.Text = "FormArcball";
            this.ResumeLayout(false);

        }

        #endregion

        private demos.OpenGLviaCSharp.WindowsGLCanvas canvas;
    }
}