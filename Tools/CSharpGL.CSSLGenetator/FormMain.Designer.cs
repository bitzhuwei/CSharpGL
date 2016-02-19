namespace CSharpGL.CSSLGenetator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.txtShaderName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cmbShaderProgramType = new System.Windows.Forms.ComboBox();
            this.lstVertexShaderField = new System.Windows.Forms.ListBox();
            this.menuVertexShaderField = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstGeometryShaderField = new System.Windows.Forms.ListBox();
            this.menuGeometryShaderField = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.lstFragmentShaderField = new System.Windows.Forms.ListBox();
            this.menuFragmentShaderField = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.lstStructure = new System.Windows.Forms.ListBox();
            this.menuFieldStructure = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改UToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除DToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.menuVertexShaderField.SuspendLayout();
            this.menuGeometryShaderField.SuspendLayout();
            this.menuFragmentShaderField.SuspendLayout();
            this.menuFieldStructure.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "shader name:";
            // 
            // txtShaderName
            // 
            this.txtShaderName.Location = new System.Drawing.Point(122, 31);
            this.txtShaderName.Name = "txtShaderName";
            this.txtShaderName.Size = new System.Drawing.Size(352, 25);
            this.txtShaderName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "shader program type:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(668, 490);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(258, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Save and Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cmbShaderProgramType
            // 
            this.cmbShaderProgramType.FormattingEnabled = true;
            this.cmbShaderProgramType.Location = new System.Drawing.Point(186, 62);
            this.cmbShaderProgramType.Name = "cmbShaderProgramType";
            this.cmbShaderProgramType.Size = new System.Drawing.Size(288, 23);
            this.cmbShaderProgramType.TabIndex = 4;
            // 
            // lstVertexShaderField
            // 
            this.lstVertexShaderField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstVertexShaderField.ContextMenuStrip = this.menuVertexShaderField;
            this.lstVertexShaderField.FormattingEnabled = true;
            this.lstVertexShaderField.ItemHeight = 15;
            this.lstVertexShaderField.Location = new System.Drawing.Point(13, 112);
            this.lstVertexShaderField.Name = "lstVertexShaderField";
            this.lstVertexShaderField.Size = new System.Drawing.Size(224, 364);
            this.lstVertexShaderField.TabIndex = 5;
            // 
            // menuVertexShaderField
            // 
            this.menuVertexShaderField.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuVertexShaderField.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAToolStripMenuItem,
            this.修改UToolStripMenuItem,
            this.删除DToolStripMenuItem});
            this.menuVertexShaderField.Name = "menuVertexShaderField";
            this.menuVertexShaderField.Size = new System.Drawing.Size(136, 82);
            // 
            // addAToolStripMenuItem
            // 
            this.addAToolStripMenuItem.Name = "addAToolStripMenuItem";
            this.addAToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.addAToolStripMenuItem.Text = "新增(&A)";
            this.addAToolStripMenuItem.Click += new System.EventHandler(this.vertexShaderAddField_Click);
            // 
            // 修改UToolStripMenuItem
            // 
            this.修改UToolStripMenuItem.Name = "修改UToolStripMenuItem";
            this.修改UToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.修改UToolStripMenuItem.Text = "修改(&U)";
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
            this.label3.Location = new System.Drawing.Point(13, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "vertex shader";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "geometry shader";
            // 
            // lstGeometryShaderField
            // 
            this.lstGeometryShaderField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstGeometryShaderField.ContextMenuStrip = this.menuGeometryShaderField;
            this.lstGeometryShaderField.FormattingEnabled = true;
            this.lstGeometryShaderField.ItemHeight = 15;
            this.lstGeometryShaderField.Location = new System.Drawing.Point(243, 112);
            this.lstGeometryShaderField.Name = "lstGeometryShaderField";
            this.lstGeometryShaderField.Size = new System.Drawing.Size(224, 364);
            this.lstGeometryShaderField.TabIndex = 5;
            // 
            // menuGeometryShaderField
            // 
            this.menuGeometryShaderField.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuGeometryShaderField.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.menuGeometryShaderField.Name = "menuShaderField";
            this.menuGeometryShaderField.Size = new System.Drawing.Size(136, 82);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(135, 26);
            this.toolStripMenuItem1.Text = "新增(&A)";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.geometryShaderAddField_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(135, 26);
            this.toolStripMenuItem2.Text = "修改(&U)";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(135, 26);
            this.toolStripMenuItem3.Text = "删除(&D)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(473, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "fragment shader";
            // 
            // lstFragmentShaderField
            // 
            this.lstFragmentShaderField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFragmentShaderField.ContextMenuStrip = this.menuFragmentShaderField;
            this.lstFragmentShaderField.FormattingEnabled = true;
            this.lstFragmentShaderField.ItemHeight = 15;
            this.lstFragmentShaderField.Location = new System.Drawing.Point(473, 112);
            this.lstFragmentShaderField.Name = "lstFragmentShaderField";
            this.lstFragmentShaderField.Size = new System.Drawing.Size(224, 364);
            this.lstFragmentShaderField.TabIndex = 5;
            // 
            // menuFragmentShaderField
            // 
            this.menuFragmentShaderField.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuFragmentShaderField.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.menuFragmentShaderField.Name = "menuShaderField";
            this.menuFragmentShaderField.Size = new System.Drawing.Size(136, 82);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(135, 26);
            this.toolStripMenuItem4.Text = "新增(&A)";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.fragmentShaderAddField_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(135, 26);
            this.toolStripMenuItem5.Text = "修改(&U)";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(135, 26);
            this.toolStripMenuItem6.Text = "删除(&D)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(703, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "structure";
            // 
            // lstStructure
            // 
            this.lstStructure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstStructure.ContextMenuStrip = this.menuFieldStructure;
            this.lstStructure.FormattingEnabled = true;
            this.lstStructure.ItemHeight = 15;
            this.lstStructure.Location = new System.Drawing.Point(703, 112);
            this.lstStructure.Name = "lstStructure";
            this.lstStructure.Size = new System.Drawing.Size(224, 364);
            this.lstStructure.TabIndex = 5;
            // 
            // menuFieldStructure
            // 
            this.menuFieldStructure.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuFieldStructure.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增AToolStripMenuItem,
            this.修改UToolStripMenuItem1,
            this.删除DToolStripMenuItem1});
            this.menuFieldStructure.Name = "menuFieldStructure";
            this.menuFieldStructure.Size = new System.Drawing.Size(136, 82);
            // 
            // 新增AToolStripMenuItem
            // 
            this.新增AToolStripMenuItem.Name = "新增AToolStripMenuItem";
            this.新增AToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.新增AToolStripMenuItem.Text = "新增(&A)";
            this.新增AToolStripMenuItem.Click += new System.EventHandler(this.addIntermediateStructure_Click);
            // 
            // 修改UToolStripMenuItem1
            // 
            this.修改UToolStripMenuItem1.Name = "修改UToolStripMenuItem1";
            this.修改UToolStripMenuItem1.Size = new System.Drawing.Size(135, 26);
            this.修改UToolStripMenuItem1.Text = "修改(&U)";
            // 
            // 删除DToolStripMenuItem1
            // 
            this.删除DToolStripMenuItem1.Name = "删除DToolStripMenuItem1";
            this.删除DToolStripMenuItem1.Size = new System.Drawing.Size(135, 26);
            this.删除DToolStripMenuItem1.Text = "删除(&D)";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(938, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建NToolStripMenuItem,
            this.打开OToolStripMenuItem,
            this.toolStripSeparator,
            this.保存SToolStripMenuItem,
            this.另存为AToolStripMenuItem,
            this.toolStripSeparator2,
            this.退出XToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 新建NToolStripMenuItem
            // 
            this.新建NToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("新建NToolStripMenuItem.Image")));
            this.新建NToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新建NToolStripMenuItem.Name = "新建NToolStripMenuItem";
            this.新建NToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.新建NToolStripMenuItem.Text = "新建(&N)";
            this.新建NToolStripMenuItem.Click += new System.EventHandler(this.新建NToolStripMenuItem_Click);
            // 
            // 打开OToolStripMenuItem
            // 
            this.打开OToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打开OToolStripMenuItem.Image")));
            this.打开OToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            this.打开OToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.打开OToolStripMenuItem.Text = "打开(&O)";
            this.打开OToolStripMenuItem.Click += new System.EventHandler(this.打开OToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(147, 6);
            // 
            // 保存SToolStripMenuItem
            // 
            this.保存SToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("保存SToolStripMenuItem.Image")));
            this.保存SToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            this.保存SToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.保存SToolStripMenuItem.Text = "保存(&S)";
            this.保存SToolStripMenuItem.Click += new System.EventHandler(this.保存SToolStripMenuItem_Click);
            // 
            // 另存为AToolStripMenuItem
            // 
            this.另存为AToolStripMenuItem.Name = "另存为AToolStripMenuItem";
            this.另存为AToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.另存为AToolStripMenuItem.Text = "另存为(&A)";
            this.另存为AToolStripMenuItem.Click += new System.EventHandler(this.另存为AToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(147, 6);
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.退出XToolStripMenuItem.Text = "退出(&X)";
            this.退出XToolStripMenuItem.Click += new System.EventHandler(this.退出XToolStripMenuItem_Click);
            // 
            // openFileDlg
            // 
            this.openFileDlg.Filter = "(CSSL template *.xml)|*.xml";
            // 
            // saveFileDlg
            // 
            this.saveFileDlg.FileName = "*.xml";
            this.saveFileDlg.Filter = "*.xml|*.xml";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 501);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(352, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "本程序不处理脏数据，所以请注意手动保存您的成果";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 525);
            this.Controls.Add(this.lstStructure);
            this.Controls.Add(this.lstFragmentShaderField);
            this.Controls.Add(this.lstGeometryShaderField);
            this.Controls.Add(this.lstVertexShaderField);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbShaderProgramType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtShaderName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "CSSL Generator";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuVertexShaderField.ResumeLayout(false);
            this.menuGeometryShaderField.ResumeLayout(false);
            this.menuFragmentShaderField.ResumeLayout(false);
            this.menuFieldStructure.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtShaderName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ComboBox cmbShaderProgramType;
        private System.Windows.Forms.ListBox lstVertexShaderField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstGeometryShaderField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstFragmentShaderField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstStructure;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为AToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.SaveFileDialog saveFileDlg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ContextMenuStrip menuVertexShaderField;
        private System.Windows.Forms.ContextMenuStrip menuFieldStructure;
        private System.Windows.Forms.ToolStripMenuItem addAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改UToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改UToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 删除DToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip menuGeometryShaderField;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ContextMenuStrip menuFragmentShaderField;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
    }
}