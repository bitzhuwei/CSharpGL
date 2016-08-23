using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btn00GLCanvas_Click(object sender, EventArgs e)
        {
            (new Form00GLCanvas()).Show();
        }

        private void btn01Renderer_Click(object sender, EventArgs e)
        {
            (new Form01Renderer()).Show();
        }

        private void btn02OrderIndependentTransparency_Click(object sender, EventArgs e)
        {
            (new Form02OrderIndependentTransparency()).Show();
        }

        private void btn04SimpleCompute_Click(object sender, EventArgs e)
        {
            (new Form04SimpleCompute()).Show();
        }

        private void btn05ParticleSimulator_Click(object sender, EventArgs e)
        {
            (new Form05ParticleSimulator()).Show();
        }

        private void btn06ImageProcessing_Click(object sender, EventArgs e)
        {
            (new Form06ImageProcessing()).Show();
        }

        private void btn07PointSprite_Click(object sender, EventArgs e)
        {
            (new Form07PointSprite()).Show();
        }

        private void btn08AnalyzedPointSprite_Click(object sender, EventArgs e)
        {
            (new Form08AnalyzedPointSprite()).Show();
        }

        private void btn09UIRenderer_Click(object sender, EventArgs e)
        {
            //(new Form09UIRenderer()).Show();
        }

        private void btn10RaycastVolumeRenderer_Click(object sender, EventArgs e)
        {
            (new Form10RaycastVolumeRenderer()).Show();
        }

        private void btn11IFontTexture_Click(object sender, EventArgs e)
        {
            (new Form11IFontTexture()).Show();
        }

        private void btn12Billboard_Click(object sender, EventArgs e)
        {
            (new Form12Billboard()).Show();
        }

        private void btn13SimplexNoise_Click(object sender, EventArgs e)
        {
            (new Form13SimplexNoise()).Show();
        }

        private void btn14ShaderToy_Click(object sender, EventArgs e)
        {
            (new Form14ShaderToy()).Show();
        }

        private void btn15UIRenderer_Click(object sender, EventArgs e)
        {
            (new Form15UIRenderer()).Show();
        }

        private void btn16ArcBallManipulater_Click(object sender, EventArgs e)
        {
            (new Form16ArcBallManipulater()).Show();
        }

        private void btn17UpdateTexture_Click(object sender, EventArgs e)
        {
            (new Form17UpdateTexture()).Show();
        }

    }
}
