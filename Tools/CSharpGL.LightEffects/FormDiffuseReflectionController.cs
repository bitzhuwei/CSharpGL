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
    public partial class FormDiffuseReflectionController : Form
    {
        private DiffuseReflectionRenderer diffuseReflectionRenderer;

        public FormDiffuseReflectionController(DiffuseReflectionRenderer diffuseReflectionRenderer)
        {
            InitializeComponent();

            this.diffuseReflectionRenderer = diffuseReflectionRenderer;
            this.lblKd.Text = diffuseReflectionRenderer.Kd.ToShortString();

        }

        private void trackKd_Scroll(object sender, EventArgs e)
        {
            float value = (float)this.trackKd.Value / 20.0f;
            this.lblKd.Text = value.ToShortString();
            this.diffuseReflectionRenderer.Kd = value;
        }

        private void FormDiffuseReflectionController_Load(object sender, EventArgs e)
        {

        }
    }
}
