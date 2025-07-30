namespace demos.anything {
    partial class FormNodePropertyGrid {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            trvScene = new TreeView();
            propertyGrid1 = new PropertyGrid();
            SuspendLayout();
            // 
            // trvScene
            // 
            trvScene.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            trvScene.Location = new Point(12, 12);
            trvScene.Name = "trvScene";
            trvScene.Size = new Size(356, 426);
            trvScene.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            propertyGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            propertyGrid1.Location = new Point(374, 12);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(414, 426);
            propertyGrid1.TabIndex = 1;
            // 
            // FormPropertyGrid
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(propertyGrid1);
            Controls.Add(trvScene);
            Name = "FormPropertyGrid";
            Text = "FormPropertyGrid";
            ResumeLayout(false);
        }

        #endregion

        public TreeView trvScene;
        public PropertyGrid propertyGrid1;
    }
}