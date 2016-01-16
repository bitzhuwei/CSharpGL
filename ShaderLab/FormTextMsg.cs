using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShaderLab
{
    public partial class FormTextMsg : Form
    {
        public FormTextMsg(string text, string title)
        {
            InitializeComponent();

            this.textBox1.Text = text;
            this.Text = title;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.Text, this.textBox1.Text);
            //return base.ToString();
        }
    }
}
