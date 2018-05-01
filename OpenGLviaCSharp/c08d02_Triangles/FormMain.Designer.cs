namespace c08d02_Triangles
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
            this.winGLCanvas1 = new CSharpGL.WinGLCanvas();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rdoRandom = new System.Windows.Forms.RadioButton();
            this.rdogl_VertexID = new System.Windows.Forms.RadioButton();
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
            this.winGLCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winGLCanvas1.Location = new System.Drawing.Point(353, 12);
            this.winGLCanvas1.Name = "winGLCanvas1";
            this.winGLCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.winGLCanvas1.Size = new System.Drawing.Size(620, 553);
            this.winGLCanvas1.StencilBits = ((byte)(0));
            this.winGLCanvas1.TabIndex = 0;
            this.winGLCanvas1.TimerTriggerInterval = 40;
            this.winGLCanvas1.UpdateContextVersion = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 18F);
            this.textBox1.Location = new System.Drawing.Point(12, 34);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(335, 531);
            this.textBox1.TabIndex = 1;
            // 
            // rdoRandom
            // 
            this.rdoRandom.AutoSize = true;
            this.rdoRandom.Checked = true;
            this.rdoRandom.Location = new System.Drawing.Point(12, 12);
            this.rdoRandom.Name = "rdoRandom";
            this.rdoRandom.Size = new System.Drawing.Size(95, 16);
            this.rdoRandom.TabIndex = 2;
            this.rdoRandom.TabStop = true;
            this.rdoRandom.Text = "Random Color";
            this.rdoRandom.UseVisualStyleBackColor = true;
            this.rdoRandom.CheckedChanged += new System.EventHandler(this.rdoRandom_CheckedChanged);
            // 
            // rdogl_VertexID
            // 
            this.rdogl_VertexID.AutoSize = true;
            this.rdogl_VertexID.Location = new System.Drawing.Point(113, 12);
            this.rdogl_VertexID.Name = "rdogl_VertexID";
            this.rdogl_VertexID.Size = new System.Drawing.Size(125, 16);
            this.rdogl_VertexID.TabIndex = 2;
            this.rdogl_VertexID.Text = "gl_VertexID Color";
            this.rdogl_VertexID.UseVisualStyleBackColor = true;
            this.rdogl_VertexID.CheckedChanged += new System.EventHandler(this.rdogl_VertexID_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 577);
            this.Controls.Add(this.rdogl_VertexID);
            this.Controls.Add(this.rdoRandom);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.winGLCanvas1);
            this.Name = "FormMain";
            this.Text = "c08d02_Triangles - CSharpGL";
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharpGL.WinGLCanvas winGLCanvas1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton rdoRandom;
        private System.Windows.Forms.RadioButton rdogl_VertexID;
    }
}