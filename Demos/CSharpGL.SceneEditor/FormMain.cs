using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.SceneEditor
{
    public partial class FormMain : Form
    {
        const string strOpenGL = "OpenGL";

        [Category(strOpenGL)]
        public Scene Scene { get; set; }

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
        }


    }
}
