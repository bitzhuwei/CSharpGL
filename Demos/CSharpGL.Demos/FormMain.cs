using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnForm00GLCanvas_Click(object sender, EventArgs e)
        {
            (new Form00GLCanvas()).Show();
        }

        private void btnForm01Simple_Click(object sender, EventArgs e)
        {
            (new Form01Simple()).Show();
        }

        private void btnForm02EmitNormalLine_Click(object sender, EventArgs e)
        {
            (new Form02EmitNormalLine()).Show();
        }

        private void btnForm03UnProjection_Click(object sender, EventArgs e)
        {
            (new Form03UnProject()).Show();
        }
    }
}
