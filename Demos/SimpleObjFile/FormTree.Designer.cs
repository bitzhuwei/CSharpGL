namespace SimpleObjFile
{
    partial class FormTree
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
            this.trvScene = new System.Windows.Forms.TreeView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.trvScene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvScene.Location = new System.Drawing.Point(0, 0);
            this.trvScene.Name = "treeView1";
            this.trvScene.Size = new System.Drawing.Size(617, 632);
            this.trvScene.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 632);
            this.Controls.Add(this.trvScene);
            this.Name = "FormTree";
            this.Text = "FormTree";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvScene;
        private System.Windows.Forms.Timer timer1;
    }
}