using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestBresenham {
    public partial class FormInfo : Form {
        private readonly BresenhamDisplay mainForm;

        public FormInfo(BresenhamDisplay mainForm) {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        public void UpdateInfo() {
            if (this.IsDisposed) return;

            this.textBox1.Clear();
            this.textBox1.AppendText("start: ");
            this.textBox1.AppendText(this.mainForm.lastStart.ToString());
            this.textBox1.AppendText(Environment.NewLine);
            this.textBox1.AppendText("end:   ");
            this.textBox1.AppendText(this.mainForm.lastEnd.ToString());
            this.textBox1.AppendText(Environment.NewLine);
            this.textBox1.AppendText("selected pixels:");
            foreach (var item in this.mainForm.bresenhamPoints) {
                this.textBox1.AppendText(item.ToString());
                this.textBox1.AppendText(Environment.NewLine);
            }
        }
    }
}
