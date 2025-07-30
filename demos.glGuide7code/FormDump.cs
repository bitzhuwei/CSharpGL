using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demos.glGuide7code {
    public partial class FormDump : Form {
        public FormDump() {
            InitializeComponent();
        }


        public void Append(string text) {
            if (this.IsDisposed) return;

            this.textBox1.AppendText(text);
        }

        public void AppendLine() {
            if (this.IsDisposed) return;

            this.textBox1.AppendText(Environment.NewLine);
        }
        public void AppendLine(string text) {
            if (this.IsDisposed) return;

            this.textBox1.AppendText(text);
            this.textBox1.AppendText(Environment.NewLine);
        }

        public void ClearText() {
            if (this.IsDisposed) return;

            this.textBox1.Clear();
        }
    }
}
