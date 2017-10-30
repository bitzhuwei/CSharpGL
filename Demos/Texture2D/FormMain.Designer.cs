namespace Texture2D
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
            this.trvSceneObject = new System.Windows.Forms.TreeView();
            this.propGrid = new System.Windows.Forms.PropertyGrid();
            this.winGLCanvas1 = new CSharpGL.WinGLCanvas();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblState = new System.Windows.Forms.ToolStripStatusLabel();
            this.trvSceneGUI = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvSceneObject
            // 
            this.trvSceneObject.Font = new System.Drawing.Font("宋体", 12F);
            this.trvSceneObject.Location = new System.Drawing.Point(12, 12);
            this.trvSceneObject.Name = "trvSceneObject";
            this.trvSceneObject.Size = new System.Drawing.Size(165, 259);
            this.trvSceneObject.TabIndex = 1;
            this.trvSceneObject.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvScene_AfterSelect);
            // 
            // propGrid
            // 
            this.propGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propGrid.Location = new System.Drawing.Point(12, 277);
            this.propGrid.Name = "propGrid";
            this.propGrid.Size = new System.Drawing.Size(332, 308);
            this.propGrid.TabIndex = 2;
            // 
            // winGLCanvas1
            // 
            this.winGLCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winGLCanvas1.Location = new System.Drawing.Point(350, 12);
            this.winGLCanvas1.Name = "winGLCanvas1";
            this.winGLCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.winGLCanvas1.Size = new System.Drawing.Size(777, 573);
            this.winGLCanvas1.TabIndex = 0;
            this.winGLCanvas1.TimerTriggerInterval = 40;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 588);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1139, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblState
            // 
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(62, 17);
            this.lblState.Text = "state info";
            // 
            // trvSceneGUI
            // 
            this.trvSceneGUI.Font = new System.Drawing.Font("宋体", 12F);
            this.trvSceneGUI.Location = new System.Drawing.Point(179, 12);
            this.trvSceneGUI.Name = "trvSceneGUI";
            this.trvSceneGUI.Size = new System.Drawing.Size(165, 259);
            this.trvSceneGUI.TabIndex = 1;
            this.trvSceneGUI.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvScene_AfterSelect);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 610);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.propGrid);
            this.Controls.Add(this.trvSceneGUI);
            this.Controls.Add(this.trvSceneObject);
            this.Controls.Add(this.winGLCanvas1);
            this.Name = "FormMain";
            this.Text = "Texture2D - CSharpGL";
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharpGL.WinGLCanvas winGLCanvas1;
        private System.Windows.Forms.TreeView trvSceneObject;
        private System.Windows.Forms.PropertyGrid propGrid;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblState;
        private System.Windows.Forms.TreeView trvSceneGUI;
    }
}