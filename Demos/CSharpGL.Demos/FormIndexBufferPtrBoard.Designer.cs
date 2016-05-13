namespace CSharpGL.Demos
{
    partial class FormIndexBufferPtrBoard
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
            this.trackFirst = new System.Windows.Forms.TrackBar();
            this.lblFirst = new System.Windows.Forms.Label();
            this.lblFirstValue = new System.Windows.Forms.Label();
            this.trackCount = new System.Windows.Forms.TrackBar();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblCountValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCount)).BeginInit();
            this.SuspendLayout();
            // 
            // trackFirst
            // 
            this.trackFirst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackFirst.Location = new System.Drawing.Point(12, 40);
            this.trackFirst.Name = "trackFirst";
            this.trackFirst.Size = new System.Drawing.Size(892, 56);
            this.trackFirst.TabIndex = 0;
            this.trackFirst.Scroll += new System.EventHandler(this.trackFirst_Scroll);
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Location = new System.Drawing.Point(12, 22);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(55, 15);
            this.lblFirst.TabIndex = 1;
            this.lblFirst.Text = "First:";
            // 
            // lblFirstValue
            // 
            this.lblFirstValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFirstValue.AutoSize = true;
            this.lblFirstValue.Location = new System.Drawing.Point(817, 22);
            this.lblFirstValue.Name = "lblFirstValue";
            this.lblFirstValue.Size = new System.Drawing.Size(87, 15);
            this.lblFirstValue.TabIndex = 1;
            this.lblFirstValue.Text = "FirstValue";
            // 
            // trackCount
            // 
            this.trackCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackCount.Location = new System.Drawing.Point(12, 131);
            this.trackCount.Name = "trackCount";
            this.trackCount.Size = new System.Drawing.Size(892, 56);
            this.trackCount.TabIndex = 0;
            this.trackCount.Scroll += new System.EventHandler(this.trackCount_Scroll);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(9, 99);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(55, 15);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "Count:";
            // 
            // lblCountValue
            // 
            this.lblCountValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountValue.AutoSize = true;
            this.lblCountValue.Location = new System.Drawing.Point(817, 99);
            this.lblCountValue.Name = "lblCountValue";
            this.lblCountValue.Size = new System.Drawing.Size(87, 15);
            this.lblCountValue.TabIndex = 1;
            this.lblCountValue.Text = "CountValue";
            // 
            // FormIndexBufferPtrBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 208);
            this.Controls.Add(this.lblCountValue);
            this.Controls.Add(this.lblFirstValue);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblFirst);
            this.Controls.Add(this.trackCount);
            this.Controls.Add(this.trackFirst);
            this.Name = "FormIndexBufferPtrBoard";
            this.Text = "FormIndexBufferPtrBoard";
            ((System.ComponentModel.ISupportInitialize)(this.trackFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackFirst;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblFirstValue;
        private System.Windows.Forms.TrackBar trackCount;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblCountValue;
    }
}