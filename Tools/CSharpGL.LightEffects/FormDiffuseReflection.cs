using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.LightEffects
{
    public partial class FormDiffuseReflection : Form
    {
        public FormDiffuseReflection()
        {
            InitializeComponent();
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {

        }

        private void FormDiffuseReflection_Load(object sender, EventArgs e)
        {
            MessageBox.Show("This is a diffuse reflection demo with point light and ambient light.");
        }
    }
}
