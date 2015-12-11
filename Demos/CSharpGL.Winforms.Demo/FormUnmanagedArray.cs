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
    public partial class FormUnmanagedArray : Form
    {
        public FormUnmanagedArray()
        {
            InitializeComponent();
        }

        private void FormUnmanagedArray_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("allocated UnmanagedArrayBase: {0}", UnmanagedArrayBase.allocatedCount));
            builder.AppendLine(string.Format("disposed  UnmanagedArrayBase: {0}", UnmanagedArrayBase.disposedCount));

            this.textBox1.Text = builder.ToString();
        }
    }
}
