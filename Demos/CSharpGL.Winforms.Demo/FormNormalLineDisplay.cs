using CSharpGL.Objects.Demos;
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
    public partial class FormNormalLineDisplay : Form
    {
        private NormalLineRenderer renderer;
        public FormNormalLineDisplay(NormalLineRenderer renderer)
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
