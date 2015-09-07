namespace CSharpGL.Winforms.Demo
{
    partial class FormPointSpriteStringElement
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCameraType = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtText = new System.Windows.Forms.TextBox();
            this.btnUpdateText = new System.Windows.Forms.Button();
            this.glCanvas1 = new CSharpGL.Winforms.GLCanvas();
            this.numFontSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lblFontColor = new System.Windows.Forms.Label();
            this.numMaxRowWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRowWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCameraType});
            this.statusStrip1.Location = new System.Drawing.Point(0, 484);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 25);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblCameraType
            // 
            this.lblCameraType.Name = "lblCameraType";
            this.lblCameraType.Size = new System.Drawing.Size(126, 20);
            this.lblCameraType.Text = "camera type: {0}";
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Location = new System.Drawing.Point(105, 12);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(683, 25);
            this.txtText.TabIndex = 6;
            this.txtText.Text = "hi well";
            // 
            // btnUpdateText
            // 
            this.btnUpdateText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateText.Location = new System.Drawing.Point(668, 41);
            this.btnUpdateText.Name = "btnUpdateText";
            this.btnUpdateText.Size = new System.Drawing.Size(120, 23);
            this.btnUpdateText.TabIndex = 7;
            this.btnUpdateText.Text = "Update Text";
            this.btnUpdateText.UseVisualStyleBackColor = true;
            this.btnUpdateText.Click += new System.EventHandler(this.btnUpdateText_Click);
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
            this.glCanvas1.RenderTrigger = CSharpGL.Winforms.RenderTriggers.TimerBased;
            this.glCanvas1.Size = new System.Drawing.Size(774, 395);
            this.glCanvas1.TabIndex = 4;
            // 
            // numFontSize
            // 
            this.numFontSize.Location = new System.Drawing.Point(105, 43);
            this.numFontSize.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.Size = new System.Drawing.Size(73, 25);
            this.numFontSize.TabIndex = 8;
            this.numFontSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Font Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Text:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(388, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Font Color:";
            // 
            // lblFontColor
            // 
            this.lblFontColor.BackColor = System.Drawing.Color.Black;
            this.lblFontColor.Location = new System.Drawing.Point(489, 45);
            this.lblFontColor.Name = "lblFontColor";
            this.lblFontColor.Size = new System.Drawing.Size(99, 15);
            this.lblFontColor.TabIndex = 9;
            this.lblFontColor.Click += new System.EventHandler(this.lblFontColor_Click);
            // 
            // numMaxRowWidth
            // 
            this.numMaxRowWidth.Location = new System.Drawing.Point(309, 43);
            this.numMaxRowWidth.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numMaxRowWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxRowWidth.Name = "numMaxRowWidth";
            this.numMaxRowWidth.Size = new System.Drawing.Size(73, 25);
            this.numMaxRowWidth.TabIndex = 8;
            this.numMaxRowWidth.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Max Row Width:";
            // 
            // FormPointSpriteStringElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 509);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFontColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numMaxRowWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numFontSize);
            this.Controls.Add(this.btnUpdateText);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.glCanvas1);
            this.Name = "FormPointSpriteStringElement";
            this.Text = "FormPointSpriteStringElement";
            this.Load += new System.EventHandler(this.FormPointSpriteStringElement_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.glCanvas1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRowWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblCameraType;
        private GLCanvas glCanvas1;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Button btnUpdateText;
        private System.Windows.Forms.NumericUpDown numFontSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblFontColor;
        private System.Windows.Forms.NumericUpDown numMaxRowWidth;
        private System.Windows.Forms.Label label4;
    }
}