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
    public partial class FormFreeType : Form
    {
        private FreeTypeDemo freeTypeDemoElement;
        public FormFreeType()
        {
            InitializeComponent();

            freeTypeDemoElement = new FreeTypeDemo();
        }

        private void glCanvas1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            freeTypeDemoElement.render();
        }
    }
}
