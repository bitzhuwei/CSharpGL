namespace CSharpGL.Objects.Controllers
{
    partial class CameraController
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
            this.orthoCameraController1 = new CSharpGL.Objects.Controllers.OrthoCameraController();
            this.perspectiveCameraController1 = new CSharpGL.Objects.Controllers.PerspectiveCameraController();
            this.SuspendLayout();
            // 
            // orthoCameraController1
            // 
            this.orthoCameraController1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orthoCameraController1.Location = new System.Drawing.Point(0, 269);
            this.orthoCameraController1.Name = "orthoCameraController1";
            this.orthoCameraController1.Size = new System.Drawing.Size(896, 389);
            this.orthoCameraController1.TabIndex = 0;
            // 
            // perspectiveCameraController1
            // 
            this.perspectiveCameraController1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.perspectiveCameraController1.Location = new System.Drawing.Point(6, 3);
            this.perspectiveCameraController1.Name = "perspectiveCameraController1";
            this.perspectiveCameraController1.Size = new System.Drawing.Size(896, 260);
            this.perspectiveCameraController1.TabIndex = 1;
            // 
            // CameraController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.perspectiveCameraController1);
            this.Controls.Add(this.orthoCameraController1);
            this.Name = "CameraController";
            this.Size = new System.Drawing.Size(902, 671);
            this.ResumeLayout(false);

        }

        #endregion

        private OrthoCameraController orthoCameraController1;
        private PerspectiveCameraController perspectiveCameraController1;
    }
}
