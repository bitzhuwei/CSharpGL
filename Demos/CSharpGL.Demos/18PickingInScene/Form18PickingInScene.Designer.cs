namespace CSharpGL.Demos
{
    partial class Form18PickingInScene
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
            this.openTextureDlg = new System.Windows.Forms.OpenFileDialog();
            this.glCanvas1 = new CSharpGL.GLCanvas();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPickingGeometryType = new System.Windows.Forms.ComboBox();
            this.cmbRenderMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.glCanvas1.Location = new System.Drawing.Point(10, 38);
            this.glCanvas1.Name = "glCanvas1";
            this.glCanvas1.OpenGLVersion = CSharpGL.GLVersion.OpenGL2_1;
            this.glCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.glCanvas1.Size = new System.Drawing.Size(970, 614);
            this.glCanvas1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Picking Geometry Type:";
            // 
            // cmbPickingGeometryType
            // 
            this.cmbPickingGeometryType.FormattingEnabled = true;
            this.cmbPickingGeometryType.Location = new System.Drawing.Point(155, 12);
            this.cmbPickingGeometryType.Name = "cmbPickingGeometryType";
            this.cmbPickingGeometryType.Size = new System.Drawing.Size(121, 20);
            this.cmbPickingGeometryType.TabIndex = 2;
            this.cmbPickingGeometryType.SelectedIndexChanged += new System.EventHandler(this.cmbPickingGeometryType_SelectedIndexChanged);
            // 
            // cmbRenderMode
            // 
            this.cmbRenderMode.FormattingEnabled = true;
            this.cmbRenderMode.Location = new System.Drawing.Point(365, 12);
            this.cmbRenderMode.Name = "cmbRenderMode";
            this.cmbRenderMode.Size = new System.Drawing.Size(121, 20);
            this.cmbRenderMode.TabIndex = 4;
            this.cmbRenderMode.SelectedIndexChanged += new System.EventHandler(this.cmbRenderMode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Render Mode:";
            // 
            // Form18PickingInScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 662);
            this.Controls.Add(this.cmbRenderMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPickingGeometryType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.glCanvas1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form18PickingInScene";
            this.Text = "Form18PickingInScene";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GLCanvas glCanvas1;
        private System.Windows.Forms.OpenFileDialog openTextureDlg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPickingGeometryType;
        private System.Windows.Forms.ComboBox cmbRenderMode;
        private System.Windows.Forms.Label label2;
    }
}