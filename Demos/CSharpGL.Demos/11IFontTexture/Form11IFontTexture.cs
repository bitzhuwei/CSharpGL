using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form11IFontTexture : Form
    {
        public Form11IFontTexture()
        {
            InitializeComponent();
        }

        private const string defaultCharSet = " \tabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890.:,;'\"(!?)+-*/=_{}[]@~#\\<>|^%$£&";

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                var font = this.fontBuilder1.GetFont();
                if (font != null)
                {
                    if (this.pictureBox1.Image != null)
                    { this.pictureBox1.Image.Dispose(); }

                    string charSet = this.txtCharSet.Text;
                    bool drawBoundary = this.chkDrawBoundary.Checked;
                    FontBitmap fontBitmap = font.GetFontBitmap(charSet, drawBoundary);
                    fontBitmap.GlyphBitmap.Save("TestFontBitmap.bmp");
                    this.pictureBox1.Image = fontBitmap.GlyphBitmap;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }
    }
}