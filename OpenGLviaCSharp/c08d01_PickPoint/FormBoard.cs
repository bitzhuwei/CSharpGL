using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace c08d01_PickPoint
{
    public partial class FormBoard : Form
    {
        public FormBoard()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            this.textBox1.Text = text;
        }
    }
}
