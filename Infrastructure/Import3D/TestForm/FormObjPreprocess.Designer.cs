namespace TestForm {
    partial class FormObjPreprocess {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            cmbTestCases = new ComboBox();
            txtSource = new TextBox();
            txtPreprocessed = new TextBox();
            SuspendLayout();
            // 
            // cmbTestCases
            // 
            cmbTestCases.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbTestCases.FormattingEnabled = true;
            cmbTestCases.Location = new Point(12, 12);
            cmbTestCases.Name = "cmbTestCases";
            cmbTestCases.Size = new Size(817, 28);
            cmbTestCases.TabIndex = 0;
            cmbTestCases.SelectedIndexChanged += cmbTestCases_SelectedIndexChanged;
            // 
            // txtSource
            // 
            txtSource.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSource.Location = new Point(12, 46);
            txtSource.Multiline = true;
            txtSource.Name = "txtSource";
            txtSource.Size = new Size(817, 243);
            txtSource.TabIndex = 1;
            // 
            // txtPreprocessed
            // 
            txtPreprocessed.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPreprocessed.Location = new Point(12, 295);
            txtPreprocessed.Multiline = true;
            txtPreprocessed.Name = "txtPreprocessed";
            txtPreprocessed.Size = new Size(817, 280);
            txtPreprocessed.TabIndex = 1;
            // 
            // FormObjPreprocess
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 587);
            Controls.Add(txtPreprocessed);
            Controls.Add(txtSource);
            Controls.Add(cmbTestCases);
            Name = "FormObjPreprocess";
            Text = "FormObjPreprocess";
            Load += FormObjPreprocess_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTestCases;
        private TextBox txtSource;
        private TextBox txtPreprocessed;
    }
}