namespace CSharpGL.Objects.Controllers
{
    partial class ViewCameraController
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
            this.trackNear = new System.Windows.Forms.TrackBar();
            this.lblNear = new System.Windows.Forms.Label();
            this.trackAspectRatio = new System.Windows.Forms.TrackBar();
            this.lblAspectRatio = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackFieldOfView = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFieldOfView = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackNear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAspectRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFieldOfView)).BeginInit();
            this.SuspendLayout();
            // 
            // trackNear
            // 
            this.trackNear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackNear.Location = new System.Drawing.Point(112, 127);
            this.trackNear.Name = "trackNear";
            this.trackNear.Size = new System.Drawing.Size(429, 56);
            this.trackNear.TabIndex = 11;
            // 
            // lblNear
            // 
            this.lblNear.AutoSize = true;
            this.lblNear.Location = new System.Drawing.Point(547, 140);
            this.lblNear.Name = "lblNear";
            this.lblNear.Size = new System.Drawing.Size(31, 15);
            this.lblNear.TabIndex = 3;
            this.lblNear.Text = "{0}";
            // 
            // trackAspectRatio
            // 
            this.trackAspectRatio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackAspectRatio.Location = new System.Drawing.Point(112, 65);
            this.trackAspectRatio.Name = "trackAspectRatio";
            this.trackAspectRatio.Size = new System.Drawing.Size(429, 56);
            this.trackAspectRatio.TabIndex = 12;
            // 
            // lblAspectRatio
            // 
            this.lblAspectRatio.AutoSize = true;
            this.lblAspectRatio.Location = new System.Drawing.Point(547, 78);
            this.lblAspectRatio.Name = "lblAspectRatio";
            this.lblAspectRatio.Size = new System.Drawing.Size(31, 15);
            this.lblAspectRatio.TabIndex = 5;
            this.lblAspectRatio.Text = "{0}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Near:";
            // 
            // trackFieldOfView
            // 
            this.trackFieldOfView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackFieldOfView.Location = new System.Drawing.Point(112, 3);
            this.trackFieldOfView.Name = "trackFieldOfView";
            this.trackFieldOfView.Size = new System.Drawing.Size(429, 56);
            this.trackFieldOfView.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "AspectRatio:";
            // 
            // lblFieldOfView
            // 
            this.lblFieldOfView.AutoSize = true;
            this.lblFieldOfView.Location = new System.Drawing.Point(547, 16);
            this.lblFieldOfView.Name = "lblFieldOfView";
            this.lblFieldOfView.Size = new System.Drawing.Size(31, 15);
            this.lblFieldOfView.TabIndex = 8;
            this.lblFieldOfView.Text = "{0}";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Position:";
            // 
            // ViewCameraController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trackNear);
            this.Controls.Add(this.lblNear);
            this.Controls.Add(this.trackAspectRatio);
            this.Controls.Add(this.lblAspectRatio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackFieldOfView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFieldOfView);
            this.Controls.Add(this.label1);
            this.Name = "ViewCameraController";
            this.Size = new System.Drawing.Size(599, 192);
            ((System.ComponentModel.ISupportInitialize)(this.trackNear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAspectRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFieldOfView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackNear;
        private System.Windows.Forms.Label lblNear;
        private System.Windows.Forms.TrackBar trackAspectRatio;
        private System.Windows.Forms.Label lblAspectRatio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackFieldOfView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFieldOfView;
        private System.Windows.Forms.Label label1;
    }
}
