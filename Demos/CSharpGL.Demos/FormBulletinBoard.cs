using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class FormBulletinBoard : Form
    {
        string filename;

        public bool Dump { get; set; }

        public FormBulletinBoard()
        {
            InitializeComponent();
            filename = string.Format("BulletinBoard{0:yyyy-MM-dd_HH-mm-ss.ff}.log", DateTime.Now);
        }

        public void SetContent(string str)
        {
            if (this.IsDisposed) { return; }

            if (!this.Dump)
            {
                this.textBox1.Text = str;
            }
            else
            {
                if (str != this.textBox1.Text)
                {
                    using (StreamWriter sw = new StreamWriter(filename, true))
                    {
                        sw.WriteLine(string.Format(
                            "=========================={0:yyyy-MM-dd HH:mm:ss.ff}========================", DateTime.Now));
                        sw.WriteLine(str);
                    }

                    this.textBox1.Text = str;
                }
            }
        }
    }
}
