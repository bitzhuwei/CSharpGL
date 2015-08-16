namespace CSharpGL.Winforms.Demo
{
    partial class FormWhiteBoard
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
            this.txtWhiteBoard = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtWhiteBoard
            // 
            this.txtWhiteBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWhiteBoard.Location = new System.Drawing.Point(12, 12);
            this.txtWhiteBoard.Multiline = true;
            this.txtWhiteBoard.Name = "txtWhiteBoard";
            this.txtWhiteBoard.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtWhiteBoard.Size = new System.Drawing.Size(697, 431);
            this.txtWhiteBoard.TabIndex = 0;
            // 
            // FormWhiteBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 455);
            this.Controls.Add(this.txtWhiteBoard);
            this.Name = "FormWhiteBoard";
            this.Text = "FormWhiteBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWhiteBoard;
    }
}