namespace CSharpGL.Objects.Controllers
{
    partial class OrthoCameraController
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
            this.trackFar = new System.Windows.Forms.TrackBar();
            this.lblFar = new System.Windows.Forms.Label();
            this.trackNear = new System.Windows.Forms.TrackBar();
            this.lblNear = new System.Windows.Forms.Label();
            this.trackRight = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackLeft = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBottom = new System.Windows.Forms.Label();
            this.trackBottom = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.trackTop = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackFar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackNear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTop)).BeginInit();
            this.SuspendLayout();
            // 
            // trackFar
            // 
            this.trackFar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackFar.Location = new System.Drawing.Point(72, 319);
            this.trackFar.Name = "trackFar";
            this.trackFar.Size = new System.Drawing.Size(469, 56);
            this.trackFar.TabIndex = 10;
            // 
            // lblFar
            // 
            this.lblFar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFar.AutoSize = true;
            this.lblFar.Location = new System.Drawing.Point(547, 332);
            this.lblFar.Name = "lblFar";
            this.lblFar.Size = new System.Drawing.Size(31, 15);
            this.lblFar.TabIndex = 2;
            this.lblFar.Text = "{0}";
            // 
            // trackNear
            // 
            this.trackNear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackNear.Location = new System.Drawing.Point(72, 257);
            this.trackNear.Name = "trackNear";
            this.trackNear.Size = new System.Drawing.Size(469, 56);
            this.trackNear.TabIndex = 11;
            // 
            // lblNear
            // 
            this.lblNear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNear.AutoSize = true;
            this.lblNear.Location = new System.Drawing.Point(547, 270);
            this.lblNear.Name = "lblNear";
            this.lblNear.Size = new System.Drawing.Size(31, 15);
            this.lblNear.TabIndex = 3;
            this.lblNear.Text = "{0}";
            // 
            // trackRight
            // 
            this.trackRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackRight.Location = new System.Drawing.Point(72, 71);
            this.trackRight.Name = "trackRight";
            this.trackRight.Size = new System.Drawing.Size(469, 56);
            this.trackRight.TabIndex = 12;
            this.trackRight.Scroll += new System.EventHandler(this.trackRight_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Far:";
            // 
            // lblRight
            // 
            this.lblRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRight.AutoSize = true;
            this.lblRight.Location = new System.Drawing.Point(547, 84);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(31, 15);
            this.lblRight.TabIndex = 5;
            this.lblRight.Text = "{0}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Near:";
            // 
            // trackLeft
            // 
            this.trackLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackLeft.Location = new System.Drawing.Point(72, 9);
            this.trackLeft.Name = "trackLeft";
            this.trackLeft.Size = new System.Drawing.Size(469, 56);
            this.trackLeft.TabIndex = 13;
            this.trackLeft.Scroll += new System.EventHandler(this.trackLeft_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Right:";
            // 
            // lblLeft
            // 
            this.lblLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLeft.AutoSize = true;
            this.lblLeft.Location = new System.Drawing.Point(547, 22);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(31, 15);
            this.lblLeft.TabIndex = 8;
            this.lblLeft.Text = "{0}";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Left:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bottom:";
            // 
            // lblBottom
            // 
            this.lblBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBottom.AutoSize = true;
            this.lblBottom.Location = new System.Drawing.Point(547, 146);
            this.lblBottom.Name = "lblBottom";
            this.lblBottom.Size = new System.Drawing.Size(31, 15);
            this.lblBottom.TabIndex = 3;
            this.lblBottom.Text = "{0}";
            // 
            // trackBottom
            // 
            this.trackBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBottom.Location = new System.Drawing.Point(72, 133);
            this.trackBottom.Name = "trackBottom";
            this.trackBottom.Size = new System.Drawing.Size(469, 56);
            this.trackBottom.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Top:";
            // 
            // lblTop
            // 
            this.lblTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(547, 208);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(31, 15);
            this.lblTop.TabIndex = 3;
            this.lblTop.Text = "{0}";
            // 
            // trackTop
            // 
            this.trackTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackTop.Location = new System.Drawing.Point(72, 195);
            this.trackTop.Name = "trackTop";
            this.trackTop.Size = new System.Drawing.Size(469, 56);
            this.trackTop.TabIndex = 11;
            // 
            // OrthoCameraController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trackFar);
            this.Controls.Add(this.lblFar);
            this.Controls.Add(this.trackTop);
            this.Controls.Add(this.lblTop);
            this.Controls.Add(this.trackBottom);
            this.Controls.Add(this.lblBottom);
            this.Controls.Add(this.trackNear);
            this.Controls.Add(this.lblNear);
            this.Controls.Add(this.trackRight);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackLeft);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.label1);
            this.Name = "OrthoCameraController";
            this.Size = new System.Drawing.Size(599, 389);
            ((System.ComponentModel.ISupportInitialize)(this.trackFar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackNear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackFar;
        private System.Windows.Forms.Label lblFar;
        private System.Windows.Forms.TrackBar trackNear;
        private System.Windows.Forms.Label lblNear;
        private System.Windows.Forms.TrackBar trackRight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackLeft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBottom;
        private System.Windows.Forms.TrackBar trackBottom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.TrackBar trackTop;
    }
}
