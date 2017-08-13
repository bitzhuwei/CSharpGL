using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/bitzhuwei/CSharpGL.Data");
        }

        private void btn07PointSprite_Click(object sender, EventArgs e)
        {
            (new Form07PointSprite()).Show();
        }

        private void btn11IFontTexture_Click(object sender, EventArgs e)
        {
            (new Form11IFontTexture()).Show();
        }

        private void btn15UIRenderer_Click(object sender, EventArgs e)
        {
            (new Form15UIRenderer()).Show();
        }

        private void btn21ConditionalRendering_Click(object sender, EventArgs e)
        {
            (new Form21ConditionalRendering()).Show();
        }

        private void btn23SingleRenderer_Click(object sender, EventArgs e)
        {
            (new Form23SingleRenderer()).Show();
        }

    }
}