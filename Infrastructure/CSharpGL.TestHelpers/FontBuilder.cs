using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL.TestHelpers
{
    public partial class FontBuilder : UserControl
    {
        public FontBuilder()
        {
            InitializeComponent();
        }

        class EnumItem<T> where T : struct
        {

        }
        private void FontBuilder_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(FontStyle)))
            {
                this.cmbFontStyle.Items.Add(item);
            }
            this.cmbFontStyle.SelectedIndex = 0;
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
                FontStyle style = (FontStyle)Enum.Parse(typeof(FontStyle), this.cmbFontStyle.SelectedItem.ToString());
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
