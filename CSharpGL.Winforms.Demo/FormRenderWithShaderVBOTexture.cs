using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Winforms.Demo
{
    public partial class FormRenderWithShaderVBOTexture : Form
    {
        ShaderVBOTextureElementDemo element = new ShaderVBOTextureElementDemo();

        public FormRenderWithShaderVBOTexture()
        {
            InitializeComponent();

            element.Initialize();
        }

        private void FormRenderWithShaderVBOTexture_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            element.Render(Objects.RenderModes.Render);
        }
    }
}
