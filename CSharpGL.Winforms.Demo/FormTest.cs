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
            string message = string.Format("{0}", "Done!");
            MessageBox.Show(message, "tip", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

        }

        private void btnGLCanvas_Click(object sender, EventArgs e)
        {
            (new Form1()).Show();
        }

        private void btnLegacyMultiTextureFont_Click(object sender, EventArgs e)
        {
            (new FormLegacyMultiTextureFont()).Show();
        }

        private void btnModernMultiTextureFont_Click(object sender, EventArgs e)
        {
            (new FormModernMultiTextureFont()).Show();
        }

        private void btnFreeTypeTextVAOElement_Click(object sender, EventArgs e)
        {
            //(new FormFreeTypeTextVAOElement()).Show();
        }

    }
}
