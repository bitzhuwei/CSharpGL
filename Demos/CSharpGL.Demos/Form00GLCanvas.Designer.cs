using CSharpGL.Windows;
namespace CSharpGL.Demos
{
    partial class Form00GLCanvas
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.glCanvas1 = new CSharpGL.Windows.GLCanvas();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // glCanvas1
            // 
            this.glCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glCanvas1.Location = new System.Drawing.Point(13, 13);
            this.glCanvas1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.OpenGLVersion = CSharpGL.Windows.GLVersion.OpenGL2_1;
            this.glCanvas1.RenderTrigger = CSharpGL.Windows.RenderTriggers.TimerBased;
            this.glCanvas1.Size = new System.Drawing.Size(705, 508);
            this.glCanvas1.TabIndex = 0;
            this.glCanvas1.OpenGLDraw += new System.EventHandler<System.Windows.Forms.PaintEventArgs>(this.glCanvas1_OpenGLDraw);
            // 
            // Form00GLCanvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 534);
            this.Controls.Add(this.glCanvas1);
            this.Name = "Form00GLCanvas";
            this.Text = "Form00GLCanvas - random background";
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GLCanvas glCanvas1;
        private System.Windows.Forms.Timer timer1;
    }
}