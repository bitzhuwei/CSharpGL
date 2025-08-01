namespace TestBresenham {
    partial class FormTriangle {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            bresenhamDisplay1 = new TriangleDisplay();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 0;
            label1.Text = "pixelLength:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(117, 12);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(76, 27);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // bresenhamDisplay1
            // 
            bresenhamDisplay1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bresenhamDisplay1.Location = new Point(12, 45);
            bresenhamDisplay1.Name = "bresenhamDisplay1";
            bresenhamDisplay1.Size = new Size(776, 543);
            bresenhamDisplay1.TabIndex = 2;
            // 
            // FormTriangle
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(bresenhamDisplay1);
            Controls.Add(numericUpDown1);
            Controls.Add(label1);
            Name = "FormTriangle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormTriangle";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown numericUpDown1;
        private TriangleDisplay bresenhamDisplay1;
    }
}
