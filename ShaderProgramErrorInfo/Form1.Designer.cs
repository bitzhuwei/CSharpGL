namespace ShaderProgramErrorInfo {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            tabControl1 = new TabControl();
            tabVertexShader = new TabPage();
            txtVertexShader = new TextBox();
            tabTessellationControlShader = new TabPage();
            txtTessellationControlShader = new TextBox();
            tabTessellationEvaluationShader = new TabPage();
            txtTessellationEvaluationShader = new TextBox();
            tabGeometryShader = new TabPage();
            txtGeometryShader = new TextBox();
            tabFragmentShader = new TabPage();
            txtFragmentShader = new TextBox();
            tabComputeShader = new TabPage();
            txtComputeShader = new TextBox();
            btnCompile = new Button();
            tabControl1.SuspendLayout();
            tabVertexShader.SuspendLayout();
            tabTessellationControlShader.SuspendLayout();
            tabTessellationEvaluationShader.SuspendLayout();
            tabGeometryShader.SuspendLayout();
            tabFragmentShader.SuspendLayout();
            tabComputeShader.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabVertexShader);
            tabControl1.Controls.Add(tabTessellationControlShader);
            tabControl1.Controls.Add(tabTessellationEvaluationShader);
            tabControl1.Controls.Add(tabGeometryShader);
            tabControl1.Controls.Add(tabFragmentShader);
            tabControl1.Controls.Add(tabComputeShader);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 391);
            tabControl1.TabIndex = 0;
            // 
            // tabVertexShader
            // 
            tabVertexShader.Controls.Add(txtVertexShader);
            tabVertexShader.Location = new Point(4, 29);
            tabVertexShader.Name = "tabVertexShader";
            tabVertexShader.Padding = new Padding(3);
            tabVertexShader.Size = new Size(768, 358);
            tabVertexShader.TabIndex = 0;
            tabVertexShader.Text = "*.vert";
            tabVertexShader.UseVisualStyleBackColor = true;
            // 
            // txtVertexShader
            // 
            txtVertexShader.Dock = DockStyle.Fill;
            txtVertexShader.Location = new Point(3, 3);
            txtVertexShader.Multiline = true;
            txtVertexShader.Name = "txtVertexShader";
            txtVertexShader.ScrollBars = ScrollBars.Both;
            txtVertexShader.Size = new Size(762, 352);
            txtVertexShader.TabIndex = 0;
            // 
            // tabTessellationControlShader
            // 
            tabTessellationControlShader.Controls.Add(txtTessellationControlShader);
            tabTessellationControlShader.Location = new Point(4, 29);
            tabTessellationControlShader.Name = "tabTessellationControlShader";
            tabTessellationControlShader.Size = new Size(768, 358);
            tabTessellationControlShader.TabIndex = 2;
            tabTessellationControlShader.Text = "*.tesc";
            tabTessellationControlShader.UseVisualStyleBackColor = true;
            // 
            // txtTessellationControlShader
            // 
            txtTessellationControlShader.Dock = DockStyle.Fill;
            txtTessellationControlShader.Location = new Point(0, 0);
            txtTessellationControlShader.Multiline = true;
            txtTessellationControlShader.Name = "txtTessellationControlShader";
            txtTessellationControlShader.ScrollBars = ScrollBars.Both;
            txtTessellationControlShader.Size = new Size(768, 358);
            txtTessellationControlShader.TabIndex = 2;
            // 
            // tabTessellationEvaluationShader
            // 
            tabTessellationEvaluationShader.Controls.Add(txtTessellationEvaluationShader);
            tabTessellationEvaluationShader.Location = new Point(4, 29);
            tabTessellationEvaluationShader.Name = "tabTessellationEvaluationShader";
            tabTessellationEvaluationShader.Size = new Size(768, 358);
            tabTessellationEvaluationShader.TabIndex = 3;
            tabTessellationEvaluationShader.Text = "*.tese";
            tabTessellationEvaluationShader.UseVisualStyleBackColor = true;
            // 
            // txtTessellationEvaluationShader
            // 
            txtTessellationEvaluationShader.Dock = DockStyle.Fill;
            txtTessellationEvaluationShader.Location = new Point(0, 0);
            txtTessellationEvaluationShader.Multiline = true;
            txtTessellationEvaluationShader.Name = "txtTessellationEvaluationShader";
            txtTessellationEvaluationShader.ScrollBars = ScrollBars.Both;
            txtTessellationEvaluationShader.Size = new Size(768, 358);
            txtTessellationEvaluationShader.TabIndex = 2;
            // 
            // tabGeometryShader
            // 
            tabGeometryShader.Controls.Add(txtGeometryShader);
            tabGeometryShader.Location = new Point(4, 29);
            tabGeometryShader.Name = "tabGeometryShader";
            tabGeometryShader.Size = new Size(768, 358);
            tabGeometryShader.TabIndex = 4;
            tabGeometryShader.Text = "*.geom";
            tabGeometryShader.UseVisualStyleBackColor = true;
            // 
            // txtGeometryShader
            // 
            txtGeometryShader.Dock = DockStyle.Fill;
            txtGeometryShader.Location = new Point(0, 0);
            txtGeometryShader.Multiline = true;
            txtGeometryShader.Name = "txtGeometryShader";
            txtGeometryShader.ScrollBars = ScrollBars.Both;
            txtGeometryShader.Size = new Size(768, 358);
            txtGeometryShader.TabIndex = 2;
            // 
            // tabFragmentShader
            // 
            tabFragmentShader.Controls.Add(txtFragmentShader);
            tabFragmentShader.Location = new Point(4, 29);
            tabFragmentShader.Name = "tabFragmentShader";
            tabFragmentShader.Padding = new Padding(3);
            tabFragmentShader.Size = new Size(768, 358);
            tabFragmentShader.TabIndex = 1;
            tabFragmentShader.Text = "*.frag";
            tabFragmentShader.UseVisualStyleBackColor = true;
            // 
            // txtFragmentShader
            // 
            txtFragmentShader.Dock = DockStyle.Fill;
            txtFragmentShader.Location = new Point(3, 3);
            txtFragmentShader.Multiline = true;
            txtFragmentShader.Name = "txtFragmentShader";
            txtFragmentShader.ScrollBars = ScrollBars.Both;
            txtFragmentShader.Size = new Size(762, 352);
            txtFragmentShader.TabIndex = 0;
            // 
            // tabComputeShader
            // 
            tabComputeShader.Controls.Add(txtComputeShader);
            tabComputeShader.Location = new Point(4, 29);
            tabComputeShader.Name = "tabComputeShader";
            tabComputeShader.Size = new Size(768, 358);
            tabComputeShader.TabIndex = 5;
            tabComputeShader.Text = "*.comp";
            tabComputeShader.UseVisualStyleBackColor = true;
            // 
            // txtComputeShader
            // 
            txtComputeShader.Dock = DockStyle.Fill;
            txtComputeShader.Location = new Point(0, 0);
            txtComputeShader.Multiline = true;
            txtComputeShader.Name = "txtComputeShader";
            txtComputeShader.ScrollBars = ScrollBars.Both;
            txtComputeShader.Size = new Size(768, 358);
            txtComputeShader.TabIndex = 1;
            // 
            // btnCompile
            // 
            btnCompile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCompile.Location = new Point(694, 409);
            btnCompile.Name = "btnCompile";
            btnCompile.Size = new Size(94, 29);
            btnCompile.TabIndex = 0;
            btnCompile.Text = "编译";
            btnCompile.UseVisualStyleBackColor = true;
            btnCompile.Click += btnCompile_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCompile);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "GLSL shader 编译";
            tabControl1.ResumeLayout(false);
            tabVertexShader.ResumeLayout(false);
            tabVertexShader.PerformLayout();
            tabTessellationControlShader.ResumeLayout(false);
            tabTessellationControlShader.PerformLayout();
            tabTessellationEvaluationShader.ResumeLayout(false);
            tabTessellationEvaluationShader.PerformLayout();
            tabGeometryShader.ResumeLayout(false);
            tabGeometryShader.PerformLayout();
            tabFragmentShader.ResumeLayout(false);
            tabFragmentShader.PerformLayout();
            tabComputeShader.ResumeLayout(false);
            tabComputeShader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabVertexShader;
        private TabPage tabFragmentShader;
        private Button btnCompile;
        private TextBox txtVertexShader;
        private TextBox txtFragmentShader;
        private TabPage tabTessellationControlShader;
        private TabPage tabTessellationEvaluationShader;
        private TabPage tabGeometryShader;
        private TabPage tabComputeShader;
        private TextBox txtGeometryShader;
        private TextBox txtComputeShader;
        private TextBox txtTessellationControlShader;
        private TextBox txtTessellationEvaluationShader;
    }
}
