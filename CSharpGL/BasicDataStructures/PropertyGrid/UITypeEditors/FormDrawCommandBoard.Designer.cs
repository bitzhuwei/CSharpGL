namespace CSharpGL
{
    partial class FormDrawCommandBoard
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
            this.btnClose = new System.Windows.Forms.Button();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDrawMode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCount)).BeginInit();
            this.SuspendLayout();
            // 
            // trackFirst
            // 
            this.trackFirst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackFirst.Location = new System.Drawing.Point(9, 55);
            this.trackFirst.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackFirst.Name = "trackFirst";
            this.trackFirst.Size = new System.Drawing.Size(669, 45);
            this.trackFirst.TabIndex = 0;
            this.trackFirst.ValueChanged += new System.EventHandler(this.trackFirst_ValueChanged);
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Location = new System.Drawing.Point(9, 35);
            this.lblFirst.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(83, 12);
            this.lblFirst.TabIndex = 1;
            this.lblFirst.Text = "First Vertex:";
            // 
            // lblFirstValue
            // 
            this.lblFirstValue.AutoSize = true;
            this.lblFirstValue.Location = new System.Drawing.Point(97, 35);
            this.lblFirstValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFirstValue.Name = "lblFirstValue";
            this.lblFirstValue.Size = new System.Drawing.Size(65, 12);
            this.lblFirstValue.TabIndex = 1;
            this.lblFirstValue.Text = "FirstValue";
            this.lblFirstValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackCount
            // 
            this.trackCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackCount.Location = new System.Drawing.Point(9, 128);
            this.trackCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackCount.Name = "trackCount";
            this.trackCount.Size = new System.Drawing.Size(669, 45);
            this.trackCount.TabIndex = 0;
            this.trackCount.ValueChanged += new System.EventHandler(this.trackCount_ValueChanged);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(7, 102);
            this.lblCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(83, 12);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "Vertex Count:";
            // 
            // lblCountValue
            // 
            this.lblCountValue.AutoSize = true;
            this.lblCountValue.Location = new System.Drawing.Point(97, 102);
            this.lblCountValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCountValue.Name = "lblCountValue";
            this.lblCountValue.Size = new System.Drawing.Size(65, 12);
            this.lblCountValue.TabIndex = 1;
            this.lblCountValue.Text = "CountValue";
            this.lblCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(622, 185);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 22);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(166, 33);
            this.txtFirst.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(76, 21);
            this.txtFirst.TabIndex = 4;
            this.txtFirst.TextChanged += new System.EventHandler(this.txtFirst_TextChanged);
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(166, 100);
            this.txtCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(76, 21);
            this.txtCount.TabIndex = 4;
            this.txtCount.TextChanged += new System.EventHandler(this.txtCount_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "DrawMode:";
            // 
            // cmbDrawMode
            // 
            this.cmbDrawMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrawMode.FormattingEnabled = true;
            this.cmbDrawMode.Location = new System.Drawing.Point(73, 10);
            this.cmbDrawMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbDrawMode.Name = "cmbDrawMode";
            this.cmbDrawMode.Size = new System.Drawing.Size(170, 20);
            this.cmbDrawMode.TabIndex = 5;
            this.cmbDrawMode.SelectedIndexChanged += new System.EventHandler(this.cmbDrawMode_SelectedIndexChanged);
            // 
            // FormDrawCommandBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(687, 216);
            this.Controls.Add(this.cmbDrawMode);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.txtFirst);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblCountValue);
            this.Controls.Add(this.lblFirstValue);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFirst);
            this.Controls.Add(this.trackCount);
            this.Controls.Add(this.trackFirst);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormDrawCommandBoard";
            this.Text = "FormIndexBufferBoard";
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
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDrawMode;
    }
}