namespace CSharpGL.Demos
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
            this.btnForm07PointSprite = new System.Windows.Forms.Button();
            this.btn11IFontTexture = new System.Windows.Forms.Button();
            this.btn15UIRenderer = new System.Windows.Forms.Button();
            this.btn21ConditionalRendering = new System.Windows.Forms.Button();
            this.btn23SingleRenderer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnForm07PointSprite
            // 
            this.btnForm07PointSprite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForm07PointSprite.Font = new System.Drawing.Font("宋体", 12F);
            this.btnForm07PointSprite.Location = new System.Drawing.Point(9, 110);
            this.btnForm07PointSprite.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnForm07PointSprite.Name = "btnForm07PointSprite";
            this.btnForm07PointSprite.Size = new System.Drawing.Size(575, 30);
            this.btnForm07PointSprite.TabIndex = 0;
            this.btnForm07PointSprite.Text = "07 PointSprite";
            this.btnForm07PointSprite.UseVisualStyleBackColor = true;
            this.btnForm07PointSprite.Click += new System.EventHandler(this.btn07PointSprite_Click);
            // 
            // btn11IFontTexture
            // 
            this.btn11IFontTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn11IFontTexture.Font = new System.Drawing.Font("宋体", 12F);
            this.btn11IFontTexture.Location = new System.Drawing.Point(9, 145);
            this.btn11IFontTexture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn11IFontTexture.Name = "btn11IFontTexture";
            this.btn11IFontTexture.Size = new System.Drawing.Size(575, 30);
            this.btn11IFontTexture.TabIndex = 0;
            this.btn11IFontTexture.Text = "11 FontTexture";
            this.btn11IFontTexture.UseVisualStyleBackColor = true;
            this.btn11IFontTexture.Click += new System.EventHandler(this.btn11IFontTexture_Click);
            // 
            // btn15UIRenderer
            // 
            this.btn15UIRenderer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn15UIRenderer.Font = new System.Drawing.Font("宋体", 12F);
            this.btn15UIRenderer.Location = new System.Drawing.Point(9, 212);
            this.btn15UIRenderer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn15UIRenderer.Name = "btn15UIRenderer";
            this.btn15UIRenderer.Size = new System.Drawing.Size(575, 30);
            this.btn15UIRenderer.TabIndex = 0;
            this.btn15UIRenderer.Text = "15 UIenderer";
            this.btn15UIRenderer.UseVisualStyleBackColor = true;
            this.btn15UIRenderer.Click += new System.EventHandler(this.btn15UIRenderer_Click);
            // 
            // btn21ConditionalRendering
            // 
            this.btn21ConditionalRendering.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn21ConditionalRendering.Font = new System.Drawing.Font("宋体", 12F);
            this.btn21ConditionalRendering.Location = new System.Drawing.Point(9, 314);
            this.btn21ConditionalRendering.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn21ConditionalRendering.Name = "btn21ConditionalRendering";
            this.btn21ConditionalRendering.Size = new System.Drawing.Size(575, 30);
            this.btn21ConditionalRendering.TabIndex = 0;
            this.btn21ConditionalRendering.Text = "21 Conditional Rendering";
            this.btn21ConditionalRendering.UseVisualStyleBackColor = true;
            this.btn21ConditionalRendering.Click += new System.EventHandler(this.btn21ConditionalRendering_Click);
            // 
            // btn23SingleRenderer
            // 
            this.btn23SingleRenderer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn23SingleRenderer.Font = new System.Drawing.Font("宋体", 12F);
            this.btn23SingleRenderer.Location = new System.Drawing.Point(9, 42);
            this.btn23SingleRenderer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn23SingleRenderer.Name = "btn23SingleRenderer";
            this.btn23SingleRenderer.Size = new System.Drawing.Size(575, 30);
            this.btn23SingleRenderer.TabIndex = 0;
            this.btn23SingleRenderer.Text = "23 Single Renderer";
            this.btn23SingleRenderer.UseVisualStyleBackColor = true;
            this.btn23SingleRenderer.Click += new System.EventHandler(this.btn23SingleRenderer_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 647);
            this.Controls.Add(this.btn23SingleRenderer);
            this.Controls.Add(this.btn21ConditionalRendering);
            this.Controls.Add(this.btn15UIRenderer);
            this.Controls.Add(this.btn11IFontTexture);
            this.Controls.Add(this.btnForm07PointSprite);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSharpGL Test/Demo Panel - http://bitzhuwei.cnblogs.com";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnForm07PointSprite;
        private System.Windows.Forms.Button btn11IFontTexture;
        private System.Windows.Forms.Button btn15UIRenderer;
        private System.Windows.Forms.Button btn21ConditionalRendering;
        private System.Windows.Forms.Button btn23SingleRenderer;
    }
}