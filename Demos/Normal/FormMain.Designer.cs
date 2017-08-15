namespace Normal
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
            this.winGLCanvas1 = new CSharpGL.WinGLCanvas();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkRotate = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lblModelColor = new System.Windows.Forms.Label();
            this.chkRenderModel = new System.Windows.Forms.CheckBox();
            this.chkRenderNormal = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVertexColor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPointerColor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenObjFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // winGLCanvas1
            // 
            this.winGLCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winGLCanvas1.Location = new System.Drawing.Point(12, 54);
            this.winGLCanvas1.Name = "winGLCanvas1";
            this.winGLCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.winGLCanvas1.Size = new System.Drawing.Size(961, 511);
            this.winGLCanvas1.TabIndex = 0;
            this.winGLCanvas1.TimerTriggerInterval = 40;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkRotate
            // 
            this.chkRotate.AutoSize = true;
            this.chkRotate.Checked = true;
            this.chkRotate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRotate.Font = new System.Drawing.Font("宋体", 12F);
            this.chkRotate.Location = new System.Drawing.Point(12, 12);
            this.chkRotate.Name = "chkRotate";
            this.chkRotate.Size = new System.Drawing.Size(123, 20);
            this.chkRotate.TabIndex = 1;
            this.chkRotate.Text = "Rotate Model";
            this.chkRotate.UseVisualStyleBackColor = true;
            this.chkRotate.CheckedChanged += new System.EventHandler(this.chkRotate_CheckedChanged);
            // 
            // lblModelColor
            // 
            this.lblModelColor.AutoSize = true;
            this.lblModelColor.BackColor = System.Drawing.Color.Gold;
            this.lblModelColor.Font = new System.Drawing.Font("宋体", 12F);
            this.lblModelColor.Location = new System.Drawing.Point(119, 35);
            this.lblModelColor.Name = "lblModelColor";
            this.lblModelColor.Size = new System.Drawing.Size(48, 16);
            this.lblModelColor.TabIndex = 2;
            this.lblModelColor.Text = "     ";
            this.lblModelColor.Click += new System.EventHandler(this.lblModelColor_Click);
            // 
            // chkRenderModel
            // 
            this.chkRenderModel.AutoSize = true;
            this.chkRenderModel.Checked = true;
            this.chkRenderModel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRenderModel.Font = new System.Drawing.Font("宋体", 12F);
            this.chkRenderModel.Location = new System.Drawing.Point(141, 12);
            this.chkRenderModel.Name = "chkRenderModel";
            this.chkRenderModel.Size = new System.Drawing.Size(123, 20);
            this.chkRenderModel.TabIndex = 1;
            this.chkRenderModel.Text = "Render Model";
            this.chkRenderModel.UseVisualStyleBackColor = true;
            this.chkRenderModel.CheckedChanged += new System.EventHandler(this.chkRenderModel_CheckedChanged);
            // 
            // chkRenderNormal
            // 
            this.chkRenderNormal.AutoSize = true;
            this.chkRenderNormal.Checked = true;
            this.chkRenderNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRenderNormal.Font = new System.Drawing.Font("宋体", 12F);
            this.chkRenderNormal.Location = new System.Drawing.Point(270, 12);
            this.chkRenderNormal.Name = "chkRenderNormal";
            this.chkRenderNormal.Size = new System.Drawing.Size(131, 20);
            this.chkRenderNormal.TabIndex = 1;
            this.chkRenderNormal.Text = "Render Normal";
            this.chkRenderNormal.UseVisualStyleBackColor = true;
            this.chkRenderNormal.CheckedChanged += new System.EventHandler(this.chkRenderNormal_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Model Color:";
            // 
            // lblVertexColor
            // 
            this.lblVertexColor.AutoSize = true;
            this.lblVertexColor.BackColor = System.Drawing.Color.White;
            this.lblVertexColor.Font = new System.Drawing.Font("宋体", 12F);
            this.lblVertexColor.Location = new System.Drawing.Point(359, 35);
            this.lblVertexColor.Name = "lblVertexColor";
            this.lblVertexColor.Size = new System.Drawing.Size(48, 16);
            this.lblVertexColor.TabIndex = 2;
            this.lblVertexColor.Text = "     ";
            this.lblVertexColor.Click += new System.EventHandler(this.lblVertexColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(241, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vertex Color:";
            // 
            // lblPointerColor
            // 
            this.lblPointerColor.AutoSize = true;
            this.lblPointerColor.BackColor = System.Drawing.Color.Gray;
            this.lblPointerColor.Font = new System.Drawing.Font("宋体", 12F);
            this.lblPointerColor.Location = new System.Drawing.Point(613, 35);
            this.lblPointerColor.Name = "lblPointerColor";
            this.lblPointerColor.Size = new System.Drawing.Size(48, 16);
            this.lblPointerColor.TabIndex = 2;
            this.lblPointerColor.Text = "     ";
            this.lblPointerColor.Click += new System.EventHandler(this.lblPointerColor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.Location = new System.Drawing.Point(487, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Pointer Color:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "*.obj|*.obj|*.obj_|*.obj_";
            // 
            // btnOpenObjFile
            // 
            this.btnOpenObjFile.Location = new System.Drawing.Point(898, 9);
            this.btnOpenObjFile.Name = "btnOpenObjFile";
            this.btnOpenObjFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenObjFile.TabIndex = 3;
            this.btnOpenObjFile.Text = "Open ...";
            this.btnOpenObjFile.UseVisualStyleBackColor = true;
            this.btnOpenObjFile.Click += new System.EventHandler(this.btnOpenObjFile_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 577);
            this.Controls.Add(this.btnOpenObjFile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPointerColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblVertexColor);
            this.Controls.Add(this.lblModelColor);
            this.Controls.Add(this.chkRenderNormal);
            this.Controls.Add(this.chkRenderModel);
            this.Controls.Add(this.chkRotate);
            this.Controls.Add(this.winGLCanvas1);
            this.Name = "FormMain";
            this.Text = "Normal - CSharpGL";
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharpGL.WinGLCanvas winGLCanvas1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkRotate;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblModelColor;
        private System.Windows.Forms.CheckBox chkRenderModel;
        private System.Windows.Forms.CheckBox chkRenderNormal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVertexColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPointerColor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOpenObjFile;
    }
}