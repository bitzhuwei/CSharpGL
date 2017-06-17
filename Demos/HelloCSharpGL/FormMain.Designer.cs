namespace HelloCSharpGL
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trvScene = new System.Windows.Forms.TreeView();
            this.propGrid = new System.Windows.Forms.PropertyGrid();
            this.winGLCanvas1 = new CSharpGL.WinGLCanvas();
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trvScene
            // 
            this.trvScene.Font = new System.Drawing.Font("宋体", 12F);
            this.trvScene.Location = new System.Drawing.Point(12, 12);
            this.trvScene.Name = "trvScene";
            this.trvScene.Size = new System.Drawing.Size(332, 259);
            this.trvScene.TabIndex = 1;
            this.trvScene.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvScene_AfterSelect);
            // 
            // propGrid
            // 
            this.propGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.propGrid.Location = new System.Drawing.Point(12, 277);
            this.propGrid.Name = "propGrid";
            this.propGrid.Size = new System.Drawing.Size(332, 321);
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
            this.winGLCanvas1.Size = new System.Drawing.Size(777, 586);
            this.winGLCanvas1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 610);
            this.Controls.Add(this.propGrid);
            this.Controls.Add(this.trvScene);
            this.Controls.Add(this.winGLCanvas1);
            this.Name = "FormMain";
            this.Text = "Hello CSharpGL";
            ((System.ComponentModel.ISupportInitialize)(this.winGLCanvas1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CSharpGL.WinGLCanvas winGLCanvas1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TreeView trvScene;
        private System.Windows.Forms.PropertyGrid propGrid;
    }
}