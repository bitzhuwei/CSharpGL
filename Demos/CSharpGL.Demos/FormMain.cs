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

        private void btnForm01Renderer_Click(object sender, EventArgs e)
        {
            (new Form01Renderer()).Show();
        }

        private void btnForm02_Click(object sender, EventArgs e)
        {
            (new Form02OrderIndependentTransparency()).Show();
        }

        private void btnForm04SimpleCompute_Click(object sender, EventArgs e)
        {
            (new Form04SimpleCompute()).Show();
        }

        private void btnForm05ParticleSimulator_Click(object sender, EventArgs e)
        {
            (new Form05ParticleSimulator()).Show();
        }

        private void btnForm06ImageProcessing_Click(object sender, EventArgs e)
        {
            (new Form06ImageProcessing()).Show();
        }

        private void btnForm07Billboard_Click(object sender, EventArgs e)
        {
            (new Form07Billboard()).Show();
        }

        private void btnForm08AnalyzedBillboard_Click(object sender, EventArgs e)
        {
            (new Form08AnalyzedBillboard()).Show();
        }

    }
}
