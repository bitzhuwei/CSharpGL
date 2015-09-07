using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedBook.Winforms.Demo
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {

        }

        private void btnLightingExample_Click(object sender, EventArgs e)
        {
            (new FormLightingExample()).Show();
        }

        private void btnTeapotExample_Click(object sender, EventArgs e)
        {
            (new FormTeapot()).Show();
        }

        private void btnFurRendering_Click(object sender, EventArgs e)
        {
            (new FormFurRendering()).Show();
        }

        private void btnParticleSimulatorExample_Click(object sender, EventArgs e)
        {
            (new FormParticleSimulator()).Show();
        }

        private void btnInstancedRendering_Click(object sender, EventArgs e)
        {
            (new FormInstancedRendering()).Show();
        }

        private void btnCubeMap_Click(object sender, EventArgs e)
        {
            (new FormCubeMap()).Show();
        }

        private void btnLoadTexture_Click(object sender, EventArgs e)
        {
            (new FormLoadTexture()).Show();
        }
    }
}
