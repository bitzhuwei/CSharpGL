namespace CSharpGL
{
    partial class FormIListEditor<T>
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstMember = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblProperty = new System.Windows.Forms.Label();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "成员(&M):";
            // 
            // lstMember
            // 
            this.lstMember.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstMember.FormattingEnabled = true;
            this.lstMember.ItemHeight = 15;
            this.lstMember.Location = new System.Drawing.Point(15, 37);
            this.lstMember.Name = "lstMember";
            this.lstMember.Size = new System.Drawing.Size(267, 394);
            this.lstMember.TabIndex = 1;
            this.lstMember.SelectedIndexChanged += new System.EventHandler(this.lstMember_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(12, 443);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Location = new System.Drawing.Point(93, 443);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "移除(&R)";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(288, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "↑";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(288, 66);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(36, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "↓";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // lblProperty
            // 
            this.lblProperty.AutoSize = true;
            this.lblProperty.Location = new System.Drawing.Point(331, 9);
            this.lblProperty.Name = "lblProperty";
            this.lblProperty.Size = new System.Drawing.Size(69, 15);
            this.lblProperty.TabIndex = 0;
            this.lblProperty.Text = "属性(&P):";
            // 
            // propertyGrid
            // 
            this.propertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid.Location = new System.Drawing.Point(330, 37);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(336, 400);
            this.propertyGrid.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(591, 443);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormGLSwitchListEditor
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 478);
            this.Controls.Add(this.propertyGrid);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstMember);
            this.Controls.Add(this.lblProperty);
            this.Controls.Add(this.label1);
            this.Name = "FormGLSwitchListEditor";
            this.Text = "GLSwticth List Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstMember;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Button btnClose;
    }
}