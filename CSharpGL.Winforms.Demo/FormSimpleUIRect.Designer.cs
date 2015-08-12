namespace CSharpGL.Winforms.Demo
{
    partial class FormSimpleUIRect
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
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.glCanvas1 = new CSharpGL.Winforms.GLCanvas();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.Location = new System.Drawing.Point(12, 12);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(788, 68);
            this.txtInfo.TabIndex = 4;
            // 
            // glCanvas1
            // 
            this.glCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glCanvas1.Location = new System.Drawing.Point(13, 87);
            this.glCanvas1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.OpenGLVersion = CSharpGL.Objects.RenderContexts.GLVersion.OpenGL2_1;
            this.glCanvas1.RenderTrigger = CSharpGL.Winforms.RenderTriggers.TimerBased;
            this.glCanvas1.Size = new System.Drawing.Size(786, 353);
            this.glCanvas1.TabIndex = 3;
            this.glCanvas1.OpenGLDraw += new System.EventHandler<CSharpGL.Winforms.RenderEventArgs>(this.glCanvas1_OpenGLDraw);
            this.glCanvas1.Load += new System.EventHandler(this.FormTranslateOnScreen_Load);
            this.glCanvas1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.glCanvas1_KeyPress);
            this.glCanvas1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glCanvas1_MouseDown);
            this.glCanvas1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glCanvas1_MouseMove);
            this.glCanvas1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glCanvas1_MouseUp);
            this.glCanvas1.Resize += new System.EventHandler(this.glCanvas_Resize);
            // 
            // FormSimpleUIRect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 453);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.glCanvas1);
            this.Name = "FormSimpleUIRect";
            this.Text = "FormSimpleUIRect";
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInfo;
        private GLCanvas glCanvas1;

    }
}