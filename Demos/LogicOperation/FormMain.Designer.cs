namespace LogicOperation
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblState = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLogicOperation = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).BeginInit();
            this.statusStrip1.SuspendLayout();
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
            this.winGLCanvas1.Location = new System.Drawing.Point(12, 38);
            this.winGLCanvas1.Name = "winGLCanvas1";
            this.winGLCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.winGLCanvas1.Size = new System.Drawing.Size(1115, 547);
            this.winGLCanvas1.StencilBits = ((byte)(8));
            this.winGLCanvas1.TabIndex = 0;
            this.winGLCanvas1.TimerTriggerInterval = 40;
            this.winGLCanvas1.UpdateContextVersion = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 588);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1139, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblState
            // 
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(62, 17);
            this.lblState.Text = "state info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Logic Operation:";
            // 
            // cmbLogicOperation
            // 
            this.cmbLogicOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicOperation.FormattingEnabled = true;
            this.cmbLogicOperation.Location = new System.Drawing.Point(119, 12);
            this.cmbLogicOperation.Name = "cmbLogicOperation";
            this.cmbLogicOperation.Size = new System.Drawing.Size(164, 20);
            this.cmbLogicOperation.TabIndex = 5;
            this.cmbLogicOperation.SelectedIndexChanged += new System.EventHandler(this.cmbLogicOperation_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 610);
            this.Controls.Add(this.cmbLogicOperation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.winGLCanvas1);
            this.Name = "FormMain";
            this.Text = "Logic Operation - CSharpGL";
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharpGL.WinGLCanvas winGLCanvas1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLogicOperation;
    }
}