using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpGL.TestHelpers
{
    public partial class FontBuilder : UserControl
    {
        public FontBuilder()
        {
            InitializeComponent();
        }

        private void FontBuilder_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(GraphicsUnit)))
            {
                this.cmbGraphicsUnit.Items.Add(item);
            }
            this.cmbGraphicsUnit.SelectedIndex = 0;
        }

        public Font GetFont()
        {
            try
            {
                string name = this.txtFontName.Text;
                float size = float.Parse(this.txtFontSize.Text);
                FontStyle style = FontStyle.Regular;
                if (chkBold.Checked) { style |= FontStyle.Bold; }
                if (chkItalic.Checked) { style |= FontStyle.Italic; }
                if (chkStrikeout.Checked) { style |= FontStyle.Strikeout; }
                if (chkUnderline.Checked) { style |= FontStyle.Underline; }
                //FontStyle.Bold
                //FontStyle.Italic
                //FontStyle.Regular
                //FontStyle.Strikeout
                //FontStyle.Underline
                //FontStyle style = (FontStyle)Enum.Parse(typeof(FontStyle), this.cmbFontStyle.SelectedItem.ToString());
                GraphicsUnit unit = (GraphicsUnit)Enum.Parse(typeof(GraphicsUnit), this.cmbGraphicsUnit.SelectedItem.ToString());
                var font = new Font(name, size, style, unit);
                return font;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
    }
}