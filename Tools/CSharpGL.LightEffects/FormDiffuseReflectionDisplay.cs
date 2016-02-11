using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.LightEffects
{
    public partial class FormDiffuseReflectionDisplay : Form
    {
        private DiffuseReflectionRenderer renderer;
        public FormDiffuseReflectionDisplay(DiffuseReflectionRenderer renderer)
        {
            InitializeComponent();

            this.renderer = renderer;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("projection matrix:");
            builder.AppendLine(string.Format("{0}", this.renderer.projectionMatrix));
            builder.AppendLine("view matrix:");
            builder.AppendLine(string.Format("{0}", this.renderer.viewMatrix));
            builder.AppendLine("model matrix:");
            builder.AppendLine(string.Format("{0}", this.renderer.modelMatrix));

            this.textBox1.Text = builder.ToString();
        }

    }
}
