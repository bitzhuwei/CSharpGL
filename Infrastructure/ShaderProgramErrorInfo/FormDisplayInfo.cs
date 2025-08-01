using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShaderProgramErrorInfo {
    public partial class FormDisplayInfo : Form {
        private static readonly char[] separator = ['\r', '\n'];
        public FormDisplayInfo() {
            InitializeComponent();
        }

        public FormDisplayInfo(string info) {
            InitializeComponent();

            var parts = info.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in parts) {
                this.textBox1.AppendText(item);
                this.textBox1.AppendText(Environment.NewLine);
            }
        }
    }
}
