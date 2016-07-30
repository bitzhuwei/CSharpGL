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
    public partial class Form11IFontTexture : Form
    {

        public Form11IFontTexture()
        {
            InitializeComponent();

            OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);

        }

        private const string defaultCharSet = " \tabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890.:,;'\"(!?)+-*/=_{}[]@~#\\<>|^%$£&";

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                var font = this.fontBuilder1.GetFont();
                if (font != null)
                {
                    string charSet = this.txtCharSet.Text;
                    FontBitmap fontBitmap = font.GetFontBitmap(charSet);
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
