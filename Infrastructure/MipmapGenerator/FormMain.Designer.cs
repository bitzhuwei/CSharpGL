namespace MipmapGenerator
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.chkGenerateBigPicture = new System.Windows.Forms.CheckBox();
            this.numMipmapLevelCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numMipmapLevelCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image:";
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.Font = new System.Drawing.Font("宋体", 14F);
            this.txtFilename.Location = new System.Drawing.Point(93, 12);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(559, 29);
            this.txtFilename.TabIndex = 1;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Font = new System.Drawing.Font("宋体", 14F);
            this.btnOpen.Location = new System.Drawing.Point(658, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(96, 29);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += btnOpen_Click;
            // 
            // chkGenerateBigPicture
            // 
            this.chkGenerateBigPicture.AutoSize = true;
            this.chkGenerateBigPicture.Checked = true;
            this.chkGenerateBigPicture.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGenerateBigPicture.Font = new System.Drawing.Font("宋体", 14F);
            this.chkGenerateBigPicture.Location = new System.Drawing.Point(16, 82);
            this.chkGenerateBigPicture.Name = "chkGenerateBigPicture";
            this.chkGenerateBigPicture.Size = new System.Drawing.Size(228, 23);
            this.chkGenerateBigPicture.TabIndex = 3;
            this.chkGenerateBigPicture.Text = "Generate Big Picture";
            this.chkGenerateBigPicture.UseVisualStyleBackColor = true;
            // 
            // numMipmapLevelCount
            // 
            this.numMipmapLevelCount.Font = new System.Drawing.Font("宋体", 14F);
            this.numMipmapLevelCount.Location = new System.Drawing.Point(217, 47);
            this.numMipmapLevelCount.Name = "numMipmapLevelCount";
            this.numMipmapLevelCount.Size = new System.Drawing.Size(120, 29);
            this.numMipmapLevelCount.TabIndex = 4;
            this.numMipmapLevelCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mipmap Level Count:";
            // 
            // button2
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Font = new System.Drawing.Font("宋体", 14F);
            this.btnGo.Location = new System.Drawing.Point(658, 111);
            this.btnGo.Name = "button2";
            this.btnGo.Size = new System.Drawing.Size(96, 29);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += btnGo_Click;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 152);
            this.Controls.Add(this.numMipmapLevelCount);
            this.Controls.Add(this.chkGenerateBigPicture);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "Mipmap Generator";
            ((System.ComponentModel.ISupportInitialize)(this.numMipmapLevelCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.CheckBox chkGenerateBigPicture;
        private System.Windows.Forms.NumericUpDown numMipmapLevelCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

