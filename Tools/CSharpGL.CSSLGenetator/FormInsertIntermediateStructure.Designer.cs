namespace CSharpGL.CSSLGenetator
{
    partial class FormInsertIntermediateStructure
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
            this.components = new System.ComponentModel.Container();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstField = new System.Windows.Forms.ListBox();
            this.menuFieldList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuFieldList.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(290, 502);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(125, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(421, 502);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(104, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(368, 25);
            this.txtName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "name:";
            // 
            // lstField
            // 
            this.lstField.AllowDrop = true;
            this.lstField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstField.ContextMenuStrip = this.menuFieldList;
            this.lstField.FormattingEnabled = true;
            this.lstField.ItemHeight = 15;
            this.lstField.Location = new System.Drawing.Point(12, 70);
            this.lstField.Name = "lstField";
            this.lstField.Size = new System.Drawing.Size(269, 424);
            this.lstField.TabIndex = 9;
            this.lstField.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstField_DragDrop);
            this.lstField.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstField_DragEnter);
            this.lstField.DragLeave += new System.EventHandler(this.lstField_DragLeave);
            this.lstField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstField_MouseDown);
            // 
            // menuFieldList
            // 
            this.menuFieldList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuFieldList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAToolStripMenuItem,
            this.修改UToolStripMenuItem,
            this.删除DToolStripMenuItem});
            this.menuFieldList.Name = "menuVertexShaderField";
            this.menuFieldList.Size = new System.Drawing.Size(136, 82);
            // 
            // addAToolStripMenuItem
            // 
            this.addAToolStripMenuItem.Name = "addAToolStripMenuItem";
            this.addAToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.addAToolStripMenuItem.Text = "新增(&A)";
            this.addAToolStripMenuItem.Click += new System.EventHandler(this.addAToolStripMenuItem_Click);
            // 
            // 修改UToolStripMenuItem
            // 
            this.修改UToolStripMenuItem.Name = "修改UToolStripMenuItem";
            this.修改UToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.修改UToolStripMenuItem.Text = "修改(&U)";
            this.修改UToolStripMenuItem.Click += new System.EventHandler(this.修改UToolStripMenuItem_Click);
            // 
            // 删除DToolStripMenuItem
            // 
            this.删除DToolStripMenuItem.Name = "删除DToolStripMenuItem";
            this.删除DToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.删除DToolStripMenuItem.Text = "删除(&D)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "field list:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(287, 70);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(259, 424);
            this.textBox1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "result:";
            // 
            // FormInsertIntermediateStructure
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(558, 537);
            this.Controls.Add(this.lstField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "FormInsertIntermediateStructure";
            this.Text = "FormAddIntermediateStructure";
            this.Load += new System.EventHandler(this.FormAddVertexShaderField_Load);
            this.menuFieldList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip menuFieldList;
        private System.Windows.Forms.ToolStripMenuItem addAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改UToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除DToolStripMenuItem;
    }
}