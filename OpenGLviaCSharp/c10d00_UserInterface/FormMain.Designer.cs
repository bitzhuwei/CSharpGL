namespace c10d00_UserInterface
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblState = new System.Windows.Forms.ToolStripStatusLabel();
            this.propGrid = new System.Windows.Forms.PropertyGrid();
            this.trvSceneObject = new System.Windows.Forms.TreeView();
            this.winGLCanvas1 = new CSharpGL.WinGLCanvas();
            this.trvSceneGUI = new System.Windows.Forms.TreeView();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 588);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1139, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblState
            // 
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(62, 17);
            this.lblState.Text = "state info";
            // 
            // propGrid
            // 
            this.propGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propGrid.Location = new System.Drawing.Point(12, 271);
            this.propGrid.Name = "propGrid";
            this.propGrid.Size = new System.Drawing.Size(332, 308);
            this.propGrid.TabIndex = 7;
            // 
            // trvSceneObject
            // 
            this.trvSceneObject.Font = new System.Drawing.Font("宋体", 12F);
            this.trvSceneObject.Location = new System.Drawing.Point(12, 6);
            this.trvSceneObject.Name = "trvSceneObject";
            this.trvSceneObject.Size = new System.Drawing.Size(165, 259);
            this.trvSceneObject.TabIndex = 5;
            // 
            // winGLCanvas1
            // 
            this.winGLCanvas1.AccumAlphaBits = ((byte)(0));
            this.winGLCanvas1.AccumBits = ((byte)(0));
            this.winGLCanvas1.AccumBlueBits = ((byte)(0));
            this.winGLCanvas1.AccumGreenBits = ((byte)(0));
            this.winGLCanvas1.AccumRedBits = ((byte)(0));
            this.winGLCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winGLCanvas1.Location = new System.Drawing.Point(350, 6);
            this.winGLCanvas1.Name = "winGLCanvas1";
            this.winGLCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.winGLCanvas1.Size = new System.Drawing.Size(777, 573);
            this.winGLCanvas1.StencilBits = ((byte)(0));
            this.winGLCanvas1.TabIndex = 4;
            this.winGLCanvas1.TimerTriggerInterval = 40;
            this.winGLCanvas1.UpdateContextVersion = true;
            // 
            // trvSceneGUI
            // 
            this.trvSceneGUI.Font = new System.Drawing.Font("宋体", 12F);
            this.trvSceneGUI.Location = new System.Drawing.Point(179, 6);
            this.trvSceneGUI.Name = "trvSceneGUI";
            this.trvSceneGUI.Size = new System.Drawing.Size(165, 259);
            this.trvSceneGUI.TabIndex = 6;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 610);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.propGrid);
            this.Controls.Add(this.trvSceneObject);
            this.Controls.Add(this.winGLCanvas1);
            this.Controls.Add(this.trvSceneGUI);
            this.Name = "FormMain";
            this.Text = "c10d00_UserInterface - CSharpGL";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblState;
        private System.Windows.Forms.PropertyGrid propGrid;
        private System.Windows.Forms.TreeView trvSceneObject;
        private CSharpGL.WinGLCanvas winGLCanvas1;
        private System.Windows.Forms.TreeView trvSceneGUI;

    }
}