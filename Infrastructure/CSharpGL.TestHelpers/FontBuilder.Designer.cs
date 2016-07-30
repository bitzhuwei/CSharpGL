namespace CSharpGL.TestHelpers
{
    partial class FontBuilder
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFontSize = new System.Windows.Forms.TextBox();
            this.txtFontName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFontStyle = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGraphicsUnit = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtFontSize
            // 
            this.txtFontSize.Location = new System.Drawing.Point(3, 74);
            this.txtFontSize.Name = "txtFontSize";
            this.txtFontSize.Size = new System.Drawing.Size(132, 25);
            this.txtFontSize.TabIndex = 4;
            this.txtFontSize.Text = "64.0";
            // 
            // txtFontName
            // 
            this.txtFontName.Location = new System.Drawing.Point(3, 22);
            this.txtFontName.Name = "txtFontName";
            this.txtFontName.Size = new System.Drawing.Size(132, 25);
            this.txtFontName.TabIndex = 5;
            this.txtFontName.Text = "Arial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Font Size:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Font Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Font Style:";
            // 
            // cmbFontStyle
            // 
            this.cmbFontStyle.FormattingEnabled = true;
            this.cmbFontStyle.Location = new System.Drawing.Point(3, 120);
            this.cmbFontStyle.Name = "cmbFontStyle";
            this.cmbFontStyle.Size = new System.Drawing.Size(176, 23);
            this.cmbFontStyle.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Graphics Unit:";
            // 
            // cmbGraphicsUnit
            // 
            this.cmbGraphicsUnit.FormattingEnabled = true;
            this.cmbGraphicsUnit.Location = new System.Drawing.Point(3, 164);
            this.cmbGraphicsUnit.Name = "cmbGraphicsUnit";
            this.cmbGraphicsUnit.Size = new System.Drawing.Size(176, 23);
            this.cmbGraphicsUnit.TabIndex = 7;
            // 
            // FontBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbGraphicsUnit);
            this.Controls.Add(this.cmbFontStyle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFontSize);
            this.Controls.Add(this.txtFontName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FontBuilder";
            this.Size = new System.Drawing.Size(185, 193);
            this.Load += new System.EventHandler(this.FontBuilder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFontSize;
        private System.Windows.Forms.TextBox txtFontName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFontStyle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbGraphicsUnit;
    }
}
