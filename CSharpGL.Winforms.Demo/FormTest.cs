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
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void btnUnmanagedArray_Click(object sender, EventArgs e)
        {
            UnmanagedArrayTest.TypicalScene();
            string message = string.Format("{0}", "All successfully done!");
            MessageBox.Show(message, "tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPyramidElement_Click(object sender, EventArgs e)
        {
            (new FormPyramidElement()).Show();
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            (new FormCamera()).Show();
        }

        private void btnSatelliteRotation_Click(object sender, EventArgs e)
        {
            (new FormSatelliteRotation()).Show();
        }

        private void btnCylinderElement_Click(object sender, EventArgs e)
        {
            (new FormCylinderElement()).Show();
        }

        private void btnWholeFontTextureElement_Click(object sender, EventArgs e)
        {
            (new FormWholeFontTextureElement()).Show();
        }

        private void btnFreeTypeTextVAOElement_Click(object sender, EventArgs e)
        {
            (new FormFontElement()).Show();
        }

        private void btnTranslateOnScreen_Click(object sender, EventArgs e)
        {
            (new FormTranslateOnScreen()).Show();
        }

        private void btnLegacySimpleUIRect_Click(object sender, EventArgs e)
        {
            //(new FormLegacySimpleUIRect()).Show();
            string message = string.Format("{0}", "This is no longer useful!");
            MessageBox.Show(message, "tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSimpleUIRect_Click(object sender, EventArgs e)
        {
            (new FormSimpleUIRect()).Show();
        }

        private void btnSimpleUIAxis_Click(object sender, EventArgs e)
        {
            (new FormSimpleUIAxis()).Show();
        }

    }
}
