namespace CSharpGL.Demos
{
    partial class Form1111SharpFont
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
            this.btnDumpGlyphsTo = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnDumpGlyphsTo
            // 
            this.btnDumpGlyphsTo.Font = new System.Drawing.Font("宋体", 20F);
            this.btnDumpGlyphsTo.Location = new System.Drawing.Point(12, 12);
            this.btnDumpGlyphsTo.Name = "btnDumpGlyphsTo";
            this.btnDumpGlyphsTo.Size = new System.Drawing.Size(759, 524);
            this.btnDumpGlyphsTo.TabIndex = 0;
            this.btnDumpGlyphsTo.Text = "Dump Glyphs From TTF ...";
            this.btnDumpGlyphsTo.UseVisualStyleBackColor = true;
            this.btnDumpGlyphsTo.Click += new System.EventHandler(this.btnDumpGlyphsTo_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "*.ttf|*.ttf";
            // 
            // Form1111SharpFont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 548);
            this.Controls.Add(this.btnDumpGlyphsTo);
            this.Name = "Form1111SharpFont";
            this.Text = "Form1111SharpFont";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDumpGlyphsTo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

    }
}