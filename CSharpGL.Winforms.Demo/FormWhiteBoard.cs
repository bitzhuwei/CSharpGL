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
    public partial class FormWhiteBoard : Form
    {
        public FormWhiteBoard()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            this.txtWhiteBoard.Text = text;
            this.txtWhiteBoard.ScrollToCaret();
        }

        public void AppendText(string text)
        {
            this.txtWhiteBoard.AppendText(text);
            this.txtWhiteBoard.ScrollToCaret();
        }
    }
}
