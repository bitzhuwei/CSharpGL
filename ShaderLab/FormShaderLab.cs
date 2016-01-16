using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShaderLab
{
    public partial class FormShaderLab : Form
    {
        public FormShaderLab()
        {
            InitializeComponent();
        }

        private void btnOpenVertexShader_Click(object sender, EventArgs e)
        {
            if (this.openShaderFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtVertexShader.Text = File.ReadAllText(this.openShaderFile.FileName);
            }
        }

        private void btnFragmentShader_Click(object sender, EventArgs e)
        {
            if (this.openShaderFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFragmentShader.Text = File.ReadAllText(this.openShaderFile.FileName);
            }
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            try
            {
                string vert = this.txtVertexShader.Text;
                string frag = this.txtFragmentShader.Text;
                ShaderProgram program = new ShaderProgram();
                program.Create(vert, frag, null);
                MessageBox.Show("Compiled successfully!");
            }
            catch (Exception ex)
            {
                (new FormTextMsg(ex.Message, "Shader Compile Error")).Show();
            }
        }
    }
}
