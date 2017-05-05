using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL3.Demo
{
    public partial class FormMain : Form
    {
        private GLNode root;
        private RenderAction renderAction;

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
        }

    }
}
