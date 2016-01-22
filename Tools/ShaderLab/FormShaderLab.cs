using CSharpGL.Objects.RenderContexts;
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
        private FBORenderContext renderContext;
        private string vertexShaderFilename;
        private string fragmentShaderFilename;
        public FormShaderLab()
        {
            InitializeComponent();

            // Initialises OpenGL.
            var renderContext = new FBORenderContext();

            //  Create the render context.
            renderContext.Create(GLVersion.OpenGL2_1, Width, Height, 32, null);
            renderContext.MakeCurrent();

            this.renderContext = renderContext;
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            this.renderContext.Dispose();

            base.OnHandleDestroyed(e);
        }
        private void btnOpenVertexShader_Click(object sender, EventArgs e)
        {
            if (this.openShaderFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtVertexShader.TextChanged -= txtVertexShader_TextChanged;
                this.txtVertexShader.Text = File.ReadAllText(this.openShaderFile.FileName);
                this.vertexShaderFilename = this.openShaderFile.FileName;
                //this.vertexShaderFileWatcher.Path = (new FileInfo(this.openShaderFile.FileName)).DirectoryName;
                this.txtVertexShader.TextChanged += txtVertexShader_TextChanged;
                this.btnSaveVertexShader.Enabled = false;
            }
        }

        private void btnFragmentShader_Click(object sender, EventArgs e)
        {
            if (this.openShaderFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFragmentShader.TextChanged -= txtFragmentShader_TextChanged;
                this.txtFragmentShader.Text = File.ReadAllText(this.openShaderFile.FileName);
                this.fragmentShaderFilename = this.openShaderFile.FileName;
                //this.fragmentShaderFileWatcher.Path = (new FileInfo(this.openShaderFile.FileName)).DirectoryName;
                this.txtFragmentShader.TextChanged += txtFragmentShader_TextChanged;
                this.btnSaveFragmentShader.Enabled = false;
            }
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            try
            {
                this.renderContext.MakeCurrent();

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

        private void btnSaveVertexShader_Click(object sender, EventArgs e)
        {
            File.WriteAllText(this.vertexShaderFilename, this.txtVertexShader.Text);
            this.btnSaveVertexShader.Enabled = false;
        }

        private void btnSaveFragmentShader_Click(object sender, EventArgs e)
        {
            File.WriteAllText(this.fragmentShaderFilename, this.txtFragmentShader.Text);
            this.btnSaveFragmentShader.Enabled = false;
        }

        private void txtVertexShader_TextChanged(object sender, EventArgs e)
        {
            this.btnSaveVertexShader.Enabled = true;
        }

        private void txtFragmentShader_TextChanged(object sender, EventArgs e)
        {
            this.btnSaveFragmentShader.Enabled = true;
        }

        //private void vertexShaderFileWatcher_Changed(object sender, FileSystemEventArgs e)
        //{
        //    if (e.FullPath == this.vertexShaderFilename)
        //    {
        //        using (FileStream fs = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read))
        //        {
        //            using (var sr = new StreamReader(fs))
        //            {
        //                this.txtVertexShader.Text = sr.ReadToEnd();
        //            }
        //        }
        //    }
        //}

        //private void fragmentShaderFileWatcher_Changed(object sender, FileSystemEventArgs e)
        //{
        //    if (e.FullPath == this.fragmentShaderFilename)
        //    {
        //        using (FileStream fs = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read))
        //        {
        //            using (var sr = new StreamReader(fs))
        //            {
        //                this.txtFragmentShader.Text = sr.ReadToEnd();
        //            }
        //        }
        //    }
        //}
    }
}
