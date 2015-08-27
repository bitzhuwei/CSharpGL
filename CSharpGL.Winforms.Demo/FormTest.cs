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

        private void btnBasis_Click(object sender, EventArgs e)
        {
            //TestUnmanagedArray.TypicalScene();
            TestUnmanagedArrayHelper.TypicalScene();
            TestProjectionFunctions.TypicalScene();
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

        private void btnFormWholeFontTextureElement_Click(object sender, EventArgs e)
        {
            (new FormWholeFontTextureElement()).Show();
        }

        private void btnFormFontElement_Click(object sender, EventArgs e)
        {
            (new FormFontElement()).Show();
        }

        private void btnTranslateOnScreen_Click(object sender, EventArgs e)
        {
            (new FormTranslateOnScreen()).Show();
        }

        private void btnLegacySimpleUIRect_Click(object sender, EventArgs e)
        {
            (new FormLegacySimpleUIRect()).Show();
            //string message = string.Format("{0}", "This is no longer useful!");
            //MessageBox.Show(message, "tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSimpleUIRect_Click(object sender, EventArgs e)
        {
            (new FormSimpleUIRect()).Show();
        }

        private void btnSimpleUIAxis_Click(object sender, EventArgs e)
        {
            (new FormSimpleUIAxis()).Show();
            //(new FormSimpleUIAxis2()).Show();
        }

        private void btnSimpleUICube_Click(object sender, EventArgs e)
        {
            (new FormSimpleUICube()).Show();
        }

        private void btnSimpleUIColorPalette_Click(object sender, EventArgs e)
        {
            (new FormSimpleUIColorIndicator()).Show();
        }

        private void btnDebugging_Click(object sender, EventArgs e)
        {
            (new FormDebugging()).Show();
        }

        private void btnFormPointSpriteStringElement_Click(object sender, EventArgs e)
        {
            (new FormPointSpriteStringElement()).Show();
        }

        private void btnSimplePointSprite_Click(object sender, EventArgs e)
        {
            FormSimplePointSpriteSettings settings = new FormSimplePointSpriteSettings();
            if (settings.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                float fontSize = settings.FontSize;
                bool foreshortening = settings.Foreshortening;
                var type = settings.FragmentShaderType;
                (new FormSimplePointSprite(fontSize, foreshortening, type)).Show();
            }
        }

        private void btnFormLegacyTexture3D_Click(object sender, EventArgs e)
        {
            (new FormLegacyTexture3D()).Show();
        }

        private void btnFormColorCodedPicking_Click(object sender, EventArgs e)
        {
            (new FormColorCodedPicking()).Show();
        }

        private void btnFormScientificVisual3DControl_Click(object sender, EventArgs e)
        {
            (new FormScientificVisual3DControl()).Show();
        }

        private void btnFormTransformFeedback_Click(object sender, EventArgs e)
        {
            (new FormTransformFeedback()).Show();
        }

        private void btnFormInstancedRendering_Click(object sender, EventArgs e)
        {

        }

        private void btnFormMapBuffer_Click(object sender, EventArgs e)
        {

        }


    }
}
