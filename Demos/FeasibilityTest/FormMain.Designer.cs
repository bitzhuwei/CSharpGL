namespace FeasibilityTest
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
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.btnSetColor = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.drvSimuCanvas1 = new DrvSimu.DrvSimuCanvas();
            ((System.ComponentModel.ISupportInitialize)(this.drvSimuCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.Location = new System.Drawing.Point(12, 12);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(127, 23);
            this.btnAddPoint.TabIndex = 0;
            this.btnAddPoint.Text = "Add Point";
            this.btnAddPoint.UseVisualStyleBackColor = true;
            // 
            // btnSetColor
            // 
            this.btnSetColor.Location = new System.Drawing.Point(145, 12);
            this.btnSetColor.Name = "btnSetColor";
            this.btnSetColor.Size = new System.Drawing.Size(156, 23);
            this.btnSetColor.TabIndex = 1;
            this.btnSetColor.Text = "Set Color";
            this.btnSetColor.UseVisualStyleBackColor = true;
            // 
            // openFileDlg
            // 
            this.openFileDlg.Filter = "*.txt|*.txt";
            // 
            // drvSimuCanvas1
            // 
            this.drvSimuCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drvSimuCanvas1.Location = new System.Drawing.Point(12, 42);
            this.drvSimuCanvas1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.drvSimuCanvas1.Name = "drvSimuCanvas1";
            this.drvSimuCanvas1.RenderTrigger = CSharpGL.RenderTrigger.TimerBased;
            this.drvSimuCanvas1.Size = new System.Drawing.Size(713, 498);
            this.drvSimuCanvas1.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 553);
            this.Controls.Add(this.drvSimuCanvas1);
            this.Controls.Add(this.btnSetColor);
            this.Controls.Add(this.btnAddPoint);
            this.Name = "FormMain";
            this.Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.drvSimuCanvas1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddPoint;
        private System.Windows.Forms.Button btnSetColor;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private DrvSimu.DrvSimuCanvas drvSimuCanvas1;

    }
}