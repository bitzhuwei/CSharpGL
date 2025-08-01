using System.CodeDom;

namespace TestBresenham {
    public partial class FormTriangle : Form {

        public FormTriangle() {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            var value = (int)this.numericUpDown1.Value;
            this.bresenhamDisplay1.SetPixelLength(value);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            //this.bresenhamDisplay1.showOriginalLine = this.checkBox1.Checked;
            this.bresenhamDisplay1.Invalidate();
        }
    }
}
